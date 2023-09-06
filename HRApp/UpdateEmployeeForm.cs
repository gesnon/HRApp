using HRApp.Application.Interfaces;
using HRApp.Application.Models.Employees;
using HRApp.Application.Models.Posts;
using HRApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApp
{
    public partial class UpdateEmployeeForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;

        int itemId = 0;
        public UpdateEmployeeForm(IEmployeeService employeeService, IPostService postService)
        {
            _employeeService = employeeService;
            _postService = postService;

            InitializeComponent();
        }

        public UpdateEmployeeForm()
        {
            InitializeComponent();
        }

        private async void UpdateEmployeeForm_Load(object sender, EventArgs e)
        {
            var form = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
            var grid = (DataGridView)form.Controls.Find("dataGridView1", true)[0];

            if (grid.SelectedRows.Count != 0)
            {
                DataGridViewRow row = grid.SelectedRows[0];
                itemId = (int)row.Cells["Id"].Value;
                EmployeeGetDTO dto = await _employeeService.GetById(itemId);

                textBox1.Text = dto.FirstName;
                textBox2.Text = dto.LastName;
                textBox3.Text = dto.Patronymic;

                List<PostGetDTO> posts = await _postService.GetAll();

                comboBox1.DataSource = posts;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox1.SelectedValue = dto.Post.Id;
            }
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void AgreeButton_Click(object sender, EventArgs e)
        {
            PostGetDTO post1 = (PostGetDTO)comboBox1.SelectedItem;

            EmployeeCreateDTO employeeCreateDTO = new EmployeeCreateDTO { 
                FirstName=textBox1.Text,
                LastName=textBox2.Text,
                Patronymic=textBox3.Text ,
                PostId=post1.Id,
            } ;
            _employeeService.Update(employeeCreateDTO, itemId);

            string query;

            List<EmployeeGetDTO> employees = await _employeeService.GetByName("");
            var form = (Form1)System.Windows.Forms.Application.OpenForms["Form1"];
            var grid = (DataGridView)form.Controls.Find("dataGridView1", true)[0];
            grid.DataSource = employees;
            this.Close();
        }

        private void DiasgreeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
