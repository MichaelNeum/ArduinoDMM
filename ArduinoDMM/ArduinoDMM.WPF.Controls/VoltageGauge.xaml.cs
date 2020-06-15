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

namespace ArduinoDMM.WPF.Controls
{
    public partial class VoltageGauge : UserControl
    {
        public VoltageGauge()
        {
            InitializeComponent();
        }

        public void RectManipulation(int angle)
        {
            PointerRect.RenderTransform = new RotateTransform(angle, PointerRect.Width, PointerRect.Height / 2);
        }
    }
}
