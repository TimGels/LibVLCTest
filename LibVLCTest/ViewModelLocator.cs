using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace LibVLCTest
{

    class ViewModelLocator
    {
        public const string MainPageKey = "MainPage";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();

            // Configure navigation keys
            nav.Configure(MainPageKey, typeof(MainPage));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<ViewModel>();

        }

        /// <summary>
        /// Unregister and register the <see cref="MainPageViewModel"/> so the view model resets.
        /// </summary>
        public static void ResetMainPageViewModel()
        {
            SimpleIoc.Default.Unregister<ViewModel>();
            SimpleIoc.Default.Register<ViewModel>();
        }

        // <summary>
        // Gets the MainPage view model.
        // </summary>
        // <value>
        // The StartPage view model.
        // </value>
        public ViewModel MainPageInstance {
            get {
                return ServiceLocator.Current.GetInstance<ViewModel>();
            }
        }

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }    
}
