using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WeatherAppDemo;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp5DayDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherApp : Page
    {
        public class DataWeatherApp
        {
            public TextBlock ResultText { get; set; }

            public Image ResultImage { get; set; }
        }

        List<DataWeatherApp> listData;

        public WeatherApp()
        {
            this.InitializeComponent();
            listData = new List<DataWeatherApp>();
            listData.Add(new DataWeatherApp { ResultText = ResultTextblock1, ResultImage = ResultImage1 });
            listData.Add(new DataWeatherApp { ResultText = ResultTextblock2, ResultImage = ResultImage2 });
            listData.Add(new DataWeatherApp { ResultText = ResultTextblock3, ResultImage = ResultImage3 });
            listData.Add(new DataWeatherApp { ResultText = ResultTextblock4, ResultImage = ResultImage4 });
            listData.Add(new DataWeatherApp { ResultText = ResultTextblock5, ResultImage = ResultImage5 });
        }

        private async void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            RootObject MyWeather = await APIManager.GetWeather();

            for (int i = 0; i < MyWeather.list.Count; i++)
            {
                String s = MyWeather.list[i].dt_txt[11] + "" + MyWeather.list[i].dt_txt[12];
                if (s == "12")
                {
                    String icon = string.Format("ms-appx:///Assets/Weather/{0}.png", MyWeather.list[i].weather[0].icon);

                    String res = MyWeather.list[i].dt_txt + "\n" + MyWeather.list[i].main.temp + "oC\n" +
                        MyWeather.list[i].weather[0].description;
                    for (int j = 0; j < listData.Count; j++)
                    {
                        if (listData[j].ResultText.Text == "")
                        {
                            listData[j].ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                            listData[j].ResultText.Text = res;
                            break;
                        }
                    }
                }

            }

        }
    }
}