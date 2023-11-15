using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button button1 = new Button();
            this.tb.PreviewTextInput += new TextCompositionEventHandler(tb_textInput);
            Im1.Source = new BitmapImage(new Uri("/Resourse/1.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
        }
       
        Elevator elevator;
        async void FirstMetod(object sender, RoutedEventArgs e)
        {
            Im1.Source = new BitmapImage(new Uri("/Resourse/2.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
            await Task.Delay(500);
            elevator = new Elevator();
            elevator.StateChanged += Elevator_StateChanged;
            elevator.LevelChanged += Elevator_LevelChanged;
            int level2 = int.Parse((sender as Button).Content.ToString());
            int level = int.Parse(etaz.Content.ToString());
            await elevator.GoTo(level, level2);

        }
        private void Elevator_LevelChanged(object sender, int e)
        {
            etaz.Content = elevator.Level.ToString();
        }

        private void Elevator_StateChanged(object sender, Elevator.States e)
        {
            switch (e)
            {
                case Elevator.States.EmptyClimbing:
                    Im1.Source = new BitmapImage(new Uri("/Resourse/2.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    break;
                case Elevator.States.OpenDoorsWaiting:
                    Im1.Source = new BitmapImage(new Uri("/Resourse/1.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    break;
                default:
                    break;
            }
        }
        private void tb_textInput(object sender, TextCompositionEventArgs e) //для ввода только цифр
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb.Text != "")
            {
                if (int.Parse(tb.Text) > 25 || int.Parse(tb.Text) == 0)
                {
                    MessageBox.Show("Ограничение до 25 этажей");
                    tb.Text = "";
                }
                else
                {
                    for(int i = 1; i < int.Parse(tb.Text)+1; i++)
                    {
                        Button button = new Button();
                        button.Content = i.ToString();
                        button.Click += FirstMetod;
                        ButtonsPanel.Children.Add(button);
                    }
                }
            }
            else
            {
                while (ButtonsPanel.Children.Count > 0)
                    ButtonsPanel.Children.RemoveAt(0);
            }
        }

    }
}
