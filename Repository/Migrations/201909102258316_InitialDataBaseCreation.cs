namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataBaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paises", t => t.PaisId)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                        PaisId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        CiudadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ciudades", t => t.CiudadId)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .ForeignKey("dbo.Paises", t => t.PaisId)
                .Index(t => t.PaisId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.CiudadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ciudades", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Usuarios", "PaisId", "dbo.Paises");
            DropForeignKey("dbo.Usuarios", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Usuarios", "CiudadId", "dbo.Ciudades");
            DropForeignKey("dbo.Departamentos", "PaisId", "dbo.Paises");
            DropIndex("dbo.Usuarios", new[] { "CiudadId" });
            DropIndex("dbo.Usuarios", new[] { "DepartamentoId" });
            DropIndex("dbo.Usuarios", new[] { "PaisId" });
            DropIndex("dbo.Departamentos", new[] { "PaisId" });
            DropIndex("dbo.Ciudades", new[] { "DepartamentoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Paises");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Ciudades");
        }
    }
}
