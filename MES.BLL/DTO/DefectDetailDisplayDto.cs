﻿using System;

namespace MES.BLL.DTO
{
    public class DefectDetailDisplayDto : IdProvider
    {
        public string NameDetail { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}