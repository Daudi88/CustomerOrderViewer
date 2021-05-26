namespace CustomerOrderViewer.Repository
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Models;

    public class CustomerOrderDetailsCommand
    {
        private string _connectionstring;

        public CustomerOrderDetailsCommand(string connectionString)
        {
            _connectionstring = connectionString;
        }

        public IList<CustomerOrderDetailsModel> GetList()
        {
            List<CustomerOrderDetailsModel> customerOrderDetailsModels = new();

            using (SqlConnection connection = new(_connectionstring))
            {
                connection.Open();

                using (SqlCommand command = new("SELECT CustomerOrderId, CustomerId, ItemId, FirstName, LastName, [Description], Price FROM CustomerOrderDetails", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CustomerOrderDetailsModel customerOrderDetailsModel = new CustomerOrderDetailsModel
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    ItemId = Convert.ToInt32(reader["ItemId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                                
                                customerOrderDetailsModels.Add(customerOrderDetailsModel);
                            }
                        }
                    }
                }
            }

            return customerOrderDetailsModels;
        }
    }
}
