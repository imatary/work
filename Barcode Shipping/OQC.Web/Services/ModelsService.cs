using OQC.Web.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace OQC.Web.Services
{
    public interface IModelsService
    {
        Task<IEnumerable<ModelPCB>> GetModelsAsync();
        Task<ModelPCB> GetModelByIdAsync(string id);
        ModelPCB GetModelById(string id);
        Task InsertAsync(ModelPCB model);
        Task UpdateAsync(ModelPCB model);
        void Delete(string id);
    }
    public class ModelsService : IModelsService
    {
        private readonly ApplicationDbContext _context;
        public ModelsService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<IEnumerable<ModelPCB>> GetModelsAsync()
        {
            return await _context.Database.SqlQuery<ModelPCB>("EXEC [sp_SelectAllModels]").ToListAsync();
        }

        public async Task<ModelPCB> GetModelByIdAsync(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };
            return await _context.Database.SqlQuery<ModelPCB>("EXEC [sp_GetModelById] @modelId", param).FirstOrDefaultAsync();
        }
        public ModelPCB GetModelById(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };
            return _context.Database.SqlQuery<ModelPCB>("EXEC [sp_GetModelById] @modelId", param).FirstOrDefault();
        }

        public void Delete(string id)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.Char,
                Value = id,
            };

            _context.Database.ExecuteSqlCommand("EXEC [sp_DeleteModelById] @modelId", param);
        }

        public async Task InsertAsync(ModelPCB model)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@ModelID", Value = model.ModelID, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@ModelName", Value = model.ModelName, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@CreatedBy", Value = model.CreatedBy, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@DateCreated", Value = model.DateCreated, SqlDbType = SqlDbType.DateTime},
                new SqlParameter() { ParameterName = "@Quantity", Value = model.Quantity, SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@SerialNo", Value = model.SerialNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@CustomerName", Value = model.CustomerName, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [sp_InsertModel] @ModelID, @ModelName, @CreatedBy, @DateCreated, @Quantity, @SerialNo, @CustomerName", param);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateAsync(ModelPCB model)
        {
            object[] param =
            {
                new SqlParameter() { ParameterName = "@ModelID", Value = model.ModelID, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@ModelName", Value = model.ModelName, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@CreatedBy", Value = model.CreatedBy, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@DateCreated", Value = model.DateCreated, SqlDbType = SqlDbType.DateTime},
                new SqlParameter() { ParameterName = "@Quantity", Value = model.Quantity, SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@SerialNo", Value = model.SerialNo, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@CustomerName", Value = model.CustomerName, SqlDbType = SqlDbType.VarChar},
                new SqlParameter("@Out_Parameter", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            try
            {
                _context.Database.ExecuteSqlCommand("EXEC [sp_UpdateModel] @ModelID, @ModelName, @CreatedBy, @DateCreated, @Quantity, @SerialNo, @CustomerName", param);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}