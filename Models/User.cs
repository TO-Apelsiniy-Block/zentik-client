using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentik.Models
{
    internal record User
    {
        public int UserId;
        public string Username = "Unknown Username";
        public string Email = "Unknown Email";
    }
}
