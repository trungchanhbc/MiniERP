   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   *    $MiniERP.View.FinishGoodAddItemWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	     FinishGoodAddItem_Title � Title# �  5   	   $	��550��6;   $
��1030��6H   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��10,10,10,10q�6+   .��5      � .+�5       �  � Orientation$ 
Horizontal=�6   .+�5!      �� -   5         ��Name$ txbFinishGoodCode��5!      $��5q�69   $	��120��6D     FinishGood_Code)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5"       % !MaterialDesignFloatingHintTextBox#��[ 5#      �� 5$      $��5q�6    �� 
IsEditable . $	��120��6<     FinishGood_Name# �  5%       & "MaterialDesignFloatingHintComboBox#��[ 5&      �� 5'      $��5q�6   $	��120��6)     Quantity# �  5(      #��[ 5)      �� 5*      $��5q�6    . $	��120��6<    	 Customer# � 	 5+      #��[ 5,      �� 5-      $��5q�6   $	��120��6)    
 PurchaseOrder# � 
 5.      #��[ 5/      �� 50      $��5q�6   $	��120��6)     Invoice# �  51      #��[ 52      �� 53      $��5q�6   $	��120��6)    
 HSCode# �  54      #��[ 55      56      57      58        5;   
   $��1��6   $��
10,0,10,10q�6+   .��5<      � $ 
Horizontal=�6   .+�5=      ��   Add#���  6   $��5q�69   $	��100��6D     MaterialDesignRaisedButton#��[ 5>      �� 5?       	 Clear#���  6   $��5q�6;   $	��100��6F   #��[ 5@      �� 5A      $��	Clipboard��6   $��5q�6-   $	��100��68   #��[ 5B      5C      5D      � 5G   
   $��2��6   $��
10,0,10,10q�6   	 � ColumnDefinitions	 5H      �� 5I      $
��auto �6#   �� 5J      $��* �6#   .+�5M        $��0��6"   .��5N      �� 
 �� View
 5O      �� 5P      .P�5Q      ��   Formula_Code#���  6-   5R      5T      5U        5W      $��1��6"   $��10,0,0,0q�62   .��5X      �� 
 5Y      �� 5Z      .P�5[      ��   RawMaterial_Code#���  6-   �� 5\        RawMaterial_Name#���  6-   �� 5]        Unit#���  6-   �� 5^        Formula_OriginalConsumed#���  6-   �� 5_        Formula_LossRate#���  6-   �� 5`        Formula_ActualConsumed#���  6-   �� 5a       
 Output#���  6-   �� 5b       	 Stock#���  6-   5c      5e      5f      5g      5i      5j      