using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Presentacion_Escritorio
{
    public partial class Form1 : Form
    {
        private Panel mainPanel;
        private DataGridView dataGridView;
        private const string BaseUrl = "http://localhost:54845/";

        private Button btnHome;
        private Button btnLoans;
        private Button btnBooks;
        private Button btnClients;
        private Button btnGenres;
        private Button btnAuthors;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeCustomComponents();
            LoadHomePage(); // Cargar la página de inicio inicialmente
        }

        private void InitializeCustomComponents()
        {
            // Configuración del TableLayoutPanel
            var tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // Configuración del Panel del Menú Lateral
            var menuPanel = CreateMenuPanel();

            // Configuración del Panel Principal
            mainPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

            // Agregar Paneles al TableLayoutPanel
            tableLayoutPanel.Controls.Add(menuPanel, 0, 0);
            tableLayoutPanel.Controls.Add(mainPanel, 1, 0);

            // Agregar TableLayoutPanel al Formulario
            this.Controls.Add(tableLayoutPanel);
        }

        private Panel CreateMenuPanel()
        {
            var menuPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke
            };

            // Agregar logo primero
            var pictureBoxLogo = new PictureBox
            {
                ImageLocation = "C:\\Users\\Shadow Moon\\OneDrive\\Escritorio\\Grupo-distribuidas\\apps\\Libros_Proyecto\\images\\logo.jpg",
                SizeMode = PictureBoxSizeMode.StretchImage,
                Height = 100,
                Dock = DockStyle.Top
            };
            menuPanel.Controls.Add(pictureBoxLogo);

            // Crear y agregar botones del menú en el orden correcto
            btnHome = CreateMenuButton("INICIO", Color.DarkGreen);
            btnLoans = CreateMenuButton("PRÉSTAMOS", Color.Gray);
            btnBooks = CreateMenuButton("LIBROS", Color.Gray);
            btnClients = CreateMenuButton("CLIENTES", Color.Gray);
            btnGenres = CreateMenuButton("GÉNEROS LITERARIOS", Color.Gray);
            btnAuthors = CreateMenuButton("AUTORES", Color.Gray);

            // Asignar eventos Click a los botones
            btnHome.Click += (sender, e) => LoadHomePage();
            btnLoans.Click += (sender, e) => LoadLoanPage();
            btnBooks.Click += (sender, e) => LoadBooksPage();
            btnClients.Click += MenuButton_Click;
            btnGenres.Click += MenuButton_Click;
            btnAuthors.Click += MenuButton_Click;

            // Agregar los botones al panel en el orden correcto
            menuPanel.Controls.Add(btnAuthors);
            menuPanel.Controls.Add(btnGenres);
            menuPanel.Controls.Add(btnClients);
            menuPanel.Controls.Add(btnBooks);
            menuPanel.Controls.Add(btnLoans);
            menuPanel.Controls.Add(btnHome);

            return menuPanel;
        }

        private Button CreateMenuButton(string text, Color backColor)
        {
            return new Button
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 50,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        private void UpdateMenuButtonStyles(Button activeButton)
        {
            var buttons = new[] { btnHome, btnLoans, btnBooks, btnClients, btnGenres, btnAuthors };
            foreach (var button in buttons)
            {
                if (button == activeButton)
                {
                    button.BackColor = Color.DarkGreen;
                    button.ForeColor = Color.White;
                }
                else
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
            }
        }

        private void LoadHomePage()
        {
            // Lógica para cargar la página de inicio
            mainPanel.Controls.Clear();
            var homeLabel = new Label
            {
                Text = "Bienvenido a la Gestión de Libros",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 24, FontStyle.Bold)
            };
            mainPanel.Controls.Add(homeLabel);
            UpdateMenuButtonStyles(btnHome);
        }

        private void LoadLoanPage()
        {
            // Lógica para cargar la página de préstamos
            mainPanel.Controls.Clear();

            var btnAddLoan = new Button
            {
                Text = "Añadir Préstamo",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddLoan.Click += BtnAddLoan_Click;
            mainPanel.Controls.Add(btnAddLoan);

            var searchPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60
            };

            var lblSearch = new Label
            {
                Text = "Buscar Préstamos por cliente",
                Dock = DockStyle.Left,
                Width = 200,
                TextAlign = ContentAlignment.MiddleLeft
            };
            searchPanel.Controls.Add(lblSearch);

            var txtSearch = new TextBox
            {
                Dock = DockStyle.Left,
                Width = 200
            };
            SetPlaceholderText(txtSearch, "ID del Cliente");
            searchPanel.Controls.Add(txtSearch);

            var btnSearch = new Button
            {
                Text = "Enviar",
                Dock = DockStyle.Left,
                Height = 30,
                BackColor = Color.DarkGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.Click += async (sender, e) => await BtnSearch_Click(sender, e, txtSearch.Text);
            searchPanel.Controls.Add(btnSearch);

            mainPanel.Controls.Add(searchPanel);

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            mainPanel.Controls.Add(dataGridView);

            LoadAllLoans();
            UpdateMenuButtonStyles(btnLoans);
        }

        private void LoadBooksPage()
        {
            // Lógica para cargar la página de libros
            mainPanel.Controls.Clear();

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
            mainPanel.Controls.Add(btnAddBook);

            var booksPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            mainPanel.Controls.Add(booksPanel);

            LoadAllBooks(booksPanel);
            UpdateMenuButtonStyles(btnBooks);
        }

        private async void LoadAllBooks(FlowLayoutPanel booksPanel)
        {
            var books = await GetBooksAsync();
            DisplayBooks(booksPanel, books);
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

        private void DisplayBooks(FlowLayoutPanel booksPanel, List<Book> books)
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

        private async Task BtnSearch_Click(object sender, EventArgs e, string clientId)
        {
            var loans = await GetLoansByClientIdAsync(clientId);
            dataGridView.DataSource = loans;
        }

        private async Task<List<Loan>> GetLoansByClientIdAsync(string clientId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + $"api/Loan/GetByClient/{clientId}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Loan>>(json);
            }
        }

        private void BtnAddLoan_Click(object sender, EventArgs e)
        {
            var addLoanForm = new AddLoanForm();
            addLoanForm.ShowDialog();
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            // Lógica para añadir un libro
            MessageBox.Show("Añadir Libro");
        }

        private async void LoadAllLoans()
        {
            var loans = await GetLoansAsync();
            dataGridView.DataSource = loans;
        }

        private async Task<List<Loan>> GetLoansAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "api/Loan/GetAll");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Loan>>(json);
            }
        }

        private void SetPlaceholderText(TextBox textBox, string placeholderText)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholderText;
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Manejar la lógica de cambio de contenido aquí según el botón presionado
                MessageBox.Show($"Botón {button.Text} presionado.");
            }
        }
    }

    public class Loan
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
