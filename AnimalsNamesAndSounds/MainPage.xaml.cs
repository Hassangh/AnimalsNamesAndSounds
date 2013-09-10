using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AnimalsNamesAndSounds.Resources;

namespace AnimalsNamesAndSounds
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {

        }

        private void What_Click(object sender, EventArgs e)
        {
            Lion_Pro.Play();
        }

        private void Sound_Click(object sender, EventArgs e)
        {
            LionRoar.Play();
        }

        private void Next_Click(object sender, EventArgs e)
        {

        }
    }
}