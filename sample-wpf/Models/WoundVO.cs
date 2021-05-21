using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sample_wpf.Models
{
    class WoundVO : INotifyPropertyChanged
    { //신검정보 테이블 (sqlite_CO)

        #region Fields
        string call_seq;
        string pin_id;
        string num;
        string health_tp;
        string mil_nm;
        string recog_wond_plc;
        string orig_dises_nm;
        string proc_rslt;
        string decsn_dt;
        string war_wnd_dth_ssn_nm;
        string agency_lv_nm;
        string reception_dt;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string NUM { get { return num; } set { num = value; OnPropertyChanged("num"); } }
        public string HEALTH_TP { get { return health_tp; } set { health_tp = value; OnPropertyChanged("health_tp"); } }
        public string MIL_NM { get { return mil_nm; } set { mil_nm = value; OnPropertyChanged("mil_nm"); } }
        public string RECOG_WOND_PLC { get { return recog_wond_plc; } set { recog_wond_plc = value; OnPropertyChanged("recog_wond_plc"); } }
        public string ORIG_DISES_NM { get { return orig_dises_nm; } set { orig_dises_nm = value; OnPropertyChanged("orig_dises_nm"); } }
        public string PROC_RSLT { get { return proc_rslt; } set { proc_rslt = value; OnPropertyChanged("proc_rslt"); } }
        public string DECSN_DT { get { return decsn_dt; } set { decsn_dt = value; OnPropertyChanged("decsn_dt"); } }
        public string WAR_WND_DTH_SSN_NM { get { return war_wnd_dth_ssn_nm; } set { war_wnd_dth_ssn_nm = value; OnPropertyChanged("war_wnd_dth_ssn_nm"); } }
        public string AGENCY_LV_NM { get { return agency_lv_nm; } set { agency_lv_nm = value; OnPropertyChanged("agency_lv_nm"); } }
        public string RECEPTION_DT { get { return reception_dt; } set { reception_dt = value; OnPropertyChanged("reception_dt"); } }
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
