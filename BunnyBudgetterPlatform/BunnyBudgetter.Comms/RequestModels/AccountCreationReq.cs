using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunnyBudgetterPlatform.RequestModels
{
    public class AccountCreationReq
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public float CurrentAmount { get; set; }
        public float OverdraftLimit { get; set; }
        public DateTime LastDateSalaryPaid { get; set; }
        public int SalaryScheduleType { get; set; }
        public int SalaryDayPaid { get; set; }
        public float MonthlyNetSalaryAmount { get; set; }
    }
}
