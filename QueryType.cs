namespace Mongo.DSL {

	public class QueryType {
		public string Value { get; set; }

		public static QueryType Select = new QueryType { Value = "Select" };
		public static QueryType Scalar = new QueryType { Value = "Scalar" };
		public static QueryType Insert = new QueryType { Value = "Insert" };
		public static QueryType Update = new QueryType { Value = "Update" };
		public static QueryType Upsert = new QueryType { Value = "Upsert" };
		public static QueryType Remove = new QueryType { Value = "Remove" };
	}

}