using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PZ_Event3
{
    public partial class StudentForm : Form
    {
        private TextBox txtName;
        private TextBox txtGrade;
        private TextBox txtRoomNumber;
        private Button btnSave;
        private bool isEditing;
        public Student CreatedStudent { get; private set; }
        public int RoomNumber { get; private set; }
        public StudentForm()
        {
            InitializeComponent();
            SetupFormControls();
            isEditing = false;
        }
        public StudentForm(Student student, int roomNumber) : this()
        {
            txtName.Text = student.Name;
            txtGrade.Text = student.Grade.ToString();
            txtRoomNumber.Text = roomNumber.ToString();
            txtRoomNumber.Enabled = false;  
            CreatedStudent = student;  
            isEditing = true;
        }

        private void SetupFormControls()
        {
            txtName = new TextBox { Location = new Point(20, 20), Width = 200 };
            txtGrade = new TextBox { Location = new Point(20, 50), Width = 200 };
            txtRoomNumber = new TextBox { Location = new Point(20, 80), Width = 200 };
            btnSave = new Button { Text = "Save", Location = new Point(20, 110), Width = 200 };
            btnSave.Click += btnSave_Click;
            Controls.Add(txtName);
            Controls.Add(txtGrade);
            Controls.Add(txtRoomNumber);
            Controls.Add(btnSave);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int grade = int.Parse(txtGrade.Text);
                int roomNum = int.Parse(txtRoomNumber.Text);  

                if (!isEditing)
                {
                    CreatedStudent = new Student(name, grade, roomNum);
                    RoomNumber = roomNum;  
                }
                else
                {
                    CreatedStudent.Name = name;
                    CreatedStudent.Grade = grade;
                    
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}