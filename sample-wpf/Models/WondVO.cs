using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    class WondVO : INotifyPropertyChanged
    { //상이처 테이블 (sqlite_BO)

        #region Fields
        string call_seq;
        string pin_id;
        string num;
        string subj_kbj_nm;
        string wond_class_decsn_dt;
        string class_nm;
        string div_nm;
        string wond_class_cd;
        string multi_wond_div_cd;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string NUM { get { return num; } set { num = value; OnPropertyChanged("num"); } }
        public string SUBJ_KBJ_NM { get { return subj_kbj_nm; } set { subj_kbj_nm = value; OnPropertyChanged("subj_kbj_nm"); } }
        public string WOND_CLASS_DECSN_DT { get { return wond_class_decsn_dt; } set { wond_class_decsn_dt = value; OnPropertyChanged("wond_class_decsn_dt"); } }
        public string CLASS_NM { get { return class_nm; } set { class_nm = value; OnPropertyChanged("class_nm"); } }
        public string DIV_NM { get { return div_nm; } set { div_nm = value; OnPropertyChanged("div_nm"); } }
        public string WOND_CLASS_CD { get { return wond_class_cd; } set { wond_class_cd = value; OnPropertyChanged("wond_class_cd"); } }
        public string MULTI_WOND_DIV_CD { get { return multi_wond_div_cd; } set { multi_wond_div_cd = value; OnPropertyChanged("multi_wond_div_cd"); } }
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
