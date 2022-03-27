using System;
using System.Collections.Generic;

namespace AvansOps 
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
				subscribers[i].Finish();
			}
		}

		private void Error(Exception exception)
        {
			for (int i = 0; i < subscribers.Count; i++)
			{
				subscribers[i].Error(exception.Message);
			}
		}
	}
}
