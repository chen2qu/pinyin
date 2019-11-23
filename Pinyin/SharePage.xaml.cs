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

            //// current strategy is not to request any permission from end users, even permission to write storage card
			//var shareGestureRecognizer = new TapGestureRecognizer();
			//shareGestureRecognizer.Tapped += (s, e) =>
			// {
			//	ImageSource imgSrc = ImageSource.FromResource("qrcode_gongzhonghao.jpg");
			//	IPicture picInterface = DependencyService.Get<IPicture>();
			//	if (picInterface != null)
			//	{
			//		picInterface.SavePictureToDisk(imgQRCode.Source, "花儿和铃铛_qrcode_gongzhonghao.jpg");
			//		//DependencyService.Get<IPicture> ().SavePictureToDisk(imgSrc, "qrcode_dupinyin.png");

			//		DisplayAlert("保存", "二维码已保存到相册，可以去扫码关注了，谢谢：）", "确定");
			//	}
			//	else
			//	{
			//		Console.WriteLine("!!!!!Failed to get picture interface!!!");
			//	}
			// };
			//imgQRCode.GestureRecognizers.Add(shareGestureRecognizer);
		}
	}
}
