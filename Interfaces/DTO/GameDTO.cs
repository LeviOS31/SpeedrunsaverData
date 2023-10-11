using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public string GameDescription { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<PlatformDTO> Platforms { get; set; }
    }
}
