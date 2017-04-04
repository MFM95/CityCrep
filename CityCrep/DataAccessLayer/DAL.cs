using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace CityCrep.DataAccessLayer
{
    class DAL
    {
        MySqlConnection MySqlCon;
        private bool error = false;

        public bool getError()
        {
            return error;
        }

        public DAL()
        {
            Connect();
            
        }

        public void Connect()
        {

            String server = "107.180.24.243";
            String database = "SmartBasket";
            String user = "samehkaras";
            String password = "Jesuslove1";
            String mode = "online";
            String port = "3306";
            if (mode == "online")
            {
               // MySqlCon = new MySqlConnection("SERVER=" + server + ";PORT=" + port + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password + "default command timeout = 200;");
               // MySqlCon = new MySqlConnection("SERVER=107.180.24.243;PORT=3306;DATABASE=SmartBasket;UID=samehkaras;PASSWORD=Jesuslove1;charset=utf8;Allow Zero Datetime=True; default command timeout = 200;");
            }
            else
            {
               MySqlCon= new MySqlConnection("SERVER=" + server + ";DATABASE=" + database + ";UID=" + user + ";PASSWORD=" + password);

            }
            Open();
        }

        public void Open()
        {
            if (MySqlCon.State != ConnectionState.Open)
            {
                try
                {
                    MySqlCon.Open();
                }
                catch
                {
                    MessageBox.Show("Error in the Internet Connnection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }
        }

        public void Close()
        {

            if (MySqlCon.State == ConnectionState.Open)
            {
                try
                {
                    MySqlCon.Close();
                }
                catch
                {
                    MessageBox.Show("Error in the Internet Connnection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }
            }

        }

        public DataTable SelectData(string stored_procedure, MySqlParameter[] param)
        {

            DataTable dt = new DataTable();
            MySqlCommand MySqlcmd = new MySqlCommand();
            MySqlcmd.CommandType = CommandType.StoredProcedure;
            MySqlcmd.CommandText = stored_procedure;

            try
            {
                this.Open();
                MySqlcmd.Connection = MySqlCon;

                if (param != null)
                    MySqlcmd.Parameters.AddRange(param);

                MySqlDataAdapter da = new MySqlDataAdapter(MySqlcmd);
                da.Fill(dt);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error in the Internet Connnection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
            return dt;
        }
        public void ExecuteCommand(string stored_procedure, MySqlParameter[] param)
        {
            MySqlCommand MySqlcmd = new MySqlCommand();
            MySqlcmd.CommandType = CommandType.StoredProcedure;
            MySqlcmd.CommandText = stored_procedure;
            try
            {
                this.Open();
                MySqlcmd.Connection = MySqlCon;
                if (param != null)
                    MySqlcmd.Parameters.AddRange(param);
                MySqlcmd.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error in the Internet Connnection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                error = true;
            }
        }

    }
}
