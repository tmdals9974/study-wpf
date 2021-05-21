using sample_wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_wpf.ViewModels
{
    public class UserDetailViewModel : INotifyPropertyChanged
    {

        private UserVO user = new UserVO();

        public UserVO User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("user");
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
