using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace Fishery_Simulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //try
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //}
            //catch { }

            //AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            //{

            //    String resourceName = "AssemblyLoadingAndReflection." +

            //       new AssemblyName(args.Name).Name + ".dll";

            //    using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            //    {

            //        Byte[] assemblyData = new Byte[stream.Length];

            //        stream.Read(assemblyData, 0, assemblyData.Length);

            //        return Assembly.Load(assemblyData);

            //    }

            //};


     

        }



    }
}
