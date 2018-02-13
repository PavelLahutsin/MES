﻿using System;
using System.ComponentModel.DataAnnotations;
using MES.DAL.Enums;

namespace MES.WEB.Models
{
    public class RepairVm : IdProvider
    {
        [Display(Name = "Название продукта")]
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "Вид ремонта")]
        [Required]
        public RepairsVariant RepairsVariant { get; set; }

        [Display(Name = "Количество")]
        [Range(1, 100000, ErrorMessage = "Min = 1, Max = 100000")]
        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Название продукта")]
        public string ProductName { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Добавил")]
        public string UserName { get; set; }

    }
}