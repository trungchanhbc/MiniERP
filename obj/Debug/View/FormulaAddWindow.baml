   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   '    !MiniERP.View.FormulaAddItemWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	     Formula_Title � Title# �  5   	   $	��450��61   $	��800��6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��
10,10,10,0q�6+   .��5      �� $��5q�6     Formula_Code)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5       % !MaterialDesignFloatingHintTextBox#��[ 5       5!        5$   
   $��1��6   $��
10,10,10,0q�6+   .��5%      ��  �� Orientation$ 
Horizontal=�6   .+�5&      �� $	��100��6   $��5q�6%     MaterialDesignRaisedButton#��[ 5'   %     Save � ToolTip# �  5(   %   #��[ 6F   �� 5)      $	��100��6   $��5q�6%   #��[ 5*   %    	 Clear# �  5+   %   #��[ 6G   5,      5-        50   
   $��2��6   $��10q�6+   .��51      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��5q�63   	   Columns	 52      0  *System.Windows.Controls.DataGridTextColumn  53       	 RawMaterial_Code,  &System.Windows.Controls.DataGridColumn
   Header#
 � 	 6)     54       
 RawMaterial_Name#
 � 
 6)     55        Unit#
 �  6)     56        Formula_OriginalConsumed#
 �  6)     57        Formula_LossRate#
 �  6)     58        Formula_ActualConsumed#
 �  6)     59        Supplier#
 �  6)   5;      5<      5=      5>      