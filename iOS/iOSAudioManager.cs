﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pinyin.iOS;
using AVFoundation;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSAudioManager))]
namespace Pinyin.iOS
{
	public class iOSAudioManager : IAudioManager
	{
		#region Private Variables

		private readonly List<AVAudioPlayer> _soundEffects = new List<AVAudioPlayer>();

		private AVAudioPlayer _soundPlaying = null; //new AVAudioPlayer();

		private AVAudioPlayer _backgroundMusic;
		private string _backgroundSong = "";

		//This is needed for iOS and Andriod because they do not await loading music
		private bool _backgroundMusicLoading = false;
		private bool _musicOn = true;
		private bool _effectsOn = true;
		private float _backgroundMusicVolume = 0.5f;
		private float _effectsVolume = 1.0f;


		#endregion

		#region Computed Properties

		public float BackgroundMusicVolume
		{
			get
			{
				return _backgroundMusicVolume;
			}
			set
			{
				_backgroundMusicVolume = value;

				if (_backgroundMusic != null)
					_backgroundMusic.Volume = _backgroundMusicVolume;
			}
		}

		public bool MusicOn
		{
			get { return _musicOn; }
			set
			{
				_musicOn = value;

				if (!MusicOn)
					SuspendBackgroundMusic();
				else
#pragma warning disable 4014
					RestartBackgroundMusic();
#pragma warning restore 4014

			}
		}

		public bool EffectsOn
		{
			get { return _effectsOn; }
			set
			{
				_effectsOn = value;

				if (!EffectsOn && _soundEffects.Any())
					foreach (var s in _soundEffects) s.Stop();
			}
		}

		public float EffectsVolume
		{
			get { return _effectsVolume; }
			set
			{
				_effectsVolume = value;

				if (_soundEffects.Any())
					foreach (var s in _soundEffects) s.Volume = _effectsVolume;
			}
		}

		public string SoundPath { get; set; } = "Sounds";

		#endregion

		#region Constructors

		public iOSAudioManager()
		{
			// Initialize
			ActivateAudioSession();
		}

		#endregion

		#region Public Methods

		public void ActivateAudioSession()
		{
			// Initialize Audio
			var session = AVAudioSession.SharedInstance();
			session.SetCategory(AVAudioSessionCategory.Ambient);
			session.SetActive(true);
		}

		public void DeactivateAudioSession()
		{
			var session = AVAudioSession.SharedInstance();
			session.SetActive(false);
		}

		public void ReactivateAudioSession()
		{
			var session = AVAudioSession.SharedInstance();
			session.SetActive(true);
		}

		public async Task<bool> PlayBackgroundMusic(string filename)
		{
			// Music enabled?
			if (!MusicOn || _backgroundMusicLoading) return false;

			_backgroundMusicLoading = true;

			// Any existing background music?
			if (_backgroundMusic != null)
			{
				//Stop and dispose of any background music
				_backgroundMusic.Stop();
				_backgroundMusic.Dispose();
			}
			_backgroundSong = filename;

			// Initialize background music
			_backgroundMusic = await NewSound(filename, BackgroundMusicVolume, true);

			_backgroundMusicLoading = false;

			return true;
		}

		public void StopBackgroundMusic()
		{
			// If any background music is playing, stop it
			_backgroundSong = "";
			if (_backgroundMusic != null)
			{
				_backgroundMusic.Stop();
				_backgroundMusic.Dispose();
			}
		}

		public void SuspendBackgroundMusic()
		{
			// If any background music is playing, stop it
			if (_backgroundMusic != null)
			{
				_backgroundMusic.Stop();
				_backgroundMusic.Dispose();
			}
		}

		public async Task<bool> RestartBackgroundMusic()
		{
			// Music enabled?
			if (!MusicOn) return false;

			// Was a song previously playing?
			if (_backgroundSong == "") return false;

			// Restart song to fix issue with wonky music after sleep
			return await PlayBackgroundMusic(_backgroundSong);
		}

		public async Task<bool> PlaySound(string filename)
		{
			// Music enabled?
			if (!EffectsOn) return false;

			////--------BEGIN: way to play multiple sounds simultaneously, but in the Pinyin app we need them to be linear-----
			//// Initialize sound
			//var effect = await NewSound(filename, EffectsVolume);
			//_soundEffects.Add(effect);
			//
			//_soundPlaying = effect;
			////--------END way to play multiple sounds simultaneously, but in the Pinyin app we need them to be linear-----

			var songUrl = new NSUrl(Path.Combine(SoundPath, filename));
			NSError err;
			var fileType = filename.Split('.').Last();

			if (_soundPlaying != null)
			{
				if (_soundPlaying.Playing)
				{
					_soundPlaying.Stop();
					_soundPlaying.CurrentTime = 0.0f;
				}

				_soundPlaying.Dispose();
			}

			_soundPlaying = new AVAudioPlayer(songUrl, fileType, out err);
			_soundPlaying.Play();

			return true;
		}

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
		private async Task<AVAudioPlayer> NewSound(string filename, float defaultVolume, bool isLooping = false)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		{

			var songUrl = new NSUrl(Path.Combine(SoundPath, filename));
			NSError err;
			var fileType = filename.Split('.').Last();
			var sound = new AVAudioPlayer(songUrl, fileType, out err)
			{
				Volume = defaultVolume,
				NumberOfLoops = isLooping ? -1 : 0
			};

			//// this will stop the current playing sound, but will also introduce weird noise....
			//if (_soundPlaying != null && _soundPlaying.Playing)
			//{
			//	_soundPlaying.Stop();
			//	_soundPlaying.Dispose();
			//}

			sound.FinishedPlaying += SoundOnFinishedPlaying;

			sound.Play();

			return sound;
		}

		private void SoundOnFinishedPlaying(object sender, AVStatusEventArgs avStatusEventArgs)
		{
			var se = sender as AVAudioPlayer;

			if (se != _backgroundMusic)
				_soundEffects.Remove(se);

			//todo: This casues an error
			//se?.Dispose();
		}

		#endregion
	}
}
