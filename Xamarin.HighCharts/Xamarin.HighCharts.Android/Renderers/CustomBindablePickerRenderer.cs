

using Android.Content.Res;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.HighCharts.Droid.Renderers;
using Xamarin.HighCharts.Views;

[assembly: ExportRenderer(typeof(BindablePicker), typeof(CustomBindablePickerRenderer))]
namespace Xamarin.HighCharts.Droid.Renderers
{
    public class CustomBindablePickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            this.Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, Resources.GetDrawable(Resource.Drawable.ic_item_list), null);
        }
    }
}