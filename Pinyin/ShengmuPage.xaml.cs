using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class ShengmuPage : ContentPage
	{
		public ShengmuPage()
		{
			InitializeComponent();

			mYinjie = new Yinjie();
			//InitializeShengmu();
		}

		//void InitializeShengmu()
		//{
		//	mAllShengmus = new List<Shengmu>(24);

		//	Shengmu smB = new Shengmu("b", btnShengmuB, "ba,bai,ban,bang,bao,bei,ben,beng,bi,bian,biao,bie,bin,bing,bo,bu");
		//	mAllShengmus.Add(smB);

		//	Shengmu smP = new Shengmu("p", btnShengmuP, "pa,pai,pan,pang,pao,pei,pen,peng,pi,pian,piao,pie,pin,ping,po,pou,pu");
		//	mAllShengmus.Add(smP);

		//	Shengmu smM = new Shengmu("m", btnShengmuM, "ma,mai,man,mang,mao,me,mei,men,meng,mi,mian,miao,mie,min,ming,miu,mo,mou,mu");
		//	mAllShengmus.Add(smM);

		//	Shengmu smF = new Shengmu("f", btnShengmuF, "fa,fan,fang,fei,fen,feng,fiao,fo,fou,fu");
		//	mAllShengmus.Add(smF);

		//	Shengmu smD = new Shengmu("d", btnShengmuD, "da,dai,dan,dang,dao,de,dei,den,deng,di,dia,dian,diao,die,ding,diu,dong,dou,du,duan,dui,dun,duo");
		//	mAllShengmus.Add(smD);

		//	Shengmu smT = new Shengmu("t", btnShengmuT, "ta,tai,tan,tang,tao,te,tei,teng,ti,tian,tiao,tie,ting,tong,tou,tu,tuan,tui,tun,tuo");
		//	mAllShengmus.Add(smT);

		//	Shengmu smN = new Shengmu("n", btnShengmuN, "na,nai,nan,nang,nao,ne,nei,nen,neng,ni,nian,niang,niao,nie,nin,ning,niu,nong,nou,nu,nü,nuan,nüe,nun,nuo");
		//	mAllShengmus.Add(smN);

		//	Shengmu smL = new Shengmu("l", btnShengmuL, "la,lai,lan,lang,lao,le,lei,leng,li,lia,lian,liang,liao,lie,lin,ling,liu,lo,long,lou,lu,lü,luan,lüe,lun,luo");
		//	mAllShengmus.Add(smL);

		//	Shengmu smG = new Shengmu("g", btnShengmuG, "ga,gai,gan,gang,gao,ge,gei,gen,geng,gong,gou,gu,gua,guai,guan,guang,gui,gun,guo");
		//	mAllShengmus.Add(smG);

		//	Shengmu smK = new Shengmu("k", btnShengmuK, "ka,kai,kan,kang,kao,ke,kei,ken,keng,kong,kou,ku,kua,kuai,kuan,kuang,kui,kun,kuo");
		//	mAllShengmus.Add(smK);

		//	Shengmu smH = new Shengmu("h", btnShengmuH, "ha,hai,han,hang,hao,he,hei,hen,heng,hong,hou,hu,hua,huai,huan,huang,hui,hun,huo");
		//	mAllShengmus.Add(smH);

		//	Shengmu smJ = new Shengmu("j", btnShengmuJ, "ji,jia,jian,jiang,jiao,jie,jin,jing,jiong,jiu,ju,juan,jue,jun");
		//	mAllShengmus.Add(smJ);

		//	Shengmu smQ = new Shengmu("q", btnShengmuQ, "qi,qia,qian,qiang,qiao,qie,qin,qing,qiong,qiu,qu,quan,que,qun");
		//	mAllShengmus.Add(smQ);

		//	Shengmu smX = new Shengmu("x", btnShengmuX, "xi,xia,xian,xiang,xiao,xie,xin,xing,xiong,xiu,xu,xuan,xue,xun");
		//	mAllShengmus.Add(smX);

		//	Shengmu smZH = new Shengmu("zh", btnShengmuZH, "zha,zhai,zhan,zhang,zhao,zhe,zhei,zhen,zheng,zhi,zhong,zhou,zhu,zhua,zhuai,zhuan,zhuang,zhui,zhun,zhuo");
		//	mAllShengmus.Add(smZH);

		//	Shengmu smCH = new Shengmu("ch", btnShengmuCH, "cha,chai,chan,chang,chao,che,chen,cheng,chi,chong,chou,chu,chua,chuai,chuan,chuang,chui,chun,chuo");
		//	mAllShengmus.Add(smCH);

		//	Shengmu smSH = new Shengmu("sh", btnShengmuSH, "sha,shai,shan,shang,shao,she,shei,shen,sheng,shi,shou,shu,shua,shuai,shuan,shuang,shui,shun,shuo");
		//	mAllShengmus.Add(smSH);

		//	Shengmu smR = new Shengmu("r", btnShengmuR, "ran,rang,rao,re,ren,reng,ri,rong,rou,ru,rua,ruan,rui,run,ruo");
		//	mAllShengmus.Add(smR);

		//	Shengmu smZ = new Shengmu("z", btnShengmuZ, "za,zai,zan,zang,zao,ze,zei,zen,zeng,zi,zong,zou,zu,zuan,zui,zun,zuo");
		//	mAllShengmus.Add(smZ);

		//	Shengmu smC = new Shengmu("c", btnShengmuC, "ca,cai,can,cang,cao,ce,cen,ceng,ci,cong,cou,cu,cuan,cui,cun,cuo");
		//	mAllShengmus.Add(smC);

		//	Shengmu smS = new Shengmu("s", btnShengmuS, "sa,sai,san,sang,sao,se,sen,seng,si,song,sou,su,suan,sui,sun,suo");
		//	mAllShengmus.Add(smS);

		//	Shengmu smY = new Shengmu("y", btnShengmuY, "ya,yan,yang,yao,ye,yi,yin,ying,yo,yong,you,yu,yuan,yue,yun");
		//	mAllShengmus.Add(smY);

		//	Shengmu smW = new Shengmu("w", btnShengmuW, "wa,wai,wan,wang,wei,wen,weng,wo,wu");
		//	mAllShengmus.Add(smW);

		//}

		void UpdateExplanation()
		{
			YinjieXmlFile pinyinData = PinyinDataManager.Instance.GetAllYinjies();
			int yinjieIndex = pinyinData.FindYinjie(mYinjie.GetString());

			FormattedString fs = new FormattedString();

			if (yinjieIndex >= 0)
			{
				fs.Spans.Add(new Span { Text = pinyinData.AllYinjies[yinjieIndex].Desc + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
			}
			else
			{
				fs.Spans.Add(new Span { Text = DefaultTip1 + "\n", ForegroundColor = Color.FromHex("#E8AD00") });
			}

			lblExplanation.FormattedText = fs;
		}

		void OnClickShengmu(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			mYinjie.Shengmu = btn.Text;
			mYinjie.Yunmu = "";

			string soundFile = string.Format("{0}.MP3", mYinjie.Shengmu);
			AudioManager.Instance.PlaySound(soundFile);

			UpdateExplanation();

			if (mLastBtnTapped != null)
			{
				mLastBtnTapped.BackgroundColor = Color.FromHex("#FAF0E6");
			}

			mLastBtnTapped = btn;
			mLastBtnTapped.BackgroundColor = Color.Yellow;

		}

		//private List<Shengmu> mAllShengmus;
		private Yinjie mYinjie;
		private const string DefaultTip1 = "";
		public Button mLastBtnTapped = null;
	}
}
