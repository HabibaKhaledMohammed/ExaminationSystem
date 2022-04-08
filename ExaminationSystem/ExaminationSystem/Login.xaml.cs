using ExaminationSystem.DataModel;
using ExaminationSystem.SystemData;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace ExaminationSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    ///


    public partial class Login : Window
    {
    public List<Student> StudentsLst { get; set; }
    public List<Instructor> InstructorsLst { get; set; }
    DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
              using (var itemDB = new Examination_SystemEntities())
            {
                StudentsLst = (from s in itemDB.get_All_Students()
                               select new Student
                               {
                                   Stud_ID = s.Stud_ID,
                                   Stud_Fname = s.Stud_Fname,
                                   Stud_Lname = s.Stud_Lname,
                                   Address = s.Address,
                                   GPA = s.GPA,
                                   Password = s.Password,
                               }).ToList(); 


                InstructorsLst = (from i in itemDB.get_All_Instructors()
                                  select new Instructor
                                  {
                                      Instr_ID=i.Instr_ID,
                                      Instr_Name=i.Instr_Name,
                                      Salary=i.Salary,
                                      Degree=i.Degree,
                                      Password=i.Password,
                                  }).ToList();  
            }
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void doLogin(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtUsername.Text);

            if (id >= 202201)
                foreach (Student student in StudentsLst)
                {
                    if (student.Stud_ID == id)
                        if (student.Password == txtPassword.Password)
                        {
                            SystemUser.id = id;
                            SystemUser.userType = Enums.UserType.Student;
                            var window = new MainWindow();
                            window.Show();
                            this.Close();
                        }

                        else
                            MessageBox.Show("Wrong Data");
                }

            else
                foreach (Instructor instructor in InstructorsLst)
                {
                    if (instructor.Instr_ID == id)
                        if (instructor.Password == txtPassword.Password)
                        {
                            SystemUser.id = id;
                            SystemUser.userType = Enums.UserType.Instructor;
                            var window = new MainWindow();
                            window.Show();
                            this.Close();
                        }
                    else
                            MessageBox.Show("Wrong Data");
                }
            }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            //Theme Code ========================>

            //get the current theme used in the application
            ITheme theme = paletteHelper.GetTheme();

            //if condition true, then set IsDarkTheme to false and, SetBaseTheme to light
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }

            //else set IsDarkTheme to true and SetBaseTheme to dark
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            //to apply the changes use the SetTheme function
            paletteHelper.SetTheme(theme);
            //===================================>
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DialogHost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
