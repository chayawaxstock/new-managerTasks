using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace _00_DAL
{
    public static class DBAccess
    {

        static MySqlConnection Connection = new MySqlConnection(ConfigurationManager.AppSettings["conectionString1"].ToString());

 
        public static int? RunNonQuery(string query)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public static object RunScalar(string query)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    return command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }

        }

        public static List<T> RunReader<T>(string query, Func<MySqlDataReader, List<T>> func)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(query, Connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public static int? RunStore(string nameStore, List<string> conditionValue, List<string> condition)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(nameStore, Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < condition.Count; i++)
                    {
                        command.Parameters.AddWithValue(condition[i], conditionValue[i]);
                    }

                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        public static List<T> RunReader<T>(Func<MySqlDataReader, List<T>> func, string nameStore, List<string> conditionValue, List<string> condition)
        {
            try
            {
                lock (Connection)
                {
                    Connection.Open();
                    MySqlCommand command = new MySqlCommand(nameStore, Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < condition.Count; i++)
                    {
                        command.Parameters.AddWithValue(condition[i], conditionValue[i]);
                    }
                    MySqlDataReader reader = command.ExecuteReader();
                    return func(reader);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
}
