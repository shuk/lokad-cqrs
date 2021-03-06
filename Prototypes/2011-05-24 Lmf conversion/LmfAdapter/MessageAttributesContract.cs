﻿using System;
using ProtoBuf;

namespace LmfAdapter
{
	[ProtoContract]
	public sealed class MessageAttributesContract
	{
		[ProtoMember(1, DataFormat = DataFormat.Default)]
		public readonly MessageAttributeContract[] Items;

		public MessageAttributesContract(MessageAttributeContract[] items)
		{
			Items = items;
		}

		MessageAttributesContract()
		{
			Items = new MessageAttributeContract[0];
		}

		public Maybe<string> GetAttributeString(MessageAttributeTypeContract type)
		{
			for (int i = Items.Length - 1; i >= 0; i--)
			{
				var item = Items[i];
				if (item.Type == type)
				{
					var value = item.StringValue;
					if (value == null)
						throw new InvalidOperationException("String attribute can't be null");
					return value;
				}
			}
			return Maybe<string>.Empty;
		}

		public Maybe<DateTime> GetAttributeDate(MessageAttributeTypeContract type)
		{
			for (int i = Items.Length - 1; i >= 0; i--)
			{
				var item = Items[i];
				if (item.Type == type)
				{
					var value = item.NumberValue;
					if (value == 0)
						throw new InvalidOperationException("Date attribute can't be empty");
					return DateTime.FromBinary(value);
				}
			}
			return Maybe<DateTime>.Empty;
		}
	}
}