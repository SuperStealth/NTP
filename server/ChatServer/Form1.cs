using System;
using System.Windows.Forms;
using System.Net;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListen_Click(object sender, EventArgs e)
        {
            // Parse the server's IP address out of the TextBox
            IPAddress ipAddr = IPAddress.Parse(txtIp.Text);
            // Create a new instance of the ChatServer object
            ChatServer mainServer = new ChatServer(ipAddr);
            // Hook the StatusChanged event handler to mainServer_StatusChanged
            ChatServer.StatusChanged += new StatusChangedEventHandler(MainServer_StatusChanged);
            // Start listening for connections
            mainServer.StartListening();
            // Show that we started to listen for connections
            txtLog.AppendText("Monitoring for connections...\r\n");
        }

        public void MainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Call the method that updates the form
            Invoke(new UpdateStatusCallback(UpdateStatus), new object[] { e.EventMessage });
        }

        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message
            txtLog.AppendText(strMessage + "\r\n");
        }
    }
}