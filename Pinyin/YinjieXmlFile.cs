using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Pinyin
{
	public class YinjieXmlFile
	{
		public YinjieXmlFile()
		{
			mYinjieDescs = new List<YinjieDesc>();
		}

		public bool Load()
		{
			XmlDocument yinJieXml = new XmlDocument();
			mYinjieDescs.Clear();

			try
			{
				string path = "";

#if __IOS__
				var resourcePrefix = "Pinyin.iOS.Data";
				path = string.Format("{0}.{1}", resourcePrefix, YinjieXmlFileName);
#elif __ANDROID__
				var resourcePrefix = "Pinyin.Droid.Data";
				path = string.Format("{0}.{1}", resourcePrefix, YinjieXmlFileName);
#else 
				path = YinjieXmlFileName;
#endif

#if __MOBILE__
				var assembly = typeof(PinyinPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(path);
				yinJieXml.Load(stream);
#else
				yinJieXml.Load(path);
#endif

				string xpath = string.Format("/{0}/{1}", YinjieRootElement, YinjieElement);
				XmlNodeList yinjieList = yinJieXml.SelectNodes(xpath);

				if (null != yinjieList)
				{
					foreach (XmlNode yinjie in yinjieList)
					{
						YinjieDesc yjDesc = new YinjieDesc();

						yjDesc.Yinjie = yinjie.Attributes[YinjieNameAttribute].Value;

						yjDesc.Desc = yinjie.ChildNodes[0].InnerText;
						yjDesc.Tone1Samples = yinjie.ChildNodes[1].InnerText;
						yjDesc.Tone2Samples = yinjie.ChildNodes[2].InnerText;
						yjDesc.Tone3Samples = yinjie.ChildNodes[3].InnerText;
						yjDesc.Tone4Samples = yinjie.ChildNodes[4].InnerText;

						mYinjieDescs.Add(yjDesc);
					}
				}

				return true;
			}
			catch (Exception e)
			{
#if DEBUG
				System.Console.WriteLine(e.Message);
#endif
				return false;
			}

		}

		public bool WriteToFile()
		{
#if !__MOBILE__
			using (StreamWriter sw = new StreamWriter(YinjieXmlFileName, false, Encoding.UTF8))
            {
                // Create Xml Writer.   
                XmlTextWriter xmlWriter = new XmlTextWriter(sw);
                // 也可以使用public XmlTextWriter(string filename, Encoding encoding)来构造   
                // encoding默认为 UTF-8.   
                //XmlTextWriter writer = new XmlTextWriter("test3.xml", null);   
                // Set indenting so that its easier to read XML when open in Notepad and such apps.   
                xmlWriter.Formatting = Formatting.Indented;
                // This will output the XML declaration   
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(YinjieRootElement);

                for (int i = 0; i < mYinjieDescs.Count; i++)
                {
                    xmlWriter.WriteStartElement(YinjieElement);

                    xmlWriter.WriteAttributeString(YinjieNameAttribute, mYinjieDescs[i].Yinjie);
                    xmlWriter.WriteElementString(YinjieDesc, mYinjieDescs[i].Desc);
                    xmlWriter.WriteElementString(YinjieTone1Samples, mYinjieDescs[i].Tone1Samples);
                    xmlWriter.WriteElementString(YinjieTone2Samples, mYinjieDescs[i].Tone2Samples);
                    xmlWriter.WriteElementString(YinjieTone3Samples, mYinjieDescs[i].Tone3Samples);
                    xmlWriter.WriteElementString(YinjieTone4Samples, mYinjieDescs[i].Tone4Samples);
                    
                    // close yinjie </yinjie>   
                    xmlWriter.WriteEndElement();
                   
                }

                // close yinjies </yinjies>   
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
				return true;
            }   
#endif
			return false;
        }

        public bool IsYinjieExist(YinjieDesc desc)
        {
            return null != mYinjieDescs.Find(
                    delegate(YinjieDesc yjd)
                    {
                        return yjd.Yinjie.Equals(desc.Yinjie);
                    }
                );
        }

        public bool AddYinjieDesc(YinjieDesc desc)
        {
            if(IsYinjieExist(desc))
                return false;

            mYinjieDescs.Add(desc);
            return true;
        }

        public int FindYinjie(string yinjie)
        {
            for (int i = 0; i < mYinjieDescs.Count; i++)
            {
                if (mYinjieDescs[i].Yinjie.Equals(yinjie))
                {
                    return i;
                }
            }
            return -1;
        }

        private List<YinjieDesc> mYinjieDescs;
        public List<YinjieDesc> AllYinjies
        {
            get { return mYinjieDescs; }
        }

        public const string YinjieXmlFileName = "yinjie.xml";
        public const string YinjieRootElement = "Yinjies";
        public const string YinjieElement = "yinjie";
        public const string YinjieNameAttribute = "name";
        public const string YinjieDesc = "desc";
        public const string YinjieTone1Samples = "tone1Samples";
        public const string YinjieTone2Samples = "tone2Samples";
        public const string YinjieTone3Samples = "tone3Samples";
        public const string YinjieTone4Samples = "tone4Samples";
    }
}
