using ExaminationSystem.DataModel;
using ExaminationSystem.Dialogs;
using ExaminationSystem.SystemData;
using ExaminationSystem.UserControls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace ExaminationSystem
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public List<Course> Courses { get; set; }
        public Dashboard()
        {
            InitializeComponent();  
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var createOrUpdate = new CreateOrUpdateCourse(-1);
            createOrUpdate.ShowDialog();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            if (SystemUser.userType == Enums.UserType.Instructor)
            {
                using (var _context = new Examination_SystemEntities())
                {
                    Courses = (from c in _context.get_AllCourses_ByInstrID(SystemUser.id)
                               select new Course
                               {
                                   Course_ID = c.Course_ID,
                                   Course_Name = c.Course_Name,
                                   Course_Duration = c.Course_Duration
                               }).ToList();


                }

                foreach (var c in Courses)
                {
                    string gridXaml = XamlWriter.Save((Card)CourseList.Children[0]);
                    StringReader stringReader = new StringReader(gridXaml);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Card newCard = (Card)XamlReader.Load(xmlReader);
                    newCard.Visibility = Visibility.Visible;
                    newCard.MouseDown += (_sender, _e) => newCourseDetails(c.Course_ID);
                    //newCard.SetValue("5");

                    StringBuilder departments = new StringBuilder();
                    using (var _context = new Examination_SystemEntities())
                    {
                        (from D in _context.get_AllDepartments_ByCourseID(c.Course_ID)
                         select new { D.Dept_Name }).ToList().ForEach(d => departments.Append(d.Dept_Name));
                    }

                    StackPanel newStack = (StackPanel)(newCard.Content);
                    Grid newGrid = (Grid)(newStack.Children[1]);

                    ((TextBlock)newGrid.Children[0]).Text = c.Course_Name;
                    ((TextBlock)newGrid.Children[1]).Text = departments.ToString();
                    ((TextBlock)newGrid.Children[2]).Text = c.Course_Duration.ToString() + "Hours";
                    ((Button)newGrid.Children[3]).Click += (_sender, _e) =>
                    {
                        using (var _context = new Examination_SystemEntities())
                        {
                            _context.Delete_Course_WithDependences_ById(c.Course_ID);
                            CourseList.Children.Remove(newCard);
                        }

                    };
                    CourseList.Children.Add(newCard);
                }
            }
            else
            {
                using (var _context = new Examination_SystemEntities())
                {
                    Courses = (from c in _context.get_AllCourses_ByStudID(SystemUser.id)
                               select new Course
                               {
                                   Course_ID = c.Course_ID,
                                   Course_Name = c.Course_Name,
                                   Course_Duration = c.Course_Duration
                               }).ToList();
                }

                foreach (var c in Courses)
                {
                    string gridXaml = XamlWriter.Save((Card)CourseList.Children[0]);
                    StringReader stringReader = new StringReader(gridXaml);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Card newCard = (Card)XamlReader.Load(xmlReader);
                    newCard.Visibility = Visibility.Visible;
                    StringBuilder departments = new StringBuilder();
                    using (var _context = new Examination_SystemEntities())
                    {
                        (from D in _context.get_AllDepartments_ByCourseID(c.Course_ID)
                         select new { D.Dept_Name }).ToList().ForEach(d => departments.Append(d.Dept_Name));
                    }

                    StackPanel newStack = (StackPanel)(newCard.Content);
                    Grid newGrid = (Grid)(newStack.Children[1]);

                    ((TextBlock)newGrid.Children[0]).Text = c.Course_Name;
                    ((TextBlock)newGrid.Children[1]).Text = departments.ToString();
                    ((TextBlock)newGrid.Children[2]).Text = c.Course_Duration.ToString() + "Hours";
                    ((Button)newGrid.Children[3]).Content = "View Course";

                    ObjectParameter @ChoosenExam_id = new ObjectParameter("ChoosenExam_id", typeof(Int32?));
                    using (var _context = new Examination_SystemEntities())
                    {
                        _context.Is_StudentTakeExam(SystemUser.id, c.Course_ID, ChoosenExam_id);
                    }
                    if (ChoosenExam_id.Value.ToString().Trim() == "")
                    {
                        ((Button)newGrid.Children[3]).Content = "Start Exam";
                        ((Button)newGrid.Children[3]).Click += (_sender, _e) =>
                        {
                            using (var _context = new Examination_SystemEntities())
                            {
                                Button item = _sender as Button;
                                var parent = ((item.Parent as Grid).Parent as StackPanel).Parent as Card;
                                var parentOfParent = parent.Parent as WrapPanel;
                                var CourseIndex = parentOfParent.Children.IndexOf(parent) - 2;

                                _context.Take_Random_Exam(SystemUser.id, Courses[CourseIndex].Course_ID, ChoosenExam_id);
                                var viewCourse = new ViewOrSubmitExam(Int32.Parse(ChoosenExam_id.Value.ToString()));
                                viewCourse.ShowDialog();
                            }
                        };

                    }



                    ((Button)newGrid.Children[3]).Click += (_sender, _e) => newCourseDetails(c.Course_ID);
                    CourseList.Children.Add(newCard);

                }


            }
        }

/// ///////////////////////// Hellper Functions
        void newCourseDetails(int param1)
        {
            DependencyObject ucParent = this.Parent;


            Grid g = ucParent as Grid;
            g?.Children?.Clear();
            g.Children.Add(new CourseDetails(param1));

        }

    }
}
