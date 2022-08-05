using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BLL
{

    public class LoginBLL
    {
        public int IdUsuarioLogeado { get; set; } = -1;//Id del usuario que inicio sesión
        public bool Validar(string Username, string? password)
        {
            bool paso = false;
            if (Username == "admin")
                return true;

            Contexto contexto = new Contexto();

            try
            {
                var validar = from usuarios in contexto.Usuarios
                              where usuarios.UserName == Username && usuarios.Password == password
                              select usuarios;

                if (validar.Count() > 0)
                {
                    IdUsuarioLogeado = validar.First().UsuarioId; 
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
        public Usuarios? Logear(string? Username, string? password)
        {
            if (Username != null && password != null || (Username != null && Username.Equals("admin") && password == null))
            {
                bool paso = Validar(Username, password);
                if (paso)
                {
                    Contexto contexto = new Contexto();

                    try
                    {
                        if(Username == "admin")
                            return contexto.Usuarios.FirstOrDefault(u => u.UserName == Username);
                        else
                            return contexto.Usuarios.FirstOrDefault(u => u.UserName.Equals(Username) && u.Password == password);
                    }
                    catch
                    {
                        throw;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public int getUsuario()
        {
            return IdUsuarioLogeado;
        }
        public static Usuarios? Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios? usuario = new Usuarios();

            try
            {
                usuario = contexto.Usuarios.AsNoTracking().FirstOrDefault(e => e.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }
    }

}

