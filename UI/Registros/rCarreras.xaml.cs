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

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Carrera;
        }

        private void Limpiar()
        {
            this.Carrera = new Carreras();
            this.DataContext = Carrera;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Carrera.Nombre))
            {
                esValido = false;
                CarreraTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = CarrerasBLL.Buscar(this.Carrera.CarreraID);

            if (encontrado != null)
            {
                this.Carrera = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro la carrera!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            paso = CarrerasBLL.Guardar(Carrera);

            if (paso)
                MessageBox.Show("La carrera se a guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarrerasBLL.Eliminar(Carrera.CarreraID))
            {
                Limpiar();
                MessageBox.Show("La carrera se a eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar la carrera", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
