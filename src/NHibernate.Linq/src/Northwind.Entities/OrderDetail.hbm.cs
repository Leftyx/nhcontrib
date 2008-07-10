﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace Northwind.Entities
{
	[Serializable]
	public class AbstractOrderDetail
	{
		public virtual OrderDetailKey PK_Order_Details { get; set; }

		public virtual float Discount { get; set; }

		public virtual short Quantity { get; set; }

		public virtual decimal UnitPrice { get; set; }

		#region Nested type: OrderDetailKey

		[Serializable]
		public class OrderDetailKey
		{
			public virtual Order Order { get; set; }

			public virtual Product Product { get; set; }

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (((obj == null)
				     || (obj == DBNull.Value)))
				{
					return false;
				}
				var entity = ((OrderDetailKey) (obj));
				return ((Order == entity.Order)
				        && (Product == entity.Product));
			}
		}

		#endregion
	}

	[Serializable]
	public class OrderDetail : AbstractOrderDetail
	{
	}
}