﻿using domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace infra.Mappings
{
    class NivelMap : EntityTypeConfiguration<Nivel>
    {
        public NivelMap()
        {
            ToTable("Nivel");
            HasKey(x => x.Id);
            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            Property(x => x.Id)
.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



        }
    }
}
