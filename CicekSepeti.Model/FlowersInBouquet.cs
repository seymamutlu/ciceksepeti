using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CicekSepeti.Model
{
    //The model of datatable which contains the information about the flowers in each size of bouquet
    public class FlowersInBouquet : Entity<int>
    {
        [Key]
        [ForeignKey("BouquetSize")]
        [Column(Order = 0)]
        public int BouquetSizeId { get; set; }

        [Key]
        [ForeignKey("Flower")]
        [Column(Order = 1)]
        public int FlowerId { get; set; }

        public int FlowerCount { get; set; }

        [JsonIgnore]
        public virtual Flower Flower { get; set; }

        [JsonIgnore]
        public virtual BouquetSize BouquetSize { get; set; }
    }
}