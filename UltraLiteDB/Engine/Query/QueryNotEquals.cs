﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraLiteDB
{
    /// <summary>
    /// Not is an Index Scan operation
    /// </summary>
    internal class QueryNotEquals : Query
    {
        private BsonValue _value;

        public QueryNotEquals(BsonValue value)
            : base()
        {
            _value = value;
        }

        internal override IEnumerable<IndexNode> ExecuteIndex(IndexService indexer, CollectionIndex index)
        {
            return indexer
                .FindAll(index, Query.Ascending)
                .Where(x => x.Key.CompareTo(_value) != 0);
        }

    }
}