using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class IssueDetailService
    {
        private readonly StockDataEntities _context;

        public IssueDetailService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<IssueDetail> GetIssueDetails()
        {
            var context = new StockDataEntities();
            return context.IssueDetails.ToList();

        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="issueDetail"></param>
        /// <returns></returns>
        public void Add(IssueDetail issueDetail)
        {
            _context.IssueDetails.Add(issueDetail);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="issueDetail"></param>
        public void Update(IssueDetail issueDetail)
        {
            _context.IssueDetails.Attach(issueDetail);
            _context.Entry(issueDetail).State = EntityState.Modified;
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}