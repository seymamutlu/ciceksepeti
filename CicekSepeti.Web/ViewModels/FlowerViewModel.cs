namespace CicekSepeti.Web.ViewModels
{
    //MVC model for flower
    public class FlowerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFlowering { get; set; }
        public bool IsThorny { get; set; }
        public bool IsLeafy { get; set; }
    }
}