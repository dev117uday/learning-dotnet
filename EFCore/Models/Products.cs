using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
	public class Products
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Column(TypeName = "decimal(10,2)")]
		public decimal Price { get; set; }
	}
}