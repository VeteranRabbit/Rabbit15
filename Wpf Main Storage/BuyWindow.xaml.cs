using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using System.Xml.Serialization;

namespace Wpf_Main_Storage
{
    /// <summary>
    /// Interaction logic for BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        public BuyWindow()
        {
            InitializeComponent();
        }
        private readonly dataclassDataContext db = new dataclassDataContext();
        
        
        

        public void GetKala()
        {
            var kalas = from kala in db.Products
                        where kala.seller.name == Combo_sherkat.SelectedItem.ToString()
                        select kala.name;
            Combo_Kala.ItemsSource = kalas;

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Dg_1.ItemsSource = db.Buy_factors;
            Combo_sherkat.ItemsSource = db.sellers.Select(c=>c.name);
        }


        private void Combo_sherkat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetKala();
        }

        public void ChangeUnit()
        {
            if (Combo_Kala.SelectedItem != null)
            {
                Product kala = new Product();
                kala = db.Products.First(c => c.name == Combo_Kala.SelectedItem.ToString());
                lbl_unit.Text = kala.unit;
            }
            
        }

        private void Combo_Kala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeUnit();
        }
        public void RefreshDataGrid()
        {
            Dg_1.ItemsSource = null;
            Dg_1.ItemsSource = db.Buy_factors;
            Dg_1.Items.Refresh();
        }
        public void SubmitNewBuyFactor()
        {
            Buy_factor jadid = new Buy_factor();
            jadid.seller_company = Combo_sherkat.SelectedItem.ToString();
            jadid.price = int.Parse(txt_price.Text);
            jadid.product_name = Combo_Kala.SelectedItem.ToString();
            jadid.unit = lbl_unit.Text;
            jadid.description = txt_description.Text;
            jadid.amount = int.Parse(txt_amount.Text);
            jadid.sum_buy = (jadid.price) * (jadid.amount);
            jadid.date = date_date.SelectedDate;

            db.Buy_factors.InsertOnSubmit(jadid);
            db.SubmitChanges();
        }
        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            SubmitNewBuyFactor();   
            RefreshDataGrid();
        }
        
    }
}
