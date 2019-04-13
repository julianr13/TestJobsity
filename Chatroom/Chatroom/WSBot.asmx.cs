using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Chatroom
{
    /// <summary>
    /// Descripción breve de WSBot
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSBot : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetValueStock(string stock_code)
        {
            GetStock getStock = new GetStock();
            return getStock.GetBotMessageStock(stock_code);  
        }
    }
}
