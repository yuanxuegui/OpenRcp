using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace OpenRcp
{
   
    public class RadioMenuItem : StandardMenuItem, ICheckable
	{
		private readonly Func<bool, IEnumerable<IResult>> _execute;

        public IList<RadioMenuItem> Group { get; private set; }

        private bool _isChecked;
		public bool IsChecked
		{
			get { return _isChecked; }
			set { _isChecked = value; NotifyOfPropertyChange(() => IsChecked); }
		}

		#region Constructors

        public RadioMenuItem(string text)
            : base(text)
        {

        }

        public RadioMenuItem(string text, IList<RadioMenuItem> group)
			: base(text)
		{
            Group = group;
            Group.Add(this);
		}

        public RadioMenuItem(string text, IList<RadioMenuItem> group, Func<bool, IEnumerable<IResult>> execute)
			: this(text, group)
		{
			_execute = execute;
		}

        public RadioMenuItem(string text, IList<RadioMenuItem> group, Func<bool, IEnumerable<IResult>> execute, Func<bool> canExecute)
            : this(text, group, execute)
        {
            _execute = execute;
        }

		#endregion

		public IEnumerable<IResult> Execute()
		{
            if (IsChecked)
            {
                // unCheck group other
                foreach (RadioMenuItem rd in Group)
                {
                    if(!rd.Text.Equals(this.Text))
                        rd.IsChecked = false;
                }
            }
            return _execute != null ? _execute(IsChecked) : new IResult[] { };
		}
	}
}