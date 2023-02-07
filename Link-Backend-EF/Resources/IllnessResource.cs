namespace Link_Backend_EF.Resources
{
    public class IllnessResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }
    }
}
