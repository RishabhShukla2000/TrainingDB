namespace TrainingDB.Custom_Model
{
    public class JWTToken
    {
        public string UserName { get; set; } = null!;
        public int UserId { get; set; }
        

        public string Token { get; set; }

        public string ProfilePic { get; set; } = null!;
    }
}
