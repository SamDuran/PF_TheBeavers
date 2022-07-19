using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Models;
using DAL;

namespace BLL
{
    public class TecnicosBLL
    {
        public static void Guardar(Tecnicos tecnico)
        {
            if (!Existe(tecnico.Id))
                Insertar(tecnico);
            else
                Modificar(tecnico);
        }
        private static bool Insertar(Tecnicos tecnico)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Tecnicos.Add(tecnico);
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
        private static bool Modificar(Tecnicos tecnico)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(tecnico).State = EntityState.Modified;
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
                encontrado = contexto.Tecnicos.Any(c => c.Id == id);
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
        public static Tecnicos? BuscarCarnet(string Carnet)
        {
            Contexto contexto = new Contexto();
            Tecnicos? tecnico = new Tecnicos();
            try
            {
                tecnico = contexto.Tecnicos.AsNoTracking().FirstOrDefault(c => c.NoCarnet == Carnet);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tecnico;
        }
        public static Tecnicos? Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tecnicos? tecnico;
            try
            {
                tecnico = contexto.Tecnicos.Where(c => c.Id == id)
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
            return tecnico;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var tecnico = contexto.Tecnicos.Find(id);
                if (tecnico != null)
                {
                    contexto.Entry(tecnico).State = EntityState.Deleted;
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
        public static List<Tecnicos> GetList(Expression<Func<Tecnicos , bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Tecnicos> lista;
            try
            {
                lista = contexto.Tecnicos.Where(criterio)
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