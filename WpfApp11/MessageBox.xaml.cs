using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();

            if (scrapeCodes.countErrors >= 1)
            {
                convertedResult.Content = Messages._ErrorTryAgain;
            }
            else if (scrapeCodes.countErrors < 1)
            {
                if (MainWindow.btnSwapClicked == true)
                {
                    convertedResult.Content = $"{MainWindow.inputValue} {MainWindow.swappedTwoCountry} ~ {scrapeCodes.convertedValue} {MainWindow.swappedOneCountry}";
                }
                else if(MainWindow.btnSwapClicked == false)
                    convertedResult.Content = $"{MainWindow.inputValue} {MainWindow.selectedComboBoxOneCountry} ~ {scrapeCodes.convertedValue} {MainWindow.selectedComboBoxTwoCountry}";
            }
        }

        private void msgWindowBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMsgMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMsgClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Environment.Exit(1);
        }

        private void btnMsgExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Environment.Exit(1);
        }

        private void btnMsgAgain_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();
            });
        }
    }
}
