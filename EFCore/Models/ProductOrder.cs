namespace EFCore.Models
{
	public class ProductOrder
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public int ProductId { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; }
		public Products Product { get; set; }
	}
}