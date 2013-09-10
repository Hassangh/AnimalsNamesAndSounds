using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace AnimalsNamesAndSounds
{
    public partial class Quiz : PhoneApplicationPage
    {
        int ran1, ran2, ran3, ran4, ranSound, indexCopy, attempts, score, title = 0;
        int[] collection;
        string compliment = "";
        public Quiz()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            RandomNum();
            RandomSound();
            Img1.Source = new BitmapImage(new Uri("/Images/" + ran1 + ".jpg", UriKind.Relative));
            Img2.Source = new BitmapImage(new Uri("/Images/" + ran2 + ".jpg", UriKind.Relative));
            Img3.Source = new BitmapImage(new Uri("/Images/" + ran3 + ".jpg", UriKind.Relative));
            Img4.Source = new BitmapImage(new Uri("/Images/" + ran4 + ".jpg", UriKind.Relative));
            GuessSound.Source = new Uri("/Sounds/" + ranSound + ".mp3", UriKind.Relative);
            GuessSound.Play();
        }

        private void NextQuestion_Click(object sender, EventArgs e)
        {
            popupMessage.IsOpen = false;
            Initialization();
        }

        private void RestartQuiz_Click(object sender, EventArgs e)
        {
            score = 0;
            attempts = 0;
            popupMessage.IsOpen = false;
            bNext.IsEnabled = true;
            Initialization();
        }

        private void RandomNum()
        {
            Random rng = new Random();
            int[] values = Enumerable.Range(1, 25).OrderBy(x => rng.Next()).ToArray();
            ran1 = values[0];
            ran2 = values[1];
            ran3 = values[2];
            ran4 = values[3];
        }

        private void RandomSound()
        {
            collection = new int[4];
            collection[0] = ran1;
            collection[1] = ran2;
            collection[2] = ran3;
            collection[3] = ran4;
            Random random = new Random();
            ranSound = collection[random.Next(0, 4)];
        }

        private void Sound_Click(object sender, EventArgs e)
        {
            GuessSound.Play();
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void GetClick(int index)
        {
            indexCopy = index;
            if (score.Equals(9))
            {
                RightWrong.Source = new Uri("/Sounds/QuizComplete.mp3", UriKind.Relative);
                RightWrong.Play();
            }
            else
            {
                if (ranSound.Equals(collection[index]))
                {
                    RightWrong.Source = new Uri("/Sounds/Right.mp3", UriKind.Relative);
                    RightWrong.Play();
                }
                else
                {
                    RightWrong.Source = new Uri("/Sounds/Wrong.mp3", UriKind.Relative);
                    RightWrong.Play();
                }
            }
        }

        private void Img1_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetClick(0);
        }

        private void Img2_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetClick(1);
        }

        private void Img3_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetClick(2);
        }

        private void Img4_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GetClick(3);
        }

        private void Compliments()
        {
            if(attempts <= 10)
            {
                compliment = "WOW!! You're exceptional!!!";
            }
            else if (attempts <= 15)
            {
                compliment = "You're Excellent!!!";
            }
            else if (attempts <= 20)
                compliment = "You're Good!!!";
            else
                compliment = "That's average. Try again with lesser attempts!";
        }

        private void RightWrong_Started(object sender, RoutedEventArgs e)
        {
            imChild.Width = 200;
            tbChild.FontFamily = new System.Windows.Media.FontFamily("Buxton Sketch");
            title = 0;
            attempts++;
            if (score < 9)
            {
                if (ranSound.Equals(collection[indexCopy]))
                {
                    score++;
                    tbChild.Text = "Right Answer!!!";
                    tbScore.Text = "Your score is : " + score;
                    Random ran = new Random();
                    title = ran.Next(51,56);
                    imChild.Source = new BitmapImage(new Uri("/Images/" + title + ".png", UriKind.Relative));
                    popupMessage.IsOpen = true;
                }
                else
                {
                    tbChild.Text = "Wrong Answer...";
                    tbScore.Text = "Your score is : " + score;
                    Random ran = new Random();
                    title = ran.Next(61, 63);
                    imChild.Source = new BitmapImage(new Uri("/Images/" + title + ".png", UriKind.Relative));
                    tbChild.FontFamily = new System.Windows.Media.FontFamily("Buxton Sketch");
                    popupMessage.IsOpen = true;
                }
            }
            else
            {
                Compliments();
                score++;
                tbChild.Text = "CONGRATULATIONS!! Quiz Completed";
                tbScore.Text = "Your score is : " + score + "\n\rAttempts : " + attempts + "\n\rRemarks : " + compliment;
                imChild.Source = new BitmapImage(new Uri("/Images/Winner1.png", UriKind.Relative));
                bNext.IsEnabled = false;
                popupMessage.IsOpen = true;
                score = 0; attempts = 0;
            }
        }
    }
}