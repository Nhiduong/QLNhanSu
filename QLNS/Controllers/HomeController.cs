using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;

namespace QLNS.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private ITaiKhoanRepository taiKhoanRepository;

        public HomeController(ITaiKhoanRepository taiKhoanRepository)
        {
            this.taiKhoanRepository = taiKhoanRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return NotFound();
            }

            var user = taiKhoanRepository.getUser(username, password);

            if (user != null)
            {
                if (user.Result.Khoa == "0")
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}