using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FeiCui.Unity
{
    namespace MySQLDemo
    {
        class BaseConnection
        {
            private string User { get; set; }
            private string Password { get; set; }
            private string Database { get; set; }
            private string Conns { get; set; }

            private static MySqlConnection conn = null;

            public BaseConnection()
            {
                Database = "gamedatabase";
                User = "root";
                Password = "123456";
                Conns = String.Format("server=localhost;port=3306;database={0};user={1};password={2};SslMode=none;CharSet=utf8", Database, User, Password);
            }

            public static MySqlConnection GetInstance()
            {
                if (conn == null)
                {
                    conn = new MySqlConnection(new BaseConnection().Conns);
                    conn.Open();
                }
                return conn;
            }

            public static void CloseConnection()
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        class LoginDAO : BaseConnection
        {
            private MySqlConnection conn = null;

            public LoginDAO()
            {
                conn = BaseConnection.GetInstance();
            }

            public Login SelectById(int id)
            {
                string sql = "select * from login where id = {0}";
                sql = String.Format(sql, id);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                Login result = null;
                while (reader.Read())
                {
                    result = new Login()
                    {
                        ID = (int)reader[0],
                        UserName = (string)reader[1],
                        Password = (string)reader[2],
                        RegisterTime = (DateTime)reader[3]
                    };
                }
                return result;
            }
        }

        class Login
        {
            public int ID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }

            public DateTime RegisterTime { get; set; }

            public Login() { }

            public Login(int id, string userName, string password, DateTime registerTime)
            {
                ID = id;
                UserName = userName;
                Password = password;
                RegisterTime = registerTime;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    LoginDAO ldao = new LoginDAO();
                    Login result = ldao.SelectById(1);
                    Console.Write("{0}\t{1}\t{2}\t{3}", result.ID, result.UserName, result.Password, result.RegisterTime);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {

                }
            }
        }
    }
}
