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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika_Lavrentev_Abdrahmanov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static MediaPlayer music;

        private GetPassCardGap getPassCardGap;
        public InsertPassCardGap InsertPassCardGap { get; set; }
        public InsertBankCardGap InsertBankCardGap { get; set; }
        private InsertPassCardGap givePassCardGap;
        public TerminalScreen terminalScreen1;
        public TerminalScreen2 terminalScreen2;
        public TerminalScreen3 terminalScreen3;

        public MenuPassCard MenuPassCard { get; set; }
        public MenuBankCard MenuBankCard { get; set; }
        public bool PassCardInHand { get; set; }
        public bool BankCardInHand { get; set; }

        public int MinuteCost {get;set;}
        public int StopTime { get; set; }
        public int FreeTime { get; set; }
        public int ResultCost { get; set; }

        public int Balance { get; set; }

        private bool cardGet, cardGive;
        public bool PaymentIsDone { get; set; }
        public bool AccountIsDone { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            music = new MediaPlayer();
            music.Open(new Uri("app music.mp3", UriKind.Relative));
            music.Play();

            PassCardInHand = false;
            BankCardInHand = true;
            AccountIsDone = false;
            PaymentIsDone = false;
            cardGet = false;
            cardGive = false;

            FreeTime = 30;
            MinuteCost = 10;
            Balance = 1000;

            MenuPassCard = new MenuPassCard(0,0,menuGrid);
            MenuBankCard = new MenuBankCard(1,0, menuGrid,Balance);


            terminalScreen1 = new TerminalScreen(0, 3, mainGrid, 1,
                "Ваша карта-пропуск готова! Можете её забрать");

            terminalScreen2 = new TerminalScreen2(1, 3, mainGrid, 2,
                "",
                "Вставьте банковскую карту",
                "");

            terminalScreen3 = new TerminalScreen3(2, 3, mainGrid, 3,
                "Нажмите кнопку \"Сдать карту\"");

            getPassCardGap = new GetPassCardGap(0, 2, mainGrid);

            InsertPassCardGap = new InsertPassCardGap(1, 2, mainGrid, terminalScreen2);
            InsertBankCardGap = new InsertBankCardGap(1, 4, mainGrid, terminalScreen2);

            givePassCardGap = new InsertPassCardGap(2, 2, mainGrid, terminalScreen3);
        }

        private void GetPassCardButton_Click(object sender, RoutedEventArgs e)
        {
            if(getPassCardGap.Accessible)
            {
                getPassCardGap.GetCardRequest();
                cardGet = true;
                cardGive = false;
            } else
            {
                MessageBox.Show("Вы уже получили карту-пропуск");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PaymentIsDone)
            {
                MessageBox.Show("Операция оплаты не может быть осуществлена, так как время стоянки Вы уже оплатили");
            }
            else if (!AccountIsDone)
            {
                MessageBox.Show("Операция оплаты не может быть осуществлена, так как не был произведён рассчёт результирующей стоимости " +
                    "с помощью карты-пропуска");
            } else if(BankCardInHand)
            {
                MessageBox.Show("Операция оплаты не может быть осуществлена, так как карта банка не вставлена в терминал");
            } 
            else if(Balance >= ResultCost)
            {
                PaymentIsDone = true;
                Balance -= ResultCost;
                MenuBankCard.BalanceUpdate(Balance);
                InsertPassCardGap.BlockCard();
                InsertBankCardGap.BlockCard();
                terminalScreen2.switchScreenToIndex(0);
            } else
            {
                MessageBox.Show("Не хватает денег для операции. Вы можете использовать функцию \"Изменить баланс\" в верхней части экрана");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(givePassCardGap.GetCardInGap() & PaymentIsDone)
            {
                terminalScreen2.switchScreenToIndex(0);
                terminalScreen3.switchScreenToIndex(0);
                givePassCardGap.SetPassiveState();
                givePassCardGap.CardInGap = false;
                PaymentIsDone = false;
                AccountIsDone = false;
                cardGive = true;
                cardGet = false;
                getPassCardGap.Accessible = true;
                InsertPassCardGap.Accessible = true;
                InsertBankCardGap.Accessible = true;

            } else if(!givePassCardGap.GetCardInGap())
            {
                MessageBox.Show("Вы не можете сдать карту-пропуск, если она не вставлена в терминал");
            } else
            {
                MessageBox.Show("Вы не можете сдать карту-пропуск, пока не оплачено время стоянки");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new BalanceWindow();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(cardGet & !PaymentIsDone)
            {
                MessageBox.Show("Вы не можете уехать со стоянки, если не оплатили время стоянки");
            } else if(cardGet & !cardGive)
            {
                MessageBox.Show("Вы не можете уехать со стоянки, не сдав карту-пропуск в 3 терминал");
            } else if(!BankCardInHand)
            {
                MessageBox.Show("Вы не можете уехать со стоянки, не забрав свою банковскую карту");
            } else
            {
                MessageBox.Show("Удачного пути!");
                Close();
            }
        }
    }
}
