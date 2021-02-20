using gmtools.rolltables;
using gmtools.site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace gmtools.site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementsController : ControllerBase
    {
        private static List<SettlementDto> Settlements = new List<SettlementDto>();

        public SettlementsController()
        {
            if (!Settlements.Any())
            {
                Settlements.Add(GenerateSettlement("Neverwinter", "City"));
                Settlements.Add(GenerateSettlement("Ten Towns", "Town"));
                Settlements.Add(GenerateSettlement("Phandalin", "Village"));
            }
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<SettlementDto> GetSettlements()
        {
            return Settlements;
        }

        [HttpGet]
        [Route("{name}")]
        public SettlementDto GetSettlement(string name)
        {
            return Settlements.FirstOrDefault(s => s.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
        }

        [HttpPost]
        [Route("")]
        public SettlementDto CreateSettlement()
        {
            var name = "NewTown";
            var size = "Village";

            var settlement = GenerateSettlement(name, size);

            Settlements.Add(settlement);

            return settlement;
        }

        private SettlementDto GenerateSettlement(string name, string size)
        {
            var settlement = new SettlementDto(name, size);

            settlement.Calamity = TableFactory.Load("settlements.calamities").Roll().Temp;
            settlement.KnownFor = TableFactory.Load("settlements.knownfor").Roll().Temp;
            settlement.NotableTraits = TableFactory.Load("settlements.notabletraits").Roll().Temp;
            settlement.RaceRelations = TableFactory.Load("settlements.racerelations").Roll().Temp;
            settlement.Ruler = "Drizzt";
            settlement.RulersStatus = TableFactory.Load("settlements.rulersstatus").Roll().Temp;

            var numberOfBuildings = 10;

            numberOfBuildings = size.ToLower(CultureInfo.InvariantCulture) switch
            {
                "city" => 150,
                "town" => 42,
                "village" => 12,
                _ => 10
            };

            for (var ctr = 1; ctr <= numberOfBuildings; ctr++)
            {
                var buildingTypes = TableFactory.Load("settlements.buildingtype");
                var building = new BuildingDto(buildingTypes.Roll().Temp);
                settlement.AddBuilding(building);
            }

            return settlement;
        }
    }
}
