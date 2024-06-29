namespace PoolRezWebApi.Models
{
    public class BookSelection
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ResourceTypeId { get; set; }
        public int AssignedResourceId { get; set; }
        public bool IsAssignedResourceSelectable { get; set; }
    }
}
