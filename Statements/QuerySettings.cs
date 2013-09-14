using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Mongo.DSL.Statements {

	public class QuerySettings {
		public Guid Id;
		public BsonDocument sort_document { get; set; }
		public string CollectionName { get; set; }

		// Consider a scenario where this property might be acceced more than once,
		// that would cause calling 'GetCollection' several times
		public MongoCollection Collection {
			get {
				return MongoDatabase.GetCollection( CollectionName );
			}
		}

		public MongoDatabase MongoDatabase { get; set; }

		public FieldsBuilder Fields { get; set; }

		public object Document { get; set; }

		public QueryType QueryType { get; set; }

		public int Limit { get; set; }

		public IMongoQuery Criteria { get; set; }

		public QuerySettings( ) {
			Fields = new FieldsBuilder( );
			Limit = 0;
		}
	}

}