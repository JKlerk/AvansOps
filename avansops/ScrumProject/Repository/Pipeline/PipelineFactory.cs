using System;

namespace AvansOps {
	public static class PipelineFactory {
		public static Pipeline CreatePipeline(Repository repository) 
		{
			Pipeline pipeLine = new Pipeline(repository);
			return pipeLine;
		}
	}
}
