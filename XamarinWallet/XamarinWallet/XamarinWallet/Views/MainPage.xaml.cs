using XamarinWallet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinWallet.Views
{

    /**
    * Used to define main page interaction
    * 
    * @author Davain Pablo Edwards
    * @license MIT 
    * @version 1.0
    */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}