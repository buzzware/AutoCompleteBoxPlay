using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoCompleteBoxPlay.Models;
using Serilog;

namespace AutoCompleteBoxPlay.ViewModels;

public class MainWindowViewModel : BindableBase {
	
	public static readonly ImmutableArray<Thing> ExampleRecentThings = ImmutableArray<Thing>.Empty
		.Add(new Thing() { id = 123, name = "Recent 123" })
		.Add(new Thing() { id = 99, name = "Recent 99" })
		.Add(new Thing() { id = 500, name = "Recent 500" });
	
	public static readonly ImmutableArray<Thing> ExampleMainThings = ImmutableArray<Thing>.Empty
		.Add(new Thing() { id = 1, name = "Sulfur Crested Parrot" })
		.Add(new Thing() { id = 2, name = "Carnaby's Parrot" })
		.Add(new Thing() { id = 3, name = "Red Tip Black Parrot" })
		.Add(new Thing() { id = 4, name = "Pink and Grey Parrot" });
	
	public ImmutableArray<ThingViewModel> RecentVMs { get; }
	public ImmutableArray<ThingViewModel> MainVMs { get; }
	
	public ThingViewModel? Selected {
		get => _Selected; 
		set => SetProperty(ref _Selected, value);
	}
	private ThingViewModel? _Selected;

	public Func<string?, CancellationToken, Task<IEnumerable<object>>>? AutoCompletePopulator { get; }

	private async Task<IEnumerable<object>> OnAutoCompletePopulator(string? arg1, CancellationToken arg2) {
		return BuildAutoCompleteList(arg1);
	}
	
	public MainWindowViewModel() {
		MainVMs = ExampleMainThings.Select(t => new ThingViewModel(t)).ToImmutableArray();
		RecentVMs = ExampleRecentThings.Select(t => new ThingViewModel(t)).ToImmutableArray();
		AutoCompletePopulator = OnAutoCompletePopulator;
	}
	
	public IEnumerable<ThingViewModel> BuildAutoCompleteList(string? arg1) {
		var predicate = bool (ThingViewModel vm) => String.IsNullOrEmpty(arg1) || vm.Thing!.name != null && vm.Thing.name.Contains(arg1, StringComparison.OrdinalIgnoreCase);
		var matchedMainThings = MainVMs.Where(predicate).ToList();
		var matchedRecentThings = RecentVMs.Where(predicate).ToList();
		var dropDownVMs = new List<ThingViewModel>();
		if (matchedRecentThings.Any()) {
			dropDownVMs.Add(new ThingViewModel() {Text = "[Recent]"});
			dropDownVMs.AddRange(matchedRecentThings);
		} 
		if (matchedMainThings.Any()) {
			if (dropDownVMs.Any())
				dropDownVMs.Add(new ThingViewModel() {Text = ""});
			dropDownVMs.Add(new ThingViewModel() {Text = "[All]"});
			dropDownVMs.AddRange(matchedMainThings);
		}
		//Log.Debug(String.Join("\n",dropDownVMs.Select(vm => vm.Text))+"\n");
		return dropDownVMs;
	}
}
