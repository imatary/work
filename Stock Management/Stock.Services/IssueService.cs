using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class IssueService
    {
        private readonly StockDataEntities _context;

        public IssueService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Issue> GetIssues()
        {
            var context = new StockDataEntities();

            return context.Issues.ToList();

        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="issueId">ID</param>
        /// <returns></returns>
        public Issue GetIssueById(string issueId)
        {
            return _context.Issues.FirstOrDefault(u => u.IssueID == issueId);
        }

        public bool CheckIssueIdExit(string issueId)
        {
            Issue issue = GetIssueById(issueId);
            if (issue != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        public void Add(Issue issue)
        {
            _context.Issues.Add(issue);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var issues = GetIssues();
            if (issues != null)
            {
                Issue issue = issues.LastOrDefault();
                if (issue != null)
                {
                    string lastId = issue.IssueID.Remove(0, 3);
                    string issueId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        issueId = string.Format("XK{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        issueId = string.Format("XK0000{0}", 1);
                    }
                    return issueId;
                }
                return string.Format("XK0000{0}", 1);
            }
            return string.Format("XK0000{0}", 1);
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="issue"></param>
        public void Update(Issue issue)
        {
            _context.Issues.Attach(issue);
            _context.Entry(issue).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="issueId"></param>
        public void Delete(string issueId)
        {
            Issue issue = GetIssueById(issueId);
            _context.Issues.Remove(issue);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}