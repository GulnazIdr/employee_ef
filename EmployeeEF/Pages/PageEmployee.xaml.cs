using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeeEF.DbService;
using EmployeeEF.Models;
using AppContext = EmployeeEF.DbService.AppContext;

namespace EmployeeEF.Pages
{
    public partial class PageEmployee : Page
    {
        private EmployeeDb employeeDb = new EmployeeDb();
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();    
        private bool isDirty = true;
        public PageEmployee()
        {
            InitializeComponent();
        }

        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            emplGrid.IsReadOnly = false;
            emplGrid.BeginInit();
            isDirty = false;
        }

        private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Employee? employee = emplGrid.SelectedItem as Employee;
            if (employee != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить сотрудника " +
                   employee.Lastname + " " + employee.Firstname + " " + employee.Patronymic, "Предупреждение",
                   MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    employeeDb.DeleteEmployee(employee);
                    emplGrid.SelectedIndex = emplGrid.SelectedIndex == 0 ? 1 : emplGrid.SelectedIndex - 1;

                    employees.Remove(employee);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
            isDirty = true;
        }

        private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AppContext.dbContext.SaveChanges();
            isDirty = true;
            emplGrid.IsReadOnly=true;
        }

        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }

        private void FindCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void FindCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void AddCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                Employee employee = Employee.CreateEmployee("не задано", "не задано", "не задано", 1);

                employeeDb.AddEmployee(employee);
                employees.Add(employee);
                emplGrid.ScrollIntoView(employee);
                emplGrid.SelectedIndex = emplGrid.Items.Count - 1;
                emplGrid.Focus();
                emplGrid.IsReadOnly = false;
                isDirty = false;
        }

        private void AddCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RewriteEmployee();
            emplGrid.IsReadOnly = true;
            isDirty = true;
        }

        private void UndoCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetEmployees();
            emplGrid.SelectedIndex = 0;
        }

        private void RewriteEmployee()
        {
            employees.Clear();
            GetEmployees();
        }

        private void GetEmployees()
        {
            employees = employeeDb.GetEmployees();
            emplGrid.ItemsSource = employees;
        }
    }
}
