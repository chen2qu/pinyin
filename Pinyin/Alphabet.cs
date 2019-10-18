using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace Pinyin
{
	public class Alphabet
	{
		public Alphabet()
		{
			mAlphabet = "";
			ButtonCtrl = null;
		}

		public Alphabet(string alphabet, Button ctrl)
		{
			Yinjie = alphabet;
			ButtonCtrl = ctrl;
		}

		protected string mAlphabet;
		public string Yinjie
		{
			get 
			{
				return mAlphabet;
			}
			set 
			{
				mAlphabet = value;
			}
		}

		protected Button mBindToButton;
		public Button ButtonCtrl
		{
			get
			{
				return mBindToButton;
			}
			set 
			{
				mBindToButton = value;
			}
		}
	}

	public class Shengmu : Alphabet
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Pinyin.Shengmu"/> class. 
		/// It's expected that the validYunmus is a string contains all valid yunmus that can be used after the given shengmu, comma separated.
		/// </summary>
		/// <param name="shengmu">Shengmu.</param>
		/// <param name="ctrl">Button control binded ot this shengmu.</param>
		/// <param name="validYunmus">Valid yunmus.</param>
		public Shengmu(string shengmu, Button ctrl, string validYunmus)
		{
			this.mAlphabet = shengmu;
			this.mBindToButton = ctrl;

			char[] seps = { ','};
			string[] separatedYunmus = validYunmus.Split(seps);
			mYunmuList = new List<string>();
			for (int i = 0; i < separatedYunmus.Length; i++)
			{
				mYunmuList.Add(separatedYunmus[i]);
			}
			mYunmuList.Sort();
		}

		private List<string> mYunmuList;
		public List<string> YunmuList
		{
			get 
			{
				return mYunmuList;
			}
		}

		/// <summary>
		/// Can append the given yunmu to the given yinjie. Sometimes a shengmu can be followed by two yunmus.
		/// </summary>
		/// <returns><c>true</c> if it's still a valid yinjie after appending the given yunmu <c>false</c> otherwise.</returns>
		/// <param name="yinjie">The given Yinjie to test, can be just a shengmu, or a valid yinjie with shengmu + one yunmu.</param>
		/// <param name="yunmu">The given Yunmu to test.</param>
		public bool CanAppendMoreYunmu(string yinjie, string yunmu)
		{
			string appendedYinjie = yinjie + yunmu;

			for (int i = 0; i < mYunmuList.Count; i++)
			{
				if (mYunmuList[i].Equals(appendedYinjie))
				{
					return true;
				}
			}
			return false;
		}
	}

	public class Yunmu : Alphabet
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Pinyin.Yunmu"/> class.
		/// </summary>
		/// <param name="yunmu">Yunmu.</param>
		/// <param name="ctrl">Button control binded to this yunmu.</param>
		/// <param name="requireShengmu">If set to <c>true</c> then it requires a shengmu to make a valid yinjie.</param>
		public Yunmu(string yunmu, Button ctrl, bool requireShengmu)
		{
			this.mAlphabet = yunmu;
			this.mBindToButton = ctrl;
			mRequireShengmu = requireShengmu;
		}

		private bool mRequireShengmu;
		public bool RequireShengmu
		{
			get
			{
				return mRequireShengmu;
			}
			set 
			{
				mRequireShengmu = value;
			}
		}
	}
}
