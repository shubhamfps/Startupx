   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Startupx.HumanResourceModuleStartupx.HumanResourceModule  5   	   7    1Startupx.HumanResourceModule.HumanResourceCapital   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Startupx.HumanResourceModule     5   	     � Title$  HumanResourceCapital��5   	   $��646.8��6&   $	��950��65    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5       6   �� 5!      6   �� 5"      6   �� 5#      6   �� 5$      6   .+�5(   
   �� $��/Images/logo.png��6   $��0��6*   $��4��6:   $
��Left=�6K   $	��155��6f   $��
-53,13,0,0q�6s   $	��Top=�6�   $	��319��6�    J� RenderTransformOrigin$ 0.523,0.395&�6�   $��2��6�   $��1��6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-       �� Angle$ -90.062Q�6&   T� 5.       T� X$ -45.055Q�6)   	 T� Y$	 32.479Q�65   5/      51      �� 54   
   $��1��6   $��1��6%   $��2��62   $	��Top=�6C   $
��Left=�6[   $	��126��6v   $	��100��6�   $��0.4,69.6,0,0q�6�   .+�55      �� -   5        
 ��Name$
 
bt_capital��55      $��Human Capital��6)      	sidebar_b#��[  6A   $��	-24,0,0,0q�6}   �� 56      -   5        $
 bt_payroll_list��56      $��Payroll��6.   #��[  6@   $ 0.492,0.701&�6c   $��30��6�   6�   �� 57      -   5        $
 
bt_Reports��57      $��Reports��6)   #��[  6;   $ 0.468,1.413&�6^   $��45��6�   6�   58      �� 5<   
   $��2��6   $��2��6    $��Human Resource Module��64    	 title#��[ 6U   $	��303��6t   $
��Left=�6�   �� 5?   
   $��2��6   $��3��6%   $��Center=�69   $��33��6W   $��	0,55,50,0q�6c    �� Orientation$ 
Horizontal=�6w   $	��Top=�6�   $	��358��6�   .+�5@      �� -   5         ��Name$ 
txt_search��5@      $	��300��6+   $��0,0,0,1q�67   $��Center=�6R   �� 5A      -   5          search_b#��[ 5A      ��5B      �� 5C       �� ImageSource$ /images/search.png��6!    j� Stretch$
 Fill=�6B   5E      5F      �� 5I   
   $��5��6   $��39��6&   $ 
Horizontal=�62   $��0.267,102,11.067,0q�6K   $��Center=�6g   $	��146��6�   $	��Top=�6�   $��2��6�   .+�5J      �� -   5        $
 InsertEmployeeAction��5J   I    
 menu_b#��[ 6   $��
0,0,10,0.2q�65   ��5K      �� 5L      $ /images/add.png��6"   $
 Fill=�6@   5N      �� 5O      -   5        #��[ 5O      ��5P      �� 5Q      $ /images/print.png��6!   $
 Fill=�6A   5S      �� 5T      -   5        $
 bt_refresh_view��5T      $�� ��6.   #��[ 69    � ToolTip$ Refresh View��6w   ��5U      �� 5V      $+ %/Startupx;component/Images/update.png��6!   5X      5Y      �� 5\   
   -	   5         ��Name$ sp_table_container��5\      $��1��61   $��1��6>   $��4��6N   $��5��6_   $��100.4,69.6,20.067,7.6q�6s   
�������$	��650��6�   $	��328��6�   .+�5^      &   System.Windows.Controls.DataGrid  -
   5          Name$ dg_hr_information��5^         
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6D      AutoGenerateColumns .     CanUserAddRows .     Columns 5_      0  *System.Windows.Controls.DataGridTextColumn  5`      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Id��6@      Width$ * 6U      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id+6_     5a      $
 Name��6F   $ * 6T    6)   �� *
FullName+6T     5b      $ Gender��6D   $ * 6T    6)   �� *Gender+6T     5c      $ 
Department��6H   $ * 6\    6)   �� *
Department+6\     5d      $ 	Job Title��6F   $ * 6Y    6)   �� *
JobTitle+6Y     5e      $ 
Department��6C   $ * 6W    6)   �� *Phone+6W     5f      $ Address��6E   $ * 6V    6)   �� *	Address+6V     5g      $ 	City Name��6B   $ * 6U    6)   �� *City+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5i      $ Update��6-   $ 40 6=      CanUserResize .     CellTemplate 5j      �� 5k      .R�5l   "   �� -   5        #��[ 5l   )   $��20��6a   $��20��6l   ��5m   &   �� 5n   *   $ /images/edit.png��65   $
 Fill=�6T   5p   #   5q      5s        5u      $ Delete��6-   $ 40 6=    .   5v      �� 5w      .R�5x   "   �� -   5        #��[ 5x   )   $��20��6a   $��20��6l   ��5y   &   �� 5z   *   $ /images/delete.png��65   $
 Fill=�6V   5|   #   5}      5        5�      $ Payroll��6-   $ 40 6>    .   5�      �� 5�      .R�5�   "   �� -   5        #��[ 5�   )   $��20��6b   $��20��6m   ��5�   &   �� 5�   *   $ /images/payroll.png��65   $
 Fill=�6W   5�   #   5�      5�      5�      5�      �� 5�   
   $!��/Images/background_path.png��6   $��4��65   $��6��6B   $��2��6V   $��0,80,0,0q�6g   $	��130��6y   $
��Fill=�6�   $��Bottom=�6�   5�      5�      