using Com.OneSignal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PushNotifications
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowPlayerIdHandler(object sender, EventArgs e)
        {
            OneSignal.Current.IdsAvailable(new Com.OneSignal.Abstractions.IdsAvailableCallback((playerID, pushToken) =>
            {
                playerIdLabel.Text = $"Player ID de este device:\n{playerID}";
            }));    
        }

    }
}
