   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Startupx.WarehouseModuleStartupx.WarehouseModule  5   	   '    !Startupx.WarehouseModule.Add_Item   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Startupx.WarehouseModule     5   	     � Title$  Add_Item��5   	   $��470.8��6   $	��540��6)    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5        $��lb_title��5      $��ADD ITEM��6    $
��Left=�63   $��
229,24,0,0q�6N   $	��Top=�6b   $
��Bold"�6z   $��18(�6�   �� 5   
   $
��Name��6   $
��Left=�6   $��	67,67,0,0q�6:   $	��Top=�6M   $��45��6e   $��27��6p    J� RenderTransformOrigin$ 0.302,-2.274&�6|   $��Right=�6�   �� 5   
   -   5         ��Name$ txt_productName��5      $
��Left=�6,   $��23��6G   $��
114,71,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��375��6�   	 � ToolTip$	 Product name��6�   �� 5   
   $��Description��6   $
��Left=�6&   $��
41,154,0,0q�6A   $	��Top=�6U   $��74��6m   $��27��6x   $ 0.302,-2.274&�6�   $��Right=�6�   �� 5   
   -   5        $ txt_description��5      $
 Wrap=�6+   "
 �� VerticalScrollBarVisibility$
 Visible=�6?   $��114,141,44.6,248.8q�6e   $	��375��6�   �� 5!   
   $��Price��6   $
��Left=�6    $��
63,107,0,0q�6;   $	��Top=�6O   $��45��6g   $��27��6r   $ 0.302,-2.274&�6~   $��Right=�6�   �� 5"   
   -   5        $ txt_productPrice��5"      $
��Left=�6,   $��23��6G   $��114,107,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $��87��6�   $	 Product price��6�   �� 5#   
   $	��CAD��6   $
��Left=�6   $��204,106,0,0q�69   $	��Top=�6N   $��34��6f   $��27��6q   $ 0.302,-2.274&�6}   �� 5%   
   $��Expiration date��6   $
��Left=�6*   $��256,106,0,0q�6E   $	��Top=�6Z   $��93��6r   $��27��6}   $ 0.302,-2.274&�6�   $��Right=�6�   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ dp_date��5&      $
��Left=�6&   $��353,107,0,0q�6A   $	��Top=�6V   $	��136��6n   �� 5(   
   $��Category��6   $
��Left=�6#   $��285,201,0,0q�6>   $	��Top=�6S   $��59��6k   $��26��6v   �� 5)   
   -   5         ��Name$ cb_category��5)      $
��Left=�6X   $��349,202,0,0q�6s   $	��Top=�6�   $	��109��6�   �� 5,   
   -   5        $�� ��5,       
  menu_b#��[  6   $
��Left=�6<   $��461,201,0,0q�6W   $	��Top=�6l   $��27��6�   $��24��6�   ��5-      �� 5.       �� ImageSource$( "/Startupx;component/Images/add.png��6   50      �� 52   
   $��Brand��6   $
��Left=�6    $��
64,200,0,0q�6;   $	��Top=�6O   $��45��6g   $��27��6r   $��Right=�6~   �� 53   
   -   5        $ cb_brand��53      $
��Left=�6%   $��114,202,0,0q�6@   $	��Top=�6U   $	��117��6m   �� 56   
   -	   5        $�� ��56      #��[  6   $
��Left=�6<   $��233,202,0,0q�6W   $	��Top=�6l   $��27��6�   $��24��6�   ��57      �� 58      $( "/Startupx;component/Images/add.png��6   5:      �� 5=   
   -
   5         ��Name$ img_barcode��5=      $
��Left=�6%   $��40��6@   $��224,245,0,0q�6L   $	��Top=�6a   $	��127��6y    J� OpacityMask �	#FFF7EDED6�   �� 5>   
   -   5         ��Name$ 
lb_barcode��5>      $��Bar code��6$   $
��Left=�67   $��226,286,0,0q�6R   $	��Top=�6g   $	��122��6   $
��Bold"�6�   $��Center=�6�   �� 5@   
   $��	Warehouse��6   $
��Left=�6$   $��
40,316,0,0q�6?   $	��Top=�6S   $��69��6k   $��27��6v   $��Right=�6�   �� 5A   
   -   5        $ cb_warehouse��5A      $
��Left=�6Z   $��114,321,0,0q�6u   $	��Top=�6�   $	��128��6�   $ 0.406,0.902&�6�   �� 5C   
   $��Section��6   $
��Left=�6"   $��273,320,0,0q�6=   $	��Top=�6R   $��49��6j   $��27��6u   �� 5D   
   -   5        $ 
cb_section��5D      $
��Left=�6(   $��327,321,0,0q�6C   $	��Top=�6X   $	��169��6p   �� 5H   
   -   5         ��Name$ bt_insert_button��5H      $��Insert Item��6+   $
��Left=�6A   $��114,371,0,0q�6\   $	��Top=�6q   $	��381��6�   $��32��6�   ���#458ca2$
��Bold"�6�   
�������6�   �� 5K   
   -   5        $�� ��5K      #��[  6   $
��Left=�6<   $��
462,36,0,0q�6W   $	��Top=�6k   $��24��6�   $��24��6�   ��5L      �� 5M      $+ %/Startupx;component/Images/update.png��6   5O      5P      5Q      