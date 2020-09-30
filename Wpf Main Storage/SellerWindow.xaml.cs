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

namespace Wpf_Main_Storage
{
    /// <summary>
    /// Interaction logic for SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
        }
        dataclassDataContext db = new dataclassDataContext();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Dg_3.ItemsSource = db.sellers;
            Combo_sherkat
        }
    }
}
