using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("OldFormsAppEffect")]
[assembly: ExportEffect(typeof(OldFormsApp.Droid.TextColorEffect), nameof(OldFormsApp.Droid.TextColorEffect))]
namespace OldFormsApp.Droid
{
    public class TextColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textView = Control as Android.Widget.TextView;

            if (textView != null)
            {
                textView.SetTextColor(Color.DarkBlue.ToAndroid());
            }
        }

        protected override void OnDetached()
        {
 
        }
    }
}