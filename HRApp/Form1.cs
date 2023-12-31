using HRApp.Application.Interfaces;
using HRApp.Application.Models.Employees;

namespace HRApp
{
    public partial class Form1 : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;
        private readonly IDataService _dataService;
        private readonly CreateEmployeeForm _createEmployeeForm;
        private readonly UpdateEmployeeForm _updateEmployeeForm;
        private readonly CreateNewPostForm _createNewPostForm;
        

        public Form1(IEmployeeService employeeService, IPostService postService,
            IDataService dataService, CreateEmployeeForm createEmployeeForm, UpdateEmployeeForm updateEmployeeForm, CreateNewPostForm createNewPostForm)
        {
            _employeeService = employeeService;
            _postService = postService;
            _dataService = dataService;
            _createEmployeeForm = createEmployeeForm;
            _updateEmployeeForm = updateEmployeeForm;
            _createNewPostForm = createNewPostForm;
            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _createEmployeeForm.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;

                _updateEmployeeForm.ShowDialog();

            }
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                 await _employeeService.Delete(id);
            }
            //���������� ������� � �����������

            List<EmployeeGetDTO> employees = await _employeeService.GetByName(textBox1.Text);
            dataGridView1.DataSource = employees;
        }

        private async void fillDB_Click(object sender, EventArgs e)
        {
             await _dataService.FillData();

            //���������� ������� � �����������
            List<EmployeeGetDTO> employees = await _employeeService.GetByName("");
            dataGridView1.DataSource = employees;
        }

        private async void ClearDB_Click(object sender, EventArgs e)
        {
            await _dataService.RemoveAllData();

            //���������� ������� � �����������
            List<EmployeeGetDTO> employees = await _employeeService.GetByName("");
            dataGridView1.DataSource = employees;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //��������������� �������� �������
            List<EmployeeGetDTO> employees = await _employeeService.GetByName(textBox1.Text);

            dataGridView1.DataSource = employees;           

        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {

            //���������� ������� � �����������
            List<EmployeeGetDTO> employees = await _employeeService.GetByName(textBox1.Text);

            dataGridView1.DataSource = employees;

        }

        private async void AddNewPostButton_Click(object sender, EventArgs e)
        {
           _createNewPostForm.ShowDialog();
            
        }
    }
}