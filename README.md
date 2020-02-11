# Cpu Usage Reader App
A very simple efficient application that reads from performance counter and displays the cpu process time in a system tray icon

# Example of how it looks
![alt text](https://raw.githubusercontent.com/jonwolfdev/Cpu_Usage_Reader_App/master/screenshot.jpg)

# Technologies
- Windows Forms
- .NET 4.7

# How?
Using performance counter to get `% Processor Time` and updating at an interval and displaying the value in a system tray icon

# Start when windows start
Follow this guide: https://support.microsoft.com/en-us/help/4026268/windows-10-change-startup-apps
Basically create a shortcut and put in: `shell:startup` (Windows+R)
