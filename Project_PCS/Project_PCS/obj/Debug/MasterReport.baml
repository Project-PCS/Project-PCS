   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	   h dSAPBusinessObjects.WPF.Viewer, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304tRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.ViewerSAPBusinessObjects.WPF.Viewer 5   	       Project_PCS.MasterReport   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	   eViewerRclr-namespace:SAPBusinessObjects.WPF.Viewer;assembly=SAPBusinessObjects.WPF.Viewer     5   	     � Title$  MasterReport��5	   	   $	��728��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67   .��5
      � .+�5   
   8  2SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer  -   5          Name$ CRViewer��5   &   $
��Left=�68   $	��571��6S   $��10,116,0,-268q�6`   $	��Top=�6w   $	��772��6�   �� 5   
   $��Jenis Laporan:��6   $
��Left=�6)   $��	11,55,0,0q�6D   $	��Top=�6W   �� 5   
   -   5         ��Name$ cbJenis��5      $
��Left=�6$   $��
100,57,0,0q�6?   $	��Top=�6S   $	��120��6k   �� 5   
   -   5         ��Name$ tbTahun��5      $
��Left=�6#   $��23��6>   $��
298,88,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��120��6�    �� 	MaxLength$ 4��6�   �� 5   
   -   5         ��Name$ 	btnCreate��5      $��BUAT LAPORAN��6$   $
��Left=�6;   $��
468,63,0,0q�6V   $	��Top=�6j   $	��159��6�   $��40��6�   �� 5   
   $��Tahun:��6   $
��Left=�6!   $��
249,87,0,0q�6<   $	��Top=�6P   �� 5   
   $��Bulan:��6   $
��Left=�6!   $��
251,56,0,0q�6<   $	��Top=�6P   �� 5   
   $��MASTER REPORT��6   $
��Left=�6(   $��
328,10,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   $��16(�6�   �� 5   
   -   5        $ cbBulan��5      $
��Left=�6$   $��
298,57,0,0q�6?   $	��Top=�6S   $	��120��6k   �� 5   
   -   5        $ btnBack��5      $��Kembali��6"   $
��Left=�64   $��	11,10,0,0q�6O   $	��Top=�6b   $��82��6z   6�   5      5      