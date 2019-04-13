using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Chatroom
{
    public class Usuarios
    {
        public string Login(string user, string passw)
        {

            Security sec = new Security();
            string passwEnc = sec.generarMD5(passw);
            dbData conec = new dbData();
            DataSet res = conec.ExecuteQuery("select * from Users where userLogin='"+user+"'");
            if (res.Tables[0].Rows.Count>0)
            {
                if (res.Tables[0].Rows[0]["passWord"].ToString() == passwEnc)
                {
                    conec.ExecuteQuery("update Users set lastLogin='" + DateTime.Now.ToString()+"' where userLogin='" + user + "'");
                    return user;
                }
                else
                {
                    return "Password incorrecto.";
                }
            }else
            {
                return "El usuario no existe, por favor de clic en registrar.";
            }
        }
        public string Register(string user, string passw)
        {

            Security sec = new Security();
            string passwEnc = sec.generarMD5(passw);
            dbData conec = new dbData();
            DataSet res = conec.ExecuteQuery("select * from Users where userLogin='" + user + "'");
            if (res.Tables[0].Rows.Count > 0)
            {
                return "El usuario ya se encuentra registrado.";
            }
            else
            {
                int resIns = conec.ExecuteNonQuery("insert into Users (userLogin,passWord,lastLogin) values ('" + user + "','"+passwEnc +"','"+DateTime.Now.ToString()+"')");
                if (resIns >0)
                {
                    return user;
                }else
                {
                    return "No se pudo realizar el registro del usuario.";
                }
               
            }
        }
    }
}