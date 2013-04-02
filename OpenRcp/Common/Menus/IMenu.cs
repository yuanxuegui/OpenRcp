using System.Collections.Generic;
using Caliburn.Micro;

namespace OpenRcp
{
	public interface IMenu : IObservableCollection<MenuItemBase>
	{
		IEnumerable<MenuItemBase> All { get; }
        MenuItemBase this[string name] { get; }
	}
}