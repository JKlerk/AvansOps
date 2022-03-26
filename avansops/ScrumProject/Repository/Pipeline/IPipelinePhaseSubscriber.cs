using System;

namespace AvansOps {
	public interface IPipelinePhaseSubscriber 
	{
		protected void Finish();
		protected void Error(string message);
	}
}
