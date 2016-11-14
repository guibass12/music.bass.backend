using domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Mappings
{
    class ConteudoAulaMap : EntityTypeConfiguration<ConteudoAula>
    {
        public ConteudoAulaMap()
        {
            ToTable("ConteudoAula");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            
            HasRequired(x => x.Aula);

        }
    }
}
