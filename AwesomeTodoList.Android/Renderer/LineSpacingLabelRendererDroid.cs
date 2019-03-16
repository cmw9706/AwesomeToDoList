using System;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Xamarin.Forms;
using AwesomeTodoList.Components;
using AwesomeTodoList.Droid.Renderer;

[assembly:ExportRenderer(typeof(LineSpacingLabel), typeof(LineSpacingLabelRendererDroid))]
namespace AwesomeTodoList.Droid.Renderer
{
    public class LineSpacingLabelRendererDroid : LabelRenderer
    {
        public LineSpacingLabelRendererDroid(Context context) : base(context)
        {
        }

        protected LineSpacingLabel LetterSpacingLabel { get; private set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                this.LetterSpacingLabel = (LineSpacingLabel)this.Element;
            }

            var letterSpacing = this.LetterSpacingLabel.LetterSpacing;
            this.Control.LetterSpacing = letterSpacing;

            this.UpdateLayout();
        }
    }
}
