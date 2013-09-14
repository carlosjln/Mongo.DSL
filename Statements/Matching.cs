using MongoDB.Driver;

namespace Mongo.DSL.Statements {

	public class Matching : MatchingMethods {
		readonly QuerySettings query_settings;

		public Matching( QuerySettings query_settings ) {
			this.query_settings = query_settings;
		}
		
		public Output matching( IMongoQuery criteria ) {
			return matching( query_settings, criteria );
		}

		public Output matching() {
			return new Output( query_settings );
		}
	}
	
}