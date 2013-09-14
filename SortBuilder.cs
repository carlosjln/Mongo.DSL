using MongoDB.Bson;

namespace Mongo.DSL {
	public class SortBuilder {
		private readonly string [ ] fields;
		private int direction;

		public SortBuilder Ascending {
			get {
				direction = 1;
				return this;
			}
		}

		public SortBuilder Descending {
			get {
				direction = -1;
				return this;
			}
		}

		public SortBuilder( params string [ ] fields ) {
			this.fields = fields;
		}

		public BsonDocument GetBsonDocument( ) {
			var document = new BsonDocument( );

			foreach( var key in fields ) {
				document.Add( key, direction );
			}

			return document;
		}
	}
}