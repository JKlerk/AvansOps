namespace AvansOps.ScrumProject.Repository.Pipeline {
	public interface IPipelinePhaseSubscriber 
	{
		public void Finish();
		public void Error(string message);
	}
}
