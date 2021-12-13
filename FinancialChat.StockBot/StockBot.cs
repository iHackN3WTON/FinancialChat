using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.StockBot
{
    public class StockBot
    {
        public string RequestStock(string command)
        {
            var apiConsumer = new ApiConsumer();
            try
            {
                var dataTable = apiConsumer.StockDataTable(command);

                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Select()[0].ItemArray[6].ToString().Equals("N/D"))
                    {
                        return command + "quote not found";
                    }
                    else
                    {
                        return command + " quote is $" + dataTable.Select()[0].ItemArray[6].ToString() + " per share";
                    }
                }
                else
                {
                    return command + " quote not found";
                }
            }
            catch (Exception e)
            {
                return command + " quote not found, " + e.Message;
            }
        }
    }
}
