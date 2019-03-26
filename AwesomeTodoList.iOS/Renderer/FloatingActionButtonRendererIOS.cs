using System;
using CoreGraphics;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AwesomeTodoList.Components;
using UIKit;
using System.ComponentModel;
using AwesomeTodoList.iOS.Renderer;

[assembly: ExportRenderer(typeof(CrossPlatformFloatingActionButton), typeof(FloatingActionButtonRendererIOS))]
namespace AwesomeTodoList.iOS.Renderer
{
    [Preserve]
    public class FloatingActionButtonRendererIOS : ButtonRenderer
    {
        public static void InitRenderer()
        {
        }

        public FloatingActionButtonRendererIOS()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            // remove text from button and set the width/height/radius
            Element.WidthRequest = 50;
            Element.HeightRequest = 50;
            Element.CornerRadius = 25;
            Element.BorderWidth = 0;
            Element.Text = null;

            // set background
            Control.BackgroundColor = ((CrossPlatformFloatingActionButton)Element).ButtonColor.ToUIColor();
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            // add shadow
            Layer.ShadowRadius = 2.0f;
            Layer.ShadowColor = UIColor.Black.CGColor;
            Layer.ShadowOffset = new CGSize(1, 1);
            Layer.ShadowOpacity = 0.80f;
            Layer.ShadowPath = UIBezierPath.FromOval(Layer.Bounds).CGPath;
            Layer.MasksToBounds = false;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "ButtonColor")
            {
                Control.BackgroundColor = ((CrossPlatformFloatingActionButton)Element).ButtonColor.ToUIColor();
            }
        }
    }
}

