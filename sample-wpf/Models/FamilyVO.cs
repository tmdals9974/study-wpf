using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    class FamilyVO : INotifyPropertyChanged
    { //유공자복합사항 테이블 (sqlite_DO)					

        #region Fields
        string call_seq;
        string pin_id;
        string veterans_no;
        string subj_kbj_cd;
        string subj_kbj_nm;
        string cmy;
        string cauth;
        string rec_nm;
        string pct01;
        string pct02;
        string pct03;
        string reg_dt;
        string wond_class_cd;
        string reg_display_dt;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string VETERANS_NO { get { return veterans_no; } set { veterans_no = value; OnPropertyChanged("veterans_no"); } }
        public string SUBJ_KBJ_CD { get { return subj_kbj_cd; } set { subj_kbj_cd = value; OnPropertyChanged("subj_kbj_cd"); } }
        public string SUBJ_KBJ_NM { get { return subj_kbj_nm; } set { subj_kbj_nm = value; OnPropertyChanged("subj_kbj_nm"); } }
        public string CMY { get { return cmy; } set { cmy = value; OnPropertyChanged("cmy"); } }
        public string CAUTH { get { return cauth; } set { cauth = value; OnPropertyChanged("cauth"); } }
        public string REC_NM { get { return rec_nm; } set { rec_nm = value; OnPropertyChanged("rec_nm"); } }
        public string PCT01 { get { return pct01; } set { pct01 = value; OnPropertyChanged("pct01"); } }
        public string PCT02 { get { return pct02; } set { pct02 = value; OnPropertyChanged("pct02"); } }
        public string PCT03 { get { return pct03; } set { pct03 = value; OnPropertyChanged("pct03"); } }
        public string REG_DT { get { return reg_dt; } set { reg_dt = value; OnPropertyChanged("reg_dt"); } }
        public string WOND_CLASS_CD { get { return wond_class_cd; } set { wond_class_cd = value; OnPropertyChanged("wond_class_cd"); } }
        public string REG_DISPLAY_DT { get { return reg_display_dt; } set { reg_display_dt = value; OnPropertyChanged("reg_display_dt"); } }
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
