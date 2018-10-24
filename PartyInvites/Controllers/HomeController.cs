﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly PartyInvitesDbContext _partyInvitesDbContext;

        public HomeController(PartyInvitesDbContext partyInvitesDbContext) => _partyInvitesDbContext = partyInvitesDbContext;

        public IActionResult Index() => View();

        public IActionResult Respond() => View();

        public IActionResult Respond(GuestResponse guestResponse)
        {
            _partyInvitesDbContext.GuestResponses.Add(guestResponse);
            _partyInvitesDbContext.SaveChanges();
            return RedirectToAction(nameof(Thanks), new {Name = guestResponse.Name, WillAttend = guestResponse.WillAttend});
        }

        public IActionResult ListResponses() => View(_partyInvitesDbContext.GuestResponses.OrderByDescending(r => r.WillAttend));
    }
}
