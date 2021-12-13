using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FinancialChat.StockBot
{
    public class ApiConsumer
    {
        public DataTable StockDataTable(string command)
        {
            var restSharpClient = new RestClient("https://stooq.com");
            var downloadRequest = new RestRequest($"q/l/?s={command}&f=sd2t2ohlcv&h&e=csv", Method.GET);

            IRestResponse response = restSharpClient.Execute(downloadRequest);

            string[] strSeparators = new string[] { "\r\n" };
            string[] lines = response.Content.Split(strSeparators, StringSplitOptions.None);

            string[] fields = lines[0].Split(new char[] { ',' });
            int columnsLength = fields.GetLength(0);
            DataTable dataTable = new DataTable();
            // 1st row must be column names; force lower case to ensure matching later on
            for (int i = 0; i < columnsLength; i++)
                dataTable.Columns.Add(fields[i].ToLower(), typeof(string));
            int rowsLength = lines.GetLength(0);
            DataRow dataRow;
            for (int i = 1; i < rowsLength; i++)
            {
                fields = lines[i].Split(new char[] { ',' });
                if (fields.Length > 1)
                {
                    dataRow = dataTable.NewRow();
                    for (int f = 0; f < columnsLength; f++)
                        dataRow[f] = fields[f];
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
