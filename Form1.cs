using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MichiToDo
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;

        public List<Task> taskList = new List<Task>();

        private bool mainForm_taskListSymbol_open;

        public MainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Instance = this;

            EnableForm();
        }


        #region TaskListSymbol
        private void mainForm_taskListSymbol_Click(object sender, EventArgs e)
        {
            ToggleTaskListSymbol();
        }

        private void mainForm_toggleTaskList_Click(object sender, EventArgs e)
        {
            ToggleTaskListSymbol();
        }

        private void mainForm_taskListSymbol_DoubleClick(object sender, EventArgs e)
        {
            ToggleTaskListSymbol();
        }

        private void ToggleTaskListSymbol()
        {
            if (taskList.Count == 0) return;

            mainForm_taskListSymbol_open = mainForm_taskListSymbol_open ? false : true;

            if (mainForm_taskListSymbol_open) OpenTaskListSymbol();
            else CloseTaskListSymbol();
        }

        private void OpenTaskListSymbol()
        {
            mainForm_taskListSymbol.Image = Properties.Resources.List_Opened_Symbol;
            mainForm_taskListSymbol_open = true;
            mainForm_taskListPanel.Visible = true;
        }

        private void CloseTaskListSymbol()
        {
            mainForm_taskListSymbol.Image = Properties.Resources.List_Closed_Symbol;
            mainForm_taskListSymbol_open = false;
            mainForm_taskListPanel.Visible = false;
        }

        #endregion

        #region AddNewTaskButton

        private bool mainForm_addNewTaskButton_hover;

        private void mainForm_addNewTaskButton_Click(object sender, EventArgs e)
        {
            DisableForm();

            EditForm editForm = new EditForm(EditMode.New);
            editForm.Show();
        }

        private void mainForm_addNewTaskButton_MouseEnter(object sender, EventArgs e)
        {
            mainForm_addNewTaskButton_hover = true;
            UpdateButtonImage(mainForm_addNewTaskButton, Properties.Resources.Add_New_Task_Button_Hover);
        }

        private void mainForm_addNewTaskButton_MouseLeave(object sender, EventArgs e)
        {
            mainForm_addNewTaskButton_hover = true;
            UpdateButtonImage(mainForm_addNewTaskButton, Properties.Resources.Add_New_Task_Button);
        }

        private void mainForm_addNewTaskButton_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateButtonImage(mainForm_addNewTaskButton, Properties.Resources.Add_New_Task_Button_Pressed);
        }

        private void mainForm_addNewTaskButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainForm_addNewTaskButton_hover)
                UpdateButtonImage(mainForm_addNewTaskButton, Properties.Resources.Add_New_Task_Button_Hover);
            else
                UpdateButtonImage(mainForm_addNewTaskButton, Properties.Resources.Add_New_Task_Button);
        }

        #endregion


        private void UpdateButtonImage(Button button, Image image) => button.Image = image;

        public void DisableForm()
        {
            mainForm_addNewTaskButton.Enabled = false;

            foreach (Task task in taskList)
            {
                task.Enabled = false;
            }
        }

        public void EnableForm()
        {
            mainForm_addNewTaskButton.Enabled = true;

            if (taskList.Count == 0) CloseTaskListSymbol();

            foreach (Task task in taskList)
            {
                task.Enabled = true;
            }
        }

        public void AddNewTask(Task newTask)
        {
            mainForm_taskListPanel.Controls.Add(newTask);
            taskList.Add(newTask);
            newTask.UpdateTask();

            OpenTaskListSymbol();
        }

        public void EditTask(Task task)
        {
            EditForm editForm = new EditForm(EditMode.Edit, task);
            editForm.Show();
            DisableForm();
        }

        public void DeleteTask(Task task)
        {
            taskList.Remove(task);
            mainForm_taskListPanel.Controls.Remove(task);
            EnableForm();
        }
    }

    public class Task : Panel
    {
        public Button button { get; private set; }
        public Button done_Button { get; private set; }

        public TaskInfo info;

        public Task(TaskInfo info)
        {
            this.info = info;
            initComponents();
        }

        private void initComponents()
        {
            button = new Button();
            done_Button = new Button();

            Controls.Add(button);
            Controls.Add(done_Button);
            Name = $"mainForm_taskPanel_{info.taskName}";
            Size = new Size(472, 61);

            button.AutoSize = true;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            button.ForeColor = Color.Silver;
            button.Image = Properties.Resources.Task_Button;
            button.Location = new Point(73, 2);
            button.Name = $"mainForm_taskButton_{info.taskName}";
            button.Size = new Size(396, 56);
            button.Text = info.taskName;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = true;
            button.Click += OnButtonClick;

            done_Button.Anchor = AnchorStyles.Left;
            done_Button.FlatAppearance.BorderSize = 0;
            done_Button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            done_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            done_Button.FlatStyle = FlatStyle.Flat;
            done_Button.Image = Properties.Resources.Task_Button_Unchecked;
            done_Button.Location = new Point(3, 2);
            done_Button.Name = $"mainForm_taskStateButton_{info.taskName}";
            done_Button.Size = new Size(55, 56);
            done_Button.UseVisualStyleBackColor = true;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            MainForm.Instance.EditTask(this);
        }

        public void UpdateTask()
        {
            button.Text = info.taskName;
        }
    }

    public class TaskInfo
    {
        public string taskName;
        public string taskNotes;
        public int taskPriority;
    }
}