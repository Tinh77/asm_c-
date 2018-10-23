using Asm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LatestSong : Page
    {
        private bool isPlaying = false;

        int onPlay = 0;

        TimeSpan _position;

        DispatcherTimer _timer = new DispatcherTimer();

        private ObservableCollection<Song> listSong;
        internal ObservableCollection<Song> ArrayLatestSong { get => listSong; set => listSong = value; }

        public LatestSong()
        {
            this.ArrayLatestSong = new ObservableCollection<Song>();
            this.InitializeComponent();
            GetLatestSong();
            this.VolumeSlider.Value = 100;
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += ticktock;
            _timer.Start();
        }

        private void ticktock(object sender, object e)
        {
            MinDuration.Text = MediaPlayer.Position.Minutes + ":" + MediaPlayer.Position.Seconds;
            Progress.Minimum = 0;
            Progress.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            MaxDuration.Text = MediaPlayer.NaturalDuration.TimeSpan.Minutes + ":" + MediaPlayer.NaturalDuration.TimeSpan.Seconds;
            Progress.Value = MediaPlayer.Position.TotalSeconds;
        }

        private async void GetLatestSong()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Service.ApiHandle.TOKEN_STRING);
            var resp = client.GetAsync(Service.ApiHandle.API_LATEST_SONG).Result;
            var content = await resp.Content.ReadAsStringAsync();
            ObservableCollection<Song> song = JsonConvert.DeserializeObject<ObservableCollection<Song>>(content);
            foreach (var item in song)
            {
                if (item != null)
                {
                    this.ArrayLatestSong.Add(item);
                }
            }
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            Song selectedSong = panel.Tag as Song;
            onPlay = MenuList.SelectedIndex;
            LoadSong(selectedSong);
            PlaySong();
        }
        private void PlaySong()
        {
            MediaPlayer.Play();
            PlayButton.Icon = new SymbolIcon(Symbol.Pause);
            isPlaying = true;
        }
        private void PauseSong()
        {
            MediaPlayer.Pause();
            PlayButton.Icon = new SymbolIcon(Symbol.Play);
            isPlaying = false;
        }
        private void PlayClick(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                PauseSong();
            }
            else
            {
                PlaySong();
            }
        }
        private void PlayBack(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
            onPlay -= 1;
            if (onPlay < 0)
            {
                onPlay = this.ArrayLatestSong.Count - 1;
            }
            LoadSong(ArrayLatestSong[onPlay]);
            PlaySong();
            MenuList.SelectedIndex = onPlay;
        }

        private void PlayNext(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
            onPlay += 1;
            if (onPlay >= ArrayLatestSong.Count)
            {
                onPlay = 0;
            }
            LoadSong(ArrayLatestSong[onPlay]);
            PlaySong();
            MenuList.SelectedIndex = onPlay;
        }
        private void LoadSong(Song currentSong)
        {
            this.NowPlaying.Text = "Loading";
            Image_Song.Source = new BitmapImage(new Uri(currentSong.thumbnail));
            MediaPlayer.Source = new Uri(currentSong.link);
            this.NowPlaying.Text = currentSong.name + " - " + currentSong.singer;
            Name_song.Text = currentSong.name;
            Singer_song.Text = currentSong.singer;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MediaPlayer.Source != null && MediaPlayer.NaturalDuration.HasTimeSpan)
            {
                Progress.Minimum = 0;
                Progress.Maximum = MediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                Progress.Value = MediaPlayer.Position.TotalSeconds;

            }
        }

        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider vol = sender as Slider;
            if (vol != null)
            {
                MediaPlayer.Volume = vol.Value / 100;
                this.volume.Text = vol.Value.ToString();
            }
        }


    }

}
