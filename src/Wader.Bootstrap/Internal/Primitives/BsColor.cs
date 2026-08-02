namespace Wader.Bootstrap.Internal.Primitives;

public enum BsColor
{
    Primary = 0,
    Secondary = 1,
    Success = 2,
    Info = 3,
    Warning = 4,
    Danger = 5,
    Light = 6,
    Dark = 7,
}

internal static class BsProgressBarBackgroundExtensions
{
    internal static string ToBackgroundClass(this BsColor color)
    {
        return color switch
        {
            BsColor.Primary => "bg-primary",
            BsColor.Secondary => "bg-secondary",
            BsColor.Success => "bg-success",
            BsColor.Info => "bg-info",
            BsColor.Warning => "bg-warning",
            BsColor.Danger => "bg-danger",
            BsColor.Light => "bg-light",
            BsColor.Dark => "bg-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }

    internal static string ToTextBackgroundClass(this BsColor color)
    {
        return color switch
        {
            BsColor.Primary => "text-bg-primary",
            BsColor.Secondary => "text-bg-secondary",
            BsColor.Success => "text-bg-success",
            BsColor.Danger => "text-bg-danger",
            BsColor.Warning => "text-bg-warning",
            BsColor.Info => "text-bg-info",
            BsColor.Light => "text-bg-light",
            BsColor.Dark => "text-bg-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }

    internal static string ToAlertClass(this BsColor color)
    {
        return color switch
        {
            BsColor.Primary => "alert-primary",
            BsColor.Secondary => "alert-secondary",
            BsColor.Success => "alert-success",
            BsColor.Danger => "alert-danger",
            BsColor.Warning => "alert-warning",
            BsColor.Info => "alert-info",
            BsColor.Light => "alert-light",
            BsColor.Dark => "alert-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }

    internal static string ToUnderlineClass(this BsColor color)
    {
        return color switch
        {
            BsColor.Primary => "link-underline-primary",
            BsColor.Secondary => "link-underline-secondary",
            BsColor.Success => "link-underline-success",
            BsColor.Danger => "link-underline-danger",
            BsColor.Warning => "link-underline-warning",
            BsColor.Info => "link-underline-info",
            BsColor.Light => "link-underline-light",
            BsColor.Dark => "link-underline-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }

    internal static string ToFocusRingClass(this BsColor color)
    {
        return color switch
        {
            BsColor.Primary => "focus-ring-primary",
            BsColor.Secondary => "focus-ring-secondary",
            BsColor.Success => "focus-ring-success",
            BsColor.Danger => "focus-ring-danger",
            BsColor.Warning => "focus-ring-warning",
            BsColor.Info => "focus-ring-info",
            BsColor.Light => "focus-ring-light",
            BsColor.Dark => "focus-ring-dark",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null),
        };
    }
}
