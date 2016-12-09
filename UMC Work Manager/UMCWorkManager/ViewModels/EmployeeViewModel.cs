using System.Collections.Generic;
using UMCWorkManager.Models;

namespace UMCWorkManager.ViewModels
{
    public class EmployeeViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}