using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lucidity
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            //FIXME: Can't figure out how to maximize better, since 
            //I can't be arsed to look up how this is done in xaml.
            this.MainWindow.WindowState = WindowState.Maximized;
        }
    }
}
