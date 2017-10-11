using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CicekSepeti.Model
{
    public enum Size
    {
        Küçük = 0,
        Orta = 1,
        Büyük = 2
    }

    //The model for 3 sizes of bouquet
    public class BouquetSize : Entity<int>
    {
        [ForeignKey("Bouquet")]
        public int BouquetId { get; set; }

        public int SizeId { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [JsonIgnore]
        public virtual Bouquet Bouquet { get; set; }
    }
}