using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using Models;
using DAL;

namespace BLL
{
    public class AveriasBLL
    {
        public static bool Guardar(Averias averias)
        {
            if (Existe(averias.AveriaId))
                return Modificar(averias);
            else
                return Insertar(averias);
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
        private static bool Insertar(Averias averias)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                contexto.Averias.Add(averias);
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
        private static bool Modificar(Averias averias)
        {
            Contexto contexto = new Contexto();
            bool modificado = false;

            try
            {
                contexto.Entry(averias).State = EntityState.Modified;
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
        public static Averias? Buscar(int? id)
        {
            Contexto contexto = new Contexto();
            Averias? averias;

            try
            {
                averias = contexto.Averias.AsNoTracking().FirstOrDefault(p => p.AveriaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return averias;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var averias = contexto.Averias.Find(id);
                if (averias != null)
                {
                    contexto.Entry(averias).State = EntityState.Deleted;
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
        public static bool EliminarPermanente(int? id)
        {
            Contexto contexto = new Contexto();
            bool eliminado = false;

            try
            {
                var averias = contexto.Averias.Find(id);
                if (averias != null)
                {
                    contexto.Averias.Remove(averias);
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
        public static List<Averias> GetListNoExistentes(Expression<Func<Averias, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Averias> lista = new List<Averias>();

            try
            {
                lista = contexto.Averias.Where(criterio)
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
            return lista;
        }
        public static List<Averias> GetListExistentes(Expression<Func<Averias, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Averias> lista = new List<Averias>();

            try
            {
                lista = contexto.Averias.Where(criterio)
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
            return lista;
        }
    }
}