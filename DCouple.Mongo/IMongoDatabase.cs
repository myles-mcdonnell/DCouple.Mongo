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
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DCouple.Mongo
{
    public interface IMongoDatabase
    {
        IMongoCollection<BsonDocument> CommandCollection { get; }
        MongoCredentials Credentials { get; }
        MongoGridFS GridFS { get; }
        IMongoCollection<BsonDocument> this[string collectionName] { get; }
        IMongoCollection<BsonDocument> this[string collectionName, SafeMode safeMode] { get; }
        string Name { get; }
        IMongoServer Server { get; }
        MongoDatabaseSettings Settings { get; }
        void AddUser(MongoCredentials credentials);
        void AddUser(MongoCredentials credentials, bool readOnly);
        void AddUser(MongoUser user);
        bool CollectionExists(string collectionName);
        CommandResult CreateCollection(string collectionName);
        CommandResult CreateCollection(string collectionName, IMongoCollectionOptions options);
        MongoCollectionSettings<TDefaultDocument> CreateCollectionSettings<TDefaultDocument>(string collectionName);
        MongoCollectionSettings CreateCollectionSettings(Type defaultDocumentType, string collectionName);
        void Drop();
        CommandResult DropCollection(string collectionName);
        BsonValue Eval(EvalFlags flags, BsonJavaScript code, object[] args);
        BsonValue Eval(BsonJavaScript code, object[] args);
        BsonDocument FetchDBRef(MongoDBRef dbRef);
        TDocument FetchDBRefAs<TDocument>(MongoDBRef dbRef);
        object FetchDBRefAs(Type documentType, MongoDBRef dbRef);
        MongoUser[] FindAllUsers();
        MongoUser FindUser(string username);
        IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(MongoCollectionSettings<TDefaultDocument> collectionSettings);
        IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName);
        IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName, SafeMode safeMode);
        IMongoCollection GetCollection(MongoCollectionSettings collectionSettings);
        IMongoCollection<BsonDocument> GetCollection(string collectionName);
        IMongoCollection<BsonDocument> GetCollection(string collectionName, SafeMode safeMode);
        IMongoCollection GetCollection(Type defaultDocumentType, string collectionName);
        IMongoCollection GetCollection(Type defaultDocumentType, string collectionName, SafeMode safeMode);
        IEnumerable<string> GetCollectionNames();
        BsonDocument GetCurrentOp();
        MongoGridFS GetGridFS(MongoGridFSSettings gridFSSettings);
        GetLastErrorResult GetLastError();
        IMongoCursor<SystemProfileInfo> GetProfilingInfo(IMongoQuery query);
        GetProfilingLevelResult GetProfilingLevel();
        IMongoDatabase GetSisterDatabase(string databaseName);
        DatabaseStatsResult GetStats();
        bool IsCollectionNameValid(string collectionName, out string message);
        void RemoveUser(MongoUser user);
        void RemoveUser(string username);
        CommandResult RenameCollection(string oldCollectionName, string newCollectionName);
        CommandResult RenameCollection(string oldCollectionName, string newCollectionName, bool dropTarget);
        CommandResult RenameCollection(string oldCollectionName, string newCollectionName, bool dropTarget, MongoCredentials adminCredentials);
        CommandResult RenameCollection(string oldCollectionName, string newCollectionName, MongoCredentials adminCredentials);
        void RequestDone();
        IDisposable RequestStart();
        IDisposable RequestStart(bool slaveOk);
        void ResetIndexCache();
        CommandResult RunCommand(IMongoCommand command);
        CommandResult RunCommand(string commandName);
        TCommandResult RunCommandAs<TCommandResult>(IMongoCommand command) where TCommandResult : CommandResult, new();
        TCommandResult RunCommandAs<TCommandResult>(string commandName) where TCommandResult : CommandResult, new();
        CommandResult RunCommandAs(Type commandResultType, IMongoCommand command);
        CommandResult RunCommandAs(Type commandResultType, string commandName);
        CommandResult SetProfilingLevel(ProfilingLevel level);
        CommandResult SetProfilingLevel(ProfilingLevel level, TimeSpan slow);
        string ToString();
    }
}
