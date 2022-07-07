﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

using Xabbo.Scripter.ViewModel;

namespace Xabbo.Scripter.View
{
    public partial class MainWindow : Window, INavigationWindow
    {
        private readonly INavigationService _nav;

        public MainWindow(MainViewManager manager,
            INavigationService nav,
            IPageService pageService)
        {
            _nav = nav;
            DataContext = manager;

            InitializeComponent();

            _nav.SetNavigation(RootNavigation);
            SetPageService(pageService);

            Loaded += MainWindow_Loaded;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        public void CloseWindow() => Close();

        public Frame GetFrame() => RootFrame;

        public INavigation GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) => RootNavigation.PageService = pageService;

        public void ShowWindow() => Show();

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;

            MainViewManager mainViewManager = (MainViewManager)DataContext;
            await Task.Run(() => mainViewManager.InitializeAsync(CancellationToken.None));
        }

        private void ButtonPin_Click(object sender, RoutedEventArgs e)
        {
            Topmost = !Topmost;
        }
    }
}
