using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace NewMauiApp.Platforms.Android.Effects
{
    public class TextColorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textView = Control as android.Widget.TextView;

            if (textView != null)
            {
                textView.SetTextColor(Colors.Green.ToAndroid());
            }
        }

        protected override void OnDetached()
        {

        }
    }
}
