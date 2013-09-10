using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.BackgroundAudio;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;

namespace AnimalsNamesAndSounds
{
    public partial class Slide : PhoneApplicationPage
    {
        int currentIndex = 1;
        public Slide()
        {
            InitializeComponent();
            Thread.Sleep(3000);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (Pivot_Animal.SelectedIndex != 0)
            {
                Pivot_Animal.SelectedIndex--;
            }
            else
                Pivot_Animal.SelectedIndex = 24;
        }

        private void SoundPlay()
        {
            currentIndex = Pivot_Animal.SelectedIndex + 1;
            Name.Source = new Uri("/Names/" + currentIndex + ".mp3", UriKind.Relative);
            Name.Play();
        }

        private void Sound_Click(object sender, EventArgs e)
        {
            SoundPlay();
        }

        private void SelectionChanged_Click(object sender, EventArgs e)
        {
            SoundPlay();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Pivot_Animal.SelectedIndex != 24)
            {
                Pivot_Animal.SelectedIndex++;
            }
            else
                Pivot_Animal.SelectedIndex = 0;
        }

        private void TakeQuiz_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Quiz.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void Name_Finished(object sender, RoutedEventArgs e)
        {
            Sound.Source = new Uri("/Sounds/" + currentIndex + ".mp3", UriKind.Relative);
            Sound.Play();
        }
    }
}