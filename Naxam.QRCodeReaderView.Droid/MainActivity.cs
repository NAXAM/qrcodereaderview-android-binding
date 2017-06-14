using Android.App;
using Android.Widget;
using Android.OS;

namespace Naxam.QRCodeReaderView.Droid
{
    [Activity(Label = "Naxam.QRCodeReaderView.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

