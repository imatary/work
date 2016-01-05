using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IndicateReport
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            m_Sb = new StringBuilder();
            m_bDirty = false;
            m_bIsWatching = false;
        }

        private StringBuilder m_Sb;
        private bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        private bool m_bIsWatching;


        private void Form2_Load(object sender, EventArgs e)
        {
            if (m_bIsWatching)
            {
                m_bIsWatching = false;
                m_Watcher.EnableRaisingEvents = false;
                m_Watcher.Dispose();
            }
            else
            {
                m_bIsWatching = true;
                m_Watcher = new FileSystemWatcher
                {
                    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };

                m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                m_Watcher.Created += new FileSystemEventHandler(OnChanged);
                m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                m_Watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!m_bDirty)
            {
                m_bDirty = true;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!m_bDirty)
            {
                m_bDirty = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_bDirty)
            {
                MessageBox.Show("Show");
                m_bDirty = false;
            }
        }
    }
}
