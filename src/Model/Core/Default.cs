using System;

namespace Sampekey.Model.Core
{
    public class Default
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public Boolean Active { get; set; } = true;
    }
}