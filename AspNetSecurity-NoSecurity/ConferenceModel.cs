using System;

namespace AspNetSecurityNoSecurity.Models
{
    public class ConferenceModel
    {
        public ConferenceModel()
        {
            Start = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EncyptedId { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
    }
}
