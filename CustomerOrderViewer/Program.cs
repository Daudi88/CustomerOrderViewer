namespace CustomerOrderViewer
{
    using System;
    using Models;
    using Repository;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailsCommand customerOrderDetailsCommand =
                    new("Data Source = localhost; Initial Catalog = CustomerOrderViewer; Integrated Security = True");

                IList<CustomerOrderDetailsModel> customerOrderDetailsModels = customerOrderDetailsCommand.GetList();

                if (customerOrderDetailsModels.Any())
                {
                    foreach (CustomerOrderDetailsModel customerOrderDetailsModel in customerOrderDetailsModels)
                    {
                        Console.WriteLine("{0}: Fullname: {1} {2} (Id: {3}) - purchased {4} for {5} (Id: {6})",
                            customerOrderDetailsModel.CustomerOrderId,
                            customerOrderDetailsModel.FirstName,
                            customerOrderDetailsModel.LastName,
                            customerOrderDetailsModel.CustomerId,
                            customerOrderDetailsModel.Description,
                            customerOrderDetailsModel.Price,
                            customerOrderDetailsModel.ItemId
                            );
                    }
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Someting went wrong {0}", ex.Message);
            }
        }
    }
}
