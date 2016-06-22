using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    public class LoginServiceModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        
    }
}
