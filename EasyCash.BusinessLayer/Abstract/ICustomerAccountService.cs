using EasyCash.DataAccessLayer.Abstract;
using EasyCash.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.BusinessLayer.Abstract
{
    public interface ICustomerAccountService : IGenericService<CustomerAccount>
    {
        public List<CustomerAccount> TGetCustomerAccountsList(int id);
    }
}
