   M S B A M L   `   `   `  ����L  HPemodelanSimulasi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PemodelanSimulasiPemodelanSimulasi  5   	   "    PemodelanSimulasi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PemodelanSimulasi     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ TitleLbl��5
      $��35(�6"   $%��Aplikasi Pemodelan dan Simulasi��60   $��Center=�6Z   $��153,34,127.6,0q�6w   $	��Top=�6�   $	��513��6�   �� 5   
   -   5        $��slXValue��5   u    � Minimum$ 1Q�6    � Maximum$ 10Q�6    �� TickPlacement$ BottomRight=�6*    �� TickFrequency$ 1Q�6F   $��342,151,287.6,193.4q�6X    �� IsSnapToTickEnabled . 6�   �� 5   
   -   5        $��slYValue��5   w   $ 1Q�6   $ 10Q�6   $ BottomRight=�6*   $ 1Q�6G   $��343,194,287.6,151.4q�6Z    . 6�   �� 5   
   -   5         ��Name$ slGenoValueS��5   w   $ 10Q�6   $	 100Q�6   $ BottomRight=�6,   $ 1Q�6H   $��343,236,286.6,108.4q�6Z    . 6�   �� 5   
   -   5         ��Name$ txtBoxEduLvl��5      $��524,151,224.6,193.4q�6(   	 �� TextWrapping$
	 Wrap=�6E   
 �� TextAlignment$
 Center=�6�   ��6Y   ��  �� ElementName$ slXValue�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5        $ txtBoxResLvl��5      $��524,193,224.6,151.4q�6(   $
	 Wrap=�6E   $
 Center=�6�   ��6Y   �� *Value+$ slYValue��$ PropertyChanged=�6�   �� 5   
   -   5        $ txtBoxGenoLvl��5      $��524,237,224.6,108.4q�6)   $
	 Wrap=�6F   $
 Center=�6�   ��6Z   �� *Value+$ slGenoValueS��$ PropertyChanged=�6�   �� 5   
   -   5        $ EducationLbl��5      $��15(�6&   $��Education Level��64   $
��Left=�6N   $��200,147,0,0q�6i   $	��Top=�6~   $	��137��6�   �� 5   
   -	   5        $ ResourceLbl��5      $��15(�6&   $��Research Level��64   $
��Left=�6M   $��200,189,0,0q�6h   $	��Top=�6}   $	��119��6�   �� 5   
   -
   5        $ GenocideLbl��5      $��15(�6&   $��Genocide Interval��64   $
��Left=�6P   $��200,232,0,0q�6k   $	��Top=�6�   $	��138��6�   �� 5   
   -   5        $��Create Model��5      $��14(�6(   $
��Left=�66   $��342,299,0,0q�6Q   $	��Top=�6f   $	��125��6~   $��44��6�    �� 	IsDefault . 6�   5      5      