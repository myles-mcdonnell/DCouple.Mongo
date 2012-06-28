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
    public class MongoCursorProxy : IMongoCursor
    {
        private readonly MongoCursor _mongoMongoCursor;

        public MongoCursorProxy(MongoCursor mongoMongoCursor)
        {
            _mongoMongoCursor = mongoMongoCursor;
            Collection = new MongoCollectionProxy(_mongoMongoCursor.Collection);
            Database = new MongoDatabaseProxy(_mongoMongoCursor.Database);
            Server = new MongoServerProxy(_mongoMongoCursor.Server);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_mongoMongoCursor).GetEnumerator();
        }

        public int BatchSize
        {
            get { return _mongoMongoCursor.BatchSize; }
        }

        public IMongoCollection Collection { get; private set; }

        public IMongoDatabase Database { get; private set; }

        public IMongoFields Fields
        {
            get { return _mongoMongoCursor.Fields; }
        }

        public QueryFlags Flags
        {
            get { return _mongoMongoCursor.Flags; }
        }

        public bool IsFrozen
        {
            get { return _mongoMongoCursor.IsFrozen; }
        }

        public int Limit
        {
            get { return _mongoMongoCursor.Limit; }
        }

        public BsonDocument Options
        {
            get { return _mongoMongoCursor.Options; }
        }

        public IMongoQuery Query
        {
            get { return _mongoMongoCursor.Query; }
        }

        public IBsonSerializationOptions SerializationOptions
        {
            get { return _mongoMongoCursor.SerializationOptions; }
        }

        public IMongoServer Server { get; private set; }

        public int Skip
        {
            get { return _mongoMongoCursor.Skip; }
        }

        public bool SlaveOk
        {
            get { return _mongoMongoCursor.SlaveOk; }
        }

        public IMongoCursor<TDocument> Clone<TDocument>()
        {
            return new MongoCursorProxy<TDocument>(_mongoMongoCursor.Clone<TDocument>());
        }

        public IMongoCursor Clone(Type documentType)
        {
            return new MongoCursorProxy( _mongoMongoCursor.Clone(documentType) );
        }

        public long Count()
        {
            return _mongoMongoCursor.Count();
        }

        public BsonDocument Explain()
        {
            return _mongoMongoCursor.Explain();
        }

        public BsonDocument Explain(bool verbose)
        {
            return _mongoMongoCursor.Explain(verbose);
        }

        public IMongoCursor SetBatchSize(int batchSize)
        {
            return new MongoCursorProxy( _mongoMongoCursor.SetBatchSize(batchSize));
        }

        public IMongoCursor SetFields(IMongoFields fields)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetFields(fields));
        }

        public IMongoCursor SetFields(string[] fields)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetFields(fields));
        }

        public IMongoCursor SetFlags(QueryFlags flags)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetFlags(flags));
        }

        public IMongoCursor SetHint(BsonDocument hint)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetHint(hint));
        }

        public IMongoCursor SetHint(string indexName)
        {
            return new MongoCursorProxy( _mongoMongoCursor.SetHint(indexName));
        }

        public IMongoCursor SetLimit(int limit)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetLimit(limit));
        }

        public IMongoCursor SetMax(BsonDocument max)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetMax(max));
        }

        public IMongoCursor SetMaxScan(int maxScan)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetMaxScan(maxScan));
        }

        public IMongoCursor SetMin(BsonDocument min)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetMin(min));
        }

        public IMongoCursor SetOption(string name, BsonValue value)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetOption(name, value));
        }

        public IMongoCursor SetOptions(BsonDocument options)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetOptions(options));
        }

        public IMongoCursor SetSerializationOptions(IBsonSerializationOptions serializationOptions)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetSerializationOptions(serializationOptions));
        }

        public IMongoCursor SetShowDiskLoc()
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetShowDiskLoc());
        }

        public IMongoCursor SetSkip(int skip)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetSkip(skip));
        }

        public IMongoCursor SetSlaveOk(bool slaveOk)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetSlaveOk(slaveOk));
        }

        public IMongoCursor SetSnapshot()
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetSnapshot());
        }

        public IMongoCursor SetSortOrder(IMongoSortBy sortBy)
        {
            return new MongoCursorProxy(_mongoMongoCursor.SetSortOrder(sortBy));
        }

        public IMongoCursor SetSortOrder(string[] keys)
        {
            return new MongoCursorProxy( _mongoMongoCursor.SetSortOrder(keys));
        }

        public long Size()
        {
            return _mongoMongoCursor.Size();
        }
    }

    public class MongoCursorProxy<TDocument> : MongoCursorProxy, IMongoCursor<TDocument>
    {
        private readonly MongoCursor<TDocument> _mongoCursor;

        public MongoCursorProxy(MongoCursor<TDocument> mongoCursor) :base(mongoCursor)
        {
            _mongoCursor = mongoCursor;
        }

        public new IEnumerator<TDocument> GetEnumerator()
        {
            return _mongoCursor.GetEnumerator();
        }

        public new IMongoCursor<TDocument> SetBatchSize(int batchSize)
        {
            return new MongoCursorProxy<TDocument>(_mongoCursor.SetBatchSize(batchSize));
        }

        public new IMongoCursor<TDocument> SetFields(IMongoFields fields)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetFields(fields));
        }

        public new IMongoCursor<TDocument> SetFields(string[] fields)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetFields(fields));
        }

        public new IMongoCursor<TDocument> SetFlags(QueryFlags flags)
        {
            return  new MongoCursorProxy<TDocument>(_mongoCursor.SetFlags(flags));
        }

        public new IMongoCursor<TDocument> SetHint(BsonDocument hint)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetHint(hint));
        }

        public new IMongoCursor<TDocument> SetHint(string indexName)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetHint(indexName));
        }

        public new IMongoCursor<TDocument> SetLimit(int limit)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetLimit(limit));
        }

        public new IMongoCursor<TDocument> SetMax(BsonDocument max)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetMax(max));
        }

        public new IMongoCursor<TDocument> SetMaxScan(int maxScan)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetMaxScan(maxScan));
        }

        public new IMongoCursor<TDocument> SetMin(BsonDocument min)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetMin(min));
        }

        public new IMongoCursor<TDocument> SetOption(string name, BsonValue value)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetOption(name, value));
        }

        public new IMongoCursor<TDocument> SetOptions(BsonDocument options)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetOptions(options));
        }

        public new IMongoCursor<TDocument> SetSerializationOptions(IBsonSerializationOptions serializationOptions)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSerializationOptions(serializationOptions));
        }

        public new IMongoCursor<TDocument> SetShowDiskLoc()
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetShowDiskLoc());
        }

        public new IMongoCursor<TDocument> SetSkip(int skip)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSkip(skip));
        }

        public new IMongoCursor<TDocument> SetSlaveOk(bool slaveOk)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSlaveOk(slaveOk));
        }

        public new IMongoCursor<TDocument> SetSnapshot()
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSnapshot());
        }

        public new IMongoCursor<TDocument> SetSortOrder(IMongoSortBy sortBy)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSortOrder(sortBy));
        }

        public new IMongoCursor<TDocument> SetSortOrder(string[] keys)
        {
            return new MongoCursorProxy<TDocument>( _mongoCursor.SetSortOrder(keys));
        }
    }
}
