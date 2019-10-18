using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Xamarin.Forms;

namespace Pinyin
{
	public partial class FAQPage : ContentPage
	{
		public FAQPage()
		{
			InitializeComponent();

			string path = "";

#if __IOS__
			var resourcePrefix = "Pinyin.iOS.Data";
			path = string.Format("{0}.{1}", resourcePrefix, FAQFileName);
#elif __ANDROID__
			var resourcePrefix = "Pinyin.Droid.Data";
			path = string.Format("{0}.{1}", resourcePrefix, FAQFileName);
#else
			path = FAQFileName;
#endif
			try
			{
				XmlDocument faqXml = new XmlDocument();
				var assembly = typeof(FAQPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(path);

				faqXml.Load(stream);

				var qaStack = new StackLayout { Padding = new Thickness(10, 10) };

				string xpath = string.Format("/{0}/{1}", FAQXmlRootNode, FAQXmlElementNode);
				XmlNodeList faqList = faqXml.SelectNodes(xpath);

				if (null != faqList)
				{

					foreach (XmlNode qa in faqList)
					{
						var s = new FormattedString();
						s.Spans.Add(new Span { Text = qa.ChildNodes[0].InnerText, FontAttributes = FontAttributes.Bold });
						s.Spans.Add(new Span { Text = "\n" });
						s.Spans.Add(new Span { Text = qa.ChildNodes[1].InnerText });
						s.Spans.Add(new Span { Text = "\n" });

						Label oneQA = new Label();
						oneQA.FormattedText = s;

						qaStack.Children.Add(oneQA);
					}

					this.Content = new ScrollView { Content = qaStack };
				}
			}
			catch (Exception e)
			{
#if DEBUG
				System.Console.WriteLine(e.Message);
#endif
			}
		}

		public const string FAQFileName = "FAQ.xml";
		public const string FAQXmlRootNode = "QAs";
		public const string FAQXmlElementNode = "QA";
	}
}
