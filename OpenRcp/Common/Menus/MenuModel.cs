﻿using System.Collections.Generic;
using Caliburn.Micro;
using System.Linq;
namespace OpenRcp
{
	public class MenuModel : BindableCollection<MenuItemBase>, IMenu
	{
		public IEnumerable<MenuItemBase> All
		{
			get
			{
				var queue = new Queue<MenuItemBase>(this);
				while (queue.Count > 0)
				{
					var current = queue.Dequeue();
					foreach (var item in current)
						queue.Enqueue(item);
					yield return current;
				}
			}
		}

		public void Add(params MenuItemBase[] items)
		{
			items.Apply(Add);
		}


        public MenuItemBase this[string name]
        {
            get
            {
                return this.All.First(x => x.Name == name);
            }
        }
    }
}