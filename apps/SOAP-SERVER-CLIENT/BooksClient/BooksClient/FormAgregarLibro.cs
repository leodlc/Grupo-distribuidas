using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BooksClient.BooksService;

namespace BooksClient
{
    public partial class FormAgregarLibro : Form
    {
        public FormAgregarLibro()
        {
            InitializeComponent();
            textBoxTitulo.KeyPress += new KeyPressEventHandler(ValidarEntrada);
            textBoxAutor.KeyPress += new KeyPressEventHandler(ValidarEntrada);
            textBoxAnoPublicacion.KeyPress += new KeyPressEventHandler(ValidarEntradaNumeros);
            textBoxEditorial.KeyPress += new KeyPressEventHandler(ValidarEntrada);
            textBoxISBN.KeyPress += new KeyPressEventHandler(ValidarEntrada);
        }
        private void ValidarEntrada(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, números, espacios, puntos y comas
            char ch = e.KeyChar;

            if (!char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch) && ch != '.' && ch != ',' && ch != '\b' && ch != '-') // \b es la tecla de retroceso
            {
                e.Handled = true;
                MessageBox.Show("Caracter no permitido. Solo se permiten letras, números, espacios, puntos y comas.");
            }
        }
        private void ValidarEntradaNumeros(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de retroceso
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != '\b') // \b es la tecla de retroceso
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.");
            }
        }

        private void FormAgregarLibro_Load(object sender, EventArgs e)
        {
            // Puedes realizar alguna inicialización adicional aquí si es necesario
        }

        private async void buttonGuardar_Click(object sender, EventArgs e)
        {
      
        }

        private async Task CreateBook(libro book)
        {
            try
            {
                var client = new LibrosPortClient();
                var request = new createLibroRequest() { libro = book };
                var response = await client.createLibroAsync(request);
                MessageBox.Show("Libro creado exitosamente.");
                // Puedes agregar lógica adicional aquí después de crear el libro, si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el libro: {ex.Message}");
            }
        }

        private async void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Validar los datos antes de crear el libro
            if (string.IsNullOrWhiteSpace(textBoxTitulo.Text) || string.IsNullOrWhiteSpace(textBoxAutor.Text) || string.IsNullOrWhiteSpace(textBoxAnoPublicacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear un objeto de tipo libro con los datos del formulario
            libro newBook = new libro()
            {
                // Asignar los valores de las propiedades del libro desde los controles del formulario
                titulo = textBoxTitulo.Text,
                autor = textBoxAutor.Text,
                anoPublicacion = Convert.ToInt64(textBoxAnoPublicacion.Text),
                editorial = textBoxEditorial.Text,
                isbn = textBoxISBN.Text,
                // Asigna otros valores según sea necesario
            };

            // Llamar a la función para crear el libro
            await CreateBook(newBook);

            // Cerrar el formulario después de guardar el libro
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
