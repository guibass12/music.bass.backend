using domain;
using System.Data.Entity.ModelConfiguration;

namespace infra.Mappings
{
    class AulaMap : EntityTypeConfiguration<Aula>
    {
        public AulaMap()
        {
            ToTable("Aula");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            HasRequired(x => x.Nivel);

        }
    }
}
