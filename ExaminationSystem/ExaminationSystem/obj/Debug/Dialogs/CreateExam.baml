   M S B A M L   `   `   `  ����L  HExaminationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ExaminationSystem.DialogsExaminationSystem.Dialogs  5   	   *    $ExaminationSystem.Dialogs.CreateExam   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ExaminationSystem.Dialogs     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   Ghc19http://schemas.microsoft.com/netfx/2009/xaml/presentation    6<     � Title$  Create Exam��5	   
   $	��450��6   $	��800��6+    � AllowsTransparency .  � WindowStyle$
 None=�6Q    � WindowStartupLocation$ CenterScreen=�6d   .��5      � .+�5   
   �� -   5        $��X��5      $��50��6   $��Right=�6(   $	��Top=�6D   $��2,2,2,2q�6]   6x   �� 5   
   ���#4A148C$
��Left=�6#   $	��450��6>   $	��Top=�6K   $��178.795��6c   � 5   
   -   5         �Name$ Basic_Details��5      $
��Left=�6&   $	��450��6A   $��178.795,0,0,0q�6N   $	��Top=�6e   $��621.205��6}    J� RenderTransformOrigin$ 0.5,0.5&�6�   .+�5      �� $
��Left=�6   $��27.268��63   $��28.125,50,0,30q�6C   $
��Wrap=�6[   $
��Exam��6o   $	��Top=�6{   $	��562��6�   $��30(�6�   $��	Open Sans)�6�   ���#4A148C6�   $  HandyControl.Controls.ComboBox  5      -   5        $��comboBoxExam��5       �� SelectedIndex$ 0��6/      SelectionBrush �#4A148C���#4A148C(  "HandyControl.Controls.TitleElement   Title$ 
CourseName��6y   $��27.205,110,0,0q�6�   	 �� Text$	 Course Name��6�   $	��266��6�   $
��Left=�6�   5      #  HandyControl.Controls.TextBox  5      -   5        
  Name$
 
textBoxMcq��5      '  !HandyControl.Controls.InfoElement   Placeholder$ Ques MCQ No��6-   $
��Left=�6V   $��35��6q   $��27.205,190,0,0q�6}    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��266��6�   ���#4A148C �� SelectionBrush �#4A148C6�     5      -   5        $
 	textBoxTF��5      $ Ques T/F No��6,   $
��Left=�6U   $��35��6p   $��27.205,240,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $	��266��6�   ���#4A148C6�   �� 5      -   5        $	��Add��5      $	��100��6#   $��28.125,200,100,100q�60   $��Bottom=�6L   ���	#FF673AB7$��2,2,2,2q�6   ���	#FFF8F6F66�   5      5      5      