using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryNievasAgenda
{
    internal class clsConexionBD
    {

        string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BDAgenda.accdb";
        OleDbConnection coneccionBaseDatos;
        OleDbCommand comandoBaseDatos;
        OleDbDataReader lectorDataReader;


        public string nombreBaseDeDatos;
        public void ConectarBD()
        {
            try
            {

                coneccionBaseDatos = new OleDbConnection(cadenaConexion);

                coneccionBaseDatos.Open();
                nombreBaseDeDatos = coneccionBaseDatos.Database;


                MessageBox.Show("Conectado a " + nombreBaseDeDatos);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }

        }
    }
}

