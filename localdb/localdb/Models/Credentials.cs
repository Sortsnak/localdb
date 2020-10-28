using System;
using SQLite;

namespace localdb.Models
{
    public class Credentials
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
