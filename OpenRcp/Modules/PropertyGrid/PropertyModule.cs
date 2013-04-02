using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;

namespace OpenRcp
{
	[Export(typeof(IModule))]
	public class PropertyModule : ModuleBase
	{
        protected override void PreInit()
        {
            IoC.Get<IEventAggregator>().Publish(new ModuleInitMessage
            {
                Content = "Loading Property Module"
            });
        }
        
        protected override void RegisterMenus()
		{
			MainMenu.All.First(x => x.Name == "View")
				.Add(new MenuItem("Properties", OpenProperties).WithIcon(@"Modules\PropertyGrid\Resources\Icons\Properties.png"));
		}

		private static IEnumerable<IResult> OpenProperties()
		{
			yield return ResultsHelper.ShowTool<IPropertyGrid>();
		}
	}
}