using System;
using System.Collections.Generic;

namespace AvansOps {
	public static class PipelineFactory {
		public static Pipeline CreatePipeline(Repository repository, SprintRelease sprint) 
		{
			Pipeline pipeLine = new Pipeline(repository, sprint);

			List<PipelinePhase> phases = new List<PipelinePhase>()
			{
				new PipelinePhasePackage(),
				new PipelinePhaseBuild(),
				new PipelinePhaseTest(),
				new PipelinePhaseAnalyse(),
				new PipelinePhaseDeploy(),
				new PipelinePhaseUtility()
			};

			foreach (var phase in phases)
			{
				pipeLine.AddPhase(phase);
			}
			
			return pipeLine;
		}
	}
}
