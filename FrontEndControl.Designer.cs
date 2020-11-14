namespace PriceNCook
{
    partial class FrontEndControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseBox = new System.Windows.Forms.ComboBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.unitCombobox = new System.Windows.Forms.ComboBox();
            this.quantityBox = new System.Windows.Forms.NumericUpDown();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dateEdition = new System.Windows.Forms.TextBox();
            this.dateCreation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.duplicateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.databaseTable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.renameCollumnButton = new System.Windows.Forms.Button();
            this.removeCollumnButton = new System.Windows.Forms.Button();
            this.addCollumnButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeLineButton = new System.Windows.Forms.Button();
            this.addLineButton = new System.Windows.Forms.Button();
            this.ingredientTable = new System.Windows.Forms.DataGridView();
            this.componentLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Banco:";
            // 
            // databaseBox
            // 
            this.databaseBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.databaseBox.FormattingEnabled = true;
            this.databaseBox.Items.AddRange(new object[] {
            "Insumos",
            "Receitas",
            "Produtos",
            "Orçamentos"});
            this.databaseBox.Location = new System.Drawing.Point(77, 27);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.Size = new System.Drawing.Size(180, 28);
            this.databaseBox.TabIndex = 1;
            this.databaseBox.Text = "Insumos";
            this.databaseBox.SelectedIndexChanged += new System.EventHandler(this.databaseBox_SelectedIndexChanged);
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.unitCombobox);
            this.infoPanel.Controls.Add(this.quantityBox);
            this.infoPanel.Controls.Add(this.priceBox);
            this.infoPanel.Controls.Add(this.nameBox);
            this.infoPanel.Controls.Add(this.cancelButton);
            this.infoPanel.Controls.Add(this.pictureBox);
            this.infoPanel.Controls.Add(this.dateEdition);
            this.infoPanel.Controls.Add(this.dateCreation);
            this.infoPanel.Controls.Add(this.label7);
            this.infoPanel.Controls.Add(this.descriptionBox);
            this.infoPanel.Controls.Add(this.label6);
            this.infoPanel.Controls.Add(this.label5);
            this.infoPanel.Controls.Add(this.quantityLabel);
            this.infoPanel.Controls.Add(this.priceLabel);
            this.infoPanel.Controls.Add(this.nameLabel);
            this.infoPanel.Location = new System.Drawing.Point(12, 76);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(314, 642);
            this.infoPanel.TabIndex = 2;
            // 
            // unitCombobox
            // 
            this.unitCombobox.FormattingEnabled = true;
            this.unitCombobox.Items.AddRange(new object[] {
            "un",
            "g",
            "kg",
            "ml",
            "l",
            "xícaras"});
            this.unitCombobox.Location = new System.Drawing.Point(218, 386);
            this.unitCombobox.Name = "unitCombobox";
            this.unitCombobox.Size = new System.Drawing.Size(88, 21);
            this.unitCombobox.TabIndex = 24;
            this.unitCombobox.Text = "un";
            // 
            // quantityBox
            // 
            this.quantityBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantityBox.DecimalPlaces = 5;
            this.quantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.quantityBox.Location = new System.Drawing.Point(116, 383);
            this.quantityBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(96, 25);
            this.quantityBox.TabIndex = 23;
            // 
            // priceBox
            // 
            this.priceBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceBox.DecimalPlaces = 2;
            this.priceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.priceBox.Location = new System.Drawing.Point(116, 349);
            this.priceBox.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(189, 25);
            this.priceBox.TabIndex = 22;
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameBox.Location = new System.Drawing.Point(65, 6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(240, 26);
            this.nameBox.TabIndex = 21;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(202, 605);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(104, 25);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 300);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // dateEdition
            // 
            this.dateEdition.Enabled = false;
            this.dateEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEdition.Location = new System.Drawing.Point(116, 452);
            this.dateEdition.Name = "dateEdition";
            this.dateEdition.Size = new System.Drawing.Size(189, 26);
            this.dateEdition.TabIndex = 11;
            // 
            // dateCreation
            // 
            this.dateCreation.Enabled = false;
            this.dateCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCreation.Location = new System.Drawing.Point(116, 417);
            this.dateCreation.Name = "dateCreation";
            this.dateCreation.Size = new System.Drawing.Size(189, 26);
            this.dateCreation.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Descrição:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(11, 507);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(294, 92);
            this.descriptionBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "última edição:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "data de criação:";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(44, 390);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(65, 13);
            this.quantityLabel.TabIndex = 3;
            this.quantityLabel.Text = "Quantidade:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(37, 355);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(76, 13);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Preço:        R$";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.nameLabel.Location = new System.Drawing.Point(4, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(42, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "nome:";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchBox.Location = new System.Drawing.Point(334, 11);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(283, 26);
            this.searchBox.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.searchButton.Location = new System.Drawing.Point(622, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 26);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Procurar";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.updateButton.Location = new System.Drawing.Point(334, 44);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(62, 26);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Atualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.newButton.Location = new System.Drawing.Point(419, 44);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(62, 26);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "Novo...";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editButton.Location = new System.Drawing.Point(504, 44);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(62, 26);
            this.editButton.TabIndex = 8;
            this.editButton.Text = "Editar";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // duplicateButton
            // 
            this.duplicateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.duplicateButton.Location = new System.Drawing.Point(589, 44);
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(62, 26);
            this.duplicateButton.TabIndex = 9;
            this.duplicateButton.Text = "Duplicar";
            this.duplicateButton.UseVisualStyleBackColor = true;
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.deleteButton.Location = new System.Drawing.Point(674, 44);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(62, 26);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Excluir";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(332, 76);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.databaseTable);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.ingredientTable);
            this.splitContainer1.Size = new System.Drawing.Size(966, 652);
            this.splitContainer1.SplitterDistance = 457;
            this.splitContainer1.TabIndex = 11;
            // 
            // databaseTable
            // 
            this.databaseTable.AllowUserToAddRows = false;
            this.databaseTable.AllowUserToDeleteRows = false;
            this.databaseTable.ColumnHeadersHeight = 30;
            this.databaseTable.Location = new System.Drawing.Point(3, 3);
            this.databaseTable.MultiSelect = false;
            this.databaseTable.Name = "databaseTable";
            this.databaseTable.ReadOnly = true;
            this.databaseTable.RowTemplate.Height = 30;
            this.databaseTable.Size = new System.Drawing.Size(450, 639);
            this.databaseTable.TabIndex = 0;
            this.databaseTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.databaseTable_CellContentClick);
            this.databaseTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.databaseTable_CellContentDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.renameCollumnButton);
            this.groupBox2.Controls.Add(this.removeCollumnButton);
            this.groupBox2.Controls.Add(this.addCollumnButton);
            this.groupBox2.Location = new System.Drawing.Point(207, 595);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colunas";
            // 
            // renameCollumnButton
            // 
            this.renameCollumnButton.Location = new System.Drawing.Point(7, 19);
            this.renameCollumnButton.Name = "renameCollumnButton";
            this.renameCollumnButton.Size = new System.Drawing.Size(80, 23);
            this.renameCollumnButton.TabIndex = 4;
            this.renameCollumnButton.Text = "renomear";
            this.renameCollumnButton.UseVisualStyleBackColor = true;
            this.renameCollumnButton.Click += new System.EventHandler(this.renameCollumnButton_Click);
            // 
            // removeCollumnButton
            // 
            this.removeCollumnButton.Location = new System.Drawing.Point(207, 19);
            this.removeCollumnButton.Name = "removeCollumnButton";
            this.removeCollumnButton.Size = new System.Drawing.Size(80, 23);
            this.removeCollumnButton.TabIndex = 3;
            this.removeCollumnButton.Text = "x";
            this.removeCollumnButton.UseVisualStyleBackColor = true;
            this.removeCollumnButton.Click += new System.EventHandler(this.removeCollumnButton_Click);
            // 
            // addCollumnButton
            // 
            this.addCollumnButton.Location = new System.Drawing.Point(108, 19);
            this.addCollumnButton.Name = "addCollumnButton";
            this.addCollumnButton.Size = new System.Drawing.Size(80, 23);
            this.addCollumnButton.TabIndex = 2;
            this.addCollumnButton.Text = "+";
            this.addCollumnButton.UseVisualStyleBackColor = true;
            this.addCollumnButton.Click += new System.EventHandler(this.addCollumnButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeLineButton);
            this.groupBox1.Controls.Add(this.addLineButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 595);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linhas";
            // 
            // removeLineButton
            // 
            this.removeLineButton.Location = new System.Drawing.Point(103, 19);
            this.removeLineButton.Name = "removeLineButton";
            this.removeLineButton.Size = new System.Drawing.Size(80, 23);
            this.removeLineButton.TabIndex = 1;
            this.removeLineButton.Text = "x";
            this.removeLineButton.UseVisualStyleBackColor = true;
            this.removeLineButton.Click += new System.EventHandler(this.removeLineButtonClick);
            // 
            // addLineButton
            // 
            this.addLineButton.Location = new System.Drawing.Point(6, 19);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(80, 23);
            this.addLineButton.TabIndex = 0;
            this.addLineButton.Text = "+";
            this.addLineButton.UseVisualStyleBackColor = true;
            this.addLineButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // ingredientTable
            // 
            this.ingredientTable.AllowUserToAddRows = false;
            this.ingredientTable.AllowUserToDeleteRows = false;
            this.ingredientTable.ColumnHeadersHeight = 30;
            this.ingredientTable.Location = new System.Drawing.Point(3, 3);
            this.ingredientTable.MultiSelect = false;
            this.ingredientTable.Name = "ingredientTable";
            this.ingredientTable.RowTemplate.Height = 30;
            this.ingredientTable.Size = new System.Drawing.Size(499, 579);
            this.ingredientTable.TabIndex = 0;
            this.ingredientTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ingredientTableCellChanged);
            // 
            // componentLabel
            // 
            this.componentLabel.AutoSize = true;
            this.componentLabel.Location = new System.Drawing.Point(802, 60);
            this.componentLabel.Name = "componentLabel";
            this.componentLabel.Size = new System.Drawing.Size(69, 13);
            this.componentLabel.TabIndex = 13;
            this.componentLabel.Text = "Components:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1082, 19);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(172, 41);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Salvar Alterações";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrontEndControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 737);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.componentLabel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.databaseBox);
            this.Controls.Add(this.duplicateButton);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updateButton);
            this.Name = "FrontEndControl";
            this.Text = "Price \'n Cook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrontEndControl_FormClosing);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.databaseTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ingredientTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox databaseBox;
        private System.Windows.Forms.Panel infoPanel;
        public System.Windows.Forms.TextBox nameBox;
        public System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox dateEdition;
        private System.Windows.Forms.TextBox dateCreation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button duplicateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView databaseTable;
        private System.Windows.Forms.DataGridView ingredientTable;
        private System.Windows.Forms.Label componentLabel;
        private System.Windows.Forms.NumericUpDown priceBox;
        private System.Windows.Forms.NumericUpDown quantityBox;
        private System.Windows.Forms.ComboBox unitCombobox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button renameCollumnButton;
        private System.Windows.Forms.Button removeCollumnButton;
        private System.Windows.Forms.Button addCollumnButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removeLineButton;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Timer timer1;
    }
}

