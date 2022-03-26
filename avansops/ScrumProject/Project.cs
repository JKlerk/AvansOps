using System;
using System.Collections.Generic;
using System.Linq;

namespace AvansOps {
	public class Project
	{
		private int id;
		public string Name { get; }
		public string Description { get; }
		private List<BackLogItem> backLogItems;
		private Repository repository;
		private List<Sprint> sprints;
		private List<SprintPhase> sprintPhases;
		private ProjectMember creator;

		public Project(int id, string name, string description, ProjectMember creator)
		{
			this.id = id;
			Name = name;
			Description = description;
			this.creator = creator;
			backLogItems = new List<BackLogItem>();
			sprints = new List<Sprint>();
			sprintPhases = new List<SprintPhase>();
			repository = new Repository(this);
		}

		public void NotifyRole(Role role)
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public void AddBackLogItem(BackLogItem backLogItem)
		{
			backLogItems.Add(backLogItem);
		}

		public Sprint AddSprint(SprintType sprintType, DateTime start, DateTime end, ProjectMember creator)
		{
			Sprint sprint = SprintFactory.CreateSprint(sprintType, start, end, creator);
			sprints.Add(sprint);
			return sprint;
		}

		public SprintBackLogItem AddBackLogItemToSprintBackLog(BackLogItem backLogItem, Sprint sprint)
		{
			SprintBackLogItem item = sprint.AddSprintBacklogItem(backLogItem);
			sprintPhases[0].PlaceItem(item, null);
			return item;
		}

		public void AddPhase(SprintPhase phase)
		{
			sprintPhases.Add(phase);
		}

		public List<SprintPhase> GetPhases()
		{
			return sprintPhases;
		}

		public SprintPhase GetPhase(string name)
		{
			return sprintPhases.First(x => x.Name.ToLower() == name.ToLower());
		}

		public SprintPhase GetPhase(int id)
		{
			return sprintPhases.First(x => x.Id == id);
		}


		public void MoveSprintBackLogItemToPhase(ProjectMember projectMember, SprintBackLogItem sprintBackLogItem,
			SprintPhase phase)
		{
			if (!phase.GetRolesAuthorized().Any(x => projectMember.Roles.Any(y => y == x)))
			{
				Console.WriteLine("Not authorized");
				return;
			}

			SprintPhase sprintPhaseFrom = null;

			foreach (var x in sprintPhases.Where(x => x.GetSprintBackLogItems().Contains(sprintBackLogItem)))
			{
				sprintPhaseFrom = x;
				x.RemoveItem(sprintBackLogItem);
			}

			phase.PlaceItem(sprintBackLogItem, sprintPhaseFrom);
		}

		public void UploadReviewDoc(Sprint sprint)
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public void StartPipelineCurrentSprint()
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public void FinishCurrentSprint()
		{
			throw new System.NotImplementedException("Not implemented");
		}

		public Sprint GetCurrentSprint()
		{
			return sprints.First(sprint => sprint.SprintState == SprintState.OnGoing);
		}

		public List<BackLogItem> GetBacklogItems()
		{
			return backLogItems;
		}

		public List<Sprint> GetSprints()
		{
			return sprints;
		}

	}

}
