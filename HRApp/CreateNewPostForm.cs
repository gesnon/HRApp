using HRApp.Application.Interfaces;
using HRApp.Application.Models.Posts;
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
    public partial class CreateNewPostForm : Form
    {
        private readonly IPostService _postService;

        public CreateNewPostForm(IPostService postService)
        {            
            _postService = postService;            

            InitializeComponent();
        }

        public CreateNewPostForm()
        {
            InitializeComponent();
        }

        private void CreateNewPostForm_Load(object sender, EventArgs e)
        {

        }

        private void PostNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void PostNameLable_Click(object sender, EventArgs e)
        {

        }

        private void AgreeButton_Click(object sender, EventArgs e)
        {
            PostCreateDTO dto = new PostCreateDTO { Name=PostNameInput.Text};
            
            _postService.Create(dto);
        }

        private void DisagreeButton_Click(object sender, EventArgs e)
        {
            PostNameInput.Text = "";
        }
    }
}
