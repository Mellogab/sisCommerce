using sisCommerce.Models;
using sisCommerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sisCommerce.Business
{
    public class GroupsBusiness
    {

        private Groups group;
        private GroupsRepository gRepository;

        public GroupsBusiness(Groups groups)
        {
            this.group.id = group.id;
            this.group.name = group.name;
        }

        public Groups validatePermissionsAdministrator()
        {
            gRepository = new GroupsRepository(this.group);
            return gRepository.findGroupById();
        }

        public Groups validatePermissionsDefault()
        {
            gRepository = new GroupsRepository(this.group);
            return gRepository.findGroupById();
        }

        public Groups validatePermissionsFinancial()
        {
            gRepository = new GroupsRepository(this.group);
            return gRepository.findGroupById();
        }
    }
}