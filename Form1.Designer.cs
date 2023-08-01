
namespace MichiToDo
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainForm_title = new System.Windows.Forms.Label();
            this.mainForm_toggleTaskListButton = new System.Windows.Forms.Button();
            this.mainForm_taskListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mainForm_addNewTaskButton = new System.Windows.Forms.Button();
            this.mainForm_taskListSymbol = new System.Windows.Forms.PictureBox();
            this.mainForm_titleLine = new System.Windows.Forms.PictureBox();
            this.mainForm_taskDoneListSymbol = new System.Windows.Forms.PictureBox();
            this.mainForm_toggleTaskDoneListButton = new System.Windows.Forms.Button();
            this.mainForm_taskDoneListPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_taskListSymbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_titleLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_taskDoneListSymbol)).BeginInit();
            this.SuspendLayout();
            // 
            // mainForm_title
            // 
            this.mainForm_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.mainForm_title.Font = new System.Drawing.Font("Microsoft YaHei UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_title.ForeColor = System.Drawing.Color.Silver;
            this.mainForm_title.Location = new System.Drawing.Point(127, 17);
            this.mainForm_title.Name = "mainForm_title";
            this.mainForm_title.Size = new System.Drawing.Size(325, 75);
            this.mainForm_title.TabIndex = 0;
            this.mainForm_title.Text = "Michi ToDo";
            this.mainForm_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm_toggleTaskListButton
            // 
            this.mainForm_toggleTaskListButton.AutoSize = true;
            this.mainForm_toggleTaskListButton.FlatAppearance.BorderSize = 0;
            this.mainForm_toggleTaskListButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mainForm_toggleTaskListButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mainForm_toggleTaskListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_toggleTaskListButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_toggleTaskListButton.ForeColor = System.Drawing.Color.Silver;
            this.mainForm_toggleTaskListButton.Location = new System.Drawing.Point(102, 158);
            this.mainForm_toggleTaskListButton.Name = "mainForm_toggleTaskListButton";
            this.mainForm_toggleTaskListButton.Size = new System.Drawing.Size(316, 67);
            this.mainForm_toggleTaskListButton.TabIndex = 2;
            this.mainForm_toggleTaskListButton.Text = "Tasks ToDo";
            this.mainForm_toggleTaskListButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mainForm_toggleTaskListButton.UseVisualStyleBackColor = true;
            this.mainForm_toggleTaskListButton.Click += new System.EventHandler(this.mainForm_toggleTaskList_Click);
            // 
            // mainForm_taskListPanel
            // 
            this.mainForm_taskListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainForm_taskListPanel.AutoScroll = true;
            this.mainForm_taskListPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainForm_taskListPanel.Location = new System.Drawing.Point(12, 241);
            this.mainForm_taskListPanel.Name = "mainForm_taskListPanel";
            this.mainForm_taskListPanel.Size = new System.Drawing.Size(565, 200);
            this.mainForm_taskListPanel.TabIndex = 4;
            this.mainForm_taskListPanel.WrapContents = false;
            // 
            // mainForm_addNewTaskButton
            // 
            this.mainForm_addNewTaskButton.FlatAppearance.BorderSize = 0;
            this.mainForm_addNewTaskButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mainForm_addNewTaskButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mainForm_addNewTaskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_addNewTaskButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_addNewTaskButton.ForeColor = System.Drawing.Color.Silver;
            this.mainForm_addNewTaskButton.Image = global::MichiToDo.Properties.Resources.Add_New_Task_Button;
            this.mainForm_addNewTaskButton.Location = new System.Drawing.Point(102, 813);
            this.mainForm_addNewTaskButton.Name = "mainForm_addNewTaskButton";
            this.mainForm_addNewTaskButton.Size = new System.Drawing.Size(350, 75);
            this.mainForm_addNewTaskButton.TabIndex = 5;
            this.mainForm_addNewTaskButton.Text = "Add new Task";
            this.mainForm_addNewTaskButton.UseVisualStyleBackColor = true;
            this.mainForm_addNewTaskButton.Click += new System.EventHandler(this.mainForm_addNewTaskButton_Click);
            this.mainForm_addNewTaskButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainForm_addNewTaskButton_MouseDown);
            this.mainForm_addNewTaskButton.MouseEnter += new System.EventHandler(this.mainForm_addNewTaskButton_MouseEnter);
            this.mainForm_addNewTaskButton.MouseLeave += new System.EventHandler(this.mainForm_addNewTaskButton_MouseLeave);
            this.mainForm_addNewTaskButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainForm_addNewTaskButton_MouseUp);
            // 
            // mainForm_taskListSymbol
            // 
            this.mainForm_taskListSymbol.Image = global::MichiToDo.Properties.Resources.List_Closed_Symbol;
            this.mainForm_taskListSymbol.Location = new System.Drawing.Point(36, 158);
            this.mainForm_taskListSymbol.Name = "mainForm_taskListSymbol";
            this.mainForm_taskListSymbol.Size = new System.Drawing.Size(60, 60);
            this.mainForm_taskListSymbol.TabIndex = 3;
            this.mainForm_taskListSymbol.TabStop = false;
            this.mainForm_taskListSymbol.Click += new System.EventHandler(this.mainForm_taskListSymbol_Click);
            this.mainForm_taskListSymbol.DoubleClick += new System.EventHandler(this.mainForm_taskListSymbol_DoubleClick);
            // 
            // mainForm_titleLine
            // 
            this.mainForm_titleLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainForm_titleLine.BackColor = System.Drawing.Color.Transparent;
            this.mainForm_titleLine.Image = global::MichiToDo.Properties.Resources.Line;
            this.mainForm_titleLine.Location = new System.Drawing.Point(17, 100);
            this.mainForm_titleLine.Name = "mainForm_titleLine";
            this.mainForm_titleLine.Size = new System.Drawing.Size(550, 10);
            this.mainForm_titleLine.TabIndex = 1;
            this.mainForm_titleLine.TabStop = false;
            // 
            // mainForm_taskDoneListSymbol
            // 
            this.mainForm_taskDoneListSymbol.Image = global::MichiToDo.Properties.Resources.List_Closed_Symbol;
            this.mainForm_taskDoneListSymbol.Location = new System.Drawing.Point(36, 464);
            this.mainForm_taskDoneListSymbol.Name = "mainForm_taskDoneListSymbol";
            this.mainForm_taskDoneListSymbol.Size = new System.Drawing.Size(60, 60);
            this.mainForm_taskDoneListSymbol.TabIndex = 6;
            this.mainForm_taskDoneListSymbol.TabStop = false;
            this.mainForm_taskDoneListSymbol.Click += new System.EventHandler(this.mainForm_taskDoneListSymbol_Click);
            this.mainForm_taskDoneListSymbol.DoubleClick += new System.EventHandler(this.mainForm_taskDoneListSymbol_DoubleClick);
            // 
            // mainForm_toggleTaskDoneListButton
            // 
            this.mainForm_toggleTaskDoneListButton.AutoSize = true;
            this.mainForm_toggleTaskDoneListButton.FlatAppearance.BorderSize = 0;
            this.mainForm_toggleTaskDoneListButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.mainForm_toggleTaskDoneListButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.mainForm_toggleTaskDoneListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainForm_toggleTaskDoneListButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainForm_toggleTaskDoneListButton.ForeColor = System.Drawing.Color.Silver;
            this.mainForm_toggleTaskDoneListButton.Location = new System.Drawing.Point(102, 464);
            this.mainForm_toggleTaskDoneListButton.Name = "mainForm_toggleTaskDoneListButton";
            this.mainForm_toggleTaskDoneListButton.Size = new System.Drawing.Size(316, 67);
            this.mainForm_toggleTaskDoneListButton.TabIndex = 7;
            this.mainForm_toggleTaskDoneListButton.Text = "Tasks Done";
            this.mainForm_toggleTaskDoneListButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mainForm_toggleTaskDoneListButton.UseVisualStyleBackColor = true;
            this.mainForm_toggleTaskDoneListButton.Click += new System.EventHandler(this.mainForm_toggleTaskDoneListButton_Click);
            // 
            // mainForm_taskDoneListPanel
            // 
            this.mainForm_taskDoneListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mainForm_taskDoneListPanel.AutoScroll = true;
            this.mainForm_taskDoneListPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainForm_taskDoneListPanel.Location = new System.Drawing.Point(12, 549);
            this.mainForm_taskDoneListPanel.Name = "mainForm_taskDoneListPanel";
            this.mainForm_taskDoneListPanel.Size = new System.Drawing.Size(565, 200);
            this.mainForm_taskDoneListPanel.TabIndex = 8;
            this.mainForm_taskDoneListPanel.WrapContents = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(584, 911);
            this.Controls.Add(this.mainForm_taskDoneListPanel);
            this.Controls.Add(this.mainForm_toggleTaskDoneListButton);
            this.Controls.Add(this.mainForm_taskDoneListSymbol);
            this.Controls.Add(this.mainForm_addNewTaskButton);
            this.Controls.Add(this.mainForm_taskListSymbol);
            this.Controls.Add(this.mainForm_taskListPanel);
            this.Controls.Add(this.mainForm_toggleTaskListButton);
            this.Controls.Add(this.mainForm_titleLine);
            this.Controls.Add(this.mainForm_title);
            this.MaximumSize = new System.Drawing.Size(600, 950);
            this.MinimumSize = new System.Drawing.Size(600, 950);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToDo";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_taskListSymbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_titleLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainForm_taskDoneListSymbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainForm_title;
        private System.Windows.Forms.PictureBox mainForm_titleLine;
        private System.Windows.Forms.Button mainForm_toggleTaskListButton;
        private System.Windows.Forms.PictureBox mainForm_taskListSymbol;
        private System.Windows.Forms.FlowLayoutPanel mainForm_taskListPanel;
        private System.Windows.Forms.Button mainForm_addNewTaskButton;
        private System.Windows.Forms.PictureBox mainForm_taskDoneListSymbol;
        private System.Windows.Forms.Button mainForm_toggleTaskDoneListButton;
        private System.Windows.Forms.FlowLayoutPanel mainForm_taskDoneListPanel;
    }
}

