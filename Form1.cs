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
        public List<Task> taskDoneList = new List<Task>();

        private int idCount = 0;
        public int newTaskID
        {
            get
            {
                idCount++;
                return idCount;
            }
        }

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

        private bool mainForm_taskListSymbol_open;

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
            if (taskList.Count == 0)
            {
                CloseTaskListSymbol();
                return;
            }

            mainForm_taskListSymbol_open = mainForm_taskListSymbol_open ? false : true;

            if (mainForm_taskListSymbol_open) OpenTaskListSymbol();
            else CloseTaskListSymbol();
        }

        private void OpenTaskListSymbol()
        {
            mainForm_taskListSymbol.Image = Properties.Resources.List_Arrow_Opened;
            mainForm_taskListSymbol_open = true;
            mainForm_taskListPanel.Visible = true;

            RepositionTaskDoneList(464);
        }

        private void CloseTaskListSymbol()
        {
            mainForm_taskListSymbol.Image = Properties.Resources.List_Arrow_Closed;
            mainForm_taskListSymbol_open = false;
            mainForm_taskListPanel.Visible = false;

            RepositionTaskDoneList(245);
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

        #region TaskDoneListSymbol

        private bool mainForm_taskDoneListSymbol_open;

        private void mainForm_taskDoneListSymbol_Click(object sender, EventArgs e)
        {
            ToggleTaskDoneListSymbol();
        }

        private void mainForm_toggleTaskDoneListButton_Click(object sender, EventArgs e)
        {
            ToggleTaskDoneListSymbol();
        }

        private void mainForm_taskDoneListSymbol_DoubleClick(object sender, EventArgs e)
        {
            ToggleTaskDoneListSymbol();
        }

        private void ToggleTaskDoneListSymbol()
        {
            if (taskDoneList.Count == 0) return;

            mainForm_taskDoneListSymbol_open = mainForm_taskDoneListSymbol_open ? false : true;

            if (mainForm_taskDoneListSymbol_open) OpenTaskDoneListSymbol();
            else CloseTaskDoneListSymbol();
        }

        private void OpenTaskDoneListSymbol()
        {
            mainForm_taskDoneListSymbol.Image = Properties.Resources.List_Arrow_Opened;
            mainForm_taskDoneListSymbol_open = true;
            mainForm_taskDoneListPanel.Visible = true;
        }

        private void CloseTaskDoneListSymbol()
        {
            mainForm_taskDoneListSymbol.Image = Properties.Resources.List_Arrow_Closed;
            mainForm_taskDoneListSymbol_open = false;
            mainForm_taskDoneListPanel.Visible = false;
        }

        private void RepositionTaskDoneList(int y)
        {
            mainForm_taskDoneListPanel.Location = new Point(12, y + 85);
            mainForm_taskDoneListSymbol.Location = new Point(36, y + 7);
            mainForm_toggleTaskDoneListButton.Location = new Point(102, y);
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
            if (taskDoneList.Count == 0) CloseTaskDoneListSymbol();

            foreach (Task task in taskList)
            {
                task.Enabled = true;
            }

            foreach (Task task in taskDoneList)
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

        public void ApplyChanges(Task task)
        {
            for(int i = 0; i < taskList.Count; i++)
            {
                if (taskList[i].id == task.id)
                {
                    taskList[i] = task;
                    task.UpdateTask();
                }
            }
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

        public void TaskDone(Task task)
        {
            taskList.Remove(task);
            mainForm_taskListPanel.Controls.Remove(task);

            taskDoneList.Add(task);
            mainForm_taskDoneListPanel.Controls.Add(task);
            task.editable = false;

            if(taskList.Count == 0) CloseTaskListSymbol();
            OpenTaskDoneListSymbol();
        }

        public void RestoreTask(Task task)
        {
            taskDoneList.Remove(task);
            mainForm_taskDoneListPanel.Controls.Remove(task);

            taskList.Add(task);
            mainForm_taskListPanel.Controls.Add(task);
            task.editable = true;

            if (taskDoneList.Count == 0) CloseTaskDoneListSymbol();
            OpenTaskListSymbol();
        }
    }

    public class Task : Panel
    {
        public Button button { get; private set; }
        public Button done_Button { get; private set; }
        public PictureBox priorityDisplay { get; private set; }

        public TaskInfo info;
        public bool editable = true;
        public int id;

        public Task(TaskInfo info, int taskID)
        {
            this.info = info;
            id = taskID;
            initComponents();
        }

        private void initComponents()
        {
            button = new Button();
            done_Button = new Button();
            priorityDisplay = new PictureBox();

            Controls.Add(button);
            Controls.Add(done_Button);
            Controls.Add(priorityDisplay);
            Name = $"mainForm_taskPanel_{info.taskName}_{id}";
            Size = new Size(550, 61);

            button.AutoSize = true;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            button.ForeColor = Color.Silver;
            button.Image = Properties.Resources.Task_Button;
            button.Location = new Point(73, 2);
            button.Name = $"mainForm_taskButton_{info.taskName}_{id}";
            button.Size = new Size(396, 56);
            button.Text = info.taskName;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = true;
            button.Click += OnButtonClick;
            button.MouseUp += OnButtonMouseUp;

            done_Button.Anchor = AnchorStyles.Left;
            done_Button.FlatAppearance.BorderSize = 0;
            done_Button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            done_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            done_Button.FlatStyle = FlatStyle.Flat;
            done_Button.Image = Properties.Resources.Task_Button_Unchecked;
            done_Button.Location = new Point(3, 2);
            done_Button.Name = $"mainForm_taskStateButton_{info.taskName}_{id}";
            done_Button.Size = new Size(55, 56);
            done_Button.UseVisualStyleBackColor = true;
            done_Button.Click += OnDoneButtonClick;

            priorityDisplay.Location = new Point(475, 3);
            priorityDisplay.Name = $"mainForm_priorityDisplay_{info.taskName}_{id}";
            priorityDisplay.Size = new Size(54, 54);
            priorityDisplay.TabStop = false;
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (!editable) return;

            MainForm.Instance.EditTask(this);
        }

        private void OnDoneButtonClick(object sender, EventArgs e)
        {
            done_Button.Image = Properties.Resources.Task_Button_Checked;
            done_Button.Enabled = false;
            MainForm.Instance.TaskDone(this);
        }

        private void OnButtonMouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) 
            {   
                DialogResult result = MessageBox.Show($"Do you want to restore the task '{info.taskName}'?", "Restore Task", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    done_Button.Image = Properties.Resources.Task_Button_Unchecked;
                    done_Button.Enabled = true;
                    MainForm.Instance.RestoreTask(this);
                }
            }
        }

        public void UpdateTask()
        {
            button.Text = info.taskName;
            switch (info.taskPriority)
            {
                case 1:
                    priorityDisplay.Image = Properties.Resources.Priority_1;
                    break;
                case 2:
                    priorityDisplay.Image = Properties.Resources.Priority_2;
                    break;
                case 3:
                    priorityDisplay.Image = Properties.Resources.Priority_3;
                    break;
                case 4:
                    priorityDisplay.Image = Properties.Resources.Priority_4;
                    break;
                case 5:
                    priorityDisplay.Image = Properties.Resources.Priority_5;
                    break;
            }
        }
    }

    public class TaskInfo
    {
        public string taskName;
        public string taskNotes;
        public int taskPriority;
    }
}