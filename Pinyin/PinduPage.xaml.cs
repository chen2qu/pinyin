using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class PinduPage : ContentPage
	{
		public PinduPage()
		{
			InitializeComponent();

			mYinjie = new Yinjie();

			InitializeShengmu();
			InitializeYunmu();

			//mYinjieExplanations = new YinjieXmlFile();
			//mYinjieExplanations.Load();

			UpdateExplanation(ToneOfYinjie.TONE_NONE);

			// set the tone buttons' initials status to false as no yinjie can be played
			UpdateToneButtonsStatus(false, false, false, false);
		}

		#region Initialize shengmu and yun, and bind them to corresponding button controls
		void InitializeShengmu()
		{
			mAllShengmus = new List<Shengmu>(24);

			Shengmu smB = new Shengmu("b", btnShengmuB, "ba,bai,ban,bang,bao,bei,ben,beng,bi,bian,biao,bie,bin,bing,bo,bu");
			mAllShengmus.Add(smB);

			Shengmu smP = new Shengmu("p", btnShengmuP, "pa,pai,pan,pang,pao,pei,pen,peng,pi,pian,piao,pie,pin,ping,po,pou,pu");
			mAllShengmus.Add(smP);

			Shengmu smM = new Shengmu("m", btnShengmuM, "ma,mai,man,mang,mao,me,mei,men,meng,mi,mian,miao,mie,min,ming,miu,mo,mou,mu");
			mAllShengmus.Add(smM);

			Shengmu smF = new Shengmu("f", btnShengmuF, "fa,fan,fang,fei,fen,feng,fiao,fo,fou,fu");
			mAllShengmus.Add(smF);

			Shengmu smD = new Shengmu("d", btnShengmuD, "da,dai,dan,dang,dao,de,dei,den,deng,di,dia,dian,diao,die,ding,diu,dong,dou,du,duan,dui,dun,duo");
			mAllShengmus.Add(smD);

			Shengmu smT = new Shengmu("t", btnShengmuT, "ta,tai,tan,tang,tao,te,tei,teng,ti,tian,tiao,tie,ting,tong,tou,tu,tuan,tui,tun,tuo");
			mAllShengmus.Add(smT);

			Shengmu smN = new Shengmu("n", btnShengmuN, "na,nai,nan,nang,nao,ne,nei,nen,neng,ni,nian,niang,niao,nie,nin,ning,niu,nong,nou,nu,nü,nuan,nüe,nun,nuo");
			mAllShengmus.Add(smN);

			Shengmu smL = new Shengmu("l", btnShengmuL, "la,lai,lan,lang,lao,le,lei,leng,li,lia,lian,liang,liao,lie,lin,ling,liu,lo,long,lou,lu,lü,luan,lüe,lun,luo");
			mAllShengmus.Add(smL);

			Shengmu smG = new Shengmu("g", btnShengmuG, "ga,gai,gan,gang,gao,ge,gei,gen,geng,gong,gou,gu,gua,guai,guan,guang,gui,gun,guo");
			mAllShengmus.Add(smG);

			Shengmu smK = new Shengmu("k", btnShengmuK, "ka,kai,kan,kang,kao,ke,kei,ken,keng,kong,kou,ku,kua,kuai,kuan,kuang,kui,kun,kuo");
			mAllShengmus.Add(smK);

			Shengmu smH = new Shengmu("h", btnShengmuH, "ha,hai,han,hang,hao,he,hei,hen,heng,hong,hou,hu,hua,huai,huan,huang,hui,hun,huo");
			mAllShengmus.Add(smH);

			Shengmu smJ = new Shengmu("j", btnShengmuJ, "ji,jia,jian,jiang,jiao,jie,jin,jing,jiong,jiu,ju,jü,juan,jüan,jue,jüe,jun,jün");
			mAllShengmus.Add(smJ);

			Shengmu smQ = new Shengmu("q", btnShengmuQ, "qi,qia,qian,qiang,qiao,qie,qin,qing,qiong,qiu,qu,qü,quan,qüan,que,qüe,qun,qün");
			mAllShengmus.Add(smQ);

			Shengmu smX = new Shengmu("x", btnShengmuX, "xi,xia,xian,xiang,xiao,xie,xin,xing,xiong,xiu,xu,xü,xuan,xüan,xue,xüe,xun,xün");
			mAllShengmus.Add(smX);

			Shengmu smZH = new Shengmu("zh", btnShengmuZH, "zha,zhai,zhan,zhang,zhao,zhe,zhei,zhen,zheng,zhi,zhong,zhou,zhu,zhua,zhuai,zhuan,zhuang,zhui,zhun,zhuo");
			mAllShengmus.Add(smZH);

			Shengmu smCH = new Shengmu("ch", btnShengmuCH, "cha,chai,chan,chang,chao,che,chen,cheng,chi,chong,chou,chu,chua,chuai,chuan,chuang,chui,chun,chuo");
			mAllShengmus.Add(smCH);

			Shengmu smSH = new Shengmu("sh", btnShengmuSH, "sha,shai,shan,shang,shao,she,shei,shen,sheng,shi,shou,shu,shua,shuai,shuan,shuang,shui,shun,shuo");
			mAllShengmus.Add(smSH);

			Shengmu smR = new Shengmu("r", btnShengmuR, "ran,rang,rao,re,ren,reng,ri,rong,rou,ru,rua,ruan,rui,run,ruo");
			mAllShengmus.Add(smR);

			Shengmu smZ = new Shengmu("z", btnShengmuZ, "za,zai,zan,zang,zao,ze,zei,zen,zeng,zi,zong,zou,zu,zuan,zui,zun,zuo");
			mAllShengmus.Add(smZ);

			Shengmu smC = new Shengmu("c", btnShengmuC, "ca,cai,can,cang,cao,ce,cen,ceng,ci,cong,cou,cu,cuan,cui,cun,cuo");
			mAllShengmus.Add(smC);

			Shengmu smS = new Shengmu("s", btnShengmuS, "sa,sai,san,sang,sao,se,sen,seng,si,song,sou,su,suan,sui,sun,suo");
			mAllShengmus.Add(smS);

			Shengmu smY = new Shengmu("y", btnShengmuY, "ya,yan,yang,yao,ye,yi,yin,ying,yo,yong,you,yu,yü,yuan,yüan,yue,yüe,yun,yün");
			mAllShengmus.Add(smY);

			Shengmu smW = new Shengmu("w", btnShengmuW, "wa,wai,wan,wang,wei,wen,weng,wo,wu");
			mAllShengmus.Add(smW);

		}

		void InitializeYunmu()
		{
			mAllYunmus = new List<Yunmu>(24);

			Yunmu ymA = new Yunmu("a", btnYunmuA, false);
			mAllYunmus.Add(ymA);

			Yunmu ymO = new Yunmu("o", btnYunmuO, false);
			mAllYunmus.Add(ymO);

			Yunmu ymE = new Yunmu("e", btnYunmuE, false);
			mAllYunmus.Add(ymE);

			Yunmu ymI = new Yunmu("i", btnYunmuI, true);
			mAllYunmus.Add(ymI);

			Yunmu ymU = new Yunmu("u", btnYunmuU, true);
			mAllYunmus.Add(ymU);

			Yunmu ymV = new Yunmu("ü", btnYunmuV, true);
			mAllYunmus.Add(ymV);

			Yunmu ymAI = new Yunmu("ai", btnYunmuAI, false);
			mAllYunmus.Add(ymAI);

			Yunmu ymEI = new Yunmu("ei", btnYunmuEI, false);
			mAllYunmus.Add(ymEI);

			Yunmu ymUI = new Yunmu("ui", btnYunmuUI, true);
			mAllYunmus.Add(ymUI);

			Yunmu ymAO = new Yunmu("ao", btnYunmuAO, false);
			mAllYunmus.Add(ymAO);

			Yunmu ymOU = new Yunmu("ou", btnYunmuOU, false);
			mAllYunmus.Add(ymOU);

			Yunmu ymIU = new Yunmu("iu", btnYunmuIU, true);
			mAllYunmus.Add(ymIU);

			Yunmu ymIE = new Yunmu("ie", btnYunmuIE, true);
			mAllYunmus.Add(ymIE);

			Yunmu ymVE = new Yunmu("üe", btnYunmuVE, true);
			mAllYunmus.Add(ymVE);

			Yunmu ymER = new Yunmu("er", btnYunmuER, false);
			mAllYunmus.Add(ymER);

			Yunmu ymAN = new Yunmu("an", btnYunmuAN, false);
			mAllYunmus.Add(ymAN);

			Yunmu ymEN = new Yunmu("en", btnYunmuEN, false);
			mAllYunmus.Add(ymEN);

			Yunmu ymIN = new Yunmu("in", btnYunmuIN, true);
			mAllYunmus.Add(ymIN);

			Yunmu ymUN = new Yunmu("un", btnYunmuUN, true);
			mAllYunmus.Add(ymUN);

			Yunmu ymVN = new Yunmu("ün", btnYunmuVN, true);
			mAllYunmus.Add(ymVN);

			Yunmu ymANG = new Yunmu("ang", btnYunmuANG, false);
			mAllYunmus.Add(ymANG);

			Yunmu ymENG = new Yunmu("eng", btnYunmuENG, false);
			mAllYunmus.Add(ymENG);

			Yunmu ymING = new Yunmu("ing", btnYunmuING, true);
			mAllYunmus.Add(ymING);

			Yunmu ymONG = new Yunmu("ong", btnYunmuONG, true);
			mAllYunmus.Add(ymONG);

		}

		#endregion

		#region playing the pinyin input

		void PlayYinjie(ToneOfYinjie tone)
		{
			string soundFile = "";

			// if user just chooses shengmu, then no tones are available
			// yunmu and full yinjie has tones
			if (mYinjie.Shengmu.Length > 0 && mYinjie.Yunmu.Length == 0)
			{
				soundFile = string.Format("{0}.MP3", mYinjie.Shengmu);
			}
			else
			{
				int toneInt = (int)tone;

				// Xamarin doesn't support adding assets with ü in name, 
				// so have to replace it with v
				string yinjieWithV = mYinjie.GetString().Replace("ü", "v");
				soundFile = string.Format("{0}{1}.MP3", yinjieWithV, toneInt);
			}

			AudioManager.Instance.PlaySound(soundFile);
			//	AudioManager.Instance.PlayBackgroundMusic(soundFile);
		}

		void UpdateYinjie(ToneOfYinjie tone)
		{
			//lblYinjie.Text = mYinjie.GetTonedString(tone);
			//lblYinjie.FormattedText = mYinjie.GetFormattedTonedString(tone, Color.FromHex("#E8AD00"), Color.LimeGreen, Color.FromHex("#E8AD00"));
			lblYinjie.FormattedText = mYinjie.GetFormattedTonedString(tone, Color.FromHex("#E8AD00"), Color.LimeGreen, Color.FromHex("#E8AD00"));
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

		void UpdateToneButtonsStatus(bool tone1BtnEnabled, bool tone2BtnEnabled, bool tone3BtnEnabled, bool tone4BtnEnabled)
		{
			btnTone1.IsEnabled = tone1BtnEnabled;
			btnTone2.IsEnabled = tone2BtnEnabled;
			btnTone3.IsEnabled = tone3BtnEnabled;
			btnTone4.IsEnabled = tone4BtnEnabled;
		}

		#endregion

		#region Handle shengmu and yunmu button click events
		void OnClickShengmu(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			mYinjie.Shengmu = btn.Text;
			mYinjie.Yunmu = "";
            mYinjie.ToneRule = Yinjie.ToneRuleEnum.TONERULE_NONE;

            string soundFile = string.Format("{0}.MP3", mYinjie.Shengmu);
            AudioManager.Instance.PlaySound(soundFile);

            if (mLastShengmuBtnTapped != null)
			{
				mLastShengmuBtnTapped.BackgroundColor = Color.FromHex("#FAF0E6");
			}

			mLastShengmuBtnTapped = btn;
			mLastShengmuBtnTapped.BackgroundColor = Color.Yellow;

			if(mYunmuBtnTapped1 != null)
			{
				mYunmuBtnTapped1.BackgroundColor = Color.FromHex("#FFE1FF");
				mYunmuBtnTapped1 = null;
			}

			if(mYunmuBtnTapped2 != null)
			{
				mYunmuBtnTapped2.BackgroundColor = Color.FromHex("#FFE1FF");
				mYunmuBtnTapped2 = null;
			}

			if(mYunmuBtnTapped3 != null)
			{
				mYunmuBtnTapped3.BackgroundColor = Color.FromHex("#FFE1FF");
				mYunmuBtnTapped3 = null;
			}

			// TODO: 判断哪些韵母按钮可以跟选定的声母搭配，将按钮设置为可用，其他的按钮设置为不可用
			ValidateYunmu(mYinjie.Shengmu);

			lblYinjie.Text = mYinjie.Shengmu;

			UpdateExplanation(ToneOfYinjie.TONE_NONE);

			UpdateToneButtonsStatus(true, false, false, false);
		}

		void OnClickYunmu(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
            mYinjie.ToneRule = Yinjie.ToneRuleEnum.TONERULE_NONE;

            string yinjieWithV = btn.Text.Replace("ü", "v");
            string soundFile = string.Format("{0}.MP3", yinjieWithV);
            AudioManager.Instance.PlaySound(soundFile);

            if (mYinjie.Shengmu.Equals(""))
			{
				mYinjie.Yunmu = btn.Text;

				if(mYunmuBtnTapped1 != null)
				{
					mYunmuBtnTapped1.BackgroundColor = Color.FromHex("#FFE1FF");
				}
				mYunmuBtnTapped1 = btn;
				mYunmuBtnTapped1.BackgroundColor = Color.LimeGreen;

				if(mYunmuBtnTapped2 != null)
				{
					mYunmuBtnTapped2.BackgroundColor = Color.FromHex("#FFE1FF");
					mYunmuBtnTapped2 = null;
				}
			}
			else
			{
				mYinjie.Yunmu += btn.Text;

				if(mYunmuBtnTapped1 == null)
				{
					mYunmuBtnTapped1 = btn;
					mYunmuBtnTapped1.BackgroundColor = Color.GreenYellow;
				}
				else if (mYunmuBtnTapped2 == null)
				{
					mYunmuBtnTapped2 = btn;
					mYunmuBtnTapped2.BackgroundColor = Color.YellowGreen;
				}
				else 
				{
					mYunmuBtnTapped3 = btn;
					mYunmuBtnTapped3.BackgroundColor = Color.LimeGreen;
				}
			}

			lblYinjie.Text = mYinjie.GetString();
			//UpdateYinjie(ToneOfYinjie.TONE_NONE);

			ValidateYunmu(mYinjie.Shengmu);

			UpdateExplanation(ToneOfYinjie.TONE_NONE);

			UpdateToneButtonsStatus(true, true, true, true);
		}

		Shengmu GetShengmuObject(string sm)
		{
			for (int i = 0; i < mAllShengmus.Count; i++)
			{
				if (sm.Equals(mAllShengmus[i].Yinjie))
				{
					return mAllShengmus[i];
				}
			}
			return null;
		}

		void ValidateYunmu(string shengmu)
		{
			Shengmu smObj = GetShengmuObject(mYinjie.Shengmu);
			if (null == smObj)
			{
				for (int i = 0; i < mAllYunmus.Count; i++)
				{
					mAllYunmus[i].ButtonCtrl.IsEnabled = true;
				}
				return;
			}

			for (int i = 0; i < mAllYunmus.Count; i++)
			{
				mAllYunmus[i].ButtonCtrl.IsEnabled = smObj.CanAppendMoreYunmu(mYinjie.GetString(), mAllYunmus[i].Yinjie);
			}

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

				fs.Spans.Add(new Span { Text = pinyinData.AllYinjies[yinjieIndex].Desc + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
                if (mYinjie.ToneRule != Yinjie.ToneRuleEnum.TONERULE_NONE)
                {
                    fs.Spans.Add(new Span { Text = string.Format("声调规则: {0}\n", mYinjie.ToneRules[(int)mYinjie.ToneRule]), ForegroundColor = Color.LimeGreen });
                }
                fs.Spans.Add(new Span { Text = samples });

			}
			else
			{
				fs.Spans.Add(new Span { Text = DefaultTip1 + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
				fs.Spans.Add(new Span { Text = DefaultTip2 });

			}

			lblExplanation.FormattedText = fs;
		}

		#endregion

		#region data members
		private Yinjie mYinjie;
		private List<Shengmu> mAllShengmus;
		private List<Yunmu> mAllYunmus;
		//private YinjieXmlFile mYinjieExplanations;

		private Button mLastShengmuBtnTapped = null;
		private Button mYunmuBtnTapped1 = null;
		private Button mYunmuBtnTapped2 = null;
		private Button mYunmuBtnTapped3 = null;

		private const string DefaultPinyin = "拼音";
		private const string DefaultTip1 = "qǐng pīn chū yīn jíe, rán hòu xuǎn zé shēng diào pīn dú";
		private const string DefaultTip2 = " 请    拼   出   音  节,  然    后    选    择   声      调    拼   读";
		#endregion
	}
}
