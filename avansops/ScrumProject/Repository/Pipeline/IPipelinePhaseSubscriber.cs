using System;

namespace AvansOps {
	public interface IPipelinePhaseSubscriber 
	{
		public void Finish();
		public void Error(string message);
	}
}
