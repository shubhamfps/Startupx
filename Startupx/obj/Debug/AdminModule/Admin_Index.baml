   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Startupx.AdminModuleStartupx.AdminModule  5   	   &     Startupx.AdminModule.Admin_Index   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Startupx.AdminModule     5   	     � Title$  Admin_Index��5   	   $��646.8��6   $	��950��6,    � WindowStartupLocation$ CenterScreen=�68    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5       6   �� 5!      6   �� 5"      6   �� 5#      6   .+�5'   
   �� $��/Images/logo.png��6   $��0��6*   $��4��6:   $
��Left=�6K   $	��155��6f   $��
-53,13,0,0q�6s   $	��Top=�6�   $	��319��6�    J� RenderTransformOrigin$ 0.523,0.395&�6�   $��2��6�   $��1��6�   z�5(      V� 5)      .~�5*      �� �� 5+      �� 5,       �� Angle$ -90.062Q�6&   T� 5-      	 T� X$	 -45.055Q�6)   
 T� Y$
 32.479Q�65   5.      50      �� 53   
   $��1��6   $��1��6%   $��3��62   $	��Top=�6C   $
��Left=�6[   $	��400��6v   $	��100��6�   $��0,70,0,0q�6�   .+�54      �� -   5         ��Name$ bt_Products��54      $��Users��6*      	sidebar_b#��[  6:   6]   �� 55      -   5        $ bt_Categories��55      $��Permissions��6,   #��[  6B   6e   57      �� 5:   
   $��2��6   $��3��6    $��Administration Module��64    	 title#��[ 6U   $	��303��6t   $
��Left=�6�   �� 5=   
   $��2��6   $��3��6%   $��Center=�69   $��33��6W   $��	0,55,50,0q�6c    �� Orientation$ 
Horizontal=�6w   $	��Top=�6�   $	��358��6�   .+�5>      �� -   5         ��Name$ 
txt_search��5>      $	��300��6+   $��0,0,0,1q�67   $��Center=�6R   �� 5?      -   5          search_b#��[ 5?      ��5@      �� 5A       �� ImageSource$ /images/search.png��6!    j� Stretch$
 Fill=�6B   5C      5D      �� 5G   
   $��4��6   $��3��6&   $��	100,0,0,0q�6:   $��39��6M   $ 
Horizontal=�6Y   $��Center=�6r   $	��150��6�   $��1��6�   $	��Top=�6�   .+�5H      �� -   5         
 menu_b#��[ 5H       � ToolTip$ Add user��6F   $��
0,0,10,0.2q�6Y   ��5I      �� 5J      $ /images/add.png��6"   $
 Fill=�6@   5L      �� 5M      -   5        #��[ 5M      $ Print report��65   ��5N      �� 5O      $ /images/print.png��6!   $
 Fill=�6A   5Q      �� 5S      -   5        $�� ��5S      #��[ 6    $ Refresh View��6U   $��
0,0,10,0.2q�6l   ��5T      �� 5U      $+ %/Startupx;component/Images/update.png��6!   5W      5X      �� 5[   
   -   5         ��Name$ sp_table_container��5[      $��1��61   $��1��6>   $��4��6N   $��5��6_   $��115,70,20,20q�6s   
�������$	��650��6�   $	��328��6�   .+�5\      &   System.Windows.Controls.DataGrid  -	   5          Name$ dg_users��5\         
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6<      AutoGenerateColumns .     CanUserAddRows .     Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6F      Width$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Username+6X     5_      $ Employee��6F   $ * 6X    6)   �� *
Employee+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5a      $ Delete��6-   $ 60 6=      CanUserResize .     CellTemplate 5b      �� 5c      .R�5d   "   �� -
   5        #��[ 5d   )   $��20��6]   $��20��6h   ��5e   &   �� 5f   *   $ /images/delete.png��65   $
 Fill=�6V   5h   #   5i      5k        5m      $ 
Permission��6-   $ 70 6A    .   5n      �� 5o      .R�5p   "   �� -   5        #��[ 5p   )   $��20��6a   $��20��6l   ��5q   &   �� 5r   *   $ /images/permission.png��65   $
 Fill=�6Z   5t   #   5u      5w      5y      5z      �� 5~   
   $!��/Images/background_path.png��6   $��4��65   $��6��6B   $��2��6V   $	��130��6g   $
��Fill=�6t   $��Bottom=�6�   5�      5�      