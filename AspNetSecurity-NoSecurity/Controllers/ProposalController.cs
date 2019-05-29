﻿using AspNetSecurityNoSecurity.Models;
using AspNetSecurityNoSecurity.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSecurityNoSecurity.Controllers
{
    [Authorize]
    public class ProposalController : Controller
    {
        private readonly ConferenceRepo conferenceRepo;
        private readonly ProposalRepo proposalRepo;
        private readonly IDataProtector protector;

        public ProposalController(ConferenceRepo conferenceRepo, ProposalRepo proposalRepo,
            IDataProtectionProvider protectionProvider, PurposeStringConstants purposeString)
        {
            this.protector = protectionProvider.CreateProtector(purposeString.ConferenceIdQueryString);
            this.conferenceRepo = conferenceRepo;
            this.proposalRepo = proposalRepo;
        }

        public IActionResult Index(string conferenceId)
        {
            var deCryptedConferenceId = int.Parse(protector.Unprotect(conferenceId));
            var conference = conferenceRepo.GetById(deCryptedConferenceId);
            ViewBag.Title = $"Speaker - Proposals For Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(proposalRepo.GetAllForConference(deCryptedConferenceId));
        }

        public IActionResult AddProposal(int conferenceId)
        {
            ViewBag.Title = "Speaker - Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }

        [HttpPost]
        public IActionResult AddProposal(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                proposalRepo.Add(proposal);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }

        public IActionResult Approve(int proposalId)
        {
            var proposal = proposalRepo.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}
