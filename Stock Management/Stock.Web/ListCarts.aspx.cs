using System;
using Stock.Web.Models;

namespace Stock.Web
{
    public partial class ListCarts : System.Web.UI.Page
    {
        private readonly Cart.Order _order = new Cart.Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = _order.Carts;
                GridView1.DataBind();
            }
        }
    }
}