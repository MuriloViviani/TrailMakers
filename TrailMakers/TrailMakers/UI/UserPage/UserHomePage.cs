using TrailMakers.Business;
using TrailMakers.Business.Interface;
using Xamarin.Forms;
using Newtonsoft.Json;
using TrailMakers.Entity;
using TrailMakers.DataAndHelper;
using System;

namespace TrailMakers.UI.UserPage
{
    public class UserHomePage : ContentPage
    {
        private Label userName, userCompleteName;
        private Image userImage;
        private Entry txtUsercompleteName, txtUserName, txtAge, txtEmail;
        private Editor txtUserDetail;
        private Button btnSave, btnCancel;

        ISaveAndLoad fileServices = DependencyService.Get<ISaveAndLoad>();
        ApiRequestN apiServices;

        public UserHomePage()
        {
            BackgroundColor = Color.White;

            apiServices = new ApiRequestN();

            LoadData();
        }

        public async void LoadData()
        {
            bool userAvailable = false;
            var userExists = fileServices.CheckFile("user.json", false);
            User user = new User();

            if (userExists == false)
            {
                await DisplayAlert("Hey Hey!", "Parece que você é novo por aqui trilheiro!\n\nÉ importante saber que antes de qualuqer coisa é necessário que seus dados estejam cadastrados aqui para que você consiga usar tudo o uqe o App pode oferecer!", "Whaaat?");
                await DisplayAlert("Ainda não pegou?", "É simples, para que você possa criar qualquer atalho ou trilha é necessário que um usuário seja cadastrado!", "Conte-me mais");
                await DisplayAlert("Quase lá!", "Depois que você cadastrar seu usuário nós saberemos quem você é -_-", "Mas e os meus dados?");
                await DisplayAlert("¬¬", "Não se preocupe com seus dados, não faremos nenhum mal a eles, é apenas para saber que é você mesmo!", "Ahhh");
                await DisplayAlert("Yey!", "Agora para começarmos, que tal criar seu usuário? é bem rápido! coisa de 1 min =D", "Vamos nessa!");
            }
            else
            {
                userAvailable = true;
                user = await apiServices.GetUserDataAsync();
            }

            #region FILLING OF THE USER INFO
            userImage = new Image()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Source = ImageSource.FromUri(new Uri("http://simpleicon.com/wp-content/uploads/user1.png")),
                HeightRequest = 60,
                WidthRequest = 60
            };
            // TODO: Implement User Image Option

            userName = new Label()
            {
                Text = "NovoTrilheiro",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };
            if (userAvailable)
                userName.Text = user.Username;

            userCompleteName = new Label()
            {
                Text = "Seu nome de trilheiro completo",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };
            if (userAvailable)
                userCompleteName.Text = user.Name;

            txtUsercompleteName = new Entry()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "Seu nome aqui"
            };
            if (userAvailable)
                txtUsercompleteName.Text = user.Name;
            
            txtUserName = new Entry()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "Seu nome de usuário"
            };
            if (userAvailable)
                txtUserName.Text = user.Username;

            txtAge = new Entry()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 40,
                Keyboard = Keyboard.Numeric,
                Placeholder = "Anos?"
            };
            if (userAvailable)
                txtAge.Text = user.Age.ToString();

            txtEmail = new Entry()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Placeholder = "exemplo@exemplo.com"
            };
            if (userAvailable)
                txtEmail.Text = user.Email;

            txtUserDetail = new Editor()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Hey! Sou um Trilheiro!"
            };
            if (userAvailable)
                txtUserDetail.Text = user.UserDetail;

            // Buttons
            btnSave = new Button()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Salvar",
                BackgroundColor = Color.FromHex("#4CAF50")
            };

            btnSave.Clicked += async delegate
            {
                var x = await DisplayAlert("Atenção", "Após feitas estas alterações seu perfil nunca mais será o mesmo\n\n Deseja continuar?", "Com certeza!", "Esta louco?");
                if (x)
                {
                    ApiRequestN apiServices = new ApiRequestN();

                    var updateUser = new User()
                    {
                        Name = txtUsercompleteName.Text,
                        Username = txtUserName.Text,
                        Email = txtEmail.Text,
                        Age = int.Parse(txtAge.Text),
                        UserDetail = txtUserDetail.Text
                    };

                    apiServices.SetUserData(updateUser);

                    await DisplayAlert("Sucesso!", "As alterações foram aplicadas com sucesso =)", "Yey!");
                    await Navigation.PopModalAsync();
                }
            };

            btnCancel = new Button()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Cancelar",
                BackgroundColor = Color.FromHex("#F44336")
            };
            btnCancel.Clicked += async delegate
            {
                var x = await DisplayAlert("Atenção", "Deseja mesmo cancelar as alterações?", "Com certeza!", "Esta louco?");
                if (x)
                {
                    await Navigation.PopModalAsync();
                }
            };

            #endregion

            var mainStack = new StackLayout() // Main Stack
            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 0,
                Children =
                {
                    new StackLayout() // Image and Name info Stack
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.FromHex("#FF9800"),
                        Spacing = 10,
                        Padding = new Thickness(10,20,10,20),
                        Children =
                        {
                            userImage,
                            new StackLayout()
                            {
                                Spacing = 0,
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                                Children =
                                {
                                    userName,
                                    userCompleteName
                                }
                            }
                        }
                    },
                    new StackLayout () // Information Stack
                    {
                        Padding = new Thickness(10,10,10,10),
                        Children =
                        {
                            new Label()
                            {
                                Text = "Suas Informações",
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                            },
                            new Frame()
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Content = new StackLayout()
                                {
                                    Children =
                                    {
                                        new Label()
                                        {
                                            Text = "Nome completo"
                                        },
                                        txtUsercompleteName,
                                        new Label()
                                        {
                                            Text = "Nome de usuário"
                                        },
                                        txtUserName,
                                        new Label()
                                        {
                                            Text = "Sua idade"
                                        },
                                        txtAge,
                                        new Label()
                                        {
                                            Text = "Seu Email"
                                        },
                                        txtEmail,
                                        new Label()
                                        {
                                            Text = "Fale um pouco mais sobre você!"
                                        },
                                        txtUserDetail,
                                        btnSave,
                                        btnCancel
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var sv = new ScrollView()
            {
                Content = mainStack
            };
            Content = sv;
        }
    }
}