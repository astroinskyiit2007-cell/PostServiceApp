namespace PostService.App
{
    partial class PostingList
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gridPostings = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            var colId = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false };
            var colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "From", HeaderText = "Відправник" };
            var colTo = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "To", HeaderText = "Отримувач" };
            var colContent = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Content", HeaderText = "Вміст" };
            var colDeliveryType = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "DeliveryType", HeaderText = "Тип доставки" };
            var colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Weight", HeaderText = "Вага" };
            var colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Width", HeaderText = "Ширина" };
            var colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Height", HeaderText = "Висота" };
            var colDepth = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Depth", HeaderText = "Глибина" };
            var colValue = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Вартість" };
            var colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Ціна" };
            var colCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "CreatedAt", HeaderText = "Створено", Visible = false };

            ((System.ComponentModel.ISupportInitialize)(this.gridPostings)).BeginInit();
            this.SuspendLayout();

            // gridPostings
            this.gridPostings.AllowUserToAddRows = false;
            this.gridPostings.AllowUserToDeleteRows = false;
            this.gridPostings.AutoGenerateColumns = false;
            this.gridPostings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPostings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colId, colFrom, colTo, colContent, colDeliveryType, colWeight, colWidth, colHeight, colDepth, colValue, colPrice, colCreatedAt
            });
            this.gridPostings.Location = new System.Drawing.Point(12, 12);
            this.gridPostings.MultiSelect = false;
            this.gridPostings.Name = "gridPostings";
            this.gridPostings.ReadOnly = true;
            this.gridPostings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPostings.Size = new System.Drawing.Size(760, 380);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(616, 405);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(697, 405);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.Text = "Видалити";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // PostingList
            this.ClientSize = new System.Drawing.Size(784, 447);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gridPostings);
            this.Name = "PostingList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список поштових відправлень";
            this.Load += new System.EventHandler(this.PostingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPostings)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView gridPostings;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
    }
}