using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CicekSepeti.Model;
using Newtonsoft.Json;

namespace CicekSepeti.Web.ViewModels
{
    //MVC model for bouquet
    public class BouquetsViewModel
    {
        public List<BouquetViewModel> Bouquets { get; set; }
    }

    public class BouquetViewModel
    {
        public BouquetViewModel()
        {
            SizeInBouquet = new List<SizeItemInBouquet>();
            var item = new SizeItemInBouquet();
            item.Size = Size.Küçük;
            SizeInBouquet.Add(item);
            item.Size = Size.Orta;
            SizeInBouquet.Add(item);
            item.Size = Size.Büyük;
            SizeInBouquet.Add(item);
        }

        public int BouquetId { get; set; }

        [DisplayName("Buket Adı")]
        public string BouquetName { get; set; }

        [DisplayName("Buket Boyutları")]
        public List<SizeItemInBouquet> SizeInBouquet { get; set; }

        public List<Flower> FlowerList { get; set; }
    }

    public class SizeItemInBouquet
    {
        public SizeItemInBouquet()
        {
            FlowerListInBouquet = new List<FlowerItemInBouquet>();
        }

        [Key]
        [DisplayName("Boyut")]
        public Size Size { get; set; }

        [DisplayName("Fiyat")]
        public decimal Price { get; set; }

        public List<FlowerItemInBouquet> FlowerListInBouquet { get; set; }
    }

    public class FlowerItemInBouquet
    {
        public int FlowerId { get; set; }
        public string FlowerName { get; set; }

        [DisplayName("Çiçek Adeti")]
        public int FlowerCount { get; set; }

        [JsonIgnore]
        public virtual Flower Flower { get; set; }
    }
}