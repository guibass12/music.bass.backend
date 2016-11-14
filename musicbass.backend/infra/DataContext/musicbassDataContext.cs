using domain;
using infra.Mappings;
using System.Data.Entity;

namespace infra.DataContext
{
    public class musicbassDataContext : DbContext
    {
        public musicbassDataContext() : base("musicbassConnectionString") {
           Database.SetInitializer<musicbassDataContext>(new musicbassDataContextInitiaizer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false; 
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
        protected override void Seed(musicbassDataContext context)
        {
            context.Niveis.Add(new Nivel {Nome = "Básico" });
            context.Niveis.Add(new Nivel { Nome = "Intermediário" });
            context.Niveis.Add(new Nivel { Nome = "Profissional" });
            context.SaveChanges();

            context.Aulas.Add(new Aula { Nome = "Aula 1", NivelId = 1 });
            context.Aulas.Add(new Aula { Nome = "Aula 1", NivelId = 2 });
            context.Aulas.Add(new Aula { Nome = "Aula 1", NivelId = 3 });
            context.SaveChanges();

            base.Seed(context);
        }
    }

    
}
