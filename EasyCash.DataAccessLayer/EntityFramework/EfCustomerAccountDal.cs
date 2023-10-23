using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DataAccessLayer.Repos;
using EasyCash.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountDal : GenericRepo<CustomerAccount>, ICustomerAccountDal
    {
        public List<CustomerAccount> GetCustomerAccountsList(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccounts.Where(x => x.AppUserID == id).ToList();
            return values;
        }
    }
}
