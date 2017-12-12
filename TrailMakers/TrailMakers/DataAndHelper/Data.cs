using System;
using System.Collections.Generic;
using TrailMakers.Entity;
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


        public static List<Historic> DemoHist = new List<Historic>(){
            new Historic()
            {
                Id = 0,
                Name = "Trilha para passar o tempo",
                Description = "Uma trilha bem rápida, com alguns momentos para apreciar a vista e com um inicio corrido, com muitas pessoas, animais carros e tudo mais, mas depois de um tempo tudo isso se acalmaa em um caminho florestado e tranquilo",
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                TrailPath = new List<Location>()
                {
                    new Location()
                    {
                        Latitude = -23.359192,
                        Longitude = -46.735441
                    },
                    new Location()
                    {
                        Latitude = -23.358897,
                        Longitude = -46.735538
                    },
                    new Location()
                    {
                        Latitude = -23.358266,
                        Longitude = -46.735270
                    },
                    new Location()
                    {
                        Latitude = -23.357416,
                        Longitude = -46.736457
                    },
                    new Location()
                    {
                        Latitude = -23.357495,
                        Longitude = -46.737895
                    },
                    new Location()
                    {
                        Latitude = -23.356126,
                        Longitude = -46.740148
                    },
                    new Location()
                    {
                        Latitude = -23.355377,
                        Longitude = -46.741467
                    },
                    new Location()
                    {
                        Latitude = -23.355692,
                        Longitude = -46.741703
                    },
                    new Location()
                    {
                        Latitude = -23.356973,
                        Longitude = -46.740459
                    },
                    new Location()
                    {
                        Latitude = -23.358086,
                        Longitude = -46.738549
                    },
                    new Location()
                    {
                        Latitude = -23.360361,
                        Longitude = -46.736178
                    },
                    new Location()
                    {
                        Latitude = -23.362719,
                        Longitude = -46.735915
                    },
                    new Location()
                    {
                        Latitude = -23.364876,
                        Longitude = -46.734424
                    },
                    new Location()
                    {
                        Latitude = -23.366629,
                        Longitude = -46.732685
                    }
                },
                Poi = new List<POI>()
                {
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Turism,
                        Latitude = -23.358266,
                        Longitude = -46.735270
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Begin,
                        Latitude = -23.359192,
                        Longitude = -46.735441
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.End,
                        Latitude = -23.366629,
                        Longitude = -46.732685
                    }
                }
            },
            new Historic()
    {
        Id = 1,
                Name = "Trilha In-City",
                Description = "Se você gosta de uma trilha rápida com muitos obstaculos e com um diferencial, esta entrando na trilha certa, esta trilha possibilita que você conheça a cidade inteira de Caieiras e de quebra tome alguns drinks em alguns dos melores bares da cidade",
                Date = DateTime.Now.ToString("dd/MM/yyyy"),
                TrailPath = new List<Location>()
                {
                    new Location()
                    {
                        Latitude = -23.356987,
                        Longitude = -46.740722
                    },
                    new Location()
                    {
                        Latitude = -23.359618,
                        Longitude = -46.741367
                    },
                    new Location()
                    {
                        Latitude = -23.360622,
                        Longitude = -46.741924
                    },
                    new Location()
                    {
                        Latitude = -23.359804,
                        Longitude = -46.743960
                    },
                    new Location()
                    {
                        Latitude = -23.360785,
                        Longitude = -46.745574
                    },
                    new Location()
                    {
                        Latitude = -23.362430,
                        Longitude = -46.746981
                    },
                    new Location()
                    {
                        Latitude = -23.363090,
                        Longitude = -46.747801
                    },
                    new Location()
                    {
                        Latitude = -23.364243,
                        Longitude = -46.748753
                    },
                    new Location()
                    {
                        Latitude = -23.365303,
                        Longitude = -46.750272
                    },
                    new Location()
                    {
                        Latitude = -23.366344,
                        Longitude = -46.750941
                    },
                    new Location()
                    {
                        Latitude = -23.366307,
                        Longitude = -46.751427
                    },
                    new Location()
                    {
                        Latitude = -23.366809,
                        Longitude = -46.751781
                    },
                    new Location()
                    {
                        Latitude = -23.367357,
                        Longitude = -46.751477
                    },
                    new Location()
                    {
                        Latitude = -23.367673,
                        Longitude = -46.751741
                    },
                    new Location()
                    {
                        Latitude = -23.367469,
                        Longitude = -46.751943
                    },
                    new Location()
                    {
                        Latitude = -23.363341,
                        Longitude = -46.751953
                    },
                    new Location()
                    {
                        Latitude = -23.362374,
                        Longitude = -46.750363
                    },
                    new Location()
                    {
                        Latitude = -23.360887,
                        Longitude = -46.749229
                    },
                    new Location()
                    {
                        Latitude = -23.357642,
                        Longitude = -46.748004
                    },
                    new Location()
                    {
                        Latitude = -23.356680,
                        Longitude = -46.745115
                    },
                    new Location()
                    {
                        Latitude = -23.355443,
                        Longitude = -46.743515
                    },
                    new Location()
                    {
                        Latitude = -23.355806,
                        Longitude = -46.741783
                    },
                    new Location()
                    {
                        Latitude = -23.356515,
                        Longitude = -46.740812
                    },
                    new Location()
                    {
                        Latitude = -23.357055,
                        Longitude = -46.740721
                    },
                },
                Poi = new List<POI>()
                {
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Turism,
                        Latitude = -23.366574,
                        Longitude = -46.751611
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Water,
                        Latitude = -23.360171,
                        Longitude = -46.744481
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Danger,
                        Latitude = -23.360579,
                        Longitude = -46.742065
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Turism,
                        Latitude = -23.357682,
                        Longitude = -46.747983
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Begin,
                        Latitude = -23.356987,
                        Longitude = -46.740722
                    },
                    new POI()
                    {
                        Type = DataAndHelper.Data.PinType.End,
                        Latitude = -23.357055,
                        Longitude = -46.740721
                    }
                }
            }
        };

        public static string PRESENTATION_ICON = "http://trainway.azurewebsites.net/media/presentation.png";
        public static string MY_PROFILE_ICON = "http://trainway.azurewebsites.net/media/userPage.png";
        public static string NEW_TRAIL_ICON = "http://trainway.azurewebsites.net/media/NEW_TRAIL_ICON.png";
        public static string ROUTE_HISTORIC_ICON = "http://trainway.azurewebsites.net/media/HistoricoRota.png";
        public static string TRAIL_SEARCH_ICON = "http://trainway.azurewebsites.net/media/TrailSearch.png";
        public static string BEGIN_MAP_ICON = "http://trainway.azurewebsites.net/media/begin_icon_60.png";
        public static string END_MAP_ICON = "http://trainway.azurewebsites.net/media/end_icon_60.png";
        public static string DANGER_MAP_ICON = "http://trainway.azurewebsites.net/media/Danger_Icon_60.png";
        public static string HELP_REQUEST_MAP_ICON = "http://trainway.azurewebsites.net/media/helprequest_icon_60.png";
        public static string PICTURE_POINT_MAP_ICON = "http://trainway.azurewebsites.net/media/picturepoint_icon_60.png";
        public static string REST_MAP_ICON = "http://trainway.azurewebsites.net/media/restpoint_icon_60.png";
        public static string WATER_MAP_ICON = "http://trainway.azurewebsites.net/media/water_icon_60.png";
    }
}
