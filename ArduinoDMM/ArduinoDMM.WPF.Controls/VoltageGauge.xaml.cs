using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace ArduinoDMM.WPF.Controls
{
    public partial class VoltageGauge : UserControl
    {
        private double Radius = 300;

        public VoltageGauge()
        {
            InitializeComponent();
        }

        public void RectManipulation(int angle)
        {
            indicator.RenderTransform = new RotateTransform(angle, Radius, Radius);
        }
    }
}
