
using NovaShop.Data;
using NovaShop.Interfaces.Repositorios;
using NovaShop.Models;
using System;

namespace NovaShop.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteEmail(string email)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Email == email);
        }

        public async Task Guardar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObtenerPorId(long id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}