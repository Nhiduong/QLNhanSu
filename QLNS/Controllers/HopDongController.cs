using Microsoft.AspNetCore.Mvc;
using QLNS.Data.Interface;
using QLNS.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Hopdong hopdong)
        {
            if (ModelState.IsValid)
            {
                await this.hopDongRepository.Create(hopdong);
                return RedirectToAction("Index");
            }
            return View(hopdong);

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Hopdong hopdong)
        {
            if (id == hopdong.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.hopDongRepository.Update(hopdong);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }

            return View(hopdong);

        }

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