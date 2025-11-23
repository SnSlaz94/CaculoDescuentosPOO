using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaculoDescuentosPOO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un valor numerico y mayor que cero.");
                txtPrecio.Focus();
                lblResultado.Text = "Esperando datos...";
                return;
            }

            string nombre = txtNombre.Text;
            string tipo = cmbTipoProducto.SelectedItem?.ToString();
            Producto productoSeleccionado = null;


            if (tipo=="Tecnología")
            {
                productoSeleccionado = new ProductoTecnologia(nombre, precio);
            }
            else if (tipo=="Alimento")
            {
                productoSeleccionado=new ProductoAlimento(nombre, precio);
             }
            else if(tipo == "General")
            {
                productoSeleccionado = new ProductoGeneral(nombre, precio);   
            }

            if (productoSeleccionado==null)
            {
                MessageBox.Show("Debe seleccionar un tipo de producto");
                return;
            }

            decimal precioFinal = productoSeleccionado.CalcularDescuento();

            lblResultado.Text = $"Precio Final: {precioFinal:C}";

            MessageBox.Show($"El valor final con descuento es: {precioFinal:C}", "Cálculo de Descuento");
                
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
        }
    }
}
