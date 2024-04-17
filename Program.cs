﻿using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Serilog;

namespace AutoCompleteBoxPlay;

sealed class Program {
	// Initialization code. Don't use any Avalonia, third-party APIs or any
	// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	// yet and stuff might break.
	[STAThread]
	public static void Main(string[] args) {
		
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Is(Serilog.Events.LogEventLevel.Debug)
			.WriteTo.Console()
			.CreateLogger();
		       
		Log.Information("Hello, world!");
		
		BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
	}
	
	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			//.LogToTrace()
			//.UseReactiveUI()
		;
}
