   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Startupx.WarehouseModuleStartupx.WarehouseModule  5   	   !    Startupx.WarehouseModule.BT   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Startupx.WarehouseModule     5   	     � Title$  BT��5   	   $	��450��6   $	��800��6!    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5   
   �� $��/Images/logo.png��6   $��0��6*   $
��Left=�6:   $	��102��6U   $��-19,101,0,0q�6b   $	��Top=�6w   $	��245��6�    J� RenderTransformOrigin$ 0.523,0.395&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -90.062Q�6&   T� 5       T� X$ -45.055Q�6)    T� Y$ 32.479Q�65   5      5      &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dg_selected_items��5!      	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  $
��Left=�6�   $	��140��6�   $��
281,96,0,0q�6�   $	��Top=�6�   $	��293��6�      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Barcode��6A      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	barcode+6\     5$      $
 Name��6>   $ * 6L    .  6%   �� *name+6V     5%      $ Price��6]   $ * 6l    .  6%   �� *price+ �� UpdateSourceTrigger$ 	LostFocus=�6v     5&      $	 Qnt��6&   $ * 63   5(      �� 5*   
   -   5         ��Name$ img_barcode��5*      $
��Left=�6%   $��49��6@   $��
122,84,0,0q�6L   $	��Top=�6`   $	��135��6x   �� 5+   
   -   5         ��Name$ 
lb_barcode��5+      $
��Code��6$   $
��Left=�63   $��123,138,0,0q�6N   $	��Top=�6c   $	��113��6{   $
��Bold"�6�   �� 5.   
   $��Center=�6   $��33��63   $��285,40,150.6,0q�6?    �� Orientation$ 
Horizontal=�6X   $	��Top=�6q   $	��358��6�   .+�5/      �� -   5         ��Name$ 
txt_search��5/      $	��300��6+   $��0,0,0,1q�67   $��Center=�6R   �� 50      -   5           search_b#��[  50      $��	0,4,0,4.8q�6P   $
��Auto��6c   $ 1.983,0.458&�6q   ��51      �� 52       �� ImageSource$" /images/add item invoice.png��6!    j� Stretch$
 Fill=�6L   54      55      �� 58   
   $!��/Images/background_path.png��6   $��4��65   $��6��6B   $��2��6V   $	��130��6g   $
��Fill=�6t   $��Bottom=�6�   �� 59   
   $��Cancel��6   $
��Left=�6"   $��360,244,0,0q�6=   $	��Top=�6R   $��70��6j   $��43��6u   ���	#FF458CA2
�������$
��Bold"�6�   �� 5:   
   -   5        $��CHECKOUT��5:      $
��Left=�6$   $��440,244,0,0q�6?   $	��Top=�6T   $	��133��6l   $��43��6x   $ 0.5,0.5&�6�   ���	#FFE6821F
�������$��20(�6�   $
��Bold"�6�   �� 5;   
   -   5        $	��New��5;      $
��Left=�6   $��282,244,0,0q�6:   $	��Top=�6O   $��70��6g   $��43��6r   ���	#FF458CA2
�������$
��Bold"�6�   6�   �� 5<   
   -   5        $��lb_total��5<      $��Total��6    $
��Left=�60   $��
609,97,0,0q�6K   $	��Top=�6_   $	��100��6w   $	��161��6�   ���	#FF458CA2
�������$��48(�6�   $
��Bold"�6�   �� 5=   
   $	��14%��6   $
��Left=�6   $��609,196,3,0q�69   $	��Top=�6N   $��35��6f   $	��161��6r   ���	#FF113B42
�������$��20(�6�   $
��Bold"�6�   5>      5?      