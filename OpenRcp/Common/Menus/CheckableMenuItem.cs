using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace OpenRcp
{
    public interface ICheckable
    {
        bool IsChecked { get; set; }
    }
    
    public class CheckableMenuItem : StandardMenuItem, ICheckable
	{
		private readonly Func<bool, IEnumerable<IResult>> _execute;

		private bool _isChecked;
		public bool IsChecked
		{
			get { return _isChecked; }
			set { _isChecked = value; NotifyOfPropertyChange(() => IsChecked); }
		}

		#region Constructors

		public CheckableMenuItem(string text)
			: base(text)
		{
			
		}

		public CheckableMenuItem(string text, Func<bool, IEnumerable<IResult>> execute)
			: base(text)
		{
			_execute = execute;
		}

		public CheckableMenuItem(string text, Func<bool, IEnumerable<IResult>> execute, Func<bool> canExecute)
			: base(text, canExecute)
		{
			_execute = execute;
		}

		#endregion

        public CheckableMenuItem Checked()
        {
            this.IsChecked = true;
            return this;
        }

        public CheckableMenuItem UnChecked()
        {
            this.IsChecked = false;
            return this;
        }

		public IEnumerable<IResult> Execute()
		{
			return _execute != null ? _execute(IsChecked) : new IResult[] { };
		}
	}
}