using System;

using Xamarin.Forms;

namespace AwesomeTodoList.Components
{
    public class CrossPlatformFloatingActionButton : Button
    {
        public static BindableProperty ButtonColorProperty = BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(CrossPlatformFloatingActionButton), Color.Accent);
        public Color ButtonColor
        {
            get
            {
                return (Color)GetValue(ButtonColorProperty);
            }
            set
            {
                SetValue(ButtonColorProperty, value);
            }
        }
        public CrossPlatformFloatingActionButton()
        {
        }
    }
}

