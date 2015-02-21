using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VKFriendsProject.Domain.Models
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        private string fullName;
        private string image;
        private bool online;
        private string url;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FullName
        {
            get { return fullName; }
            set
            {
                if (value != fullName)
                {
                    fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                if (value != image)
                {
                    image = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Online
        {
            get { return online; }
            set
            {
                if (value != online)
                {
                    online = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Url
        {
            get { return url; }
            set
            {
                if (value != url)
                {
                    url = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}