using my_books_v2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_v2.Data.ViewModels
{
    public class CustomActionResultVM
    {

        public Exception Exception { get; set; }
        public Publisher Publisher { get; set; }
    }
}
