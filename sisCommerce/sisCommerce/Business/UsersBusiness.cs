using sisCommerce.Models;
using sisCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Business
{
    public class UsersBusiness
    {
        private Users user;
        private UsersRepository uRepository;
        public CurrentUser cUser;

        public UsersBusiness(Users user)
        {
            this.user = user;
            uRepository = new UsersRepository();
        }

        public CurrentUser UserValidate()
        {
           var result = uRepository.findUserByParams(this.user);
           
           if(result != null)
           {
                //session user by injection object
                this.cUser = new CurrentUser(result.id, result.name, result.user, result.password);
                //this.cUser.setUserSession();
                return this.cUser;
           }

           return this.cUser;
        }

        public void clearSessionUser() { 
            cUser = new CurrentUser();
            cUser.clearUserSession();
        }
    }
}