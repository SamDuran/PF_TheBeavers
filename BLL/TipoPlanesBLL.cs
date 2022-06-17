using Microsoft.EntityFrameworkCore; //Para setear los estados de las entidades
using System.Collections.Generic;
using System.Linq.Expressions;       //Para filtrar en la consulta
using System.Linq;					 //Para expresiones lambdas
using Models;                        //Para utilizar nuestras entidades
using DAL;                           //Para utilizar el contexto

namespace BLL
{
    public class TipoPlanesBLL
    {
        public static TipoPlanes? Buscar(int? PlanId) 
		{
			Contexto contexto = new Contexto();
			TipoPlanes? plan;
			try
			{
				plan = contexto.TipoPlanes.Find(PlanId);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return plan;
		}//Read
        public static List<TipoPlanes> GetList()
        {
            Contexto contexto = new Contexto();
            List<TipoPlanes> lista;
            try
            {
                lista = contexto.TipoPlanes.
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