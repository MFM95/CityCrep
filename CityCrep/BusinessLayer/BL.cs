using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace CityCrep.BusinessLayer
{
    class BL
    {
        DataAccessLayer.DAL D;
        public BL()
        {

        }

        // Get User for login
        public DataTable get_user(string u_name, string pass)
        {
            D = new DataAccessLayer.DAL();

            if (D.getError()) return null;

            DataTable dt = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            param[0] = new MySqlParameter("u_name", MySqlDbType.VarChar);
            param[0].Value = u_name;
            param[1] = new MySqlParameter("pass", MySqlDbType.VarChar);
            param[1].Value = pass;
            dt = D.SelectData("get_user", param);
            return dt;
        }

        // Add new Product
        public void add_product(string name, float price, int size, string category)
        {
            D = new DataAccessLayer.DAL();
            if (D.getError()) return;

            MySqlParameter[] param = new MySqlParameter[4];
            param[0] = new MySqlParameter("pro_name", MySqlDbType.VarChar);
            param[0].Value = name;
            param[1] = new MySqlParameter("price", MySqlDbType.Float);
            param[1].Value = price;
            param[2] = new MySqlParameter("size", MySqlDbType.Int32);
            param[2].Value = size;
            param[3] = new MySqlParameter("category", MySqlDbType.VarChar);
            param[3].Value = category;
            D.ExecuteCommand("add_product", param);
        }




    }
}
