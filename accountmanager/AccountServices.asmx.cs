﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

//we need these to talk to mysql
using MySql.Data;
using MySql.Data.MySqlClient;
//and we need this to manipulate data from a db
using System.Data;
using System.Web.Script.Serialization;

namespace accountmanager
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

	/// <summary>
	/// Summary description for AccountServices
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class AccountServices : System.Web.Services.WebService
	{

		[WebMethod(EnableSession = true)]
		public int NumberOfAccounts()
		{
			//here we are grabbing that connection string from our web.config file
			string sqlConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
			//here's our query.  A basic select with nothing fancy.
			string sqlSelect = "SELECT * from accounts";



			//set up our connection object to be ready to use our connection string
			MySqlConnection sqlConnection = new MySqlConnection(sqlConnectString);
			//set up our command object to use our connection, and our query
			MySqlCommand sqlCommand = new MySqlCommand(sqlSelect, sqlConnection);


			//a data adapter acts like a bridge between our command object and 
			//the data we are trying to get back and put in a table object
			MySqlDataAdapter sqlDa = new MySqlDataAdapter(sqlCommand);
			//here's the table we want to fill with the results from our query
			DataTable sqlDt = new DataTable();
			//here we go filling it!
			sqlDa.Fill(sqlDt);
			//return the number of rows we have, that's how many accounts are in the system!
			return sqlDt.Rows.Count;
		}

        [WebMethod(EnableSession = true)]
        public string CreateAccount(string username,string password)
        {
            /*
            string sqlConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(sqlConnectString);
            string query = "insert INTO accounts(username,password) VALUES (@usernameValue,@passwordValue)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader;
            cmd.Parameters.AddWithValue("@usernameValue", HttpUtility.UrlDecode(username));
            cmd.Parameters.AddWithValue("@passwordValue", HttpUtility.UrlDecode(password));
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                conn.Close();
                return "success";
            }
            catch (Exception e)
            {
                conn.Close();
                return "Failed";
            }
            */

            var AccountRequest = new Account
            {
                Username = username,
                Password = password,
            };

            var serializer = new JavaScriptSerializer();
            var result = serializer.Serialize(AccountRequest);

            return result;

        }
	}
}
