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
    public partial class FormEditarLibro : Form
    {
        private libro book;

        public FormEditarLibro(libro book)
        {
            InitializeComponent();
            this.book = book;
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


        private void FormEditarLibro_Load(object sender, EventArgs e)
        {
            textBoxTitulo.Text = book.titulo;
            textBoxAutor.Text = book.autor;
            textBoxISBN.Text = book.isbn;
            textBoxEditorial.Text = book.editorial;
            textBoxAnoPublicacion.Text = book.anoPublicacion.ToString();

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Actualizar los datos del libro con la información de los cuadros de texto
           

            book.titulo = textBoxTitulo.Text;
            book.autor = textBoxAutor.Text;
            book.isbn = textBoxISBN.Text;
            book.editorial = textBoxEditorial.Text;
            book.anoPublicacion = int.Parse(textBoxAnoPublicacion.Text);

            // Guardar los cambios en el libro (puedes llamar a un método en tu servicio web para esto)
            SaveChanges();

            // Cerrar el formulario después de guardar los cambios
            this.Close();
        }
        private void SaveChanges()
        {
            try
            {
                var client = new LibrosPortClient();
                var request = new updateLibroRequest() { libro = book };
                var response = client.updateLibro(request);
                MessageBox.Show("Cambios guardados exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar cambios: {ex.Message}");
            }
        }
    }
}
