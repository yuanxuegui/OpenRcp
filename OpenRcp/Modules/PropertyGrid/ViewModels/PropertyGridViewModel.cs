using System;
using System.ComponentModel.Composition;

namespace OpenRcp
{
	[Export(typeof(IPropertyGrid))]
	public class PropertyGridViewModel : Tool, IPropertyGrid
	{
		public override string DisplayName
		{
			get { return "Properties"; }
		}

		public override PaneLocation PreferredLocation
		{
			get { return PaneLocation.Right; }
		}

		public override Uri IconSource
		{
			get { return new Uri("pack://application:,,,/OpenRcp;component/Workbench/Resources/Icons/Properties.png"); }
		}

		private object _selectedObject;
		public object SelectedObject
		{
			get { return _selectedObject; }
			set
			{
				_selectedObject = value;
				NotifyOfPropertyChange(() => SelectedObject);
			}
		}
	}
}