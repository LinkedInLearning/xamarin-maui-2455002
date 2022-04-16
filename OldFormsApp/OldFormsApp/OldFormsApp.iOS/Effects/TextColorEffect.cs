using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("OldFormsAppEffect")]
[assembly: ExportEffect(typeof(OldFormsApp.iOS.TextColorEffect), nameof(OldFormsApp.iOS.TextColorEffect))]
namespace OldFormsApp.iOS
{
    public class TextColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var label = Control as UILabel;

            if (label != null)
            {
                label.TextColor = Color.DarkBlue.ToUIColor();
            }
        }

        protected override void OnDetached()
        {
        }
    }
}