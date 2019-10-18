using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Pinyin.Droid;
using Android.Content;


[assembly: Dependency(typeof(DroidPicture))]
namespace Pinyin.Droid
{
	public class DroidPicture : IPicture
	{
		public DroidPicture()
		{
		}

		async void IPicture.SavePictureToDisk(ImageSource imgSrc, string fileName)
		{
			var renderer = new FileImageSourceHandler(); 
			var photo = await renderer.LoadImageAsync(imgSrc, Android.App.Application.Context);

			if (photo == null)
			{
#if DEBUG
				Console.WriteLine("!!!LoadImage failed!!!");
#endif
				return;
			}

			var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
			var Dcim = dir.AbsolutePath;

			string cameraFolder = System.IO.Path.Combine(Dcim, "Camera");
			string jpgFileName = System.IO.Path.Combine(cameraFolder, fileName);
#if DEBUG
			Console.WriteLine("!!!file path to save: " + jpgFileName);
#endif

			try
			{
				var stream = new FileStream(jpgFileName, FileMode.Create);
				photo.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
				stream.Close();
#if DEBUG
				Console.WriteLine("!!!!File saved!!!!");
#endif

				//mediascan adds the saved image into the gallery
				// this code will return error: [SendBroadcastPermission] action:android.intent.action.MEDIA_SCANNER_SCAN_FILE, mPermissionType:0
				var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
				mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(jpgFileName)));
				Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
			}
			catch (SystemException e)
			{
#if DEBUG
				System.Console.WriteLine(e.Message);
#endif
			}
		}
	}
}
