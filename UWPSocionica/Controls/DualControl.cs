using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPSocionica.Controls
{
    internal partial class DualControl : Control
    {
        private CheckBox? _firstCheckBox;
        private CheckBox? _secondCheckBox;
        public DualControl()
        {
            
        }
        public static readonly DependencyProperty SelectedFeatureProperty =
            DependencyProperty.Register(nameof(SelectedFeature), typeof(string), typeof(DualControl), new PropertyMetadata(""));

        public string SelectedFeature
        {
            get => (string)GetValue(SelectedFeatureProperty);
            set => SetValue(SelectedFeatureProperty, value);
        }



        public string FirstFeature
        {
            get { return (string)GetValue(FirstFeatureProperty); }
            set { SetValue(FirstFeatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstFeature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstFeatureProperty =
            DependencyProperty.Register(nameof(FirstFeature), typeof(string), typeof(DualControl), new PropertyMetadata(""));



        public string SecondFeature
        {
            get { return (string)GetValue(SecondFeatureProperty); }
            set { SetValue(SecondFeatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondFeature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondFeatureProperty =
            DependencyProperty.Register(nameof(SecondFeature), typeof(string), typeof(DualControl), new PropertyMetadata(""));

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _firstCheckBox = GetTemplateChild("FirstCheckBox") as CheckBox;
            if (_firstCheckBox != null)
            {
                _firstCheckBox.Checked += FirstCheckBox_Checked;
                _firstCheckBox.Unchecked += (s, e) =>
                {
                    if (_secondCheckBox != null && _secondCheckBox.IsChecked == false)
                        SelectedFeature = "";
                };
            }

            _secondCheckBox = GetTemplateChild("SecondCheckBox") as CheckBox;
            if (_secondCheckBox != null)
            {
                _secondCheckBox.Checked += SecondCheckBox_Checked;
                _secondCheckBox.Unchecked += (s, e) =>
                {
                    if (_firstCheckBox != null && _firstCheckBox.IsChecked == false)
                        SelectedFeature = "";
                };
            }
        }

        private void FirstCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SelectedFeature = FirstFeature;

            if(_secondCheckBox != null)
                _secondCheckBox.IsChecked = false;
        }

        private void SecondCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SelectedFeature = SecondFeature;

            if (_firstCheckBox != null)
                _firstCheckBox.IsChecked = false;
        }

    }
}
