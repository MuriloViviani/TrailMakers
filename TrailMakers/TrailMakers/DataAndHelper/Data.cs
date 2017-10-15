using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrailMakers.DataAndHelper
{
    public class Data
    {
        // TODO: Update curiosities
        public static string[] curiosities = new string[] {
            "Jundiaí possui 401.896 habitantes. Sendo o 15º município mais populoso do estado e o sétimo maior fora da grande São Paulo",
            "O nome 'Jundiaí' é uma referência ao Rio Jundiaí, cujo nome vem da língua tupi e significa “Rio dos Jundiás”, um peixe característico da região",
            "Jundiaí é a cidade que tem o melhor saneamento do Brasil, segundo o Instituto Trata Brasil",
            "Jundiaí é a 11ª melhor cidade para se viver no Brasil, segundo a ONU",
            "Jundiaí possui cidades-irmãs, sendo elas Havana (Cuba), Pádua (Itália), Trenton (EUA) e as brasileiras Santo André e Poços de Caldas. Cidades irmãs são laços de vários níveis, como no aspecto cultural e econômico",
            "Jundiaí é vizinha de 11 municípios: Várzea Paulista, Campo Limpo Paulista, Franco da Rocha, Cajamar, Pirapora do Bom Jesus, Cabreúva, Itupeva, Louveira, Vinhedo, Itatiba e Jarinú",
            "No século 18, as ruas do centro tinham nomes diferentes dos quais são hoje. Rua Direita (atual Barão de Jundiaí), Rua do Meio (Rua do Rosário), Rua Nova (Senador Fonseca) e Rua Boa Vista (Zacarias de Góes)",
            "No século 18, se tem registro de que o ponto mais movimentado da cidade era a praça da Bandeira, onde hoje está o Terminal Central",
            "Em Jundiaí, o abastecimento de água foi implantado em 1881. A energia elétrica chegou em 1905 e o telefone em 1916",
            "Ao longo dos séculos 17, 18 e início do 19, a economia da cidade se limitava a pequenas lavouras de subsistência, que abasteciam moradores da vila, tropeiros e bandeirantes",
            "De acordo com censo realizado pelo Governo Federal, em 1920, Jundiaí possuía uma população de 44.437 habitantes",
            "Depois que o imperador D. Pedro II ordenou às províncias a criação de núcleos coloniais, o então Presidente da Província de São Paulo, Antônio de Queiroz Telles, criou quatro núcleos, entre eles “Núcleo Colonial Barão de Jundiaí”, em 4 de outubro de 1886, atual região do bairro da Colônia",
            "A Estação Ferroviária de Jundiaí foi inaugurada após sete anos de obra, em 1867. Denominada de São Paulo Railway, ela ligava a cidade portuária de Santos a São Paulo e Jundiaí.",
            "Aos poucos, tanto os imigrantes como seus descendentes foram se integrando à comunidade jundiaiense. Hoje, mais de 75% da população de Jundiaí é descendente de imigrantes italianos",
            "Jundiaí destaca-se, atualmente, no desenvolvimento das áreas cultural, educacional, tecnológica e ambiental",
            "O aniversário de Jundiaí é comemorado em 14 de dezembro",
            "O Jardim Botânico de Jundiaí, inaugurado em 29 de dezembro de 2004, com uma área de 150.000 m², surgiu como uma proposta de recuperação para uma área com longo histórico de degradação"
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
        enum PinType
        {
            Turism,
            Danger,
            Warning,
            Help,
            POI
        };
    }
}
