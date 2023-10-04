using PedidosSLN.datos;
using PedidosSLN.datos.DTOs;
using PedidosSLN.Servicios.Implementacion;
using PedidosSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosSLN.presentación
{
    public partial class FrmConsultar : Form
    {
        IServicio gestor;
       
        public FrmConsultar()
        {
            InitializeComponent();
            gestor = new Servicio();
            
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarCombo();
        }

        private void CargarCombo()
        {
            cboClientes.Items.Clear();
            cboClientes.Items.AddRange(gestor.ObtenerClientes().ToArray());
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lParametro = new List<Parametro>();
            if (cboClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir un cliente...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("Por favor, la fecha desde tiene que ser menor a la de fecha hasta..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(dtpHasta.Value > DateTime.UtcNow)
            {
                MessageBox.Show("Ingrese una fecha maxima valida", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ClienteDTO cliente = (ClienteDTO)cboClientes.SelectedItem;
            lParametro.Add(new Parametro("@cliente", cliente.Id));
            lParametro.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lParametro.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            List<PedidoDTO> lPedidos = gestor.ObtenerPedidos(lParametro);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedidos.CurrentCell.ColumnIndex == 5) //Añadimos el boton quitar
            {
                dgvPedidos.Rows.RemoveAt(dgvPedidos.CurrentRow.Index);
            }
        }
    }
}
