using Microsoft.EntityFrameworkCore;
using webapi.inlock.code.First.manha.Domains;

namespace webapi.inlock.code.First.manha.Context
{
    public class InlockContext : DbContext
    {
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        //Define as opcoes de construcao do banco(String Conexao)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE11-S13; DataBase= inlock_games_codeFirst_manha; User Id = sa; Pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
