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

namespace ITB.Windows
{

    public partial class wMain : Window
    {
        public wMain()
        {
            InitializeComponent();
            frmMain.Navigate(new Page());
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            wModal w = new wModal(frmMain);
            w.Owner = this;
            w.Left = (double)typeof(Window).GetField("_actualLeft", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this) + WidthPoint.ActualWidth;
            w.Top = (double)typeof(Window).GetField("_actualTop", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this) + 35;
            w.Width = this.ActualWidth - WidthPoint.ActualWidth - 15;
            w.Height = this.ActualHeight - 50;
            w.Loaded += (object s, RoutedEventArgs ea) => ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(240, 255, 255, 255));
            w.Closed += (object s, EventArgs ea) => ((Button)sender).Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            switch (((Button)sender).Name)
            {
                case "Sales":
                    w.AddCategory("1С-Битрикс: Управление сайтом");
                    w.AddItem("1С-Битрикс: Бизнес", new Sales());
                    w.AddItem("1С-Битрикс: Малый бизнес", new Sales1());
                    w.AddItem("1С-Битрикс: Стандарт", new Sales2());
                    w.AddCategory("Готовые решения");
                    w.AddItem("Интернет-магазины", new Sales3());
                    w.AddItem("Корпоративные сайты", new Sales4());
                    w.AddCategory("CRM системы");
                    w.AddItem("Битрикс24", new Sales5());
                    w.ShowDialog();
                    break;
                case "Clients":
                    w.AddCategory("Информация о клиентах");
                    w.AddItem("Статус заказа", new zakaz());
                    w.AddItem("Данные клиента", new klient());
                    w.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private object сs()
        {
            throw new NotImplementedException();
        }
    }
}
