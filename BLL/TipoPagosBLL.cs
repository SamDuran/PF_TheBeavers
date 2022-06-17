using Microsoft.EntityFrameworkCore;
using System;
using Models;
using DAL;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class TipoPagosBLL
    {
        public static TipoPagos? Buscar(int? TipoPagoId) 
		{
			Contexto contexto = new Contexto();
			TipoPagos? pag;
			try
			{
				pag = contexto.TipoPagos.Find(TipoPagoId);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return pag;
		}
        public static List<TipoPagos> GetList()
        {
            Contexto contexto = new Contexto();
            List<TipoPagos> lista;
            try
            {
                lista = contexto.TipoPagos.AsNoTracking().ToList();
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