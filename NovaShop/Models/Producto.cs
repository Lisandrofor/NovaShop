namespace NovaShop.Models
{
    public record Producto
    {
      public Guid Id {get; set;}
      public string Descripcion { get; set; } = string.Empty;
      public DateTime Alta {get; set;}
      public int Stock {get; set;}
      
      public decimal Precio{get; set;}
      public int Categoría {get; set;}
    }


}