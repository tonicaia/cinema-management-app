using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CineM8.Models;
using MySqlConnector;

namespace CineM8.DAL
{
    public class PriceDAL
    {
        public void CreatePrice(Price price)
        {
            MySqlCommand comm = DBConnect.conn.CreateCommand();
            comm.CommandText = "INSERT INTO prices(price,description,weekend) VALUES(@price,@description,@weekend)";
            comm.Parameters.AddWithValue("@price", price.PriceAmount);
            comm.Parameters.AddWithValue("@description", price.Description);
            comm.Parameters.AddWithValue("@weekend", price.Weekend );
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }

        public List<Price> GetPrices()
        {
            try
            {
                List<Price> prices = new List<Price>();
                DataSet ds;
                MySqlDataAdapter da;

                using (MySqlConnection connection = new MySqlConnection(DBConnect.conString))
                {
                    string query = "SELECT * FROM prices;";
                    connection.Open();

                    da = new MySqlDataAdapter(query, connection);
                    ds = new DataSet();
                    da.Fill(ds, "Prices");
                }
                DataTable dt = ds.Tables["Prices"];

                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["id"]);
                    double priceAmount = Convert.ToDouble(dr["price"]);
                    string description = dr["description"].ToString();
                    int weekend = Convert.ToInt32(dr["weekend"]);
                   
                    Price price = new Price();
                    price.Id = id;
                    price.PriceAmount = priceAmount;
                    price.Description = description;
                    price.Weekend = weekend;

                    prices.Add(price);
                }

                return prices;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}