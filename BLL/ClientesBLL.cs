using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Models;
using DAL;

namespace BLL
{
    public class ClientesBLL
    {
        public static void Guardar(Clientes cliente)
        {
            if (!Existe(cliente.Id))
                Insertar(cliente);
            else
                Modificar(cliente);
        }
        private static bool Insertar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Clientes.Add(cliente);
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Modificar(Clientes cliente)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {//encontrato es true si es diferente de null
                encontrado = contexto.Clientes.Any(c => c.Id == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static Clientes? BuscarCedula(string cedula)
        {
            Contexto contexto = new Contexto();
            Clientes? cliente = new Clientes();
            try
            {
                cliente = contexto.Clientes.AsNoTracking().FirstOrDefault(c => c.Cedula == cedula);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }
        public static Clientes? Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes? cliente;
            try
            {
                cliente = contexto.Clientes.Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return cliente;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var cliente = contexto.Clientes.Find(id);
                if (cliente != null)
                {
                    contexto.Entry(cliente).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static List<Clientes> GetList(Expression<Func<Clientes , bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Clientes> lista;
            try
            {
                lista = contexto.Clientes.Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch
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