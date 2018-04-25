using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BunnyBudgetter.Data.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLockedOut { get; set; }
        public int NumberOfAttempts { get; set; }
        public string AccessCode { get; set; }
        public ICollection<AccountUser> AccountUsers { get; set; }
    }
}
