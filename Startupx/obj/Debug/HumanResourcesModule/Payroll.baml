   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Startupx.HumanResourcesModuleStartupx.HumanResourcesModule  5   	   +    %Startupx.HumanResourcesModule.Payroll   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Startupx.HumanResourcesModule     5   	     � Title$  Payroll��5   	   $	��450��6   $	��800��6&   .��5
      � $��0,1,-0.4,-1q�6    � RowDefinitions 5   
   �� 5      $
��197* �6   �� 5      $	��13* �6   .+�5   
   �� -   5        $��dialog_title��5      $��GENERATE PAYROLL��6$   $
��Left=�6?   $��
269,24,0,0q�6Z   $	��Top=�6n   $
��Bold"�6�   $��18(�6�   $	��244��6�   �� 5   
   $��Working Hours��6   $
��Left=�6(   $��	85,76,0,0q�6C   $	��Top=�6V   $	��122��6n   �� 5   
   -   5         ��Name$ working_hours��5      $
��Left=�6)   $��23��6D   $��
188,78,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��150��6�   �� 5   
   $��EPF (%)��6   $
��Left=�6"   $��
83,113,0,0q�6=   $	��Top=�6Q   $	��122��6i   �� 5   
   -   5        $	 epf��5      $
��Left=�6   $��23��6:   $��189,113,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��150��6�   $��5��6�   �� 5   
   $	��Tax��6   $
��Left=�6   $��
96,155,0,0q�69   $	��Top=�6M   $��92��6e   �� 5   
   -   5        $	 tax��5      $
��Left=�6   $��23��6:   $��190,155,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $	��150��6�    � ToolTip$  ��6�   $��3��6�   �� 5   
   $��End Date��6   $
��Left=�6#   $��368,199,0,0q�6>   $	��Top=�6S   $��79��6k   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ end_date��5      $
��Left=�6'   $��435,201,0,0q�6B   $	��Top=�6W   $	��136��6o   �� 5!   
   $��
Start Date��6   $
��Left=�6%   $��118,199,0,0q�6@   $	��Top=�6U   $��79��6m    J� RenderTransformOrigin$ 
0.59,2.406&�6x     5"   
   -   5        $ 
start_date��5"      $
��Left=�6)   $��191,201,0,0q�6D   $	��Top=�6Y   $	��147��6q   �� 5$   
   $��	Increment��6   $
��Left=�6$   $��117,244,0,0q�6?   $	��Top=�6T   $	��104��6l   �� 5%   
   -   5        $ 	increment��5%      $
��Left=�6%   $��18��6@   $��191,250,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��148��6�   �� 5&   
   $��CAD/hr��6   $
��Left=�6!   $��345,245,0,0q�6<   $	��Top=�6Q   $��60��6i   $��27��6t   $ 0.302,-2.274&�6�   �� 5)   
   -   5         ��Name$ generate_payroll��5)      $��Generate��6+   $
��Left=�6>   $��269,308,0,0q�6Y   $	��Top=�6n   $��99��6�   $��31��6�   ���#458ca2$
��Bold"�6�   
�������6�   �� 5*   
   -	   5        $ CancelEvent��5*      $��Cancel��6&   $
��Left=�67   $��414,308,0,0q�6R   $	��Top=�6g   $��99��6   $��31��6�   6�   �� 5+   
   $��per Day��6   $
��Left=�6"   $��
343,78,0,0q�6=   $	��Top=�6Q   $��60��6i   $��27��6t   $ 0.302,-2.274&�6�   5-      5.      