using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryNievasAgenda
{
    public partial class frmAgenda : Form
    {
        private string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmActividades frmActividades = new frmActividades();
            if (frmActividades.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla(); // método que vuelve a leer la tabla y muestra las actividades actualizadas
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Validar selección
                if (dgvDatos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná una actividad para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2️⃣ Obtener el IdActividad de la fila seleccionada
                int idActividad = Convert.ToInt32(dgvDatos.CurrentRow.Cells["IdActividad"].Value);

                // 3️⃣ Confirmar con el usuario
                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de que querés eliminar esta actividad?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.No)
                    return;

                // 4️⃣ Ejecutar el DELETE en Access
                string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
                string sql = "DELETE FROM Actividad WHERE IdActividad = ?";

                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                using (OleDbCommand comando = new OleDbCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("?", idActividad);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    conexion.Close();

                    // 5️⃣ Informar y recargar
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Actividad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla(); // refresca la grilla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la actividad seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la actividad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RevisarAvisos()
        {
            string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
            string sql = "SELECT IdActividad, Asuntos, Fecha, Avisado24, Avisado12 FROM Actividad";

            using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
            using (OleDbCommand comando = new OleDbCommand(sql, conexion))
            using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                foreach (DataRow fila in tabla.Rows)
                {
                    int id = Convert.ToInt32(fila["IdActividad"]);
                    string asunto = fila["Asuntos"].ToString();
                    DateTime fecha = Convert.ToDateTime(fila["Fecha"]);
                    bool avisado24 = fila["Avisado24"] != DBNull.Value && Convert.ToBoolean(fila["Avisado24"]);
                    bool avisado12 = fila["Avisado12"] != DBNull.Value && Convert.ToBoolean(fila["Avisado12"]);

                    TimeSpan diferencia = fecha - DateTime.Now;

                    // Mostrar aviso 24 horas antes
                    if (!avisado24 && diferencia.TotalHours <= 24 && diferencia.TotalHours > 0)
                    {
                        MostrarAviso(asunto, fecha, 24);
                        ActualizarAviso(id, "Avisado24");
                    }

                    // Mostrar aviso 12 horas antes
                    if (!avisado12 && diferencia.TotalHours <= 12 && diferencia.TotalHours > 0)
                    {
                        MostrarAviso(asunto, fecha, 12);
                        ActualizarAviso(id, "Avisado12");
                    }
                }
            }
        }

        private void MostrarAviso(string asunto, DateTime fecha, int horas)
        {
            MessageBox.Show($"La actividad '{asunto}' vence el {fecha:dd/MM/yyyy HH:mm}.\n" +
                            $"Este es un recordatorio {horas} horas antes.",
                            "Aviso de vencimiento",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void ActualizarAviso(int id, string columna)
        {
            string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
            string sql = $"UPDATE Actividad SET {columna} = True WHERE IdActividad = ?";

            using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
            using (OleDbCommand comando = new OleDbCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("?", id);
                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        private void timerAvisos_Tick_1(object sender, EventArgs e)
        {
            RevisarAvisos();
        }
        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            clsConexionBD clsConexionBD_V2 = new clsConexionBD();
            clsConexionBD_V2.ConectarBD();
            CargarGrilla();
            timerAvisos.Start();

        }
        private void CargarGrilla()
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(cadenaConexion))
                {
                    string sql = "SELECT IdActividad, Asuntos, Fecha, Observacion FROM Actividad ORDER BY Fecha";

                    using (OleDbCommand comando = new OleDbCommand(sql, conexion))
                    using (OleDbDataAdapter adaptador = new OleDbDataAdapter(comando))
                    {
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        dgvDatos.DataSource = tabla;
                    }
                }

                // Ajuste visual (opcional)
                dgvDatos.Columns["IdActividad"].Visible = false; // ocultar ID si no lo querés mostrar
                dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
