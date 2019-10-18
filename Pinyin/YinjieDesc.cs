using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinyin
{
    public class YinjieDesc
    {
        public YinjieDesc()
        { }

        private string mYinjie;
        public string Yinjie
        {
            get
            {
                return mYinjie;
            }
            set
            {
                mYinjie = value;
            }
        }

        private string mDesc;
        public string Desc 
        {
            get { return mDesc; }
            set { mDesc = value; }
        }

        private string mTone1Samples;
        public string Tone1Samples
        {
            get { return mTone1Samples; }
            set { mTone1Samples = value; }
        }

        private string mTone2Samples;
        public string Tone2Samples
        {
            get { return mTone2Samples; }
            set { mTone2Samples = value; }
        }

        private string mTone3Samples;
        public string Tone3Samples
        {
            get { return mTone3Samples; }
            set { mTone3Samples = value; }
        }

        private string mTone4Samples;
        public string Tone4Samples
        {
            get { return mTone4Samples; }
            set { mTone4Samples = value; }
        }
    }
}
