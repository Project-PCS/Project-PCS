   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	       Project_PCS.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	     � Title$  Halaman Login��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��32* �6   �� 5      $
��365* �6   .+�5   
   �� $	��645��6   $	��Top=�6   $��2��65   $��-103,-107,-162.4,-118q�6I   $'��!photo-1557683311-eac922347aa1.jpg��6h    J� OpacityMask �	#FFDDC0C06�   �� 5   
   ���	#FFF4F4F5$
��Left=�6%   $	��283��6@   
���   �$	��Top=�6\   $	��437��6t   $��1��6�   $��
127,99,0,0q�6�    J� Opacity$	 0.7Q�6�   �� 5   
   $��LOGIN��6   $��Microsoft YaHei Light)�6    $
��Left=�6C   $��
266,23,0,0q�6^   $	��Top=�6r   $	��160��6�   $��48(�6�   $��1��6�   
�������$
��Bold"�6�   �� 5   
   $
��Left=�6   $��232,173,0,0q�6/   $
��Wrap=�6D   $��Username��6X   $��Microsoft YaHei Light)�6i   $	��Top=�6�   $��1��6�   �� 5   
   $
��Left=�6   $��Microsoft YaHei Light)�6/   $��234,222,0,0q�6R   $
��Wrap=�6g   $��Password��6{   $	��Top=�6�   $��1��6�   �� 5   
   -   5         ��Name$ tb_username��5      $
��Left=�6'   $��23��6B   $��232,189,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��219��6�   $��1��6�   �� 5   
   -   5         ��Name$ btnLogin��5      $�� ��6#   $
��Left=�6.   $��234,295,0,0q�6I   $	��Top=�6^   $	��219��6v   $��64��6�   $��1��6�   ���	#DDFFFFFF��6�   Z� ��5      �� 5       �� ImageSource$ 	login.png��6   5      �� 5   
   $
��Left=�6   $��229,122,0,0q�6/   $
��Wrap=�6D   $��Login sebagai:��6X   $	��Top=�6n   $��Microsoft YaHei Light)�6�   $��1��6�   	� 5   
   -   5        	 	�Name$		 peg��5      $��Pegawai��6#   $
��Left=�66   $��Microsoft YaHei Light)�6Q   $��232,143,0,0q�6t   $	��Top=�6�   $��1��6�   	� 5   
   -   5        $		 adm��5      $��Admin��6#   $
��Left=�63   $��Microsoft YaHei Light)�6N   $��376,146,0,0q�6q   $	��Top=�6�   $��1��6�   G� 5   
   -   5        
 G�Name$
 tb_pass��5      $
��Left=�6'   $��234,243,0,0q�6B   $	��Top=�6W   $	��217��6o   $��1��6{   5      5      