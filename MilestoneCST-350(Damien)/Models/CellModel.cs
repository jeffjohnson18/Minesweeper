namespace MilestoneCST_350_Damien_.Models
{
	public class CellModel
	{
		// Cell properties
		public int RowNumber { get; set; }
		public int ColNumber { get; set; }
		public bool Visited { get; set; }
		public bool LiveBomb { get; set; }
		public bool CellFlagged { get; set; }

		public int LiveNeighbors { get; set; }

		// temporary

		// Default cell constructor
		public CellModel()
		{
			RowNumber = 0;
			ColNumber = 0;
			Visited = false;
			LiveBomb = false;
			LiveNeighbors = 0;
			CellFlagged = false;
		}

	}
}
