using System;
using System.ComponentModel; // CancelEventArgs
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows; // window
using System.Windows.Forms;

namespace TCP_Client
{
    public partial class Form1 : Form
    {
        // private TcpClient clientSocket;
        private Socket serverSocket;
        private Socket clientSocket;

        public Form1()
        {
            InitializeComponent();
            //clientSocket = new TcpClient();
            //clientSocket.Connect("localhost", 10000);

            // StartClient();
            exitServerBTN.Enabled = false;
            StartListening();
        }
        public void closeConnection()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                //your code here 



                // Release the socket.
                try
                {
                    byte[] msg = Encoding.ASCII.GetBytes("exit");

                    // Send the data through the socket.
                    int bytesSent = serverSocket.Send(msg);

                    Thread.Sleep(1000);

                    serverSocket.Shutdown(SocketShutdown.Both);
                    serverSocket.Close();
                    if (exitServerBTN.InvokeRequired)
                    {
                        exitServerBTN.Invoke(new MethodInvoker(delegate
                        {
                            exitServerBTN.Enabled = false;
                        }));
                    }
                    else
                    {
                        exitServerBTN.Enabled = false;

                    }
                    if (connectServerBTN.InvokeRequired)
                    {
                        connectServerBTN.Invoke(new MethodInvoker(delegate
                        {
                            connectServerBTN.Enabled = true;
                        }));
                    }
                    else
                    {
                        connectServerBTN.Enabled = true;

                    }
                    if (refreshBTN.InvokeRequired)
                    {
                        refreshBTN.Invoke(new MethodInvoker(delegate
                        {
                            refreshBTN.Enabled = false;
                        }));
                    }
                    else
                    {
                        refreshBTN.Enabled = false;

                    }
                    if (selectBTN.InvokeRequired)
                    {
                        selectBTN.Invoke(new MethodInvoker(delegate
                        {
                            selectBTN.Enabled = false;
                        }));
                    }
                    else
                    {
                        selectBTN.Enabled = false;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Closing Connection: " + e.ToString());
                }

            }).Start();
        }
        public void StartClient()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                IPHostEntry ipHostInfo = Dns.Resolve(serverAddress.Text);
                IPAddress ipAddress = ipHostInfo.AddressList[0];

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12000);

                // Create a TCP/IP  socket.
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    serverSocket.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        serverSocket.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("Hello World");

                    // Send the data through the socket.
                    int bytesSent = serverSocket.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = serverSocket.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String list = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    comboBox1.Items.AddRange(list.Split(','));

                    connectServerBTN.Enabled = false;
                    exitServerBTN.Enabled = true;
                    selectBTN.Enabled = true;
                    refreshBTN.Enabled = true;

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void exitServerBTN_Click(object sender, EventArgs e)
        {
            closeConnection();
        }

        private void connectServerBTN_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            refreshList();
        }
        private void refreshList()
        {
            comboBox1.Items.Clear();
            byte[] bytes = new byte[1024];

            byte[] msg = Encoding.ASCII.GetBytes("ping");

            serverSocket.Send(msg);
            int bytesRec = serverSocket.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));
            String list = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            comboBox1.Items.AddRange(list.Split(','));
            MessageBox.Show("Reloaded List!");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitServerBTN.Enabled == true)
            {


                DialogResult mBoxResult = MessageBox.Show("Program still has running connections, close them?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mBoxResult)
                {
                    case DialogResult.No:
                        e.Cancel = true;

                        break;
                    case DialogResult.Yes:
                        closeConnection();
                        break;
                }

            }
        }

        private void selectBTN_Click(object sender, EventArgs e)
        {
            sendBTN.Enabled = true;
            textBox1.Enabled = true;
            clientChat();

        }
        // Incoming data from the client.
        public static string data = null;
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public void StartListening()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                //your code here 


                // Data buffer for incoming data.
                byte[] bytes = new Byte[1024];

                // Establish the local endpoint for the socket.
                // Dns.GetHostName returns the name of the 
                // host running the application.
                IPHostEntry ipHostInfo = Dns.Resolve(GetLocalIPAddress());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 12000);

                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and 
                // listen for incoming connections.
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);

                    // Start listening for connections.
                    while (true)
                    {
                        Console.WriteLine("Waiting for a connection...");
                        // Program is suspended while waiting for an incoming connection.
                        Socket handler = listener.Accept();
                        data = null;

                        // An incoming connection needs to be processed.
                        while (true)
                        {

                            if (sendBTN.InvokeRequired)
                            {
                                sendBTN.Invoke(new MethodInvoker(delegate
                                {

                                    sendBTN.Enabled = true;
                                }));
                            }
                            else
                            {
                                sendBTN.Enabled = true;
                            }

                            bytes = new byte[1024];
                            int bytesRec = handler.Receive(bytes);
                            data += "\n" + handler.RemoteEndPoint.ToString() + ": ";
                            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            if (richTextBox1.InvokeRequired)
                            {
                                richTextBox1.Invoke(new MethodInvoker(delegate
                                {

                                    richTextBox1.Text = data;
                                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                    richTextBox1.ScrollToCaret();
                                }));
                            }
                            else
                            {
                                richTextBox1.Text = data;
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();

                            }
                            //if (selectBTN.InvokeRequired)
                            //{
                            //    selectBTN.Invoke(new MethodInvoker(delegate
                            //    {

                            //        selectBTN.Enabled = true;
                            //    }));
                            //}
                            //else
                            //{
                            //    selectBTN.Enabled = true;
                            //}
                        }

                        //// Show the data on the console.
                        //Console.WriteLine("Text received : {0}", data);

                        //// Echo the data back to the client.
                        //byte[] msg = Encoding.ASCII.GetBytes(data);

                        //handler.Send(msg);
                        //handler.Shutdown(SocketShutdown.Both);
                        //handler.Close();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.Read();
            }).Start();


        }
        private void clientChat()
        {
            // closeConnection();
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                //your code here 

                // richTextBox1.Text = "Connecting to " + comboBox1.Text + "....";
                // Data buffer for incoming data.
                byte[] bytes = new byte[1024];

                // Connect to a remote device.
                try
                {

                    // Establish the remote endpoint for the socket.
                    // This example uses port 11000 on the local computer.
                    IPHostEntry ipHostInfo = new IPHostEntry();
                    if (comboBox1.InvokeRequired)
                    {
                        comboBox1.Invoke(new MethodInvoker(delegate
                        {

                            ipHostInfo = Dns.Resolve(comboBox1.Text);
                            Console.WriteLine(comboBox1.Text);

                        }));
                    }
                    else
                    {
                        ipHostInfo = Dns.Resolve(comboBox1.Text);


                    }

                    IPAddress ipAddress = ipHostInfo.AddressList[0];

                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12000);

                    // Create a TCP/IP  socket.
                    clientSocket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);


                    // Connect the socket to the remote endpoint. Catch any errors.
                    try
                    {

                        clientSocket.Connect(remoteEP);

                        Console.WriteLine("Socket connected to {0}",
                            clientSocket.RemoteEndPoint.ToString());

                        if (richTextBox1.InvokeRequired)
                        {
                            richTextBox1.Invoke(new MethodInvoker(delegate
                            {

                                richTextBox1.Text += "\nNow sending message to " + comboBox1.Text;
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();

                            }));
                        }
                        else
                        {
                            richTextBox1.Text += "\nNow sending message to " + comboBox1.Text;
                            richTextBox1.SelectionStart = richTextBox1.Text.Length;
                            richTextBox1.ScrollToCaret();


                        }
                        byte[] msg = Encoding.ASCII.GetBytes("Test");

                        clientSocket.Send(msg);

                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }).Start();

        }

        private void sendBTN_Click(object sender, EventArgs e)
        {
            byte[] bytes = new byte[1024];

            byte[] msg = Encoding.ASCII.GetBytes(textBox1.Text);

            clientSocket.Send(msg);
            richTextBox1.Text += "\n" + comboBox1.Text+": "+ textBox1.Text;
            textBox1.Text = "";
            int bytesRec = clientSocket.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));
            String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            richTextBox1.Text += "\n" + comboBox1.Text + ": " + data;
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();


        }
    }
}
