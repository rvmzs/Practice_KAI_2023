using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class TerminalScreen
    {
        private StackPanel panel;
        protected Label label;
        protected List<string> messageList;

        public TerminalScreen(int gridCol, int gridRow, Grid grid, int terminalNum, params string[] messages)
        {
            messageList = new List<string>
            {
                "Здравствуйте, это пользовательский интерфейс\n" + terminalNum + "-го терминала"
            };

            foreach (string el in messages)
            {
                messageList.Add(el);
            }

            panel = new StackPanel();
            panel.Margin = new Thickness(20);
            panel.Background = HelpMethods.getHexBrush("#FFF0F8FF");

            label = new Label();
            label.Content = messageList[0];
            panel.Children.Add(label);

            Grid.SetColumn(panel, gridCol);
            Grid.SetRow(panel, gridRow);
            grid.Children.Add(panel);
        }

        public void switchScreenToIndex(int index)
        {
            label.Content = messageList[index];
        }

        public virtual void switchScreenToMain(bool cardInGap) { }
    }
}
