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
    public class MongoDatabaseProxy : IMongoDatabase
    {
        private readonly MongoDatabase _mongoDatabase;

        public MongoDatabaseProxy(MongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;

            Server = new MongoServerProxy(mongoDatabase.Server);
        }

        public IMongoCollection<BsonDocument> CommandCollection
        {
            get { return new MongoCollectionProxy<BsonDocument>(_mongoDatabase.CommandCollection); }
        }

        public MongoCredentials Credentials
        {
            get { return _mongoDatabase.Credentials; }
        }

        public MongoGridFS GridFS
        {
            get { return _mongoDatabase.GridFS; }
        }

        public string Name
        {
            get { return _mongoDatabase.Name; }
        }

        public IMongoServer Server { get; private set; }

        public MongoDatabaseSettings Settings
        {
            get { return _mongoDatabase.Settings; }
        }

        IMongoCollection<BsonDocument> IMongoDatabase.this[string collectionName]
        {
            get { return  new MongoCollectionProxy<BsonDocument>(_mongoDatabase[collectionName]); }
        }

        IMongoCollection<BsonDocument> IMongoDatabase.this[string collectionName, SafeMode safeMode]
        {
            get { return new MongoCollectionProxy<BsonDocument>(_mongoDatabase[collectionName, safeMode]); }
        }

        public void AddUser(MongoCredentials credentials)
        {
            _mongoDatabase.AddUser(credentials);
        }

        public void AddUser(MongoCredentials credentials, bool readOnly)
        {
            _mongoDatabase.AddUser(credentials, readOnly);
        }

        public void AddUser(MongoUser user)
        {
            _mongoDatabase.AddUser(user);
        }

        public bool CollectionExists(string collectionName)
        {
            return _mongoDatabase.CollectionExists(collectionName);
        }

        public CommandResult CreateCollection(string collectionName)
        {
            return _mongoDatabase.CreateCollection(collectionName);
        }

        public CommandResult CreateCollection(string collectionName, IMongoCollectionOptions options)
        {
            return _mongoDatabase.CreateCollection(collectionName, options);
        }

        public MongoCollectionSettings<TDefaultDocument> CreateCollectionSettings<TDefaultDocument>(string collectionName)
        {
            return _mongoDatabase.CreateCollectionSettings<TDefaultDocument>(collectionName);
        }

        public MongoCollectionSettings CreateCollectionSettings(Type defaultDocumentType, string collectionName)
        {
            return _mongoDatabase.CreateCollectionSettings(defaultDocumentType, collectionName);
        }

        public void Drop()
        {
            _mongoDatabase.Drop();
        }

        public CommandResult DropCollection(string collectionName)
        {
            return _mongoDatabase.DropCollection(collectionName);
        }

        public BsonValue Eval(EvalFlags flags, BsonJavaScript code, object[] args)
        {
            return _mongoDatabase.Eval(flags, code, args);
        }

        public BsonValue Eval(BsonJavaScript code, object[] args)
        {
            return _mongoDatabase.Eval(code, args);
        }

        public BsonDocument FetchDBRef(MongoDBRef dbRef)
        {
            return _mongoDatabase.FetchDBRef(dbRef);
        }

        public TDocument FetchDBRefAs<TDocument>(MongoDBRef dbRef)
        {
            return _mongoDatabase.FetchDBRefAs<TDocument>(dbRef);
        }

        public object FetchDBRefAs(Type documentType, MongoDBRef dbRef)
        {
            return _mongoDatabase.FetchDBRefAs(documentType,dbRef);
        }

        public MongoUser[] FindAllUsers()
        {
            return _mongoDatabase.FindAllUsers();
        }

        public MongoUser FindUser(string username)
        {
            return _mongoDatabase.FindUser(username);
        }

        public IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(MongoCollectionSettings<TDefaultDocument> collectionSettings)
        {
            return new MongoCollectionProxy<TDefaultDocument>(_mongoDatabase.GetCollection(collectionSettings));
        }

        public IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName)
        {
            return new MongoCollectionProxy<TDefaultDocument>(_mongoDatabase.GetCollection<TDefaultDocument>(collectionName));
        }

        public IMongoCollection<TDefaultDocument> GetCollection<TDefaultDocument>(string collectionName, SafeMode safeMode)
        {
            return new MongoCollectionProxy<TDefaultDocument>(_mongoDatabase.GetCollection<TDefaultDocument>(collectionName, safeMode));
        }

        public IMongoCollection GetCollection(MongoCollectionSettings collectionSettings)
        {
            return new MongoCollectionProxy(_mongoDatabase.GetCollection(collectionSettings));
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return new MongoCollectionProxy<BsonDocument>(_mongoDatabase.GetCollection(collectionName));
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName, SafeMode safeMode)
        {
            return new MongoCollectionProxy<BsonDocument>(_mongoDatabase.GetCollection(collectionName, safeMode));
        }

        public IMongoCollection GetCollection(Type defaultDocumentType, string collectionName)
        {
            return  new MongoCollectionProxy( _mongoDatabase.GetCollection(defaultDocumentType, collectionName));
        }

        public IMongoCollection GetCollection(Type defaultDocumentType, string collectionName, SafeMode safeMode)
        {
            return new MongoCollectionProxy(_mongoDatabase.GetCollection(defaultDocumentType, collectionName, safeMode));
        }

        public IEnumerable<string> GetCollectionNames()
        {
            return _mongoDatabase.GetCollectionNames();
        }

        public BsonDocument GetCurrentOp()
        {
            return _mongoDatabase.GetCurrentOp();
        }

        public MongoGridFS GetGridFS(MongoGridFSSettings gridFSSettings)
        {
            return _mongoDatabase.GetGridFS(gridFSSettings);
        }

        public GetLastErrorResult GetLastError()
        {
            return _mongoDatabase.GetLastError();
        }

        public IMongoCursor<SystemProfileInfo> GetProfilingInfo(IMongoQuery query)
        {
            return new MongoCursorProxy<SystemProfileInfo>(_mongoDatabase.GetProfilingInfo(query));
        }

        public GetProfilingLevelResult GetProfilingLevel()
        {
            return _mongoDatabase.GetProfilingLevel();
        }

        public IMongoDatabase GetSisterDatabase(string databaseName)
        {
            return new MongoDatabaseProxy(_mongoDatabase.GetSisterDatabase(databaseName));
        }

        public DatabaseStatsResult GetStats()
        {
            return _mongoDatabase.GetStats();
        }

        public bool IsCollectionNameValid(string collectionName, out string message)
        {
            return _mongoDatabase.IsCollectionNameValid(collectionName, out message);
        }

        public void RemoveUser(MongoUser user)
        {
            _mongoDatabase.RemoveUser(user);
        }

        public void RemoveUser(string username)
        {
            _mongoDatabase.RemoveUser(username);
        }

        public CommandResult RenameCollection(string oldCollectionName, string newCollectionName)
        {
            return _mongoDatabase.RenameCollection(oldCollectionName, newCollectionName);
        }

        public CommandResult RenameCollection(string oldCollectionName, string newCollectionName, bool dropTarget)
        {
            return _mongoDatabase.RenameCollection(oldCollectionName, newCollectionName, dropTarget);
        }

        public CommandResult RenameCollection(string oldCollectionName, string newCollectionName, bool dropTarget, MongoCredentials adminCredentials)
        {
            return _mongoDatabase.RenameCollection(oldCollectionName, newCollectionName, dropTarget, adminCredentials);
        }

        public CommandResult RenameCollection(string oldCollectionName, string newCollectionName, MongoCredentials adminCredentials)
        {
            return _mongoDatabase.RenameCollection(oldCollectionName, newCollectionName, adminCredentials);
        }

        public void RequestDone()
        {
            _mongoDatabase.RequestDone();
        }

        public IDisposable RequestStart()
        {
            return _mongoDatabase.RequestStart();
        }

        public IDisposable RequestStart(bool slaveOk)
        {
            return _mongoDatabase.RequestStart(slaveOk);
        }

        public void ResetIndexCache()
        {
            _mongoDatabase.ResetIndexCache();
        }

        public CommandResult RunCommand(IMongoCommand command)
        {
            return _mongoDatabase.RunCommand(command);
        }

        public CommandResult RunCommand(string commandName)
        {
            return _mongoDatabase.RunCommand(commandName);
        }

        public TCommandResult RunCommandAs<TCommandResult>(IMongoCommand command) where TCommandResult : CommandResult, new()
        {
            return _mongoDatabase.RunCommandAs<TCommandResult>(command);
        }

        public TCommandResult RunCommandAs<TCommandResult>(string commandName) where TCommandResult : CommandResult, new()
        {
            return _mongoDatabase.RunCommandAs<TCommandResult>(commandName);
        }

        public CommandResult RunCommandAs(Type commandResultType, IMongoCommand command)
        {
            return _mongoDatabase.RunCommandAs(commandResultType, command);
        }

        public CommandResult RunCommandAs(Type commandResultType, string commandName)
        {
            return _mongoDatabase.RunCommandAs(commandResultType, commandName);
        }

        public CommandResult SetProfilingLevel(ProfilingLevel level)
        {
            return _mongoDatabase.SetProfilingLevel(level);
        }

        public CommandResult SetProfilingLevel(ProfilingLevel level, TimeSpan slow)
        {
            return _mongoDatabase.SetProfilingLevel(level, slow);
        }
    }
}
