using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using AutoMapper;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using VKFriendsProject.Domain.Models;
using VKFriendsProject.Domain.Profiles;

namespace VKFriendsProject
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
            Mapper.AddProfile<ModelsProfile>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            HandleTheme();
        }

        private void HandleTheme()
        {
            var isDarkTheme = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible;

            if (isDarkTheme)
            {
                LogoImage.Source = new BitmapImage(new Uri("/Assets/IconWhite.png",UriKind.Relative));
            }
            else
            {
                LogoImage.Source = new BitmapImage(new Uri("/Assets/IconBlack.png", UriKind.Relative));
            }
        }

        private void LongListSelector_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selectedItem = ((LongListSelector)sender).SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            var url = ((FriendViewModel)selectedItem).Url;

            var webBrowserTask = new WebBrowserTask
            {
                Uri = new Uri(url, UriKind.Absolute)
            };
            webBrowserTask.Show();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            App.ViewModel.LoadData();
        }
    }
}