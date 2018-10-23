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
    public sealed partial class ListSong : Page
    {
        private bool isPlaying = false;
        private ObservableCollection<Song> listSong;
        internal ObservableCollection<Song> ArrayListSong { get => listSong; set => listSong = value; }

        int _currentIndex = 0;

        TimeSpan _position;

        DispatcherTimer _timer = new DispatcherTimer();
        public ListSong()
        {
            this.ArrayListSong = new ObservableCollection<Song>();
            this.InitializeComponent();
            GetListMySong();
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

        private async void GetListMySong()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Service.ApiHandle.TOKEN_STRING);
            var resp = client.GetAsync(Service.ApiHandle.API_MY_LIST_SONG).Result;
            var content = await resp.Content.ReadAsStringAsync();
            ObservableCollection<Song> song = JsonConvert.DeserializeObject<ObservableCollection<Song>>(content);
            foreach (var item in song)
            {
                this.ArrayListSong.Add(item);
            }
        }

        private void Click_MySong(object sender, TappedRoutedEventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            Song song = panel.Tag as Song;
            _currentIndex = this.MyListSong.SelectedIndex;
            LoadSong(song);
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
            _currentIndex -= 1;
            if (_currentIndex < 0)
            {
                _currentIndex = ArrayListSong.Count - 1;
            }
            LoadSong(ArrayListSong[_currentIndex]);
            PlaySong();
            MyListSong.SelectedIndex = _currentIndex;
        }

        private void PlayNext(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Stop();
            if (_currentIndex < ArrayListSong.Count - 1)
            {
                _currentIndex = _currentIndex + 1;
            }
            else
            {
                _currentIndex = 0;
            }
            LoadSong(ArrayListSong[_currentIndex]);
            PlaySong();
            MyListSong.SelectedIndex = _currentIndex;
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
