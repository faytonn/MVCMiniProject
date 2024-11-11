﻿using System.ComponentModel.DataAnnotations;

namespace MVCMiniProject.Areas.Admin.ViewModels
{
    public class AdminLoginViewModel
    {
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
