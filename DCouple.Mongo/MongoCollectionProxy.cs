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
using MongoDB.Driver;

namespace DCouple.Mongo
{
    public class MongoCollectionProxy : IMongoCollection
    {
        private readonly MongoCollection _collection;

        public MongoCollectionProxy(MongoCollection collection)
        {
            _collection = collection;

            Database = new MongoDatabaseProxy(_collection.Database);
        }

        public IMongoDatabase Database { get; private set; }

        public string FullName
        {
            get { return _collection.FullName; }
        }

        public string Name
        {
            get { return _collection.Name; }
        }

        public MongoCollectionSettings Settings
        {
            get { return _collection.Settings; }
        }

        public long Count()
        {
            return _collection.Count();
        }

        public long Count(IMongoQuery query)
        {
            return _collection.Count(query);
        }

        public SafeModeResult CreateIndex(IMongoIndexKeys keys, IMongoIndexOptions options)
        {
            return _collection.CreateIndex(keys, options);
        }

        public SafeModeResult CreateIndex(IMongoIndexKeys keys)
        {
            return _collection.CreateIndex(keys);
        }

        public SafeModeResult CreateIndex(string[] keyNames)
        {
            return _collection.CreateIndex(keyNames);
        }

        public IEnumerable<BsonValue> Distinct(string key)
        {
            return _collection.Distinct(key);
        }

        public IEnumerable<BsonValue> Distinct(string key, IMongoQuery query)
        {
            return _collection.Distinct(key, query);
        }

        public CommandResult Drop()
        {
            return _collection.Drop();
        }

        public CommandResult DropAllIndexes()
        {
            return _collection.DropAllIndexes();
        }

        public CommandResult DropIndex(IMongoIndexKeys keys)
        {
            return _collection.DropIndex(keys);
        }

        public CommandResult DropIndex(string[] keyNames)
        {
            return _collection.DropIndex(keyNames);
        }

        public CommandResult DropIndexByName(string indexName)
        {
            return _collection.DropIndexByName(indexName);
        }

        public void EnsureIndex(IMongoIndexKeys keys, IMongoIndexOptions options)
        {
            _collection.EnsureIndex(keys, options);
        }

        public void EnsureIndex(IMongoIndexKeys keys)
        {
            _collection.EnsureIndex(keys);
        }

        public void EnsureIndex(string[] keyNames)
        {
            _collection.EnsureIndex(keyNames);
        }

        public bool Exists()
        {
            return _collection.Exists();
        }

        public IMongoCursor<TDocument> FindAllAs<TDocument>()
        {
            return new MongoCursorProxy<TDocument>(_collection.FindAllAs<TDocument>());
        }

        public IMongoCursor FindAllAs(Type documentType)
        {
            return new MongoCursorProxy(_collection.FindAllAs(documentType));
        }

        public FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update)
        {
            return _collection.FindAndModify(query, sortBy, update);
        }

        public FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, bool returnNew)
        {
            return _collection.FindAndModify(query, sortBy, update, returnNew);
        }

        public FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, bool returnNew, bool upsert)
        {
            return _collection.FindAndModify(query, sortBy, update, returnNew, upsert);
        }

        public FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, IMongoFields fields, bool returnNew, bool upsert)
        {
            return _collection.FindAndModify(query, sortBy, update, fields, returnNew, upsert);
        }

        public FindAndModifyResult FindAndRemove(IMongoQuery query, IMongoSortBy sortBy)
        {
            return _collection.FindAndRemove(query, sortBy);
        }

        public IMongoCursor<TDocument> FindAs<TDocument>(IMongoQuery query)
        {
            return new MongoCursorProxy<TDocument>(_collection.FindAs<TDocument>(query));
        }

        public IMongoCursor FindAs(Type documentType, IMongoQuery query)
        {
            return new MongoCursorProxy(_collection.FindAs(documentType, query));
        }

        public TDocument FindOneAs<TDocument>()
        {
            return _collection.FindOneAs<TDocument>();
        }

        public TDocument FindOneAs<TDocument>(IMongoQuery query)
        {
            return _collection.FindOneAs<TDocument>(query);
        }

        public object FindOneAs(Type documentType)
        {
            return _collection.FindOneAs(documentType);
        }

        public object FindOneAs(Type documentType, IMongoQuery query)
        {
            return _collection.FindOneAs(documentType, query);
        }

        public TDocument FindOneByIdAs<TDocument>(BsonValue id)
        {
            return _collection.FindOneByIdAs<TDocument>(id);
        }

        public object FindOneByIdAs(Type documentType, BsonValue id)
        {
            return _collection.FindOneByIdAs(documentType, id);
        }

        public GeoHaystackSearchResult<TDocument> GeoHaystackSearchAs<TDocument>(double x, double y, IMongoGeoHaystackSearchOptions options)
        {
            return _collection.GeoHaystackSearchAs<TDocument>(x, y, options);
        }

        public GeoHaystackSearchResult GeoHaystackSearchAs(Type documentType, double x, double y, IMongoGeoHaystackSearchOptions options)
        {
            return _collection.GeoHaystackSearchAs(documentType, x, y, options);
        }

        public GeoNearResult<TDocument> GeoNearAs<TDocument>(IMongoQuery query, double x, double y, int limit)
        {
            return _collection.GeoNearAs<TDocument>(query, x, y, limit);
        }

        public GeoNearResult<TDocument> GeoNearAs<TDocument>(IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options)
        {
            return _collection.GeoNearAs<TDocument>(query, x, y, limit, options);
        }

        public GeoNearResult GeoNearAs(Type documentType, IMongoQuery query, double x, double y, int limit)
        {
            return _collection.GeoNearAs(documentType, query, x, y, limit);
        }

        public GeoNearResult GeoNearAs(Type documentType, IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options)
        {
            return _collection.GeoNearAs(documentType, query, x, y, limit, options);
        }

        public GetIndexesResult GetIndexes()
        {
            return _collection.GetIndexes();
        }

        public CollectionStatsResult GetStats()
        {
            return _collection.GetStats();
        }

        public long GetTotalDataSize()
        {
            return _collection.GetTotalDataSize();
        }

        public long GetTotalStorageSize()
        {
            return _collection.GetTotalStorageSize();
        }

        public IEnumerable<BsonDocument> Group(IMongoQuery query, BsonJavaScript keyFunction, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            return _collection.Group(query, keyFunction, initial, reduce, finalize);
        }

        public IEnumerable<BsonDocument> Group(IMongoQuery query, IMongoGroupBy keys, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            return _collection.Group(query, keys, initial, reduce, finalize);
        }

        public IEnumerable<BsonDocument> Group(IMongoQuery query, string key, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize)
        {
            return _collection.Group(query, key, initial, reduce, finalize);
        }

        public bool IndexExists(IMongoIndexKeys keys)
        {
            return _collection.IndexExists(keys);
        }

        public bool IndexExists(string[] keyNames)
        {
            return _collection.IndexExists(keyNames);
        }

        public bool IndexExistsByName(string indexName)
        {
            return _collection.IndexExistsByName(indexName);
        }

        public SafeModeResult Insert<TNominalType>(TNominalType document)
        {
            return _collection.Insert(document);
        }

        public SafeModeResult Insert<TNominalType>(TNominalType document, MongoInsertOptions options)
        {
            return _collection.Insert(document, options);
        }

        public SafeModeResult Insert<TNominalType>(TNominalType document, SafeMode safeMode)
        {
            return _collection.Insert(document, safeMode);
        }

        public SafeModeResult Insert(Type nominalType, object document)
        {
            return _collection.Insert(nominalType, document);
        }

        public SafeModeResult Insert(Type nominalType, object document, MongoInsertOptions options)
        {
            return _collection.Insert(nominalType, document, options);
        }

        public SafeModeResult Insert(Type nominalType, object document, SafeMode safeMode)
        {
            return _collection.Insert(nominalType, document, safeMode);
        }

        public IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents)
        {
            return _collection.InsertBatch(documents);
        }

        public IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents, MongoInsertOptions options)
        {
            return _collection.InsertBatch(documents, options);
        }

        public IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents, SafeMode safeMode)
        {
            return _collection.InsertBatch(documents, safeMode);
        }

        public IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents)
        {
            return _collection.InsertBatch(nominalType, documents);
        }

        public IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents, SafeMode safeMode)
        {
            return _collection.InsertBatch(nominalType, documents, safeMode);
        }

        public IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents, MongoInsertOptions options)
        {
            return _collection.InsertBatch(nominalType, documents, options);
        }

        public bool IsCapped()
        {
            return _collection.IsCapped();
        }

        public MapReduceResult MapReduce(BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options)
        {
            return _collection.MapReduce(map, reduce, options);
        }

        public MapReduceResult MapReduce(IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options)
        {
            return _collection.MapReduce(query, map, reduce, options);
        }

        public MapReduceResult MapReduce(IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce)
        {
            return _collection.MapReduce(query, map, reduce);
        }

        public MapReduceResult MapReduce(BsonJavaScript map, BsonJavaScript reduce)
        {
            return _collection.MapReduce(map, reduce);
        }

        public CommandResult ReIndex()
        {
            return _collection.ReIndex();
        }

        public SafeModeResult Remove(IMongoQuery query)
        {
            return _collection.Remove(query);
        }

        public SafeModeResult Remove(IMongoQuery query, SafeMode safeMode)
        {
            return _collection.Remove(query, safeMode);
        }

        public SafeModeResult Remove(IMongoQuery query, RemoveFlags flags)
        {
            return _collection.Remove(query, flags);
        }

        public SafeModeResult Remove(IMongoQuery query, RemoveFlags flags, SafeMode safeMode)
        {
            return _collection.Remove(query, flags, safeMode);
        }

        public SafeModeResult RemoveAll()
        {
            return _collection.RemoveAll();
        }

        public SafeModeResult RemoveAll(SafeMode safeMode)
        {
            return _collection.RemoveAll(safeMode);
        }

        public void ResetIndexCache()
        {
            _collection.ResetIndexCache();
        }

        public SafeModeResult Save<TNominalType>(TNominalType document)
        {
            return _collection.Save(document);
        }

        public SafeModeResult Save<TNominalType>(TNominalType document, MongoInsertOptions options)
        {
            return _collection.Save(document, options);
        }

        public SafeModeResult Save<TNominalType>(TNominalType document, SafeMode safeMode)
        {
            return _collection.Save(document, safeMode);
        }

        public SafeModeResult Save(Type nominalType, object document)
        {
            return _collection.Save(nominalType, document);
        }

        public SafeModeResult Save(Type nominalType, object document, MongoInsertOptions options)
        {
            return _collection.Save(nominalType, document, options);
        }

        public SafeModeResult Save(Type nominalType, object document, SafeMode safeMode)
        {
            return _collection.Save(nominalType, document, safeMode);
        }

        public SafeModeResult Update(IMongoQuery query, IMongoUpdate update)
        {
            return _collection.Update(query, update);
        }

        public SafeModeResult Update(IMongoQuery query, IMongoUpdate update, MongoUpdateOptions options)
        {
            return _collection.Update(query, update, options);
        }

        public SafeModeResult Update(IMongoQuery query, IMongoUpdate update, SafeMode safeMode)
        {
            return _collection.Update(query, update, safeMode);
        }

        public SafeModeResult Update(IMongoQuery query, IMongoUpdate update, UpdateFlags flags)
        {
            return _collection.Update(query, update, flags);
        }

        public SafeModeResult Update(IMongoQuery query, IMongoUpdate update, UpdateFlags flags, SafeMode safeMode)
        {
            return _collection.Update(query, update, flags, safeMode);
        }

        public ValidateCollectionResult Validate()
        {
            return _collection.Validate();
        }
    }

    public class MongoCollectionProxy<TDocument> : MongoCollectionProxy, IMongoCollection<TDocument>
    {
        private readonly MongoCollection<TDocument> _collection;

        public MongoCollectionProxy(MongoCollection<TDocument> collection) : base(collection)
        {
            _collection = collection;
        }

        public IMongoCursor<TDocument> Find(IMongoQuery query)
        {
            return new MongoCursorProxy<TDocument>(_collection.Find(query));
        }

        public IMongoCursor<TDocument> FindAll()
        {
            return new MongoCursorProxy<TDocument>(_collection.FindAll());
        }

        public TDocument FindOne()
        {
            return _collection.FindOne();
        }

        public TDocument FindOne(IMongoQuery query)
        {
            return _collection.FindOne(query);
        }

        public TDocument FindOneById(BsonValue id)
        {
            return _collection.FindOneById(id);
        }

        public GeoHaystackSearchResult<TDocument> GeoHaystackSearch(double x, double y, IMongoGeoHaystackSearchOptions options)
        {
            return _collection.GeoHaystackSearch(x, y, options);
        }

        public GeoNearResult<TDocument> GeoNear(IMongoQuery query, double x, double y, int limit)
        {
            return _collection.GeoNear(query, x, y, limit);
        }

        public GeoNearResult<TDocument> GeoNear(IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options)
        {
            return _collection.GeoNear(query, x, y, limit);
        }

        public SafeModeResult Insert(TDocument document)
        {
            return _collection.Insert(document);
        }

        public SafeModeResult Insert(TDocument document, MongoInsertOptions options)
        {
            return _collection.Insert(document, options);
        }

        public SafeModeResult Insert(TDocument document, SafeMode safeMode)
        {
            return _collection.Insert(document, safeMode);
        }

        public IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDocument> documents)
        {
            return _collection.InsertBatch(documents);
        }

        public IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDocument> documents, MongoInsertOptions options)
        {
            return _collection.InsertBatch(documents, options);
        }

        public IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDocument> documents, SafeMode safeMode)
        {
            return _collection.InsertBatch(documents, safeMode);
        }

        public SafeModeResult Save(TDocument document)
        {
            return _collection.Save(document);
        }

        public SafeModeResult Save(TDocument document, MongoInsertOptions options)
        {
            return _collection.Save(document, options);
        }

        public SafeModeResult Save(TDocument document, SafeMode safeMode)
        {
            return _collection.Save(document, safeMode);
        }
    }
}
