using System.Net;
using System.Web.Mvc;
using CicekSepeti.Model;
using CicekSepeti.Service;

namespace CicekSepeti.Web.Controllers
{
    public class FlowerController : Controller
    {
        private readonly IFlowerService _flowerService;

        public FlowerController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        // GET: Flowers
        public ActionResult Index()
        {
            return View(_flowerService.GetAll());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int id)
        {
            var flower = _flowerService.GetById(id);
            if (flower == null)
                return HttpNotFound();
            return View(flower);
        }

        // GET: Flowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsFlowering,IsThorny,IsLeafy")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _flowerService.Create(flower);
                return RedirectToAction("Index");
            }

            return View(flower);
        }

        // GET: Flowers/Edit/5
        public ActionResult Edit(int id)
        {
            var flower = _flowerService.GetById(id);
            if (flower == null)
                return HttpNotFound();
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsFlowering,IsThorny,IsLeafy")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                _flowerService.Update(flower);
                return RedirectToAction("Index");
            }
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public ActionResult Delete(int id)
        {
            var flower = _flowerService.GetById(id);
            if (flower == null)
                return HttpNotFound();
            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var flower = _flowerService.GetById(id);
            _flowerService.Delete(flower);
            return RedirectToAction("Index");
        }
    }
}