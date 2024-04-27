using Business;
using Entity;
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
using System.Xml.Linq;

namespace Lab07
{
    /// <summary>
    /// Lógica de interacción para CustomersListByName.xaml
    /// </summary>
    public partial class CustomersListByName : Window
    {
        public CustomersListByName(List<Customer> customers)
        {
            InitializeComponent();
            dgCustomersList.ItemsSource = customers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
