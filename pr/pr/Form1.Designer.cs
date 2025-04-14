using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace pr
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dataGridView;
        private Button btnOpenFile;
        private Button btnSave;
        private Button btnCreateTest;
        private Button btnSearch;
        private TextBox txtSearchModel;
        private Label lblFileName;
        private Label lblFileSize;
        private Label lblLastModified;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnAbout;

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
            dataGridView = new DataGridView();
            btnOpenFile = new Button();
            btnSave = new Button();
            btnCreateTest = new Button();
            btnSearch = new Button();
            txtSearchModel = new TextBox();
            lblFileName = new Label();
            lblFileSize = new Label();
            lblLastModified = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(760, 300);
            dataGridView.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(20, 20);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(100, 30);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Открыть файл";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(140, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCreateTest
            // 
            btnCreateTest.Location = new Point(260, 20);
            btnCreateTest.Name = "btnCreateTest";
            btnCreateTest.Size = new Size(100, 30);
            btnCreateTest.TabIndex = 3;
            btnCreateTest.Text = "Создать тест";
            btnCreateTest.UseVisualStyleBackColor = true;
            btnCreateTest.Click += btnCreateTest_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(240, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 30);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Найти модель";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchModel
            // 
            txtSearchModel.Location = new Point(20, 20);
            txtSearchModel.Name = "txtSearchModel";
            txtSearchModel.Size = new Size(200, 27);
            txtSearchModel.TabIndex = 5;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(12, 430);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(127, 20);
            lblFileName.TabIndex = 3;
            lblFileName.Text = "Файл: не выбран";
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(12, 460);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(67, 20);
            lblFileSize.TabIndex = 4;
            lblFileSize.Text = "Размер: ";
            // 
            // lblLastModified
            // 
            lblLastModified.AutoSize = true;
            lblLastModified.Location = new Point(12, 490);
            lblLastModified.Name = "lblLastModified";
            lblLastModified.Size = new Size(75, 20);
            lblLastModified.TabIndex = 5;
            lblLastModified.Text = "Изменен:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnOpenFile);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnCreateTest);
            groupBox1.Location = new Point(12, 320);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Файл";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSearchModel);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Location = new Point(400, 320);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(380, 100);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Поиск";
            // 
            // button1
            // 
            button1.Location = new Point(640, 512);
            button1.Name = "button1";
            button1.Size = new Size(120, 29);
            button1.TabIndex = 6;
            button1.Text = "О программе";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(button1);
            Controls.Add(dataGridView);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(lblFileName);
            Controls.Add(lblFileSize);
            Controls.Add(lblLastModified);
            Name = "Form1";
            Text = "Редактор блоков питания";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
    }
}
