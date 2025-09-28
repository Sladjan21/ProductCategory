namespace GUI
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbName = new TextBox();
            numQuantity = new NumericUpDown();
            tbDescription = new TextBox();
            numPrice = new NumericUpDown();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            cblCategory = new CheckedListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(27, 42);
            tbName.Name = "tbName";
            tbName.Size = new Size(125, 27);
            tbName.TabIndex = 1;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(27, 113);
            numQuantity.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(125, 27);
            numQuantity.TabIndex = 2;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(28, 252);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(445, 179);
            tbDescription.TabIndex = 3;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(27, 183);
            numPrice.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(125, 27);
            numPrice.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 12);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 5;
            label1.Text = "Naziv proizvoda";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 90);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 7;
            label3.Text = "Kolicina";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 157);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 8;
            label4.Text = "Cena";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 229);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 9;
            label5.Text = "Opis";
            // 
            // button1
            // 
            button1.Location = new Point(31, 464);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 10;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(199, 465);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 11;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // cblCategory
            // 
            cblCategory.CheckOnClick = true;
            cblCategory.FormattingEnabled = true;
            cblCategory.Location = new Point(230, 42);
            cblCategory.Name = "cblCategory";
            cblCategory.Size = new Size(243, 158);
            cblCategory.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 15);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 14;
            label2.Text = "Kategorija";
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 523);
            Controls.Add(label2);
            Controls.Add(cblCategory);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(numPrice);
            Controls.Add(tbDescription);
            Controls.Add(numQuantity);
            Controls.Add(tbName);
            Name = "AddProductForm";
            Text = "AddProductForm";
            Load += AddProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbName;
        private NumericUpDown numQuantity;
        private TextBox tbDescription;
        private NumericUpDown numPrice;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private CheckedListBox cblCategory;
        private Label label2;
    }
}