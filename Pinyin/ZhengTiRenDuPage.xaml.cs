using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class ZhengTiRenDuPage : ContentPage
	{
		public ZhengTiRenDuPage()
		{
			InitializeComponent();

			mYinjie = new Yinjie();

			UpdateToneButtonsStatus(false, false, false, false);
		}

		void UpdateExplanation(ToneOfYinjie tone)
		{
			YinjieXmlFile pinyinData = PinyinDataManager.Instance.GetAllYinjies();
			int yinjieIndex = pinyinData.FindYinjie(mYinjie.GetString());

			FormattedString fs = new FormattedString();

			if (yinjieIndex >= 0)
			{
				string samples = "";

				if (tone == ToneOfYinjie.TONE_1)
				{
					samples = pinyinData.AllYinjies[yinjieIndex].Tone1Samples;
				}
				else if (tone == ToneOfYinjie.TONE_2)
				{
					samples = pinyinData.AllYinjies[yinjieIndex].Tone2Samples;
				}
				else if (tone == ToneOfYinjie.TONE_3)
				{
					samples = pinyinData.AllYinjies[yinjieIndex].Tone3Samples;
				}
				else if (tone == ToneOfYinjie.TONE_4)
				{
					samples = pinyinData.AllYinjies[yinjieIndex].Tone4Samples;
				}
				else
				{
					samples = "";
				}

				fs.Spans.Add(new Span { Text = pinyinData.AllYinjies[yinjieIndex].Desc + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
                if (mYinjie.ToneRule != Yinjie.ToneRuleEnum.TONERULE_NONE)
                {
                    fs.Spans.Add(new Span { Text = string.Format("声调规则: {0}\n", mYinjie.ToneRules[(int)mYinjie.ToneRule]), ForegroundColor = Color.LimeGreen });
                }
                fs.Spans.Add(new Span { Text = samples });

			}

			lblExplanation.FormattedText = fs;
		}

		void PlayYinjie(ToneOfYinjie tone)
		{
			string soundFile = "";

			if (mYinjie.Yunmu.Length > 0)
			{
				int toneInt = (int)tone;

				// Xamarin doesn't support adding assets with ü in name, 
				// so have to replace it with v
				string yinjieWithV = mYinjie.Yunmu.Replace("ü", "v");
				soundFile = string.Format("{0}{1}.MP3", yinjieWithV, toneInt);
			}

			AudioManager.Instance.PlaySound(soundFile);
		}

		void UpdateYinjie(ToneOfYinjie tone)
		{
			lblYinjie.FormattedText = mYinjie.GetFormattedTonedString(tone, Color.FromHex("#E8AD00"), Color.LimeGreen, Color.FromHex("#E8AD00"));
		}

		void UpdateToneButtonsStatus(bool tone1BtnEnabled, bool tone2BtnEnabled, bool tone3BtnEnabled, bool tone4BtnEnabled)
		{
			btnTone1.IsEnabled = tone1BtnEnabled;
			btnTone2.IsEnabled = tone2BtnEnabled;
			btnTone3.IsEnabled = tone3BtnEnabled;
			btnTone4.IsEnabled = tone4BtnEnabled;
		}

		void OnClickYinjie(object sender, EventArgs e)
		{ 
			Button btn = (Button)sender;
			mYinjie.Shengmu = "";
			mYinjie.Yunmu = btn.Text;
            mYinjie.ToneRule = Yinjie.ToneRuleEnum.TONERULE_NONE;

			lblYinjie.Text = mYinjie.GetString();

			UpdateExplanation(ToneOfYinjie.TONE_NONE);

			if (mLastBtnTapped != null)
			{
				mLastBtnTapped.BackgroundColor = Color.FromHex("#FAF0E6");
			}

			mLastBtnTapped = btn;
			mLastBtnTapped.BackgroundColor = Color.LimeGreen;

			UpdateToneButtonsStatus(true, true, true, true);
		}

		void OnTone1Clicked(object sender, EventArgs e)
		{
            UpdateYinjie(ToneOfYinjie.TONE_1);
            PlayYinjie(ToneOfYinjie.TONE_1);
			UpdateExplanation(ToneOfYinjie.TONE_1);
		}

		void OnTone2Clicked(object sender, EventArgs e)
		{
            UpdateYinjie(ToneOfYinjie.TONE_2);
            PlayYinjie(ToneOfYinjie.TONE_2);
			UpdateExplanation(ToneOfYinjie.TONE_2);
		}

		void OnTone3Clicked(object sender, EventArgs e)
		{
            UpdateYinjie(ToneOfYinjie.TONE_3);
            PlayYinjie(ToneOfYinjie.TONE_3);
			UpdateExplanation(ToneOfYinjie.TONE_3);
		}

		void OnTone4Clicked(object sender, EventArgs e)
		{
            UpdateYinjie(ToneOfYinjie.TONE_4);
            PlayYinjie(ToneOfYinjie.TONE_4);
			UpdateExplanation(ToneOfYinjie.TONE_4);
		}

		private Yinjie mYinjie;
		public Button mLastBtnTapped = null;
		private const string DefaultTip1 = "";
	}
}
