using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minimus.DB;
using Minimus.Models;

namespace Minimus.Services
{
    public class UserService
    {
        private readonly UserDataService _userService;

        public UserService(string connectionString)
        {
            _userService = UserDataService.GetInstance(connectionString);
        }

        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        public string AddUser(User user)
        {
            try
            {
                return _userService.AddUser(user) ? "Amigo Add Successfully" : "Error Adding Amigo";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteUser(int iduser)
        {
            try
            {
                return _userService.DeleteUser(iduser) ? "Amigo Delete Successfully" : "Error in delete Amigo";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateUser(int iduser, User user)
        {
            try
            {
                return _userService.UpdateUser(iduser, user) ? "Amigo Update Successfully" : "Error in update Amigo";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Exist(string mail)
        {
            try
            {
                return _userService.Exist(mail) ? "Existe" : "No existe";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Verify(string mail, string pasword)
        {
            try
            {
                return _userService.Verify(mail,pasword) ? "Correcto" : "Incorrecto";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
