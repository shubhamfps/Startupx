   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Startupx.AdminModuleStartupx.AdminModule  5   	   #    Startupx.AdminModule.Add_user   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Startupx.AdminModule     5   	     � Title$  Add_user��5   	   $��460.296��6   $��461.009��6+    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ txt_username��5      $
��Left=�6(   $��23��6C   $��
138,96,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��239��6�   �� 5   
   -   5         ��Name$ cb_employees��5      $
��Left=�6)   $��139,161,0,0q�6D   $	��Top=�6Y   $	��239��6q   G� 5   
   -   5         G�Name$ txt_password��5      $
��Left=�6,   $��23��6G   $��138,128,0,0q�6S   $	��Top=�6i   $	��239��6�   �� 5   
   $��Username��6   $
��Left=�6#   $��	69,93,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Password��6   $
��Left=�6#   $��
70,128,0,0q�6>   $	��Top=�6R   �� 5   
   $��Employee��6   $
��Left=�6#   $��
71,160,0,0q�6>   $	��Top=�6R   �� 5   
   $
��Left=�6   $��57��6+   $��
205,17,0,0q�67   $	��Top=�6K   $��64��6c   $)��#/Startupx;component/Images/user.png��6n   �� 5   
   -   5        $��Add user��5      $
��Left=�6$   $��139,197,0,0q�6?   $	��Top=�6T   $	��239��6l   $��34��6x   ���	#FF458CA2
�������$
��Bold"�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_users��5         AutoGenerateColumns .  	   CanUserAddRows	 .  
   
IsReadOnly
 . $
��Left=�6j   $	��174��6�   $��
13,244,0,0q�6�   $	��Top=�6�   $	��430��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Username��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Username+6^     5      $ Employee��6B   $ * 6T    6%   �� *
Employee+6T   5      5      5      