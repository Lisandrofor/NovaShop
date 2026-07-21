using Dapper;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.Sqlite;

namespace NovaShop.Data
{
    public class DatabaseInitializer
    {
        private readonly DbConnection _connectionBase;

        public DatabaseInitializer(DbConnection connectionBase)
        {
            _connectionBase = connectionBase;
        }

        public void Initialize()
        {
            using var connection = _connectionBase.CreateConnection(); ;

            connection.Open();

            connection.Execute("""
                CREATE TABLE IF NOT EXISTS Usuario (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    Nombre      TEXT NOT NULL,
                    Apellido    TEXT NOT NULL,
                    Dni         INTEGER NOT NULL,
                    Perfil      INTEGER NOT NULL,
                    Email       TEXT NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                );
                CREATE TABLE IF NOT EXISTS Producto (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    Descripcion      TEXT NOT NULL,
                    Stock         INTEGER NOT NULL,
                    Precio       DECIMAL NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                );
            CREATE TABLE IF NOT EXISTS  ItemVentas(
                    Id               BIGINT PRIMARY KEY AUTOINCREMENT,
                    IdUsuario        BIGINT ,
                    IdProducto       BIGINT ,
                    IdOrdenVenta      BIGINT ,
                    Cantidad         INTEGER NOT NULL,
                    PrecioUnitario   DECIMAL NOT NULL,
                    EstadoOrden      TEXT NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                    FOREIGN KEY (IdOrdenVenta)
                    REFERENCES OrdenVentas(Id)
                );
            CREATE TABLE IF NOT EXISTS ItemCarrito (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    IdProducto  BIGINT NOT NULL,
                    Cantidad    INTEGER NOT NULL,
                    Total       DECIMAL NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                    FOREIGN KEY (IdProducto)
                    REFERENCES Producto(Id)
                );
            CREATE TABLE IF NOT EXISTS Notificaciones (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    IdUsuario   BIGINT NOT NULL,
                    Mensaje     TEXT NOT NULL,
                    IdTipo      INTEGER NOT NULL,
                    Enviada     BOOLEAN NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                    FOREIGN KEY (IdTipo)
                    REFERENCES TipoNotificacion(Id)

                );
            CREATE TABLE IF NOT EXISTS OrdenVentas (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    IdUusario      BIGINT NOT NULL,
                    IdEstado    INTEGER NOT NULL,
                    Total       DECIMAL NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT

                    FOREIGN KEY (IdUsuario)
                    REFERENCES Usuario(Id),
                    FOREIGN KEY (IdEstado)
                    REFERENCES EstadoId(Id)
                );
            CREATE TABLE IF NOT EXISTS Carrito (
                    Id          BIGINT PRIMARY KEY AUTOINCREMENT,
                    IdUsuario      BIGINT NOT NULL,
                    IdItemCarrito  BIGINT NOT NULL,
                    Subtotal       DECIMAL NOT NULL,
                    CantidadTotal  INTEGER NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                    FOREIGN KEY (IdUsuario)
                    REFERENCES Usuario(Id),
                    FOREIGN KEY(IdItemCarrito)
                    REFERENCES ItemCarrito(Id)

                );
            CREATE TABLE IF NOT EXISTS Perfiles (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descripcion      TEXT NOT NULL,
                    CreatedAt   TEXT NOT NULL,
                    UpdatedAt   TEXT
                );

            """);
        }
    }
}