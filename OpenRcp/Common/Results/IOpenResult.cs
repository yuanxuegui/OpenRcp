﻿using System;
using Caliburn.Micro;

namespace OpenRcp
{
	public interface IOpenResult<TChild> : IResult
	{
		Action<TChild> OnConfigure { get; set; }
		Action<TChild> OnShutDown { get; set; }
	}
}