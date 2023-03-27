
namespace RepositoryPattern.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Manager { get; set; }
        public decimal CostCenter { get; set; }
    }
}
