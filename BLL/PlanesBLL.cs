using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Models;
using DAL;

namespace BLL
{
    public class PlanesBLL
    {
        public static bool Guardar(Planes plan)
        {
            if(Existe(plan.PlanId))
                return Modificar(plan);
            else
                return Insertar(plan);
        }
        private static bool Existe(int? id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Planes.Find(id) != null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        private static bool Insertar(Planes plan)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                contexto.Planes.Add(plan);
                guardado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }
        private static bool Modificar(Planes plan)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(plan).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }
        public static Planes? Buscar(int? id)
        {
            Contexto contexto = new Contexto();
            Planes? plan;

            try
            {
                plan = contexto.Planes.AsNoTracking().FirstOrDefault(p => p.PlanId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return plan;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var plan = contexto.Planes.Find(id);
                if(plan!=null)
                {
                    plan.Existente = false;
                    contexto.Entry(plan).State = EntityState.Modified;
                    eliminado = contexto.SaveChanges() > 0;
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
            return eliminado;
        }
        public static bool EliminarPermanente(int? id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var plan = contexto.Planes.Find(id);
                if(plan!=null)
                {
                    contexto.Planes.Remove(plan);
                    eliminado = contexto.SaveChanges() > 0;
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
            return eliminado;
        }
        public static List<Planes> GetListNoExistentes(Expression<Func<Planes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Planes> lista = new List<Planes>();

            try
            {
                lista = contexto.Planes.Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista.Where(p => p.Existente == false).ToList();
        }
        public static List<Planes> GetListExistentes(Expression<Func<Planes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Planes> lista = new List<Planes>();

            try
            {
                lista = contexto.Planes.Where(criterio)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista.Where(p => p.Existente).ToList();
        }
    }
}