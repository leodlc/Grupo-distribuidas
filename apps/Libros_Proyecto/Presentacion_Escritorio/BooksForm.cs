using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Presentacion_Escritorio
{
    public partial class BooksForm : Form
    {
        private FlowLayoutPanel booksPanel;
        private const string BaseUrl = "http://localhost:54845/";

        public BooksForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(BooksForm_Load);
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Gestión de Libros";
            this.Size = new Size(800, 600);

            var btnAddBook = new Button
            {
                Text = "Añadir Libro",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddBook.Click += BtnAddBook_Click;
            this.Controls.Add(btnAddBook);

            booksPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(booksPanel);

            LoadAllBooks();
        }

        private async void LoadAllBooks()
        {
            var books = await GetBooksAsync();
            DisplayBooks(books);
        }

        private async Task<List<Book>> GetBooksAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "api/Book/GetAll");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Book>>(json);
            }
        }

        private void DisplayBooks(List<Book> books)
        {
            booksPanel.Controls.Clear();
            foreach (var book in books)
            {
                var bookPanel = CreateBookPanel(book);
                booksPanel.Controls.Add(bookPanel);
            }
        }

        private Panel CreateBookPanel(Book book)
        {
            var panel = new Panel
            {
                Width = 200,
                Height = 300,
                Margin = new Padding(10)
            };

            var pictureBox = new PictureBox
            {
                ImageLocation = book.ImageUrl,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 180,
                Height = 200,
                Dock = DockStyle.Top
            };
            panel.Controls.Add(pictureBox);

            var lblTitle = new Label
            {
                Text = book.Title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            panel.Controls.Add(lblTitle);

            var lblAuthor = new Label
            {
                Text = "Autor: " + book.Author,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lblAuthor);

            var lblYear = new Label
            {
                Text = "Año: " + book.Year,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lblYear);

            return panel;
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            // Lógica para añadir un libro
            MessageBox.Show("Añadir Libro");
        }
    }

    public class Book
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}
