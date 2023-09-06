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
    public partial class CreateEmployeeForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;       

        public CreateEmployeeForm(IEmployeeService employeeService, IPostService postService)
        {
            _employeeService = employeeService;
            _postService = postService;           
            
            InitializeComponent();
        }
        public CreateEmployeeForm()
        {
            InitializeComponent();

        }


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          


        }

        private async void CreateEmployeeForm_Load(object sender, EventArgs e)
        {
            List<PostGetDTO> posts = await _postService.GetAll();

            comboBox1.DataSource = posts;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

        }

        private void AgreeButton_Click(object sender, EventArgs e)
        {
            PostGetDTO post = (PostGetDTO)comboBox1.SelectedItem;
             

            EmployeeCreateDTO dto = new EmployeeCreateDTO
            {
                FirstName = textBox1.Text,
                LastName = textBox2.Text,
                Patronymic = textBox2.Text,
                PostId = post.Id
            };
            _employeeService.Create(dto);
            
        }

        private void DiasgreeButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
