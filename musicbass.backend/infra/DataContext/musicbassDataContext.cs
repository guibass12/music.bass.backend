using domain;
using infra.Mappings;
using System.Data.Entity;

namespace infra.DataContext
{
    public class musicbassDataContext : DbContext
    {
        public musicbassDataContext() : base("musicbassConnectionString") {
           // Database.SetInitializer<musicbassDataContext>(musicbassDataContextInitiaizer());
        }

        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<ConteudoAula> ConteudoAulas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NivelMap());
            modelBuilder.Configurations.Add(new AulaMap());
            modelBuilder.Configurations.Add(new ConteudoAulaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class musicbassDataContextInitiaizer: DropCreateDatabaseIfModelChanges<musicbassDataContext>
    {

    }

    
}
