using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLNS.Model;

namespace QLNS.DataProvider
{
    public interface IPhongBanDataProvider
    {
        Task<IEnumerable<Phongban>> GetPhongBans();

        Task<Phongban> GetPhongBan(int PhongbanId);

        Task AddPhongban(Phongban product);

        Task UpdatePhongban(Phongban product);

        Task DeletePhongban(int PhongbanId);
        Task<IEnumerable<Phongban>> GetPhongbans();
        Task<Phongban> GetPhongban(int phongbanId);
    }
}
