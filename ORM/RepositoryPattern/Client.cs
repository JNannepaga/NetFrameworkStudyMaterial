using RepositoryPattern.TargetMultiDB;
//using RepositoryPattern.TargetRepos;
using System;

namespace RepositoryPattern
{
    public class Client
    {
        public static void Main() 
        {

            TargetMultiDbImplementor.Encounter();
            //TargetReposImplementor.Encounter();
        }
    }
}
