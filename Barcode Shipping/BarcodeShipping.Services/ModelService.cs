using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using BarcodeShipping.Data;

namespace BarcodeShipping.Services
{
    public class ModelService
    {
        private readonly IQCDataEntities _context;
        public ModelService()
        {
            _context = new IQCDataEntities();
        }

        #region Models

        /// <summary>
        /// Trả về tất cả Model
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model> GetModels()
        {
            return _context.Database.SqlQuery<Model>("EXEC sp_SelectAllModels").ToList();
        }
        public IEnumerable<Model> GetModelsByCustomerName(string customerName)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@customerName",
                SqlDbType = SqlDbType.VarChar,
                Value = customerName,
            };
            return _context.Database.SqlQuery<Model>("EXEC [dbo].[sp_GetModelsByCustomerName] @customerName", param).ToList();
        }
        public Model GetModelById(string modelId)
        {
            var param = new SqlParameter()
            {
                ParameterName = "@modelId",
                SqlDbType = SqlDbType.VarChar,
                Value = modelId,
            };
            return _context.Database.SqlQuery<Model>("EXEC [sp_GetModelById] @modelId", param).FirstOrDefault();
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Model ID
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public bool CheckModelIdExits(string modelId)
        {
            if (modelId != null)
            {
                var model = GetModelById(modelId);
                if (model != null)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Thêm mới Model
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="modelName"></param>
        /// <param name="createdBy"></param>
        /// <param name="quantity"></param>
        /// <param name="serialNo"></param>
        public void InsertModel(string modelId, string modelName, string createdBy, int quantity, string serialNo)
        {
            var model = new Model()
            {
                ModelID = modelId,
                ModelName = modelName,
                CreatedBy = createdBy,
                DateCreated = DateTime.Now,
                Quantity = quantity,
                SerialNo = serialNo,
            };

            try
            {
                _context.Models.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="createdBy"></param>
        /// <param name="quantity"></param>
        /// <param name="serialNo"></param>
        public void UpdateModel(string modelId, string createdBy, int quantity, string serialNo)
        {
            var model = GetModels().FirstOrDefault(m => m.ModelID == modelId);
            if (model != null)
            {
                model.CreatedBy = createdBy;
                model.Quantity = quantity;
                model.SerialNo = serialNo;
                try
                {
                    _context.Models.Attach(model);
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
        }

        #endregion


    }
}