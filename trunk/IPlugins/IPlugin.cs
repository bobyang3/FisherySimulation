using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPlugins;
using System.Data;
using System.Windows.Forms;
using System.Reflection;


namespace IPlugins
{
    // Event fired by the plugin on detecting motion
    public delegate void PluginEvent(object sender, EventArgs args);


    public interface IPlugin
    {
        /// <summary>
        /// Plugin Name (must have)
        /// </summary>
        string Name { get; }


        string Description { get; }
        string Author { get; }

        /// <summary>
        /// Plugin version (must have)
        /// </summary>
        string Version { get; }
        string DllfilePath { get; }
        bool refreshMainDataset { get; set; }
        DataSet dataset { get; set; }

        void startingPoint();

        event PluginEvent PluginMotion;

    }
}
