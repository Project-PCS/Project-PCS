   M S B A M L   `   `   `  ����F  BProject_PCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Project_PCSProject_PCS  5   	   "    Project_PCS.MasterBrgMenarik   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Project_PCS     5   	     � Title$  MasterBrgMenarik��5   	   $	��458��6"   $	��808��6/    � WindowStartupLocation$ CenterScreen=�6;   .��5	      � .+�5
   
   �� $��MASTER BARANG MENARIK��6   $��Center=�60   $	��Top=�6M   $
��Bold"�6e   $��16(�6w   $��284,10,284,0q�6�   �� 5   
   -   5         ��Name$ 
btnKembali��5      $��Kembali��6%   $
��Left=�67   $��	10,10,0,0q�6R   $	��Top=�6e   $��88��6}   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgBrgMenarik��5      $
��Left=�6)   $	��355��6D   $��9,54,0,0q�6Q   $	��Top=�6c   $	��489��6{   6�   �� 5   
   -   5         ��Name$ canvas1��5      $
��Left=�6"   $	��353��6=   $��
503,54,0,0q�6J   $	��Top=�6^   $	��279��6v   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 1Q�61   � 5      $ 	#FFE1D0FF��6#   5      .+�5      �� -   5        	 ��Name$	 tbJmlBarang��5      $��23��6+   
 �� Left$	
 137��67    �� TextWrapping$
 Wrap=�6I   
 �� Top$	 208��6]   $	��133��6n    �� 	MaxLength$ 2��6�   �� 5      $��ID Barang Menarik��6   $
 10��60   $ 10��6A   �� 5      $��	ID Barang��6   $
 10��6(   $	 108��69   �� 5      $��Jumlah Barang��6   $
 10��6,   $	 204��6=   �� 5      -   5         ��Name$ labIDBrgMenarik��5      $��-��6-   $	
 137��69   $ 10��6K   $��55��6[   �� 5      -   5        $	 	tbJmlPoin��5      $��23��6)   $	
 137��65   $
 Wrap=�6G   $	 236��6[   $	��133��6l   $ 3��6�   �� 5      $��Jumlah Poin��6   $
 10��6*   $	 232��6;   �� 5      -   5         ��Name$ 	cbBerlaku��5      $��Berlaku��6*   $
 10��6<   $	 263��6M   �� 5      $��Cari ID/Nama Barang��6   $
 10��62   $ 50��6C   �� 5      -   5        $	 tbCari��5      $��23��6&   $	
 137��62   $
 Wrap=�6D   $ 54��6X   $	��133��6h   6t   �� 5      $��Nama Barang��6   $
 10��6*   $	 134��6;   �� 5      -	   5        $ labIDBrg��5      $��-��6&   $	
 137��62   $	 108��6D   $	��133��6U   �� 5       -
   5        $ 
labNamaBrg��5       $��-��6(   $	
 137��64   $	 134��6F   $	��133��6W   �� 5!      $��Harga Eceran��6   $
 10��6+   $	 160��6<   �� 5"      -   5        $ labHarga��5"      $��0��6&   $	
 137��62   $	 160��6D   $	��133��6U   �� 5#      $��Kategori��6   $
 10��6'   $ 82��68   �� 5$      -   5        $ labKategori��5$      $��-��6)   $	
 137��65   $ 82��6G   $	��133��6W   �� 5%      -   5        $ 	btnTambah��5%      $��Tambah��6(   $
 10��69   $	 301��6J   $	��122��6[   $��35��6g   6s   �� 5&      -   5        $ btnUbah��5&      $
��Edit��6&   $	
 137��65   $	 301��6G   $	��132��6X   $��35��6d   6p   5'      5(      5)      