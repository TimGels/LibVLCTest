using GalaSoft.MvvmLight.Command;
using LibVLCSharp.Platforms.UWP;
using LibVLCSharp.Shared;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace LibVLCTest
{
    public class ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LibVLC LibVLC { get; set; }
        private MediaPlayer mediaPlayer;

        /// <summary>
        /// Gets the commands for the initialization
        /// </summary>
        public ICommand InitializeLibVLCCommand { get; }

        /// <summary>
        /// Gets the media player
        /// </summary>
        public MediaPlayer MediaPlayer {
            get { return mediaPlayer; }
            set {
                mediaPlayer = value;
                NotifyPropertyChanged("MediaPlayer");
            }
        }

        public ViewModel()
        {
            InitializeLibVLCCommand = new RelayCommand<InitializedEventArgs>(InitializeLibVLC);
        }

        private void InitializeLibVLC(InitializedEventArgs eventArgs)
        {
            LibVLC = new LibVLC(eventArgs.SwapChainOptions);
            MediaPlayer = new MediaPlayer(LibVLC);
            MediaPlayer.Play(new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
