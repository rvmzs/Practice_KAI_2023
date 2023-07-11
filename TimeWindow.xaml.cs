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
    /// Логика взаимодействия для TimeWindow.xaml
    /// </summary>
    public partial class TimeWindow : Window
    {
        private bool windowCloseRequest;

        public TimeWindow()
        {
            InitializeComponent();
            Show();
            windowCloseRequest = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!windowCloseRequest)
            {
                MessageBox.Show("Если Вы получили карту пропуск Вам необходимо вписать время, которые Вы собираетесь провести на стоянке");
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из приложения?", "Диалоговое окно", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                windowCloseRequest = true;
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void rangeMessage()
        {
            MessageBox.Show("Некорректный ввод данных. Было введено не число от 1 до 360. Попробуйте ещё раз.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(textField.Text=="")
            {
                MessageBox.Show("Некорректный ввод данных. Поле ввода текста пустое. Попробуйте ещё раз.");
            } else
            {
                try
                {
                    int stopTime = int.Parse(textField.Text);
                    if (stopTime >= 1 & stopTime <= 360)
                    {
                        HelpMethods.SetStopTime(stopTime);
                        windowCloseRequest = true;
                        HelpMethods.AddTimeToMenuPassCard(stopTime);
                        Close();
                        HelpMethods.MainWindowShow();
                    } else
                    {
                        rangeMessage();
                    }
                } catch(Exception ex)
                {
                    rangeMessage();
                }
            }
        }
    }
}
