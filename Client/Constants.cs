using System;
using Microsoft.AspNetCore.Components;


namespace Examensarbete.Client
{
    static class Constants
    {
        public const string exercise = "exercise";
        public const string focus = "focus";
        public const string home = "home";
    }

    public class Navigation
    {
        [Inject]
        NavigationManager navigamtion { get; set; }

        public void Navigate(string url)
        {
            navigamtion.NavigateTo(url);

        }
    }
}

