using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Win32;

namespace OpenRcp.Desktop.Demo.Modules.Startup
{
	[Export(typeof(IModule))]
	public class StartupModule : ModuleBase
	{
		[Import]
		private IOutput _output = null;

		[Import]
		private IResourceService _resourceManager = null;

		protected override void PreInit()
		{
			Shell.WindowState = WindowState.Maximized;
			Shell.Title = "OpenRcp Demo";
            Shell.StatusBar.Status = "就绪";
			Shell.StatusBar.Message = "Hello world!";
			Shell.Icon = _resourceManager.GetBitmap("Resources/Icon.png", 
				Assembly.GetExecutingAssembly().GetAssemblyName());

			_output.AppendLine("Demo Application Started up");
		}
	}
}