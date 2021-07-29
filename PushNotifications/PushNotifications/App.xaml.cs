using Com.OneSignal;
using Plugin.Toast;
using PushNotifications.Pages;
using Xamarin.Forms;

namespace PushNotifications
{
    public partial class App : Application
    {
        public static string MessageFromNotification = "";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            OneSignal.Current.StartInit("73c81827-c15c-4502-8a0c-0885a91493c1").HandleNotificationOpened(OnHandleNotificationOpened).EndInit();

            MainPage.Appearing += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(MessageFromNotification))
                {
                    var notificationPage = new NotificationPage
                    {
                        BindingContext = MessageFromNotification,
                        Title = "Notificacion de OneSignal"
                    };
                    var modalPage = new NavigationPage(notificationPage);
                    MainPage.Navigation.PushModalAsync(modalPage);
                    MessageFromNotification = "";
                }
            };


        }

        private void OnHandleNotificationOpened(Com.OneSignal.Abstractions.OSNotificationOpenedResult result)
        {
            if (result.notification.payload.additionalData.ContainsKey("additional_message"))
            {
                // Si el payload posee la key additional_message, ejecutar esta seccion de codigo
                MessageFromNotification = result.notification.payload.additionalData["additional_message"].ToString();

                CrossToastPopUp.Current.ShowToastMessage(MessageFromNotification);

            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
