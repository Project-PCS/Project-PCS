   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	   $    Project_PCS.TransaksiPembelian   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	     � Title$  TransaksiPembelian��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � .+�5
   
   �� $��Transaksi Pembelian��6   $
��Left=�6.   $��
258,26,0,0q�6I   $	��Top=�6]   $��Broadway)�6u   $��24(�6�   ���	#FF001FFF6�   �� 5   
   $��No Nota��6   $
��Left=�6"   $��	22,97,0,0q�6=   $	��Top=�6P   �� 5   
   $��Supplier��6   $
��Left=�6#   $��
22,128,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ 
cbSupplier��5      $
��Left=�6'   $��108,131,0,0q�6B   $	��Top=�6W   $	��120��6o   6{   �� 5   
   -   5         ��Name$ tbNomor��5      $
��Left=�6#   $��23��6>   $��108,101,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   {�.  6�   �� 5   
   $��Batas Bayar��6   $
��Left=�6&   $��
22,168,0,0q�6A   $	��Top=�6U   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgDaftar��5      $
��Left=�6%   $	��187��6@   $��281,101,0,0q�6M   $	��Top=�6b   $	��227��6z      
IsReadOnly . 6�     5   
   -   5        $ dgKeranjang��5      $
��Left=�6(   $	��187��6C   $��535,101,0,0q�6P   $	��Top=�6e   $	��227��6}    . 6�   �� 5   
   $��Jumlah:��6   $
��Left=�6"   $��282,336,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $ tbbJum��5      $
��Left=�6"   $��23��6=   $��346,339,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   6�   �� 5   
   -   5         ��Name$ 	btnTambah��5      $��Tambah��6$   $
��Left=�65   $��380,367,0,0q�6P   $	��Top=�6e   $��86��6}   {�.  6�   �� 5   
   $��
Id Barang:��6   $
��Left=�6%   $��282,305,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ 
tbIdBarang��5      $
��Left=�6&   $��23��6A   $��346,308,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   {�.  6�   �� 5   
   -   5        $ btnBeli��5      $
��Beli��6"   $
��Left=�61   $��
30,251,0,0q�6L   $	��Top=�6`   $	��198��6x   $��37��6�   {�.  6�   �� 5   
   -	   5        $ btnReset��5      $��Ulang��6#   $
��Left=�63   $��
30,293,0,0q�6N   $	��Top=�6b   $��80��6z   6�   �� 5   
   -
   5        $ btnBack��5      $��Kembali��6"   $
��Left=�64   $��	26,35,0,0q�6O   $	��Top=�6b   $��96��6z   6�   �� 5   
   -   5        $ btnHapus��5      $��Hapus��6#   $
��Left=�63   $��535,308,0,0q�6N   $	��Top=�6c   $��86��6{   {�.  6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpTime��5      $
��Left=�6%   $��108,167,0,0q�6@   $	��Top=�6U   $	��120��6m   5      5      