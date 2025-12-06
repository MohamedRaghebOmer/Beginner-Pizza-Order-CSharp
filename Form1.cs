using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class frmPizzaOrder : Form
    {
        float GetSelectedWhereToEatPrice()
        {
            if (rbEatIn.Checked)
                return Convert.ToSingle(rbEatIn.Tag.ToString());
            else
                return Convert.ToSingle(rbTakeOut.Tag.ToString());
        }       

        float GetSelectedCrustTypePrice()
        {
            if (rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag.ToString());
            else
                return Convert.ToSingle(rbThinkCrust.Tag.ToString());            
        }

        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag.ToString());

            if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag.ToString());

            // not small and not medium -> thin large
            return Convert.ToSingle(rbLarge.Tag.ToString());
        }

        float GetSelectedToppingsPrice()
        {
            float price = 0f;

            if (cbExtraCheese.Checked)
                price = Convert.ToSingle(cbExtraCheese.Tag.ToString());

            if (cbOnion.Checked)
                price += Convert.ToSingle(cbOnion.Tag.ToString());

            if (cbMushrooms.Checked)
                price += Convert.ToSingle(cbMushrooms.Tag.ToString());

            if (cbOlives.Checked)
                price += Convert.ToSingle(cbOlives.Tag.ToString());

            if (cbTomatoas.Checked)
                price += Convert.ToSingle(cbTomatoas.Tag.ToString());

            if (cbGreenPapers.Checked)
                price += Convert.ToSingle(cbGreenPapers.Tag.ToString());

            return price;
        }
     
        float GetTotalPrice()
        {
            return GetSelectedToppingsPrice() +
                GetSelectedSizePrice() + GetSelectedCrustTypePrice() +
                GetSelectedWhereToEatPrice();
        }
        
        void UpdatePrice()
        {
            lblPrice.Text = "$" + Convert.ToString(GetTotalPrice());
        }
        
        void ChangeSize()
        {
            UpdatePrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        void UpdateCrust()
        {
            UpdatePrice();

            if (rbThinCrust.Checked)
            {
                lblCurstType.Text = "Thin Crust";
                return;
            }

            lblCurstType.Text = "Think Crust";

        }
        
        void UpdateWhereToEat()
        {
            UpdatePrice();

            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }

            lblWhereToEat.Text = "Take Out";
        }

        void UpdateToppings() 
        { 
            UpdatePrice(); 

            string toppings = ""; 

            if (cbExtraCheese.Checked) 
                toppings = "Extra Cheese"; 
            
            if (cbOnion.Checked) 
                toppings += ", Onion"; 
            
            if (cbMushrooms.Checked) 
                toppings += ", Mushrooms"; 
            
            if (cbOlives.Checked) 
                toppings += ", Olives"; 
            
            if (cbTomatoas.Checked) 
                toppings += ", Tomatoas"; 
            
            if (cbGreenPapers.Checked) 
                toppings += ", Green Paper"; 
            
            // delete ',' from the beginning if existed
            if (toppings.StartsWith(",")) 
                toppings = toppings.Substring(1).Trim(); 
            
            if (toppings == "") 
                toppings = "No Toppings"; 
            
            lblToppings.Text = toppings; 
        }



        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPizzaOrder_Load(object sender, EventArgs e)
        {

        }

        private void gbToppings_Enter(object sender, EventArgs e)
        {

        }

        private void gbWhereToEat_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            // reset size
            rbSmall.Select();

            // reset Curst Thin
            rbThinCrust.Select();

            // Reset Where to eat
            rbEatIn.Select();

            // Reset CheckBox->Extra Cheese
            cbExtraCheese.Checked = false;

            // Reset CheckBox->Onion Cheese
            cbOnion.Checked = false;

            // Reset CheckBox->Mushrooms
            cbMushrooms.Checked = false;

            // Reset CheckBox->Olives
            cbOlives.Checked = false;

            // Reset CheckBox->Tomatoas
            cbTomatoas.Checked = false;

            // Reset CheckBox->Green Papers
            cbGreenPapers.Checked = false;

            lblSize.Text = "Small";
            lblToppings.Text = "No-Toppings";
            lblCurstType.Text = "Thin Crust";
            lblWhereToEat.Text = "Eat In";
            

            // reset groups
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbToppings.Enabled = true;

            // update price
            lblPrice.Text = GetTotalPrice().ToString();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            ChangeSize();
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbTomatoas_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void cbGreenPapers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void gbOrderSummary_Enter(object sender, EventArgs e)
        {

        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cofirm this order?", "Cofirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order cofirmed successfly", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disabel all buttons
                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;
                gbToppings.Enabled = false;
            }
        }
    
        
    }
}
