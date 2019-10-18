using System;
using Xamarin.Forms;

namespace Pinyin
{
	public interface IPicture
	{
		void SavePictureToDisk(ImageSource imgSrc, string fileName);
	}
}
