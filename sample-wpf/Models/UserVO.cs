using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    public class UserVO : INotifyPropertyChanged
    {
        #region Constructor
        public UserVO() { }
        public UserVO(string name, int age, string residentNum, string veteranNum)
        {
            this.name = name;
            this.age = age;
            this.residentNum = residentNum;
            this.veteranNum = veteranNum;
        }
        #endregion

        #region Fileds
        string name;
        int age;
        string residentNum;
        string veteranNum;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("name"); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("age"); }
        }

        public string ResidentNum
        {
            get { return residentNum; }
            set { residentNum = value; OnPropertyChanged("residentNum"); }
        }

        public string VeteranNum
        {
            get { return veteranNum; }
            set { veteranNum = value; OnPropertyChanged("veteranNum"); }
        }

        public string UserInfo
        {
            get { return name + " (" + residentNum + ") 의 보훈 자격 목록"; }
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
