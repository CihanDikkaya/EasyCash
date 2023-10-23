using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DataAccessLayer.Repos;
using EasyCash.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepo<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(y => y.SenderCustomer).Include(ı=>ı.ReceiverCustomer)
                .ThenInclude(z => z.AppUser)
                .Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}
