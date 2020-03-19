using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTestBertoni.Model;
using TaskTestBertoni.View;
using TaskTestBertoni.ViewModel;
using Xamarin.Forms;

namespace TaskTestBertoni
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //var Vm = new TaskBertoniViewModel();
            //var ListTask = Vm.GetTaskBertoni();
            //BindingContext = Vm;
            //ListViews.ItemsSource = ListTask;
            UpdateList();

        }

        private void UpdateList()
        {
            var Vm = new TaskBertoniViewModel();
            var ListTask = Vm.GetTaskBertoni();
            BindingContext = Vm;
            ListViews.ItemsSource = ListTask;
        }
        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new AddTaskBertoniPage());
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            TaskBertoni taskBertoni = e.Item as TaskBertoni;
            await ((NavigationPage)this.Parent).PushAsync(new AddTaskBertoniPage(taskBertoni));
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void btnDeleted_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var taskBertoni = button?.BindingContext as TaskBertoni;
            var vm = BindingContext as TaskBertoniViewModel;
            vm?.RemoveCommand.Execute(taskBertoni);
            UpdateList();
        }
    }
}
