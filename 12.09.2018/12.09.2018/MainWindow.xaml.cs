using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;


namespace _12._09._2018
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private ObservableCollection<Items_PRS> LP = new ObservableCollection<Items_PRS>();
        public bool _CheckPermit = false;
        string _PrcsId = null;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            Dispatcher.Invoke(new Action(delegate { DG_L(); }));
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        public void DG_L()
        {
            LP.Clear();
            foreach (Process PS in Process.GetProcesses())
            {
                LP.Add(new Items_PRS(PS.ProcessName, PS.Id.ToString(), PS.BasePriority.ToString(), PS.MainWindowTitle.ToString()));
            }
            DG.IsReadOnly = true;
            DG.ItemsSource = LP;
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window1 W_One = new Window1(this);

            if (_CheckPermit)
            {
                W_One.Dispatcher.Invoke(new Action(delegate { W_One.Show(); }));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           System.Windows.Forms.OpenFileDialog OFD = new System.Windows.Forms.OpenFileDialog();
            OFD.ShowDialog();
            Process.Start(OFD.FileName); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Process PS in Process.GetProcesses())
            {
                if (PS.Id.ToString().Contains(_PrcsId))
                {
                    PS.Kill();
                    break;
                }
            }
            _Kill.IsEnabled = false;
        }

        private void DG_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _Kill.IsEnabled = true;
                Items_PRS items_PRS = DG.SelectedItem as Items_PRS;
                _PrcsId = items_PRS.ProcessId;
            }
            catch
            {
                _Kill.IsEnabled = false;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(new Action(delegate { DG_L(); }));
            }
            catch(Exception exc)
            { MessageBox.Show(exc.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Shell32.Shell shell = new Shell32.Shell();
            shell.FileRun();
        }
    }
}
