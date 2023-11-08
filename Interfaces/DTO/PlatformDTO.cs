using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class PlatformDTO
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Manufacturer { get; set; }
        public List<GameDTO>? Games { get; set; }
    }
}
