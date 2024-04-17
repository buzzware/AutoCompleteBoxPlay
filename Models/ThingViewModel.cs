namespace AutoCompleteBoxPlay.Models {
	
	public class ThingViewModel : BindableBase {
		private string? _text;

		public Thing? Thing { get; }

		public string? Text {
			get => _text ?? Thing?.name ?? "";
			set => SetProperty(ref _text,value);
		}

		public ThingViewModel(Thing? thing = null) {
			Thing = thing;
		}
		
		public override string ToString() {
			return Text!;
		}
	}
}
