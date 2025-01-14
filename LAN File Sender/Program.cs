using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Easy_LAN_Message_Sender {
    class Program {
        static void Main(string[] args) {
            MainMenu();
        }

        static public void MainMenu() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Easy LAN Message Sender v1.0.0-alpha\n1. Setup exceptions\n2. Send message\n3. Receive message\n4. Send file\n5. Receive file\n6. Exit");
                string ans = Console.ReadLine();

                if (ans == "1") {
                    SetupFirewallExceptions();
                }
                else if (ans == "2") {
                    SendMessage();
                }
                else if (ans == "3") {
                    ReceiveMessage();
                }
                else if (ans == "4") {
                    SendFile();
                }
                else if (ans == "5") {
                    ReceiveFile();
                }
                else if (ans == "6") {
                    break;
                }
                else {
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        static void SetupFirewallExceptions() {
            try {
                string appPath = Process.GetCurrentProcess().MainModule.FileName;
                string command = $"netsh advfirewall firewall add rule name=\"Easy LAN Message Sender\" dir=in action=allow program=\"{appPath}\" enable=yes";
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/c " + command) {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process p = Process.Start(psi);
                p.WaitForExit();

                Console.WriteLine("Firewall exception added successfully.");
            } catch (Exception ex) {
                Console.WriteLine("Error adding firewall exception: " + ex.Message);
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void SendMessage() {
            try {
                Console.Write("Enter the recipient's IP address: ");
                string ipAddress = Console.ReadLine();

                Console.Write("Enter the port number: ");
                int port = int.Parse(Console.ReadLine());

                Console.Write("Enter the message to send: ");
                string message = Console.ReadLine();

                using (TcpClient client = new TcpClient(ipAddress, port)) {
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Message sent successfully.");
                }
            } catch (Exception ex) {
                Console.WriteLine("Error sending message: " + ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void ReceiveMessage() {
            try {
                Console.Write("Enter the port number to listen on: ");
                int port = int.Parse(Console.ReadLine());

                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                Console.WriteLine("Waiting for a connection...");
                using (TcpClient client = listener.AcceptTcpClient()) {
                    Console.WriteLine("Connection established.");
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Message received: " + message);
                }

                listener.Stop();
            } catch (Exception ex) {
                Console.WriteLine("Error receiving message: " + ex.Message);
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void SendFile() {
            try {
                Console.Write("Enter the recipient's IP address: ");
                string ipAddress = Console.ReadLine();

                Console.Write("Enter the port number: ");
                int port = int.Parse(Console.ReadLine());

                Console.Write("Enter the path of the file to send: ");
                string filePath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) {
                    Console.WriteLine("Invalid file path. Please check and try again.");
                    return;
                }

                using (TcpClient client = new TcpClient(ipAddress, port)) {
                    NetworkStream stream = client.GetStream();
                    byte[] fileData = File.ReadAllBytes(filePath);
                    stream.Write(fileData, 0, fileData.Length);
                    Console.WriteLine("File sent successfully.");
                }
            } catch (Exception ex) {
                Console.WriteLine("Error sending file: " + ex.Message);
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }

        static void ReceiveFile() {
            try {
                Console.Write("Enter the port number to listen on: ");
                int port = int.Parse(Console.ReadLine());

                Console.Write("Enter the path to save the received file: ");
                string savePath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(savePath) || !Directory.Exists(Path.GetDirectoryName(savePath))) {
                    Console.WriteLine("Invalid save path. Please check and try again.");
                    Console.ReadLine();
                    return;
                }

                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();

                Console.WriteLine("Waiting for a connection...");
                using (TcpClient client = listener.AcceptTcpClient()) {
                    Console.WriteLine("Connection established.");
                    NetworkStream stream = client.GetStream();
                    using (FileStream fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write)) {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                    Console.WriteLine("File received and saved successfully.");
                    Console.ReadLine();
                }

                listener.Stop();
            } catch (Exception ex) {
                Console.WriteLine("Error receiving file: " + ex.Message);
            }
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}
