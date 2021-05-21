using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using sample_wpf.ViewModels;
using sample_wpf.Models;
using sample_wpf.Alert;
using sample_wpf.Config;
using Newtonsoft.Json.Linq;
using System.IO;

namespace sample_wpf
{
    /// <summary>
    /// LoginPopupWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginPopupWindow : Window
    {
        MainWindow parentWindow;
        public LoginPopupWindow(MainWindow parentWindow)
        {
            this.parentWindow = parentWindow;
            InitializeComponent();
        }

        #region TitleBar Events
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TitleBarButton_Close_OnClick(object sender, RoutedEventArgs e)
        {
            parentWindow.Close();
            this.Close();
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

        #region Events
        /// <summary>
        /// 로그인 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Login_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                new CustomAlert("아이디를 입력해주세요.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                emailTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                new CustomAlert("비밀번호를 입력해주세요.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                passwordBox.Focus();
                return;
            }

            //GetCertList();

            JObject result = sample_dll.Class1.Login(emailTextBox.Text, passwordBox.Password);
            JToken token;

            if (result.TryGetValue("error", out token) && !string.IsNullOrWhiteSpace(token.ToString()))
            {
                new CustomAlert("로그인에 실패하였습니다.\r\n" + result["error"].ToString(), MessageType.Warning, MessageButtons.Ok).ShowDialog();
            }
            else
            {
                if (result.TryGetValue("code", out token) && token.ToString() == "0")
                {
                    bool? Result = new CustomAlert("로그인에 성공하였습니다.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                    if (Result.Value)
                    {
                        //IniFile ini = new IniFile();
                        //ini["user"]["id"] = emailTextBox.Text;
                        //ini["user"]["pw"] = passwordBox.Password;
                        //ini.Save(Properties.Resources.iniPath);
                        parentWindow.Login();
                        parentWindow.Show();
                        this.Close();
                    }
                }
                if (result.TryGetValue("code", out token) && token.ToString() == "-1")
                {
                    new CustomAlert("로그인에 실패하였습니다.", MessageType.Warning, MessageButtons.Ok).ShowDialog();
                }
            }
        }

        /// <summary>
        /// 비밀번호에서 엔터 입력 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Login_OnClick(sender, null);
            }
        }
        #endregion

        #region 공인인증서 관련 코드
        List<string> certList = new List<string>();

        private void GetCertList()
        {
            appdataNPKI(); 
            programNPKI(); 
            ProgramX86NPKI();
            certList.ForEach(cert => Console.WriteLine(cert));
        }

        private void appdataNPKI()
        {
            string path = string.Empty;
            string strsub = string.Empty;
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString();
            path += "\\AppData\\LocalLow\\NPKI\\yessign\\User\\";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists == true)
            {
                foreach (var item in dir.GetDirectories())
                {

                    certList.Add(item.Name.ToString());
                }
            }
        }

        private void programNPKI()
        {
            string strsub = string.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            path = path.Substring(0, 3);
            path = path + "Program Files";
            path += "\\NPKI\\yessign\\User\\";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists == true)
            {
                foreach (var item in dir.GetDirectories())
                {
                    certList.Add(item.Name.ToString());
                }
            }

        }

        private void ProgramX86NPKI()
        {
            string path = string.Empty;
            string strsub = string.Empty;
            path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).ToString();
            path += "\\NPKI\\yessign\\User\\";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists == true)
            {
                foreach (var item in dir.GetDirectories())
                {
                    certList.Add(item.Name.ToString());
                }
            }
        }

        #endregion
    }
}
