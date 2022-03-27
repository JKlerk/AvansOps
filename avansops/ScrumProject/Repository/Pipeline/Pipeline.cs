using System;
using System.Collections.Generic;

namespace AvansOps 
{
    public class Pipeline : IPipelinePhaseSubscriber
    {
		private Repository repository;
		public List<PipelinePhase> Phases { get; }
		public SprintRelease SprintRelease { get; }
		public bool IsFinished { get; private set; }

		public bool IsRunning { get; private set; }

		private int indexCurrentPhase;

		public Pipeline(Repository repository, SprintRelease sprintRelease)
		{
			this.repository = repository;
			Phases = new List<PipelinePhase>();
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
			Phases[index].TemplateMethod();
		}

		private void AdvancePhase() 
		{
			indexCurrentPhase++;

			if (indexCurrentPhase > Phases.Count - 1)
            {
				FinishPipeline();
				return;
			}

			StartPhase(indexCurrentPhase);
		}

		private void FinishPipeline() 
		{
			IsRunning = false;
			IsFinished = true;
			SprintRelease.FinishPipeline();
		}

        void IPipelinePhaseSubscriber.Finish()
        {
			AdvancePhase();
		}

        public void AddPhase(PipelinePhase phase)
        {
			Phases.Add(phase);
			phase.Subscribe(this);
		}

        void IPipelinePhaseSubscriber.Error(string message)
        {
			IsRunning = false;
			NotificationManager.Notify(new List<Role>() { Role.ScrumMaster }, repository.Project, "Pipeline has failed: " + message);
		}
	}
}
