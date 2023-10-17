using EasyCash.BusinessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DTOLayer.DTOS.CustomerAccountProcessDTO;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDTO sendMoneyForCustomerAccountProcessDTO)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where
                (x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDTO.ReciverAccountNumber)
                .Select(s => s.CustomerAccountID).FirstOrDefault();


            var senderAccountNumberID = context.CustomerAccounts.Where(x => x.AppUserID == user.Id).Where(ı => ı.CustomerAccountCurrency == "Türk Lirası")
                .Select(g => g.CustomerAccountID).FirstOrDefault();

            var val = new CustomerAccountProcess();

            val.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            val.SenderID = senderAccountNumberID;
            val.ProcessType = "Havale";
            val.ReceiverID = receiverAccountNumberID;
            val.Amount = sendMoneyForCustomerAccountProcessDTO.Amount;

            _customerAccountProcessService.TInsert(val);



            return RedirectToAction("Index", "Deneme");
        }




    }
}
