using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BarcodeShipping.Data;
using BarcodeShipping.Data.Repositories;

namespace BarcodeShipping.Services
{

    public class IqcService
    {
        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new IqcRepository()); }
        }

        /// <summary>
        /// get logs by boxid
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public IEnumerable<tbl_test_log> GetLogs(string boxId)
        {
            return Repository.GetAll<tbl_test_log>().Where(log => log.BoxID == boxId).ToList();
        }

        /// <summary>
        /// Get PCB
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public tbl_test_log GetPcbById(string productionId)
        {
            return Repository.GetAll<tbl_test_log>().FirstOrDefault(op => op.ProductionID == productionId);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Operator
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public bool CheckPcbExits(string productionId)
        {
            var pcb = GetPcbById(productionId);
            if (pcb != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// all shipping
        /// </summary>
        /// <returns></returns>
        public List<Shipping> GetShippings()
        {
            return Repository.GetAll<Shipping>().ToList();
        }

        /// <summary>
        /// Get Shipping By Production ID
        /// </summary>
        /// <param name="productionId"></param>
        /// <returns></returns>
        public Shipping GetShippingById(string productionId)
        {
            return Repository.GetAll<Shipping>().FirstOrDefault(p => p.ProductID == productionId);
        }

        public Shipping GetShippingByGuiId(Guid id)
        {
            return Repository.GetAll<Shipping>().FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của PCb vừa nhập đã có trong BOX hiện tại hay chưa
        /// Nếu có thì không cho làm việc
        /// Chưa có thì thực hiện thêm mới vào danh sách
        /// </summary>
        /// <returns></returns>
        public bool CheckPcbExitsOnBoxOrShip(string productId, IEnumerable<Shipping> shippings)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var shipping = shippings.FirstOrDefault(p => p.ProductID == productId);
                if (shipping != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Box
        /// </summary>
        /// <param name="boxId"></param>
        /// <returns></returns>
        public bool CheckBoxExits(string boxId)
        {
            if (boxId != null)
            {
                var shippings = Repository.GetAll<Shipping>().ToList();
                if (shippings.Any(c => c.BoxID == boxId))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Insert to Shipping
        /// </summary>
        /// <param name="operatorCode"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="poNo"></param>
        /// <param name="boxId"></param>
        /// <param name="productId"></param>
        /// <param name="macAddress"></param>
        public void InsertShipping(
            string operatorCode, 
            string modelId, 
            string workingOder, 
            int quantity,
            string poNo,
            string boxId,
            string productId,
            string macAddress)
        {
            var shipping = new Shipping()
            {
                ID = Guid.NewGuid(),
                Operator = operatorCode,
                Model = modelId,
                WorkingOder = workingOder,
                Quantity = 1,
                PO_NO = poNo,
                BoxID = boxId,
                ProductID = productId,
                MacAddress = macAddress,
                DateCheck = DateTime.Now,
            };
            try
            {
                Repository.Insert(shipping);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #region Models

        /// <summary>
        /// Trả về tất cả Model
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Model> GetModels()
        {
            return Repository.GetAll<Model>().ToList();
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
                var model = GetModels().FirstOrDefault(m => m.ModelID == modelId);
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
            Repository.Insert(model);
        }

        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="createdBy"></param>
        /// <param name="quantity"></param>
        /// <param name="serialNo"></param>
        public void UpdateModel(string modelId,string createdBy, int quantity, string serialNo)
        {
            var model = GetModels().FirstOrDefault(m => m.ModelID == modelId);
            if (model != null)
            {
                model.CreatedBy = createdBy;
                model.Quantity = quantity;
                model.SerialNo = serialNo;
                Repository.Update(model);
            }
        }

        #endregion


        #region Logs

        /// <summary>
        /// Toàn bộ danh sách QA
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_test_log> GetAllLogs()
        {
            return Repository.GetAll<tbl_test_log>().ToList();
        }

        public IEnumerable<tbl_test_log> GetLogsByMonths(DateTime startDate, DateTime endDate)
        {
            //DateTime start= startDate.
            //return Repository.GetAll<tbl_test_log>().Where()

            return null;
        } 

        /// <summary>
        /// Kiểm tra sự tồn tại của PCb vừa nhập đã có trong BOX hiện tại hay chưa
        /// Nếu có thì không cho làm việc
        /// Chưa có thì thực hiện thêm mới vào danh sách
        /// </summary>
        /// <returns></returns>
        public bool CheckPcbExitsOnBox(string productId, IEnumerable<tbl_test_log> logs)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var log = logs.FirstOrDefault(p => p.ProductionID == productId);
                if (log != null)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        /// <param name="qaCheck"></param>
        public void InsertLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, 
            string operatorCode)
        {
            var log = new tbl_test_log()
            {
                ProductionID = productionId,
                LineID = lineId,
                MacAddress = macAddress,
                BoxID = boxId,
                ModelID = modelId,
                WorkingOder = workingOder,
                DateCheck = DateTime.Now,
                TimeCheck = DateTime.Now.TimeOfDay,
                Quantity = quantity,
                OperatorCode = operatorCode,
            };

            try
            {
                Repository.Insert(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        public void UpdateLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, string operatorCode)
        {
            var log = GetPcbById(productionId);

            log.LineID = lineId;
            log.MacAddress = macAddress;
            log.BoxID = boxId;
            log.ModelID = modelId;
            log.WorkingOder = workingOder;
            log.DateCheck = DateTime.Now;
            log.TimeCheck = DateTime.Now.TimeOfDay;
            log.Quantity = quantity;
            log.OperatorCode = operatorCode;

            try
            {
                Repository.Update(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update QA Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="lineId"></param>
        /// <param name="macAddress"></param>
        /// <param name="boxId"></param>
        /// <param name="modelId"></param>
        /// <param name="workingOder"></param>
        /// <param name="quantity"></param>
        /// <param name="operatorCode"></param>
        public void UpdateQaCheckLogs(
            string productionId,
            int lineId,
            string macAddress,
            string boxId,
            string modelId,
            string workingOder,
            int quantity, string operatorCode)
        {
            var log = GetPcbById(productionId);

            log.LineID = lineId;
            log.MacAddress = macAddress;
            log.BoxID = boxId;
            log.ModelID = modelId;
            log.WorkingOder = workingOder;
            log.DateCheck = DateTime.Now;
            log.TimeCheck = DateTime.Now.TimeOfDay;
            log.Quantity = quantity;
            log.OperatorCode = operatorCode;

            try
            {
                Repository.Update(log);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        #region Log Result

        /// <summary>
        /// Get Production ID
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public tbl_test_result GetResultById(string productionId, int operationId)
        {
            return
                Repository.GetAll<tbl_test_result>().FirstOrDefault(op => op.ProductionID == productionId && op.OperationID == operationId);
        }

        /// <summary>
        /// Result check exits
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        public bool CheckResultExits(string productionId, int operationId)
        {
            var pcb = GetResultById(productionId, operationId);
            if (pcb != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa Result
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        public void DeleteResult(string productionId, int operationId)
        {
            var result = GetResultById(productionId, operationId);
            try
            {
                Repository.Delete(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Insert Result
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <param name="judge"></param>
        /// <param name="operatorId"></param>
        public void InsertResult(
            string productionId,
            int operationId,
            bool judge,
            string operatorId)
        {
            var result = new tbl_test_result()
            {
                ProductionID = productionId,
                OperationID = operationId,
                JudgeResult = judge,
                OperatorID = operatorId,
                OperationDate = DateTime.Now
            };
            try
            {
                Repository.Insert(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="operationId"></param>
        /// <param name="judge"></param>
        /// <param name="operatorId"></param>
        public void UpdateResult(
            string productionId,
            int operationId,
            bool judge,
            string operatorId)
        {
            var result = GetResultById(productionId, operationId);
            result.JudgeResult = judge;
            result.OperatorID = operatorId;
            result.OperationDate = DateTime.Now;
            
            try
            {
                Repository.Update(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Packing PO

        /// <summary>
        /// Trả về QtyPO và Remains theo workingOder và PoNo
        /// </summary>
        /// <param name="modelNo">Model</param>
        /// <param name="poNo">PO</param>
        public PackingPO GetPackingPoModelAndPoNo(string modelNo, string poNo)
        {
            var po = Repository.GetAll<PackingPO>().FirstOrDefault(p => (p.ModelID == modelNo) && (p.PO_NO == poNo));
            if (po != null)
            {
                return po;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelNo"></param>
        /// <param name="poNo"></param>
        /// <returns></returns>
        public PackingPO GetPoByModelAndPoNo(string modelNo, string poNo)
        {
            return Repository.GetAll<PackingPO>().FirstOrDefault(p => (p.ModelID == modelNo) && (p.PO_NO == poNo));
        }

        /// <summary>
        /// Insert PO
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="po"></param>
        /// <param name="qtyPo"></param>
        /// <param name="createdBy"></param>
        public void InsertPo(string modelId, string po, int qtyPo, string createdBy)
        {
            var poAdd = new PackingPO()
            {
                ModelID = modelId,
                PO_NO = po,
                QuantityPO = qtyPo,
                QuantityRemain = qtyPo,
                DateCreated = DateTime.Now,
                TimeCreated = DateTime.Now.TimeOfDay,
                CreateBy = createdBy,
            };

            try
            {
                Repository.Insert(poAdd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update PO
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="po"></param>
        /// <param name="qtyPo"></param>
        /// <param name="createdBy"></param>
        public void UpdatePo(string modelId, string po, int qtyPo, string createdBy)
        {
            var packingPo = GetPackingPoModelAndPoNo(modelId, po);

            if (packingPo != null)
            {
                packingPo.QuantityPO = packingPo.QuantityPO + qtyPo;
                packingPo.QuantityRemain = qtyPo;
                packingPo.DateCreated = DateTime.Now;
                packingPo.TimeCreated = DateTime.Now.TimeOfDay;
                packingPo.CreateBy = createdBy;

                try
                {
                    Repository.Update(packingPo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DeletePcbById(Guid id)
        {
            var shipping = GetShippingByGuiId(id);
            if (shipping != null)
            {
                try
                {
                    Repository.Delete(shipping);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poId"></param>
        /// <param name="modelNo"></param>
        /// <param name="remains"></param>
        public void UpdateRemainsForPo(string poId, string modelNo, int remains)
        {
            PackingPO po = GetPoByModelAndPoNo(modelNo, poId);
            po.QuantityRemain = remains;
            try
            {
                Repository.Update(po);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Operator

        /// <summary>
        /// Get all Operator
        /// </summary>
        /// <returns></returns>
        public IEnumerable<mst_operator> GetOperators()
        {
            return Repository.GetAll<mst_operator>().ToList();
        }

        /// <summary>
        /// Trả về Operator theo code
        /// </summary>
        /// <param name="operatorCode"></param>
        /// <returns></returns>
        public mst_operator GetOperatorByCode(string operatorCode)
        {
            return Repository.GetAll<mst_operator>().FirstOrDefault(op => op.OperatorID == operatorCode);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của Operator
        /// </summary>
        /// <param name="operatorCode"></param>
        /// <returns></returns>
        public bool CheckOperatorExits(string operatorCode)
        {
            var op = GetOperatorByCode(operatorCode);
            if (op != null)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
