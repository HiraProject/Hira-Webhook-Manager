   M S B A M L   `   `   `  ����   Hira Webhook Destroyer'    !Hira_Webhook_Destroyer.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Webhook Tool��$	��650��$	��900�� � WindowStartupLocation$ CenterScreen=����#0F0F0F$��Segoe UI)� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius	 J� SnapsToDevicePixels
 J� Opacity ��Name �� Triggers P� Property P� Value �� 
TargetName ��Name��%�  '��       '��     �� " ��.���  � �� �#007ACC��  � ��
 �������  � ��$ 0q���  � ��$ 20 10q���  � ��$ 14(���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��#��z��$ 8��$
	 True��._�� .+��� $ hoverEffect��$
 0Q�$ 8�����	#20FFFFFF�� $ contentPresenter��$��Center=�$��Center=�#��z�� P�  �@J�IsMouseOver$
 True��. ��� $ hoverEffect�� �@J�Opacity$ 1Q�P�  � ��$
 True��. ��� $ border�� � �� �#005F9E�� " ��.���  � �� �#1A1A1A��  � ��
 �������  � ��$ 0q���  � ��$ 15 10q���  � ��$ 14(���  �@��
CaretBrush �#007ACC��  � �� �� " ��.R��� $ border��#��z��$ 8��$
	 True��._��� $ PART_ContentHost�� P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �#212121.��� $��25q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��Discord Webhook Tool��$��28(�$��Medium"�
�������$��Center=�$��0 0 0 40q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ #007ACC��   Opacity$	 0.4Q�   
BlurRadius$ 20Q��� $��1��$��0 0 0 20q�.+��� $��Webhook URL�����#A0A0A0$��0 0 0 5q�$��13(��� -    ��Name$ WebhookUrlTextBox��$��40�� � ToolTip$ Enter Webhook URL���� $��2��$��0 0 0 20q�.+��� $��Message (Optional)�����#A0A0A0$��0 0 0 5q�$��13(��� -   $ MessageTextBox��$��40��$ Enter Message���� $��3��$��0 0 0 30q�.+��� $��Spam Settings�����#A0A0A0$��15(�$��0 0 0 10q��  � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� $��0 0 10 0q�.+��� $��Number of Messages�����#808080$��12(��� -   $ SpamCountTextBox��$��10��$��40��$��0 5 0 0q��� $��1��$
��10 0q�.+��� $��
Delay (ms)�����#808080$��12(��� -   $ SpamDelayTextBox��$
��1000��$��38��$��0 5 0 0q��� -    ��Name$ RandomMessageCheckBox��$��2��$��Random Messages�����#A0A0A0$��Bottom=�$��10 0 0 0q��� $��4�� �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$
��0 20q�.+��� -    ��Name$ SendMessageButton��$��Send Message��$	��140�����#007ACC�� -   $ DeleteWebhookButton��$��Delete Webhook��$	��145�����#E53935$
��20 0q��� -   $ 
SpamButton��$��
Start Spam��$	��140�����#4CAF50