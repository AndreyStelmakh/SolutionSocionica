using System;
using System.Collections.Generic;
using UWPSocionica.Controls;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;

namespace UWPSocionica
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a <see cref="Frame">.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly DataDiamond _dataDiamond = new();
        private void SyncFeatures(HashSet<string> value)
        {
            foreach (var child in _featuresStackPanel.Children)
            {
                if (child is CheckBox control && !string.IsNullOrEmpty(control.Content.ToString()))
                    control.IsChecked = value.Contains(control.Content.ToString().ToLower());
            }
        }
        private void SyncPsychoTypes(HashSet<string> value) 
        {
            foreach (var child in _psychoTypesStackPanel.Children)
            {
                if (child is CheckBox control && !string.IsNullOrEmpty(control.Content.ToString()))
                    control.IsChecked = value.Contains(control.Content.ToString().ToLower());
            }
        }
        public MainPage()
        {
            InitializeComponent();

            _dataDiamond.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_dataDiamond.GetSelectedFeatures))
                {
                    SyncFeatures(_dataDiamond.GetSelectedFeatures());
                }

                if (e.PropertyName == nameof(_dataDiamond.GetSelectedPsychoTypes))
                {
                    SyncPsychoTypes(_dataDiamond.GetSelectedPsychoTypes());
                }
            };
        }

        private void CheckBox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            {
                if (sender is CheckBox checkBox && !string.IsNullOrEmpty(checkBox.Content.ToString()))
                {
                    string content = checkBox.Content.ToString().ToLower();

                    if (checkBox.IsChecked == true)
                    {
                        _dataDiamond.Check(content);
                    }
                    else
                    {
                        _dataDiamond.Uncheck(content);
                    }
                }
            }

            //{
            //    if (sender is CheckBox_Feature checkBox)
            //    {
            //        if (!string.IsNullOrEmpty(checkBox.Content.ToString()))
            //        {
            //            string feature = checkBox.Content.ToString().ToLower();

            //            if (checkBox.IsChecked == true)
            //            {
            //                _dataDiamond.Check(feature);
            //            }
            //            else
            //            {
            //                _dataDiamond.Uncheck(feature);
            //            }
            //        }
            //    }
            //}
        }
    }
}
