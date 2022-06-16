using Microsoft.EntityFrameworkCore;
using Models;
using DAL;
using System.Linq;

namespace BLL
{
    public class PagosBLL
    {
        private static bool Insertar(Pagos pago){
            bool paso = false;
			Contexto contexto = new Contexto();
			try
			{
				contexto.Pagos.Add(pago);
				paso = contexto.SaveChanges() > 0;
			}catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return paso;
        }
        public static string? ExisteNombreCliente(string NombreCliente)
		{
			Contexto contexto = new Contexto();
			string? NombreClienteEnco = null;
			try
			{
				var contrato = contexto.Pagos.Where(p => p.NombreCliente == NombreCliente).FirstOrDefault();
				NombreClienteEnco =(contrato!=null)? contrato.NombreCliente: null;
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return NombreCliente;
       
        
         }
         public static string? ExisteApellidoCliente(string ApellidoCliente)
		{
			Contexto contexto = new Contexto();
			string? ApellidoClienteEnco = null;
			try
			{
				var contrato = contexto.Pagos.Where(p => p.ApellidoCliente == ApellidoCliente).FirstOrDefault();
				ApellidoClienteEnco =(contrato!=null)? contrato.ApellidoCliente: null;
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return ApellidoClienteEnco;
       
        
         }
         private static bool Modificar(Pagos pago)
		{
			bool paso = false;
			Contexto contexto = new Contexto();

			try
			{
				contexto.Entry(pago).State = EntityState.Modified;
				paso = contexto.SaveChanges() > 0;
			}
			catch
			{
				throw;
			}finally
			{
				contexto.Dispose();
			}
			return paso;
		} 
        private static bool Existe(int? Id)
		{
			Contexto contexto = new Contexto();
			bool existe = false;

			try
			{
				existe = contexto.Pagos.Any(pago => pago.PagoId == Id);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return existe;
		}
        public static bool Guardar(Pagos pago)
		{
			if (Existe(pago.PagoId))
				return Modificar(pago);
			else
				return Insertar(pago);
		}
        public static Pagos? Buscar(int? PagoId)
		{
			Contexto contexto = new Contexto();
			Pagos? pago;
			try
			{
				pago = contexto.Pagos.Find(PagoId);
			}
			catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();
			}
			return pago;
		}
        public static bool Eliminar(int? PagoId)
		{
			Contexto contexto = new Contexto();
			bool paso = false;

			try
			{
				var pago = contexto.Pagos.Find(PagoId);
				if(pago!=null) 
				{
					contexto.Pagos.Remove(pago);
					paso = contexto.SaveChanges()>0;
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

    
}
}