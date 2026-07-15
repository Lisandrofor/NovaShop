namespace NovaShop.Models
{
    public record Producto
    {
      public long Id {get; set;}
      public string Descripcion { get; set; } = string.Empty;
      public DateTime Alta {get; set;}
      public int Stock {get; set;}
      
      public decimal Precio{get; set;}
      public int Categoría {get; set;}
    }

   public record CreateProductRequest(
   string Descripcion,
   int Stock,
   decimal Precio,
   string Categoria);
  


}