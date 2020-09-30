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
    /// Interaction logic for ProWindow.xaml
    /// </summary>
    public partial class ProWindow : Window
    {
        public ProWindow()
        {
            InitializeComponent();
        }

        private readonly dataclassDataContext db = new dataclassDataContext();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Combo_sherkat.ItemsSource = db.sellers.Select(c => c.name);
            Dg_3.ItemsSource = db.Products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            seller Seller = new seller();
            Seller = db.sellers.First(c => c.name == Combo_sherkat.SelectedItem.ToString());

            Product jadid = new Product();
            jadid.name = txt_name.Text;
            jadid.unit = txt_unit.Text;
            jadid.seller_id = Seller.Id;

            db.Products.InsertOnSubmit(jadid);
            db.SubmitChanges();
            Dg_3.ItemsSource = db.Products;
        }
    }
}
