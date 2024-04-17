using Avalonia;
using Avalonia.Controls;

namespace AutoCompleteBoxPlay.Styles.Assists
{
    public static class AutoCompleteBoxAssist
    {
        public static readonly AvaloniaProperty<string?> LabelProperty =
            AvaloniaProperty.RegisterAttached<AutoCompleteBox, string?>(
                "Label", typeof(AutoCompleteBox));

        public static void SetLabel(AvaloniaObject element, string value) =>
            element.SetValue(LabelProperty, value);

        public static string? GetLabel(AvaloniaObject element) =>
            element.GetValue<string?>(LabelProperty);
    }
}
