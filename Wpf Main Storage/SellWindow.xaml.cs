using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for SellWindow.xaml
    /// </summary>
    public partial class SellWindow : Window
    {
        public ObservableCollection<Sell_factor> TableData { get; }

        public SellWindow()
        {
            InitializeComponent();
            
        }
        private readonly dataclassDataContext db = new dataclassDataContext();

        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            Dg_1.ItemsSource = db.Sell_factors;
            Combo_sherkat.ItemsSource = db.sellers.Select(c => c.name);
        }

        public void GetKala()
        {
            var kalas = from kala in db.Products
                        where kala.seller.name == Combo_sherkat.SelectedItem.ToString()
                        select kala.name;
            Combo_kala.ItemsSource = kalas;

        }
       
        public void ChangeUnit()
        {
            if (Combo_kala.SelectedItem != null)
            {
                Product kala = new Product();
                kala = db.Products.First(c => c.name == Combo_kala.SelectedItem.ToString());
                lbl_unit.Text = kala.unit;
            }

        }
       

        private void Combo_sherkat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetKala();
        }

        private void Combo_kala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeUnit();
        }
        public void SubmitNewBuyFactor()
        {
            Sell_factor jadid = new Sell_factor();
            jadid.seller_company = Combo_sherkat.SelectedItem.ToString();
            jadid.sell_price = int.Parse(txt_sellprice.Text);
            jadid.product_name = Combo_kala.SelectedItem.ToString();
            jadid.unit = lbl_unit.Text;
            jadid.buy_price = int.Parse(txt_buyprice.Text);
            jadid.description = txt_description.Text;
            jadid.amount = int.Parse(txt_amount.Text);
            jadid.sum_finance = ((int.Parse(txt_sellprice.Text)) - (int.Parse(txt_buyprice.Text)) - (int.Parse(txt_discount.Text))) * (int.Parse(txt_amount.Text));
            jadid.date = date_date.SelectedDate;
            jadid.discount = int.Parse(txt_discount.Text);

            db.Sell_factors.InsertOnSubmit(jadid);
            db.SubmitChanges();

            Dg_1.ItemsSource = db.Sell_factors;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubmitNewBuyFactor();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Dg_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
