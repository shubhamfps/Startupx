   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Startupx.WarehouseModuleStartupx.WarehouseModule  5   	   +    %Startupx.WarehouseModule.Add_Category   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Startupx.WarehouseModule     5   	     � Title$  Add_Category��5   	   $��466.335��6   $��496.583��6/    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5   
   �� $��ADD CATEGORY��6   $
��Left=�6'   $��
154,13,0,0q�6B   $	��Top=�6V   $
��Bold"�6n   $��18(�6�   �� 5   
   $
��Name��6   $
��Left=�6   $��	25,90,0,0q�6:   $	��Top=�6M   �� 5   
   -   5         ��Name$ txt_category��5      $
��Left=�6(   $��34��6C   $��	71,88,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��144��6�   �� 5   
   $��Prefix��6   $
��Left=�6!   $��
223,89,0,0q�6<   $	��Top=�6P   $��30��6h   �� 5    
   -   5        $ 
txt_prefix��5       $
��Left=�6&   $��34��6A   $��
268,88,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $��67��6�   �� 5#   
   -   5        $��Add Category��5#      $
��Left=�6(   $��
339,88,0,0q�6C   $	��Top=�6W   $	��115��6o   $��34��6{   ���#458ca2$
��Bold"�6�   
�������6�   �� 5&   
   $��Center=�6   $��28��62   $��130,146,129.4,0q�6>    �� Orientation$ 
Horizontal=�6X   $	��Top=�6q   $	��231��6�   .+�5'      �� -   5        $ 
txt_search��5'      $	��200��6*   $��2,0,0,0q�66   $��0,0,0,1q�6G   $��Right=�6a   �� 5(      -   5           search_b#��[  5(      $��0,4,0,3q�67   $��20��6H   $
��Auto��6S   	 J� RenderTransformOrigin$	 	0.5,0.505&�6a   ��5)      �� 5*      
 �� ImageSource$
 /images/search.png��6!    j� Stretch$
 Fill=�6B   5,      5-      �� 50   
   -   5        $�� ��50       
 menu_b#��[ 6   $
��Left=�6<   $��427,195,0,0q�6W   $	��Top=�6l   $��24��6�   $��24��6�   ��51      �� 52      $+
 %/Startupx;component/Images/update.png��6   54      &   System.Windows.Controls.DataGrid  57   
   -   5          Name$ dg_categories��57      $
��Left=�6*   $	��179��6E   $��
32,233,0,0q�6R   $	��Top=�6f   $	��427��6~      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 58         AutoGenerateColumns .     CanUserAddRows .     Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Category Id��6<      Width$ * 6Q      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6[     5;      $ Category Name��6G   $ * 6^    6%   �� *category_name+6^     5<      $ Prefix��6G   $ * 6W    6%   �� *category_pref+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Update��6)   $ 60 69      CanUserResize .     CellTemplate 5?      �� 5@      .R�5A      �� -   5        #��[ 5A   %   $��20��6]   $��20��6h   ��5B   "   �� 5C   &   $
 /images/edit.png��61   $
 Fill=�6P   5E      5F      5H        5J      $ Delete��6)   $ 60 69    .   5K      �� 5L      .R�5M      �� -	   5        #��[ 5M   %   $��20��6]   $��20��6h   ��5N   "   �� 5O   &   $
 /images/delete.png��61   $
 Fill=�6R   5Q      5R      5T      5V      5Z      5[      