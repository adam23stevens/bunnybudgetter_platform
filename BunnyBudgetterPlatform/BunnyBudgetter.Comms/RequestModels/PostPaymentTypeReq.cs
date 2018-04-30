using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyBudgetter.Comms.RequestModels
{
    public class PostPaymentTypeReq
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public float MaxAmount { get; set; }
    }
}
