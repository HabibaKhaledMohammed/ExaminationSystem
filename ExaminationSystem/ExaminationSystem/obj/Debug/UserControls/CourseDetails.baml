   M S B A M L   `   `   `  ����L  HExaminationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ExaminationSystem.UserControlsExaminationSystem.UserControls  5   	   2    ,ExaminationSystem.UserControls.CourseDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ExaminationSystem.UserControls     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6D   $
��1208��5        � 	Resources  5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid��%  '        '      �� 5	   
   "  6   .�5
      ��  � �� �	#ff2c3e506+   �� 5       � ��$ 30��6'   �� 5       � ��$ 12(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�69   �� 5       � ��
 �����6+   5      �� 5   
   "  6   .�5      ��  �@ VerticalGridLinesBrush �#4b658467   �� 5        �@ HorizontalGridLinesBrush �#4b658469   �� 5        �@ AlternatingRowBackground �	#ff2c3e5069   �� 5       �@ RowBackground �#34495e6.   �� 5       �@ 	RowHeight$ 25Q�6*   �� 5       �@ RowHeaderWidth$ 0Q�6/   �� 5       � ��
 �����6+   �� 5      # �@ VerticalScrollBarVisibility$ Hidden=�6<   5      5      .��5      �  � ColumnDefinitions 5    
   �� 5!      $��* �6     5#   
   '  !MaterialDesignThemes.Wpf.PackIcon��%�   '        �� 5$      "  6   .�5%      ��  � ��$ 30��6*   67   �� 5&       � ��$ 30��6+   68   5'      5(       � RowDefinitions 5)   
   �� 5*      $��* �6   �� 5+      $��* �6   .+�5-   
   � $��0��6   ���#F6F6F8$��1��64   .+�5.      �� $��10q�6   .+�5/      � $��60��6   .+�50      �� $
��Left=�6   ��51      Z� ��6-   Z� .��52      �� $��-5q�6%   .+�53        -   5           Kind$ 	ArrowLeft=�53   6   
�������6Y   54      55      �� 56      $��Right=�6   $	��100��6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Options��6G   $��0,0,0,30q�6r   .@�57      �� .��58      �� -   5        $��Update Course��58   (    �� TextAlignment$ Center=�6=   6T   59      5;      5<      #  MaterialDesignThemes.Wpf.Card  5=      $��10q�6&   	   UniformCornerRadius$	 20Q�62   $��10q�6K   ���#4A148C$
��1100��6m   .��5>      �� .+�5@      � $��50��6    5A      �� 5B   "    5D      �� 5F   "   .+�5H      �� $��Course Details��6(   $��0��6>   $��0��6N   
�������$��Center=�6n   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   5I      5J      5K        5L      $��10q�6&   $	 20Q�62   $��10q�6K   
�������$
��1100��6k   .��5M      �� .+�5O      �  5P      �� 5Q   "   $
��0.2* �63   �� 5R   "   $
��0.8* �63    5U      �� 5V   "   $��1* �60   �� 5W   "   $��1* �60   �� 5X   "   $��1* �60   .+�5[      �� $��Course Name: ��6(   $��0��6=   $��0��6M   
���   �$
��left=�6m   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
30 20 0 0 q�6�   �� 5\      -   5        
 ��Name$
 
courseName��5\   (   $��C#��6<   $��1��6F   $��0��6V   
���   �$
��left=�6v   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
20 20 0 0 q�6�   �� 5_      $��Course Duration: ��6(   $��0��6A   $��1��6Q   
���   �$
��left=�6q   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
30 20 0 0 q�6�   �� 5`      -   5        $
 crsDuration��5`   (   $��15 hour��6=   $��1��6L   $��1��6\   
���   �$
��left=�6|   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
20 20 0 0 q�6�   �� 5b      $��Department: ��6(   $��0��6<   $��2��6L   
���   �$
��left=�6l   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
30 20 0 0 q�6�   �� 5c      -   5        $
 crsDept��5c   (   $��SD��69   $��1��6C   $��2��6S   
���   �$
��left=�6s   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   $��
20 20 0 0 q�6�   5d      5e      5f        5g      $��40,5,0,5q�6&   $	 20Q�68   $��10q�6Q   ���#4A148C$	��200��6s   $
��left=�6   .��5h      �� .+�5j      � $��50��6    5k      �� 5l   "    5n      �� 5p   "   .+�5r      �� $��Instructors��6(   $��0��6;   $��0��6K   
�������$
��left=�6k   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   5s      5t      5u        5v      $��10q�6&   $	 20Q�62   $��10q�6K   
�������$
��1100��6k   .��5w      � -   5         �Name$ InstructorWrapper��5w   ,   $��10q�6    .+�5x      � $
��1100��6   ���#F3E5F5$��0,0,0,20q�6A    5y      �� 5z   "   $��0.25* �63   �� 5{   "   $��0.75* �63   .+�5}      �� $��Instructor Title��6(   $��0��6@   
���   �$
��Left=�6c   $��Center=�6~   $��25(�6�   $��SemiBold"�6�   $��
30,0, 0, 0q�6�   �� 5~      $
��Name��6(   $��1��64   
���   �$
��Left=�6X   $��Center=�6s   $��25(�6�   $��SemiBold"�6�   5      � 5�      $
��1100��6   $y�	Collapsed=�6,    5�      �� 5�   "   $��0.25* �63   �� 5�   "   $��0.75* �63   .+�5�      �� $��Main Instructor��6(   $��0��6?   
���   �$
��Left=�6b   $��Center=�6}   $��25(�6�   $��SemiBold"�6�   $��
30,0, 0, 0q�6�   �� 5�      $��Ahmed ��6(   $��1��66   
���   �$
��left=�6Z   $��Center=�6u   $��25(�6�   $��SemiBold"�6�   5�      5�      5�        5�      $��40,5,0,5q�6'   $	 20Q�69   $��10q�6R   ���#4A148C$	��200��6t   $
��left=�6�   .��5�      �� .+�5�      � $��50��6    5�      �� 5�   "    5�      �� 5�   "   .+�5�      �� $��Topics��6(   $��0��66   $��0��6F   
�������$
��left=�6f   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   5�      5�      5�        5�      $��10q�6&   $	 20Q�62   $��10q�6K   
�������$
��1100��6k   .��5�      �� .+�5�      � -   5        $��TopicsWrapper��5�   $   $
��Left=�69   .+�5�      �� ���#C51162���#C78585$
��50px��6Q   $��	10,0,10,0q�6_   $y�	Collapsed=�6r   .��6�   C#5�      5�      5�      5�        5�      -   5        $��
ExamHeader��5�   �   $	 20Q�6'   $��10q�6@   $
��1200��6M   
������ $
��left=�6s   .��5�      �  5�      �� 5�      $
��0.8* �6/   �� 5�      $
��0.2* �6/    5�      �� 5�      .+�5�        $��30,5,0,5q�6/   $	 20Q�6A   $��10q�6Z   ���#4A148C$	��200��6|   $
��left=�6�   $��0��6�   $��0��6�   .��5�      �  5�   "   �� 5�   &    5�   "   �� 5�   &   .+�5�   "   �� $��Exams��6,   $��0��69   $��0��6I   
�������$
��left=�6i   $��Center=�6�   $��25(�6�   $��SemiBold"�6�   5�      5�      �� 5�      -	   5        $��
createExam��5�   1   $��1��6!   $��0��6C   
����������#C78585���#4A148C$
��22px(�6�   $
��50px��6�   $��
23,0,50,10q�6�   $��Bottom=�6�   .��6�   Create Exam5�      5�      5�        5�      -
   5        $��ExamContent��5�   x   $��10q�6&   $	 20Q�62   $��10q�6K   
�������$
��1100��6k   .��5�      �� .+�5�      � -   5        $��ExamWrapper��5�   $   $
��Left=�67   .+�5�        $��10q�62   $	 20Q�6>   $��10q�6W   $	��200��6d   $y�	Collapsed=�6p   .��5�   "   � $	��150��6'    5�   &   �� 5�   *    5�   &   �� 5�   *   �� 5�   *   �� 5�   *   �� 5�   *   .+�5�   &   �� $
��Exam��60   $��0��6<   $��0��6L   $��Center=�6Y   $��Center=�6v   $��23(�6�   $��SemiBold"�6�   �� 5�   &   $��A��60   $��0��69   $��1��6I   $��Center=�6V   $��Center=�6s   $��23(�6�   $��SemiBold"�6�   �� 5�   &   $��2 Hours��60   $��0��6?   $��2��6O   $��Center=�6\   $��Center=�6y   $��13(�6�   $��SemiBold"�6�   �� 5�   &   -   5        $��0��5�   -   $��3��6=   ���#42A5F5���#C78585$��32��6u   $��0,2,0,0q�6�   $	��Top=�6�   .��6�   	View Exam5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      