﻿using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace OpenRcp
{
	public class ShowToolResult<TTool> : OpenResultBase<TTool>
		where TTool : ITool
	{
		private readonly Func<TTool> _toolLocator = () => IoC.Get<TTool>();

		[Import]
		private IShell _shell = null;

		public ShowToolResult()
		{
			
		}

		public ShowToolResult(TTool tool)
		{
			_toolLocator = () => tool;
		}

		public override void Execute(ActionExecutionContext context)
		{
			var tool = _toolLocator();

			if (_setData != null)
				_setData(tool);

			if (_onConfigure != null)
				_onConfigure(tool);

			tool.Deactivated += (s, e) =>
			{

				if (!e.WasClosed)
					return;

				if (_onShutDown != null)
					_onShutDown(tool);

				OnCompleted(null);
			};

			_shell.ShowTool(tool);
		}
	}
}