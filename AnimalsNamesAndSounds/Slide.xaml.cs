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
using ImageTools.IO;

namespace AnimalsNamesAndSounds
{
    public partial class Slide : PhoneApplicationPage
    {
        int currentIndex = 1;
        string[] animalNames = { "Ape", "Bear", "Cat", "Deer", "Elephant", "Frog", "Goat", "Horse", "Ibis", "Jaguar", "Kangaroo", "Lion", "Monkey", "Nightingale", "Ostrich", "Penguin", "Quail", "Rabbit", "Snake", "Tiger", "UmbrellaBird", "Vulture", "Wolf", "Yak", "Zebra" };
        public Slide()
        {
            InitializeComponent();
            Thread.Sleep(3000);
            fillName();
        }

        private void fillName()
        {
            string temp1 = "";
            for (int i = 0; i < animalNames.Length; i++)
            {
                var control = (TextBlock)FindName("tb" + i);
                string temp = animalNames[i];
                char[] charString = temp.ToCharArray();
                for (int j = 0; j < charString.Length; j++)
                {
                    temp1 += charString[j] + "\n";
                }
                control.Text = temp1;
                temp1 = "";
                if (animalNames[i].Length > 10)
                    control.FontSize = 40;
                else
                    control.FontSize = 60;
            }
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
            pbLoad.IsIndeterminate = false;
        }

        private void Sound_Click(object sender, EventArgs e)
        {
            SoundPlay();
        }

        private void SelectionChanged_Click(object sender, EventArgs e)
        {
            SoundPlay();
            pbLoad.IsIndeterminate = true;
            Thread.Sleep(10);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (Pivot_Animal.SelectedIndex != Pivot_Animal.Items.Count - 1)
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