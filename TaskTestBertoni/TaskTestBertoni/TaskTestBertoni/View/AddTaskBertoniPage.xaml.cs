using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTestBertoni.Model;
using TaskTestBertoni.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskTestBertoni.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskBertoniPage : ContentPage
    {
        public int IdTaskBertoni { get; set; }
        public AddTaskBertoniPage(TaskBertoni taskBertoni = null)
        {
            InitializeComponent();
            if (taskBertoni != null)
                UpdateTask(taskBertoni);

        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            TaskBertoni taskBertoni  = new TaskBertoni();
            taskBertoni.Name = Name.Text;
            taskBertoni.Status = Status.IsChecked;
            if (IdTaskBertoni > 0)
                taskBertoni.IdTaskBertoni = IdTaskBertoni;
            var vm = new TaskBertoniViewModel();
            var result = vm.AddTaskBertoni(taskBertoni);
            DisplayAlert("Success", "Registration Success.", "OK");
            ((NavigationPage)this.Parent).PopAsync();
        }

        private void UpdateTask(TaskBertoni taskBertoni)
        {
            IdTaskBertoni = taskBertoni.IdTaskBertoni;
            Name.Text = taskBertoni.Name;
            Status.IsChecked = taskBertoni.Status;
        }
    }
}