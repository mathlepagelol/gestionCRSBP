   M S B A M L   `   `   `  ����G  CgestionCRSBP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:gestionCRSBPgestionCRSBP  5          gestionCRSBP.Auth   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:gestionCRSBP     5        N� Title$
  Auth��5      .��5
      �  � RowDefinitions 5   
   �� 5      $
��225* �6   �� 5      $	��36* �6   �� 5      $	��36* �6   �� 5      $	��41* �6   �� 5      $	��36* �6   �� 5      $	��41* �6   �� 5      $	��70* �6   �� 5      $	��94* �6    � ColumnDefinitions 5   
   �� 5      $
��260* �6   �� 5      $	��75* �6   �� 5      $
��228* �6   �� 5      $	��75* �6   �� 5      $
��238* �6   .+�5   
   �� -   5        $��	Connexion��5      $��
74,15,76,0q�6%   ���	#FF1243EA J� RenderTransformOrigin$ -0.026,0.45&�6l   $��2��6�   $��6��6�   $��24��6�   $	��Top=�6�   �� 5   
   $��	2,10,1,10q�6   $��/Images/crsbp.png��6#   $��2��6>   �� 5   
   -   5        $��edtUsername��5      $��
32,5,32,10q�6%    �� TextWrapping$
 Wrap=�69   $�� ��6M   ���	#FF1D8AD4$��2��6m   $��3��6}   G� 5   
   -   5        $��edtPassword��5      $��
32,4,32,10q�6)   ���	#FF1D8AD4$��2��6U   $��5��6e   �� 5    
   $��Nom d'utilisateur��6   $��	32,3,40,0q�6,   $��2��6?   $��2��6O   �� 5!   
   $��Mot de passe��6   $��	32,3,40,3q�6'   $��2��6:   $��4��6J   �� 5"   
   -   5        $��
lblInvalid��5"      $y�Hidden=�6#   $7��1Le nom d'utilisateur/le mot de passe est invalide��67   $��	62,3,49,0q�6s   ���	#FFEE0B0B$��1��6�   $��1��6�   $��3��6�   5#      5$      