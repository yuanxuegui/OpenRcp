﻿using System;
using Caliburn.Micro;
using Microsoft.Win32;

namespace OpenRcp
{
	public class ShowCommonDialogResult : IResult
	{
		public event EventHandler<ResultCompletionEventArgs> Completed;

		private readonly CommonDialog _commonDialog;

		public ShowCommonDialogResult(CommonDialog commonDialog)
		{
			_commonDialog = commonDialog;
		}

		public void Execute(ActionExecutionContext context)
		{
			var result = _commonDialog.ShowDialog().GetValueOrDefault(false);
			Completed(this, new ResultCompletionEventArgs { WasCancelled = !result });
		}
	}
}