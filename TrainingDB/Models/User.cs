using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TrainingDB.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Hobbies { get; set; } = null!;
        public string ProfilePic { get; set; } = null!;
        public string Pword { get; set; } = null!;


        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
