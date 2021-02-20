using System.Collections.Generic;

namespace gmtools.site.Models
{
    public class SettlementDto
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string RaceRelations { get; set; }
        public string Ruler { get; set; }
        public string RulersStatus { get; set; }
        public string NotableTraits { get; set; }
        public string KnownFor { get; set; }
        public string Calamity { get; set; }

        public IEnumerable<BuildingDto> Buildings => buildings;

        private List<BuildingDto> buildings;

        public SettlementDto(string name, string size)
        {
            this.Name = name;
            this.Size = size;
            buildings = new List<BuildingDto>();
        }

        public void AddBuilding(BuildingDto building)
        {
            buildings.Add(building);
        }
    }

    public class BuildingDto
    {
        public string Description { get; set; }

        public BuildingDto(string description)
        {
            this.Description = description;
        }
    }
}
