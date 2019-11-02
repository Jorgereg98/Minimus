using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.Models;
using System.Data.SqlClient;
using System.Data;

namespace Minimus.DB
{
    public class UserDataService
    {
        private readonly SqlClient _client;
        private static UserDataService _instance;
        private static readonly object _lock = new object();

        public static UserDataService GetInstance(string connectionString)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserDataService(connectionString);
                    }
                }
            }
            return _instance;
        }

        private UserDataService(string connectionString)
        {
            _client = new SqlClient(connectionString);
        }

        public List<User> GetUsers()
        {
            var result = new List<User>();
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "getusers",
                        CommandType = CommandType.StoredProcedure
                    };
                    var dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var user = new User
                        {
                            iduser = Convert.ToInt32(dataReader["idamigo"].ToString()),
                            mail = dataReader["mail"].ToString(),
                            pasword = dataReader["pasword"].ToString(),
                            cities = dataReader["cities"].ToString(),
                            
                        };
                        result.Add(user);
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool AddUser(User user)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "adduser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@mail", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.mail
                    };

                    var par2 = new SqlParameter("@pasword", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.pasword
                    };

                    var par3 = new SqlParameter("@cities", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.cities
                    };

                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool DeleteUser(int iduser)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "deleteuser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@iduser", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = iduser
                    };

                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());

                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool UpdateUser(int iduser, User user)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "updateuser",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@iduser", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Input,
                        Value = iduser
                    };

                    var par2 = new SqlParameter("@mail", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.mail
                    };

                    var par3 = new SqlParameter("@pasword", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.pasword
                    };

                    var par4 = new SqlParameter("@cities", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = user.cities
                    };

                    var par5 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par3);
                    command.Parameters.Add(par4);
                    command.Parameters.Add(par5);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());


                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool Exist(string mail)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "exist",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@mail", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = mail
                    };

                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());

                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }

        public bool Verify(string mail, string pasword)
        {
            var result = false;
            try
            {
                if (_client.Open())
                {
                    var command = new SqlCommand
                    {
                        Connection = _client.Conecction,
                        CommandText = "verify",
                        CommandType = CommandType.StoredProcedure
                    };

                    var par1 = new SqlParameter("@mail", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = mail
                    };

                    var par2 = new SqlParameter("@pasword", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Input,
                        Value = pasword
                    };

                    var par4 = new SqlParameter("@haserror", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(par1);
                    command.Parameters.Add(par2);
                    command.Parameters.Add(par4);

                    command.ExecuteNonQuery();

                    result = !Convert.ToBoolean(command.Parameters["@haserror"].Value.ToString());

                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                _client.Close();
            }

            return result;
        }
    }
}
