using System.Windows;
using Tarea3_Registro_Estudiantes.Entidades;
using Tarea3_Registro_Estudiantes.BLL;

namespace Tarea3_Registro_Estudiantes.UI.Registros
{
    public partial class rEstudiantes : Window
    {
        private Estudiantes Estudiantes = new Estudiantes();

        public rEstudiantes()
        {
            InitializeComponent();

            this.DataContext = Estudiantes;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Estudiantes;
        }

        private void Limpiar()
        {
            this.Estudiantes = new Estudiantes();
            this.DataContext = Estudiantes;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Estudiantes.Nombres))
            {
                esValido = false;
                NombreTextBox.Focus();
                MessageBox.Show("Debe indicar el nombre!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            
            } 
            else if (string.IsNullOrWhiteSpace(Estudiantes.Email))
            {

                esValido = false;
                EmailTextBox.Focus();
                MessageBox.Show("Debe indicar el Email!", "Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            
            }

            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = EstudiantesBLL.Buscar(this.Estudiantes.EstudiantesID);

            if (encontrado != null)
            {
                this.Estudiantes = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No se encontro el libro!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
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

            paso = EstudiantesBLL.Guardar(Estudiantes);

            if (paso)
                MessageBox.Show("Libro guardado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No se pudo guardar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Estudiantes.EstudiantesID))
            {
                Limpiar();
                MessageBox.Show("Libro eliminado con éxito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el libro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ValidarEmail(string email){
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }

        private bool ValidarTexto(string texto){

            bool auxiliar = true;

            if( texto != " " ||    
                texto.Contains('!') ||
                texto.Contains('@') ||
                texto.Contains('#') ||
                texto.Contains('$') ||
                texto.Contains('%') ||
                texto.Contains('^') ||
                texto.Contains('&') ||
                texto.Contains('*') ||
                texto.Contains('(') ||
                texto.Contains(')') ||
                texto.Contains('1') ||
                texto.Contains('2') ||
                texto.Contains('3') ||
                texto.Contains('4') ||
                texto.Contains('5') ||
                texto.Contains('6') ||
                texto.Contains('7') ||
                texto.Contains('8') ||
                texto.Contains('9'))
                {
                    auxiliar = false;
                }

                return auxiliar;
        }
    }
}
