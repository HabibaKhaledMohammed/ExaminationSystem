using ExaminationSystem.DataModel;
using System;
using System.Collections.Generic;
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

namespace ExaminationSystem.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateExam.xaml
    /// </summary>
    public partial class CreateExam : Window
    {
        public List<Course> CourseLst { get; set; }
        public CreateExam()
        {
            InitializeComponent();
            using (var itemDB = new Examination_SystemEntities())
            {
                CourseLst = (from c in itemDB.get_All_Courses()
                             select new Course
                             {
                                 Course_ID = c.Course_ID,
                                 Course_Name = c.Course_Name,
                                 Course_Duration = c.Course_Duration,
                             }).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string c = comboBoxExam.SelectedItem as string;
            int quesmcq = int.Parse(textBoxMcq.Text);
            int questf = int.Parse(textBoxTF.Text);
            using (var itemDB = new Examination_SystemEntities())
            {
                itemDB.Generate_Exam(c, quesmcq, questf);
            }
       
            this.Close();
        }

        private void comboBoxExam_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            comboBoxExam.ItemsSource = CourseLst.Where(x => x.Course_Name.StartsWith(comboBoxExam.Text.Trim()));
        }

        private void comboBoxExam_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxExam.ItemsSource = CourseLst.Select(x => x.Course_Name);
        }
    }
}
