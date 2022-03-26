using System;
using System.Collections.Generic;

namespace AvansOps 
{
	public abstract class IPipelinePhase 
	{
		private List<IPipelinePhaseSubscriber> subscribers;
		private Pipeline pipeline;

		public IPipelinePhase()
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
			catch
            {
				Error();
			}
		}

		protected virtual void Start()
        {

        }

		protected void Hook() 
		{
			
		}

		protected virtual void Finish()
        {
			for (int i = 0; i < subscribers.Count; i++)
			{
				subscribers[i].Finish();
			}
		}

		protected virtual void Error()
        {
			for (int i = 0; i < subscribers.Count; i++)
			{
				subscribers[i].Error("");
			}
		}
	}
}
