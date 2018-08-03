using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using QLNS.Model;
using System.Data;
using System.Data.SqlClient;

namespace QLNS.DataProvider
{
    public class PhongBanDataProvider : IPhongBanDataProvider
    {
        private readonly string connectionString = @"Data Source=DESKTOP-NTBPN6G\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
        private SqlConnection sqlConnection;

        public async Task DSPhongban()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
             await sqlConnection.ExecuteAsync(
                    "Them_phongban",
                   
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddPhongban(Phongban phongban)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Ten", phongban.Ten);
                dynamicParameters.Add("@Mota", phongban.Mota);
                dynamicParameters.Add("@Dateadd", phongban.Dateadd);
                dynamicParameters.Add("@Useradd", phongban.Useradd);
                dynamicParameters.Add("@Dateedit", phongban.Dateedit);
                dynamicParameters.Add("@Useredit", phongban.Useredit);

                await sqlConnection.ExecuteAsync(
                    "Them_phongban",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeletePhongban(int PhongbanId)

        {

            using (var sqlConnection = new SqlConnection(connectionString))

            {

                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PhongbanId", PhongbanId);

                await sqlConnection.ExecuteAsync(

                    "Xoa_phongban",

                    dynamicParameters,

                    commandType: CommandType.StoredProcedure);

            }

        }





        public async Task<Phongban> GetPhongban(int PhongBanId)

        {

            using (var sqlConnection = new SqlConnection(connectionString))

            {

                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@Id", PhongBanId);

                return await sqlConnection.QuerySingleOrDefaultAsync<Phongban>(

                    "DSPhongBan_Id",

                    dynamicParameters,

                    commandType: CommandType.StoredProcedure);

            }

        }



        public async Task<IEnumerable<Phongban>> GetPhongbans()

        {

            using (var sqlConnection = new SqlConnection(connectionString))

            {

                await sqlConnection.OpenAsync();

                return await sqlConnection.QueryAsync<Phongban>(

                    "DanhSachPhongBan",

                    null,

                    commandType: CommandType.StoredProcedure);

            }

        }



        public async Task UpdatePhongban(Phongban Phongban)

        {

            using (var sqlConnection = new SqlConnection(connectionString))

            {

                await sqlConnection.OpenAsync();

                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@Id", Phongban.Id);
                dynamicParameters.Add("@Ten", Phongban.Ten);
                dynamicParameters.Add("@Mota", Phongban.Mota);
                dynamicParameters.Add("@Dateadd", Phongban.Dateadd);
                dynamicParameters.Add("@Useradd", Phongban.Useradd);
                dynamicParameters.Add("@Dateedit", Phongban.Dateedit);
                dynamicParameters.Add("@Useredit", Phongban.Useredit);

                await sqlConnection.ExecuteAsync(

                    "Sua_phongban",

                    dynamicParameters,

                    commandType: CommandType.StoredProcedure);

            }

        }

        public Task<IEnumerable<Phongban>> GetPhongBans()
        {
            throw new NotImplementedException();
        }

        public Task<Phongban> GetPhongBans(int PhongbanId)
        {
            throw new NotImplementedException();
        }

        public Task<Phongban> GetPhongBan(int PhongbanId)
        {
            throw new NotImplementedException();
        }
    }
}
