using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    class WoundEtcVO : INotifyPropertyChanged
    { //등외판정 테이블 (sqlite_EO)

        #region Fields
        string call_seq;
        string pin_id;
        string mil_type_ons_pos_nm;
        string recog_wond_plc;
        string mdcl_chk_dt;
        string mdcl_chk_item_nm;
        string proc_rslt;
        string orig_dises_nm;
        string decsn_dt;
        string ogniz_nm;
        string reception_dt;
        string last_proc_rslt;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string MIL_TYPE_ONS_POS_NM { get { return mil_type_ons_pos_nm; } set { mil_type_ons_pos_nm = value; OnPropertyChanged("mil_type_ons_pos_nm"); } }
        public string RECOG_WOND_PLC { get { return recog_wond_plc; } set { recog_wond_plc = value; OnPropertyChanged("recog_wond_plc"); } }
        public string MDCL_CHK_DT { get { return mdcl_chk_dt; } set { mdcl_chk_dt = value; OnPropertyChanged("mdcl_chk_dt"); } }
        public string MDCL_CHK_ITEM_NM { get { return mdcl_chk_item_nm; } set { mdcl_chk_item_nm = value; OnPropertyChanged("mdcl_chk_item_nm"); } }
        public string PROC_RSLT { get { return proc_rslt; } set { proc_rslt = value; OnPropertyChanged("proc_rslt"); } }
        public string ORIG_DISES_NM { get { return orig_dises_nm; } set { orig_dises_nm = value; OnPropertyChanged("orig_dises_nm"); } }
        public string DECSN_DT { get { return decsn_dt; } set { decsn_dt = value; OnPropertyChanged("decsn_dt"); } }
        public string OGNIZ_NM { get { return ogniz_nm; } set { ogniz_nm = value; OnPropertyChanged("ogniz_nm"); } }
        public string RECEPTION_DT { get { return reception_dt; } set { reception_dt = value; OnPropertyChanged("reception_dt"); } }
        public string LAST_PROC_RSLT { get { return last_proc_rslt; } set { last_proc_rslt = value; OnPropertyChanged("last_proc_rslt"); } }
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
