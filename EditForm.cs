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
        private TaskInfo info;
        private List<Button> priorityButtons = new List<Button>();

        public EditForm()
        {
            InitializeComponent();

            priorityButtons.Add(editForm_priorityButton1);
            priorityButtons.Add(editForm_priorityButton2);
            priorityButtons.Add(editForm_priorityButton3);
            priorityButtons.Add(editForm_priorityButton4);
            priorityButtons.Add(editForm_priorityButton5);

            info.taskPriority = 1;

            UpdatePriorityButtons();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Instance.EnableForm();
        }

        #region ApplyButton

        private void editForm_applyButton_Click(object sender, EventArgs e)
        {
            info.taskName = editForm_nameTextbox.Text;
            info.taskNotes = editForm_notesTextbox.Text;

            MainForm.Instance.AddNewTask(new Task(info));
            Close();
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


        #region DeleteButtons

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

        #endregion

        #region PriorityButtons

        private void editForm_priorityButton1_Click(object sender, EventArgs e)
        {
            if (info.taskPriority == 1) return;

            info.taskPriority = 1;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton2_Click(object sender, EventArgs e)
        {
            if (info.taskPriority == 2) return;

            info.taskPriority = 2;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton3_Click(object sender, EventArgs e)
        {
            if (info.taskPriority == 3) return;

            info.taskPriority = 3;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton4_Click(object sender, EventArgs e)
        {
            if (info.taskPriority == 4) return;

            info.taskPriority = 4;
            UpdatePriorityButtons();
        }

        private void editForm_priorityButton5_Click(object sender, EventArgs e)
        {
            if (info.taskPriority == 5) return;

            info.taskPriority = 5;
            UpdatePriorityButtons();
        }

        private void UpdatePriorityButtons()
        {
            for(int i = 0; i < priorityButtons.Count; i++)
            {
                if (info.taskPriority - 1 == i)
                {
                    SelectButton(priorityButtons[i]);
                    continue;
                }

                DeselectButton(priorityButtons[i]);
            }

            void SelectButton(Button button)
            {
                button.Image = Properties.Resources.Dark_Gray;
            }

            void DeselectButton(Button button)
            {
                button.Image = Properties.Resources.Gray;
            }
        }

        #endregion

        private void UpdateButtonImage(Button button, Image image) => button.Image = image;
    }
}
