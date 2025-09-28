namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgProducts = new DataGridView();
            label1 = new Label();
            cbCategory = new ComboBox();
            label2 = new Label();
            btnAddProduct = new Button();
            btnDeleteProduct = new Button();
            btnUpdateProduct = new Button();
            btnReset = new Button();
            btnRefresh = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgProducts).BeginInit();
            SuspendLayout();
            // 
            // dgProducts
            // 
            dgProducts.AllowUserToAddRows = false;
            dgProducts.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProducts.Location = new Point(25, 53);
            dgProducts.Name = "dgProducts";
            dgProducts.RowHeadersWidth = 51;
            dgProducts.Size = new Size(803, 236);
            dgProducts.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 19);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 1;
            label1.Text = "Proizvodi";
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(865, 53);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(151, 28);
            cbCategory.TabIndex = 2;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(865, 19);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 3;
            label2.Text = "Kategorije";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(29, 333);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(151, 29);
            btnAddProduct.TabIndex = 4;
            btnAddProduct.Text = "Dodaj proizvod";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(213, 333);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(143, 29);
            btnDeleteProduct.TabIndex = 5;
            btnDeleteProduct.Text = "Izbrisi proizvod";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(407, 333);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(141, 29);
            btnUpdateProduct.TabIndex = 6;
            btnUpdateProduct.Text = "Azuriraj proizvode";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(865, 105);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 7;
            btnReset.Text = "Reset filter";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(594, 334);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(159, 29);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Osvezi podatke";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 371);
            label3.Name = "label3";
            label3.Size = new Size(616, 20);
            label3.TabIndex = 9;
            label3.Text = "Da bi azurirali proizvode treba da promenite vrednost celija u grid i kliknete dugme auzriraj";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 409);
            Controls.Add(label3);
            Controls.Add(btnRefresh);
            Controls.Add(btnReset);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnAddProduct);
            Controls.Add(label2);
            Controls.Add(cbCategory);
            Controls.Add(label1);
            Controls.Add(dgProducts);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)dgProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgProducts;
        private Label label1;
        private ComboBox cbCategory;
        private Label label2;
        private Button btnAddProduct;
        private Button btnDeleteProduct;
        private Button btnUpdateProduct;
        private Button btnReset;
        private Button btnRefresh;
        private Label label3;
    }
}
