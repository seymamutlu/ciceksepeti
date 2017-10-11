using System.Collections.Generic;
using System.Web.Mvc;
using CicekSepeti.Model;
using CicekSepeti.Service;
using CicekSepeti.Web.ViewModels;

namespace CicekSepeti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBouquetService _bouquetService;
        private readonly IFlowerService _flowerService;

        public HomeController(IBouquetService bouquetService, IFlowerService flowerService)
        {
            _bouquetService = bouquetService;
            _flowerService = flowerService;
        }

        public ActionResult Index()
        {
            var result = new BouquetsViewModel();
            result.Bouquets = new List<BouquetViewModel>();
            var bouquetList = _bouquetService.GetAll();
            foreach (var item in bouquetList)
            {
                var id = item.Id;
                var bouquets = new BouquetViewModel();
                var bouquetSizes = _bouquetService.GetSizesOfBouquet(id);
                bouquets.BouquetId = id;
                bouquets.BouquetName = item.Name;
                bouquets.SizeInBouquet = new List<SizeItemInBouquet>();
                foreach (var bouquetSizeItem in bouquetSizes)
                {
                    var bouquet = new SizeItemInBouquet();
                    bouquet.Size = (Size) bouquetSizeItem.SizeId;
                    bouquet.Price = bouquetSizeItem.Price;
                    bouquet.FlowerListInBouquet = new List<FlowerItemInBouquet>();
                    var flowers = _bouquetService.GetFlowersInBouquetType(bouquetSizeItem.Id);
                    var flowerList = new List<FlowerItemInBouquet>();
                    foreach (var flower in flowers)
                    {
                        var flowerInBouquet = new FlowerItemInBouquet();
                        flowerInBouquet.FlowerId = flower.FlowerId;
                        flowerInBouquet.FlowerName = _flowerService.GetById(flower.FlowerId).Name;
                        flowerInBouquet.FlowerCount = flower.FlowerCount;
                        flowerList.Add(flowerInBouquet);
                    }
                    bouquet.FlowerListInBouquet = flowerList;
                    bouquets.SizeInBouquet.Add(bouquet);
                }
                result.Bouquets.Add(bouquets);
            }
            return View(result);
        }
    }
}