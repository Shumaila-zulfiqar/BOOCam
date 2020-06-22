using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBook : ContentPage
    {
        public SearchBook()
        {
            InitializeComponent();
        }

        private void searchbar_SearchButtonPressed(object sender, EventArgs e)
        {

        }
    }
}