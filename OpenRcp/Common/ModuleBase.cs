using System.ComponentModel.Composition;
using Caliburn.Micro;
namespace OpenRcp
{
	public abstract class ModuleBase : IModule
	{
		[Import]
		private IShell _shell = null;

		protected IShell Shell
		{
			get { return _shell; }
		}

		protected IMenu MainMenu
		{
			get { return _shell.MainMenu; }
		}
        [Import]
        private IEventAggregator _eventAggregator = null;
        [Import]
        private IResourceService _resourceService = null;

        protected void SubcribeMessage(object instance)
        {
            _eventAggregator.Subscribe(instance);
        }

        protected void PublishMessage(object message)
        {
            _eventAggregator.Publish(message);
        }

        protected virtual ModuleInfoItem GetModuleInfo()
        {
            return null;
        }

        protected virtual bool IsLoadModule()
        {
            return true;
        }

        protected virtual void PreInit()
        {

        }

        protected virtual void RegisterResources()
        {
        }

        protected void AddResource(IResource resource)
        {
            _resourceService.AddResource(resource);
        }

        protected virtual void RegisterCommands()
        {
        }

        protected virtual void RegisterMenus()
        {
        }

        protected virtual void RegisterToolbar()
        {
        }

        protected virtual void SetupModuleInfo()
        {
            ModuleInfoItem infoItem = GetModuleInfo();
            if (infoItem != null)
            {
                //TODO. 绑定信息到模块列表模板
            }
        }

        protected virtual void PostInit()
        {

        }

        #region IModule Implementation

        void IModule.Initialize()
        {
            if (IsLoadModule())
            {
                PreInit();
                RegisterCommands();
                RegisterResources();
                RegisterMenus();
                RegisterToolbar();
                SetupModuleInfo();
                PostInit();
            }
        }

        #endregion
	}
}