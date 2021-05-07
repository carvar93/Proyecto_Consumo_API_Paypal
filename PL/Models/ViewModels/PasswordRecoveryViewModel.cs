﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModels
{
    public class PasswordRecoveryViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}