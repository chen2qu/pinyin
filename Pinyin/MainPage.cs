using System;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class MainPage : MasterDetailPage
	{
		MasterPage masterPage;

		public MainPage()
		{
			this.masterPage = new MasterPage();
			Master = this.masterPage;

			//Detail = new NavigationPage(new PinduPage()) { BarTextColor = Color.White, BarBackgroundColor=Color.FromHex("#1D8BF1") };
			Detail = new NavigationPage(new HomePage()) { BarTextColor = Color.White, BarBackgroundColor=Color.FromHex("#1D8BF1") };

			this.masterPage.ListView.ItemSelected += OnItemSelected;

			//this.MasterBehavior = MasterBehavior.Split;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)) { BarTextColor = Color.White, BarBackgroundColor = Color.FromHex("#1D8BF1")  };
				//not working --> Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType)); //{ BarTextColor = Color.White, BarBackgroundColor = Color.FromHex("#1D8BF1")  };

				//not working too -->
				//if (item.TargetType == typeof(ShengmuPage))
				//{
				//	Navigation.PushAsync(new ShengmuPage());
				//}
				//else if (item.TargetType == typeof(YunmuPage))
				//{
				//	Navigation.PushAsync(new YunmuPage());
				//}
				//else if (item.TargetType == typeof(PinduPage))
				//{
				//	Navigation.PushAsync(new PinduPage());
				//}
				//else if (item.TargetType == typeof(ZhengTiRenDuPage))
				//{
				//	Navigation.PushAsync(new ZhengTiRenDuPage());
				//}

				this.masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}

