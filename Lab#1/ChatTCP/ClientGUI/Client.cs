using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public class Client
    {
        private readonly Socket _tcpSocket;
        private readonly Form1 _form;

        public Client(string ip, int port, Form1 form)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connectToServer(tcpEndPoint);

            _form = form;
        }

        public void Start()
        {


            Thread reader = new Thread(() =>
            {
                while (true)
                {
                    var data = readFromServer();
                    ConsoleUtils.PrintResponse(data);
                }
            });
            reader.Start();

            
        }

        private void connectToServer(IPEndPoint tcpEndPoint)
        {
            while (true)
            {
                try
                {
                    _tcpSocket.Connect(tcpEndPoint);
                    ConsoleUtils.PrintWarning("Socket connected to server " + _tcpSocket.RemoteEndPoint.ToString());

                    break;
                }
                catch (SocketException)
                {
                    _form.Invoke(new Action(() =>
                    {
                        _form.textBox1.AppendText("Connection failed. Retrying in 1 second..." + Environment.NewLine);
                    }));
                    Thread.Sleep(1000);
                }
            }
        }

        public void sendToServer(string message)
        {
            var data = Encoding.UTF8.GetBytes(_form.Text + " => " + message);
            _tcpSocket.Send(data);
        }

        public string readFromServer()
        {
            var buffer = new byte[256];
            int size;
            var response = new StringBuilder();

            do
            {
                size = _tcpSocket.Receive(buffer);
                response.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (_tcpSocket.Available > 0);

            var data = response.ToString();
            _form.Invoke(new Action(() =>
            {
                _form.textBox1.AppendText(data + Environment.NewLine);
            }));

            return data;
        }

        public void Close()
        {
            //_tcpSocket.Shutdown(SocketShutdown.Both);
            _tcpSocket.Close();
        }
    }
}
