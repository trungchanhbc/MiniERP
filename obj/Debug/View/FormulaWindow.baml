   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	        MiniERP.View.FormulaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	     	FormulaVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	     Formula_Title � Title# �  5   	   $	��550��61   $	��850��6>   .��5      �  � 	Resources 5   
   #  MaterialDesignThemes.Wpf.Card �� 
TargetType �� Property �� Value��%Z   '        �� 5      "  6   .�5      ��  � ��$ 
10,10,10,0q�6+   5      5      	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   .+�5%   
     $��0��6   .��5&      � 
 � ColumnDefinitions
 5'      �� 5(      $	��150 �6'   �� 5)      $��* �6'   .+�5,      �� $��5q�6   $��0��6&     SearchBy)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5-       & "MaterialDesignFloatingHintComboBox#��[ 5.      .@�5/      �� .��6#   Formula Code51      �� 52      .��6#   Raw Material Code54      �� 55      .��6#   Raw Material Name57      58      �� 59      $��5q�6   $��1��6%     
SearchText# �  5:       % !MaterialDesignFloatingHintTextBox#��[ 5;      5<      5=        5@   
   $��1��6   .��5A      ��  �� Orientation$ 
Horizontal=�6   .+�5B      �� $��5q�5C      $	��100��6$    	 Add#��� 	 60    
 MaterialDesignRaisedButton#��[
 5D      ��5B      �� *FormulaAddItemCommand+5D      �� 5E      $��5q�6   $	��100��6$     Edit#���  60   #��[
 5F      �� 5G      $��5q�6   $	��100��6$    
 Remove#���  60   #��[
 5H      5I      5J        5M   
   $��2��6   $��10q�6+   .��5N      ��  �� View 5O      �� 5P      .P�5Q      ��   RawMaterial_Code#���  6)   �� 5R        RawMaterial_Name#���  6)   �� 5S        Unit#���  6)   �� 5T        Formula_OriginalConsumed#���  6)   �� 5U        Formula_LossRate#���  6)   �� 5V        Formula_ActualConsumed#���  6)   �� 5W        Supplier#���  6)   5X      5Z      5[      5]      5^      