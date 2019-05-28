using AspNetSecurity_NoSecurity.Models;
using AspNetSecurityNoSecurity;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetSecurity_NoSecurity.Repositories
{
    public class ConferenceRepo
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        private readonly IDataProtector protector;

        public ConferenceRepo(IDataProtectionProvider protectionProvider, PurposeStringConstants purposeString)
        {
            protector = protectionProvider.CreateProtector(purposeString.ConferenceIdQueryString);
            conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", EncyptedId = protector.Protect("1"), Location = "Oslo", Start = new DateTime(2017, 6, 12) });
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", EncyptedId = protector.Protect("2"), Location = "San Francisco", Start = new DateTime(2017, 10, 18) });
        }
        public IEnumerable<ConferenceModel> GetAll()
        {
            return conferences;
        }

        public ConferenceModel GetById(int id)
        {
            return conferences.First(c => c.Id == id);
        }

        public void Add(ConferenceModel model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            model.EncyptedId = protector.Protect(model.Id.ToString());
            conferences.Add(model);
        }
    }
}
