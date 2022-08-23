using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();

        private void LoadProduct()
        {
            dgwProducts.DataSource = _productDal.getAll();
        }

        private void SearchProduct(String key)
        {
            //var result = _productDal.getAll().Where(p=>p.Name.ToLower()Contains(key.toLower())).ToList();
            var result = _productDal.getByName(key);
            dgwProducts.DataSource = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbName.Text,
                UnitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbStockAmount.Text)
            });
            LoadProduct();
            MessageBox.Show("Added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbUpdateName.Text,
                UnitPrice = Convert.ToDecimal(tbUpdateUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbUpdateStockAmount.Text)
            });
            LoadProduct();
            MessageBox.Show("Updated!");
        }

       private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            tbUpdateName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbUpdateUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbUpdateStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            LoadProduct();
            MessageBox.Show("Deleted!");
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(tbSearch.Text);
        }

        private void tbxGetById_Click(object sender, EventArgs e)
        {
            _productDal.getById(1);
        }
    }
}
