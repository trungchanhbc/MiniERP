   M S B A M L   `   `   `  ���� B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  %    MiniERP.View.RegistrationWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:MiniERP.View     U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $��RegistrationWin��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � WindowStartupLocation$ CenterScreen=�  RegistrationVM � DataContext# [  � Title$ Registration��$	��400��$	��500��.���  � RowDefinitions �� $
��auto ��� $��* �.+�� $��0��$��10q�.+�#  MaterialDesignThemes.Wpf.Card  .���� $��Registry��$	��100��$��5q�$
��Left=�  MaterialDesignRaisedButton#��[ ���� � $��1�� �� �� .+�� $��0��$��
10,0,10,10q�.+�  .���� $��5q� �� TextWrapping$
 Wrap=�$��Stretch=�" �� VerticalScrollBarVisibility$
 Auto=�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Application Serial:������ *
DisplayKey+� $��1��$��
10,0,10,10q�.+�  .���� $��5q�$
 Wrap=�	 �� 
IsReadOnly	 . $��Stretch=�$
 Auto=�$ Registration Key:��