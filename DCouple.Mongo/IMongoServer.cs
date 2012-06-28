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
using MongoDB.Driver.Internal;

namespace DCouple.Mongo
{
    public interface IMongoServer
    {
        MongoServerInstance[] Arbiters { get; }
        MongoServerBuildInfo BuildInfo { get; }
        int ConnectionAttempt { get; }
        IndexCache IndexCache { get; }
        MongoServerInstance Instance { get; }
        MongoServerInstance[] Instances { get; }
        MongoServerInstance[] Passives { get; }
        MongoServerInstance Primary { get; }
        string ReplicaSetName { get; }
        MongoConnection RequestConnection { get; }
        int RequestNestingLevel { get; }
        MongoServerInstance[] Secondaries { get; }
        int SequentialId { get; }
        MongoServerSettings Settings { get; }
        MongoServerState State { get; }
        IMongoDatabase this[string databaseName] { get; }
        IMongoDatabase this[string databaseName, MongoCredentials credentials] { get; }
        IMongoDatabase this[MongoDatabaseSettings databaseSettings] { get; }
        IMongoDatabase this[string databaseName, MongoCredentials credentials, SafeMode safeMode] { get; }
        IMongoDatabase this[string databaseName, SafeMode safeMode] { get; }
        void Connect();
        void Connect(ConnectWaitFor waitFor);
        void Connect(TimeSpan timeout);
        void Connect(TimeSpan timeout, ConnectWaitFor waitFor);
        void CopyDatabase(string from, string to);
        MongoDatabaseSettings CreateDatabaseSettings(string databaseName);
        bool DatabaseExists(string databaseName);
        bool DatabaseExists(string databaseName, MongoCredentials adminCredentials);
        void Disconnect();
        CommandResult DropDatabase(string databaseName);
        CommandResult DropDatabase(string databaseName, MongoCredentials credentials);
        BsonDocument FetchDBRef(MongoDBRef dbRef);
        TDocument FetchDBRefAs<TDocument>(MongoDBRef dbRef);
        object FetchDBRefAs(Type documentType, MongoDBRef dbRef);
        IMongoDatabase GetDatabase(MongoDatabaseSettings databaseSettings);
        IMongoDatabase GetDatabase(string databaseName);
        IMongoDatabase GetDatabase(string databaseName, MongoCredentials credentials);
        IMongoDatabase GetDatabase(string databaseName, MongoCredentials credentials, SafeMode safeMode);
        IMongoDatabase GetDatabase(string databaseName, SafeMode safeMode);
        IEnumerable<string> GetDatabaseNames();
        IEnumerable<string> GetDatabaseNames(MongoCredentials adminCredentials);
        GetLastErrorResult GetLastError();
        GetLastErrorResult GetLastError(MongoCredentials adminCredentials);
        bool IsDatabaseNameValid(string databaseName, out string message);
        void Ping();
        void Reconnect();
        void RequestDone();
        IDisposable RequestStart(IMongoDatabase initialDatabase);
        IDisposable RequestStart(IMongoDatabase initialDatabase, bool slaveOk);
        IDisposable RequestStart(IMongoDatabase initialDatabase, MongoServerInstance serverInstance);
        void ResetIndexCache();
        void Shutdown();
        void Shutdown(MongoCredentials adminCredentials);
        void VerifyState();
    }
}