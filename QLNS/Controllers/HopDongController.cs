using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace QLNS.Controllers
{
    [Route("api/[controller]")]
    public class HopDongController : Controller
    {
        private IHopDongRepository hopDongRepository;

        public HopDongController(IHopDongRepository hopDongRepository)
        {
            this.hopDongRepository = hopDongRepository;
        }

        // GET: HopDong
        public async Task<IActionResult> Index()
        {
            return View(await hopDongRepository.getAll());
        }

        // GET: 
        [Route("Details")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await hopDongRepository.getById(id));
        }

        [Route("Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                await this.hopDongRepository.Create(hopdong);
                return RedirectToAction("Index");
            }
            else
                return Content("Hi there!");
           

        }

        [Route("Update")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await hopDongRepository.getById(id));
        }
        [Route("Update")]
        [HttpPost]
        //public int ID = 
        public async Task<IActionResult> Update([FromForm]Hopdong hopdong)
        {
          
           
            if (ModelState.IsValid)
            {
                
                    await this.hopDongRepository.Update(hopdong);
                    return RedirectToAction("Index");
                
                
            }

            else
                return Content("Hi there!");

        }

        [Route("Delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await this.hopDongRepository.Delete(id);

            return RedirectToAction("Index");

        }
    }
}