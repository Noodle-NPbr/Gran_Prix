using Gran_Prix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gran_Prix.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CaixaModel> caixa { get; set; }
        public DbSet<ClientesModel> clientes { get; set; }
        public DbSet<EstoqueModel> estoque { get; set;}
        public DbSet<FornecedorModel> fornecedor { get; set;}
        public DbSet<FuncionarioModel> funcionario { get; set; }
    }
}