using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.GUI
{
    public partial class ShowControlsForm : XtraForm
    {
        public ShowControlsForm()
        {
            InitializeComponent();
        }


        private void ShowControls()
        {
           Assembly myAssembly = Assembly.GetEntryAssembly();
           Type[] types = myAssembly.GetTypes();
           foreach (Type myType in types)
              
          {
               if (myType.BaseType == null) continue;

              if (myType.BaseType.FullName == "DevExpress.XtraEditors.XtraForm")
              {
                  MessageBox.Show(myType.Name);
              }
              else
              {
                  MessageBox.Show(myType.Name);
              }      
               
           }      
        }

        private void LoadAllForms()
        {
            try
            {
                Assembly projectA = Assembly.Load("Stock.GUI"); // replace with actual ProjectA name 
                // despite all Microsoft's dire warnings about loading from a simple name,
                // you should be fine here as long as you don't have multiple versions of ProjectA
                // floating around

                foreach (Type t in projectA.GetTypes())
                {
                    if (t.BaseType == typeof(XtraForm))
                    {
                        var emptyCtor = t.GetConstructor(Type.EmptyTypes);
                        if (emptyCtor != null)
                        {
                            var f = (XtraForm)emptyCtor.Invoke(new object[] { });
                            // t.FullName will help distinguish the unwanted entries and
                            // possibly later ignore them
                            string formItem = t.FullName + " // " + f.Text + " // " + f.Name;
                            checkedListBox1.Items.Add(formItem);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                XtraMessageBox.Show(err.Message);
            }
        }
        private void ShowControlsForm_Load(object sender, EventArgs e)
        {
            LoadAllForms();
        }
    }
}