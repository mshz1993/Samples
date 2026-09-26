using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly DigitalMarketDBContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public UserController(DigitalMarketDBContext context, IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddMenu()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddMenu(HeaderMenu H)
        {
            H.ParentID = 1;
            H.ControlName = "Home";
            H.IsDynamic = false;
            _context.HeaderMenus.Add(H);
            _context.SaveChanges();
            return View();

        }
        public IActionResult ManageMenu()
        {
            return View(_context.HeaderMenus.Where(a => a.Id > 1));

        }
        [Route("User/AddMenu/{id}")]
        //[Route(Name ="id")]
        public IActionResult AddMenu(int id)
        {
            return View();
        }
        public IActionResult EditHeaderMenu(int id)
        {
            var h = _context.HeaderMenus.Find(id);
            return View(h);
        }
        [HttpPost]
        public IActionResult EditHeaderMenu(HeaderMenu H)
        {
            H.ParentID = 1;
            H.IsDynamic = false;
            H.ControlName = "Home";
            _context.HeaderMenus.Update(H);
            if (_context.SaveChanges() != -1)
            {
                TempData["Message"] = "منو با موفقیت ویرایش شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteHeaderMenu(int id)
        {
            _context.HeaderMenus.Remove(_context.HeaderMenus.Find(id));
            if (_context.SaveChanges() != -1)
            {
                TempData["Message"] = "منو با موفقیت حذف شد";
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddDigitalProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDigitalProduct(Product P, IFormFile ImageName)
        {
            if (ImageName != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath + "/images/", "DigitalPro");
                var filePath = Path.Combine(uploads, ImageName.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageName.CopyToAsync(fileStream);
                }
            }
            P.ImageName = ImageName.FileName;
            _context.Products.Add(P);
            if (_context.SaveChanges() != -1)
            {
                TempData["Message"] = "کالای دیجیتال با موفقیت افزوده شد";
            }
            return RedirectToAction("Index");
        }
        public IActionResult ManageDigitalProduct()
        {
            return View(_context.Products);
        }
        public IActionResult EditDigitalProduct(int id)
        {
            var DP = _context.Products.Find(id);

            return View(DP);
        }
        [HttpPost]
        public async Task<IActionResult> EditDigitalProduct(Product P, IFormFile ImageName)
        {
            var s = TempData["IMG"];
            if (ImageName != null)
            {
                string fullPath = "C:/Users/Mehran/Desktop/DigitalMarket/WebApplication1/WebApplication1/wwwroot/images/DigitalPro/" + TempData["IMG"];
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath + "/images/", "DigitalPro");
                var filePath = Path.Combine(uploads, ImageName.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageName.CopyToAsync(fileStream);
                }
                P.ImageName = ImageName.FileName;
                _context.Products.Update(P);
                if (_context.SaveChanges() != -1)
                {
                    TempData["Message"] = "کالای دیجیتال با موفقیت ویرایش شد";
                }
            }
            else
            {
                TempData["Message"] = "لطفا عکس مورد نظر را انتخاب کنید";
                return View();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteDigitalProduct(int id)
        {
            var P = _context.Products.Find(id);
            string fullPath = "C:/Users/Mehran/Desktop/DigitalMarket/WebApplication1/WebApplication1/wwwroot/images/DigitalPro/" + P.ImageName;
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            _context.Products.Remove(P);
            if (_context.SaveChanges() != -1)
            {
                TempData["Message"] = "کالای دیجیتال با موفقیت حذف شد";
            }
            return RedirectToAction("Index");
        }
    }
}