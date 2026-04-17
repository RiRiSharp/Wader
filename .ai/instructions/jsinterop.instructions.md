---
scope: js-interop
applies_to:
  - "**/*JsInterop.cs"
  - "**/Internals/*JsInterop.cs"
intent: Define strict conventions for JavaScript interop wrappers
---

## JavaScript Interop Conventions (`*JsInterop`)

Files named `*JsInterop` represent **thin, deterministic wrappers** around Bootstrap-related JavaScript functionality. They exist solely to bridge Blazor and JavaScript, not to introduce abstraction, logic, or state.

### Core Principles

- **No business logic**
  - These classes must only forward calls to JavaScript.
  - No conditionals, retries, fallbacks, or inferred behavior.

- **One JS object reference per wrapper**
  - Each instance owns exactly one `IJSObjectReference`.
  - Wrapper lifetime maps 1:1 to the JS object lifecycle.

- **Explicit JS identifiers**
  - All JavaScript function names must be declared as `internal const string`.
  - No inline string literals inside `Invoke*Async` calls.

- **Method names mirror JavaScript**
  - Public async methods correspond directly to JS functions.
  - Avoid semantic reinterpretation (`CreateOrUpdateAsync`, not `EnsureAsync`).

### Lifetime & Disposal

- Every `*JsInterop` must implement `IAsyncDisposable`.
- `DisposeAsync` must:
  - Dispose the underlying `IJSObjectReference`
  - Perform no additional logic
  - Not swallow or translate exceptions

If the JavaScript implementation requires element-level cleanup:
- Expose a **separate explicit method**
  - Example: `DisposeReferenceAsync(ElementReference)`
- Do not overload `DisposeAsync` with element semantics.

### Parameters & Boundary Rules

Only simple, serializable Blazor primitives may cross the JS boundary:

- `ElementReference`
- Plain option objects (POCOs)
- Simple value types

The following are **not allowed**:
- Component instances
- Delegates or callbacks
- Framework or application services

Interop serialization must remain predictable and explicit.

### Error Handling

- Do not catch JavaScript exceptions
- Do not translate or wrap errors
- Errors should surface immediately and fail fast

Validation and misuse protection belong in higher layers, never here.

### File & Naming Conventions

- File name: `BsXxxJsInterop.cs`
- Namespace must include `.Internals`
- Each interop wrapper must expose the JS asset name:

  ```csharp
  public static string JsFileName => "xyzFunctions.js";
  ```