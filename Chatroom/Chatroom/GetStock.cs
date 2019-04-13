using GenericParsing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Chatroom
{
    public class GetStock
    {

        public string GetBotMessageStock(string stock_code)
        {
            string messg = "";
            obtenerExcel("https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv");
            return messg;
        }
        public DataTable obtenerExcel(string url)
        {

            //get the cvs from url
            Stream resCSV = getFilefromUrl(url);
            
            DataTable archivoExcT = new DataTable("svc");
            archivoExcT.Columns.Add("RequestId");
            archivoExcT.Columns.Add("DeviceId");
            archivoExcT.Columns.Add("CampaignId");
            archivoExcT.Columns.Add("Score");
            archivoExcT.Columns.Add("Email");
            string strID, strName, strStatus;
            using (GenericParser parser = new GenericParser())
            {
                //parser.SetDataSource()

                //parser.ColumnDelimiter = ',';
                //parser.FirstRowHasHeader = true;
                //parser.SkipStartingDataRows = 0;
                //parser.MaxBufferSize = 409600;
                //parser.TextQualifier = '\"';

                while (parser.Read())
                {
                    archivoExcT.Rows.Add(parser[0], parser[1], parser[2], parser[3], parser[4]);
 
                }
            }

            return archivoExcT;
        }
        public Stream  getFilefromUrl(string url)
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
            return dataStream;
        }
    }
}