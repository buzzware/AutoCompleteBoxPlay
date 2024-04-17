namespace AutoCompleteBoxPlay.Models {
	
	public class Thing : BindableBase {
		
		public int id {
			get => _id; 
			set => SetProperty(ref _id, value);
		}
		private int _id;
		
		public string? name {
			get => _name; 
			set => SetProperty(ref _name, value);
		}
		private string? _name;

		public string? colour {
			get => _colour;
			set => SetProperty(ref _colour, value);
		}
		private string? _colour;
	}
}
