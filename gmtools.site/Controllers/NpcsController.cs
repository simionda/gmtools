using gmtools.site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gmtools.site.Controllers
{
    [ApiController]
    [Route("api/npcs")]
    public class NpcsController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public IEnumerable<NpcDto> Get()
        {
            var results = FakeNpcList;

            return results;
        }

        [HttpGet]
        [Route("{name}")]

        public NpcDto Get(string name)
        {
            var npc = FakeNpcList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return npc;
        }

        [HttpPost]
        [Route("")]
        public NpcDto CreateNpc(string name)
        {
            var result = new NpcDto() { Name = "Bob", Race = "Human", Class = "Commoner", Alignment = "Neutral" };
            FakeNpcList.Add(result);
            return result;
        }

        private static List<NpcDto> FakeNpcList = new List<NpcDto>()
            {
                new NpcDto() { Name="Drizzt", Alignment="Lawful Good", Class="Ranger", Race="Drow", ImageUrl="images/drizzt.png" },
                new NpcDto() { Name="Catti-Brie", Alignment="Lawful Good", Class="Ranger", Race="Human", ImageUrl="images/catti-brie.jpg"},
                new NpcDto() { Name="Bruenor", Alignment="Lawful Good", Class="Fighter", Race="Dwarf", ImageUrl="images/bruenor.jpg" },
                new NpcDto() { Name="Wulfgar", Alignment="Lawful Good", Class="Barbarian", Race="Human", ImageUrl="images/wulfgar.jfif" }
            };
    }
}
