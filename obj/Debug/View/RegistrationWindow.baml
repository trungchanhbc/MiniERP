   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   %    MiniERP.View.RegistrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5        $��RegistrationWin��5   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	     RegistrationVM � DataContext# [ 5   	    � Title$ Registration��5   	   $	��400��6   $	��500��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��10q�6   .+�5       #  MaterialDesignThemes.Wpf.Card  .��5!      �� $��Registry��6-   $	��100��5"      $��5q�6%   $
��Left=�60     MaterialDesignRaisedButton#��[ 5#      ��5!      �� 5#      5$      5%      � 5'   
   $��1��6    5(      �� 5)      �� 5*      .+�5-      � $��0��6   $��
10,0,10,10q�6    .+�5.        .��5/      �� $��5q�6    �� TextWrapping$
 Wrap=�50      $��Stretch=�52      " �� VerticalScrollBarVisibility$
 Auto=�53      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Application Serial:��54      ��5/   )   �� *
DisplayKey+54      55      56      � 57      $��1��6   $��
10,0,10,10q�6    .+�58        .��59      �� $��5q�6   $
 Wrap=�5:      	 �� 
IsReadOnly	 . $��Stretch=�5<      $
 Auto=�5=      $ Registration Key:��5>      5?      5@      5A      5B      5C      