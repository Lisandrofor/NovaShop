namespace NovaShop.Models
{
    public record Carrito
    {
      public Guid idCarrito {get; set;}
      public Guid idUsuario {get;set;}
      public Guid idProducto { get; set;}
      public int cantidad {get; set;}
      public decimal Subtotal{get; set;}
      
    }
}
