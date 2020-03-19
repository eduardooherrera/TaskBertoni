using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTestBertoni.Model
{
    public class TaskBertoni
    {
        [PrimaryKey, AutoIncrement]
        public int IdTaskBertoni { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
    }
}
