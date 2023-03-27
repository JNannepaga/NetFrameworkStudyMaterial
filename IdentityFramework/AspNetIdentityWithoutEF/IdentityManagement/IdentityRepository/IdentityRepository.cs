using IdentityOwinIntegrationWithoutEF.Models;
using IdentityOwinIntegrationWithoutEF.SQLAdapter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class IdentityRepository :
        IRepository<Models.MyUser>,
        IRepository<Models.MyRole>,
        IRepository<Models.MyUserLogins>,
        IIdentityRepository
    {
        private readonly SqlAdapterEF _sqlAdapterEF;
        public IdentityRepository(SqlAdapterEF sqlAdapter)
        {
            _sqlAdapterEF = sqlAdapter;
            _sqlAdapterEF.SpBinder = (DbModelBuilder modelBuilder) =>
            {
                modelBuilder.Entity<MyUser>()
                    .HasMany<MyRole>(u => u.Roles)
                    .WithMany(r => r.Users)
                    .Map(ru =>
                    {
                        ru.MapLeftKey("UserRefId");
                        ru.MapRightKey("RolesRefId");
                        ru.ToTable("MyUserRoles");
                    });
            };

            //SP for Insert into MyUserRoles
        }

        #region UserManager
        MyUser IRepository<MyUser>.NewEntity => throw new NotImplementedException();
        void IRepository<MyUser>.Add(MyUser item)
        {
            foreach (Role role in item.Roles)
            {
                this._sqlAdapterEF.Roles.Attach(role);
            }
            _sqlAdapterEF.Set<MyUser>().Add(item);
        }

        IEnumerable<MyUser> IRepository<MyUser>.Filter(Expression<Func<MyUser, bool>> predicate)
        {
            return _sqlAdapterEF.Set<MyUser>().Where(predicate);
        }


        MyUser IRepository<MyUser>.Get(int Id)
        {
            return _sqlAdapterEF.Set<MyUser>().Find(Id);
        }

        MyUser IRepository<MyUser>.Get(string name)
        {
            return _sqlAdapterEF.Set<MyUser>().FirstOrDefault(x => x.UserName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        void IRepository<MyUser>.Remove(MyUser item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region UserLoginManager

        void IRepository<MyUserLogins>.Add(MyUserLogins item)
        {
            this._sqlAdapterEF.Users.Attach(item.User);
           _sqlAdapterEF.Set<MyUserLogins>().Add(item);
        }

        void IRepository<MyUserLogins>.Remove(MyUserLogins item)
        {
            throw new NotImplementedException();
        }

        MyUserLogins IRepository<MyUserLogins>.Get(int Id)
        {
            return _sqlAdapterEF.Set<MyUserLogins>().Find(Id);
        }

        MyUserLogins IRepository<MyUserLogins>.Get(string name)
        {
            return _sqlAdapterEF.Set<MyUserLogins>().Find(name);
        }

        IEnumerable<MyUserLogins> IRepository<MyUserLogins>.Filter(Expression<Func<MyUserLogins, bool>> predicate)
        {
            return _sqlAdapterEF.Set<MyUserLogins>().Where(predicate);
        }
        #endregion

        #region RoleManager

        MyRole IRepository<MyRole>.NewEntity => throw new NotImplementedException();

        MyUserLogins IRepository<MyUserLogins>.NewEntity => throw new NotImplementedException();

        void IRepository<MyRole>.Add(MyRole item)
        {
            _sqlAdapterEF.Set<MyRole>().Add(item);
        }

        MyRole IRepository<MyRole>.Get(string name)
        {
            return _sqlAdapterEF.Set<MyRole>().Find(name);
        }
        void IRepository<MyRole>.Remove(MyRole item)
        {
            throw new NotImplementedException();
        }

        MyRole IRepository<MyRole>.Get(int Id)
        {
            return _sqlAdapterEF.Set<MyRole>().Find(Id);
        }

        IEnumerable<MyRole> IRepository<MyRole>.Filter(Expression<Func<MyRole, bool>> predicate)
        {
            return _sqlAdapterEF.Set<MyRole>().Where(predicate);
        }
        #endregion

        #region Behavioural Implementations
        public IList<MyRole> GetUserRoles(int userId)
        {
            return this._sqlAdapterEF.Users.FirstOrDefault(x => x.Id == userId)?.Roles.ToList<MyRole>();
                //Select<MyRole>("", new SqlParameter("userId", userId)).ToList();
        }

        public MyUser FindUserByEmail(string email)
        {
            return this._sqlAdapterEF.Users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

    }
}