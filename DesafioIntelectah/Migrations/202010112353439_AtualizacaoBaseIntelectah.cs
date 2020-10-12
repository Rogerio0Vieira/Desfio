namespace DesafioIntelectah.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoBaseIntelectah : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBCONSULTA",
                c => new
                    {
                        CODIGO_CONSULTA = c.Int(nullable: false, identity: true),
                        ID_PACIENTE_CONSULTA = c.Int(nullable: false),
                        ID_EXAME_CONSULTA = c.Int(nullable: false),
                        DATA_HORA_CONSULTA = c.DateTime(nullable: false),
                        HorasConsulta = c.Int(nullable: false),
                        MinutosConsulta = c.Int(nullable: false),
                        PROTOCOLO_CONSULTA = c.String(),
                    })
                .PrimaryKey(t => t.CODIGO_CONSULTA);
            
            CreateTable(
                "dbo.TBEXAME",
                c => new
                    {
                        CODIGO_EXAME = c.Int(nullable: false, identity: true),
                        ID_TIPO_EXAME = c.Int(nullable: false),
                        NOME_EXAME = c.String(nullable: false, maxLength: 100),
                        OBSERVACAO_EXAME = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.CODIGO_EXAME);
            
            CreateTable(
                "dbo.TBPACIENTE",
                c => new
                    {
                        CODIGO_PACIENTE = c.Int(nullable: false, identity: true),
                        NOME_PACIENTE = c.String(nullable: false, maxLength: 100),
                        CPF_PACIENTE = c.String(nullable: false, maxLength: 14),
                        NASCIMENTO_PACIENTE = c.DateTime(nullable: false),
                        SEXO_PACIENTE = c.String(nullable: false, maxLength: 10),
                        TELEFONE_PACIENTE = c.String(nullable: false, maxLength: 14),
                        EMAIL_PACIENTE = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CODIGO_PACIENTE);
            
            CreateTable(
                "dbo.TBTIPOEXAME",
                c => new
                    {
                        CODIGO_TP_EXAME = c.Int(nullable: false, identity: true),
                        NOME_TP_EXAME = c.String(nullable: false, maxLength: 100),
                        DESCRICAO_TP_EXAME = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.CODIGO_TP_EXAME);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBTIPOEXAME");
            DropTable("dbo.TBPACIENTE");
            DropTable("dbo.TBEXAME");
            DropTable("dbo.TBCONSULTA");
        }
    }
}
