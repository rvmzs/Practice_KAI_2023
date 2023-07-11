using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public abstract class CardGap
    {
        protected StackPanel panel;
        protected Label label;
        protected GapState active, passive, enterActive, enterPassive;

        public bool CardInGap { get; set; }
        public bool Accessible { get; set; }

        protected CardGap(int gridCol, int gridRow, Grid grid)
        {
            passive = new GapState(HelpMethods.getHexBrush("#D3D3D3"), "");

            CardInGap = false;
            Accessible = true;

            panel = new StackPanel();
            panel.Height = 25;
            panel.Width = 150;
            panel.Background = passive.Color;

            label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Center;

            panel.Children.Add(label);

            panel.MouseEnter += new MouseEventHandler(Gap_MouseEnter);
            panel.MouseLeave += new MouseEventHandler(Gap_MouseLeave);
            panel.MouseDown += new MouseButtonEventHandler(Gap_MouseDown);

            Grid.SetColumn(panel, gridCol);
            Grid.SetRow(panel, gridRow);
            grid.Children.Add(panel);
        }

        protected void Gap_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CardInGap)
            {
                panel.Background = enterActive.Color;
                label.Content = enterActive.Text;
            }
            else
            {
                panel.Background = enterPassive.Color;
                label.Content = enterPassive.Text;
            }
        }

        protected void Gap_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CardInGap)
            {
                panel.Background = active.Color;
                label.Content = active.Text;
            }
            else
            {
                panel.Background = passive.Color;
                label.Content = passive.Text;
            }
        }

        protected abstract void Gap_MouseDown(object sender, MouseEventArgs e);

        public void BlockCard() { Accessible = false; }

        public void SetPassiveState() {
            panel.Background = passive.Color;
            label.Content = passive.Text;
        }
    }
}
