﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using SampleApp.Localization.SampleApp;
using Volo.Abp.UI.Navigation;

namespace SampleApp.Menus
{
    public class SampleAppMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<SampleAppResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("SampleApp.Home", l["Menu:Home"], "/"));
            context.Menu.AddItem(
                    new ApplicationMenuItem("BooksStore", l["Menu:BooksStore"])
                    .AddItem(new ApplicationMenuItem("BooksStore.Books", l["Menu:Books"], url: "/Books"))
                    .AddItem(new ApplicationMenuItem("BooksStore.Authors", l["Menu:Authors"], url: "/Authors"))
                            );
        }
    }
}
