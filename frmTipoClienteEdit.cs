using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class frmTipoClienteEdit : Form
    {
        private int? id;
        public frmTipoClienteEdit(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int estado = chkEstado.Checked ? 1 : 0;
            string nombre = txtName.Text;
            var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
            if(this.id==null)
            {
                adaptador.Add(nombre, (byte)estado);
            }else
            {
                adaptador.Edit(nombre, (byte)estado, (int)this.id);
            }
            
            this.Close();
        }

        private void frmTipoClienteEdit_Load(object sender, EventArgs e)
        {
            if(this.id != null)
            {
                this.Text = "Editar";
                var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
                var tabla = adaptador.GetDataById((int)this.id);
                var fila = (dsApp.TipoClienteRow) tabla.Rows[0];
                txtName.Text = fila.Nombre;
                chkEstado.Checked = fila.Estado == 1 ? true: false;
            }else
            {
                this.Text = "Nuevo";
            }
        }
    }
}
