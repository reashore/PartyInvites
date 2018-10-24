using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly PartyInvitesDbContext _partyInvitesDbContext;

        public HomeController(PartyInvitesDbContext partyInvitesDbContext) => _partyInvitesDbContext = partyInvitesDbContext;

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult Respond() => View();

        [HttpPost]
        public IActionResult Respond(GuestResponse guestResponse)
        {
            _partyInvitesDbContext.GuestResponses.Add(guestResponse);
            _partyInvitesDbContext.SaveChanges();
            return RedirectToAction(nameof(Thanks), new {guestResponse.Name, guestResponse.WillAttend});
        }

        [HttpGet]
        public IActionResult Thanks(GuestResponse guestResponse) => View(guestResponse);

        [HttpGet]
        public IActionResult ListResponses() => View(_partyInvitesDbContext.GuestResponses.OrderByDescending(r => r.WillAttend));
    }
}
