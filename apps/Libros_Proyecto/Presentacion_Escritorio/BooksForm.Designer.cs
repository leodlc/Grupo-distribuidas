namespace Presentacion_Escritorio
{
    partial class BooksForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BooksForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "BooksForm";
            this.Load += new System.EventHandler(this.BooksForm_Load);
            this.ResumeLayout(false);
        }
    }
}
