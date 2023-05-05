namespace Rentade.pages;

public partial class Galeria : ContentPage
{
	public Galeria()
	{
		InitializeComponent();

	}

    private async void tesla_Clicked(System.Object sender, System.EventArgs e)
    {
		Registro.iNumeroCarro = 1;
		Registro.iCond = 1;

		var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }

    private async void versa_Clicked(System.Object sender, System.EventArgs e)
    {
        Registro.iNumeroCarro = 3;
        Registro.iCond = 1;

        var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }

    private async void sentra_Clicked(System.Object sender, System.EventArgs e)
    {
        Registro.iNumeroCarro = 2;
        Registro.iCond = 1;

        var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }

    private async void camaro_Clicked(System.Object sender, System.EventArgs e)
    {
        Registro.iNumeroCarro = 4;
        Registro.iCond = 1;

        var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }

    private async void mustang_Clicked(System.Object sender, System.EventArgs e)
    {
        Registro.iNumeroCarro = 5;
        Registro.iCond = 1;

        var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }

    private async void corvette_Clicked(System.Object sender, System.EventArgs e)
    {
        Registro.iNumeroCarro = 6;
        Registro.iCond = 1;

        var miTabbedPage = (TabbedPage)Application.Current.MainPage;
        miTabbedPage.CurrentPage = miTabbedPage.Children[0];
        await DisplayAlert("", "Los datos del Automovil han sido llenados, porfavor complete el registro", "Aceptar");
    }
}
