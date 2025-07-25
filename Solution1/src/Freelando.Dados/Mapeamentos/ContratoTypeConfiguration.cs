﻿using Freelando.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelando.Dados.Mapeamentos;
internal class ContratoTypeConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> entity)
    {
        entity.ToTable("TB_Contratos");
        entity.Property(e => e.Id).HasColumnName("ID_Contrato");
        entity.Property(e => e.ProfissionalId).HasColumnName("ID_Profissional");
        entity.Property(e => e.ServicoId).HasColumnName("ID_Servico");
        entity.OwnsOne(e => e.Vigencia, vigencia =>
        {
            vigencia.Property(v => v.DataInicio).HasColumnName("Data_Inicio");
            vigencia.Property(v => v.DataEncerramento).HasColumnName("Data_Encerramento");
        });
        entity.HasOne(e => e.Servico).WithOne(e => e.Contrato).HasForeignKey<Contrato>(e => e.Id);
        entity.HasOne(e => e.Profissional).WithMany(e => e.Contratos).HasForeignKey(e => e.ProfissionalId);



    }
}
