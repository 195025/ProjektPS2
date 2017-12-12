using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;

namespace DotNetAppSqlDb.Models
{
    public class MyDatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        public DbSet<Projekt.Models.Type> Types { get; set; }
        public DbSet<Projekt.Models.Book> Books { get; set; }


        public MyDatabaseContext() : base("name=MyDatabase")
        {
            Database.SetInitializer<MyDatabaseContext>(new CreateDatabaseIfNotExists<MyDatabaseContext>());
        }


        public List<PropertyInfo> GetDbSetProperties()
        {
            var dbSetProperties = new List<PropertyInfo>();
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                var setType = property.PropertyType;

                var isDbSet = setType.IsGenericType && (typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()));

                if (isDbSet)
                {
                    dbSetProperties.Add(property);
                }
            }

            return dbSetProperties;

        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyDatabaseContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Projekt.Models.Book>().ToTable("Books");
            modelBuilder.Entity<Projekt.Models.Type>().ToTable("Type");
        }
    }
}
