using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class TerminalScreen2 : TerminalScreen
    {
        public TerminalScreen2(int gridCol, int gridRow, Grid grid, int terminalNum, params string[] messages)
            : base(gridCol, gridRow, grid, terminalNum, messages) { }

        public override void switchScreenToMain(bool cardInGap)
        {
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).AccountIsDone = true;
            messageList[1] =
                "Ваше время: " + HelpMethods.GetStopTime() + " минут\n" +
                "Цена за минуту: " + HelpMethods.GetMinuteCost() + " руб.\n" +
                "Время бесплатной стоянки: " + HelpMethods.GetFreeTime() + " минут\n" +
                "Конечная стоимость: " + HelpMethods.GetResultCost() + " руб.\n\n";


            messageList[3] = "Банковская карта вставлена. Баланс: " + HelpMethods.GetBalance() + " руб.\nНажмите кнопку \"Оплатить\"";

            switchScreenToIndex(1);

            if (HelpMethods.GetResultCost() == 0)
            {
                label.Content += "Автоматическая оплата произведена.";
                HelpMethods.GetInsertPassCardGap().BlockCard();
                HelpMethods.GetInsertBankCardGap().BlockCard();
                HelpMethods.SetPaymentIsDone(true);
            }
            else if(HelpMethods.GetBankCardInHand())
            {
                label.Content += messageList[2];
            }
            else
            {
                label.Content += messageList[3];
            }
        }
    }
}
