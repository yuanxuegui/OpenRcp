using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using OpenRcp.Desktop.Demo.Modules.Home.ViewModels;

namespace OpenRcp.Desktop.Demo.Modules.Home
{
	[Export(typeof(IModule))]
	public class HomeModule : ModuleBase
	{
        protected override void PreInit()
        {
            var homeViewModel = IoC.Get<HomeViewModel>();
            Shell.OpenDocument(homeViewModel);
        }

        protected override void RegisterMenus()
		{
            MainMenu["View"].Add(new CheckableMenuItem("Home", openHome).Checked());
		}

		private IEnumerable<IResult> openHome(bool isChecked)
		{
			if(isChecked)
                yield return ResultsHelper.OpenDocument<HomeViewModel>();
            else
                yield return ResultsHelper.CloseDocument<HomeViewModel>();
		}
	}
}