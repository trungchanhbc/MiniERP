   M S B A M L   `   `   `  ���� B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  '    !MiniERP.View.FormulaAddItemWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:MiniERP.View     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=�  Formula_Title � Title# �  $	��450��$	��800��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��$��
10,10,10,0q�.���� $��5q�  Formula_Code)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   % !MaterialDesignFloatingHintTextBox#��[   $��1��$��
10,10,10,0q�.����  �� Orientation$ 
Horizontal=�.+��� $	��100��$��5q�  MaterialDesignRaisedButton#��[   Save � ToolTip# �  #��[ �� $	��100��$��5q�#��[  	 Clear# �  #��[   $��2��$��10q�.��&   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��5q�	   Columns	 0  *System.Windows.Controls.DataGridTextColumn   	 RawMaterial_Code,  &System.Windows.Controls.DataGridColumn
   Header#
 � 	    
 RawMaterial_Name#
 � 
     Unit#
 �      Formula_OriginalConsumed#
 �      Formula_LossRate#
 �      Formula_ActualConsumed#
 �      Supplier#
 �  