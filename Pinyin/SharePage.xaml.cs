using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class SharePage : ContentPage
	{
		public SharePage()
		{
			InitializeComponent();

			var shareGestureRecognizer = new TapGestureRecognizer();
			shareGestureRecognizer.Tapped += (s, e) =>
			 {
				ImageSource imgSrc = ImageSource.FromResource("qrcode_dupinyin512.jpg");
				IPicture picInterface = DependencyService.Get<IPicture>();
				if (picInterface != null)
				{
					picInterface.SavePictureToDisk(imgQRCode.Source, "QRCodeDuPinyin.jpg");
					//DependencyService.Get<IPicture> ().SavePictureToDisk(imgSrc, "qrcode_dupinyin.png");

					DisplayAlert("保存", "二维码已保存到相册，可以去转发给好友了：）", "确定");
				}
				else
				{
					Console.WriteLine("!!!!!Failed to get picture interface!!!");
				}
			 };
			imgQRCode.GestureRecognizers.Add(shareGestureRecognizer);
		}
	}
}
