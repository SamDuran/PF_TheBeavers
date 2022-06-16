using Microsoft.EntityFrameworkCore; //Para setear los estados de las entidades
using System.Linq.Expressions;       //Para filtrar en la consulta
using System.Linq;					 //Para expresiones lambdas
using Models;                        //Para utilizar nuestras entidades
using DAL;                           //Para utilizar el contexto

namespace BLL
{
	public class ContratosBLL// CRUD de Contratos = Create, Read, Update & Delete 
	{
		private static bool Insertar(Contratos contrato)
		{
			bool paso = false;
			Contexto contexto = new Contexto();
			try
			{
				contexto.Contratos.Add(contrato);
				paso = contexto.SaveChanges() > 0;
			}catch
			{
				throw;
			}
			finally
			{
				contexto.Dispose();//Para cerrar el contexto
			}
			return paso;
		}//Create
		public static Contratos? ExisteCedula(string Cedula)
		{
			Contexto contexto = new Contexto();
			Contratos? contrato;
			try
			{
				contrato = contexto.Contratos.Where(c => c.Cedula == Cedula)
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
			return contrato;
		}//ExisteNoContrato
		private static bool Modificar(Contratos contrato)
		{
			bool paso = false;
			Contexto contexto = new Contexto();

			try
			{
				contexto.Entry(contrato).State = EntityState.Modified;
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
		} //Update
		private static bool Existe(int? Id)
		{
			Contexto contexto = new Contexto();
			bool existe = false;

			try
			{
				existe = contexto.Contratos.Any(contrato => contrato.ContratoId == Id);
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
		public static bool Guardar(Contratos contrato)
		{
			if (Existe(contrato.ContratoId))
				return Modificar(contrato);
			else
				return Insertar(contrato);
		}
		public static Contratos? Buscar(int? ContratoId)
		{
			Contexto contexto = new Contexto();
			Contratos? contrato;
			try
			{
				contrato = contexto.Contratos.Where(c =>c.ContratoId == ContratoId)
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
			return contrato;
		}//Read
		public static bool Eliminar(int? ContratoId)
		{
			Contexto contexto = new Contexto();
			bool paso = false;

			try
			{
				var contrato = contexto.Contratos.Find(ContratoId);
				if(contrato!=null) //Si encontro un contrato con ese ID
				{
					contexto.Contratos.Remove(contrato);
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
		}//Delete
	}
}