using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class CustomerData
    {
        private string connectionString = "Data Source=LAB1504-13\\SQLEXPRESS; Initial Catalog=Factura; User Id=UserHuallpa; Password=1234567";

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CustomerList", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.customer_id = reader.GetInt32(0);
                        customer.name = reader.GetString(1);
                        customer.address = reader.IsDBNull(2) ? null : reader.GetString(2);
                        customer.phone = reader.IsDBNull(3) ? null : reader.GetString(3);
                        customer.active = reader.GetBoolean(4);

                        customers.Add(customer);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return customers;
        }
    }
}
