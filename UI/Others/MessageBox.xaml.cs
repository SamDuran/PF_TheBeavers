using System.Windows;
using System.Windows.Media;

namespace UI
{
    public partial class MessageBoxCustom : Window
    {
        public MessageBoxCustom()
        {
            InitializeComponent();
        }
        public MessageBoxCustom(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    txtTitle.Text = "Info";
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Confirmation";
                    break;
                case MessageType.Success:
                    {
                        txtTitle.Text = "Success";
                    }
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Warning";
                    break;
                case MessageType.Error:
                    {
                        txtTitle.Text = "Error";
                    }
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        public void ShowDialog(string Message, MessageType Type, MessageButtons Buttons)
        {
            setMessage(Message);
            setMessageType(Type);
            setButtons(Buttons);
            this.ShowDialog();
        }
        private void setMessageType(MessageType Type)
        {

            switch (Type)
            {
                case MessageType.Info:
                    txtTitle.Text = "Información";
                    cardHeader.Background = new SolidColorBrush(Color.FromRgb(72, 191, 193));
                    break;
                case MessageType.Confirmation:
                    txtTitle.Text = "Confirmación";
                    cardHeader.Background = new SolidColorBrush(Color.FromRgb(63, 136, 248));
                    break;
                case MessageType.Success:
                    txtTitle.Text = "Exito";
                    cardHeader.Background = new SolidColorBrush(Color.FromRgb(72, 193, 124));
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Advertencia";
                    cardHeader.Background = new SolidColorBrush(Color.FromRgb(239, 239, 0));
                    break;
                case MessageType.Error:
                    txtTitle.Text = "Error";
                    cardHeader.Background = new SolidColorBrush(Color.FromRgb(248, 63, 63));
                    break;
            }
            btnClose.BorderBrush = btnClose.Foreground = cardHeader.Background;
        }
        private void setButtons(MessageButtons Buttons)
        {
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        private void setMessage(string Message)
        {
            txtMessage.Text = Message;
            Extentor(Message);
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
        private void Extentor(string message)
        {
            int JumpCounter = 0;
            foreach (char letter in message)
            {
                if (letter == '\n')
                    JumpCounter++;
            }
            this.Height += (JumpCounter * 20);
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

}
