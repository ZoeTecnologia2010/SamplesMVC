using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Samples.Entities;

namespace Samples.DAO
{
    public class UserDAO
    {
        public int Insert(UserEnt objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "INSERT INTO users ([nameFull], [name], [password]) VALUES (@nameFull, @name, @password)";

                cn.Parameters.Add("nameFull", SqlDbType.VarChar).Value = objTable.NameFull;
                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTable.Name;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = objTable.Password;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }
        }

        public int Edit(UserEnt objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "UPDATE users SET nameFull = @nameFull, name = @name, password = @password where id = @id";

                cn.Parameters.Add("nameFull", SqlDbType.VarChar).Value = objTable.NameFull;
                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTable.Name;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = objTable.Password;
                cn.Parameters.Add("id", SqlDbType.Int).Value = objTable.Id;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;

            }
        }

        public int Delete(UserEnt objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "DELETE FROM users where id = @id";

                cn.Parameters.Add("id", SqlDbType.Int).Value = objTable.Id;


                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;

            }
        }

        public List<UserEnt> Find(UserEnt objTable)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * from users WHERE name LIKE @name";

                cn.Parameters.Add("name", SqlDbType.VarChar).Value = objTable.Name + "%";
                cn.Connection = con;

                SqlDataReader dr;
                List<UserEnt> lista = new List<UserEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserEnt dado = new UserEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.NameFull = Convert.ToString(dr["nameFull"]);
                        dado.Name = Convert.ToString(dr["name"]);
                        dado.Password = Convert.ToString(dr["password"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }

        public UserEnt Login(UserEnt obj)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * from users where name = @name AND password = @password";


                cn.Connection = con;

                cn.Parameters.Add("name", SqlDbType.VarChar).Value = obj.Name;
                cn.Parameters.Add("password", SqlDbType.VarChar).Value = obj.Password;

                SqlDataReader dr;


                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserEnt dado = new UserEnt();

                        dado.Name = Convert.ToString(dr["name"]);
                        dado.Password = Convert.ToString(dr["password"]);
                    }
                }
                else
                {
                    obj.Name = null;
                    obj.Password = null;
                }

                return obj;
            }
        }

        public List<UserEnt> ListTable()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.SamplesConnectionString;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;

                con.Open();

                cn.CommandText = "SELECT * from users ORDER BY id DESC";


                cn.Connection = con;

                SqlDataReader dr;
                List<UserEnt> lista = new List<UserEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserEnt dado = new UserEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.NameFull = Convert.ToString(dr["nameFull"]);
                        dado.Name = Convert.ToString(dr["name"]);
                        dado.Password = Convert.ToString(dr["password"]);

                        lista.Add(dado);
                    }
                }

                return lista;
            }
        }
    }
}
