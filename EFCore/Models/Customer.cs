using System.Collections;
using System.Collections.Generic;

namespace EFCore.Models
{
	public class Customer
	{
		#nullable enable
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNo { get; set; }
		#nullable disable

		public ICollection<Order> Order { get; set; }
	}
}