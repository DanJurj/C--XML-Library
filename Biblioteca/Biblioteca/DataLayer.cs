using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Biblioteca
{
    class DataLayer
    {
        private DataTable Carti;

        public DataLayer()
        {
            Carti = new DataTable("Carti");
            ReadData();
        }
        public void ReadData()
        {
            Carti.ReadXml("database.xml");
        }
        public void SaveData()
        {
            Carti.WriteXml("database.xml", XmlWriteMode.WriteSchema);
        }
        public void UpdateDatabase()
        {
            SaveData();
            Carti = new DataTable("Carti");
            ReadData();
        }
        public DataTable GetData()
        {
            return Carti;
        }
        public DataView OrderData(String criteriu)
        {
            DataView ordered = Carti.DefaultView;
            switch (criteriu)
            {
                case "Titlu":
                    ordered.Sort = "[Titlu] ASC";
                    break;
                case "Autor":
                    ordered.Sort = "[Autor] ASC";
                    break;
                case "Anul Editurii":
                    ordered.Sort = "[Anul Editurii] ASC";
                    break;
                case "Pret":
                    ordered.Sort = "[Pret] ASC";
                    break;
                default:
                    break;
            }
            return ordered;
        }
        public DataView SearchData(String criteriu, String substr)
        {
            DataView filter = Carti.DefaultView;
            switch (criteriu)
            {
                case "Titlu":
                    filter.RowFilter = "Titlu LIKE '%" + substr + "%'";
                    break;
                case "Numele autorului":
                    filter.RowFilter = "Autor LIKE '%" + substr + "%'";
                    break;
                case "Anul editurii":
                    if (substr != "")
                        filter.RowFilter = "[Anul Editurii]='" + int.Parse(substr) + "'";
                    else
                        filter.RowFilter = "";
                    break;
                case "Limba":
                    filter.RowFilter = "Limba LIKE '%" + substr + "%'";
                    break;
                case "Categorie":
                    filter.RowFilter = "Categorie LIKE '%" + substr + "%'";
                    break;
                default:
                    break;
            }
            return filter;
        }
        public bool DeteleData(String titlu)
        {
            foreach (DataRow row in Carti.Rows)
            {
                if (row["Titlu"].ToString() == titlu)
                {
                    row.Delete();
                    Carti.AcceptChanges();
                    UpdateDatabase();
                    return true;
                }
            }
            return false;
        }
        public DataRow SelectData(String titlu)
        {
            foreach (DataRow row in Carti.Rows)
            {
                if (row["Titlu"].ToString() == titlu)
                {
                    return row;
                }
            }
            return null;
        }
        public bool InsertData(String titlu, String autor, String editura, int anE, int anA, String limba, String categorie, int pret)
        {
            Carti.Rows.Add(titlu, autor, editura, anE, anA, limba, categorie, pret);
            Carti.AcceptChanges();
            UpdateDatabase();
            return true;
        }
        public bool UpdateData(String titlu, String autor, String editura, int anE, String limba, String categorie, int pret)
        {
            foreach (DataRow row in Carti.Rows)
            {
                if (row["Titlu"].ToString() == titlu)
                {
                    row["Autor"] = autor;
                    row["Editura"] = editura;
                    row["Anul Editurii"] = anE;
                    row["Limba"] = limba;
                    row["Categorie"] = categorie;
                    row["Pret"] = pret;
                    Carti.AcceptChanges();
                    UpdateDatabase();
                    return true;
                }
            }
            return false;
        }
        public String CountEditura(String editura)
        {
            DataView filter = Carti.DefaultView;
            filter.RowFilter = "Editura='" + editura + "'";
            return filter.Count.ToString();
        }
        public String CountAutor(String autor)
        {
            DataView filter = Carti.DefaultView;
            filter.RowFilter = "Autor='" + autor + "'";
            return filter.Count.ToString();
        }
        public void DeleteFilter()
        {
            Carti.DefaultView.RowFilter = "";
        }
    }
}
