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
            mYunmuRaw = "";
		}

		public const string TonedA = "aāáǎà";
		public const string TonedO = "oōóǒò";
		public const string TonedE = "eēéěè";
		public const string TonedI = "iīíǐì";
		public const string TonedU = "uūúǔù";
		public const string TonedV = "üǖǘǚǜ";

        public readonly string[] ToneRules = {"", "有a直接加a上","有o没a加o上", "有e直接加e上", "有ü加ü上", "i和u并列加后面那个上", "声调只加在元音a o e i u ü上" };
        public enum ToneRuleEnum
        {
            TONERULE_NONE,
            TONERULE_A,
            TONERULE_O,
            TONERULE_E,
            TONERULE_V,
            TONERULE_IU,
            TONERULE_VOWELS
        }
        
        public string GetString()
		{
            //         string ym = Yunmu;
            //         if(IsShengmuJQX())
            //         {
            //             if(Yunmu.IndexOf('ü') >= 0)
            //             {
            //                 ym = Yunmu.Replace('ü', 'u');
            //             }                
            //         }
            //return Shengmu + ym;
            return Shengmu + Yunmu;
		}

		//public string GetTonedString(ToneOfYinjie tone)
		//{
		//	string ym = "";
		//	int t = (int)tone;

		//	if (mYunmu.Contains("a"))
		//	{
		//		ym = mYunmu.Replace('a', TonedA[t]);
  //              mToneRule = ToneRuleEnum.TONERULE_A;
		//	}
		//	else if (mYunmu.Contains("o"))
		//	{
		//		ym = mYunmu.Replace('o', TonedO[t]);
  //              mToneRule = ToneRuleEnum.TONERULE_O;
		//	}
		//	else if (mYunmu.Contains("e"))
		//	{
		//		ym = mYunmu.Replace('e', TonedE[t]);
  //              mToneRule = ToneRuleEnum.TONERULE_E;
		//	}
		//	else if (mYunmu.Contains("ü"))
		//	{
  //              if (Shengmu.Equals("j") || Shengmu.Equals("q") || Shengmu.Equals("x"))
  //              {
  //                  ym = mYunmu.Replace('ü', TonedU[t]);
  //                  mToneRule = ToneRuleEnum.TONERULE_VOWELS;
  //                  Console.WriteLine("mShengmu: {0}, mYunmu: {1}, ym: {2}", mShengmu, mYunmu, ym);
  //              }
  //              else
  //              {
  //                  ym = mYunmu.Replace('ü', TonedV[t]);
  //                  mToneRule = ToneRuleEnum.TONERULE_VOWELS;
  //                  Console.WriteLine("mShengmu: {0}, mYunmu: {1}, ym: {2}", mShengmu, mYunmu, ym);
  //              }
		//	}
		//	else
		//	{
		//		int indexI = mYunmu.IndexOf('i');
		//		int indexU = mYunmu.IndexOf('u');

		//		if (indexI >= 0 && indexU < 0)
		//		{
		//			ym = mYunmu.Replace('i', TonedI[t]);
  //                  mToneRule = ToneRuleEnum.TONERULE_VOWELS;
		//		}
		//		else if (indexI < 0 && indexU >= 0)
		//		{
		//			ym = mYunmu.Replace('u', TonedU[t]);
  //                  mToneRule = ToneRuleEnum.TONERULE_VOWELS;
  //              }
		//		else if (indexI >= 0 && indexU >= 0)
		//		{
		//			if (indexI < indexU)
		//			{
		//				ym = mYunmu.Replace('u', TonedU[t]);
		//			}
		//			else
		//			{
		//				ym = mYunmu.Replace('i', TonedI[t]);
		//			}
  //                  mToneRule = ToneRuleEnum.TONERULE_IU;
		//		}
		//		else
		//		{
		//			// if it goes here, it should be an illegal pinyin, just return what it is
		//			ym = mYunmu;
		//		}
		//	}
		//	return mShengmu + ym;
		//}

		public FormattedString GetFormattedTonedString(ToneOfYinjie tone, Color shengmuColor, Color tonedYunmuColor, Color otherYunmuColor)
		{
			string ym = "";
			int t = (int)tone;

			int tonedYunmuIndex = -1;

			if (mYunmu.Contains("a"))
			{
				ym = mYunmu.Replace('a', TonedA[t]);
				tonedYunmuIndex = mYunmu.IndexOf('a');
                mToneRule = ToneRuleEnum.TONERULE_A;
            }
			else if (mYunmu.Contains("o"))
			{
				ym = mYunmu.Replace('o', TonedO[t]);
				tonedYunmuIndex = mYunmu.IndexOf('o');
                mToneRule = ToneRuleEnum.TONERULE_O;
            }
			else if (mYunmu.Contains("e"))
			{
				ym = mYunmu.Replace('e', TonedE[t]);
				tonedYunmuIndex = mYunmu.IndexOf('e');
                mToneRule = ToneRuleEnum.TONERULE_E;
            }
			else if (mYunmu.Contains("ü"))
			{
                //if (Shengmu.Equals("j") || Shengmu.Equals("q") || Shengmu.Equals("x"))
                //{
                //    ym = mYunmu.Replace('ü', TonedU[t]);
                //    mToneRule = ToneRuleEnum.TONERULE_VOWELS;
                //    //Console.WriteLine("mShengmu: {0}, mYunmu: {1}, ym: {2}", mShengmu, mYunmu, ym);
                //}
                //else
                //{
                //    ym = mYunmu.Replace('ü', TonedV[t]);
                //    mToneRule = ToneRuleEnum.TONERULE_VOWELS;
                //    //Console.WriteLine("mShengmu: {0}, mYunmu: {1}, ym: {2}", mShengmu, mYunmu, ym);
                //}
                ym = mYunmu.Replace('ü', TonedV[t]);
				tonedYunmuIndex = mYunmu.IndexOf('ü');
                mToneRule = ToneRuleEnum.TONERULE_VOWELS;
            }
			else
			{
				int indexI = mYunmu.IndexOf('i');
				int indexU = mYunmu.IndexOf('u');

				if (indexI >= 0 && indexU< 0)
				{
					ym = mYunmu.Replace('i', TonedI[t]);
					tonedYunmuIndex = indexI;
                    mToneRule = ToneRuleEnum.TONERULE_VOWELS;
                }
				else if (indexI< 0 && indexU >= 0)
				{
					ym = mYunmu.Replace('u', TonedU[t]);
					tonedYunmuIndex = indexU;
                    mToneRule = ToneRuleEnum.TONERULE_VOWELS;
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
                    mToneRule = ToneRuleEnum.TONERULE_IU;
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

        private bool IsShengmuJQX()
        {
            return Shengmu.Equals("j") || Shengmu.Equals("q") || Shengmu.Equals("x");
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

        private string mYunmuRaw;
		private string mYunmu;
		public string Yunmu
		{
			get 
			{
				return mYunmu; 
			}
			set 
			{ 
				mYunmuRaw = value; 
                if(IsShengmuJQX() && mYunmuRaw.IndexOf('ü')>=0)
                {
                    mYunmu = mYunmuRaw.Replace('ü', 'u');
                }
                else
                {
                    mYunmu = mYunmuRaw;
                }
			}
		}

        private ToneRuleEnum mToneRule;
        public ToneRuleEnum ToneRule
        {
            get
            {
                return mToneRule;
            }
            set
            {
                mToneRule = value;
            }
        }
	}
}
