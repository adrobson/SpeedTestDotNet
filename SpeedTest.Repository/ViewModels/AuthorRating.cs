using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedTest.Repository.ViewModels
{
    public class AuthorRating
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public double AverageRating { get; set; }
    }
}
