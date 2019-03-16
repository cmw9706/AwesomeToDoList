using System;
using AwesomeTodoList.Components;
using AwesomeTodoList.iOS.Renderer;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LineSpacingLabel), typeof(LineSpacingLabelRendererIOS))]
namespace AwesomeTodoList.iOS.Renderer
{
    public class LineSpacingLabelRendererIOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (!(Element is LineSpacingLabel data) || Control == null)
            {
                return;
            }

            var text = Control.Text;
            var attributedString = new NSMutableAttributedString(text);

            var nsKern = new NSString("NSKern");
            var spacing = NSObject.FromObject(data.LetterSpacing * 10);
            var range = new NSRange(0, text.Length);

            attributedString.AddAttribute(nsKern, spacing, range);
            Control.AttributedText = attributedString;
        }
    }
}
