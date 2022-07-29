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
    public partial class frmTipoCliente : Form
    {
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnEdit;
        private DataGridView dgvDatos;

        public frmTipoCliente()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 124);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.Size = new System.Drawing.Size(298, 150);
            this.dgvDatos.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(223, 77);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 31);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Cargar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 81);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Nuevo";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(124, 81);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmTipoCliente
            // 
            this.ClientSize = new System.Drawing.Size(322, 286);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvDatos);
            this.Name = "frmTipoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Tipo de Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos() {
            var adaptador = new dsAppTableAdapters.TipoClienteTableAdapter();
            var tabla = adaptador.GetData();
            dgvDatos.DataSource = tabla;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoClienteEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if(id>0)
            {
                var frm = new frmTipoClienteEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un id valido","Sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        private int getId()
        {
            try
            {
                //que queremos porcesar
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if(filaActual ==null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                //¿q hacer en caso de error?
                return 0;
            }
            
        }
    }
}
