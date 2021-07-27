using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
 
        public string Fullname { get; set; }
        public string Mobileno { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<TasksHistory> TasksHistories { get; set; }
    }
}
