   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	       Project_PCS.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	     � Title$  Login Database��5   	   $��447.2��6    $��390.8��6/    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � $��	0,0,0,1.6q�6    � ColumnDefinitions 5
   
   �� 5      $	��79* �6   �� 5      $
��305* �6   .+�5   
   �� $
��Left=�6   $��10.067,199,0,0q�6/   $
��Wrap=�6G   $��Username��6[   $��Microsoft YaHei Light)�6l   $	��Top=�6�   $��1��6�   �� 5   
   $
��Left=�6   $��Microsoft YaHei Light)�6/   $��11.8,253,0,0q�6R   $
��Wrap=�6h   $��Password��6|   $	��Top=�6�   $��1��6�   �� 5   
   -   5         ��Name$ tb_username��5      $
��Left=�6'   $��23��6B   $��10.067,215,0,0q�6N    �� TextWrapping$
 Wrap=�6f   $��project��6z   $	��Top=�6�   $	��219��6�   $��1��6�   �� 5   
   -   5         ��Name$ btnLogin��5      $�� ��6#   $
��Left=�6.   $��12.067,321,0,0q�6I   $	��Top=�6a   $	��219��6y   $��64��6�   $��1��6�   ��6�   Z� ��5      �� 5       �� ImageSource$ 	login.png��6   5      �� 5   
   $
��Left=�6   $��7.067,148,0,0q�6/   $
��Wrap=�6F   $��Data Source��6Z   $	��Top=�6m   $��Microsoft YaHei Light)�6�   $��1��6�   �� 5   
   -   5        $ tb_datasource��5      $
��Left=�6)   $��23��6D   $��7.067,165,0,0q�6P   $
 Wrap=�6g   $
��orcl��6{   $	��Top=�6�   $	��224��6�   $��1��6�   �� 5   
   $
��Left=�6   $	��113��6+   $��62.067,30,0,0q�68   $	��Top=�6O   $	��142��6g   $��log.png��6s   $��1��6�   G� 5   
   -   5         G�Name$ tb_pass��5      $
��Left=�6'   $��11.8,267,0,0q�6B   $	��Top=�6X   $	��219��6p   $��1��6|   5      5      