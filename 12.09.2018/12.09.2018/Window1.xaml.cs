using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace _12._09._2018
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1( MainWindow _LALAL)
        {
            InitializeComponent();
            try
            {
                Items_PRS items_PRS = _LALAL.DG.SelectedItem as Items_PRS;

                ProcessModuleCollection PMC = null;
                foreach (Process PS in Process.GetProcesses())
                {
                    if (PS.ProcessName.Contains(items_PRS.ProcessName))
                    {
                        PMC = PS.Modules;
                        break;
                    }
                }
                DG_W.ItemsSource = PMC;
                _LALAL._CheckPermit = true;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
                _LALAL._CheckPermit = false;
            }
        }
    }
}
