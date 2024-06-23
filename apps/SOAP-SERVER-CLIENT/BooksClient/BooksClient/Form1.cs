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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            ConfigureDataGridView();
        }
        private void ConfigureDataGridView()
        {
            // Agregar columnas al DataGridView
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Editar";
            editColumn.Text = "Editar";
            editColumn.UseColumnTextForButtonValue = true;
            editColumn.Name = "Editar"; // Establecer el nombre de la columna

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Eliminar";
            deleteColumn.Text = "Eliminar";
            deleteColumn.UseColumnTextForButtonValue = true;
            deleteColumn.Name = "Eliminar"; // Establecer el nombre de la columna

            dataGridView1.Columns.Add(editColumn);
            dataGridView1.Columns.Add(deleteColumn);

            // Ocultar la columna idSpecified


            // Manejar el evento CellContentClick para los botones de editar y eliminar
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }
        /*
        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var icon = Properties.Resources.edit.ToBitmap(); // Convertir el icono a Bitmap
                int iconWidth = icon.Width/5;
                int iconHeight = icon.Height/5;

                // Calcular la posición del icono en la celda
                int iconX = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 4;
                int iconY = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 4;

                // Dibujar el icono en la celda
                e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                e.Handled = true;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var icon = Properties.Resources.delete.ToBitmap(); // Convertir el icono a Bitmap
                int iconWidth = icon.Width/5;
                int iconHeight = icon.Height/5;

                // Calcular la posición del icono en la celda
                int iconX = e.CellBounds.Left + (e.CellBounds.Width - iconWidth) / 4;
                int iconY = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 4;

                // Dibujar el icono en la celda
                e.Graphics.DrawImage(icon, new Rectangle(iconX, iconY, iconWidth, iconHeight));
                e.Handled = true;
            }
        }


        */

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón de editar
            int editColumnIndex = dataGridView1.Columns["Editar"].Index;
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                libro selectedBook = selectedRow.DataBoundItem as libro;

                // Crear un nuevo formulario de edición y pasar el libro seleccionado
                FormEditarLibro formEditar = new FormEditarLibro(selectedBook);
                formEditar.ShowDialog(); // Mostrar el formulario como modal

                // Después de cerrar el formulario de edición, recargar los libros
                LoadBooks();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Confirmar con el usuario si realmente desea eliminar el libro
                var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar este libro?",
                                                    "Confirmar Eliminación",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Obtener el libro correspondiente a la fila seleccionada
                    var selectedBook = dataGridView1.Rows[e.RowIndex].DataBoundItem as libro;

                    // Eliminar el libro
                    DeleteBook(selectedBook);
                }
            }
        }

        private void DeleteBook(libro book)
        {
            try
            {
                var client = new LibrosPortClient();
                var request = new deleteLibroRequest() { id = book.id }; // Suponiendo que `id` es el identificador único del libro
                var response = client.deleteLibro(request);
                MessageBox.Show("Libro eliminado exitosamente.");
                LoadBooks(); // Actualizar la lista de libros después de eliminar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el libro: {ex.Message}");
            }
        }


        private async void LoadBooks()
        {
            try
            {
                var client = new LibrosPortClient();
                var request = new getAllLibrosRequest();
                var response = await client.getAllLibrosAsync(request);
                var books = response.getAllLibrosResponse1;

                // Crear un BindingSource
                var bindingSource = new BindingSource();
                bindingSource.DataSource = books;

                // Establecer el BindingSource como origen de datos del DataGridView
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns["idSpecified"].Visible = false;
                dataGridView1.Columns["titulo"].HeaderText = "Título";
                dataGridView1.Columns["id"].HeaderText = "Identificador";

                dataGridView1.Columns["autor"].HeaderText = "Autor";
                dataGridView1.Columns["editorial"].HeaderText = "Editorial";
                dataGridView1.Columns["anoPublicacion"].HeaderText = "Año de Publicación";
                dataGridView1.Columns["isbn"].HeaderText = "ISBN";

                // Establecer el estilo de la columna para que ocupe todo el espacio disponible
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Manejar el evento CellContentClick para los botones de editar y eliminar



                // Refrescar el DataGridView
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar libros: {ex.Message}");
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void getAllLibrosResponseBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }




        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAgregarLibro formAdd = new FormAgregarLibro();
            formAdd.ShowDialog(); // Mostrar el formulario como modal
            LoadBooks();
        }
    }
}