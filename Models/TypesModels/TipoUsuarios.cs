using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System;

namespace Models
{
	public class TipoUsuarios
	{
		[Key]
		public int Id { get; set; }// 1 admin, 2 usuario comun, 3 call center, no se cuales mas, despues se agregan xD 
		public string Tipo { get; set; } = string.Empty;
	}
}
