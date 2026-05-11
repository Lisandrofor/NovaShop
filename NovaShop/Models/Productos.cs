namespace NovaShop.Models
{
    public record Productos
    {
      public Guid Id {get; set;}
      public String Descripcion {get; set;}
      public Data time Alta {get; set;}
      public int Stock {get; set;}
      

      
    }


}