using System;
namespace Pinyin
{
	public class MasterPageItem
	{
		public MasterPageItem()
		{
		}

		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}
}
