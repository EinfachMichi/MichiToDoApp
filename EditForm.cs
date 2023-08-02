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
    public partial class EditForm : Form
    {
        private Task task;
        private List<Button> priorityButtons = new List<Button>();
        private EditMode editMode;

        public EditForm(EditMode mode, Task task = null)
        {
            InitializeComponent();
            priorityButtons.Add(editForm_priorityButton1);
            priorityButtons.Add(editForm_priorityButton2);
            priorityButtons.Add(editForm_priorityButton3);
            priorityButtons.Add(editForm_priorityButton4);
            priorityButtons.Add(editForm_priorityButton5);

            if (task == null) 
                task = new Task(new TaskInfo() { taskPriority = 1 }, MainForm.Instance.newTaskID);

            this.task = task;
            editMode = mode;

            UpdatePriorityButtons();
            UpdateInfo();
            

            if(mode == EditMode.Edit)
            {
                editForm_notesTextbox.Select();
                ToggleDeleteButtonVisibility(true);
            }
            else
            {
                editForm_nameTextbox.Select();
                ToggleDeleteButtonVisibility(false);
            }
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Instance.EnableForm();
        }

        #region ApplyButton

        private void editForm_applyButton_Click(object sender, EventArgs e)
        {
            if (editForm_nameTextbox.Text == "")
            {
                MessageBox.Show("Error: Name can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editForm_nameTextbox.Text = task.info.taskName;
                editForm_nameTextbox.Select();
                return;
            }

            if (NameAlreadyExists(editForm_nameTextbox.Text))
            {
                MessageBox.Show("Error: Name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                editForm_nameTextbox.Text = task.info.taskName;
                editForm_nameTextbox.Select();
                return;
            }

            task.info.taskName = editForm_nameTextbox.Text;
            task.info.taskNotes = editForm_notesTextbox.Text;

            if(editMode == EditMode.Edit)
                MainForm.Instance.ApplyChanges(task);
            else
                MainForm.Instance.AddNewTask(task);
            Close();
        }

        private bool NameAlreadyExists(string name)
        {
            foreach (Task task in MainForm.Instance.taskList)
            {
                if (task.info.taskName == name) return true;
            }
            return false;
        }

        private bool editForm_applyButton_hover;

        private void editForm_applyButton_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateButtonImage(editForm_applyButton, Properties.Resources.Action_Button_Pressed);
        }

        private void editForm_applyButton_MouseEnter(object sender, EventArgs e)
        {
            editForm_applyButton_hover = true;
            UpdateButtonImage(editForm_applyButton, Properties.Resources.Action_Button_Hover);
        }

        private void editForm_applyButton_MouseLeave(object sender, EventArgs e)
        {
            editForm_applyButton_hover = false;
            UpdateButtonImage(editForm_applyButton, Properties.Resources.Action_Button);
        }

        private void editForm_applyButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (editForm_applyButton_hover)
                UpdateButtonImage(editForm_applyButton, Properties.Resources.Action_Button_Hover);
            else
                UpdateButtonImage(editForm_applyButton, Properties.Resources.Action_Button);
        }

        #endregion

        #region CancelButton

        private void editForm_cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool editForm_cancelButton_hover;

        private void editForm_cancelButton_MouseEnter(object sender, EventArgs e)
        {
            editForm_cancelButton.Image = Properties.Resources.Action_Button_Hover;
            editForm_cancelButton_hover = true;
        }

        private void editForm_cancelButton_MouseLeave(object sender, EventArgs e)
        {
            editForm_cancelButton.Image = Properties.Resources.Action_Button;
            editForm_cancelButton_hover = false;
        }

        private void editForm_cancelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (editForm_cancelButton_hover)
                UpdateButtonImage(editForm_cancelButton, Properties.Resources.Action_Button_Hover);
            else
                UpdateButtonImage(editForm_cancelButton, Properties.Resources.Action_Button);
        }

        private void editForm_cancelButton_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateButtonImage(editForm_cancelButton, Properties.Resources.Action_Button_Pressed);
        }

        #endregion

        #region DeleteButton

        private bool editForm_deleteButton_hover;

        private void editForm_deleteButton_MouseEnter(object sender, EventArgs e)
        {
            editForm_deleteButton_hover = true;
            UpdateButtonImage(editForm_deleteButton, Properties.Resources.Delete_Task_Button_Hover);
        }

        private void editForm_deleteButton_MouseLeave(object sender, EventArgs e)
        {
            editForm_deleteButton_hover = false;
            UpdateButtonImage(editForm_deleteButton, Properties.Resources.Delete_Task_Button);
        }

        private void editForm_deleteButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (editForm_deleteButton_hover)
                UpdateButtonImage(editForm_deleteButton, Properties.Resources.Delete_Task_Button_Hover);
            else
                UpdateButtonImage(editForm_deleteButton, Properties.Resources.Delete_Task_Button);
        }

        private void editForm_deleteButton_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateButtonImage(editForm_deleteButton, Properties.Resources.Delete_Task_Button_Pressed);
        }

        private void editForm_deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Do you really want to delete the task '{task.info.taskName}'?", "Delete task", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                MainForm.Instance.DeleteTask(task);
                Close();
            }
        }

        private void ToggleDeleteButtonVisibility(bool active) => editForm_deleteButton.Visible = active;

        #endregion

        #region PriorityButtons

        private void editForm_priorityButton1_Click(object sender, EventArgs e)
        {
            if (task.info.taskPriority == 1) return;

            task.info.taskPriority = 1;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton2_Click(object sender, EventArgs e)
        {
            if (task.info.taskPriority == 2) return;

            task.info.taskPriority = 2;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton3_Click(object sender, EventArgs e)
        {
            if (task.info.taskPriority == 3) return;

            task.info.taskPriority = 3;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton4_Click(object sender, EventArgs e)
        {
            if (task.info.taskPriority == 4) return;

            task.info.taskPriority = 4;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton5_Click(object sender, EventArgs e)
        {
            if (task.info.taskPriority == 5) return;

            task.info.taskPriority = 5;
            UpdatePriorityButtons();
        }

        private void UpdatePriorityButtons()
        {
            for(int i = 0; i < priorityButtons.Count; i++)
            {
                if (task.info.taskPriority - 1 == i)
                {
                    SelectButton(i);
                    continue;
                }

                DeselectButton(i);
            }

            void SelectButton(int index)
            {
                switch (index)
                {
                    case 0:
                        priorityButtons[0].Image = Properties.Resources.Priority_1_Selected;
                        break;
                    case 1:
                        priorityButtons[1].Image = Properties.Resources.Priority_2_Selected;
                        break;
                    case 2:
                        priorityButtons[2].Image = Properties.Resources.Priority_3_Selected;
                        break;
                    case 3:
                        priorityButtons[3].Image = Properties.Resources.Priority_4_Selected;
                        break;    
                    case 4:
                        priorityButtons[4].Image = Properties.Resources.Priority_5_Selected;
                        break;  
                }
            }

            void DeselectButton(int index)
            {
                switch (index)
                {
                    case 0:
                        priorityButtons[0].Image = Properties.Resources.Priority_1;
                        break;
                    case 1:
                        priorityButtons[1].Image = Properties.Resources.Priority_2;
                        break;
                    case 2:
                        priorityButtons[2].Image = Properties.Resources.Priority_3;
                        break;
                    case 3:
                        priorityButtons[3].Image = Properties.Resources.Priority_4;
                        break;
                    case 4:
                        priorityButtons[4].Image = Properties.Resources.Priority_5;
                        break;
                }
            }
        }

        #endregion

        private void UpdateInfo()
        {
            editForm_nameTextbox.Text = task.info.taskName;
            editForm_notesTextbox.Text = task.info.taskNotes;
        }

        private void UpdateButtonImage(Button button, Image image) => button.Image = image;
    }

    public enum EditMode
    {
        New,
        Edit
    }
}
