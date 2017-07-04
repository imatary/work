using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MurataSystem.Net45
{
    public partial class Form1 : Form
    {
        string URI = "http://localhost:64368/api/product";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetAllProduct_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }


        #region Methods

        private async void GetAllProducts() 
        { 
            using (var client = new HttpClient())             
            {
                using (var response = await client.GetAsync(URI))
                {                     
                    if (response.IsSuccessStatusCode) 
                    {                         
                        var productJsonString = await response.Content.ReadAsStringAsync();

                        dataGridView1.DataSource = JsonConvert.DeserializeObject<Product[]>(productJsonString).ToList();                       

                    }
                }             
            } 
        }
        
        private async void AddProduct()
        {           
            Product p = new Product();
            p.Id = 3;
            p.Name = "Rolex";
            p.Category = "Watch";
            p.Price = 1299936;
            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(p);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);
            }
            GetAllProducts();                       
        }



        private async void UpdateProduct()
        {
            Product p = new Product();
            p.Id = 3;
            p.Name = "Rolex";
            p.Category = "Watch";
            p.Price = 1400000; //changed the price

            using (var client = new HttpClient())
            {
                var serializedProduct = JsonConvert.SerializeObject(p);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                var result = await client.PutAsync(String.Format("{0}/{1}", URI, p.Id), content);
            }
            GetAllProducts(); 
        }


        private async void DeleteProduct()
        {
            using (var client = new HttpClient())
            {                
                var result = await client.DeleteAsync(String.Format("{0}/{1}", URI, 3));
            }            
            GetAllProducts();
        }

        #endregion
    }
}
