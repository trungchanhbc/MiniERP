   M S B A M L   `   `   `  ����B  >MiniERP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MiniERP.ViewMiniERP.View  5   	   7 clr-namespace:MiniERP.PropertiesMiniERP.Properties  5   	       MiniERP.View.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MiniERP.View     5   	   7
properties clr-namespace:MiniERP.Properties     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��LoginWin��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6     LoginVM � DataContext# [ 5   	     Login_Title � Title# �  5   	   $	��400��6/   $	��350��6<   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoginLoadedCmd+
   CommandParameter
 5   $   ��  �� ElementName$ cboLanguage��5       .��5#      �  � 	Resources 5$   
     
txbAccount �� 
TargetType �� Property �� Value��%Z   &	       �� 5%      " �6'   .�5&      ��  � ��$ 
15,15,15,0q�6+   5'      5(      .+�5*   
   �� .+�5+      �� $	��100��6   $	��100��6    $��/Resource/Icons/Login.png��6-   6R   #  MaterialDesignThemes.Wpf.Card  5-      $	��300��6#   $	��250��6/   $��Center=�6<   $��Center=�6Y   .��5.      � #���  6    � RowDefinitions 5/      �� 50      $
��auto �6(   68   �� 51      $
��auto �6(   68   �� 52      $��* �6(   65   �� 53      $
��auto �6(   68   .+�56      � $��0��6   .+�57      �  � ColumnDefinitions 58      �� 59   "   $
��auto �63   �� 5:   "   $��* �63   .+�5<      '  !MaterialDesignThemes.Wpf.PackIcon  $��0��66      Kind$ Account=�6F   $��0,15,0,0q�6U   �� 5=      -   5         ��Name$ txtUserName��5=   &   $��1��5>   &     Login_UserName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  66    % !MaterialDesignFloatingHintTextBox#��[ 5?   &   5@      5A      � 5C      $��1��6   .+�5D      �  5E      �� 5F   "   $
��auto �63   �� 5G   "   $��* �63   .+�5I        $	 Key=�66   $��0,15,0,0q�6A   $��0��6S   G� 5J      -   5         G�Name$ txtPassword��5J   *   $��1��6?     Login_Password# �  5K   %    )	 %MaterialDesignFloatingHintPasswordBox#��[	 5L   %   5M      5N      � 5P      $��2��6    5Q      �� 5R      61   �� 5S      61   .+�5V      �� $��0��5X       

 Submit#��� 
 6-   $��5,15,5,0q�6P   ��5V   !   �� *LoadMainWindowCmd+��5W   !   �� $ LoginWin��5X   d   �� 5Z      $��1��5[        Exit#���  6-   $��5,15,5,0q�6N   
��� E����5Z   !   �� *
CloseCMD+5[   y   5\      � 5^      $��3��6   $
��Left=�6(   $	��100��6C   .+�5`      �� -   5        $��cboLanguage��5`   #   $��0,0,0,10q�66    �� DisplayMemberPath$ DisplayName��5b   #   $ Language��5c   #    �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 5f   #   ��5a   #   �� *
Language+ �� SelectedItem 5d   #   �� *SelectedLanguage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5g      5h      5i      5j      5k      5l      5m      