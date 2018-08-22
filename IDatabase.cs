using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public interface IDatabase : IDisposable
    {
        // Connection details
        DatabaseType DatabaseType { get; }
        string ConnectionString { get; }
        string DatabaseName { get; }
        void OpenConnection();
        void ResetConnection();
        void CloseConnection();
        bool IsConnected { get; set; }
        bool IsOnline { get; }

        // Read methods
        List<T> Table<T>() where T : class, new();
        List<T> Query<T>(string sql, bool checkPermission = true) where T : class, new();
        List<object> QueryByTable(string tableName, string sql, bool checkPermission = true);
        List<object> QueryByType(Type objectType, string sql, bool checkPermission = true);
        void QueryWithOut<T>(string sql, bool checkPermission) where T : class, new();
        List<T> PagedQuery<T>(string sql, string orderBy, long startRow, long lastRow, bool checkPermission = true) where T : class, new();
        List<object> PagedQueryByTable(string tableName, string sql, string orderBy, long startRow, long lastRow, bool checkPermission = true);
        List<object> PagedQueryByType(Type objectType, string sql, string orderBy, long startRow, long lastRow, bool checkPermission = true);
        void PagedQueryWithOut<T>(string sql, string orderBy, long startRow, long lastRow, bool checkPermission) where T : class, new();
        T Get<T>(long key) where T : class, new();
        T GetComposite<T>(T row, List<string> pks = null) where T : class, new();
        T GetComposite<T>(string[] pks, string[] values) where T : class, new();

        // Write methods
        bool Insert<T>(T row, bool adjustInput = true, bool checkPermission = true) where T : class;
        bool RawInsert<T>(T row) where T : class;
        bool Update<T>(T row, bool adjustInput = true, bool checkPermission = true) where T : class, new();
        bool RawUpdate<T>(T row) where T : class;
        bool UpdateComposite<T>(T row, bool adjustInput = true, bool checkPermission = true, List<string> pks = null) where T : class, new();
        bool RawUpdateComposite<T>(T row, List<string> pk = null) where T : class;
        bool Delete<T>(T row, bool adjustInput = true, bool checkPermission = true, List<string> pk = null) where T : class, new();

        // Read/write methods
        void Execute(string sql);
        T ExecuteScalar<T>(string sql);

        // Datatabase details 
        List<string> GetPrimaryKeys(string tableName);
        List<string> GetIdentityKeys(string tableName);
        List<ForeignKeyModel> GetForeignKeys();
        List<string> GetColumns(string tableName);
        List<string> GetTableList();
        DateTime GetDbLocalTime();
        DateTime GetDbUtcTime();
        string GetUtcTimeString(DateTime? utcDateTime = null);

        // Transaction methods
        bool IsInTransaction();
        void StartTransaction();
        void Rollback();
        void Commit();
    }
}
