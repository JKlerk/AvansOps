using System;
using System.Collections.Generic;

namespace AvansOps.ScrumProject.RepositoryScrum.PipelineScrum 
{
	public abstract class PipelinePhase 
	{
		private List<IPipelinePhaseSubscriber> subscribers;
		private Pipeline pipeline;

		public PipelinePhase()
        {
			subscribers = new List<IPipelinePhaseSubscriber>();
		}

		public void Subscribe(IPipelinePhaseSubscriber pipelinePhaseSubscriber)
        {
			subscribers.Add(pipelinePhaseSubscriber);
        }

		public void UnSubscribe(IPipelinePhaseSubscriber pipelinePhaseSubscriber)
        {
			subscribers.Remove(pipelinePhaseSubscriber);
		}

		public void TemplateMethod() 
		{
            try
            {
				Start();
				Hook();
				Finish();

			}
			catch (Exception exception)
            {
				Error(exception);
			}
		}

		protected virtual void Start()
        {

        }

		protected virtual void Hook() 
		{
			
		}

		protected virtual void Finish()
        {
			for (int i = 0; i < subscribers.Count; i++)
			{
				subscribers[i].Finish(this);
			}
		}

		private void Error(Exception exception)
        {
			for (int i = 0; i < subscribers.Count; i++)
			{
				subscribers[i].Error(this, exception.Message);
			}
		}
	}
}
