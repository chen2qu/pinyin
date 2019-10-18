using System;
using System.Reflection;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Pinyin.iOS;
using UIKit;

[assembly: Dependency(typeof(iOSPicture))]
namespace Pinyin.iOS
{
	public class iOSPicture : IPicture
	{
		public iOSPicture()
		{
		}

		public async void SavePictureToDisk(ImageSource imgSrc, string fileName)
		{
			var renderer = new FileImageSourceHandler(); 
			var photo = await renderer.LoadImageAsync(imgSrc);
			var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			string jpgFileName = System.IO.Path.Combine(documentsDirectory, fileName);
			NSData imgData = photo.AsJPEG();
			NSError err = null;
			bool saved = imgData.Save(jpgFileName, false, out err);
#if DEBUG
			if (saved)
			{
				Console.WriteLine("!!!!iOS: QRCode file saved!!!");
				//return true;
			}
			else
			{
				Console.WriteLine("!!!iOS: NOT saved as " + jpgFileName + " because " + err.LocalizedDescription);
				//return false;
			}
#endif
		}
	}
}
