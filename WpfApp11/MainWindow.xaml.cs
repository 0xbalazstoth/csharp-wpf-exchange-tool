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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Leaf.xNet;

namespace WpfApp11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string selectedComboBoxOneCountry;
        public static string selectedComboBoxTwoCountry;
        public static double inputValue;
        public static string swappedOneCountry;
        public static string swappedTwoCountry;
        public static bool btnSwapClicked { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            countryCodes.Codes();

            for (int i = 0; i < countryCodes.datas.Count; i++)
            {
                comboBoxCountryOne.Items.Add(countryCodes.datas[i].CountryCode);
                comboBoxCountryTwo.Items.Add(countryCodes.datas[i].CountryCode);
            }
        }
        private void windowBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Environment.Exit(1);
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void comboBoxCountryOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedComboBoxOneCountry += comboBoxCountryOne.SelectedValue;
        }

        private void comboBoxCountryTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedComboBoxTwoCountry += comboBoxCountryTwo.SelectedValue;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                inputValue = Convert.ToDouble(txtInput.Text);

                if (btnSwapClicked == true)
                {
                    swappedOneCountry += selectedComboBoxOneCountry.Substring(0, 3);
                    swappedTwoCountry += selectedComboBoxTwoCountry.Substring(0, 3);

                    scrapeCodes.ScrapingCodes(swappedTwoCountry, swappedOneCountry, inputValue);
                }
                else if (btnSwapClicked == false)
                    scrapeCodes.ScrapingCodes(selectedComboBoxOneCountry, selectedComboBoxTwoCountry, inputValue);

                MessageBox msg = new MessageBox();
                msg.Show();
            }
            catch (Exception)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox msg = new MessageBox();
                    msg.Visibility = Visibility.Visible;
                    msg.convertedResult.Content = Messages._InputError;
                    msg.Show();
                });
            }
        }

        private void windowbarIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string valOne = comboBoxCountryOne.SelectedItem.ToString();
                string valTwo = comboBoxCountryTwo.SelectedItem.ToString();

                comboBoxCountryOne.SelectedValue = valTwo;
                comboBoxCountryTwo.SelectedValue = valOne;

                btnSwapClicked = true;
            }
            catch (Exception)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox msg = new MessageBox();
                    msg.Visibility = Visibility.Visible;
                    msg.convertedResult.Content = Messages._ErrorTryAgain;
                    msg.Show();
                });
            }
        }

        private void toggleMode_Checked(object sender, RoutedEventArgs e)
        {
            //<DropShadowEffect BlurRadius="30" RenderingBias="Quality" ShadowDepth="10" Color="#FFECECEC"></DropShadowEffect> rgba(0, 0, 0, 0.16)

            windowBar.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2f3640"));

            mainGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2f3640"));

            txtInput.Foreground = Brushes.White;

            comboBoxCountryOne.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3E4653"));
            comboBoxCountryOne.BorderBrush = null;
            comboBoxCountryOne.Foreground = Brushes.White;

            comboBoxCountryTwo.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3E4653"));
            comboBoxCountryTwo.BorderBrush = null;
            comboBoxCountryTwo.Foreground = Brushes.White;

            btnConvert.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3E4653"));
            btnConvert.BorderBrush = null;
            btnConvert.Foreground = Brushes.White;

            DropShadowEffect dropShadow = new DropShadowEffect();
            Color shadowColor = new Color();
            shadowColor.A = 255;
            shadowColor.B = 50;
            shadowColor.G = 50;
            shadowColor.R = 50;
            dropShadow.Color = shadowColor;
            dropShadow.Direction = 315;
            dropShadow.ShadowDepth = 10;
            dropShadow.BlurRadius = 30;
            dropShadow.Opacity = 0.2;
            windowBar.Effect = dropShadow;
            comboBoxCountryOne.Effect = dropShadow;
            comboBoxCountryTwo.Effect = dropShadow;
            btnConvert.Effect = dropShadow;
            designFooter.Source = new BitmapImage(new Uri(@"C:\Users\rpgix\source\repos\WpfApp11\WpfApp11\Assets\darkShapes.png"));
        }

        private void toggleMode_Unchecked(object sender, RoutedEventArgs e)
        {
            windowBar.Fill = Brushes.White;

            mainGrid.Background = Brushes.White;

            txtInput.Foreground = Brushes.Black;

            comboBoxCountryOne.Background = Brushes.Gainsboro;
            comboBoxCountryOne.BorderBrush = null;
            comboBoxCountryOne.Foreground = Brushes.Black;

            comboBoxCountryTwo.Background = Brushes.Gainsboro;
            comboBoxCountryTwo.BorderBrush = null;
            comboBoxCountryTwo.Foreground = Brushes.Black;

            btnConvert.Background = Brushes.Gainsboro;
            btnConvert.BorderBrush = null;
            btnConvert.Foreground = Brushes.Black;

            DropShadowEffect dropShadow = new DropShadowEffect();
            Color shadowColor = new Color();
            shadowColor.A = 255;
            shadowColor.B = 50;
            shadowColor.G = 50;
            shadowColor.R = 50;
            dropShadow.Color = shadowColor;
            dropShadow.Direction = 315;
            dropShadow.ShadowDepth = 10;
            dropShadow.BlurRadius = 30;
            dropShadow.Opacity = 0.2;
            windowBar.Effect = dropShadow;
            comboBoxCountryOne.Effect = dropShadow;
            comboBoxCountryTwo.Effect = dropShadow;
            btnConvert.Effect = dropShadow;
            designFooter.Source = new BitmapImage(new Uri(@"C:\Users\rpgix\source\repos\WpfApp11\WpfApp11\Assets\Shapes.png"));
        }
    }
}
