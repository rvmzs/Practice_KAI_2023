using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Praktika_Lavrentev_Abdrahmanov
{
    internal static class HelpMethods
    {
        public static SolidColorBrush getHexBrush(string hexNum)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexNum));
        }

        public static void AddTimeToMenuPassCard(int stopTime)
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).MenuPassCard.AddTextToActiveText("\nВремя стоянки: " + stopTime+" мин.");
        }

        public static void MainWindowHide()
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).Visibility = Visibility.Hidden;
        }

        public static void MainWindowShow()
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).Visibility = Visibility.Visible;
        }

        public static int GetBalance()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).Balance;
        }

        public static void SetBalance(int balance)
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).Balance = balance;
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).MenuBankCard.BalanceUpdate(balance);
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).terminalScreen2.switchScreenToMain(GetInsertBankCardGap().CardInGap);
        }

        public static InsertPassCardGap GetInsertPassCardGap()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).InsertPassCardGap;
        }

        public static InsertBankCardGap GetInsertBankCardGap()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).InsertBankCardGap;
        }

        public static void SetPaymentIsDone(bool paymentIsDone)
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).PaymentIsDone = paymentIsDone;
        }

        public static int GetMinuteCost()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).MinuteCost;
        }

        public static int GetStopTime()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).StopTime;
        }

        public static int GetFreeTime()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).FreeTime;
        }

        public static void SetStopTime(int stopTime)
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).StopTime = stopTime;
        }

        public static int GetResultCost()
        {
            if(GetStopTime() <= GetFreeTime())
            {
                (Window.GetWindow(App.Current.MainWindow) as MainWindow).ResultCost = 0;
            } else
            {
                (Window.GetWindow(App.Current.MainWindow) as MainWindow).ResultCost = GetMinuteCost() * (GetStopTime() - GetFreeTime());
            }
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).ResultCost;
        }

        public static bool GetAccountIsDone()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).AccountIsDone;
        }

        public static bool GetPassCardInHand()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).PassCardInHand;
        }

        public static bool GetBankCardInHand()
        {
            return (Window.GetWindow(App.Current.MainWindow) as MainWindow).BankCardInHand;
        }

        public static void InvertBoolPassCardInHand()
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).PassCardInHand = 
                !(Window.GetWindow(App.Current.MainWindow) as MainWindow).PassCardInHand;
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).MenuPassCard.InvertCardState();
        }

        public static void InvertBoolBankCardInHand()
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).BankCardInHand =
                !(Window.GetWindow(App.Current.MainWindow) as MainWindow).BankCardInHand;
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).MenuBankCard.InvertCardState();
        }
    }
}
