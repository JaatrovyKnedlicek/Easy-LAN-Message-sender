
# Easy LAN Message and File sender
This is my little project. It's a program that lets you send messages and files between computers in a LAN Network using the TCP protocol for Linux and Windows 10 or newer.
## WIP
I'm still working on the project. This is a pre-release alpha version with only basic in-dev functions.
## Installation
### Windows
**Runtime installation** you need to install [.NET Desktop Runtime 9.0](https://download.visualstudio.microsoft.com/download/pr/685792b6-4827-4dca-a971-bce5d7905170/1bf61b02151bc56e763dc711e45f0e1e/windowsdesktop-runtime-9.0.0-win-x64.exe) to be able to run the program.
**Downloading the program** then download the program from releases. You can just extract the content of the `win-x64.zip` and you're ready to go.
### Linux
**Runtime installation** You need to install .NET Runtime 9.0 individually according to your Linux distribution.
**Downloading the program** then download the program from releases. Extract the content of the `linux-x64.zip`.
## Use
**Windows** You can run the program by opening `LAN File Sender.exe` from the zip file you downloaded. For communication between computers, programs must be run on both computers. I recommend using port 5000.

**Linux** You can run the program by running `LAN File Sender` using a terminal. For communication between computers, programs must be run on both computers. I recommend using port 5000.
### Functions explained:

 - **Setup exceptions** This setup firewall exception so Windows built-in firewall will not block traffic from the program.
 Note: Setup exceptions isn't currently in Linux version. But in most cases, Linux shouldn't require this function.
 - **Send/Receive message** sends a basic message from one computer to another computer.
 - **Send/Receive file** sends a file from one to another computer.
 
## Requirements
### Windows:
 - **Windows 10 x64 or newer**
 - **.NET Runtime 9.0 or .NET Runtime Desktop 9.0** I reccomend to download **Runtime Desktop**.
 ### Linux:
 - **.NET Runtime 9.0**

## Contributing
I would appreciate any kind of help. You can send your code to pull requests. I would review all the pull requests.
## License
This project is licensed under [Creative Commons Attribution-NonCommercial 4.0 International License](https://creativecommons.org/licenses/by-nc/4.0/).
[![CC BY-NC 4.0](https://mirrors.creativecommons.org/presskit/buttons/88x31/png/by-nc.png)](https://creativecommons.org/licenses/by-nc/4.0/)
## Contact
E-Mail: [jankorepka888@gmail.com](mailto:jankorepka888@gmail.com)

## Screenshots:
Screenshot of the main menu on Windows:
![enter image description here](https://github.com/JaatrovyKnedlicek/Easy-LAN-Message-sender/blob/main/screenshots/image.png?raw=true)
Screenshot of the main menu on Linux:
![enter image description here](https://github.com/JaatrovyKnedlicek/Easy-LAN-Message-sender/blob/main/screenshots/linuxscreen.png?raw=true)
## Future plans:

 - Add chat
 - Make the app more practical
 - Adding encryption
 - Adding customizability
 - Adding GUI
