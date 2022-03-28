using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PR_13
{
    public partial class MainPage : ContentPage
    {
       
        

        public MainPage()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();

            Button button = new Button
            {
                Margin = 50,
                Padding = 50,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Нажми, чтобы вычисеть факториал"
            };

            Editor editor = new Editor
            {
                Placeholder = "Введите число",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 100,
            };

            Label labelCounter = new Label
            {
                Text = "Кликни, чтобы вывести степень из числа 2 по кол-ву кликов.",
                Margin = 50,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Default,typeof(Label))
            };

            Label labelFactorialCounter = new Label
            {
                Text = "Введи в строке положительное чилсо, чтобы вычесть факториал.",
                Margin = 50,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
            };



            editor.Keyboard = Keyboard.Telephone;
            TapGestureRecognizer tapGesture = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1
            };

            #region Возведение в степень число
            double count = 0, conutPower = 0;

            tapGesture.Tapped += (s, e) =>
            {
                count+=1;
                conutPower = Math.Pow(2, count);
                labelCounter.Text = $"{conutPower}";
            };

            labelCounter.GestureRecognizers.Add(tapGesture);
            #endregion

            #region Нажатие кнопки

            button.Clicked += (s, e) =>
            {
                 int countFactorial = 0;
                countFactorial = Convert.ToInt32(editor.Text);
                labelFactorialCounter.TextColor = Color.Default;
            
                if (countFactorial > 0)
                {
                    int Factorial = 1;

                    for (int i = 1; i <= countFactorial; i++)
                    {
                        Factorial *= i;
                        
                    }
                    labelFactorialCounter.Text = $"Факториал равен: {Factorial}";
                }

                else
                {
                    labelFactorialCounter.TextColor = Color.Red;
                    labelFactorialCounter.Text = $"Введите верное значение";
                }

            };
            #endregion


            stackLayout.Children.Add(labelCounter);
            stackLayout.Children.Add(labelFactorialCounter);
            stackLayout.Children.Add(editor);
            stackLayout.Children.Add(button);
            
            
            Content = stackLayout;
        }
    }
}
