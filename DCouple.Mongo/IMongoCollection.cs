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
    public interface IMongoCollection
    {
        IMongoDatabase Database { get; }

        string FullName { get; }

        string Name { get; }

        MongoCollectionSettings Settings  { get; }

        long Count();

        long Count(IMongoQuery query);

        SafeModeResult CreateIndex(IMongoIndexKeys keys, IMongoIndexOptions options);

        SafeModeResult CreateIndex(IMongoIndexKeys keys);

        SafeModeResult CreateIndex(string[] keyNames);

        IEnumerable<BsonValue> Distinct(string key);

        IEnumerable<BsonValue> Distinct(string key, IMongoQuery query);

        CommandResult Drop();

        CommandResult DropAllIndexes();

        CommandResult DropIndex(IMongoIndexKeys keys);

        CommandResult DropIndex(string[] keyNames);

        CommandResult DropIndexByName(string indexName);

        void EnsureIndex(IMongoIndexKeys keys, IMongoIndexOptions options);

        void EnsureIndex(IMongoIndexKeys keys);

        void EnsureIndex(string[] keyNames);

        bool Exists();

        IMongoCursor<TDocument> FindAllAs<TDocument>();

        IMongoCursor FindAllAs(Type documentType);

        FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update);

        FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, bool returnNew);

        FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, bool returnNew, bool upsert);

        FindAndModifyResult FindAndModify(IMongoQuery query, IMongoSortBy sortBy, IMongoUpdate update, IMongoFields fields, bool returnNew, bool upsert);

        FindAndModifyResult FindAndRemove(IMongoQuery query, IMongoSortBy sortBy);

        IMongoCursor<TDocument> FindAs<TDocument>(IMongoQuery query);

        IMongoCursor FindAs(Type documentType, IMongoQuery query);

        TDocument FindOneAs<TDocument>();

        TDocument FindOneAs<TDocument>(IMongoQuery query);

        object FindOneAs(Type documentType);

        object FindOneAs(Type documentType, IMongoQuery query);

        TDocument FindOneByIdAs<TDocument>(BsonValue id);

        object FindOneByIdAs(Type documentType, BsonValue id);

        GeoHaystackSearchResult<TDocument> GeoHaystackSearchAs<TDocument>(double x, double y, IMongoGeoHaystackSearchOptions options);

        GeoHaystackSearchResult GeoHaystackSearchAs(Type documentType, double x, double y, IMongoGeoHaystackSearchOptions options);

        GeoNearResult<TDocument> GeoNearAs<TDocument>(IMongoQuery query, double x, double y, int limit);

        GeoNearResult<TDocument> GeoNearAs<TDocument>(IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options);

        GeoNearResult GeoNearAs(Type documentType, IMongoQuery query, double x, double y, int limit);

        GeoNearResult GeoNearAs(Type documentType, IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options);

        GetIndexesResult GetIndexes();

        CollectionStatsResult GetStats();

        long GetTotalDataSize();

        long GetTotalStorageSize();

        IEnumerable<BsonDocument> Group(IMongoQuery query, BsonJavaScript keyFunction, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize);

        IEnumerable<BsonDocument> Group(IMongoQuery query, IMongoGroupBy keys, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize);

        IEnumerable<BsonDocument> Group(IMongoQuery query, string key, BsonDocument initial, BsonJavaScript reduce, BsonJavaScript finalize);

        bool IndexExists(IMongoIndexKeys keys);

        bool IndexExists(string[] keyNames);

        bool IndexExistsByName(string indexName);

        SafeModeResult Insert<TNominalType>(TNominalType document);

        SafeModeResult Insert<TNominalType>(TNominalType document, MongoInsertOptions options);

        SafeModeResult Insert<TNominalType>(TNominalType document, SafeMode safeMode);

        SafeModeResult Insert(Type nominalType, object document);

        SafeModeResult Insert(Type nominalType, object document, MongoInsertOptions options);

        SafeModeResult Insert(Type nominalType, object document, SafeMode safeMode);

        IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents);

        IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents, MongoInsertOptions options);

        IEnumerable<SafeModeResult> InsertBatch<TNominalType>(IEnumerable<TNominalType> documents, SafeMode safeMode);

        IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents);

        IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents, SafeMode safeMode);

        IEnumerable<SafeModeResult> InsertBatch(Type nominalType, IEnumerable documents, MongoInsertOptions options);

        bool IsCapped();

        MapReduceResult MapReduce(BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options);

        MapReduceResult MapReduce(IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce, IMongoMapReduceOptions options);

        MapReduceResult MapReduce(IMongoQuery query, BsonJavaScript map, BsonJavaScript reduce);

        MapReduceResult MapReduce(BsonJavaScript map, BsonJavaScript reduce);

        CommandResult ReIndex();

        SafeModeResult Remove(IMongoQuery query);

        SafeModeResult Remove(IMongoQuery query, SafeMode safeMode);

        SafeModeResult Remove(IMongoQuery query, RemoveFlags flags);

        SafeModeResult Remove(IMongoQuery query, RemoveFlags flags, SafeMode safeMode);

        SafeModeResult RemoveAll();

        SafeModeResult RemoveAll(SafeMode safeMode);

        void ResetIndexCache();

        SafeModeResult Save<TNominalType>(TNominalType document);

        SafeModeResult Save<TNominalType>(TNominalType document, MongoInsertOptions options);

        SafeModeResult Save<TNominalType>(TNominalType document, SafeMode safeMode);

        SafeModeResult Save(Type nominalType, object document);

        SafeModeResult Save(Type nominalType, object document, MongoInsertOptions options);

        SafeModeResult Save(Type nominalType, object document, SafeMode safeMode);

        SafeModeResult Update(IMongoQuery query, IMongoUpdate update);

        SafeModeResult Update(IMongoQuery query, IMongoUpdate update, MongoUpdateOptions options);

        SafeModeResult Update(IMongoQuery query, IMongoUpdate update, SafeMode safeMode);

        SafeModeResult Update(IMongoQuery query, IMongoUpdate update, UpdateFlags flags);

        SafeModeResult Update(IMongoQuery query, IMongoUpdate update, UpdateFlags flags, SafeMode safeMode);

        ValidateCollectionResult Validate();
    }

    public interface IMongoCollection<TDefaultDocument> : IMongoCollection
    {
        IMongoCursor<TDefaultDocument> Find(IMongoQuery query);

        IMongoCursor<TDefaultDocument> FindAll();

        TDefaultDocument FindOne();

        TDefaultDocument FindOne(IMongoQuery query);

        TDefaultDocument FindOneById(BsonValue id);

        GeoHaystackSearchResult<TDefaultDocument> GeoHaystackSearch(double x, double y, IMongoGeoHaystackSearchOptions options);

        GeoNearResult<TDefaultDocument> GeoNear(IMongoQuery query, double x, double y, int limit);

        GeoNearResult<TDefaultDocument> GeoNear(IMongoQuery query, double x, double y, int limit, IMongoGeoNearOptions options);

        SafeModeResult Insert(TDefaultDocument document);

        SafeModeResult Insert(TDefaultDocument document, MongoInsertOptions options);

        SafeModeResult Insert(TDefaultDocument document, SafeMode safeMode);

        IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDefaultDocument> documents);

        IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDefaultDocument> documents, MongoInsertOptions options);

        IEnumerable<SafeModeResult> InsertBatch(IEnumerable<TDefaultDocument> documents, SafeMode safeMode);

        SafeModeResult Save(TDefaultDocument document);

        SafeModeResult Save(TDefaultDocument document, MongoInsertOptions options);

        SafeModeResult Save(TDefaultDocument document, SafeMode safeMode);
    }
}
