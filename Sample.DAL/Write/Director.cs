using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#nullable disable

namespace Sample.DAL.Write
{
    public class Director
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
