﻿#region (c) 2010-2011 Lokad - CQRS for Windows Azure - New BSD License 

// Copyright (c) Lokad 2010-2011, http://www.lokad.com
// This code is released as Open Source under the terms of the New BSD Licence

#endregion

using System.IO;

namespace Lokad.Cqrs.Feature.StreamingStorage
{
    public delegate void ReaderDelegate(StreamingItemInfo props, Stream designationStream);
}