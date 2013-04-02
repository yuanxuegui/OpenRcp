using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace OpenRcp.Desktop.Exhibition.Modules
{
    [Export(typeof(IModule))]
    public class ExhibitionDesktopModule : ModuleBase
    {
        [Import]
        private IOutput _output = null;

        [Import]
        private IResourceService _resourceManager = null;

        protected override void PreInit()
        {
            Shell.WindowState = WindowState.Maximized;
            Shell.Title = "Exhibition Studio";
            Shell.StatusBar.Status = "就绪";
            Shell.StatusBar.Message = "欢迎使用Exhibition Studio!";
            Shell.Icon = _resourceManager.GetBitmap("Resources/Icon.png",
                Assembly.GetExecutingAssembly().GetAssemblyName());

            _output.AppendLine("Loading ExhibitionDesktop Module");
        }
    }
}
