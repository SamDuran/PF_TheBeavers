using Microsoft.EntityFrameworkCore; //Para setear los estados de las entidades
using System.Collections.Generic;    //Para usar listas
using System.Linq.Expressions;       //Para filtrar en la consulta
using System.Linq;					 //Para expresiones lambdas
using System;						 //Para usar las "func"
using Models;                        //Para utilizar nuestras entidades
using DAL;                           //Para utilizar el contexto

namespace BLL
{
	public class ContratosBLL// CRUD de Contratos = Create, Read, Update & Delete 
	{
		private static bool Insertar(Contratos contrato)
		{
			bool paso = false;
			var cliente = ClientesBLL.BuscarCedula(contrato.Cedula);
			if(cliente==null)//Si el cliente no está registrado
			{
				cliente = new Clientes();
				cliente.Cedula = contrato.Cedula;
				cliente.Nombre = contrato.NombreCliente;
				cliente.Apellido = contrato.ApellidoCliente;
				ClientesBLL.Guardar(cliente);
			}
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
		public static Contratos? BuscarNoContrato(string NoContrato)
		{
			Contexto contexto = new Contexto();
			Contratos? contrato;
			try
			{
				contrato = contexto.Contratos.Where(c => c.NoContrato.Contains( NoContrato))
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
		public static bool Existe(int? Id)
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
				if(contrato!=null)
					ActualizarContrato(contrato);
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
		private static void ActualizarContrato(Contratos contrato)
		{
			var ultimopago = PagosBLL.Buscar(contrato.UltimoPagoId);
			var DiaQueDeberiaPagar = new DateTime(DateTime.Now.Year, DateTime.Now.Month, contrato.FechaCreacion.Day);
			var Hoy  = DateTime.Today;
			if(ultimopago==null && Hoy.Day - contrato.FechaCreacion.Day >=30)//si no hay pago y paso un mes de su creacion
			{
				contrato.Estado=1;
			}else if(ultimopago!=null && Hoy.Day-ultimopago.FechaPago.Day >30 )//Si hay pago y se generó un mes
			{
				if(contrato.Estado==1)
					return;
				
				contrato.Estado=1;
			}
			if(ultimopago!=null && Hoy.Day-ultimopago.FechaPago.Day >60 )//Si hay pago y se generó un mes
			{
				if(contrato.Estado==3)
					return;
				
				contrato.Estado=3;
			}


			Guardar(contrato);
		}
		public static bool Eliminar(int? ContratoId)
		{
			Contexto contexto = new Contexto();
			bool paso = false;

			try
			{
				var contrato = contexto.Contratos.Find(ContratoId);
				if(contrato!=null) //Si encontro un contrato con ese ID
				{
					contrato.Existente = false;
					contexto.Entry(contrato).State = EntityState.Modified;
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
		}//Delete
		public static bool EliminarPermanente(int? id)
		{
			Contexto contexto = new Contexto();
			bool paso = false;

			try
			{
				var contrato = contexto.Contratos.Find(id);
				if(contrato!=null) //Si encontro un contrato con ese ID
				{
					contexto.Contratos.Remove(contrato);

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
		public static List<Contratos> GetListExistentes(Expression<Func<Contratos, bool>> expression)
		{
			Contexto contexto = new Contexto();
			List<Contratos> contratos;
			try
			{
				contratos = contexto.Contratos.Where(expression)
				.AsNoTracking()
				.ToList();
				
				if(contratos!=null)
					foreach(var contrato in contratos)  ActualizarContrato(contrato);//actualiza todos los contratos

				contratos = contexto.Contratos.Where(expression)
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
			return contratos.Where(c=>c.Existente).ToList();
		}
		public static List<Contratos> GetListNoExistentes(Expression<Func<Contratos, bool>> expression)
		{
			Contexto contexto = new Contexto();
			List<Contratos> contratos;
			try
			{
				contratos = contexto.Contratos.Where(expression)
				.AsNoTracking()
				.ToList();
				
				if(contratos!=null)
					foreach(var contrato in contratos)  ActualizarContrato(contrato);//actualiza todos los contratos

				contratos = contexto.Contratos.Where(expression)
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
			return contratos.Where(c => !c.Existente).ToList();
		}
		public static List<Contratos> GetListSuspendidosNoExistentes(Expression<Func<Contratos, bool>> expression)
		{
			var lista = new List<Contratos>();
			lista = GetListNoExistentes(expression);

			return lista.Where(c => c.Estado == 2).ToList();
		}
		public static List<Contratos> GetListSuspendidosExistentes(Expression<Func<Contratos, bool>> expression)
		{
			var lista = new List<Contratos>();
			lista = GetListExistentes(expression);

			return lista.Where(c => c.Estado == 2).ToList();
		}
	}
}