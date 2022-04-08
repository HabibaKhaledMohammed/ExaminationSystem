using ExaminationSystem.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
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
    /// Interaction logic for CreateOrUpdateCourse.xaml
    /// </summary>
    public partial class CreateOrUpdateCourse : Window
    {
        int id, flag = 0;

        public List<Instructor> InstructorsLst { get; set; }
        public List<Department> DepartmentLst { get; set; }
        public List<Topic> TopicLst { get; set; }


        public CreateOrUpdateCourse(int _id)
        {
            InitializeComponent();
            this.id = _id;
            using (var itemDB = new Examination_SystemEntities())
            {
                DepartmentLst = (from d in itemDB.get_All_Department()
                                 select new Department
                                 {
                                     Dept_ID = d.Dept_ID,
                                     Dept_Name = d.Dept_Name,
                                     Description = d.Description,
                                     Instr_ID = d.Instr_ID
                                 }).ToList();

                TopicLst = (from t in itemDB.get_all_topic_cousre(id)
                            select new Topic
                            {
                                Topic_ID = t.Topic_ID,
                                Topic_name = t.Topic_name,
                                Course_ID = t.Course_ID,
                            }).ToList();

                InstructorsLst = (from i in itemDB.get_All_Instructors()
                                  select new Instructor
                                  {
                                      Instr_ID = i.Instr_ID,
                                      Instr_Name = i.Instr_Name,
                                      Salary = i.Salary,
                                      Degree = i.Degree,
                                      Password = i.Password,
                                  }).ToList();
            }

            if (id == -1) { flag = 0; }
            else
            {
                flag = 1;
                btnAdd.Content = "  Update";
                using (var itemDB = new Examination_SystemEntities())
                {
                    var c = itemDB.get_Course_ById(id);
                    foreach (var crs in c)
                    {
                        txtcourseName.Text = Convert.ToString(crs.Course_Name);
                        txtDuration.Text = Convert.ToString(crs.Course_Duration);
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (Topic top in TopicLst)
                    {
                        sb.Append(top.Topic_name);
                        sb.Append('/');
                    }
                   
                    txtTopics.Text = sb.ToString();


                }
            }

        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void ComboDepartment_Loaded(object sender, RoutedEventArgs e)
        {
            ComboDepartment.ItemsSource = DepartmentLst;
        }

        private void ComboInstructor_Loaded(object sender, RoutedEventArgs e)
        {
            ComboInstructor.ItemsSource = InstructorsLst;
        }





        private void ComboDepartment_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ComboDepartment.ItemsSource = DepartmentLst.Where(x => x.Dept_Name.StartsWith(ComboDepartment.Text.Trim()));
        }

        List<Department> SelectedDept = new List<Department>();
        private void chkDepartment_Checked(object sender, RoutedEventArgs e)
        {
            var mydeptcom = sender.ToString();
            foreach (Department department in DepartmentLst)
            {
                if (mydeptcom.Contains($"{department.Dept_Name}") && mydeptcom.Contains("True") && !SelectedDept.Contains(department))
                {
                    SelectedDept.Add(department);
                }
            }

        }



        private void ComboInstructor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ComboInstructor.ItemsSource = InstructorsLst.Where(x => x.Instr_Name.StartsWith(ComboInstructor.Text.Trim()));
        }

        List<Instructor> SelectedInst = new List<Instructor>();
        private void chkInstructor_Checked(object sender, RoutedEventArgs e)
        {
            var myinstcom = sender.ToString();
            foreach (Instructor instructor in InstructorsLst)
            {
                if (myinstcom.Contains($"{instructor.Instr_Name}") && myinstcom.Contains("True") && !SelectedInst.Contains(instructor))
                {
                    SelectedInst.Add(instructor);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string coursename = txtcourseName.Text;
            int duration = int.Parse(txtDuration.Text);
            string[] topics = txtTopics.Text.Split('/');
            if (flag == 0)
            {

                using (var itemDB = new Examination_SystemEntities())
                {
                    ObjectParameter @courseid = new ObjectParameter("courseid", typeof(Int32));
                    itemDB.insert_course(coursename, duration, @courseid);
                    foreach (string topic in topics)
                    {
                        itemDB.Insert_Topic(topic, int.Parse(courseid.Value.ToString()));
                    }

                    foreach (Department dept in SelectedDept)
                    {
                        itemDB.insert_Dept_Course_ById(dept.Dept_ID, int.Parse(courseid.Value.ToString()));
                    }

                    foreach (Instructor inst in SelectedInst)
                    {
                        itemDB.insert_Instr_Course(inst.Instr_ID, int.Parse(courseid.Value.ToString()));
                    }

                }


            }
            else
            {

                using (var itemDB = new Examination_SystemEntities())
                {
                    itemDB.update_course_ById(id, coursename, duration);
                    itemDB.delete_all_topic_cousre(id);
                    itemDB.delete_all_Dept_cousre(id);
                    itemDB.delete_all_Inst_cousre(id);
                    foreach (string topic in topics)
                    {
                        itemDB.Insert_Topic(topic, id);
                    }

                    foreach (Department dept in SelectedDept)
                    {
                        itemDB.insert_Dept_Course_ById(dept.Dept_ID, id);
                    }

                    foreach (Instructor inst in SelectedInst)
                    {
                        itemDB.insert_Instr_Course(inst.Instr_ID, id);
                    }

                }
            }
          
            this.Close();

        }

      


    }
}
