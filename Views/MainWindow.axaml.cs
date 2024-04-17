using System;
using System.ComponentModel;
using System.Linq;
using AutoCompleteBoxPlay.Models;
using AutoCompleteBoxPlay.ViewModels;
using Avalonia.Controls;
using Avalonia.Input;
using Serilog;

namespace AutoCompleteBoxPlay.Views;

public partial class MainWindow : Window {
	
	public MainWindowViewModel VM => (DataContext as MainWindowViewModel)!;
	
	public MainWindow() {
		InitializeComponent();
	}
	
	private void SetLastTapped(object? sender, TappedEventArgs e) {
		VM.Selected = (autoComplete.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).LastOrDefault();
	}

	private void SetFirstTapped(object? sender, TappedEventArgs e) {
		VM.Selected = (autoComplete.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).FirstOrDefault();
	}

	private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
		var vm = e.AddedItems.Count > 0 ? e.AddedItems[0] : null;
		VM.Selected = vm as ThingViewModel;
	}

	private void AutoComplete_OnDropDownClosed(object? sender, EventArgs e) {
		Log.Debug("AutoComplete_OnDropDownClosed");
	}

	private void AutoComplete_OnDropDownOpened(object? sender, EventArgs e) {
		Log.Debug("AutoComplete_OnDropDownOpened");
	}

	private void AutoComplete_OnDropDownClosing(object? sender, CancelEventArgs e) {
		Log.Debug("AutoComplete_OnDropDownClosing");
	}

	private void AutoComplete_OnDropDownOpening(object? sender, CancelEventArgs e) {
		Log.Debug("AutoComplete_OnDropDownOpening");
	}

	private void AutoComplete_OnPopulated(object? sender, PopulatedEventArgs e) {
		Log.Debug("AutoComplete_OnPopulated");
	}

	private void AutoComplete_A_OnPopulating(object? sender, PopulatingEventArgs e) {
		Log.Debug("AutoComplete_OnPopulating");
		e.Cancel = true;
		autoComplete.ItemsSource = VM.BuildAutoCompleteList(autoComplete.Text);
		autoComplete.PopulateComplete();
	}
}
