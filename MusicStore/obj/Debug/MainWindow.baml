   M S B A M L   `   `   `  ����E  AMusicStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MusicStore
MusicStore  5   	   =#clr-namespace:MusicStore.PropertiesMusicStore.Properties  5   	       MusicStore.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MusicStore     5   	   :
Properties#clr-namespace:MusicStore.Properties     5   	   -   5          �Name$  MusicStoreMainWindow��5   @    � Title$ 
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $	��73* �6    � ColumnDefinitions 5   
   �� 5      $	��69* �6   �� 5      $
��448* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MusicStoreInstrumentsGrid��5      $
��Left=�66   $��0,3,0,0q�6Q   $	��Top=�6b   $	��284��6z   $	��517��6�   $��1��6�   $��2��6�   6�   o� 5   
   -   5         o�Name$
 menu��5      $��2��6   $
��Left=�61   $��21��6L   $	��Top=�6X   $	��507��6p   .@�5      m� $
��View��6   .@�5      �� -   5         ��Name$! MusicStoreShowPianoCheckbox��5      $��Pianos��6@   6Q   �� 5      -   5        $" MusicStoreShowGuitarCheckbox��5      $��Guitars��6A   6S   5      m� 5      $��Add Instrument��6    J� 	AllowDrop . .@�5      m� -   5         m�Name$ addPianoButton��5      $��Piano��63   6B   m� 5      -   5        $ addGuitarButton��5      $��Guitar��64   6D   5      5      5      5       