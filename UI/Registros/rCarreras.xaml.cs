using System.Windows;
using Tarea3_Registro_Estudiantes.Entidades;
using Tarea3_Registro_Estudiantes.BLL;

namespace Tarea3_Registro_Estudiantes.UI.Registros
{
    public partial class rCarreras : Window
    {
        private Carreras Carrera = new Carreras();

        public rCarreras()
        {
            InitializeComponent();

            this.DataContext = Carrera;
        }

        
    }
}
