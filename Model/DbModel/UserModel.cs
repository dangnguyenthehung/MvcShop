using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DbModel
{
    public class UserModel
    {
        ShopdbContext context = null;

        public UserModel()
        {
            context = new ShopdbContext();
        }

        public int Insert(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();

            return entity.Id;
        } 

        public User GetByUserName(string userName)
        {
            return context.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public int Login(string UserName, string Password)
        {
            var result = context.Users.SingleOrDefault(x => x.UserName == UserName);

            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.C_Status == -1)
                {
                    return -1;
                }
                else
                {
                    if ( result.PW == Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
