   M S B A M L   `   `   `  ����C  ?Startupx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Startupx.HumanResourcesModuleStartupx.HumanResourcesModule  5   	   1    +Startupx.HumanResourcesModule.ManagePayroll   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Startupx.HumanResourcesModule     5   	     � Title$  ManagePayroll��5   	   $	��450��6   $	��800��6,    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Style.xaml?�6%   %    5      .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dg_payroll_information��5         
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6I      AutoGenerateColumns .     CanUserAddRows .  $��0,0,-0.4,10q�6�   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Payroll Id��6G      Width$ * 6[      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *	PayrollId+6e     5      $
 Employee Id��6H   $ * 6]    .  6)   �� *
EmployeeId+6g     5      $
 	Full Name��6F   $ * 6Y    .  6)   �� *
FullName+6c     5      $
 WorkingHours��6J   $ * 6`    .  6)   �� *WorkingHours+6j     5      $
 Gross Salary��6I   $ * 6_    6)   �� *GrossSalary+6_     5      $
 
Net Salary��6G   $ * 6[    6)   �� *	NetSalary+6[     5       $
 
Start Date��6M   $ * 6a    6)   �� *SalaryIniPeriod+6a     5!      $
 End Date��6M   $ * 6_    6)   �� *SalaryEndPeriod+6_     5"      $
 	Increment��6O   $ * 6b    6)   �� *AdjustmentPercent+6b   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $
 Update��6-   $ 40 6=      CanUserResize .     CellTemplate 5'      �� 5(      .R�5)   "   ��  ��Name$ update_payroll��6)   -   5         
  menu_b#��[  5)   A   $��20��6~   $��20��6�   ��5*   &   �� 5+   *    �� ImageSource$ /images/edit.png��65    j� Stretch$
 Fill=�6T   5-   #   5.      50        52      $
 Delete��6-   $ 40 6=    .   53      �� 54      .R�55   "   �� $ delete_payroll��6)   -   5        #��[  55   A   $��20��6~   $��20��6�   ��56   &   �� 57   *   $ /images/delete.png��65   $
 Fill=�6V   59   #   5:      5<      5?      5A      5B      