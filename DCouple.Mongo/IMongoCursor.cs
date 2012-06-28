//   Copyright 2012 Myles McDonnell (myles.mcdonnell.public@gmail.com)

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace DCouple.Mongo
{
    public interface IMongoCursor : IEnumerable
    {
        int BatchSize { get; }
        IMongoCollection Collection { get; }
        IMongoDatabase Database { get; }
        IMongoFields Fields { get; }
        QueryFlags Flags { get; }
        bool IsFrozen { get; }
        int Limit { get; }
        BsonDocument Options { get; }
        IMongoQuery Query { get; }
        IBsonSerializationOptions SerializationOptions { get; }
        IMongoServer Server { get; }
        int Skip { get; }
        bool SlaveOk { get; }
        IMongoCursor<TDocument> Clone<TDocument>();
        IMongoCursor Clone(Type documentType);
        long Count();
        BsonDocument Explain();
        BsonDocument Explain(bool verbose);
        IMongoCursor SetBatchSize(int batchSize);
        IMongoCursor SetFields(IMongoFields fields);
        IMongoCursor SetFields(string[] fields);
        IMongoCursor SetFlags(QueryFlags flags);
        IMongoCursor SetHint(BsonDocument hint);
        IMongoCursor SetHint(string indexName);
        IMongoCursor SetLimit(int limit);
        IMongoCursor SetMax(BsonDocument max);
        IMongoCursor SetMaxScan(int maxScan);
        IMongoCursor SetMin(BsonDocument min);
        IMongoCursor SetOption(string name, BsonValue value);
        IMongoCursor SetOptions(BsonDocument options);
        IMongoCursor SetSerializationOptions(IBsonSerializationOptions serializationOptions);
        IMongoCursor SetShowDiskLoc();
        IMongoCursor SetSkip(int skip);
        IMongoCursor SetSlaveOk(bool slaveOk);
        IMongoCursor SetSnapshot();
        IMongoCursor SetSortOrder(IMongoSortBy sortBy);
        IMongoCursor SetSortOrder(string[] keys);
        long Size();
    }

    public interface IMongoCursor<out TDocument> : IMongoCursor, IEnumerable<TDocument>
    {
        new IMongoCursor<TDocument> SetBatchSize(int batchSize);
        new IMongoCursor<TDocument> SetFields(IMongoFields fields);
        new IMongoCursor<TDocument> SetFields(string[] fields);
        new IMongoCursor<TDocument> SetFlags(QueryFlags flags);
        new IMongoCursor<TDocument> SetHint(BsonDocument hint);
        new IMongoCursor<TDocument> SetHint(string indexName);
        new IMongoCursor<TDocument> SetLimit(int limit);
        new IMongoCursor<TDocument> SetMax(BsonDocument max);
        new IMongoCursor<TDocument> SetMaxScan(int maxScan);
        new IMongoCursor<TDocument> SetMin(BsonDocument min);
        new IMongoCursor<TDocument> SetOption(string name, BsonValue value);
        new IMongoCursor<TDocument> SetOptions(BsonDocument options);
        new IMongoCursor<TDocument> SetSerializationOptions(IBsonSerializationOptions serializationOptions);
        new IMongoCursor<TDocument> SetShowDiskLoc();
        new IMongoCursor<TDocument> SetSkip(int skip);
        new IMongoCursor<TDocument> SetSlaveOk(bool slaveOk);
        new IMongoCursor<TDocument> SetSnapshot();
        new IMongoCursor<TDocument> SetSortOrder(IMongoSortBy sortBy);
        new IMongoCursor<TDocument> SetSortOrder(string[] keys);
    }
}

