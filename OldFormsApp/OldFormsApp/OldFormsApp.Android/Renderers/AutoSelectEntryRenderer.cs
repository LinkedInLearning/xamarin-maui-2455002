using OldFormsApp.Controls;
using OldFormsApp.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AutoSelectEntry), typeof(AutoSelectEntryRenderer))]
namespace OldFormsApp.Droid.Renderers
{
    public class AutoSelectEntryRenderer : EntryRenderer
    {
        public AutoSelectEntryRenderer(Android.Content.Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetSelectAllOnFocus(true);
        }
    }
}