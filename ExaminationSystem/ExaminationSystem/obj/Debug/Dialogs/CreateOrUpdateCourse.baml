   M S B A M L   `   `   `  ����L  HExaminationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ExaminationSystemExaminationSystem  5   	   ,    &ExaminationSystem.CreateOrUpdateCourse   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ExaminationSystem     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   
   Ghc19http://schemas.microsoft.com/netfx/2009/xaml/presentation    6=     � Title$  CreateOrUpdateCourse��5	      $	��450��6%   $	��800��62    � AllowsTransparency .  � WindowStyle$
 None=�6X    � WindowStartupLocation$ CenterScreen=�6k   .��5      � .+�5   
   �� -   5        $��X��5      $��50��6   $��Right=�6(   $	��Top=�6D   $��2,2,2,2q�6]   6x   �� 5   
   ���#4A148C$
��Left=�6#   $	��450��6>   $	��Top=�6K   $��178.795��6c   � 5   
   -   5         �Name$ Basic_Details��5      $
��Left=�6&   $	��450��6A   $��178.795,0,0,0q�6N   $	��Top=�6e   $��621.205��6}    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5      T� 5      5      .+�5      �� $
��Left=�6   $��27.268��63   $��28.125,50,0,30q�6C   $
��Wrap=�6[   $��Course��6o   $	��Top=�6}   $��562.5��6�   $��30(�6�   $��	Open Sans)�6�   ���#4A148C6�   #  HandyControl.Controls.TextBox  5      -   5        $��txtcourseName��5   �   ���#4A148C'  !HandyControl.Controls.InfoElement   Placeholder$ Course Name��6/   $
��Left=�6X   $��35��6t   $��27.205,110,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��266��6�   6�     5      -   5        $��txtDuration��5   �   ���#4A148C$ Duration��6/   $
��Left=�6U   $��35��6p   $��315.205,110,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $	��266��6�   6�     5      -   5        $��	txtTopics��5   �   ���#4A148C$ Topics��6/   $
��Left=�6S   $��65��6n   $��
25,150,0,0q�6z   $
 Wrap=�6�   $	��Top=�6�   $	��266��6�   (  "HandyControl.Controls.TitleElement   Title$ Topics��6�   $  HandyControl.Controls.ComboBox  5      -   5        $��ComboInstructor��5   B   ���#4A148C	 �� Text$	 
Instructor��60   
 �� StaysOpenOnEdit
 .  �� 
IsEditable .  �� IsTextSearchEnabled .    SelectionBrush �#4A148C$ 
Instructor��6  $��25,240,331,0q�63  ��5       �� 5!      .R�5"      �� $��chkInstructor��6#   -   5        ��5"   Z   �� *
Instr_Name+��6y   ��  �� Path$ 	IsChecked� �� RelativeSource �� *Self+5$      5%      5'        5(      -   5        $��ComboDepartment��5(   6  $	 
Department��6   
 .  .  . ���#4A148C �#4A148C$ 
Department��6�   $��315,161,39,161q�6  ��5)      �� 5*      .R�5+      �� $��chkDepartment��6#   -	   5        ��5+   Y   �� *	Dept_Name+��6w   �� $ 	IsChecked� �� *Self+5-      5.      50      �� 5?      -
   5        $��btnAdd��5?   �   $	��Add��6   $	��100��6#   $
��Left=�6/   $��491,360,0,58q�6J   $��2,2,2,2q�6x   6�   5@      5B      5C      