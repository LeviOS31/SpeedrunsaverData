﻿namespace DataSpeedrunsaver.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}
