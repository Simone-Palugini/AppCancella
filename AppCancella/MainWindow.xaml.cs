using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AppCancella
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool stop = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_start1_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => DoWork(100, 1000, lbl_count1));
        }

        private void Btn_start2_Click(object sender, RoutedEventArgs e)
        {
            int max = Convert.ToInt32(txt_max1.Text);
            Task.Factory.StartNew(() => DoWork(max, 1000, lbl_count2));
        }

        private void Btn_start3_Click(object sender, RoutedEventArgs e)
        {
            int max = Convert.ToInt32(txt_max2.Text);
            int delay = Convert.ToInt32(txt_delay.Text);
            Task.Factory.StartNew(() => DoWork(max, delay, lbl_count3));
        }


        private void DoWork(int max, int delay, Label lbl)
        {
            stop = false;
            for (int i = 0; i <= max; i++)
            {
                Dispatcher.Invoke(() => UpdateUI(i, lbl));
                Thread.Sleep(delay);

                if (stop)
                    break;
            }           
        }

        private void UpdateUI(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }

        private void Btn_stop_Click(object sender, RoutedEventArgs e)
        {
            stop = true;
        }

    }
}
