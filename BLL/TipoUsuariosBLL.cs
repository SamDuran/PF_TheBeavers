using Microsoft.EntityFrameworkCore; //Para setear los estados de las entidades
using System.Collections.Generic;
using System.Linq.Expressions;       //Para filtrar en la consulta
using System.Linq;					 //Para expresiones lambdas
using Models;                        //Para utilizar nuestras entidades
using DAL;                           //Para utilizar el contexto

namespace BLL
{
    public class TipoUsuariosBLL
    {
        public static TipoUsuarios? Buscar(int? TipoUsuarioId) 
		{
			Contexto contexto = new Contexto();
			TipoUsuarios? TipoUsuario;
			try
			{
				TipoUsuario = contexto.TipoUsuarios.Find(TipoUsuarioId);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return TipoUsuario;
		}//Read
        public static List<TipoUsuarios> GetList()
        {
            Contexto contexto = new Contexto();
            List<TipoUsuarios> lista;
            try
            {
                lista = contexto.TipoUsuarios.
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