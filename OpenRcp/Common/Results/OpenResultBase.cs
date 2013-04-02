﻿using System;
using Caliburn.Micro;

namespace OpenRcp
{
	public abstract class OpenResultBase<TTarget> : IOpenResult<TTarget>
	{
		protected Action<TTarget> _setData;
		protected Action<TTarget> _onConfigure;
		protected Action<TTarget> _onShutDown;

		Action<TTarget> IOpenResult<TTarget>.OnConfigure
		{
			get { return _onConfigure; }
			set { _onConfigure = value; }
		}

		Action<TTarget> IOpenResult<TTarget>.OnShutDown
		{
			get { return _onShutDown; }
			set { _onShutDown = value; }
		}

		//void IOpenResult<TTarget>.SetData<TData>(TData data)
		//{
		//    _setData = child =>
		//    {
		//        var dataCentric = (IDataCentric<TData>)child;
		//        dataCentric.LoadData(data);
		//    };
		//}

		protected virtual void OnCompleted(Exception exception)
		{
			if (Completed != null)
				Completed(this, new ResultCompletionEventArgs { Error = exception });
		}

		public abstract void Execute(ActionExecutionContext context);

		public event EventHandler<ResultCompletionEventArgs> Completed;
	}
}