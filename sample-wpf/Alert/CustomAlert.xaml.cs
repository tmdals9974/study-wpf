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

namespace sample_wpf.Alert
{
    /// <summary>
    /// Alert.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CustomAlert : Window
    {
        Action enterAction;
        public CustomAlert()
        {
            InitializeComponent();
        }

        public CustomAlert(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {
                case MessageType.Info:
                    ico.Kind = MaterialDesignThemes.Wpf.PackIconKind.InformationOutline;
                    txtTitle.Text = "Info";
                    break;
                case MessageType.Confirmation:
                    ico.Kind = MaterialDesignThemes.Wpf.PackIconKind.InformationOutline;
                    txtTitle.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    ico.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircleOutline;
                    txtTitle.Text = "Success";
                    break;
                case MessageType.Warning:
                    ico.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertCircleOutline;
                    txtTitle.Text = "Warning";
                    break;
                case MessageType.Error:
                    ico.Kind = MaterialDesignThemes.Wpf.PackIconKind.AlertOutline;
                    txtTitle.Text = "Error";
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    enterAction = delegate() { btnCancel_Click(null, null); };
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    enterAction = delegate() { btnNo_Click(null, null); };
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    enterAction = delegate() { btnOk_Click(null, null); };
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                enterAction();
            }
        }
    }

}

public enum MessageType
{
    Info,
    Confirmation,
    Success,
    Warning,
    Error,
}
public enum MessageButtons
{
    OkCancel,
    YesNo,
    Ok,
}

