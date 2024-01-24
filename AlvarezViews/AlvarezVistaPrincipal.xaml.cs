using Newtonsoft.Json;
using AlvarezExamenProgreso3.AlvarezModels;
using static AlvarezExamenProgreso3.AlvarezModels.AlvarezGato;

namespace AlvarezExamenProgreso3.AlvarezViews;

public partial class AlvarezVistaPrincipal : ContentPage
{
    private Image gatossImage;
    public AlvarezVistaPrincipal()
	{
		InitializeComponent();

        MostrarGatosEnPantalla();
	}

    private async void MostrarGatosEnPantalla()
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())
            {
                string url = "https://api.thecatapi.com/v1/images/search?api_key=live_4pXq2bUSr2bsshJR8tjjyfHB9HEpVnVZlqD4F5RxCBBbx8dxUxyGQDR7QNNJFORTY";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var gatos = JsonConvert.DeserializeObject<List<Root>>(json);


                    gatosImage.Source = ImageSource.FromUri(new Uri(gatos[0].url));


                }

            }
        }


    }

    private void OtroGatoButton_Clicked(object sender, EventArgs e)
    {
        MostrarGatosEnPantalla();
    }

    private void GuardarButton_Clicked(object sender, EventArgs e)
    {

    }
}