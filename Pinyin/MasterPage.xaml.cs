using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage()
		{
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();

			masterPageItems.Add(new MasterPageItem
			{
				Title = "首页",
				IconSource = "home158.png",
				TargetType = typeof(HomePage)
			});

			masterPageItems.Add( new MasterPageItem
			{
				Title = "声母表",
				IconSource = "tomato158_nochar.png",
				TargetType = typeof(ShengmuPage)
			}
			);

			masterPageItems.Add(new MasterPageItem
			{
				Title = "韵母表",
				IconSource = "orange158_nochar.png",
				TargetType = typeof(YunmuPage)
			});

			//masterPageItems.Add(new MasterPageItem
			//{
			//	Title = "音节拼读",
			//	IconSource = "PinDu.png",
			//	TargetType = typeof(PinyinPage)
			//});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "音节拼读",
				IconSource = "pear158_nochar.png",
				TargetType = typeof(PinduPage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "整体认读音节",
				IconSource = "apple158_nochar.png",
				TargetType = typeof(ZhengTiRenDuPage)
			});

            masterPageItems.Add(new MasterPageItem
			{
				Title = "常见问题",
				IconSource = "QA96.png",
				TargetType = typeof(FAQPage)
			});

			masterPageItems.Add(new MasterPageItem
			{
				Title = "声明和致谢",
				IconSource = "thanks96.png",
				TargetType = typeof(DeclarationPage)
			});

            //temporarily disable the share feature
            masterPageItems.Add(new MasterPageItem
            {
                Title = "关注公众号",
                IconSource = "qrcode_gongzhonghao_96.png",
                TargetType = typeof(SharePage)
            });

            listView.ItemsSource = masterPageItems;

		}
	}
}
