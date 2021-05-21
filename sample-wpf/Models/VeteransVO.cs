using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_wpf.Models
{
    class VeteransVO : INotifyPropertyChanged
    { //진료대상자 테이블 (sqlite_A0)

        #region Fields
        string call_seq;
        string pin_id;
        string ord;
        string family_nm;
        string family_lno;
        string rec_nm;
        string age;
        string authori_yn;
        string subj_nm;
        string prvn_brn_ofc_nm;
        string pr_yn;
        string reg_dt;
        string veterans_zipcd;
        string veterans_addr1;
        string veterans_addr2;
        string war_wnd_dth_ssn_nm;
        string pct;
        string pct1;
        string pct2;
        string pct3;
        string pv_stop_yn;
        string right_laps_yn;
        string defoli_no;
        string pv_stop_rsn_nm;
        string right_laps_rsn_nm;
        string defoli_nm;
        string veterans_no;
        string veterans_tel;
        string veterans_hp;
        string chng_res_nm;
        string rec_cd;
        string pv_stop_dt;
        string right_laps_dt;
        string right_laps_proc_dt;
        string wond_class_cd;
        string rec_dt;
        string reg_proc_dt;
        string reg_display_dt;
        string reg_dt_new;
        string old_new_gubn;
        string subj_kbj_cd;
        string call_dt;
        bool first;
        #endregion

        #region Properties
        public string CALL_SEQ { get { return call_seq; } set { call_seq = value; OnPropertyChanged("call_seq"); } }
        public string PIN_ID { get { return pin_id; } set { pin_id = value; OnPropertyChanged("pin_id"); } }
        public string ORD { get { return ord; } set { ord = value; OnPropertyChanged("ord"); } }
        public string FAMILY_NM { get { return family_nm; } set { family_nm = value; OnPropertyChanged("family_nm"); } }
        public string FAMILY_LNO { get { return family_lno; } set { family_lno = value; OnPropertyChanged("family_lno"); } }
        public string REC_NM { get { return rec_nm; } set { rec_nm = value; OnPropertyChanged("rec_nm"); } }
        public string AGE { get { return age; } set { age = value; OnPropertyChanged("age"); } }
        public string AUTHORI_YN { get { return authori_yn; } set { authori_yn = value; OnPropertyChanged("authori_yn"); } }
        public string SUBJ_NM { get { return subj_nm; } set { subj_nm = value; OnPropertyChanged("subj_nm"); } }
        public string PRVN_BRN_OFC_NM { get { return prvn_brn_ofc_nm; } set { prvn_brn_ofc_nm = value; OnPropertyChanged("prvn_brn_ofc_nm"); } }
        public string PR_YN { get { return pr_yn; } set { pr_yn = value; OnPropertyChanged("pr_yn"); } }
        public string REG_DT { get { return reg_dt; } set { reg_dt = value; OnPropertyChanged("reg_dt"); } }
        public string VETERANS_ZIPCD { get { return veterans_zipcd; } set { veterans_zipcd = value; OnPropertyChanged("veterans_zipcd"); } }
        public string VETERANS_ADDR1 { get { return veterans_addr1; } set { veterans_addr1 = value; OnPropertyChanged("veterans_addr1"); } }
        public string VETERANS_ADDR2 { get { return veterans_addr2; } set { veterans_addr2 = value; OnPropertyChanged("veterans_addr2"); } }
        public string WAR_WND_DTH_SSN_NM { get { return war_wnd_dth_ssn_nm; } set { war_wnd_dth_ssn_nm = value; OnPropertyChanged("war_wnd_dth_ssn_nm"); } }
        public string PCT { get { return pct; } set { pct = value; OnPropertyChanged("pct"); } }
        public string PCT1 { get { return pct1; } set { pct1 = value; OnPropertyChanged("pct1"); } }
        public string PCT2 { get { return pct2; } set { pct2 = value; OnPropertyChanged("pct2"); } }
        public string PCT3 { get { return pct3; } set { pct3 = value; OnPropertyChanged("pct3"); } }
        public string PV_STOP_YN { get { return pv_stop_yn; } set { pv_stop_yn = value; OnPropertyChanged("pv_stop_yn"); } }
        public string RIGHT_LAPS_YN { get { return right_laps_yn; } set { right_laps_yn = value; OnPropertyChanged("right_laps_yn"); } }
        public string DEFOLI_NO { get { return defoli_no; } set { defoli_no = value; OnPropertyChanged("defoli_no"); } }
        public string PV_STOP_RSN_NM { get { return pv_stop_rsn_nm; } set { pv_stop_rsn_nm = value; OnPropertyChanged("pv_stop_rsn_nm"); } }
        public string RIGHT_LAPS_RSN_NM { get { return right_laps_rsn_nm; } set { right_laps_rsn_nm = value; OnPropertyChanged("right_laps_rsn_nm"); } }
        public string DEFOLI_NM { get { return defoli_nm; } set { defoli_nm = value; OnPropertyChanged("defoli_nm"); } }
        public string VETERANS_NO { get { return veterans_no; } set { veterans_no = value; OnPropertyChanged("veterans_no"); } }
        public string VETERANS_TEL { get { return veterans_tel; } set { veterans_tel = value; OnPropertyChanged("veterans_tel"); } }
        public string VETERANS_HP { get { return veterans_hp; } set { veterans_hp = value; OnPropertyChanged("veterans_hp"); } }
        public string CHNG_RES_NM { get { return chng_res_nm; } set { chng_res_nm = value; OnPropertyChanged("chng_res_nm"); } }
        public string REC_CD { get { return rec_cd; } set { rec_cd = value; OnPropertyChanged("rec_cd"); } }
        public string PV_STOP_DT { get { return pv_stop_dt; } set { pv_stop_dt = value; OnPropertyChanged("pv_stop_dt"); } }
        public string RIGHT_LAPS_DT { get { return right_laps_dt; } set { right_laps_dt = value; OnPropertyChanged("right_laps_dt"); } }
        public string RIGHT_LAPS_PROC_DT { get { return right_laps_proc_dt; } set { right_laps_proc_dt = value; OnPropertyChanged("right_laps_proc_dt"); } }
        public string WOND_CLASS_CD { get { return wond_class_cd; } set { wond_class_cd = value; OnPropertyChanged("wond_class_cd"); } }
        public string REC_DT { get { return rec_dt; } set { rec_dt = value; OnPropertyChanged("rec_dt"); } }
        public string REG_PROC_DT { get { return reg_proc_dt; } set { reg_proc_dt = value; OnPropertyChanged("reg_proc_dt"); } }
        public string REG_DISPLAY_DT { get { return reg_display_dt; } set { reg_display_dt = value; OnPropertyChanged("reg_display_dt"); } }
        public string REG_DT_NEW { get { return reg_dt_new; } set { reg_dt_new = value; OnPropertyChanged("reg_dt_new"); } }
        public string OLD_NEW_GUBN { get { return old_new_gubn; } set { old_new_gubn = value; OnPropertyChanged("old_new_gubn"); } }
        public string SUBJ_KBJ_CD { get { return subj_kbj_cd; } set { subj_kbj_cd = value; OnPropertyChanged("subj_kbj_cd"); } }
        public string CALL_DT { get { return call_dt; } set { call_dt = value; OnPropertyChanged("call_dt"); } }
        public bool FIRST { get { return first; } set { first = value; OnPropertyChanged("first"); } }
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
