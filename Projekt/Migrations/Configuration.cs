namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetAppSqlDb.Models.MyDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DotNetAppSqlDb.Models.MyDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var types = new Projekt.Models.Type[]
            {
                new Projekt.Models.Type { TypeName = "Dramat"},
                new Projekt.Models.Type { TypeName = "Thriller"},
                new Projekt.Models.Type { TypeName = "Akcja"}
            };

            foreach (Projekt.Models.Type type in types)
            {
                context.Types.AddOrUpdate(type);
            }

            context.SaveChanges();

            var books = new Projekt.Models.Book[]
            {
                new Projekt.Models.Book { Title = "NieHitler", Description = "Maras", Author = "A", TypeId = types.Single( s => s.TypeName == "Dramat").TypeId},
                 new Projekt.Models.Book { Title = "Hitler", Description = "To", Author = "B", TypeId = types.Single( s => s.TypeName == "Akcja").TypeId},
                 new Projekt.Models.Book { Title = "Hitler1", Description = "Chuj", Author = "C", TypeId = types.Single( s => s.TypeName == "Dramat").TypeId},
                  new Projekt.Models.Book { Title = "Hitler3", Description = "!", Author = "D", TypeId = types.Single( s => s.TypeName == "Thriller").TypeId},
            };

            foreach (Projekt.Models.Book book in books)
            {
                context.Books.AddOrUpdate(book);
            }

            context.SaveChanges();
        }
    }
}
