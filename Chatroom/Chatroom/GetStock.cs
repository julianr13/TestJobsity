using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Chatroom
{
    public class GetStock
    {

        public string GetBotMessageStock(string stock_code)
        {
            string messg = "";
           string high = obtenerExcel("https://stooq.com/q/l/?s="+ stock_code + "&f=sd2t2ohlcv&h&e=csv");
            if (high.Contains("Error:"))
            {
                messg = high;
            }
            else if (high == "N/D")
            {
                messg = "The quote for " + stock_code + " is not defined.";
            }
            else if (high == "Ticker missing")
            {
                messg = high + ", please provide a stock_code";
            }
            else
            {
               
                messg = stock_code +" quote is $"+ high + " per share.";
            }
            return messg;
        }
        public string  obtenerExcel(string url)
        {

            //get the csv from url
            String resCSV = getFilefromUrl(url);
            if (resCSV.Contains("Error:") || resCSV.Contains("Ticker missing"))
            {
                return resCSV;
            }
            else
            {
                //parsing
                string[] rowsCsv = Regex.Split(resCSV, "\r\n");
                //header
                DataTable archivoExcT = new DataTable("svc");
                string[] headers = rowsCsv[0].Split(',');
                for (int i = 0; i < headers.Length ; i++)
                {
                    archivoExcT.Columns.Add(headers[i]);
                }
                //rows

                for (int i = 1; i < rowsCsv.Length; i++)
                {
                    string[] row = rowsCsv[i].Split(',');
                    DataRow rowDT = archivoExcT.NewRow();
                    for (int j = 0; j < row.Length ; j++)
                    {
                        rowDT[j] = row[j];
                       
                    }
                    archivoExcT.Rows.Add(rowDT);
                }
                return archivoExcT.Rows[0]["High"].ToString();
            }
             

           
        }
        public String  getFilefromUrl(string url)
        {
            try
            {
                WebRequest tRequest;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                tRequest = WebRequest.Create(url);
                tRequest.Method = "post";

                Stream dataStream = tRequest.GetRequestStream();

                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();


                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                return sResponseFromServer;
            }
            catch (Exception ex)
            {

                return "Error: " + ex.ToString();
            }
                
        }
    }
}