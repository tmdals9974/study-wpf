using sample_wpf.Models;
using sample_wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sample_wpf.Views
{
    /// <summary>
    /// Users.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Users : UserControl
    {
        UsersViewModel userViewModel = new UsersViewModel();
        MainWindow mainWindow;

        public Users(MainWindow mainWindow)
        {
            InitializeComponent();
            this.DataContext = userViewModel;
            this.mainWindow = mainWindow;
        }

        #region Events
        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent, new MouseButtonEventHandler(dataGrid_Row_DoubleClick)));
            dataGrid.RowStyle = rowStyle;
        }

        private void dataGrid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            mainWindow.SetUserDetail((UserVO)row.Item);
            mainWindow.ChangeUserCurrentView();
            //UserVO us = userViewModel.Users.Where(u => u.ResidentNum == user.ResidentNum).FirstOrDefault();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.TabControlChangeSelectedTab("Plus");
        }

        private void TextBox_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Search_Click(sender, null);
            }
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);

            if (string.IsNullOrEmpty(TextBoxSearchPinID.Text) && string.IsNullOrEmpty(TextBoxSearchVeteransNum.Text) && string.IsNullOrEmpty(TextBoxSearchName.Text))
            {
                cv.Filter = null;
            }
            else
            {
                cv.Filter = new Predicate<object>(ComplexFilter);
            }
        }
        #endregion

        #region Methods
        private bool ComplexFilter(object obj)
        {
            UserVO user = obj as UserVO;
            bool b = true;

            string pinId = TextBoxSearchPinID.Text;
            if (!string.IsNullOrEmpty(pinId))
            {
                b = b && user.ResidentNum.Contains(pinId);
            }

            string veteransNum = TextBoxSearchVeteransNum.Text;
            if (b && !string.IsNullOrEmpty(veteransNum))
            {
                b = b && user.VeteranNum.Contains(veteransNum);
            }

            string name = TextBoxSearchName.Text;
            if (b && !string.IsNullOrEmpty(name))
            {
                b = b && user.Name.Contains(name);
            }

            return b;
        }
        #endregion
    }
}
