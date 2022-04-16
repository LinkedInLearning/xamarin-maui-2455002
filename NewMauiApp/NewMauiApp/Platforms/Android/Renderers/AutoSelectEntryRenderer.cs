using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace NewMauiApp.Platforms.Android.Renderers
{
    public class AutoSelectEntryRenderer : EntryRenderer
    {
        public AutoSelectEntryRenderer(android.Content.Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetSelectAllOnFocus(true);
        }
    }
}
