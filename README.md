# netsync

DataAccessLayer for providing sync functions. Designed for SQLite to SQL server, but could be used for anything to anything. Some requirements on the database:

* Each table needs **Updated** datetime and **SyncStatus** integer fields.
  * Both fields are critical for the sync process to work as designed. Updated field should be UTC. SyncStatus is used in the local database with 0 showing no change, 1 is new record, 2 is updated record.
* A **Deleted** table must exist matching the Deleted.cs POCO. This is used in local database and on server to check for deleted records.
* Every primary table should have a field name **Id** for the record index.
  * The local database should use negative indexing for new primary records, otherwise the keyswap method can be modified to use SyncStatus.  This can be set in the implementation.
  * The server can use autoincrement for this, or this can be set in the implementation. Check the ORM.
* Foreign keys should be set ON UPDATE CASCADE or other code is needed to swap foreign keys.
