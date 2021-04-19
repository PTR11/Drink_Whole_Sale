﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DrinkWholeSale.Web
{
    public class ApplicationState
    {
		private long _userCount;

		// Szálbiztos kezelés
		public long UserCount
		{
			get => Interlocked.Read(ref _userCount);
			set => Interlocked.Exchange(ref _userCount, value);
		}
	}
}
