using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWallet.Models;

namespace XamarinWallet.Views
{

   /**
    * Used to define block model
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
      
        public Transaction Transaction { get; set; }

       /*
        * Constructor
        * 
        */ 
        public ItemsPage()
        {
            InitializeComponent();
            Transaction = new Transaction
            {
                PrivateKey = "", //L3aq7WPiSois3N7GxTr6ZSXMNdfbAZWNebiYvKK5hAUBCijk95rL
                Sender = "", //18jp31DcT3n5vsYHGVhhQa2qsvEve4EUoQ
            };

            BindingContext = this;
        }

        /*
         * Saved_Clicked() Event to save public and private keys
         * 
         */
        async void Save_Clicked(object sender, EventArgs e)
        {
            Credential.PublicKey = Transaction.Sender;
            Credential.PrivateKey = Transaction.PrivateKey;

            await DisplayAlert("Credential", "Keys Updated", "OK");
        }

        /*
         * CreateSign_Clicked() Event to navigate through item page
         * 
         */
        async void CreateSign_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }


    }
}