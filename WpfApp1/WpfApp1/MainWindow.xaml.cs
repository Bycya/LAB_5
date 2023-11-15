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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.tb.PreviewTextInput += new TextCompositionEventHandler(tb_textInput);
            btn.IsEnabled = false;
        }
        private int sum_vn;
        private Beverage beverage;
        bool sh = false;
        bool ml = false;
        public void tb_textInput(object sender, TextCompositionEventArgs e) //для ввода только цифр
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sum_vn += int.Parse(tb.Text);
            vnsum.Content = sum_vn.ToString();
            tb.Text = "";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Btn1.IsChecked == true)
            {
                Im1.Source = new BitmapImage(new Uri("/Resources/американо.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                Nach_pol();
                beverage = new Amerikano();
            }
            if (Btn2.IsChecked == true)
            {
                Im1.Source = new BitmapImage(new Uri("/Resources/капучино.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                Nach_pol();
                beverage = new Kapuchino();
            }
            if (Btn3.IsChecked == true)
            {
                Im1.Source = new BitmapImage(new Uri("/Resources/эспрессо.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                Nach_pol();
                beverage = new Espresso();
            }
            if (Btn4.IsChecked == true)
            {
                Im1.Source = new BitmapImage(new Uri("/Resources/какао.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                Nach_pol();
                beverage = new Kakao();
            }
            Proverka();
        }
        public void Nach_pol()
        {
            sh = false;
            ml = false;
            ChB1.IsChecked = false;
            ChB2.IsChecked = false;
            Im2.Source = null;
            Im3.Source = null;
        }
        public void Proverka()
        {
            cost_lab.Content = beverage.cost().ToString();
            if (sum_vn >= beverage.cost())
            {
                btn.IsEnabled = true;
                cdacha.Content = (sum_vn-beverage.cost()).ToString();
            }
            else
                btn.IsEnabled=false;
        }

        private void ChB1_Checked(object sender, RoutedEventArgs e)
        {
            if (ChB1.IsChecked == true)
            {
                if (sh == false)
                {
                    Im2.Source= new BitmapImage(new Uri("/Resources/сахар.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    beverage = new Shuga(beverage);
                    sh= true;
                }
            }
            if (ChB2.IsChecked == true)
            {
                if (ml == false)
                {
                    Im3.Source= new BitmapImage(new Uri("/Resources/молоко.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    beverage = new Milk(beverage);
                    ml= true;
                }
            }
            Proverka();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            vnsum.Content = cdacha.Content;
            cdacha.Content = "";
            cost_lab.Content = "";
        }
    }
}
