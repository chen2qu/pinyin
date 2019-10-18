using System;
namespace Pinyin
{
	public class PinyinDataManager
	{
		static readonly PinyinDataManager instance = new PinyinDataManager();
		static PinyinDataManager()
		{
		}

		PinyinDataManager()
		{
			mYinjieExplanations = new YinjieXmlFile();
			mYinjieExplanations.Load();
		}

		public static PinyinDataManager Instance
		{
			get 
			{
				return instance;
			}
		}

		public YinjieXmlFile GetAllYinjies()
		{
			return mYinjieExplanations;
		}

		private YinjieXmlFile mYinjieExplanations;
	}
}
