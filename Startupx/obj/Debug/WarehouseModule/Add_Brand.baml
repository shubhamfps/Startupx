   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Startupx.WarehouseModuleStartupx.WarehouseModule  5   	   (    "Startupx.WarehouseModule.Add_Brand   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Startupx.WarehouseModule     5   	     � Title$  	Add_Brand��5   	   $��466.335��5	   	   $��496.583��6    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5   
   �� $��	ADD BRAND��6   $
��Left=�6$   $��
154,13,0,0q�6?   $	��Top=�6S   $
��Bold"�6k   $��18(�6}   �� 5   
   $
��Name��6   $
��Left=�6   $��	25,90,0,0q�6:   $	��Top=�6M   �� 5   
   -   5         ��Name$ 	txt_brand��5      $
��Left=�6%   $��34��6@   $��	71,88,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��265��6�   �� 5!   
   -   5        $��	Add Brand��5!      $
��Left=�6%   $��
339,88,0,0q�6@   $	��Top=�6T   $	��115��6l   $��34��6x   ���#458ca2$
��Bold"�6�   
�������6�   �� 5$   
   $��Center=�6   $��28��62   $��130,146,129.4,0q�6>    �� Orientation$ 
Horizontal=�6X   $	��Top=�6q   $	��231��6�   .+�5%      �� -   5        $ 
txt_search��5%      $	��200��6+   $��0,0,0,1q�67   $��2,0,0,0q�6Q   $��Right=�6b   �� 5&      -   5           search_b#��[  5&      $��0,4,0,0q�67   $��20��6H   $��21��6S   	 J� RenderTransformOrigin$	 0.5,0.5&�6_   $	��Top=�6   ��5'      �� 5(      
 �� ImageSource$
 /images/search.png��6!    j� Stretch$
 Fill=�6B   5*      5+      �� 5.   
   -   5        $�� ��5.       
 menu_b#��[ 6   $
��Left=�6<   $��427,195,0,0q�6W   $	��Top=�6l   $��24��6�   $��24��6�   ��5/      �� 50      $+
 %/Startupx;component/Images/update.png��6   52      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ dg_Brand��56      $
��Left=�6%   $	��179��6@   $��
32,233,0,0q�6M   $	��Top=�6a   $	��427��6y      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 57         AutoGenerateColumns .     CanUserAddRows .     Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ Brand Id��6<      Width$ * 6N      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6X     5:      $ 
Brand Name��6D   $ * 6X    6%   �� *
brand_name+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5<      $ Update��6)   $ 60 69      CanUserResize .     CellTemplate 5=      �� 5>      .R�5?      �� -   5        #��[ 5?   %   $��20��6Z   $��20��6e   ��5@   "   �� 5A   &   $
 /images/edit.png��61   $
 Fill=�6P   5C      5D      5F        5H      $ Delete��6)   $ 60 69    .   5I      �� 5J      .R�5K      �� -   5        #��[ 5K   %   $��20��6Z   $��20��6e   ��5L   "   �� 5M   &   $
 /images/delete.png��61   $
 Fill=�6R   5O      5P      5R      5T      5X      5Y      