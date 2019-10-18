using System;
using Xamarin.Forms;

namespace Pinyin
{
	public static class AudioManager
	{
		public static IAudioManager Instance { get; } = DependencyService.Get<IAudioManager>();
	}
}
