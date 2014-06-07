﻿using System.Collections.Generic;

namespace AcspNet.Meta
{
	/// <summary>
	/// Represent controllers meta store
	/// </summary>
	public interface IControllersMetaStore : IHideObjectMembers
	{
		/// <summary>
		/// Get controllers meta-data
		/// </summary>
		/// <returns></returns>
		IList<ControllerMetaContainer> GetControllersMetaData();
	}
}