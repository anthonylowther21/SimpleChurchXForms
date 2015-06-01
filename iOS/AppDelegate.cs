﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SimpleChurchApp.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		UITabBarController tabBarController;

//		//
//		// This method is invoked when the application has loaded and is ready to run. In this
//		// method you should instantiate the window, load the UI into it and then make the window
//		// visible.
//		//
//		// You have 17 seconds to return from this method, or iOS will terminate your application.
//		//
//		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
//		{
//			// create a new window instance based on the screen size
//			window = new UIWindow (UIScreen.MainScreen.Bounds);
//
//			window.RootViewController = new UINavigationController( new TabController () );
//
//			// make the window visible
//			window.MakeKeyAndVisible ();
//
//			return true;
//		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			var viewControllers = new UIViewController[]
			{
				CreateTabFor("Home", "first", new HomeController ()),
				CreateTabFor("Sermons", "first", new SermonsController ()),
				CreateTabFor("Events", "first", new EventsController ()),
				CreateTabFor("Small Groups", "first", new SmallGroupsController ()),
				CreateTabFor("About", "second", new AboutController ()),
			};

			tabBarController = new UITabBarController ();
			tabBarController.ViewControllers = viewControllers;
			tabBarController.SelectedViewController = tabBarController.ViewControllers[0];

			window.RootViewController = tabBarController;
			window.MakeKeyAndVisible ();

			return true;
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTabFor(string title, string imageName, UIViewController view)
		{
			var controller = new UINavigationController();
			controller.NavigationBar.TintColor = UIColor.Black;
			var screen = view;
			SetTitleAndTabBarItem(screen, title, imageName);
			controller.PushViewController(screen, false);
			return controller;
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
		{
			screen.Title = NSBundle.MainBundle.LocalizedString (title, title);
			screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(imageName),
				_createdSoFarCount);
			_createdSoFarCount++;
		}
	}
}

