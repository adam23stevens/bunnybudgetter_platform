using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyBudgetter.Comms.RequestModels
{
    public class PostPaymentReq
    {
        public int AccountId { get; set; }
        public int? PaymentTypeId { get; set; }
        public float Amount { get; set; }
        public bool IsIncome { get; set; }
        public string Description { get; set; }
    }
}
