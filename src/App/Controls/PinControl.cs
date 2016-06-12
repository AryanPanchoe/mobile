﻿using System;
using Xamarin.Forms;

namespace Bit.App.Controls
{
    public class PinControl
    {
        public EventHandler OnPinEntered;

        public PinControl()
        {
            Label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                TextColor = Color.FromHex("333333"),
                FontFamily = "Courier"
            };

            Entry = new ExtendedEntry
            {
                Keyboard = Keyboard.Numeric,
                MaxLength = 4,
                Margin = new Thickness(0, int.MaxValue, 0, 0)
            };
            Entry.TextChanged += Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length >= 4)
            {
                OnPinEntered.Invoke(this, null);
            }
        }

        public Label Label { get; set; }
        public ExtendedEntry Entry { get; set; }
    }
}
