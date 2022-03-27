using System;
using System.Collections.Generic;

namespace AvansOps 
{
    public class Pipeline : IPipelinePhaseSubscriber
    {
		private Repository repository;
		private List<PipelinePhase> phases;
		public SprintRelease SprintRelease { get; }
		public bool IsFinished { get; private set; }

		public bool IsRunning { get; private set; }

		private int indexCurrentPhase;

		public Pipeline(Repository repository, SprintRelease sprintRelease)
		{
			this.repository = repository;
			phases = new List<PipelinePhase>();
			SprintRelease = sprintRelease;
		}

		public void Run() 
		{
			IsRunning = true;
			indexCurrentPhase = 0;

			StartPhase(indexCurrentPhase);
		}

		private void StartPhase(int index) 
		{
			phases[index].TemplateMethod();
		}

		private void AdvancePhase() 
		{
			indexCurrentPhase++;

			if (indexCurrentPhase > phases.Count - 1)
            {
				FinishPipeline();
				return;
			}

			StartPhase(indexCurrentPhase);
		}

		private void FinishPipeline() 
		{
			IsFinished = true;
			SprintRelease.FinishPipeline();
		}

        void IPipelinePhaseSubscriber.Finish()
        {
			AdvancePhase();
		}

        public void AddPhase(PipelinePhase phase)
        {
	        phases.Add(phase);
			phase.Subscribe(this);
		}

        void IPipelinePhaseSubscriber.Error(string message)
        {
			NotificationManager.Notify(new List<Role>() { Role.ScrumMaster }, repository.Project, "Pipeline has failed: " + message);
		}
	}
}
