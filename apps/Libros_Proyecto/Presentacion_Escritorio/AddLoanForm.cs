using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Presentacion_Escritorio
{
    public partial class AddLoanForm : Form
    {
        private ComboBox cmbClient;
        private ComboBox cmbBook;
        private TextBox txtStartDate;
        private TextBox txtEndDate;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
        private const string BaseUrl = "http://localhost:54845/";

        public AddLoanForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(AddLoanForm_Load); // Asegúrate de agregar el evento Load aquí
        }

        private void AddLoanForm_Load(object sender, EventArgs e)
        {
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Añadir Préstamo";
            this.Size = new Size(800, 600);

            var lblClient = new Label { Text = "Seleccionar cliente", Top = 20, Left = 20, Width = 150 };
            cmbClient = new ComboBox { Top = 50, Left = 20, Width = 300 };
            cmbClient.TextChanged += async (sender, e) => await CmbClient_TextChanged(sender, e);

            var lblBook = new Label { Text = "Seleccionar libro", Top = 20, Left = 350, Width = 150 };
            cmbBook = new ComboBox { Top = 50, Left = 350, Width = 300 };
            cmbBook.TextChanged += async (sender, e) => await CmbBook_TextChanged(sender, e);

            var lblStartDate = new Label { Text = "Fecha de inicio del préstamo", Top = 100, Left = 20, Width = 200 };
            txtStartDate = new TextBox { Top = 130, Left = 20, Width = 300 };

            var lblEndDate = new Label { Text = "Fecha fin del préstamo", Top = 100, Left = 350, Width = 200 };
            txtEndDate = new TextBox { Top = 130, Left = 350, Width = 300 };

            var lblDescription = new Label { Text = "Descripción", Top = 180, Left = 20, Width = 150 };
            txtDescription = new TextBox { Top = 210, Left = 20, Width = 630, Height = 100, Multiline = true };

            btnSave = new Button { Text = "Guardar", Top = 340, Left = 20, Width = 100, BackColor = Color.DarkGreen, ForeColor = Color.White };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button { Text = "Cancelar", Top = 340, Left = 130, Width = 100, BackColor = Color.Gray, ForeColor = Color.White };
            btnCancel.Click += (sender, e) => this.Close();

            this.Controls.Add(lblClient);
            this.Controls.Add(cmbClient);
            this.Controls.Add(lblBook);
            this.Controls.Add(cmbBook);
            this.Controls.Add(lblStartDate);
            this.Controls.Add(txtStartDate);
            this.Controls.Add(lblEndDate);
            this.Controls.Add(txtEndDate);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

        private async Task CmbClient_TextChanged(object sender, EventArgs e)
        {
            if (cmbClient.Text.Length > 2)
            {
                var clients = await GetClientsAsync(cmbClient.Text);
                cmbClient.Items.Clear();
                foreach (var client in clients)
                {
                    cmbClient.Items.Add(client);
                }
            }
        }

        private async Task CmbBook_TextChanged(object sender, EventArgs e)
        {
            if (cmbBook.Text.Length > 2)
            {
                var books = await GetBooksAsync(cmbBook.Text);
                cmbBook.Items.Clear();
                foreach (var book in books)
                {
                    cmbBook.Items.Add(book);
                }
            }
        }

        private async Task<List<string>> GetClientsAsync(string search)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + $"api/Client/Search?name={search}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
        }

        private async Task<List<string>> GetBooksAsync(string search)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + $"api/Book/Search?title={search}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var client = cmbClient.Text;
            var book = cmbBook.Text;
            var startDate = txtStartDate.Text;
            var endDate = txtEndDate.Text;
            var description = txtDescription.Text;

            var confirmResult = MessageBox.Show($"Detalles del préstamo:\nCliente: {client}\nLibro: {book}\nFecha de inicio: {startDate}\nFecha de fin: {endDate}\nDescripción: {description}", "Confirmar Préstamo", MessageBoxButtons.OKCancel);

            if (confirmResult == DialogResult.OK)
            {
                MessageBox.Show("Préstamo guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
