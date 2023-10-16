using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Repos;
using EasyCash.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepo<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
    }
}
