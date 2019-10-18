using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Pinyin.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main(args, null, "AppDelegate");

			// manually register the interface as Xamarin might not be able to find it 
			Xamarin.Forms.DependencyService.Register<iOSAudioManager>();
			Xamarin.Forms.DependencyService.Register<iOSPicture>();
		}
	}
}
