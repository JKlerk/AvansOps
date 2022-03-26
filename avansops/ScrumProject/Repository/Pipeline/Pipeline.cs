using System;
using System.Collections.Generic;

namespace AvansOps 
{
    public class Pipeline : IPipelinePhaseSubscriber
    {
		private Repository repository;
		private List<IPipelinePhase> phases;
		public SprintRelease SprintRelease { get; }
		public bool IsFinished { get; private set; }

		public bool IsRunning { get; private set; }

		private int indexCurrentPhase;

		public Pipeline(Repository repository, SprintRelease sprintRelease)
		{
			this.repository = repository;
			phases = new List<IPipelinePhase>();
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

        void IPipelinePhaseSubscriber.Error(string message)
        {
			Console.WriteLine(message);
		}
	}
}
