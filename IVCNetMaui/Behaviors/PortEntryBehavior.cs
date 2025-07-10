using System.Text.RegularExpressions;

namespace IVCNetMaui.Behaviors
{
    internal class PortEntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // Allow only digits
            if (!Regex.IsMatch(e.NewTextValue, @"^\d*$"))
            {
                entry.Text = e.OldTextValue;
                return;
            }

            // Check range 1–65535
            if (int.TryParse(e.NewTextValue, out int port))
            {
                if (port < 1 || port > 65535)
                {
                    entry.Text = e.OldTextValue;
                }
            }
        }
    }
}
