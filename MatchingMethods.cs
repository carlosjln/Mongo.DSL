using Mongo.DSL.Statements;
using MongoDB.Driver;

namespace Mongo.DSL {

	public abstract class MatchingMethods {
		protected Output matching( QuerySettings query_settings, IMongoQuery criteria ) {
			query_settings.Criteria = criteria;

			return new Output( query_settings );
		}
	}

}