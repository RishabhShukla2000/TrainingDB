using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrainingDB.Custom_Model
{
    public class CustomUser 
    {
            
            public int UserId { get; set; }
            public string UserName { get; set; } = null!;
            public string MobileNo { get; set; } = null!;
            public string Email { get; set; } = null!;
            public string Gender { get; set; } = null!;
            public DateTime DateOfBirth { get; set; }
            public string Hobbies { get; set; } = null!;
            public IFormFile Profile_Pic { get; set; } = null!;
            public string Pword { get; set; } = null!;
      
       
    }
    public class CustomUser1
    {
        public string Login { get; set; } = null!;
        public string Pword { get; set; } = null!;
    }
}
