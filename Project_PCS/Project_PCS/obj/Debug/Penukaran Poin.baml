   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	        Project_PCS.Penukaran_Poin   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	     � Title$  Penukaran_Poin��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � .+�5
   
   �� -   5         ��Name$ btnBack��5
      $��Kembali��6"   $
��Left=�64   $��	29,38,0,0q�6O   $	��Top=�6b   $��87��6z   6�   �� 5   
   $��Penukaran Poin��6   $
��Left=�6)   $��
258,26,0,0q�6D   $	��Top=�6X   $��Broadway)�6p   $��24(�6�   ���	#FF001FFF6�   �� 5   
   $��ID Customer��6   $
��Left=�6&   $	��Top=�6A   $��
29,103,0,0q�6Y   �� 5   
   -   5         ��Name$
 tbId��5      $
��Left=�6    $��23��6;   $��121,100,0,0q�6G    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��120��6�   �� 5   
   -   5        $ btnCari��5      $
��Cari��6"   $
��Left=�61   $��270,100,0,0q�6L   $	��Top=�6a   $��82��6y   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgBarang��5      $
��Left=�6%   $	��146��6@   $��
29,156,0,0q�6M   $	��Top=�6a   $	��323��6y      
IsReadOnly . 6�   �� 5   
   $��Total Poin : ��6   $
��Left=�6(   $	��Top=�6C   $��
568,96,0,0q�6[   $��75��6o   �� 5   
   -   5         ��Name$ lbPoin��5      $��-��6    $
��Left=�6,   $	��Top=�6G   $��
643,96,0,0q�6_   $��75��6s   �� 5   
   $��	ID Barang��6   $
��Left=�6$   $	��Top=�6?   $��
29,319,0,0q�6W   �� 5   
   -   5        $ 
tbIdBarang��5      $
��Left=�6&   $��23��6A   $��121,323,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   {�.  6�   �� 5   
   -   5        $ 	btnTambah��5      $��Tambah��6$   $
��Left=�65   $��258,323,0,0q�6P   $	��Top=�6e   $��94��6}   {�.  6�     5   
   -   5        $ dgList��5      $
��Left=�6#   $	��146��6>   $��395,156,0,0q�6K   $	��Top=�6`   $	��323��6x   6�   �� 5   
   $ ��Total Poin yang diperlukan��6   $
��Left=�65   $	��Top=�6P   $��395,317,0,0q�6h   �� 5   
   -	   5        $ poinreq��5      $��0��6!   $
��Left=�6-   $	��Top=�6H   $��550,317,0,0q�6`   �� 5   
   -
   5        $ lbketerangan��5      $�� ��6&   $
��Left=�62   $	��Top=�6M   $��409,343,0,0q�6e   �� 5   
   -   5        $ btnTukar��5      $��Tukar��6#   $
��Left=�63   $��627,354,0,0q�6N   $	��Top=�6c   $��91��6{   {�.  6�   �� 5   
   -   5        $ btnHapus��5      $��Hapus��6#   $
��Left=�63   $��627,320,0,0q�6N   $	��Top=�6c   $��91��6{   {�.  6�   5      5      