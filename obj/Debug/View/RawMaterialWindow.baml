   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   $    MiniERP.View.RawMaterialWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     RawMaterialVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     RawMaterial_Title � Title# �  5   	   $	��650��65   $
��1550��6B   .��5      �  � 	Resources 5   
   #  MaterialDesignThemes.Wpf.Card �� 
TargetType �� Property �� Value��%R   '        �� 5      "  6   .�5      ��  � ��$ 10q�6+   5      5      	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   .+�5%   
     $��0��6   $��
10,10,10,0q�6+   .��5&      � 
 � ColumnDefinitions
 5'      �� 5(      $	��170 �6'   �� 5)      $��* �6'   �� 5*      $
��auto �6'   .+�5-      �� -   5         ��Name$ cboRMSearch��5-      $��5q�60   $��0��6;     SearchBy)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5.       & "MaterialDesignFloatingHintComboBox#��[ 5/      .@�50      �� .��6#   
Input Date52      �� 53      .��6#   Customs Declaration No.55      �� 56      .��6#   	Open Date58      �� 59      .��6#   Goods Arrival Date5;      �� 5<      .��6#   ...5>      5?      �� 5@      -   5         ��Name$ txbRMSearch��5@      $��5q�6/   $��1��6:     
SearchText# �  5A       % !MaterialDesignFloatingHintTextBox#��[ 5B      5C      5D        5G   
   $��1��6   .��5H      ��  �� Orientation$ 
Horizontal=�6   $��2��62   .+�5I      �� $��5q�5J      $	��100��6(    	 MaterialDesignRaisedButton#��[	 5K       
 Add#��� 
 6Q   ��5I      �� *OpenRawMaterialInputCommand+5K   Q   �� 5L      $��5q�6   $	��100��6$   #��[	 5M        Edit#���  6Q   �� 5N      $��5q�6   $	��100��6$   #��[	 5O       
 Remove#���  6Q   5P      5Q        5T   
   $��2��6   $��
10,0,10,10q�6+   .��5U      ��  �� View 5V      �� 5W      .P�5X      ��   	InputDate#���  6)   �� 5Y       % !RawMaterial_CustomsDeclarationNo.#���  6)   �� 5Z        RawMaterial_OpenDate#���  6)   �� 5[        RawMaterial_GoodsArrialDate#���  6)   �� 5\        RawMaterial_Code#���  6)   �� 5]        RawMaterial_Name#���  6)   �� 5^       
 HSCode#���  6)   �� 5_       	 Price#���  6)   �� 5`        ExchangeRate#���  6)   �� 5a        TaxRate#���  6)   �� 5b        Tax#���  6)   �� 5c        ExportPrice#���  6)   �� 5d       	 Input#���  6)   �� 5e       
 Output#���  6)   �� 5f       	 Stock#���  6)   5g      5i      5j      5k      5l      