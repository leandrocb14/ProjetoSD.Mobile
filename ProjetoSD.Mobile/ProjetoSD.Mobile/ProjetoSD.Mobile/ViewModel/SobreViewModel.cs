using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjetoSD.Mobile.ViewModel
{
    public class SobreViewModel
    {
        public string NumeroVersao { get { return GetVersion(); } }

        private string GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }
    }
}
