using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;

namespace OpenRcp
{
    [Export(typeof(IModule))]
    public class OutputModule : ModuleBase, IHandle<IMessage>
    {
        protected override void PreInit()
        {
            var outputTool = IoC.Get<IOutput>();
            Shell.ShowTool(outputTool);
            
            SubcribeMessage(this);
            PublishMessage(new ModuleInitMessage
            {
                Content = "Loading Output Module"
            });
        }

        protected override void RegisterMenus()
        {
            MainMenu["View"].Add(new CheckableMenuItem("Output", OpenOutput).Checked());
        }

        private IEnumerable<IResult> OpenOutput(bool isChecked)
        {
            if(isChecked)
                yield return ResultsHelper.ShowTool<IOutput>();
            else
                yield return ResultsHelper.HideTool<IOutput>();
        }

        public void Handle(IMessage message)
        {
            IoC.Get<IOutput>().AppendLine(message.Content);
        }
    }
}