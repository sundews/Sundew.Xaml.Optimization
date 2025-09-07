// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamlDiagnostic.cs" company="Sundews">
// Copyright (c) Sundews. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sundew.Xaml.Optimization;

using System.Text;

/// <summary>
/// Represents a diagnostic message related to XAML processing.
/// </summary>
/// <param name="Code">The code.</param>
/// <param name="Message">The message.</param>
/// <param name="MessageArguments">The message arguments.</param>
/// <param name="DiagnosticSeverity">The diagnostic severity.</param>
/// <param name="FilePath">The file path.</param>
/// <param name="LineNumber">The line number.</param>
/// <param name="ColumnNumber">The column number.</param>
/// <param name="EndLineNumber">The end line number.</param>
/// <param name="EndColumnNumber">The end column number.</param>
public record XamlDiagnostic(
    string Code,
    string Message,
    object[] MessageArguments,
    DiagnosticSeverity DiagnosticSeverity,
    string FilePath,
    int LineNumber,
    int ColumnNumber,
    int EndLineNumber,
    int EndColumnNumber)
{
    private const string Err = "error";
    private const string Wrn = "warning";
    private const string Inf = "info";
    private const string Unk = "unknown";

    /// <summary>
    /// Create an info diagnostics.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="message">The message.</param>
    /// <param name="messageArguments">The message arguments.</param>
    /// <param name="filePath">The file path.</param>
    /// <param name="lineNumber">The line number.</param>
    /// <param name="columnNumber">The column number.</param>
    /// <param name="endLineNumber">The end line number.</param>
    /// <param name="endColumnNumber">The end column number.</param>
    /// <returns>The xaml diagnostics.</returns>
    public static XamlDiagnostic Info(
        string code,
        string message,
        object[] messageArguments,
        string filePath,
        int lineNumber,
        int columnNumber,
        int endLineNumber,
        int endColumnNumber)
    {
        return new XamlDiagnostic(code, message, messageArguments, DiagnosticSeverity.Info, filePath, lineNumber, columnNumber, endLineNumber, endColumnNumber);
    }

    /// <summary>
    /// Creates a warning diagnostics.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="message">The message.</param>
    /// <param name="messageArguments">The message arguments.</param>
    /// <param name="filePath">The file path.</param>
    /// <param name="lineNumber">The line number.</param>
    /// <param name="columnNumber">The column number.</param>
    /// <param name="endLineNumber">The end line number.</param>
    /// <param name="endColumnNumber">The end column number.</param>
    /// <returns>The xaml diagnostics.</returns>
    public static XamlDiagnostic Warning(
        string code,
        string message,
        object[] messageArguments,
        string filePath,
        int lineNumber,
        int columnNumber,
        int endLineNumber,
        int endColumnNumber)
    {
        return new XamlDiagnostic(code, message, messageArguments, DiagnosticSeverity.Warning, filePath, lineNumber, columnNumber, endLineNumber, endColumnNumber);
    }

    /// <summary>
    /// Creates an error diagnostics.
    /// </summary>
    /// <param name="code">The code.</param>
    /// <param name="message">The message.</param>
    /// <param name="messageArguments">The message arguments.</param>
    /// <param name="filePath">The file path.</param>
    /// <param name="lineNumber">The line number.</param>
    /// <param name="columnNumber">The column number.</param>
    /// <param name="endLineNumber">The end line number.</param>
    /// <param name="endColumnNumber">The end column number.</param>
    /// <returns>The xaml diagnostics.</returns>
    public static XamlDiagnostic Error(
        string code,
        string message,
        object[] messageArguments,
        string filePath,
        int lineNumber,
        int columnNumber,
        int endLineNumber,
        int endColumnNumber)
    {
        return new XamlDiagnostic(code, message, messageArguments, DiagnosticSeverity.Error, filePath, lineNumber, columnNumber, endLineNumber, endColumnNumber);
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <returns>The message.</returns>
    public string ToMessage()
    {
        var stringBuilder = new StringBuilder();
        const string @in = " in ";
        stringBuilder.Append(this.DiagnosticSeverity switch
        {
            DiagnosticSeverity.Error => Err,
            DiagnosticSeverity.Warning => Wrn,
            DiagnosticSeverity.Info => Inf,
            _ => Unk,
        })
            .Append(' ')
            .Append(this.Code)
            .Append(':')
            .Append(' ')
            .Append(string.Format(this.Message, this.MessageArguments))
            .Append(@in)
            .Append(this.FilePath)
            .Append('(')
            .Append(this.LineNumber)
            .Append(',')
            .Append(this.ColumnNumber)
            .Append(',')
            .Append(this.EndLineNumber)
            .Append(',')
            .Append(this.EndColumnNumber)
            .Append(')');
        return stringBuilder.ToString();
    }
}