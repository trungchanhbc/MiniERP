   M S B A M L   `   `   `  ���� B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  7 clr-namespace:MiniERP.PropertiesMiniERP.Properties      MiniERP.View.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:MiniERP.View     7
properties clr-namespace:MiniERP.Properties     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $��LoginWin��   MaterialDesignBody#���   $��Regular"�$��13(�&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�   TextRenderingMode$
 Auto=�  MaterialDesignPaper#���    MaterialDesignFont#���   � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�  LoginVM � DataContext# [   Login_Title � Title# �  $	��400��$	��350��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *LoginLoadedCmd+
   CommandParameter
 ��  �� ElementName$ cboLanguage��.���  � 	Resources   
txbAccount �� 
TargetType �� Property �� Value��%5   &	       �� " �.���  � ��$ 
15,15,15,0q�.+��� .+��� $	��100��$	��100��$��/Resource/Icons/Login.png��#  MaterialDesignThemes.Wpf.Card  $	��300��$	��250��$��Center=�$��Center=�.��� #���   � RowDefinitions �� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+�� $��0��.+��  � ColumnDefinitions �� $
��auto ��� $��* �.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��0��   Kind$ Account=�$��0,15,0,0q��� -    ��Name$ txtUserName��$��1��  Login_UserName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   % !MaterialDesignFloatingHintTextBox#��[ � $��1��.+��  �� $
��auto ��� $��* �.+�  $	 Key=�$��0,15,0,0q�$��0��G� -    G�Name$ txtPassword��$��1��  Login_Password# �   )	 %MaterialDesignFloatingHintPasswordBox#��[	 � $��2�� �� �� .+��� $��0�� 

 Submit#��� 
 $��5,15,5,0q����� *LoadMainWindowCmd+���� $ LoginWin���� $��1��  Exit#���  $��5,15,5,0q�
��� E������ *
CloseCMD+� $��3��$
��Left=�$	��100��.+��� -   $��cboLanguage��$��0,0,0,10q� �� DisplayMemberPath$ DisplayName��$ Language�� �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ ���� *
Language+ �� SelectedItem �� *SelectedLanguage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�