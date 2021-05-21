using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    class WarVO : INotifyPropertyChanged
    { //참전/제대정보 테이블 (sqlite_FO)

        #region Fields
        string call_seq;
        string pin_id;
        string subj_kbj_cd;
        string veterans_no;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string SUBJ_KBJ_CD { get { return subj_kbj_cd; } set { subj_kbj_cd = value; OnPropertyChanged("subj_kbj_cd"); } }
        public string VETERANS_NO { get { return veterans_no; } set { veterans_no = value; OnPropertyChanged("veterans_no"); } }
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
