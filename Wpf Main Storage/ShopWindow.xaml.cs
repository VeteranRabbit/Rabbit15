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
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        public ShopWindow()
        {
            InitializeComponent();
        }

        private readonly dataclassDataContext db = new dataclassDataContext();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dg_2.ItemsSource = db.shops;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shop jadid = new shop();
            jadid.address = txt_address.Text;
            jadid.manager = txt_manager.Text;
            jadid.name = txt_shopname.Text;

            db.shops.InsertOnSubmit(jadid);
            db.SubmitChanges();

            dg_2.Items.Refresh();
            dg_2.ItemsSource = db.shops;
        }

        
    }
}
