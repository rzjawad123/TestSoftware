namespace Application.Users
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
