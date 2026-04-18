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
        () => "Razor expressions must be parenthesized",
        RazorDiagnosticSeverity.Warning
    );
}
