using Mongo.DSL.Statements;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo.DSL {

	public abstract class OutputMethods {
		private readonly QuerySettings query_settings;
		private readonly MongoCollection<BsonDocument> collection;
		
		protected OutputMethods( QuerySettings query_settings ) {
			this.query_settings = query_settings;
			var database = query_settings.MongoDatabase;

			collection = database.GetCollection( query_settings.CollectionName );
		}

		protected void set_options(MongoCursor cursor) {
			cursor.SetFields( query_settings.Fields );
			cursor.SetLimit( query_settings.Limit );

			var sort_document = query_settings.sort_document;
			if( sort_document != null ) cursor.SetOption( "$orderby", sort_document );
		}

		protected T base_get_one_as<T>() where T : new() {
			var cursor = collection.FindAs<T>( query_settings.Criteria );
			set_options( cursor );
			
			var enumerator = cursor.GetEnumerator();
			
			return enumerator.MoveNext() ? enumerator.Current : default( T );
		}

		protected BsonDocument base_get_one() {
			return base_get_one_as<BsonDocument>();
		}

		protected MongoCursor<T> base_get_all_as<T>() where T : new() {
			var cursor = query_settings.Criteria == null ? collection.FindAllAs<T>() : collection.FindAs<T>( query_settings.Criteria );
			set_options( cursor );

			return cursor;
		}

		protected MongoCursor base_get_all( ) {
			var cursor = collection.FindAll();
			set_options( cursor );
			
			return cursor;
		}
	}

}