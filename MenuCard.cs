using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public abstract class MenuCard
    {
        protected StackPanel panel;
        protected Label label;
        protected GapState active, passive;
        protected bool isActive;

        protected MenuCard(int gridCol, int gridRow, Grid grid)
        {
            isActive = false;

            panel = new StackPanel();
            panel.Margin = new Thickness(10);

            label = new Label();
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;

            panel.Children.Add(label);

            Grid.SetColumn(panel, gridCol);
            Grid.SetRow(panel, gridRow);
            grid.Children.Add(panel);
        }

        public void InvertCardState()
        {
            if(isActive)
            {
                panel.Background = passive.Color;
                label.Content = passive.Text;
                isActive = false;
            } else
            {
                panel.Background = active.Color;
                label.Content = active.Text;
                isActive = true;
            }
        }
    }
}
