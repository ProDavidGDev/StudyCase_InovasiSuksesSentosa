using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Study_Case_4.Models
{
    public class AttendanceViewModel
    {
        public string SelectedNik { get; set; } = string.Empty;
        public DateTime TanggalAbsen { get; set; }
        public List<SelectListItem> EmployeeList { get; set; } = new List<SelectListItem>();
    }
}
