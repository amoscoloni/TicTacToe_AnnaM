   M S B A M L   `   `   `  ????L  HTicTacToePractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TicTacToePracticeTicTacToePractice  5   	   "    TicTacToePractice.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TicTacToePractice     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? 
??????? ? ColumnDefinitions 5
   
   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6    ? RowDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??1* ?6   .+?5   
   ?? $??Tic Tac Toe??6   $??0??6'   $??Center=?65   $??Center=?6R   $	??100(?5      $??Calibri Light)?6#   $??1??6>   $??3??6N   ?? 5   
   -   5         ??Name$ 
btnNewGame??5      $??New Game??6>   $??1??5      $??1??6   $??10, 20, 10 ,80q?6.   ???#ffe5eb$??DemiBold"?6[   ?? 5   
   -   5        $ btnSettings??5      $??Settings??6@   $??1??6S   $??2??6`   $??10, 20, 10 ,80q?6p   ???#ffe5eb$??DemiBold"?6?   ?? 5   
   -   5        $ btnExit??5      $
??Exit??68   $??1??6G   $??3??6T   $??10, 20, 10 ,80q?6d   ???#ffe5eb$??DemiBold"?6?   5      5       