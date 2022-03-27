namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum {
	public interface IPipelinePhaseSubscriber 
	{
		public void Finish(PipelinePhase phase);
		public void Error(PipelinePhase phase, string message);
	}
}
