using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CicekSepeti.Model;
using CicekSepeti.Service;
using CicekSepeti.Web.ViewModels;

namespace CicekSepeti.Web.Controllers
{
    public class BouquetController : Controller
    {
        private readonly IBouquetService _bouquetService;
        private readonly IFlowerService _flowerService;

        //Inject services in the constructor
        public BouquetController(IBouquetService bouquetService, IFlowerService flowerService)
        {
            _bouquetService = bouquetService;
            _flowerService = flowerService;
        }

        // GET: Bouquet
        public ActionResult Index()
        {
            var bouquetViewModels = _bouquetService.GetAll().ToList();
            return View(bouquetViewModels);
        }

        // GET: Bouquet/Details/5
        public ActionResult Details(int id)
        {
            var bouquet = _bouquetService.GetById(id);

            if (bouquet == null)
                return HttpNotFound();
            var model = new BouquetViewModel();
            var bouquetSizes = _bouquetService.GetSizesOfBouquet(id);
            model.BouquetId = bouquet.Id;
            model.BouquetName = bouquet.Name;
            model.SizeInBouquet = new List<SizeItemInBouquet>();
            foreach (var bouquetSizeItem in bouquetSizes)
            {
                var bouquetSize = new SizeItemInBouquet
                {
                    Size = (Size) bouquetSizeItem.SizeId,
                    Price = bouquetSizeItem.Price,
                    FlowerListInBouquet = new List<FlowerItemInBouquet>()
                };
                var flowers = _bouquetService.GetFlowersInBouquetType(bouquetSizeItem.Id);
                var flowerList = new List<FlowerItemInBouquet>();
                foreach (var flower in flowers)
                {
                    var flowerInBouquet = new FlowerItemInBouquet();
                    flowerInBouquet.FlowerId = flower.FlowerId;
                    var f = _flowerService.GetById(flower.FlowerId);
                    flowerInBouquet.FlowerName = f.Name;
                    flowerInBouquet.Flower = f;
                    flowerInBouquet.FlowerCount = flower.FlowerCount;
                    flowerList.Add(flowerInBouquet);
                }
                bouquetSize.FlowerListInBouquet = flowerList;
                model.SizeInBouquet.Add(bouquetSize);
            }
            model.FlowerList = _flowerService.GetAll().ToList();

            return View(model);
        }

        // GET: Bouquet/Create
        public ActionResult Create()
        {
            var model = new BouquetViewModel {SizeInBouquet = new List<SizeItemInBouquet>(3)};
            var item1 = new SizeItemInBouquet
            {
                Size = Size.Küçük,
                FlowerListInBouquet = new List<FlowerItemInBouquet>()
            };
            var item2 = new SizeItemInBouquet
            {
                Size = Size.Orta,
                FlowerListInBouquet = new List<FlowerItemInBouquet>()
            };
            var item3 = new SizeItemInBouquet
            {
                Size = Size.Büyük,
                FlowerListInBouquet = new List<FlowerItemInBouquet>()
            };
            model.SizeInBouquet.Add(item1);
            model.SizeInBouquet.Add(item2);
            model.SizeInBouquet.Add(item3);
            model.FlowerList = _flowerService.GetAll().ToList();

            return View(model);
        }

        // POST: Bouquet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BouquetViewModel bouquetViewModel)
        {
            if (ModelState.IsValid)
            {
                var bouquet = new Bouquet();
                bouquet.Name = bouquetViewModel.BouquetName;
                _bouquetService.AddBouquet(bouquet);
                var i = 0;
                foreach (var sizeItemInBouquet in bouquetViewModel.SizeInBouquet)
                    try
                    {
                        var bouquetSize = new BouquetSize();
                        bouquetSize.SizeId = i;
                        bouquetSize.Price = sizeItemInBouquet.Price;
                        bouquetSize.BouquetId = bouquet.Id;
                        bouquetSize.Bouquet = bouquet;
                        _bouquetService.AddSizeOfBouquet(bouquetSize);
                        i++;
                        foreach (var flowerItemInBouquet in sizeItemInBouquet.FlowerListInBouquet)
                            try
                            {
                                var flowerItem = new FlowersInBouquet();
                                flowerItem.FlowerCount = flowerItemInBouquet.FlowerCount;
                                flowerItem.FlowerId = flowerItemInBouquet.FlowerId;
                                var f = _flowerService.GetById(flowerItemInBouquet.FlowerId);
                                flowerItem.Flower = f;
                                flowerItem.BouquetSizeId = bouquetSize.Id;
                                _bouquetService.AddFlowerToBouquet(flowerItem);
                            }
                            catch (Exception e)
                            {
                                //todo: log error
                                Console.WriteLine(e);
                            }
                    }
                    catch (Exception e)
                    {
                        //todo: log error
                        Console.WriteLine(e);
                    }

                return RedirectToAction("Index");
            }
            bouquetViewModel.FlowerList = _flowerService.GetAll().ToList();

            return View(bouquetViewModel);
        }

        // GET: Bouquet/Edit/5
        public ActionResult Edit(int id)
        {
            var bouquet = _bouquetService.GetById(id);

            if (bouquet == null)
                return HttpNotFound();
            var model = new BouquetViewModel();
            var bouquetSizes = _bouquetService.GetSizesOfBouquet(id);
            model.BouquetId = bouquet.Id;
            model.BouquetName = bouquet.Name;
            model.SizeInBouquet = new List<SizeItemInBouquet>();
            foreach (var bouquetSizeItem in bouquetSizes)
            {
                var bouquetSize = new SizeItemInBouquet();
                bouquetSize.Size = (Size) bouquetSizeItem.SizeId;
                bouquetSize.Price = bouquetSizeItem.Price;
                bouquetSize.FlowerListInBouquet = new List<FlowerItemInBouquet>();
                var flowers = _bouquetService.GetFlowersInBouquetType(bouquetSizeItem.Id);
                var flowerList = new List<FlowerItemInBouquet>();
                foreach (var flower in flowers)
                {
                    var flowerInBouquet = new FlowerItemInBouquet();
                    flowerInBouquet.FlowerId = flower.FlowerId;
                    var f = _flowerService.GetById(flower.FlowerId);
                    flowerInBouquet.FlowerName = f.Name;
                    flowerInBouquet.Flower = f;
                    flowerInBouquet.FlowerCount = flower.FlowerCount;
                    flowerList.Add(flowerInBouquet);
                }
                bouquetSize.FlowerListInBouquet = flowerList;
                model.SizeInBouquet.Add(bouquetSize);
            }
            model.FlowerList = _flowerService.GetAll().ToList();

            return View(model);
        }

        // POST: Bouquet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BouquetId,BouquetName")] BouquetViewModel bouquetModel)
        {
            if (ModelState.IsValid)
            {
                var bouquet = new Bouquet();
                bouquet.Name = bouquetModel.BouquetName;
                _bouquetService.Update(bouquet);
                return RedirectToAction("Index");
            }
            return View(bouquetModel);
        }

        // GET: Bouquet/Delete/5
        public ActionResult Delete(int id)
        {
            var bouquet = _bouquetService.GetById(id);
            if (bouquet == null)
                return HttpNotFound();

            var model = new BouquetViewModel();
            var bouquetSizes = _bouquetService.GetSizesOfBouquet(id);
            model.BouquetId = bouquet.Id;
            model.BouquetName = bouquet.Name;
            model.SizeInBouquet = new List<SizeItemInBouquet>();
            foreach (var bouquetSizeItem in bouquetSizes)
            {
                var bouquetSize = new SizeItemInBouquet();
                bouquetSize.Size = (Size) bouquetSizeItem.SizeId;
                bouquetSize.Price = bouquetSizeItem.Price;
                bouquetSize.FlowerListInBouquet = new List<FlowerItemInBouquet>();
                var flowers = _bouquetService.GetFlowersInBouquetType(bouquetSizeItem.Id);
                var flowerList = new List<FlowerItemInBouquet>();
                foreach (var flower in flowers)
                {
                    var flowerInBouquet = new FlowerItemInBouquet();
                    flowerInBouquet.FlowerId = flower.FlowerId;
                    var f = _flowerService.GetById(flower.FlowerId);
                    flowerInBouquet.FlowerName = f.Name;
                    flowerInBouquet.Flower = f;
                    flowerInBouquet.FlowerCount = flower.FlowerCount;
                    flowerList.Add(flowerInBouquet);
                }
                bouquetSize.FlowerListInBouquet = flowerList;
                model.SizeInBouquet.Add(bouquetSize);
            }
            model.FlowerList = _flowerService.GetAll().ToList();

            return View(model);
        }

        // POST: Bouquet/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bouquet = _bouquetService.GetById(id);
            var bouquetSizes = _bouquetService.GetSizesOfBouquet(id);
            foreach (var sizes in bouquetSizes)
                _bouquetService.DeleteFlowersOfBouquetSize(sizes.Id);
            _bouquetService.DeleteBouquet(bouquet);
            return RedirectToAction("Index");
        }
    }
}