using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.Model;
using QLNS.DataProvider;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
namespace QLNS.Controllers
{
    [Produces("application/json")]
    //[Route("api/PhongBan")]
    [Route("api/[controller]")]
    public class PhongbanController : Controller
    {
        private IPhongBanDataProvider PhongBanDataProvider;

        public PhongbanController(IPhongBanDataProvider PhongBanDataProvider)
        {
            this.PhongBanDataProvider = PhongBanDataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<Phongban>> Get()
        {
            //QLNSContext db = new QLNSContext();
            //var listcv = await db.Phongban.FromSql("exec DanhSachPhongBan").ToListAsync();
            //return listcv;
            return await this.PhongBanDataProvider.GetPhongbans();
        }
        
        [HttpGet("{id}")]
        public async Task<Phongban> Get(int PhongbanId)
        {
            return await this.PhongBanDataProvider.GetPhongban(PhongbanId);
        }

        [HttpPost]
        public async Task Post([FromBody]Phongban Phongban)
        {
            await this.PhongBanDataProvider.AddPhongban(Phongban);
        }

        [HttpPut("{id}")]
        public async Task Put(int PhongbanId, [FromBody]Phongban Phongban)
        {
            await this.PhongBanDataProvider.UpdatePhongban(Phongban);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int PhongbanId)
        {
            await this.PhongBanDataProvider.DeletePhongban(PhongbanId);
        }

    }
}
