using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BLL
{
    public static partial class UsuariosBLL
    {
        private static bool Existe(int id)
        {
            bool existe = false;
            Contexto contexto = new Contexto();

            try
            {
                existe = contexto.Usuarios.Any(u => u.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return existe;
        }
        public static bool Guardar(Usuarios usuario)
        {
            if (Existe(usuario.UsuarioId))
                return Modificar(usuario);
            else
                return Insertar(usuario);
        }
        private static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
                contexto.Entry(usuario).State = EntityState.Detached;
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
        private static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Usuarios.Add(usuario);
                paso = contexto.SaveChanges() > 0;
                contexto.Entry(usuario).State = EntityState.Detached;
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static Usuarios? Buscar(int id)
        {
            Usuarios? usuario;
            Contexto contexto = new Contexto();

            try
            {
                usuario = contexto.Usuarios
                .Where(t => t.UsuarioId == id)
                .AsNoTracking()
                .FirstOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var usuario = contexto.Usuarios.Find(id);
                if (usuario != null)
                {
                    usuario.Existente = false;
                    contexto.Entry(usuario).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                    contexto.Entry(usuario).State = EntityState.Detached;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool EliminarPermanentemente(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var usuario = contexto.Usuarios.Find(id);
                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);
                    paso = contexto.SaveChanges() > 0;
                    contexto.Entry(usuario).State = EntityState.Detached;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static List<Usuarios> GetListExistentes(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuarios
                .Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista.Where(u => u.Existente).ToList();
        }
        public static List<Usuarios> GetAllUsers(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Usuarios
                .Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}