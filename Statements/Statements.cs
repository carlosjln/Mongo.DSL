using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Mongo.DSL.Statements {

	public class Statements : OutputMethods {
		readonly QuerySettings query_settings;

		public Statements( QuerySettings query_settings ) : base(query_settings) {
			this.query_settings = query_settings;
		}
		
		// SELECT
		public Matching select( FieldsBuilder fields ) {
			query_settings.Fields = fields;
			return select();
		}
		public Matching select() {
			query_settings.QueryType = QueryType.Select;
			
			return new Matching( query_settings );
		}
		
		// INSERT
		public Into insert( object document ) {
			query_settings.Document = document;
			return new Into( query_settings );
		}
		
		// REMOVE
		public RemoveMatching remove() {
			return new RemoveMatching( query_settings );
		}

		// INMEDIATE OUTPUT
		public MongoCursor<T> get_all_as<T>( ) where T : new( ) {
			return base_get_all_as<T>();
		}

		public MongoCursor get_all( ) {
			return base_get_all();
		}

		public MongoCursor get_all( SortBuilder sort_builder ) {
			query_settings.sort_document = sort_builder.GetBsonDocument();
			return base_get_all();
		}
	}

}