---
scope: js-interop-tests
applies_to:
  - "**/*JsInteropTests.cs"
  - "**/Tests/**/Internals/*JsInteropTests.cs"
intent: Enforce minimal, boring, call-forwarding unit tests for JsInterop wrappers
---

## JavaScript Interop Test Conventions (`*JsInteropTests`)

Unit tests for `*JsInterop` classes are intentionally **boring, repetitive, and explicit**.  
Their sole purpose is to verify that the correct JavaScript function name and arguments are forwarded to `IJSObjectReference`.

These tests exist to **lock down regressions**, not to provide architectural confidence.

### Core Rule (Non‑Negotiable)

Each test must assert **exactly one thing**:

> *Calling method X results in a call to JS function Y with arguments Z.*

Nothing more.

### Required Structure

Each test must follow this structure:

1. **Arrange**
   - Create a substituted `IJSObjectReference`
   - Construct the `*JsInterop` instance directly
   - Use `ElementReference = default`
   - Keep options objects minimal and inline

2. **Act**
   - Call exactly one public method on the SUT

3. **Assert**
   - Use `AssertJsInterop.Calls(...)`
   - Assert only the JS function name and arguments

Example (canonical):

```csharp
[Fact]
public async Task ToggleCallsCorrectJsFunctionAsync()
{
    // Arrange
    var jsObj = Substitute.For<IJSObjectReference>();
    await using var sut = new BsModalJsInterop(jsObj);
    ElementReference modalRef = default;

    // Act
    await sut.ToggleAsync(modalRef);

    // Assert
    AssertJsInterop.Calls(jsObj, BsModalJsInterop.TOGGLE, modalRef);
}
```
## What These Tests Must NOT Do

The following are **explicitly forbidden** in \*JsInteropTests:

- ❌ Inheriting from BunitContext
- ❌ Using bUnit, render trees, or JS runtimes
- ❌ Testing disposal of IJSObjectReference via Received()
- ❌ Verifying call counts beyond the helper assertion
- ❌ Inspecting serialization behavior
- ❌ Testing option contents, defaults, or validation
- ❌ Mocking anything other than IJSObjectReference
If a test starts to “feel” like an integration test, it is wrong.

## Disposal Semantics

DisposeAsync() behavior is not tested directly
Only explicit JS-facing disposal methods are tested

**Allowed**
```csharp
await sut.DisposeReferenceAsync(elementRef);
AssertJsInterop.Calls(jsObj, BsXxxJsInterop.DISPOSE, elementRef);
```

**Not allowed**
```csharp
await jsObj.Received(1).DisposeAsync()
```

Lifetime correctness is verified at higher layers.

## Options Objects
When testing methods that accept an options object:

- Provide a minimal, valid instance
- Do not assert on internal option fields
- Do not test object shape or defaults

Example
```csharp
var options = new PopoverJsOptions
{
    Placement = "top",
    Trigger = "click"
};
```
The test asserts forwarding, not correctness.

## One Test = One JS Function

- Each JS constant exposed by the interop class must have exactly one test
- Test names must follow the pattern: `{MethodName}CallsCorrectJsFunctionAsync`

## Why this is strict
JsInterop tests exist to:

- Prevent accidental renaming of JS functions
- Prevent argument reordering
- Prevent silent removal of calls

They are not:

- Documentation
- Safety nets for Bootstrap behavior
- A place for creativity

If a test looks "smart", it is almost certainly wrong.