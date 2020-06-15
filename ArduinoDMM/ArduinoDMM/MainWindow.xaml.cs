using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;

namespace ArduinoDMM
{
    // <summary>
    // Interaktionslogik für MainWindow.xaml
    // </summary>
    public partial class MainWindow : Window
    {
        SerialPort serial = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
            serial.BaudRate = 9600;
            serial.PortName = "COM4";
            try { serial.Open(); }
            catch { }
            serial.DataReceived += Serial_DataReceived;
        }
        private delegate void nextStep(string Data);
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Data = serial.ReadLine();
            Dispatcher.Invoke(DispatcherPriority.Send, new nextStep(SerialEncoder), Data);
        }
        private void SerialEncoder(string Data)
        {
            SerialLib values = new SerialLib(Data);
            string command = values.getCommand;
            int number = values.getNumber;

            if (command.Equals("VoltDeg"))
                gauge.RectManipulation(number);
        }
    }
}
