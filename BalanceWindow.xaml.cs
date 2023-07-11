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

namespace Praktika_Lavrentev_Abdrahmanov
{
    /// <summary>
    /// Логика взаимодействия для BalanceWindow.xaml
    /// </summary>
    public partial class BalanceWindow : Window
    {
        private bool windowCloseRequest;

        public BalanceWindow()
        {
            InitializeComponent();
            Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rangeMessage()
        {
            MessageBox.Show("Некорректный ввод данных. Было введено не число от 0 до 100000. Попробуйте ещё раз.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textField.Text == "")
            {
                MessageBox.Show("Некорректный ввод данных. Поле ввода текста пустое. Попробуйте ещё раз.");
            }
            else
            {
                try
                {
                    int balance = int.Parse(textField.Text);
                    if (balance >= 0 & balance <= 100000)
                    {
                        HelpMethods.SetBalance(balance);
                        Close();
                    }
                    else
                    {
                        rangeMessage();
                    }
                }
                catch (Exception ex)
                {
                    rangeMessage();
                }
            }
        }
    }
}
