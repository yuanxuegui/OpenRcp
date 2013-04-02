using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;

namespace OpenRcp
{
	public class MenuItemBase : PropertyChangedBase, IEnumerable<MenuItemBase>
	{
		#region Static stuff

		public static MenuItemBase Separator
		{
			get { return new MenuItemSeparator(); }
		}

		#endregion

		#region Properties

		public IObservableCollection<MenuItemBase> Children { get; private set; }

		public virtual string Name
		{
			get { return "-"; }
		}

		#endregion

		#region Constructors

		protected MenuItemBase()
		{
			Children = new BindableCollection<MenuItemBase>();
		}

		#endregion

        public MenuItemBase Add(params MenuItemBase[] menuItems)
		{
			menuItems.Apply(Children.Add);
            return this;
		}

		public IEnumerator<MenuItemBase> GetEnumerator()
		{
			return Children.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}