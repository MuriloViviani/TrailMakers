using Xamarin.Forms;

namespace TrailMakers.DataAndHelper
{
    public class Data
    {
        // TODO: Update curiosities
        public static string[] curiosities = new string[] {
            "Até 2015, a França já contava com cerca de 14 mil km de vias urbanas destinadas aos ciclistas",
            "Em 2016, a UCI e a organização do Tour de France utilizaram câmeras com sistema de sensores térmicos para detectar ciclistas que estariam utilizando motores ocultos nas bicicletas",
            "O Mountain Bike, no estilo Cross Country, entrou no ciclo olímpico em 1996, nos Jogos de Barcelona. A França conquistou uma medalha de bronze, com Miguel Martinez. Nas três edições seguintes, o país ficou com o primeiro lugar",
            "É bastante comum encontrar franceses fazendo grandes percursos de bicicleta em estradas e montanhas, não apenas no uso dentro da cidade. Algumas das mais conhecidas e apreciadas são: Grande Traversée du Jura, Grande Traversée des Alpes e Grande Traversée du Massif Central",
            "Muitos espectadores se fantasiam para acompanhar as competições de ciclismo de perto",
            "O recorde de maior pulo registrado sem o uso de rampas, ou varas é de 2014; com a marca de 1m e 48cm",
            "O suíço Manuel Scheidegger quebrou o recorde de distância pedalada com a bike empinada no período de uma hora, em junho de 2015. O ciclista pedalou por 25,72 km, com sua bike empinada",
            "Em outubro de 2013 o australiano Andrew Hellinga superou o recorde mundial pedalado de costas por 337km em 24 horas",
            "O alemão Christian Adam, que aprendeu a pedalar aos 4 anos de idade, combinou sua outra paixão (o violino) para quebrar o recorde mundial de ciclismo de costas tocando seu violino; o ciclista pedalou por 5 horas e 9 minutos, percorrendo os 60,4 km do recorde",
            "O ciclista polonês Krystian Herba quebrou o recorde mundial de subida em uma escadaria, com sua bike. Herba “escalou” um dos arranha-céus mais altos do mundo, o Taipei 101, que fica em Taiwan. Em cima de sua bike, ele subiu incríveis 3.139 degraus em 2 horas e 13 minutos, em março de 2015",
            "Craig Cannon pedalou por 48 horas e deu 227 voltas em um percurso do parque Tilden Regional Park em São Francisco",
            "O ciclista francês Robert Marchand quebrou o conhecido Hour Record, na categoria acima dos 100 anos de idade. Marchand pedalou 26,92 km em uma hora, o que representa 2,5 km a mais do que seu último recorde",
            "O californiano Kurt Osburn, possui o recorde de maior tempo pedalado com a bike empinada. Em 1998 Osburn pedalou durante 11 horas, com apenas a roda de trás encostando no chão"
        };

        // TODO: Change the application colors
        public static int[,] cores = new int[,] { { 0, 130, 254 },
                                                  { 65, 160, 47 },
                                                  { 235, 155, 19 },
                                                  { 229, 76, 75 },
                                                  { 227, 0, 0 },
                                                  { 1, 277, 105 },
                                                  { 254, 233, 7 },
                                                  { 0, 82, 156 },
                                                  { 35, 88, 0 },
                                                  { 255, 0, 209 },
                                                  { 227, 0, 0 },
                                                  { 128, 167, 204 },
                                                  { 255, 51, 1 },
                                                  { 232, 141, 112 },
                                                  { 2, 50, 254 },
                                                  { 221, 200, 133 }};

        // TODO: Change the menu backgraund colors
        public static Color[] backgroundColors = new Color[]
        {
            Color.FromHex("#2bcaae"),
            Color.FromHex("#18a9a6"),
            Color.FromHex("#474e5a"),
            Color.FromHex("#7cccda")
        };

        /// <summary>
        /// Pin types!
        /// </summary>
        public enum PinType
        {
            Turism,
            Danger,
            Help,
            Begin,
            End,
            Rest,
            Water   
        };

        public static string MY_PROFILE_ICON = "https://d30y9cdsu7xlg0.cloudfront.net/png/103614-200.png";
        public static string NEW_TRAIL_ICON = "http://trailapi.azurewebsites.net/assets/images/NEW_TRAIL_ICON.png";
        public static string ROUTE_HISTORIC_ICON = "http://trailapi.azurewebsites.net/assets/images/HistoricoRota.png";
        public static string TRAIL_SEARCH_ICON = "http://trailapi.azurewebsites.net/assets/images/TrailSearch.png";
        public static string BEGIN_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/begin_icon_60.png";
        public static string END_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/end_icon_60.png";
        public static string DANGER_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/Danger_Icon_60.png";
        public static string HELP_REQUEST_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/helprequest_icon_60.png";
        public static string PICTURE_POINT_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/picturepoint_icon_60.png";
        public static string REST_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/restpoint_icon_60.png";
        public static string WATER_MAP_ICON = "http://trailapi.azurewebsites.net/assets/images/water_icon_60.png";
    }
}
