namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum {
	public interface IPipelinePhaseSubscriber 
	{
		public void Finish();
		public void Error(string message);
	}
}
