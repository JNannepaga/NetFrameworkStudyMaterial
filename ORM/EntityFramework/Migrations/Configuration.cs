namespace EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFramework.DataAnnotationAttribute.ManytoManyMapping.OrmManager.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EntityFramework.DataAnnotationAttribute.ManytoManyMapping.OrmManager.ApplicationDbContext";
        }

        protected override void Seed(EntityFramework.DataAnnotationAttribute.ManytoManyMapping.OrmManager.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
