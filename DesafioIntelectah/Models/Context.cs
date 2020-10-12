using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DesafioIntelectah.Models
{
    public class Context: DbContext
    {
        public Context() : base("Server=DESKTOP-UG2Q47C;Database=DesafioIntelectah;User Id=sa;Password=123456;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Tabela Paciente
            modelBuilder.Entity<Paciente>().ToTable("TBPACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.CodigoPaciente).HasColumnName("CODIGO_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.NomePaciente).HasColumnName("NOME_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.CpfPaciente).HasColumnName("CPF_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.DataNascimentoPaciente).HasColumnName("NASCIMENTO_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.SexoPaciente).HasColumnName("SEXO_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.TelefonePaciente).HasColumnName("TELEFONE_PACIENTE");
            modelBuilder.Entity<Paciente>().Property(p => p.EmailPaciente).HasColumnName("EMAIL_PACIENTE");

            //Tabela Tipo Exame
            modelBuilder.Entity<TipoExame>().ToTable("TBTIPOEXAME");
            modelBuilder.Entity<TipoExame>().Property(p => p.CodigoTipoExame).HasColumnName("CODIGO_TP_EXAME");
            modelBuilder.Entity<TipoExame>().Property(p => p.NomeTipoExame).HasColumnName("NOME_TP_EXAME");
            modelBuilder.Entity<TipoExame>().Property(p => p.DescricaoTipoExame).HasColumnName("DESCRICAO_TP_EXAME");

            //Tabela Exame
            modelBuilder.Entity<Exame>().ToTable("TBEXAME");
            modelBuilder.Entity<Exame>().Property(p => p.CodigoExame).HasColumnName("CODIGO_EXAME");
            modelBuilder.Entity<Exame>().Property(p => p.IdTipoExame).HasColumnName("ID_TIPO_EXAME");
            modelBuilder.Entity<Exame>().Property(p => p.NomeExame).HasColumnName("NOME_EXAME");
            modelBuilder.Entity<Exame>().Property(p => p.ObservacaoExame).HasColumnName("OBSERVACAO_EXAME");

            modelBuilder.Entity<Consulta>().ToTable("TBCONSULTA");
            modelBuilder.Entity<Consulta>().Property(p => p.CodigoConsulta).HasColumnName("CODIGO_CONSULTA");
            modelBuilder.Entity<Consulta>().Property(p => p.IdPaciente).HasColumnName("ID_PACIENTE_CONSULTA");
            modelBuilder.Entity<Consulta>().Property(p => p.IdExame).HasColumnName("ID_EXAME_CONSULTA");
            modelBuilder.Entity<Consulta>().Property(p => p.DataHoraConsulta).HasColumnName("DATA_HORA_CONSULTA");
            modelBuilder.Entity<Consulta>().Property(p => p.ProtocoloConsulta).HasColumnName("PROTOCOLO_CONSULTA");
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoExame> TiposExames { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
    }
}