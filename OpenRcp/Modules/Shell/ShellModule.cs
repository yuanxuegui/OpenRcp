using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using Caliburn.Micro;
using Microsoft.Win32;

namespace OpenRcp
{
    [Export(typeof(IModule))]
    public class ShellModule : ModuleBase
    {
        protected override void PreInit()
        {
            PublishMessage(new ModuleInitMessage
            {
                Content = "Loading Shell Module"
            });
        }

        protected override void RegisterResources()
        {
            base.RegisterResources();

            ResourceBase res = new ResourceBase("OpenRcp.Modules.Shell.Resources.StringResource");
            AddResource(res);
        }


        protected override void RegisterMenus()
        {
            MainMenu["File"].Add(
                new MenuItem("_Open", openFile)
                .WithIcon(@"Modules\Shell\Resources\Icons\Open.png")
                .WithGlobalShortcut(ModifierKeys.Control, Key.O)).Add(MenuItemBase.Separator).Add(new MenuItem("E_xit", exit, canExit));

            MainMenu["Edit"].Add(new MenuItem("Undo").WithGlobalShortcut(ModifierKeys.Control, Key.Z));
        }

        protected override ModuleInfoItem GetModuleInfo()
        {
            var item = new ModuleInfoItem
            {
                Name = OpenRcp.Properties.Resources.Shell_ModuleInfo_Name,
                HeaderInfo = OpenRcp.Properties.Resources.Shell_ModuleInfo_Header,
                Authors = OpenRcp.Properties.Resources.Shell_ModuleInfo_Authors,
                Description = OpenRcp.Properties.Resources.Shell_ModuleInfo_Description,
                Version = string.Format(OpenRcp.Properties.Resources.Shell_ModuleInfo_Version, Assembly.GetExecutingAssembly().GetName().Version, IntPtr.Size * 8),
                CopyrightNotice = OpenRcp.Properties.Resources.Shell_ModuleInfo_Copyright,
                Rights = OpenRcp.Properties.Resources.Shell_ModuleInfo_Rights
            };
            return item;
        }

        private IEnumerable<IResult> openFile()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "文本文件(*.txt)|*.txt|XML文件(*.xml)|*.xml|所有文件|*.*";
            yield return ResultsHelper.ShowDialog(dialog);
            yield return ResultsHelper.OpenDocument(dialog.FileName);
        }

        private bool canExit()
        {
            return false;
        }

        private IEnumerable<IResult> exit()
        {
            Shell.Close();
            yield break;
        }

        private IEnumerable<IResult> openAboutDialog()
        {
            var dialog = new OpenFileDialog();
            yield return ResultsHelper.ShowDialog(dialog); ;
        }
    }
}