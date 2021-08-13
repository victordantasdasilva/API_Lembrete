namespace API_Lembretes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adiciona_Lembrete : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(maxLength: 255),
                        Prioridade = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarefas");
        }
    }
}
