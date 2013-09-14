using System;
using MongoDB.Driver;

namespace Mongo.DSL.Statements {

	public class Into {
		readonly QuerySettings query_settings;
		
		public Into( QuerySettings query_settings ) {
			this.query_settings = query_settings;
		}
		
		public WriteConcernResult into( string collection ) {
			query_settings.CollectionName = collection;
			
			var document = query_settings.Document;
			var document_type = document.GetType();
			
			var value = Convert.ChangeType( document, Nullable.GetUnderlyingType( document_type ) ?? document_type );
			
			// Returns the safe mode result if "safe mode" is enabled, otherwise insert wont wait to confirm the insertion
			// and will return null as per MongoDB driver's design.
			return query_settings.Collection.Insert( document_type, value );
		}
	}
	
	public class Update {
		readonly QuerySettings query_settings;
		
		public Update( QuerySettings query_settings ) {
			this.query_settings = query_settings;
		}
		
		public WriteConcernResult on( string collection ) {
			query_settings.CollectionName = collection;
			
			var document = query_settings.Document;
			var document_type = document.GetType();
			
			var value = Convert.ChangeType( document, Nullable.GetUnderlyingType( document_type ) ?? document_type );
			
			// Returns the safe mode result if "safe mode" is enabled, otherwise insert wont wait to confirm the insertion
			// and will return null as per MongoDB driver's design.
			return query_settings.Collection.Insert( document_type, value );
		}
	}
}