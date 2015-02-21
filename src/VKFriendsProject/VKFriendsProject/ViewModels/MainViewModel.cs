using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using VKFriendsProject.Domain.Models;
using VKFriendsProject.Domain.Services;
using VKFriendsProject.Resources;

namespace VKFriendsProject.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IVkService vkService;
        public MainViewModel()
        {
            this.Items = new ObservableCollection<FriendViewModel>();
            vkService = new VkService();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<FriendViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            vkService.GetFriendsInfo(18337037, PopulateData, HandleError);
        }
        private void PopulateData(IEnumerable<FriendViewModel> friends)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                foreach (var friend in friends)
                {
                    Items.Add(friend);
                }
                IsDataLoaded = true;
            });
        }

        private void HandleError(VkErrorResult error)
        {
            Debug.WriteLine("Error code:{0}", error.ErrorCode);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}