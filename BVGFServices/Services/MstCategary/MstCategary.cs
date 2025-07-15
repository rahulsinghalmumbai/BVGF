using BVGF.Entities;
using BVGFRepository.Interfaces.MstCategary;
using BVGFServices.Interfaces.MstCategary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVGFServices.Services.MstCategary
{
    public class MstCategary : IMstCategary
    {
        private readonly IMstCategary<MstCategory> _repository;
        public MstCategary(IMstCategary<MstCategory> repository)
        {
            _repository = repository;
        }
        public async Task<List<MstCategory>> GetAllAsync()
        {
            var result = new List<MstCategory>();

            var dt = await _repository.ExecuteStoredProcedureAsync("stp_GetAllCategories");
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new MstCategory
                {
                    CategoryID = row["CategoryID"] != DBNull.Value ? Convert.ToInt32(row["CategoryID"]) : 0,
                    CategoryName = row["CategoryName"]?.ToString(),
                    Status = row["Status"] != DBNull.Value && Convert.ToBoolean(row["Status"]),
                    CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"]) : null,
                    CreatedDt = row["CreatedDt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDt"]) : null,
                    UpdatedBy = row["UpdatedBy"] != DBNull.Value ? Convert.ToInt32(row["UpdatedBy"]) : null,
                    UpdatedDt = row["UpdatedDt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDt"]) : null,
                    DeletedBy = row["DeletedBy"] != DBNull.Value ? Convert.ToInt32(row["DeletedBy"]) : null,
                    DeletedDt = row["DeletedDt"] != DBNull.Value ? Convert.ToDateTime(row["DeletedDt"]) : null
                });
            }
            return result;
        }
    }
}
