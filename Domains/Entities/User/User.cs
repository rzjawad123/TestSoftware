﻿namespace Domains.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Device { get; set; }
        public string IpAddress { get; set; }
        public decimal Balance { get; set; } = 0;
    }
}
