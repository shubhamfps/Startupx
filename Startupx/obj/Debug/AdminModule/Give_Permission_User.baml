   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Startupx.AdminModuleStartupx.AdminModule  5   	   /    )Startupx.AdminModule.Give_Permission_User   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Startupx.AdminModule     5   	     � Title$  Give_Permission_User��5   	   $��441.45��6&   $��503.471��66    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5         ��Name$ cb_permissions��5      $
��Left=�6+   $��
88,171,0,0q�6F   $	��Top=�6Z   $	��210��6r   $��30��6~   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_permission��5         CanUserAddRows .  	   AutoGenerateColumns	 .  
   
IsReadOnly
 . $
��Left=�6o   $	��146��6�   $��
88,209,0,0q�6�   $	��Top=�6�   $	��329��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Description��6E      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Description+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Delete��6)   $ 60 69      CanUserResize .     CellTemplate 5      �� 5      .R�5      �� -   5         
  menu_b#��[  5   %   $��20��6_   $��20��6j   ��5   "   �� 5   &    �� ImageSource$ /images/delete.png��61    j� Stretch$
 Fill=�6R   5!      5"      5$      5(      �� 5*   
   -   5        $��Add Permission��5*      $
��Left=�6*   $��302,171,0,0q�6E   $	��Top=�6Z   $	��114��6r   $��31��6~   ���	#FF458CA2
�������$��13(�6�   $
��Bold"�6�   6�   �� 5+   
   $
��Left=�6   $��87��6+   $��
193,22,0,0q�67   $	��Top=�6K   $	��107��6c   $4��./Startupx;component/Images/user_permission.png��6o   �� 5,   
   -   5         ��Name$ lb_user��5,      $
��USER��6!   $
��Left=�60   $��155,140,0,0q�6K   $	��Top=�6`   $	��173��6x   $
��Bold"�6�   $��Center=�6�   ���	#FFDD5D156�   5.      5/      