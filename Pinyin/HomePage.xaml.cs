using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			var shengmuGestureRecognizer = new TapGestureRecognizer();
			shengmuGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new ShengmuPage());
			};
			imgShengmu.GestureRecognizers.Add(shengmuGestureRecognizer);

			var yunmuGestureRecognizer = new TapGestureRecognizer();
			yunmuGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new YunmuPage());
			};
			imgYunmu.GestureRecognizers.Add(yunmuGestureRecognizer);

			var pinduGestureRecognizer = new TapGestureRecognizer();
			pinduGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new PinduPage());
			};
			imgPindu.GestureRecognizers.Add(pinduGestureRecognizer);

			var zhengtiGestureRecognizer = new TapGestureRecognizer();
			zhengtiGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new ZhengTiRenDuPage());
			};
			imgZhengti.GestureRecognizers.Add(zhengtiGestureRecognizer);

			var QAGestureRecognizer = new TapGestureRecognizer();
			QAGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new FAQPage());
			};
			imgQA.GestureRecognizers.Add(QAGestureRecognizer);

			var thanksGestureRecognizer = new TapGestureRecognizer();
			thanksGestureRecognizer.Tapped+=(s,e) =>
			{
				Navigation.PushAsync(new DeclarationPage());
			};
			imgThanks.GestureRecognizers.Add(thanksGestureRecognizer);

			// temporarily do not enable the share feature
			//var shareGestureRecognizer = new TapGestureRecognizer();
			//shareGestureRecognizer.Tapped += (s, e) =>
			// {
			//	 Navigation.PushAsync(new SharePage());
			// };
			//imgShare.GestureRecognizers.Add(shareGestureRecognizer);
		}

		void OnClickShengmu(object sender, EventArgs e)
		{ }

		void OnClickYunmu(object sender, EventArgs e)	
		{ }

		void OnClickPindu(object sender, EventArgs e)	
		{ }

		void OnClickZhengti(object sender, EventArgs e)	
		{ }
	}
}
