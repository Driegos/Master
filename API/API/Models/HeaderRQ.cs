using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class HeaderRQ
    {
        public IEnumerable<string> key;
        public IEnumerable<string> rout;
        public IEnumerable<string> signature;
    }
}