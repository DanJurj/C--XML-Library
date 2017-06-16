using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Biblioteca
{
    class BussinesLayer
    {
        private DataLayer DLL_Conn;

        public BussinesLayer()
        {
            DLL_Conn = new DataLayer();
        }
        public DataTable GetData()
        {
            return DLL_Conn.GetData();
        }
        public DataView OrderData(String criteriu)
        {
            return DLL_Conn.OrderData(criteriu);
        }
        public DataView SearchData(String criteriu, String substr)
        {
            return DLL_Conn.SearchData(criteriu, substr);
        }
        public bool DeteleData(String titlu)
        {
            return DLL_Conn.DeteleData(titlu);
        }
        public DataRow SelectData(String titlu)
        {
            return DLL_Conn.SelectData(titlu);
        }
        public bool UpdateCarte(String titlu, String autor, String editura, int anE, String limba, String categorie, int pret)
        {
            return DLL_Conn.UpdateData(titlu, autor, editura, anE, limba, categorie, pret);
        }
        public String CountEditura(String editura)
        {
            String nr=DLL_Conn.CountEditura(editura);
            DLL_Conn.DeleteFilter();
            return nr;
        }
        public String CountAutor(String autor)
        {
            String nr = DLL_Conn.CountAutor(autor);
            DLL_Conn.DeleteFilter();
            return nr;
        }
        public bool InsertData(String titlu, String autor, String editura, int anE, int anA, String limba, String categorie, int pret)
        {
            return DLL_Conn.InsertData(titlu, autor, editura, anE, anA, limba, categorie, pret);
        }
    }
}
