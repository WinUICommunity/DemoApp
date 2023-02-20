// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Navigation;
using System.Linq;
using WinUICommunity.Common.Helpers;
using WinUICommunity.LandingsPage.Controls;
using WinUICommunity.Shared.DataModel;

namespace WinUICommunity.DemoApp.Pages
{
    public sealed partial class SectionPage : ItemsPageBase
    {
        public SectionPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationArgs args = (NavigationArgs)e.Parameter;
            var navigationView = args.NavigationView;

            var group = await ControlInfoDataSource.Instance.GetGroupAsync((string)args.Parameter, args.JsonRelativeFilePath, args.IncludedInBuildMode);

            var menuItem = (Microsoft.UI.Xaml.Controls.NavigationViewItemBase)navigationView.MenuItems.Single(i => (string)((Microsoft.UI.Xaml.Controls.NavigationViewItemBase)i).Tag == group.UniqueId);
            menuItem.IsSelected = true;
            TitleTxt.Text = group.Title;
            Items = group.Items.OrderBy(i => i.Title).ToList();
        }

        protected override bool GetIsNarrowLayoutState()
        {
            return LayoutVisualStates.CurrentState == NarrowLayout;
        }
    }
}
