using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace PEDS_XWFC.Controllers
{
    public class Connection
    {
        public DataView getData(string command)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost; user id=root; database=worldcupbd; password=alonso; SslMode = none");

            mySqlConnection.Open();

            MySqlCommand sqlCommand = new MySqlCommand(command, mySqlConnection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            sqlCommand.Dispose();
            mySqlConnection.Close();

            return dataSet.Tables[0].DefaultView;
        }
    }
}  