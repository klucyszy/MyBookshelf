using System;
using System.ComponentModel.DataAnnotations;

namespace elibrary.data.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Login { get; set; }
    }
}
