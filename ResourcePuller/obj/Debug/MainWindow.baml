   M S B A M L   `   `   `  ����  ResourcePuller    ResourcePuller.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5        � Title$  Resource Puller��5      $	��450��5      $	��800��6    � Icon$ icon.png��5      (  "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �#252525 � WindowStartupLocation$ CenterScreen=�5	         LeftWindowCommands 5      +  %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      o� 
������ 
�������.@�5      m� $��_File��6   .@�5      m� -   5        $��_Open...��5      61   �� 5      m� 5      -   5        $��E_xit��5      6.   5      5      5         RightWindowCommands 5        5   
   .@�5      �� -   5        $
��Open��5      6$   5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5       $��* �6   .+�5#   
   R� -   5         R�Name$ ResourceTree��5#      $��0��6)   $��5q�69   �� 5%   
   -   5         ��Name$ ResourceEditor��5%      $��1��6*   $��5q�6:   	 �� AcceptsReturn	 . 
 �� 
AcceptsTab
 . " �� VerticalScrollBarVisibility$
 Auto=�5'      $ �� HorizontalScrollBarVisibility$
 Auto=�65   �� 5)   
   -   5        $��1��5)      $��Save Changes��6!   $��Right=�68   $��Bottom=�5*      $��5q�6,   $	��120��67   6C   5+      5,      