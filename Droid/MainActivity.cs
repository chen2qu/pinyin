using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Pinyin.Droid
{
	[Activity(Label = "陪你读拼音", Icon = "@drawable/icon512", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			//base.Window.RequestFeature(WindowFeatures.ActionBar);
			// Name of the MainActivity theme you had there before.
			// Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MyTheme);

			base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			// manually register the interface as Xamarin might not be able to find it 
			Xamarin.Forms.DependencyService.Register<DroidAudioManager>();
			Xamarin.Forms.DependencyService.Register<DroidPicture>();

			LoadApplication(new App());
		}
	}
}
