using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class MenuBankCard : MenuCard
    {
        public MenuBankCard(int gridCol, int gridRow, Grid grid, int balance) : base(gridCol, gridRow, grid)
        {
            passive = new GapState(HelpMethods.getHexBrush("#D3D3D3"), "Карта банка не в руках");
            active = new GapState(HelpMethods.getHexBrush("#BA55D3"), getActiveText(balance));

            panel.Background = active.Color;
            label.Content = active.Text;
            isActive = true;
        }

        private string getActiveText(int balance) { return "Ваша карта банка\nБаланс: " + balance+" руб."; }

        public void BalanceUpdate(int balance) {
            if (label.Content.ToString() == active.Text)
            {
                label.Content = getActiveText(balance);
            }
            active.Text = getActiveText(balance);
        }
    }
}
