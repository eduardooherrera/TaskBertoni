using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTestBertoni.Model;
using Xamarin.Forms;

namespace TaskTestBertoni.ViewModel
{
    public class TaskBertoniViewModel
    {
        public List<TaskBertoni> ListTaskBertoni { get; set; }
        public TaskBertoniViewModel()
        {

        }

        public List<TaskBertoni> GetTaskBertoni()
        {
            ListTaskBertoni = App.DB.GetTaskBertoni().Result;
            return ListTaskBertoni;
        }

        public int AddTaskBertoni(TaskBertoni taskBertoni)
        {
            TaskBertoni _taskBertoni = new TaskBertoni();
            _taskBertoni.Name = taskBertoni.Name;
            _taskBertoni.Status = taskBertoni.Status;
            _taskBertoni.StatusName = taskBertoni.Status == false ? "No Completed" : "Completed";
            if (taskBertoni.IdTaskBertoni > 0)
                _taskBertoni.IdTaskBertoni = taskBertoni.IdTaskBertoni;
            var result = App.DB.AddTaskBertoni(_taskBertoni).Result;
            return result;
        }

        public void DeleteTaskBertoni(TaskBertoni taskBertoni)
        {
            var result = App.DB.DeleteTaskBertoni(taskBertoni).Result;
        }

        public Command<TaskBertoni> RemoveCommand
        {
            get
            {
                return new Command<TaskBertoni>((taskBertoni) =>
                {
                    DeleteTaskBertoni(taskBertoni);
                });
            }
        }
        
    }
}
