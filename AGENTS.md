# Agent Instructions

Instructions for GitHub Copilot and other AI coding agents working with the Wader repository.

## Repository Overview

**Wader** is a Blazor component library built on top of Bootstrap 5.
It wraps Bootstrap's markup and behavior in strongly-typed Blazor components, while adding quality-of-life improvements that go beyond a thin abstraction.

The components are implemented as Razor class libraries targeting .NET 10.
The library is designed to integrate cleanly with the broader ASP.NET ecosystem instead of working around it.
Where ASP.NET already provides solid primitives, Wader extends them rather than replacing them.

A key goal is to harmonize Bootstrap with existing ASP.NET and Blazor packages.
This includes adapting and extending built‑in components such as InputSelect, so that they behave consistently with Bootstrap styling, validation, and accessibility expectations.

Wader also provides optional integrations, including an icon system with support for Bootstrap Icons and Phosphor Icons, without forcing additional dependencies on consumers that do not need them.

The overall focus of the project is predictability, composability, and reducing friction when building Bootstrap-based Blazor applications, while keeping close alignment with the underlying framework rather than hiding it.

### Key Projects

- **Wader.Bootstrap**: Core Bootstrap 5 Razor component library — the primary deliverable.
- **Wader.Icons**: Icon components wrapping Bootstrap Icons 1.13.1 and Phosphor Icons 2.0.8.
- **Wader.Site**: Blazor WebAssembly demo and documentation app.
- **Wader.Bootstrap.Tests**: xUnit + bUnit test suite for `Wader.Bootstrap`.

### Technology Stack

- .NET 10.0 (SDK 10.0.0, `rollForward: latestMinor`, `allowPrerelease: false`)
- C# with file-scoped namespaces, `var`-everywhere, nullable reference types enabled
- Razor Class Libraries (`Microsoft.NET.Sdk.Razor`)
- Bootstrap 5.3.8 (CSS/JS bundled in `wwwroot/`)
- xUnit 2.9.3 + bUnit 2.5.3 for component testing
- NSubstitute 5.3.0 for mocking
- CSharpier (`CSharpier.MsBuild`) — formatting enforced at build time
- Roslynator analyzers on all projects
- Central Package Management via `Directory.Packages.props`

## General

- Make only high-confidence suggestions when reviewing code changes.
- Always use the latest C# language features appropriate to C# 13 / .NET 10.
- Never change `global.json` unless explicitly asked to.
- Never change `Directory.Packages.props` package versions unless explicitly asked to.
- Warnings are treated as errors (`TreatWarningsAsErrors = true`) — do not introduce new warnings.
- All analyzers are enabled (`AnalysisMode = All`) — code must pass analysis cleanly.
- Code style is enforced at build time (`EnforceCodeStyleInBuild = true`).
- Namespace must match folder path (`dotnet_style_namespace_match_folder = true`).
- Prefer `internal` over `public` — only expose publicly what adds value to the package, and every public member must be backed by at least one test.
- Enum extension methods are always in the same file as the enum.
  Other than that, all C# files contain exactly one class/enum/record.

## Formatting

- Code formatting is enforced by **CSharpier** at build time. Write code that CSharpier would not reformat.
- Apply the style rules defined in `.editorconfig`.
- Use file-scoped namespace declarations.
- Use single-line `using` directives; sort system directives first; do not separate groups.
- Line endings: LF. Indent: 4 spaces. Max line length: 120 characters.
- `var` is preferred everywhere (enforced by `.editorconfig`).
- Do not use `this.` qualification on any member.
- Do not use primary constructors (`.editorconfig`: `csharp_style_prefer_primary_constructors = false`), except in test base classes where they are already established.
- Expression-bodied members are preferred for simple properties and methods.
- Insert a newline before the opening curly brace of any code block (after `if`, `for`, `foreach`, `using`, `try`, etc.).
- Ensure the final return statement of a method is on its own line.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.
- All parameters for razor components should be enclosed like `<Component Param="@(LikeThis)"/>`, so in quotes and with `@()`.

### Nullable Reference Types

- Declare variables non-nullable and check for `null` at entry points.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Trust the C# null annotations; do not add null checks when the type system says a value cannot be null.

## Component Architecture

### `BsComponent` Base Class

Every Bootstrap component inherits from `BsComponent` (or `BsChildContentComponent` for components with child content). The base class:

- Captures all unmatched HTML attributes via `[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes`.
- Merges user-supplied CSS classes with component Bootstrap classes in `OnParametersSet` via `BsAttributeUtilities.AssignClassNames`.
- Requires subclasses to implement the `BsComponentClasses` abstract property returning the component's Bootstrap CSS class string.

### Bootstrap Flavour Enums

When a component supports multiple visual variants driven by Bootstrap CSS classes, represent them as an enum.
Map the enum to its Bootstrap class string via an extension method named `ToBootstrapClass()`, defined in the same file as the enum.

### Partial Class Pattern

Every Razor component is split into two files:

- `ComponentName.razor` — markup only
- `ComponentName.razor.cs` — code-behind (`partial class`)

Always maintain this split when adding or modifying components. Do not put logic in `.razor` files.

### Adding a New Component to Wader.Bootstrap

Only do this when asked to.
This component should also exist in Bootstrap.
1. Create a folder under `src/Wader.Bootstrap/Components/<ComponentName>/`.
2. Add `BsComponentName.razor` and `BsComponentName.razor.cs` following existing component patterns.
3. Implement `BsComponentClasses` to return the correct Bootstrap CSS class string.
4. Add a corresponding test class under `tests/Wader.Bootstrap.Tests/Components/<ComponentName>/` inheriting from `BsComponentTests<BsComponentName>`.

## Building

Build with standard `dotnet` commands — no custom restore scripts are required.

```bash
# Restore and build all projects
dotnet build

# Build a specific project
dotnet build src/Wader.Bootstrap/Wader.Bootstrap.csproj

# Build in Release
dotnet build -c Release
```

CSharpier formatting and Roslynator analysis run automatically during the build.
Fix all warnings before committing — warnings are errors.

## Testing

Tests use **xUnit 2.9.3** and **bUnit 2.5.3** (standard VSTest runner via `Microsoft.NET.Test.Sdk`).

```bash
# Run all tests
dotnet test tests/Wader.Bootstrap.Tests/Wader.Bootstrap.Tests.csproj

# Run tests without rebuilding (only if no code changes since last build)
dotnet test tests/Wader.Bootstrap.Tests/Wader.Bootstrap.Tests.csproj --no-build

# Run a specific test class
dotnet test tests/Wader.Bootstrap.Tests/Wader.Bootstrap.Tests.csproj --filter "FullyQualifiedName~AlertTests"

# Run a specific test method
dotnet test tests/Wader.Bootstrap.Tests/Wader.Bootstrap.Tests.csproj --filter "FullyQualifiedName~AlertTests.DefaultWorks"
```

### Test Conventions

- Every component test class inherits from `BsComponentTests<TComponent>`, whenever possible, and is placed in a file mirroring the component's folder structure.
- `BsComponentTests<T>` provides three tests for free: `DefaultWorks`, `PassingClassesWorks`, and `ExtraAttributesWorks`.
  Do not duplicate these.
- Form input component tests inherit from `BsInputBaseComponentTests<TComponent, TValue>` instead, which extends `BsComponentTests<TComponent>` and binds the `Value` parameter automatically.
- Use **NSubstitute** for mocking; it is the only mocking library in the project.
- All tests should emit "Arrange", "Act", or "Assert" comments.
- Copy existing capitalization and naming style from nearby test files.
- Do not leave newly added tests commented out. All added tests must build and pass.
- Do not use `Directory.SetCurrentDirectory` in tests — it causes side effects when tests run concurrently.
- Test classes must be `public` (suppression `CA1515` is applied in the test project).
- The `RZ2012` warning is suppressed in the test project so parameters can be set individually in tests.
- Tests naming does not use underscores, but are also PascalCase.
- All public methods should be tested, as they form a contract.

### Test Helper Methods (on `BsComponentTests<T>`)

| Method | Purpose |
|--------|---------|
| `TestForAllowingOverride(...)` | Asserts a parameter value can be overridden via `AdditionalAttributes` |
| `TestForDisallowingOverride(...)` | Asserts a parameter value cannot be overridden |
| `TestForCascadingValue<T>(...)` | Asserts the component exposes a `CascadingValue<T>` to its subtree |

## Project Layout

```
Wader.slnx                          Solution file (slnx format)
Directory.Build.props               Shared MSBuild properties for all projects
Directory.Packages.props            Central NuGet package version management
global.json                         SDK version pin
.editorconfig                       Code style and analyzer configuration

src/
  Wader.Bootstrap/                  Core Bootstrap Razor component library
    BaseComponents/                 BsComponent, BsChildContentComponent + interfaces
    Components/                     Bootstrap UI components (Accordion, Alert, …)
    Content/                        Typography/content elements (Headings, Tables, …)
    Forms/                          Form components (InputBase, Selects, Validation, …)
    Helpers/                        Layout helpers (BsDisplayFlex, …)
    Internals/                      BsAttributeUtilities, JS interop, logging, extensions
    Layout/                         Layout components
    Primitives/                     Primitive building blocks
    wwwroot/                        Bootstrap CSS and JS bundles

  Wader.Icons/                      Icon component library
    Bootstrap/                      Bootstrap Icons components
    Phosphor/                       Phosphor Icons components
    wwwroot/                        Icon font/asset files

  Wader.Site/                       Demo Blazor WASM app
    Pages/                          Demo pages per component
    SassStyling/                    SASS source files (compiled via sasscompiler.json)

tests/
  Wader.Bootstrap.Tests/            Component tests (xUnit + bUnit)
    Components/                     Mirrors src/Wader.Bootstrap/Components/
    Content/                        Mirrors src/Wader.Bootstrap/Content/
    Forms/                          Mirrors src/Wader.Bootstrap/Forms/
    Internals/                      Internal utility tests
    Layout/                         Layout component tests

branding/                           Logo assets included in NuGet packages
```

## Key Configuration Files

| File | Purpose |
|------|---------|
| `global.json` | SDK version pin — never modify |
| `Directory.Build.props` | Global MSBuild properties, analyzers, packaging |
| `Directory.Packages.props` | Central NuGet package versions — do not change versions without being asked |
| `.editorconfig` | Code style, formatting, analyzer severity |
| `Wader.slnx` | Solution file (new XML-based `.slnx` format) |
| `src/Wader.Bootstrap/wwwroot/` | Bootstrap static assets bundled with the library |

## Markdown Files

- Markdown files should not have multiple consecutive blank lines.
- Every new sentence should start on a new line.
- Code blocks must use triple backticks (` ``` `) and include a language identifier for syntax highlighting.
- JSON code blocks should be properly indented.
