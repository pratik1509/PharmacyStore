using System;
using System.Collections.Generic;

namespace Common.Persistence.PaymentManagement.PaymentDto
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string DefaultSourceId { get; set; }
        public Dictionary<string, string> MetaData { get; set; }
        public bool IsDeleted { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
