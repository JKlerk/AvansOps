using System;

namespace AvansOps {
	public abstract class IReportExportStrategy {
		public void ExportReport(ref TeamReport report) {
			throw new System.NotImplementedException("Not implemented");
		}

		private TeamReportGenerator teamReportGenerator;

	}

}
