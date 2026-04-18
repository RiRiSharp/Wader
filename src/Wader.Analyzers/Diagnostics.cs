using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.Language;

namespace Wader.Analyzers;

internal static class Diagnostics
{
    public const string IdRequireParenthesesRazorExpression = "WADER001";
    public static readonly RazorDiagnosticDescriptor RequireParathesesRazorExpression = new(
        IdRequireParenthesesRazorExpression,
        () => "Razor expressions must be parenthesized",
        RazorDiagnosticSeverity.Warning
    );

    public const string IdRequireNameCascadingParameter = "WADER002";
    public static readonly RazorDiagnosticDescriptor RequireNameCascadingParameter = new(
        IdRequireNameCascadingParameter,
        () => $"Cascading parameter must have the {nameof(CascadingParameterAttribute.Name)} parameter set",
        RazorDiagnosticSeverity.Warning
    );

    public const string IdRequireCodeInSeparateFile = "WADER003";
    public static readonly RazorDiagnosticDescriptor RequireCodeInSeparateFile = new(
        IdRequireNameCascadingParameter,
        () => "All C# code must be in a separate .razor.cs file",
        RazorDiagnosticSeverity.Warning
    );
}
