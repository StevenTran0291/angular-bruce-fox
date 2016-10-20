using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace angularBruceFox.Models
{
    public class TaskRecord
    {
        [Key]
        public int Task_Id { get; set; }
        public string Quote_Type { get; set; }
        public int Quote_Number { get; set; }
        public string Contact { get; set; }
        public string Task_Record { get; set; }
        public DateTime Due_Date { get; set; }
        public string Task_Type { get; set; }
    }

    public class TaskRecordContext : DbContext
    {
        public TaskRecordContext() : base()
        {

        }

        public DbSet<TaskRecord> Taskss { get; set; }
    }
}