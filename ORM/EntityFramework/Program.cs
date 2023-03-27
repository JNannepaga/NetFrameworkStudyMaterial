using EFAnnotationAttribute = EntityFramework.DataAnnotationAttribute.OnetoOneMapping;
using EFFluentAPI = EntityFramework.FluentAPI.OnetoOneMapping;
using EntityFramework.TPH;
using System;
using EntityFramework.DisconnectedArch;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //TPHImplementor.Encounter();
            //EFAnnotationAttribute.OnetoOneImplementor.Encounter();
            //EFFluentAPI.OnetoOneImplementor.Encounter();
            //EntityFramework.DataAnnotationAttribute.OnetoManyMapping.OnetoManyImplementor.Encounter();
            //EntityFramework.FluentAPI.OnetoManyMapping.OnetoManyImplementor.Encounter();
            //EntityFramework.DataAnnotationAttribute.ManytoManyMapping.ManytoManyImplementor.Encounter();
            EntityFramework.FluentAPI.ManytoManyMapping.ManytoManyImplementor.Encounter();
            //DiscImplementor.Encounter();
            Console.ReadKey();
        }
    }
}
