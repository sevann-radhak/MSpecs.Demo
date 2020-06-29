using System.ComponentModel.DataAnnotations.Schema;

namespace ClientService.Data
{
    public class TeamEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
    }
}
