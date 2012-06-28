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
    public class MongoServerProxy : IMongoServer
    {
        private readonly MongoServer _mongoServer;

        public MongoServerProxy(MongoServer mongoServer)
        {
            _mongoServer = mongoServer;
        }

        public MongoServerInstance[] Arbiters
        {
            get { return _mongoServer.Arbiters; }
        }

        public MongoServerBuildInfo BuildInfo
        {
            get { return _mongoServer.BuildInfo; }
        }

        public int ConnectionAttempt
        {
            get { return _mongoServer.ConnectionAttempt; }
        }

        public IndexCache IndexCache
        {
            get { return _mongoServer.IndexCache; }
        }

        public MongoServerInstance Instance
        {
            get { return _mongoServer.Instance; }
        }

        public MongoServerInstance[] Instances
        {
            get { return _mongoServer.Instances; }
        }

        public MongoServerInstance[] Passives
        {
            get { return _mongoServer.Passives; }
        }

        public MongoServerInstance Primary
        {
            get { return _mongoServer.Primary; }
        }

        public string ReplicaSetName
        {
            get { return _mongoServer.ReplicaSetName; }
        }

        public MongoConnection RequestConnection
        {
            get { return _mongoServer.RequestConnection; }
        }

        public int RequestNestingLevel
        {
            get { return _mongoServer.RequestNestingLevel; }
        }

        public MongoServerInstance[] Secondaries
        {
            get { return _mongoServer.Secondaries; }
        }

        public int SequentialId
        {
            get { return _mongoServer.SequentialId; }
        }

        public MongoServerSettings Settings
        {
            get { return _mongoServer.Settings; }
        }

        public MongoServerState State
        {
            get { return _mongoServer.State; }
        }

        IMongoDatabase IMongoServer.this[string databaseName]
        {
            get { return new MongoDatabaseProxy(_mongoServer[databaseName]); }
        }

        IMongoDatabase IMongoServer.this[string databaseName, MongoCredentials credentials]
        {
            get { return new MongoDatabaseProxy(_mongoServer[databaseName, credentials]); }
        }

        IMongoDatabase IMongoServer.this[MongoDatabaseSettings databaseSettings]
        {
            get { return new MongoDatabaseProxy(_mongoServer[databaseSettings]); }
        }

        IMongoDatabase IMongoServer.this[string databaseName, MongoCredentials credentials, SafeMode safeMode]
        {
            get { return new MongoDatabaseProxy(_mongoServer[databaseName, credentials, safeMode]); }
        }

        IMongoDatabase IMongoServer.this[string databaseName, SafeMode safeMode]
        {
            get { return new MongoDatabaseProxy(_mongoServer[databaseName, safeMode]); }
        }

        public void Connect()
        {
            _mongoServer.Connect();
        }

        public void Connect(ConnectWaitFor waitFor)
        {
            _mongoServer.Connect(waitFor);
        }

        public void Connect(TimeSpan timeout)
        {
            _mongoServer.Connect(timeout);
        }

        public void Connect(TimeSpan timeout, ConnectWaitFor waitFor)
        {
            _mongoServer.Connect(timeout, waitFor);
        }

        public void CopyDatabase(string @from, string to)
        {
            _mongoServer.CopyDatabase(@from, to);
        }

        public MongoDatabaseSettings CreateDatabaseSettings(string databaseName)
        {
            return _mongoServer.CreateDatabaseSettings(databaseName);
        }

        public bool DatabaseExists(string databaseName)
        {
            return _mongoServer.DatabaseExists(databaseName);
        }

        public bool DatabaseExists(string databaseName, MongoCredentials adminCredentials)
        {
            return _mongoServer.DatabaseExists(databaseName, adminCredentials);
        }

        public void Disconnect()
        {
            _mongoServer.Disconnect();
        }

        public CommandResult DropDatabase(string databaseName)
        {
            return _mongoServer.DropDatabase(databaseName);
        }

        public CommandResult DropDatabase(string databaseName, MongoCredentials credentials)
        {
            return _mongoServer.DropDatabase(databaseName, credentials);
        }

        public BsonDocument FetchDBRef(MongoDBRef dbRef)
        {
            return _mongoServer.FetchDBRef(dbRef);
        }

        public TDocument FetchDBRefAs<TDocument>(MongoDBRef dbRef)
        {
            return _mongoServer.FetchDBRefAs<TDocument>(dbRef);
        }

        public object FetchDBRefAs(Type documentType, MongoDBRef dbRef)
        {
            return _mongoServer.FetchDBRefAs(documentType, dbRef);
        }

        public IMongoDatabase GetDatabase(MongoDatabaseSettings databaseSettings)
        {
            return new MongoDatabaseProxy(_mongoServer.GetDatabase(databaseSettings));
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return new MongoDatabaseProxy(_mongoServer.GetDatabase(databaseName));
        }

        public IMongoDatabase GetDatabase(string databaseName, MongoCredentials credentials)
        {
            return new MongoDatabaseProxy(_mongoServer.GetDatabase(databaseName, credentials));
        }

        public IMongoDatabase GetDatabase(string databaseName, MongoCredentials credentials, SafeMode safeMode)
        {
            return new MongoDatabaseProxy(_mongoServer.GetDatabase(databaseName, credentials, safeMode));
        }

        public IMongoDatabase GetDatabase(string databaseName, SafeMode safeMode)
        {
            return new MongoDatabaseProxy(_mongoServer.GetDatabase(databaseName, safeMode));
        }

        public IEnumerable<string> GetDatabaseNames()
        {
            return _mongoServer.GetDatabaseNames();
        }

        public IEnumerable<string> GetDatabaseNames(MongoCredentials adminCredentials)
        {
            return _mongoServer.GetDatabaseNames(adminCredentials);
        }

        public GetLastErrorResult GetLastError()
        {
            return _mongoServer.GetLastError();
        }

        public GetLastErrorResult GetLastError(MongoCredentials adminCredentials)
        {
            return _mongoServer.GetLastError();
        }

        public bool IsDatabaseNameValid(string databaseName, out string message)
        {
            return _mongoServer.IsDatabaseNameValid(databaseName, out message);
        }

        public void Ping()
        {
            _mongoServer.Ping();
        }

        public void Reconnect()
        {
            _mongoServer.Reconnect();
        }

        public void RequestDone()
        {
            _mongoServer.RequestDone();
        }

        public IDisposable RequestStart(IMongoDatabase initialDatabase)
        {
            return _mongoServer.RequestStart((MongoDatabase)initialDatabase);
        }

        public IDisposable RequestStart(IMongoDatabase initialDatabase, bool slaveOk)
        {
            return _mongoServer.RequestStart((MongoDatabase)initialDatabase, slaveOk);
        }

        public IDisposable RequestStart(IMongoDatabase initialDatabase, MongoServerInstance serverInstance)
        {
            return _mongoServer.RequestStart((MongoDatabase) initialDatabase, serverInstance);
        }

        public void ResetIndexCache()
        {
            _mongoServer.ResetIndexCache();
        }

        public void Shutdown()
        {
            _mongoServer.Shutdown();
        }

        public void Shutdown(MongoCredentials adminCredentials)
        {
            _mongoServer.Shutdown(adminCredentials);
        }

        public void VerifyState()
        {
            _mongoServer.VerifyState();
        }
    }
}
