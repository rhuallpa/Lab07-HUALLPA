using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductData
    {
        private string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS; Initial Catalog=Factura; User Id=UserHuallpa; Password=1234567";

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ProductList", connection); // Reemplaza "ProductList" con el nombre de tu procedimiento almacenado para obtener la lista de productos
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.product_id = reader.GetInt32(0); // Suponiendo que el primer campo en el resultado es el product_id
                        product.name = reader.GetString(1); // Suponiendo que el segundo campo en el resultado es el nombre del producto
                        product.price = reader.GetDecimal(2); // Suponiendo que el tercer campo en el resultado es el precio del producto
                        product.stock = reader.GetInt32(3); // Suponiendo que el cuarto campo en el resultado es el stock del producto
                        product.active = reader.GetBoolean(4); // Suponiendo que el quinto campo en el resultado indica si el producto está activo

                        products.Add(product);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return products;
        }
    }
}
