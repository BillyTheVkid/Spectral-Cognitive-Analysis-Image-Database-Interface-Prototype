namespace ImageDataBaseInterface
{
    partial class ResearchForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            ResearchLabel = new Label();
            ResearcherLabel = new Label();
            CategoryLabel = new Label();
            MarkerLabel = new Label();
            ResearchBox = new TextBox();
            CategoryBox = new ComboBox();
            ResearcherBox = new ComboBox();
            MarkerBox = new ComboBox();
            DescriptionLabel = new Label();
            DescriptionBox = new TextBox();
            ModelLabel = new Label();
            ModelBox = new ComboBox();
            CoeffitientsLabel = new Label();
            DateLabel = new Label();
            DateBox = new DateTimePicker();
            SaveButton = new Button();
            CloseButton = new Button();
            Grid = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ColorName = new DataGridViewTextBoxColumn();
            Inf_Coef = new DataGridViewTextBoxColumn();
            Red = new DataGridViewTextBoxColumn();
            Green = new DataGridViewTextBoxColumn();
            Blue = new DataGridViewTextBoxColumn();
            Color = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // ResearchLabel
            // 
            ResearchLabel.AutoSize = true;
            ResearchLabel.Location = new Point(4, 9);
            ResearchLabel.Name = "ResearchLabel";
            ResearchLabel.Size = new Size(153, 15);
            ResearchLabel.TabIndex = 0;
            ResearchLabel.Text = "♦Название исследования :";
            // 
            // ResearcherLabel
            // 
            ResearcherLabel.AutoSize = true;
            ResearcherLabel.Location = new Point(61, 125);
            ResearcherLabel.Name = "ResearcherLabel";
            ResearcherLabel.Size = new Size(96, 15);
            ResearcherLabel.TabIndex = 1;
            ResearcherLabel.Text = "Исследователь :";
            // 
            // CategoryLabel
            // 
            CategoryLabel.AutoSize = true;
            CategoryLabel.Location = new Point(38, 183);
            CategoryLabel.Name = "CategoryLabel";
            CategoryLabel.Size = new Size(119, 15);
            CategoryLabel.TabIndex = 2;
            CategoryLabel.Text = "Категория маркера :";
            // 
            // MarkerLabel
            // 
            MarkerLabel.AutoSize = true;
            MarkerLabel.Location = new Point(101, 212);
            MarkerLabel.Name = "MarkerLabel";
            MarkerLabel.Size = new Size(56, 15);
            MarkerLabel.TabIndex = 3;
            MarkerLabel.Text = "Маркер :";
            // 
            // ResearchBox
            // 
            ResearchBox.Location = new Point(163, 6);
            ResearchBox.Name = "ResearchBox";
            ResearchBox.Size = new Size(616, 23);
            ResearchBox.TabIndex = 4;
            ResearchBox.TextChanged += SomethingChanged;
            // 
            // CategoryBox
            // 
            CategoryBox.FormattingEnabled = true;
            CategoryBox.Items.AddRange(new object[] { "Новая категория +" });
            CategoryBox.Location = new Point(163, 180);
            CategoryBox.Name = "CategoryBox";
            CategoryBox.Size = new Size(178, 23);
            CategoryBox.TabIndex = 6;
            // 
            // ResearcherBox
            // 
            ResearcherBox.FormattingEnabled = true;
            ResearcherBox.Items.AddRange(new object[] { "Новый Исследователь +" });
            ResearcherBox.Location = new Point(163, 122);
            ResearcherBox.Name = "ResearcherBox";
            ResearcherBox.Size = new Size(246, 23);
            ResearcherBox.TabIndex = 7;
            ResearcherBox.DropDown += ResearcherBox_DropDown;
            ResearcherBox.SelectedIndexChanged += ResearcherBox_SelectedIndexChanged;
            ResearcherBox.TextChanged += ResearcherName_Changed;
            // 
            // MarkerBox
            // 
            MarkerBox.FormattingEnabled = true;
            MarkerBox.Items.AddRange(new object[] { "Новый Маркер +" });
            MarkerBox.Location = new Point(163, 209);
            MarkerBox.Name = "MarkerBox";
            MarkerBox.Size = new Size(212, 23);
            MarkerBox.TabIndex = 8;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(89, 38);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(68, 15);
            DescriptionLabel.TabIndex = 9;
            DescriptionLabel.Text = "Описание :";
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(163, 35);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(616, 81);
            DescriptionBox.TabIndex = 10;
            DescriptionBox.TextChanged += SomethingChanged;
            // 
            // ModelLabel
            // 
            ModelLabel.AutoSize = true;
            ModelLabel.Location = new Point(101, 154);
            ModelLabel.Name = "ModelLabel";
            ModelLabel.Size = new Size(56, 15);
            ModelLabel.TabIndex = 11;
            ModelLabel.Text = "Модель :";
            // 
            // ModelBox
            // 
            ModelBox.FormattingEnabled = true;
            ModelBox.Items.AddRange(new object[] { "Новая модель +" });
            ModelBox.Location = new Point(163, 151);
            ModelBox.Name = "ModelBox";
            ModelBox.Size = new Size(246, 23);
            ModelBox.TabIndex = 12;
            // 
            // CoeffitientsLabel
            // 
            CoeffitientsLabel.AutoSize = true;
            CoeffitientsLabel.Location = new Point(20, 240);
            CoeffitientsLabel.Name = "CoeffitientsLabel";
            CoeffitientsLabel.Size = new Size(248, 15);
            CoeffitientsLabel.TabIndex = 14;
            CoeffitientsLabel.Text = "Цвета и информационные коэффициенты :";
            // 
            // DateLabel
            // 
            DateLabel.AutoSize = true;
            DateLabel.Location = new Point(443, 125);
            DateLabel.Name = "DateLabel";
            DateLabel.Size = new Size(38, 15);
            DateLabel.TabIndex = 15;
            DateLabel.Text = "Дата :";
            // 
            // DateBox
            // 
            DateBox.Location = new Point(487, 122);
            DateBox.Name = "DateBox";
            DateBox.Size = new Size(142, 23);
            DateBox.TabIndex = 16;
            DateBox.ValueChanged += SomethingChanged;
            // 
            // SaveButton
            // 
            SaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveButton.Location = new Point(623, 390);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 17;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CloseButton.Location = new Point(704, 390);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 23);
            CloseButton.TabIndex = 18;
            CloseButton.Text = "Закрыть";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // Grid
            // 
            Grid.AllowUserToAddRows = false;
            Grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { ID, ColorName, Inf_Coef, Red, Green, Blue, Color });
            Grid.Location = new Point(20, 258);
            Grid.Name = "Grid";
            Grid.RowHeadersVisible = false;
            Grid.Size = new Size(759, 126);
            Grid.TabIndex = 19;
            // 
            // ID
            // 
            ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ID.DefaultCellStyle = dataGridViewCellStyle2;
            ID.HeaderText = "№";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 5;
            // 
            // ColorName
            // 
            ColorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColorName.DefaultCellStyle = dataGridViewCellStyle3;
            ColorName.HeaderText = "Название Цвета";
            ColorName.Name = "ColorName";
            // 
            // Inf_Coef
            // 
            Inf_Coef.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Inf_Coef.DefaultCellStyle = dataGridViewCellStyle4;
            Inf_Coef.HeaderText = "Коэффициент";
            Inf_Coef.Name = "Inf_Coef";
            // 
            // Red
            // 
            Red.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Red.DefaultCellStyle = dataGridViewCellStyle5;
            Red.HeaderText = "RED";
            Red.MinimumWidth = 70;
            Red.Name = "Red";
            Red.Width = 70;
            // 
            // Green
            // 
            Green.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Green.DefaultCellStyle = dataGridViewCellStyle6;
            Green.HeaderText = "GREEN";
            Green.MinimumWidth = 70;
            Green.Name = "Green";
            Green.Width = 70;
            // 
            // Blue
            // 
            Blue.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Blue.DefaultCellStyle = dataGridViewCellStyle7;
            Blue.HeaderText = "BLUE";
            Blue.MinimumWidth = 70;
            Blue.Name = "Blue";
            Blue.Width = 70;
            // 
            // Color
            // 
            Color.HeaderText = "Цвет";
            Color.ImageLayout = DataGridViewImageCellLayout.Stretch;
            Color.MinimumWidth = 100;
            Color.Name = "Color";
            // 
            // ResearchForm
            // 
            AcceptButton = SaveButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            CancelButton = CloseButton;
            ClientSize = new Size(799, 421);
            Controls.Add(Grid);
            Controls.Add(CloseButton);
            Controls.Add(SaveButton);
            Controls.Add(DateBox);
            Controls.Add(DateLabel);
            Controls.Add(CoeffitientsLabel);
            Controls.Add(ModelBox);
            Controls.Add(ModelLabel);
            Controls.Add(DescriptionBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(MarkerBox);
            Controls.Add(ResearcherBox);
            Controls.Add(CategoryBox);
            Controls.Add(ResearchBox);
            Controls.Add(MarkerLabel);
            Controls.Add(CategoryLabel);
            Controls.Add(ResearcherLabel);
            Controls.Add(ResearchLabel);
            MaximumSize = new Size(815, 10000);
            MinimumSize = new Size(815, 460);
            Name = "ResearchForm";
            Text = "Новое исследование";
            Load += ResearchForm_Load;
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ResearchLabel;
        private Label ResearcherLabel;
        private Label CategoryLabel;
        private Label MarkerLabel;
        private TextBox ResearchBox;
        private ComboBox CategoryBox;
        private ComboBox ResearcherBox;
        private ComboBox MarkerBox;
        private Label DescriptionLabel;
        private TextBox DescriptionBox;
        private Label ModelLabel;
        private ComboBox ModelBox;
        private Label CoeffitientsLabel;
        private Label DateLabel;
        private DateTimePicker DateBox;
        private Button SaveButton;
        private Button CloseButton;
        private DataGridView Grid;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColorName;
        private DataGridViewTextBoxColumn Inf_Coef;
        private DataGridViewTextBoxColumn Red;
        private DataGridViewTextBoxColumn Green;
        private DataGridViewTextBoxColumn Blue;
        private DataGridViewImageColumn Color;
    }
}