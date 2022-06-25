using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Models;
using DAL;

namespace BLL
{

    public class LoginBLL
    {

        public static bool Validar(string Username, string password)
        {
            bool paso = false;
            
            Contexto contexto = new Contexto();

            try
            {
                var validar = from usuarios in contexto.Usuarios
                              where usuarios.UserName == Username && usuarios.Password == password
                              select usuarios;

                if (validar.Count() > 0)
                {
                    paso = true;
                }
                else
                {
                    paso = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

    }

}

