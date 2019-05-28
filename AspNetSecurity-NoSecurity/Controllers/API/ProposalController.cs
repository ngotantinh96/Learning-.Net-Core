using System.Collections.Generic;
using AspNetSecurityNoSecurity.Models;
using AspNetSecurityNoSecurity.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetSecurityNoSecurity.Controllers.API
{
    [Route("api/[controller]")]
    public class ProposalController
    {
        private readonly ProposalRepo repo;

        public ProposalController(ProposalRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<ProposalModel> Get(int conferenceId)
        {
            return repo.GetAllApprovedForConference(conferenceId);
        }
    }
}
