using ExaminationSystem.DataModel;
using ExaminationSystem.Dialogs;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Xml.Linq;
using ExaminationSystem.SystemData;

namespace ExaminationSystem.Dialogs
{
    /// <summary>
    /// Interaction logic for ViewOrSubmitExam.xaml
    /// </summary>

    public partial class ViewOrSubmitExam : Window
    {
        int id;
        public List<Exam> Exams { get; set; }
        public List<Question>Questions { get; set; }

        public List<int>StudenAnswers{ get; set; }
        public ViewOrSubmitExam(int _param1)
        {
            InitializeComponent();
            id = _param1;
            StudenAnswers = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                StudenAnswers.Add(1);
            }
            if (SystemUser.userType == Enums.UserType.Instructor)
            {
              using (var DataT = new Examination_SystemEntities())
            {

                //  var Ques = DataT.get_questuin_options(id);// For student
                  var Ques = DataT.ExamWithCorrectAnswers(id);// For Imnstructor
                Questions = new List<Question>();
                foreach (var ques in Ques)
                {
                    if (Questions?.LastOrDefault()?.Quest_ID == ques.question_id)
                        Questions.LastOrDefault().Quest_Option.Add(new Quest_Option() { Option_Name = ques.question_option });
                    else
                    {
                        Questions.Add(new Question() { Quest_ID = (int)ques.question_id, Quest_Description = (string)ques.question_description, Quest_Answer=ques.question_answer });
                        if (ques.question_option != null)
                        {
                            Questions.Last().Quest_Option = new List<Quest_Option>();
                            Questions.LastOrDefault().Quest_Option?.Add(new Quest_Option() { Option_Name = ques.question_option });
                        }

                    }
                }
            }

              foreach (var Question in Questions)
            {
                int index = 0;

                string gridXaml = XamlWriter.Save((Grid)MainWrap.Children[0]);
                StringReader stringReader = new StringReader(gridXaml);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Grid newGrid = (Grid)XamlReader.Load(xmlReader);
                newGrid.Visibility = Visibility.Visible;

                ((TextBlock)newGrid.Children[0]).Text = Question.Quest_Description;
                
                foreach (var option in Question.Quest_Option)
                {
                    if (index++ < 2)
                    {
                      ((RadioButton)newGrid.Children[index]).Content = option.Option_Name;
                        ((RadioButton)newGrid.Children[index]).GroupName = Question.Quest_ID.ToString();

                        if (Question.Quest_Answer == index)
                            ((RadioButton)newGrid.Children[index]).IsChecked = true;

                        continue;
                    }

                    newGrid.RowDefinitions.Add(new RowDefinition());
                  
                    string gridXaml2 = XamlWriter.Save((RadioButton)newGrid.Children[1]);
                    StringReader stringReader2 = new StringReader(gridXaml2);
                    XmlReader xmlReader2 = XmlReader.Create(stringReader2);
                    RadioButton newRadio = (RadioButton)XamlReader.Load(xmlReader2);
                    newRadio.Content = option.Option_Name;
                    newRadio.GroupName = Question.Quest_ID.ToString();
                    newRadio.IsChecked = false;

                    newGrid.Children.Add(newRadio);
                    Grid.SetRow(newRadio,index);

                    if (Question.Quest_Answer == index)
                          newRadio.IsChecked = true;
                }
                if (Question.Quest_Option.Count == 0)
                {
                    ((RadioButton)newGrid.Children[1]).GroupName = Question.Quest_ID.ToString();
                    ((RadioButton)newGrid.Children[2]).GroupName = Question.Quest_ID.ToString();

                    /// For instructor // To check correct answer for T/F Questions
                    if (Question.Quest_Answer == 1)
                        ((RadioButton)newGrid.Children[1]).IsChecked = true;
                    else
                        ((RadioButton)newGrid.Children[2]).IsChecked = true;

                }
                else 
                  ((RadioButton)newGrid.Children[(int)Question.Quest_Answer]).IsChecked = true;
                MainWrap.Children.Add(newGrid);
            }

              SumbitBtn.Content = "Back";
            }
            //Student section
            else
            {
                using (var DataT = new Examination_SystemEntities())
                {

                     var Ques = DataT.get_questuin_options(id);// For student
                    //var Ques = DataT.ExamWithCorrectAnswers(id);// For Imnstructor
                    Questions = new List<Question>();
                    foreach (var ques in Ques)
                    {
                        if (Questions?.LastOrDefault()?.Quest_ID == ques.question_id)
                            Questions.LastOrDefault().Quest_Option.Add(new Quest_Option() { Option_Name = ques.question_option });
                        else
                        {
                            Questions.Add(new Question() { Quest_ID = (int)ques.question_id, Quest_Description = (string)ques.question_description});
                            if (ques.question_option != null)
                            {
                                Questions.Last().Quest_Option = new List<Quest_Option>();
                                Questions.LastOrDefault().Quest_Option?.Add(new Quest_Option() { Option_Name = ques.question_option });
                            }

                        }
                    }
                }
                int current = 0;
                foreach (var Question in Questions)
                {
                    int index = 0;

                    string gridXaml = XamlWriter.Save((Grid)MainWrap.Children[0]);
                    StringReader stringReader = new StringReader(gridXaml);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    Grid newGrid = (Grid)XamlReader.Load(xmlReader);
                    newGrid.Visibility = Visibility.Visible;

                    ((TextBlock)newGrid.Children[0]).Text = Question.Quest_Description;
                   
                    foreach (var option in Question.Quest_Option)
                    {
                        if (index++ < 2)
                        {
                            ((RadioButton)newGrid.Children[index]).Content = option.Option_Name;
                            ((RadioButton)newGrid.Children[index]).GroupName = Question.Quest_ID.ToString();
                            ((RadioButton)newGrid.Children[index]).Checked += (sender, e)=>{
                                RadioButton item = sender as RadioButton;
                                var parent = item.Parent as Grid;
                                var selectionIndex= parent.Children.IndexOf(item);
                                var parentOfParent = parent.Parent as WrapPanel;
                                var QuestionIndex= parentOfParent.Children.IndexOf(parent)-1;
                                StudenAnswers[QuestionIndex] = selectionIndex;


                            };

                            continue;
                        }

                        newGrid.RowDefinitions.Add(new RowDefinition());

                        string gridXaml2 = XamlWriter.Save((RadioButton)newGrid.Children[1]);
                        StringReader stringReader2 = new StringReader(gridXaml2);
                        XmlReader xmlReader2 = XmlReader.Create(stringReader2);
                        RadioButton newRadio = (RadioButton)XamlReader.Load(xmlReader2);
                        newRadio.Content = option.Option_Name;
                        newRadio.GroupName = Question.Quest_ID.ToString();

                        newRadio.Checked += (sender, e) => {
                            RadioButton item = sender as RadioButton;
                            var parent = item.Parent as Grid;
                            var selectionIndex = parent.Children.IndexOf(item);
                            var parentOfParent = parent.Parent as WrapPanel;
                            var QuestionIndex = parentOfParent.Children.IndexOf(parent)-1 ;
                            StudenAnswers[QuestionIndex] = selectionIndex;

                        };
                        newGrid.Children.Add(newRadio);
                        Grid.SetRow(newRadio, index);
                    }
                    if (Question.Quest_Option.Count == 0)
                    {
                        ((RadioButton)newGrid.Children[1]).GroupName = Question.Quest_ID.ToString();
                        ((RadioButton)newGrid.Children[2]).GroupName = Question.Quest_ID.ToString();
                        ((RadioButton)newGrid.Children[1]).Checked += (sender, e) => {
                            RadioButton item = sender as RadioButton;
                            var parent = item.Parent as Grid;
                            var parentOfParent = parent.Parent as WrapPanel;
                            var QuestionIndex = parentOfParent.Children.IndexOf(parent)-1 ;
                            StudenAnswers[QuestionIndex] = 0;

                        };
                        ((RadioButton)newGrid.Children[2]).Checked += (sender, e) => {
                            RadioButton item = sender as RadioButton;
                            var parent = item.Parent as Grid;
                            var parentOfParent = parent.Parent as WrapPanel;
                            var QuestionIndex = parentOfParent.Children.IndexOf(parent)-1 ;
                            StudenAnswers[QuestionIndex] = 1;
                        };
                    }
                    MainWrap.Children.Add(newGrid);
                    current++;

                }


                SumbitBtn.Content = "Sumbit";
                SumbitBtn.Click += SumbitBtn_Click;

            }
        }


        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void SumbitBtn_Click(object sender, RoutedEventArgs e)
        {

            using(var DataT = new Examination_SystemEntities())
            {
                
             DataT.Exam_Answers(id,SystemUser.id,StudenAnswers[0], StudenAnswers[1], StudenAnswers[2], StudenAnswers[3], StudenAnswers[4], StudenAnswers[5], StudenAnswers[6], StudenAnswers[7], StudenAnswers[8], StudenAnswers[9]);

             DataT.Correct_Exam(id, SystemUser.id);
            
            }
            this.Close();

        }
    }
}
