using StoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example03
{
    public partial class Form1 : Form
    {
        private Order order;
        private Customer customer;

        //-------------------------------------------------
        //Form/Button Setting
        //-------------------------------------------------
        public Form1()
        {
            InitializeComponent();

            this.customer = new Customer();

            this.customer.Name = "張元鴻";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderScreen();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            this.order = new Order();
            this.order.Customer = this.customer;
            RenderScreen();
        }

        private void product1Button_Click(object sender, EventArgs e)
        {
            this.order.ProductList.Add(new Product() { Name = "豆漿", Price = 15 });
            RenderScreen();
        }

        private void product2Button_Click(object sender, EventArgs e)
        {
            this.order.ProductList.Add(new Product() { Name = "油條", Price = 10 });
            RenderScreen();
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0}, 結帳金額 : {1} ， 謝謝惠顧。",
                this.order.Customer.Name, this.order.GetTotal()));

            this.order = null;
            RenderScreen();
        }

        private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedIndex = tableComboBox.SelectedIndex;

            this.customer.Name = tableComboBox.Items[SelectedIndex].ToString() + "桌";
            RenderScreen();
        }

        //-------------------------------------------------
        //Reload Screen
        //-------------------------------------------------
        private void RenderScreen()
        {
            this.customerLabel.Text = this.customer.Name;
            this.orderButton.Text = "點餐";
            this.product1Button.Text = "豆漿";
            this.product2Button.Text = "油條";
            this.accountButton.Text = "結帳";

            if (this.order != null)
            {
                orderButton.Enabled = false;
                product1Button.Enabled = true;
                product2Button.Enabled = true;

                //    string orderDetail = string.Empty;
                //    orderDetail = string.Format("點餐明細 : \n");

                //     float total = 0.0f;

                //     //新增資訊
                //     foreach (Product product in this.order.ProductList)
                //     {
                //         orderDetail += string.Format("{0} : {1} 元\n", product.Name, product.Price);
                //         total = total + product.Price;
                //     }
                //     //小計
                //     orderDetail += string.Format("結帳金額 : {0}\n", total);

                //Output Info.
                this.orderRichTextBox.Text = order.GetOrderDetail();
            }
            else
            {
                orderButton.Enabled = true;
                product1Button.Enabled = false;
                product2Button.Enabled = false;

                orderRichTextBox.Text = string.Empty;
            }
        }

        //-------------------------------------------------
    }
}