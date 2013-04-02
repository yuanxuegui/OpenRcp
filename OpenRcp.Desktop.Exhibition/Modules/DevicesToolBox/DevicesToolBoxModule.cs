using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using OpenRcp.Desktop.Exhibition.Modules.DevicesToolBox.ViewModels;

namespace OpenRcp.Desktop.Exhibition.Modules.DevicesToolBox
{
    [Export(typeof(IModule))]
    public class DevicesToolBoxModule : ModuleBase
    {
        protected override void RegisterMenus()
        {
            base.RegisterMenus();
            MainMenu["View"].Add(new CheckableMenuItem("设备工具箱", openDevicesToolBox));
        }
        private IEnumerable<IResult> openDevicesToolBox(bool isChecked)
        {
            if (isChecked)
            {
                yield return ResultsHelper.ShowTool<DevicesToolBoxViewModel>();
            }
            else
            {
                yield return ResultsHelper.HideTool<DevicesToolBoxViewModel>();
            }
        }
    }
}
