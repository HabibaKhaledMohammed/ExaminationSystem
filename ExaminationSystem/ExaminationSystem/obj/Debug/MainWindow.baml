   M S B A M L   `   `   `  ����L  HExaminationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ExaminationSystemExaminationSystem  5   	   "    ExaminationSystem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ExaminationSystem     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  67   -   5          � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)    � WindowStyle$
 None=�5	   
    � AllowsTransparency .  � WindowState$ 	Maximized=�6O   .��5
      #  MaterialDesignThemes.Wpf.Card  $��10q�6      UniformCornerRadius$ 15Q�6&   .��5   
   �  � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $	��18* �6#    � 	Resources 5      '  !MaterialDesignThemes.Wpf.PackIcon �� 
TargetType �� Property	 �� Value��%�   '        �� 5      "  6   .�5      ��  � ��$	 30��6.   6;   �� 5       � ��$	 30��6/   6<   5      5      .+�5      � $��0��6   $��2��6#   $��	0,0,900,0q�67    5      �� 5      $��1* �6'   .+�5      �� $
��Left=�6   $��91��66   .@�5      �� $��Center=�6#   $
��0 10q�6@   .��5      ��  &  "MaterialDesignFloatingActionButton#��[  6!   $
��Left=�6]   
���   ���5      Z� ��65   Z� .��5      �� $��-5q�6)   .+�5   "     
   Kind$
 Resistor=�6:   5       5!      5"      �� 5#      $��Center=�6#   $��0q�6@   .��5$      �� #��[  6!   $
��Left=�6]   
���   ���5%      Z� ��65   Z� .��5&      �� $��-5q�6)   .+�5'   "     $
 CircleSlice6=�6:   5(      5)      5*      �� 5+      $��Center=�6#   $
��0 10q�6@   .��5,      �� #��[  6!   $
��Left=�6]   
���   ���5-      Z� ��65   Z� .��5.      �� $��-5q�6)   .+�5/   "     $
 CalendarBlankOutline=�6:   50      51      52      �� 53      $��Center=�6#   $��0q�6@   .��54      �� #��[  6!   $
��Left=�6]   
���   ���55      Z� ��65   Z� .��56      �� $��-5q�6)   .+�57   "     $
 EqualiserVertical=�6:   58      59      5:      �� 5;      $��Center=�6#   $
��0 10q�6@   .��5<      �� #��[  6!   $
��Left=�6]   
���   ���5=      Z� ��65   Z� .��5>      �� $��-5q�6)   .+�5?   "     $
 ChatOutline=�6:   5@      5A      5B      �� 5C      $��Center=�6#   $��0 60 0 0q�6@   .��5D      �� -   5         ��Name$ btnExit��5E   ^   #��[  5D   !   $
��Left=�6]   
���   ���5E      Z� ��65   Z� .��5F      �� $��-5q�6)   .+�5G   "     $
 	ExitToApp=�6:   5H      5I      5J      5K      5L      � 5M      $��1��6   ���#F6F5F8$��2,0,0,0q�69    5N      �� 5O      $��* �6'   .+�5Q      �� $��1��6   $
��Auto=�60     MaterialDesignScrollViewer#���  6S   .��5R      � -   5         �Name$ RenderPages��5R      $	��Top=�64    5S      �� 5T      $��* �6/   5W      5X      5Z      5[      5\      5]      