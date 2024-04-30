using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PZ_Event3
{
    public partial class Form1 : Form
    {
        private Room room1 = new Room("Room1", 10);
        private Room room2 = new Room("Room2", 8);
        private Room room3 = new Room("Room3", 5);
        private bool isDragging = false;
        private Point dragStartPoint;
        public Form1()
        {
            InitializeComponent();
            RegisterEventHandlers();
            listBoxRoom1.AllowDrop = true;
            listBoxRoom2.AllowDrop = true;
            listBoxRoom3.AllowDrop = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var studentForm = new StudentForm())
            {
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    Student newStudent = studentForm.CreatedStudent;
                    int roomNumber = studentForm.RoomNumber;
                    AddStudentToRoom(newStudent, roomNumber);
                }
            }
        }
        private void RegisterEventHandlers()
        {
            listBoxRoom1.DoubleClick += ListBox_DoubleClick;
            listBoxRoom2.DoubleClick += ListBox_DoubleClick;
            listBoxRoom3.DoubleClick += ListBox_DoubleClick;
            listBoxRoom1.MouseDown += ListBox_MouseDown;
            listBoxRoom2.MouseDown += ListBox_MouseDown;
            listBoxRoom3.MouseDown += ListBox_MouseDown;
            listBoxRoom1.DragOver += ListBox_DragOver;
            listBoxRoom2.DragOver += ListBox_DragOver;
            listBoxRoom3.DragOver += ListBox_DragOver;
            listBoxRoom1.DragDrop += ListBox_DragDrop;
            listBoxRoom2.DragDrop += ListBox_DragDrop;
            listBoxRoom3.DragDrop += ListBox_DragDrop;
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            using (var studentForm = new StudentForm())
            {
                if (studentForm.ShowDialog() == DialogResult.OK)
                {
                    Student newStudent = studentForm.CreatedStudent;
                    int roomNumber = studentForm.RoomNumber;  
                    AddStudentToRoom(newStudent, roomNumber);
                }
            }
        }


        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null)
            {
                Room room = GetRoomAssociatedWithListBox(listBox);
                Student studentToEdit = room?.Students.Find(st => st.Name == listBox.SelectedItem.ToString());
                int roomNumber = GetRoomNumber(listBox); 
                using (var studentForm = new StudentForm(studentToEdit, roomNumber))
                {
                    if (studentForm.ShowDialog() == DialogResult.OK)
                    {
                        listBox.Items[listBox.SelectedIndex] = studentForm.CreatedStudent.Name;
                    }
                }
            }
        }

        private Room GetRoomAssociatedWithListBox(ListBox listBox)
        {
            if (listBox == listBoxRoom1) return room1;
            if (listBox == listBoxRoom2) return room2;
            if (listBox == listBoxRoom3) return room3;
            return null;
        }

        private void AddStudentToRoom(Student student, int roomNumber)
        {
            Room room = null;
            ListBox listBox = null;

            switch (roomNumber)
            {
                case 1:
                    room = room1;
                    listBox = listBoxRoom1;
                    break;
                case 2:
                    room = room2;
                    listBox = listBoxRoom2;
                    break;
                case 3:
                    room = room3;
                    listBox = listBoxRoom3;
                    break;
                default:
                    MessageBox.Show($"Invalid room number: {roomNumber}");
                    return;
            }

            if (room.AddStudent(student))
            {
                listBox.Items.Add(student.Name);
            }
            else
            {
                MessageBox.Show($"Room {room.Name} is full or student cannot be added.");
            }
        }


        

        private int GetRoomNumber(ListBox listBox)
        {
            if (listBox == listBoxRoom1) return 1;
            if (listBox == listBoxRoom2) return 2;
            if (listBox == listBoxRoom3) return 3;
            return -1;
        }
        private void ListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            int index = listBox.IndexFromPoint(e.X, e.Y);
            if (index != ListBox.NoMatches)
            {
                dragStartPoint = e.Location;
                isDragging = false;
                listBox.MouseMove += ListBox_MouseMove;
            }
        }

        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                int deltaX = Math.Abs(e.X - dragStartPoint.X);
                int deltaY = Math.Abs(e.Y - dragStartPoint.Y);
                if ((deltaX > SystemInformation.DoubleClickSize.Width / 2) || (deltaY > SystemInformation.DoubleClickSize.Height / 2))
                {
                    ListBox listBox = sender as ListBox;
                    int index = listBox.IndexFromPoint(dragStartPoint.X, dragStartPoint.Y);
                    if (index != ListBox.NoMatches && !isDragging)
                    {
                        isDragging = true;  
                        listBox.DoDragDrop(listBox.Items[index], DragDropEffects.Move);
                    }
                }
            }
        }

        private void ListBox_MouseUp(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            listBox.MouseMove -= ListBox_MouseMove;
            isDragging = false;  
        }

        private void ListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void ListBox_DragDrop(object sender, DragEventArgs e)
        {
            ListBox target = sender as ListBox;
            if (target != null && e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string studentName = (string)e.Data.GetData(DataFormats.StringFormat);
                ListBox source = GetSourceListBox(studentName);
                if (source != target)
                {
                    Student student = GetStudentByName(studentName);
                    if (student != null)
                    {
                        Room sourceRoom = GetRoomAssociatedWithListBox(source);
                        Room targetRoom = GetRoomAssociatedWithListBox(target);

                        if (sourceRoom.Students.Remove(student)) 
                        {
                            targetRoom.AddStudent(student); 
                            source.Items.Remove(studentName);
                            target.Items.Add(studentName);
                        }
                    }
                }
            }
        }
        private ListBox GetSourceListBox(string studentName)
        {
            
            if (listBoxRoom1.Items.Contains(studentName)) return listBoxRoom1;
            if (listBoxRoom2.Items.Contains(studentName)) return listBoxRoom2;
            if (listBoxRoom3.Items.Contains(studentName)) return listBoxRoom3;
            return null;
        }

        private Student GetStudentByName(string name)
        {
            if (room1.Students.Any(s => s.Name == name)) return room1.Students.Find(s => s.Name == name);
            if (room2.Students.Any(s => s.Name == name)) return room2.Students.Find(s => s.Name == name);
            if (room3.Students.Any(s => s.Name == name)) return room3.Students.Find(s => s.Name == name);
            return null;
        }

        private void SerButton_Click(object sender, EventArgs e)
        {
            List<Room> roomsToSerialize = new List<Room> { room1, room2, room3 };
            string filename = "rooms.dat";  
            SerializeRooms(roomsToSerialize, filename);
        }


        private void DeSerButton_Click(object sender, EventArgs e)
        {
            string filename = "rooms.dat";  
            List<Room> deserializedRooms = DeserializeRooms(filename);
            UpdateUIWithDeserializedData(deserializedRooms);
        }

        private void UpdateUIWithDeserializedData(List<Room> rooms)
        {
            listBoxRoom1.Items.Clear();
            listBoxRoom2.Items.Clear();
            listBoxRoom3.Items.Clear();
            if (rooms.Count >= 3)
            {
                room1 = rooms[0];
                room2 = rooms[1];
                room3 = rooms[2];

                UpdateListBoxFromRoom(listBoxRoom1, room1);
                UpdateListBoxFromRoom(listBoxRoom2, room2);
                UpdateListBoxFromRoom(listBoxRoom3, room3);
            }
            else
            {
                MessageBox.Show("Десериализованные данные не содержат достаточно комнат.");
            }
        }

        private void SerializeRooms(List<Room> rooms, string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, rooms);
                }
                MessageBox.Show("Кімнати успішно серіалізовані.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка серіалізації: " + ex.Message);
            }
        }

        private List<Room> DeserializeRooms(string filename)
        {
            List<Room> deserializedRooms = new List<Room>();
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    deserializedRooms = (List<Room>)formatter.Deserialize(fs);
                }
                MessageBox.Show("Кімнати успішно десеріалізовані.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка десеріалізації: " + ex.Message);
            }
            return deserializedRooms;
        }
        private void UpdateListBoxFromRoom(ListBox listBox, Room room)
        {
            foreach (var student in room.Students)
            {
                listBox.Items.Add(student.Name);
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            ListBox selectedListBox = null;

            if (listBoxRoom1.SelectedItem != null)
            {
                selectedListBox = listBoxRoom1;
            }
            else if (listBoxRoom2.SelectedItem != null)
            {
                selectedListBox = listBoxRoom2;
            }
            else if (listBoxRoom3.SelectedItem != null)
            {
                selectedListBox = listBoxRoom3;
            }

            if (selectedListBox != null)
            {   
                string studentName = selectedListBox.SelectedItem.ToString();

                Room room = GetRoomAssociatedWithListBox(selectedListBox);

                room.Students.RemoveAll(student => student.Name == studentName);

                selectedListBox.Items.Remove(studentName);

                MessageBox.Show($"Студент {studentName} удален из комнаты {room.Name}.");
            }
            else
            {
                MessageBox.Show("Не выбран объект для удаления.");
            }
        }

        
    }

}