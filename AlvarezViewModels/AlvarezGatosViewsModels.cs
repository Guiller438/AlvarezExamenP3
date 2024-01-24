using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlvarezExamenProgreso3.AlvarezViewModels
{ 
    class AlvarezGatosViewsModels
    {
        private Image gatosImage;
        public class Breed
        {
            public int id { get; set; }
            public string name { get; set; }
            public string weight { get; set; }
            public string height { get; set; }
            public string life_span { get; set; }
            public string breed_group { get; set; }
        }

        public class Root
        {
            public string id { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string mime_type { get; set; }
            public List<Breed> breeds { get; set; }
            public List<object> categories { get; set; }
        }

        public async void MostrarGatosEnPantalla()
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
    }
    
}
