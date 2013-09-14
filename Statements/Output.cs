namespace Mongo.DSL.Statements {
	
	public class Output : OutputMethods {
		public Output( QuerySettings query_settings ) : base( query_settings ) {
		}

		public T get_one_as<T>() where T : new( ) {
			return base_get_one_as<T>();
		}
	}

}