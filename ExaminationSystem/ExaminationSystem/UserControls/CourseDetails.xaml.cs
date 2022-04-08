using ExaminationSystem.DataModel;
using ExaminationSystem.Dialogs;
using ExaminationSystem.SystemData;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

namespace ExaminationSystem.UserControls
{
    /// <summary>
    /// Interaction logic for CourseDetails.xaml
    /// </summary>
    public partial class CourseDetails : UserControl
    {
        public List<string> Instructors { get; set; }
        public List<string> Topics { get; set; }
        public List<int> Exams { get; set; }

        int param1;
        public CourseDetails(int _param1)
        {
            this.param1 = _param1;
            InitializeComponent();
            
            int id = param1;

            /////////////////////// Course
            using (var _context = new Examination_SystemEntities())
            {
                var c = _context.get_Course_ById(id);
               foreach (var crs in c)
                {
                    courseName.Text = Convert.ToString(crs.Course_Name);
                    crsDuration.Text = Convert.ToString(crs.Course_Duration);
                }
               var depts = _context.get_AllDepartments_ByCourseID(id).ToList().Distinct();
                StringBuilder s = new StringBuilder();
               foreach (var dept in depts){
                    s.Append(dept.Dept_Name);
                    s.Append(",");
                }
                s.Remove(s.Length - 1, 1);
                crsDept.Text = s.ToString();
              
               
            }



            ////////////////////// Topics
            using (var _context = new Examination_SystemEntities())
            {
                Topics = (from t in _context.get_AllTopics_ByCourseID(id)
                          select t).ToList(); 
            }
            foreach (var topic in Topics)
            {
                string gridXaml = XamlWriter.Save((Button)TopicsWrapper.Children[0]);
                StringReader stringReader = new StringReader(gridXaml);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Button newButton = (Button)XamlReader.Load(xmlReader);
                newButton.Visibility = Visibility.Visible;
                newButton.Content = topic;
                TopicsWrapper.Children.Add(newButton);
            }


            ///Instructor 
            using (var _context = new Examination_SystemEntities())
            {
                Instructors = (from i in _context.get_AllInstrs_ByCourseID(id)
                               select i).ToList();
            }
            foreach (var ins in Instructors)
            {
                string gridXaml = XamlWriter.Save((Grid)InstructorWrapper.Children[1]);
                StringReader stringReader = new StringReader(gridXaml);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Grid newGrid = (Grid)XamlReader.Load(xmlReader);
                newGrid.Visibility = Visibility.Visible;

                ((TextBlock)newGrid.Children[0]).Text = "Instructor one: ";
                ((TextBlock)newGrid.Children[1]).Text = ins;
                InstructorWrapper.Children.Add(newGrid);
            }



            //////////////////////////exams
            if (SystemUser.userType == Enums.UserType.Instructor)
            {
                using (var _context = new Examination_SystemEntities())
                {
                    Exams = (from e in _context.get_AllExams__ByCourseID(id)
                             select e.Value).ToList();
                }
                int v = 0;
                foreach (var exam in Exams)
                {
                    string gridXaml = XamlWriter.Save((Card)ExamWrapper.Children[0]);
                    StringReader stringReader = new StringReader(gridXaml);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Card newCard = (Card)XamlReader.Load(xmlReader);
                    newCard.Visibility = Visibility.Visible;

                    Grid newGrid = (Grid)newCard.Content;
                    Enums.ExamsVersions e = (Enums.ExamsVersions)v++;
                    ((TextBlock)newGrid.Children[1]).Text = e.ToString();
                    ((Button)newGrid.Children[3]).Click += Button_Click_1;

                    ExamWrapper.Children.Add(newCard);
                }
            }
            else
            {

              
                using (var _context= new Examination_SystemEntities())
                {
                    ObjectParameter @ChoosenExam_id = new ObjectParameter("ChoosenExam_id", typeof(Int32?));
                    _context.Is_StudentTakeExam(SystemUser.id,id, ChoosenExam_id);

                    if (ChoosenExam_id.Value.ToString().Trim() != "")
                    {
                    ObjectParameter @grade = new ObjectParameter("grade", typeof(float?));
                        createExam.Visibility = Visibility.Collapsed;
                        _context.get_Stud_Course_Exam_ById(Int32.Parse(@ChoosenExam_id.Value.ToString()), id, SystemUser.id, @grade);
                        ExamContent.Content ="Final Exam Degrae: " + (Int32.Parse(grade.Value.ToString())*10).ToString()+"%";
                    }
                    else
                    {
                        ExamHeader.Visibility = Visibility.Collapsed;
                        ExamContent.Visibility = Visibility.Collapsed;

                    }
                }
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newExam=new CreateExam();
            newExam.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var viewCourse=new ViewOrSubmitExam(param1);
            viewCourse.ShowDialog();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var updateCourse = new CreateOrUpdateCourse(param1);
            updateCourse.ShowDialog();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject ucParent = this.Parent;
            Grid g = ucParent as Grid;
            g.Children.Clear();
            g.Children.Add(new Dashboard());
        }

       
    }
}
