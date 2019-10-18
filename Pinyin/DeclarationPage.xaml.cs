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
	public partial class DeclarationPage : ContentPage
	{
		public DeclarationPage()
		{
			InitializeComponent();

			string path = "";

#if __IOS__
			var resourcePrefix = "Pinyin.iOS.Data";
			path = string.Format("{0}.{1}", resourcePrefix, DeclarationsFileName);
#elif __ANDROID__
			var resourcePrefix = "Pinyin.Droid.Data";
			path = string.Format("{0}.{1}", resourcePrefix, DeclarationsFileName);
#else
			path = DeclarationsFileName;
#endif
			try
			{
				XmlDocument declarationsXml = new XmlDocument();
				var assembly = typeof(DeclarationPage).GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(path);

				declarationsXml.Load(stream);

				var declarationsStack = new StackLayout { Padding = new Thickness(10, 10) };

				string xpath = string.Format("/{0}/{1}", DeclarationsXmlRootNode, DeclarationsXmlElementNode);
				XmlNodeList declarationList = declarationsXml.SelectNodes(xpath);

				if (null != declarationList)
				{
					foreach (XmlNode declaration in declarationList)
					{
						var title = new FormattedString();
						title.Spans.Add(new Span { Text = declaration.Attributes[DeclarationNameAttribute].InnerText, FontAttributes = FontAttributes.Bold });
						title.Spans.Add(new Span { Text = "\n" });
						declarationsStack.Children.Add(new Label { FormattedText=title});

						foreach (XmlNode p in declaration.ChildNodes)
						{
							var paragraph = new FormattedString();
							paragraph.Spans.Add(new Span { Text = p.ChildNodes[0].InnerText});
							paragraph.Spans.Add(new Span { Text = "\n" });
							declarationsStack.Children.Add(new Label { FormattedText = paragraph });
						}

					}

					this.Content = new ScrollView { Content = declarationsStack };
				}
			}
			catch (Exception e)
			{
#if DEBUG
				System.Console.WriteLine(e.Message);
#endif
			}
		}

		public const string DeclarationsFileName = "Declarations.xml";
		public const string DeclarationsXmlRootNode = "Declarations";
		public const string DeclarationsXmlElementNode = "Declaration";
		public const string DeclarationNameAttribute = "name";
	}
}
