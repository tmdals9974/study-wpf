using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using Forms = System.Windows.Forms;
using sample_wpf.Config;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using sample_wpf.Models;
using sample_wpf.ViewModels;
using sample_wpf.Views;
using System.Windows.Threading;
namespace sample_wpf
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon ni = new NotifyIcon() { Icon = Properties.Resources.icon_default, Visible = true, Text = "SAMPLE_WPF" };
        bool isLogin = false;
        Forms.ContextMenu userMenu = new Forms.ContextMenu();
        Forms.ContextMenu guestMenu = new Forms.ContextMenu();
        IniFile ini = new IniFile();
        MainViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel(this);
            this.DataContext = mainViewModel;
            ini.Load(Properties.Resources.iniPath);

            //테마컬러 설정
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetPrimaryColor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF796B90"));
            theme.SetSecondaryColor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FFA3BC8E"));
            paletteHelper.SetTheme(theme);

            #region 트레이아이콘 메뉴 생성
            //isLogin = !String.IsNullOrWhiteSpace(ini["user"]["id"].GetString()) && !String.IsNullOrWhiteSpace(ini["user"]["pw"].GetString());
            
            userMenu.MenuItems.Add(CreateMenuItem(0, "로그아웃", delegate() { Logout(); }));
            userMenu.MenuItems.Add(CreateMenuItem(1, "보훈자격조회", delegate() { TabControlChangeSelectedTab("Plus"); }));
            userMenu.MenuItems.Add(CreateMenuItem(2, "보훈자격조회결과", delegate() { TabControlChangeSelectedTab("Home"); }));
            userMenu.MenuItems.Add(CreateMenuItem(3, "정보", delegate() { ShowInfo(); }));
            userMenu.MenuItems.Add(CreateMenuItem(4, "프로그램 종료", delegate() { this.Close(); }));

            guestMenu.MenuItems.Add(CreateMenuItem(0, "로그인", delegate() { Login(); }));
            guestMenu.MenuItems.Add(CreateMenuItem(1, "정보", delegate() { ShowInfo(); }));
            guestMenu.MenuItems.Add(CreateMenuItem(2, "프로그램 종료", delegate() { this.Close(); }));

            ni.DoubleClick += delegate(object senders, EventArgs args) { this.Show(); };
            ni.ContextMenu = isLogin ? userMenu : guestMenu;
            #endregion

            //로그인팝업
            if (!isLogin)
            {
                LoginPopupWindow loginPopup = new LoginPopupWindow(this);
                this.Hide();
                loginPopup.Show();
            }

            #region sqlite default setting
            using (SQLiteConnection conn = SqliteControll.GetConnection())
            {
                conn.Open();

                string sql = "CREATE TABLE IF NOT EXISTS VETERANS ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " +
                            "   ,ORD      TEXT " +
                            "   ,FAMILY_NM      TEXT " +
                            "   ,FAMILY_LNO      TEXT " +
                            "   ,REC_NM      TEXT " +
                            "   ,AGE      TEXT " +
                            "   ,AUTHORI_YN      TEXT " +
                            "   ,SUBJ_NM      TEXT " +
                            "   ,PRVN_BRN_OFC_NM      TEXT " +
                            "   ,PR_YN      TEXT " +
                            "   ,REG_DT      TEXT " +
                            "   ,VETERANS_ZIPCD      TEXT " +
                            "   ,VETERANS_ADDR1      TEXT " +
                            "   ,VETERANS_ADDR2      TEXT " +
                            "   ,WAR_WND_DTH_SSN_NM      TEXT " +
                            "   ,PCT      TEXT " +
                            "   ,PCT1      TEXT " +
                            "   ,PCT2      TEXT " +
                            "   ,PCT3      TEXT " +
                            "   ,PV_STOP_YN      TEXT " +
                            "   ,RIGHT_LAPS_YN      TEXT " +
                            "   ,DEFOLI_NO      TEXT " +
                            "   ,PV_STOP_RSN_NM      TEXT " +
                            "   ,RIGHT_LAPS_RSN_NM      TEXT " +
                            "   ,DEFOLI_NM      TEXT " +
                            "   ,VETERANS_NO      TEXT " +
                            "   ,VETERANS_TEL      TEXT " +
                            "   ,VETERANS_HP      TEXT " +
                            "   ,CHNG_RES_NM      TEXT " +
                            "   ,REC_CD      TEXT " +
                            "   ,PV_STOP_DT      TEXT " +
                            "   ,RIGHT_LAPS_DT      TEXT " +
                            "   ,RIGHT_LAPS_PROC_DT      TEXT " +
                            "   ,WOND_CLASS_CD      TEXT " +
                            "   ,REC_DT      TEXT " +
                            "   ,REG_PROC_DT      TEXT " +
                            "   ,REG_DISPLAY_DT      TEXT " +
                            "   ,REG_DT_NEW      TEXT " +
                            "   ,OLD_NEW_GUBN      TEXT " +
                            "   ,SUBJ_KBJ_CD      TEXT " +
                            "   ,CALL_DT      TEXT " +
                            "   ,FIRST      BOOLEAN DEFAULT FALSE NOT NULL" +
                            "); " +
                            " " +
                            "CREATE TABLE IF NOT EXISTS WOND ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " + 
                            "   ,NUM      TEXT " +
                            "   ,SUBJ_KBJ_NM      TEXT " +
                            "   ,WOND_CLASS_DECSN_DT      TEXT " +
                            "   ,CLASS_NM      TEXT " +
                            "   ,DIV_NM      TEXT " +
                            "   ,WOND_CLASS_CD      TEXT " +
                            "   ,MULTI_WOND_DIV_CD      TEXT " +
                            "); " +
                            " " +
                            "CREATE TABLE IF NOT EXISTS WOUND ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " + 
                            "   ,NUM      TEXT " +
                            "   ,HEALTH_TP      TEXT " +
                            "   ,MIL_NM      TEXT " +
                            "   ,RECOG_WOND_PLC      TEXT " +
                            "   ,ORIG_DISES_NM      TEXT " +
                            "   ,PROC_RSLT      TEXT " +
                            "   ,DECSN_DT      TEXT " +
                            "   ,WAR_WND_DTH_SSN_NM      TEXT " +
                            "   ,AGENCY_LV_NM      TEXT " +
                            "   ,RECEPTION_DT      TEXT " +
                            "); " +
                            " " +
                            "CREATE TABLE IF NOT EXISTS FAMILY ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " + 
                            "   ,VETERANS_NO      TEXT " +
                            "   ,SUBJ_KBJ_CD      TEXT " +
                            "   ,SUBJ_KBJ_NM      TEXT " +
                            "   ,CMY      TEXT " +
                            "   ,CAUTH      TEXT " +
                            "   ,REC_NM      TEXT " +
                            "   ,PCT01      TEXT " +
                            "   ,PCT02      TEXT " +
                            "   ,PCT03      TEXT " +
                            "   ,REG_DT      TEXT " +
                            "   ,WOND_CLASS_CD      TEXT " +
                            "   ,REG_DISPLAY_DT      TEXT " +
                            "); " +
                            " " +
                            "CREATE TABLE IF NOT EXISTS WOUND_ETC ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " + 
                            "   ,MIL_TYPE_ONS_POS_NM      TEXT " +
                            "   ,RECOG_WOND_PLC      TEXT " +
                            "   ,MDCL_CHK_DT      TEXT " +
                            "   ,MDCL_CHK_ITEM_NM      TEXT " +
                            "   ,PROC_RSLT      TEXT " +
                            "   ,ORIG_DISES_NM      TEXT " +
                            "   ,DECSN_DT      TEXT " +
                            "   ,OGNIZ_NM      TEXT " +
                            "   ,RECEPTION_DT      TEXT " +
                            "   ,LAST_PROC_RSLT      TEXT " +
                            "); " +
                            " " +
                            "CREATE TABLE IF NOT EXISTS WAR ( " +
                            "    CALL_SEQ      TEXT PRIMARY KEY" +
                            "   ,PIN_ID      TEXT " + 
                            "   ,SUBJ_KBJ_CD      TEXT " +
                            "   ,VETERANS_NO      TEXT " +
                            "); ";

                using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
            #endregion
        }

        #region ContextMenu Settings & Events
        public void Login()
        {
            isLogin = true;
            ni.ContextMenu = userMenu;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromHours(24);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isLogin) Logout();
            (sender as DispatcherTimer).Stop();
        }

        public void Logout()
        {
            isLogin = false;
            ni.ContextMenu = guestMenu;
            this.Hide();
            LoginPopupWindow loginPopup = new LoginPopupWindow(this);
            loginPopup.Show();
        }

        private Forms.MenuItem CreateMenuItem(int index, String text, Action act)
        {
            Forms.MenuItem item = new Forms.MenuItem() { Index = index, Text = text };
            item.Click += delegate(object click, EventArgs eClick) { act(); };
            return item;
        }

        private void ShowInfo()
        {

        }
        #endregion

        #region TitleBar Events
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
                this.Top = 0;
            }
            this.DragMove();
        }

        private void TitleBarButton_Close_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TitleBarButton_Minimize_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void TitleBarButton_Maximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }
        #endregion

        #region View Controllers

        public void ChangeUserCurrentView()
        {
            if (mainViewModel.UserCurrentView.GetType().Equals(typeof(Users))) {
                mainViewModel.UserCurrentView =  mainViewModel.UserDetailView;
            }
            else {
                mainViewModel.UserCurrentView =  mainViewModel.UsersView;
            }
        }

        public void SetUserDetail(UserVO u)
        {
            mainViewModel.UserDetailView.SetUser(u);
        }

        public void TabControlChangeSelectedTab(string value)
        {
            int index = -1;
            switch (value) {
                case "Home":
                    index = 0;
                    break;
                case "Plus":
                    index = 1;
                    break;
                case "Config":
                    index = 2;
                    break;
                default:
                    index = -1;
                    break;
            }
            if (index != -1)
            {
                tabControl.SelectedIndex = index;
                if (!this.IsActive) this.Show();
            }
        }

        #endregion

        #region Events
        private void Button_Add_OnClick(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
