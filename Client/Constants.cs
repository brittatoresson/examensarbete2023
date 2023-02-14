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
        NavigationManager nav { get; set; }
        private readonly NavigationManager _navMagager;

        public void Navigate(string url)
        {
            nav.NavigateTo(url);
            //_navMagager.NavigateTo(url);
            //NavigationManger.NavigateTo(url);
        }

        //public Navigation(NavigationManager navManager)
        //{
        //    _navMagager = navManager;
        //}
       

    }
}

