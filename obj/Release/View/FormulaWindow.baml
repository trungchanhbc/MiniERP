   M S B A M L   `   `   `  ���� B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View       MiniERP.View.FormulaWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:MiniERP.View     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���    	FormulaVM � DataContext# [  � WindowStartupLocation$ CenterScreen=�  Formula_Title � Title# �  $	��550��$	��850��.���  � 	Resources #  MaterialDesignThemes.Wpf.Card �� 
TargetType �� Property �� Value��%5   '        �� "  .���  � ��$ 
10,10,10,0q�	 � RowDefinitions	 �� $
��auto ��� $
��auto ��� $��* �.+�  $��0��.��� 
 � ColumnDefinitions
 �� $	��150 ��� $��* �.+��� $��5q�$��0��  SearchBy)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   & "MaterialDesignFloatingHintComboBox#��[ .@��� .��Formula Code�� .��Raw Material Code�� .��Raw Material Name�� $��5q�$��1��  
SearchText# �   % !MaterialDesignFloatingHintTextBox#��[   $��1��.����  �� Orientation$ 
Horizontal=�.+��� $��5q�$	��100�� 	 Add#��� 	  
 MaterialDesignRaisedButton#��[
 ���� *FormulaAddItemCommand+�� $��5q�$	��100��  Edit#���  #��[
 �� $��5q�$	��100�� 
 Remove#���  #��[
   $��2��$��10q�.����  �� View �� .P���   RawMaterial_Code#���  ��   RawMaterial_Name#���  ��   Unit#���  ��   Formula_OriginalConsumed#���  ��   Formula_LossRate#���  ��   Formula_ActualConsumed#���  ��   Supplier#���  