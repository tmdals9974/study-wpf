using sample_wpf.Models;
using sample_wpf.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.usersView = new Users(mainWindow);
            this.userDetailView = new UserDetail(mainWindow);
            this.userCurrentView = this.usersView;
        }

        private MainWindow mainWindow;

        private UserControl userCurrentView;
        public UserControl UserCurrentView
        {
            get { return userCurrentView; }
            set {
                userCurrentView = value;
                OnPropertyChanged("userCurrentView");
            }
        }

        private Users usersView;
        public Users UsersView
        {
            get { return usersView; }
        }

        private UserDetail userDetailView;
        public UserDetail UserDetailView
        {
            get { return userDetailView; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
