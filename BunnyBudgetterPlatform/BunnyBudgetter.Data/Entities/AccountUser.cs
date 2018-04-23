using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BunnyBudgetter.Data.Entities
{
    public class AccountUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
