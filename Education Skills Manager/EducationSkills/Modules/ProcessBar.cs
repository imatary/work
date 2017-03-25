using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationSkills.Modules
{
    public partial class ProcessBar : Form
    {
        public int Count { get; set; }
        public ProcessBar(int count)
        {
            InitializeComponent();
        }
    }
}
