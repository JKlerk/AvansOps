using System;

namespace AvansOps {
	public static class PipelineFactory {
		public static Pipeline CreatePipeline(Repository repository, SprintRelease sprint) 
		{
			Pipeline pipeLine = new Pipeline(repository, sprint);
			return pipeLine;
		}
	}
}
