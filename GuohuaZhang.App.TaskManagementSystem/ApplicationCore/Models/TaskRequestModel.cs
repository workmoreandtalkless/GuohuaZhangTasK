﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
   public class TaskRequestModel
    {
        /*public int Id { get; set; }*/
        public int userid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }

        public string Remarks { get; set; }
    }
}
