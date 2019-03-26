using System;
using Xamarin.Forms;

namespace AwesomeTodoList.Components
{
    public class LineSpacingLabel : Label
    {
        public static BindableProperty LetterSpacingProperty = BindableProperty.Create(nameof(LetterSpacing), typeof(double), typeof(LineSpacingLabel), 1.0);
        public double LetterSpacing 
        {
            get
            {
                return (double)GetValue(LetterSpacingProperty);
            }
            set
            {
                SetValue(LetterSpacingProperty, value);
            }
        }
    }
}
