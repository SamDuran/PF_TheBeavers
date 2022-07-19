using Microsoft.EntityFrameworkCore; //Para setear los estados de las entidades
using System.Collections.Generic;
using System.Linq.Expressions;       //Para filtrar en la consulta
using System.Linq;					 //Para expresiones lambdas
using Models;                        //Para utilizar nuestras entidades
using DAL;                           //Para utilizar el contexto

namespace BLL
{
    public class TipoAveriasBLL
    {
        public static TipoAverias? Buscar(int? AveriaId) 
		{
			Contexto contexto = new Contexto();
            TipoAverias? averia;
			try
			{
				averia = contexto.TipoAverias.Find(AveriaId);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return averia;

            
		}//Read
        public static List<TipoAverias> GetList()
        {
            Contexto contexto = new Contexto();
            List<TipoAverias> lista;
            try
            {
                lista = contexto.TipoAverias.
                AsNoTracking()
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