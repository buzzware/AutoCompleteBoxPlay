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
		if (sender==lastA)
			VM.SelectedA = (autoCompleteA.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).LastOrDefault();
		if (sender==lastB)
			VM.SelectedB = (autoCompleteB.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).LastOrDefault();
		if (sender==lastC)
			VM.SelectedC = (autoCompleteC.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).LastOrDefault();
	}

	private void SetFirstTapped(object? sender, TappedEventArgs e) {
		if (sender==firstA)
			VM.SelectedA = (autoCompleteA.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).FirstOrDefault();
		if (sender==firstB)
			VM.SelectedB = (autoCompleteB.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).FirstOrDefault();
		if (sender==firstC)
			VM.SelectedC = (autoCompleteC.ItemsSource?.Cast<ThingViewModel>() ?? VM.MainVMs).FirstOrDefault();
	}

	private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
		var vm = e.AddedItems.Count > 0 ? e.AddedItems[0] : null;
		if (sender==autoCompleteA)
			VM.SelectedA = vm as ThingViewModel;
		if (sender==autoCompleteB)
			VM.SelectedB = vm as ThingViewModel;
		if (sender==autoCompleteC)
			VM.SelectedC = vm as ThingViewModel;
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

	private void AutoComplete_OnPopulating(object? sender, PopulatingEventArgs e) {
		Log.Debug("AutoComplete_OnPopulating");
	}
	
	private void AutoComplete_C_OnPopulating(object? sender, PopulatingEventArgs e) {
		Log.Debug("AutoComplete_C_OnPopulating");
		e.Cancel = true;
		autoCompleteC.ItemsSource = VM.BuildAutoCompleteList(autoCompleteC.Text);
		autoCompleteC.PopulateComplete();
	}

}
