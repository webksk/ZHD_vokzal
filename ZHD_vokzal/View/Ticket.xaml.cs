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
using ZHD_vokzal.ViewModel;
using System.Windows.Shapes;
using ZHD_vokzal.Model;

namespace ZHD_vokzal.View
{
    /// <summary>
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Window
    {
        public Ticket(Bilet bilet)
        {
            DataContext = bilet;
            InitializeComponent();
        }
    }
}
