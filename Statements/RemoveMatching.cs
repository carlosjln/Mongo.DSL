using MongoDB.Driver;

namespace Mongo.DSL.Statements {

	public class RemoveMatching {
		readonly QuerySettings query_settings;

		public RemoveMatching( QuerySettings query_settings ) {
			this.query_settings = query_settings;
		}

		public WriteConcernResult matching( IMongoQuery criteria ) {
			return query_settings.Collection.Remove( criteria );
		}
	}

}