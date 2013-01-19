using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPlugins;
using System.Data;
using System.Windows.Forms;
using System.Reflection;


namespace FSPlugin1
{
    public class FSPlguin:IPlugin
    {
        #region IPlugin Members


        DataSet ds_from_main = new DataSet();
        bool refreshDataSet = true;

        public string Name
        {
            get { return "My first plugin"; }
        }

        public string Description
        {
            get { return "testing plug-in"; }
        }

        public string Author
        {
            get { return "Robert Yang"; }
        }

        public string Version
        {
            get { return "v1.0"; }
        }

        public string DllfilePath
        {
            get { return Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName; }
        }

        public bool refreshMainDataset
        {
            get
            {
                return refreshDataSet;
            }
            set
            {
                refreshDataSet = value;
            }
        }

        public DataSet dataset
        {
            get
            {
                return(ds_from_main);
            }
            set
            {
                ds_from_main = value;
            }
        }

        public void startingPoint()
        {
            MessageBox.Show("All plug-ins start here!! and you can start your own plugin for anything here!");
        }

        public event PluginEvent PluginMotion;

        #endregion
    }
}
