   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   #    MiniERP.View.FinishGoodWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     FinishGoodVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     FinishGood_Title � Title# �  5   	   $	��700��64   $	��900��6A   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��10q�6+   .��5      �  � ColumnDefinitions 5       �� 5!      $
��auto �6'   �� 5"      $��* �6'   .+�5%      �� $	��160��6   $��5q�6'   $��0��62     SearchBy)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5&       & "MaterialDesignFloatingHintComboBox#��[ 5'      .@�5(      �� .��6#   Formula Code5*      �� 5+      .��6#   Finish Good Code5-      �� 5.      .��6#   Finish Good Name50      �� 51      .��6#   
Customer53      �� 54      .��6#   ...56      57      �� 58      $��1��6   $��5q�6*     
SearchText# �  59       % !MaterialDesignFloatingHintTextBox#��[ 5:      5;      5<        5>   
   $��1��6   $��
10,0,10,10q�6+   .��5?      ��  �� Orientation$ 
Horizontal=�6   .+�5@      �� $��5q�5A      $	��100��6$    	 Add#��� 	 60    
 MaterialDesignRaisedButton#��[
 5B      ��5@      �� *FinishGoodAddItemCommand+5B      �� 5C      $��5q�6   $	��100��6$     Edit#���  60   #��[
 5D      �� 5E      $��5q�6   $	��100��6$    
 Remove#���  60   #��[
 5F      5G      5H        5J   
   $��2��6   $��
10,0,10,10q�6+   .��5K      �� 	 �� View	 5L      �� 5M      .P�5N      ��   	InputDate#���  6)   �� 5O        Formula_Code#���  6)   �� 5P        FinishGood_Code#���  6)   �� 5Q        FinishGood_Name#���  6)   �� 5R       
 HSCode#���  6)   �� 5S        Quantity#���  6)   �� 5T        Customer#���  6)   �� 5U        PurchaseOrder#���  6)   �� 5V        Invoice#���  6)   5W      5Y      5Z      5[      5\      