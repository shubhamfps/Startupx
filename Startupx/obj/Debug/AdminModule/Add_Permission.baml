   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Startupx.AdminModuleStartupx.AdminModule  5   	   )    #Startupx.AdminModule.Add_Permission   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Startupx.AdminModule     5   	     � Title$  Add_Permission��5   	   $��353.586��6    $��433.264��61    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ txt_description��5      $
��Left=�6+   $��33��6F   $��
40,104,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��219��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_permissions��5   X      CanUserAddRows .     AutoGenerateColumns .     
IsReadOnly . $
��Left=�6p   $	��142��6�   $��
39,147,0,0q�6�   $	��Top=�6�   $	��348��6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6H      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+6R     5      $
 
Permission��6E   $ * 6Y    6%   �� *description+6Y   5      �� 5   
   $
��Left=�6   $��72��6+   $��
171,20,0,0q�67   $	��Top=�6K   $��89��6c   $0��*/Startupx;component/Images/permission2.png��6n   �� 5   
   -   5        $��Add Permission��5      $
��Left=�6*   $��264,104,0,0q�6E   $	��Top=�6Z   $	��118��6r   $��34��6~   ���	#FF458CA2
�������$
��Bold"�6�   $��13(�6�   6�   5      5      