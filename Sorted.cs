namespace Mongo.DSL.Core {

	public class Sorted {

		public static SortBuilder By( params string[] fields ) {
			return new SortBuilder( fields );
		}

	}

}