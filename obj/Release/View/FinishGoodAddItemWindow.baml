   M S B A M L   `   `   `  ���� B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  *    $MiniERP.View.FinishGoodAddItemWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:MiniERP.View     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes     MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=�  FinishGoodAddItem_Title � Title# �  $	��550��$
��1030��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��$��10,10,10,10q�.��� .+��  � Orientation$ 
Horizontal=�.+��� -    ��Name$ txbFinishGoodCode��$��5q�$	��120��  FinishGood_Code)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   % !MaterialDesignFloatingHintTextBox#��[ �� $��5q� �� 
IsEditable . $	��120��  FinishGood_Name# �   & "MaterialDesignFloatingHintComboBox#��[ �� $��5q�$	��120��  Quantity# �  #��[ �� $��5q� . $	��120�� 	 Customer# � 	 #��[ �� $��5q�$	��120�� 
 PurchaseOrder# � 
 #��[ �� $��5q�$	��120��  Invoice# �  #��[ �� $��5q�$	��120�� 
 HSCode# �  #��[   $��1��$��
10,0,10,10q�.��� $ 
Horizontal=�.+���   Add#���  $��5q�$	��100��  MaterialDesignRaisedButton#��[ ��  	 Clear#���  $��5q�$	��100��#��[ �� $��	Clipboard��$��5q�$	��100��#��[ � $��2��$��
10,0,10,10q�	 � ColumnDefinitions	 �� $
��auto ��� $��* �.+�  $��0��.���� 
 �� View
 �� .P���   Formula_Code#���    $��1��$��10,0,0,0q�.���� 
 �� .P���   RawMaterial_Code#���  ��   RawMaterial_Name#���  ��   Unit#���  ��   Formula_OriginalConsumed#���  ��   Formula_LossRate#���  ��   Formula_ActualConsumed#���  ��  
 Output#���  ��  	 Stock#���  