using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components.Forms;
using Wader.Bootstrap.Forms;
using Wader.Bootstrap.Forms.Validation;

namespace Wader.Bootstrap.Tests.Forms.Validation;

public class BsValidationMessageTests : BunitContext
{
    private const string ERROR_MESSAGE = "Error message";
    private readonly TestModel _model;
    private readonly EditContext _editContext;
    private IRenderedComponent<BsEditForm>? _editContextComponent;

    [StringSyntax("Html")]
    private const string HTML_FORMAT = $$"""<div class="invalid-feedback {0}" {1}>{{ERROR_MESSAGE}}</div>""";

    private static CompositeFormat HtmlFormatCache => CompositeFormat.Parse(HTML_FORMAT);

    public BsValidationMessageTests()
    {
        _model = new TestModel();
        _editContext = new EditContext(_model);
    }

    [Fact]
    public async Task DefaultWorksAsync()
    {
        // Arrange
        var cut = GetCut();

        // Act
        await SimulateValidatingModel();

        // Assert
        cut.MarkupMatches(GetExpectedHtml());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("aclass")]
    [InlineData("aclass bclass")]
    [InlineData("aclass blass class")]
    public async Task PassingClassesWorksAsync(string? classes)
    {
        // Arrange
        var cut = GetCut(parameters => parameters.Add(x => x.Classes, classes));

        // Act
        await SimulateValidatingModel();

        // Assert
        cut.MarkupMatches(GetExpectedHtml(classes));
    }

    [Theory]
    [InlineData(
        new[] { "attributeKey" },
        new[] { "attributeValue" },
        """
            attributeKey="attributeValue"
            """
    )]
    [InlineData(
        new[] { "attributeKey1", "attributeKey2" },
        new[] { "attributeValue1", "attributeValue2" },
        """
            attributeKey1="attributeValue1" attributeKey2="attributeValue2"
            """
    )]
    public async Task ExtraAttributesWorksAsync(string[] attributeKeys, string[] attributeValues, string expected)
    {
        // Arrange
        var cut = GetCut(parameters =>
        {
            for (var i = 0; i < attributeKeys.Length; i++)
            {
                _ = parameters.AddUnmatched(attributeKeys[i], attributeValues[i]);
            }
        });

        // Act
        await SimulateValidatingModel();

        // Assert
        cut.MarkupMatches(GetExpectedHtml(attributes: expected));
    }

    protected virtual IRenderedComponent<BsValidationMessage<string?>> GetCut(
        Action<ComponentParameterCollectionBuilder<BsValidationMessage<string?>>>? action = null
    )
    {
        _editContextComponent = Render<BsEditForm>(parameters =>
        {
            _ = parameters
                .Add(p => p.EditContext, _editContext)
                .Add<BsValidationMessage<string?>, EditContext>(
                    p => p.ChildContent,
                    _ =>
                        pms =>
                        {
                            BindParameters(pms);
                            action?.Invoke(pms);
                        }
                );
        });
        return _editContextComponent.FindComponent<BsValidationMessage<string?>>();
    }

    protected virtual void BindParameters(
        ComponentParameterCollectionBuilder<BsValidationMessage<string?>> parameterBuilder
    )
    {
        _ = parameterBuilder.Add(p => p.For, () => _model.Property);
    }

    protected virtual string GetExpectedHtml(string? classes = null, string? attributes = null)
    {
        return string.Format(CultureInfo.InvariantCulture, HtmlFormatCache, classes, attributes);
    }

    private async Task SimulateValidatingModel()
    {
        // We need to make sure an error happened so we make the validation message actually appear
        var store = new ValidationMessageStore(_editContext);
        var field = FieldIdentifier.Create(() => _model.Property);
        store.Clear(field);
        store.Add(field, ERROR_MESSAGE);

        ArgumentNullException.ThrowIfNull(_editContextComponent);
        await _editContextComponent.InvokeAsync(_editContext.NotifyValidationStateChanged);
    }

    protected override async ValueTask DisposeAsyncCore()
    {
        await base.DisposeAsyncCore();
        _editContextComponent?.Dispose();
    }

    private sealed class TestModel
    {
        public string? Property { get; set; }
    }
}
