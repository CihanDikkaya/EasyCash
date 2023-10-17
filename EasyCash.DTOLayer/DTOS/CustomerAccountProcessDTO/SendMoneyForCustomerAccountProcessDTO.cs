using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DTOLayer.DTOS.CustomerAccountProcessDTO
{
    public class SendMoneyForCustomerAccountProcessDTO
    {

        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }

        public int SenderID { get; set; }
        public string ReciverAccountNumber { get; set; }
        public int ReceiverID { get; set; }
        public string Description { get; set; }

    }
}
