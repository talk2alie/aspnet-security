using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Malie.Idp.Data
{
    public class User : IConcurrencyAware
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string UserName { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; } = $"{Guid.NewGuid()}";

        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }
}
