using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class YunmuPage : ContentPage
	{
		public YunmuPage()
		{
			InitializeComponent();

			mYinjie = new Yinjie();
			//InitializeYunmu();

			// set the tone buttons' initials status to false as no yinjie can be played
			UpdateToneButtonsStatus(false, false, false, false);
		}


		//void InitializeYunmu()
		//{
		//	mAllYunmus = new List<Yunmu>(24);

		//	Yunmu ymA = new Yunmu("a", btnYunmuA, false);
		//	mAllYunmus.Add(ymA);

		//	Yunmu ymO = new Yunmu("o", btnYunmuO, false);
		//	mAllYunmus.Add(ymO);

		//	Yunmu ymE = new Yunmu("e", btnYunmuE, false);
		//	mAllYunmus.Add(ymE);

		//	Yunmu ymI = new Yunmu("i", btnYunmuI, true);
		//	mAllYunmus.Add(ymI);

		//	Yunmu ymU = new Yunmu("u", btnYunmuU, true);
		//	mAllYunmus.Add(ymU);

		//	Yunmu ymV = new Yunmu("ü", btnYunmuV, true);
		//	mAllYunmus.Add(ymV);

		//	Yunmu ymAI = new Yunmu("ai", btnYunmuAI, false);
		//	mAllYunmus.Add(ymAI);

		//	Yunmu ymEI = new Yunmu("ei", btnYunmuEI, false);
		//	mAllYunmus.Add(ymEI);

		//	Yunmu ymUI = new Yunmu("ui", btnYunmuUI, true);
		//	mAllYunmus.Add(ymUI);

		//	Yunmu ymAO = new Yunmu("ao", btnYunmuAO, false);
		//	mAllYunmus.Add(ymAO);

		//	Yunmu ymOU = new Yunmu("ou", btnYunmuOU, false);
		//	mAllYunmus.Add(ymOU);

		//	Yunmu ymIU = new Yunmu("iu", btnYunmuIU, true);
		//	mAllYunmus.Add(ymIU);

		//	Yunmu ymIE = new Yunmu("ie", btnYunmuIE, true);
		//	mAllYunmus.Add(ymIE);

		//	Yunmu ymVE = new Yunmu("üe", btnYunmuVE, true);
		//	mAllYunmus.Add(ymVE);

		//	Yunmu ymER = new Yunmu("er", btnYunmuER, false);
		//	mAllYunmus.Add(ymER);

		//	Yunmu ymAN = new Yunmu("an", btnYunmuAN, false);
		//	mAllYunmus.Add(ymAN);

		//	Yunmu ymEN = new Yunmu("en", btnYunmuEN, false);
		//	mAllYunmus.Add(ymEN);

		//	Yunmu ymIN = new Yunmu("in", btnYunmuIN, true);
		//	mAllYunmus.Add(ymIN);

		//	Yunmu ymUN = new Yunmu("un", btnYunmuUN, true);
		//	mAllYunmus.Add(ymUN);

		//	Yunmu ymVN = new Yunmu("ün", btnYunmuVN, true);
		//	mAllYunmus.Add(ymVN);

		//	Yunmu ymANG = new Yunmu("ang", btnYunmuANG, false);
		//	mAllYunmus.Add(ymANG);

		//	Yunmu ymENG = new Yunmu("eng", btnYunmuENG, false);
		//	mAllYunmus.Add(ymENG);

		//	Yunmu ymING = new Yunmu("ing", btnYunmuING, true);
		//	mAllYunmus.Add(ymING);

		//	Yunmu ymONG = new Yunmu("ong", btnYunmuONG, true);
		//	mAllYunmus.Add(ymONG);

		//}

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
				fs.Spans.Add(new Span { Text = samples });

			}
			else
			{
				fs.Spans.Add(new Span { Text = DefaultTip1 + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
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

		void OnClickYunmu(object sender, EventArgs e)
		{ 
			Button btn = (Button)sender;
			mYinjie.Shengmu = "";
			mYinjie.Yunmu = btn.Text;

			lblYinjie.Text = mYinjie.GetString();

			UpdateExplanation(ToneOfYinjie.TONE_NONE);

			if (mLastBtnTapped != null)
			{
				mLastBtnTapped.BackgroundColor = Color.FromHex("#FFE1FF");
			}

			mLastBtnTapped = btn;
			mLastBtnTapped.BackgroundColor = Color.DeepSkyBlue;

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
		//private List<Yunmu> mAllYunmus;
		public Button mLastBtnTapped = null;
		private const string DefaultTip1 = "";
	}
}
