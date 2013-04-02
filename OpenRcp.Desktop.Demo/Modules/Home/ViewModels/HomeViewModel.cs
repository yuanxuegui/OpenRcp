using System.ComponentModel.Composition;
using System.Windows.Media;

namespace OpenRcp.Desktop.Demo.Modules.Home.ViewModels
{
	[Export(typeof(HomeViewModel))]
	public class HomeViewModel : Document, IPropertySelectable
	{
		private Color _background;
		public Color Background
		{
			get { return _background; }
			set
			{
				_background = value;
				NotifyOfPropertyChange(() => Background);
			}
		}

		private Color _foreground;
		public Color Foreground
		{
			get { return _foreground; }
			set
			{
				_foreground = value;
				NotifyOfPropertyChange(() => Foreground);
			}
		}

		public override string DisplayName
		{
			get { return "Home"; }
		}

		public HomeViewModel()
		{
			Background = Colors.CornflowerBlue;
			Foreground = Colors.White;
		}

        public object SelectProperty()
        {
            return this;
        }
    }
}