using System;
using Xamarin.Forms;

namespace Pinyin
{
	public class Yinjie
	{
		public Yinjie()
		{
			mShengmu = "";
			mYunmu = "";
		}

		public const string TonedA = "aāáǎà";
		public const string TonedO = "oōóǒò";
		public const string TonedE = "eēéěè";
		public const string TonedI = "iīíǐì";
		public const string TonedU = "uūúǔù";
		public const string TonedV = "üǖǘǚǜ";

		public string GetString()
		{
			return Shengmu + Yunmu;
		}

		public string GetTonedString(ToneOfYinjie tone)
		{
			string ym = "";
			int t = (int)tone;

			if (mYunmu.Contains("a"))
			{
				ym = mYunmu.Replace('a', TonedA[t]);
			}
			else if (mYunmu.Contains("o"))
			{
				ym = mYunmu.Replace('o', TonedO[t]);
			}
			else if (mYunmu.Contains("e"))
			{
				ym = mYunmu.Replace('e', TonedE[t]);
			}
			else if (mYunmu.Contains("ü"))
			{
				ym = mYunmu.Replace('ü', TonedV[t]);
			}
			else
			{
				int indexI = mYunmu.IndexOf('i');
				int indexU = mYunmu.IndexOf('u');

				if (indexI >= 0 && indexU < 0)
				{
					ym = mYunmu.Replace('i', TonedI[t]);
				}
				else if (indexI < 0 && indexU >= 0)
				{
					ym = mYunmu.Replace('u', TonedU[t]);
				}
				else if (indexI >= 0 && indexU >= 0)
				{
					if (indexI < indexU)
					{
						ym = mYunmu.Replace('u', TonedU[t]);
					}
					else
					{
						ym = mYunmu.Replace('i', TonedI[t]);
					}
				}
				else
				{
					// if it goes here, it should be an illegal pinyin, just return what it is
					ym = mYunmu;
				}
			}
			return mShengmu + ym;
		}

		public FormattedString GetFormattedTonedString(ToneOfYinjie tone, Color shengmuColor, Color tonedYunmuColor, Color otherYunmuColor)
		{
			string ym = "";
			int t = (int)tone;

			int tonedYunmuIndex = -1;

			if (mYunmu.Contains("a"))
			{
				ym = mYunmu.Replace('a', TonedA[t]);
				tonedYunmuIndex = mYunmu.IndexOf('a');
			}
			else if (mYunmu.Contains("o"))
			{
				ym = mYunmu.Replace('o', TonedO[t]);
				tonedYunmuIndex = mYunmu.IndexOf('o');
			}
			else if (mYunmu.Contains("e"))
			{
				ym = mYunmu.Replace('e', TonedE[t]);
				tonedYunmuIndex = mYunmu.IndexOf('e');
			}
			else if (mYunmu.Contains("ü"))
			{
				ym = mYunmu.Replace('ü', TonedV[t]);
				tonedYunmuIndex = mYunmu.IndexOf('ü');
			}
			else
			{
				int indexI = mYunmu.IndexOf('i');
				int indexU = mYunmu.IndexOf('u');

				if (indexI >= 0 && indexU< 0)
				{
					ym = mYunmu.Replace('i', TonedI[t]);
					tonedYunmuIndex = indexI;
				}
				else if (indexI< 0 && indexU >= 0)
				{
					ym = mYunmu.Replace('u', TonedU[t]);
					tonedYunmuIndex = indexU;
				}
				else if (indexI >= 0 && indexU >= 0)
				{
					if (indexI<indexU)
					{
						ym = mYunmu.Replace('u', TonedU[t]);
						tonedYunmuIndex = indexU;
					}
					else
					{
						ym = mYunmu.Replace('i', TonedI[t]);
						tonedYunmuIndex = indexI;
					}
				}
				else
				{
					// if it goes here, it should be an illegal pinyin, just return what it is
					ym = mYunmu;
				}
			}

			FormattedString fs = new FormattedString();
			if (mShengmu.Length > 0)
			{
				fs.Spans.Add(new Span { Text = mShengmu, ForegroundColor = shengmuColor });
			}
			if (tonedYunmuIndex >= 0)
			{
				string ymspan1 = ym.Substring(0, tonedYunmuIndex);
				if (ymspan1.Length > 0)
				{ 
					fs.Spans.Add(new Span { Text = ymspan1, ForegroundColor = otherYunmuColor});
				}

				string ymspan2 = ym.Substring(tonedYunmuIndex, 1);
				fs.Spans.Add(new Span { Text = ymspan2, ForegroundColor = tonedYunmuColor});

				if (tonedYunmuIndex < ym.Length - 1)
				{
					fs.Spans.Add(new Span { Text = ym.Substring(tonedYunmuIndex+1), ForegroundColor = otherYunmuColor});
				}

			}

			return fs;
		}

		private string mShengmu;
		public string Shengmu
		{
			get
			{
				return mShengmu;
			}
			set
			{
				mShengmu = value;
			}
		}

		private string mYunmu;
		public string Yunmu
		{
			get 
			{
				return mYunmu; 
			}
			set 
			{ 
				mYunmu = value; 
			}
		}
	}
}
