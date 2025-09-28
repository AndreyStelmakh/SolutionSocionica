using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPSocionica
{
    internal partial class DataDiamond : Helpers.ExtendedNotify
    {
        private static readonly Dictionary<string, HashSet<string>> _allPsychoTypes;
        private static readonly HashSet<string> _allFeatures;
        private readonly HashSet<string> _selectedFeatures = [];
        private readonly HashSet<string> _selectedPsychoTypes = [];

        public void Check(string value)
        {
            if (_selectedFeatures.Contains(value)) return;
            if (_selectedPsychoTypes.Contains(value)) return;

            if(_allFeatures.Contains(value))
            {
                _selectedFeatures.Remove(OppositeFeature(value));
                _selectedFeatures.Add(value);
                _selectedPsychoTypes.Clear();
                _selectedPsychoTypes.UnionWith(FeaturesToPsychoTypes(_selectedFeatures));

                RaisePropertyChanged(nameof(GetSelectedFeatures));
                RaisePropertyChanged(nameof(GetSelectedPsychoTypes));

                return;
            }
            if(_allPsychoTypes.ContainsKey(value))
            {
                _selectedPsychoTypes.Clear();
                _selectedPsychoTypes.Add(value);
                _selectedFeatures.Clear();
                var vals = PsychoTypesToFeatures(_selectedPsychoTypes);
                _selectedFeatures.UnionWith(vals);

                RaisePropertyChanged(nameof(GetSelectedFeatures));
                RaisePropertyChanged(nameof(GetSelectedPsychoTypes));

                return;
            }
        }
        public void Uncheck(string value)
        {
            if (_selectedFeatures.Contains(value))
            {
                _selectedFeatures.Remove(value);
                _selectedPsychoTypes.Clear();
                _selectedPsychoTypes.UnionWith(FeaturesToPsychoTypes(_selectedFeatures));

                RaisePropertyChanged(nameof(GetSelectedPsychoTypes));

                return;
            }
            if (_selectedPsychoTypes.Contains(value))
            {
                _selectedPsychoTypes.Remove(value);
                _selectedFeatures.Clear();
                _selectedFeatures.UnionWith(PsychoTypesToFeatures(_selectedPsychoTypes));

                RaisePropertyChanged(nameof(GetSelectedFeatures));

                return;
            }
        }
        public HashSet<string> GetSelectedFeatures()
        {
            return [.. _selectedFeatures.Select(s => s.ToLower())];
        }
        public HashSet<string> GetSelectedPsychoTypes()
        {
            return [.. _selectedPsychoTypes.Select(s => s.ToLower())];
        }
        static DataDiamond()
        {
            _allFeatures = [
                "экстраверсия",
                "интроверсия",
                "интуиция",
                "сенсорика",
                "логика",
                "этика",
                "динамика",
                "статика",
                "позитивизм",
                "негативизм",
                "квестимность",
                "деклатимность",
                "стратегия",
                "тактика",
                "конструктивизм",
                "эмотивизм",
                "рациональность",
                "иррациональность",
                "результат",
                "процесс",
                "упрямость",
                "уступчивость",
                "предусмотрительность",
                "беспечность",
                "рассудительность",
                "решительность",
                "веселый",
                "серьезный",
                "демократизм",
                "аристократизм"
            ];

            _allPsychoTypes = new(StringComparer.OrdinalIgnoreCase);
            _allPsychoTypes.Add("Дон Кихот",
            [
                "экстраверсия",
                "интуиция",
                "логика",
                "тактика",
                "статика",
                "позитивизм",
                "квестимность",
                "конструктивизм",
                "иррациональность",
                "процесс",
                "уступчивость",
                "беспечность",
                "рассудительность",
                "веселый",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Дюма",
            [
                "интроверсия",
                "сенсорика",
                "этика",
                "динамика",
                "негативизм",
                "деклатимность",
                "стратегия",
                "эмотивизм",
                "иррациональность",
                "процесс",
                "уступчивость",
                "беспечность",
                "рассудительность",
                "веселый",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Гюго",
            [
                "экстраверсия",
                "сенсорика",
                "этика",
                "динамика",
                "позитивизм",
                "деклатимность",
                "тактика",
                "конструктивизм",
                "рациональность",
                "результат",
                "упрямость",
                "предусмотрительность",
                "рассудительность",
                "веселый",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Робеспьер",
            [
                "интроверсия",
                "интуиция",
                "логика",
                "статика",
                "негативизм",
                "квестимность",
                "стратегия",
                "эмотивизм",
                "рациональность",
                "результат",
                "упрямость",
                "предусмотрительность",
                "рассудительность",
                "веселый",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Гамлет",
            [
                "экстраверсия",
                "интуиция",
                "этика",
                "динамика",
                "негативизм",
                "квестимность",
                "стратегия",
                "конструктивизм",
                "рациональность",
                "процесс",
                "упрямость",
                "беспечность",
                "решительность",
                "веселый",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Максим",
            [
                "интроверсия",
                "сенсорика",
                "логика",
                "статика",
                "позитивизм",
                "деклатимность",
                "тактика",
                "эмотивизм",
                "рациональность",
                "процесс",
                "упрямость",
                "беспечность",
                "решительность",
                "веселый",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Жуков",
            [
                "экстраверсия",
                "сенсорика",
                "логика",
                "статика",
                "негативизм",
                "деклатимность",
                "стратегия",
                "конструктивизм",
                "иррациональность",
                "результат",
                "уступчивость",
                "предусмотрительность",
                "решительность",
                "веселый",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Есенин",
            [
                "интроверсия",
                "интуиция",
                "этика",
                "динамика",
                "позитивизм",
                "квестимность",
                "тактика",
                "эмотивизм",
                "иррациональность",
                "результат",
                "уступчивость",
                "предусмотрительность",
                "решительность",
                "веселый",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Наполеон",
            [
                "экстраверсия",
                "сенсорика",
                "этика",
                "статика",
                "позитивизм",
                "квестимность",
                "стратегия",
                "эмотивизм",
                "иррациональность",
                "процесс",
                "упрямость",
                "предусмотрительность",
                "решительность",
                "серьезный",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Бальзак",
            [
                "интроверсия",
                "интуиция",
                "логика",
                "динамика",
                "негативизм",
                "деклатимность",
                "тактика",
                "конструктивизм",
                "иррациональность",
                "процесс",
                "упрямость",
                "предусмотрительность",
                "решительность",
                "серьезный",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Джек",
            [
                "экстраверсия",
                "интуиция",
                "логика",
                "динамика",
                "позитивизм",
                "деклатимность",
                "стратегия",
                "эмотивизм",
                "рациональность",
                "результат",
                "уступчивость",
                "беспечность",
                "решительность",
                "серьезный",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Драйзер",
            [
                "интроверсия",
                "сенсорика",
                "этика",
                "статика",
                "негативизм",
                "квестимность",
                "тактика",
                "конструктивизм",
                "рациональность",
                "результат",
                "уступчивость",
                "беспечность",
                "решительность",
                "серьезный",
                "демократизм",
            ]);
            _allPsychoTypes.Add("Штирлиц",
            [
                "экстраверсия",
                "сенсорика",
                "логика",
                "динамика",
                "негативизм",
                "квестимность",
                "тактика",
                "эмотивизм",
                "рациональность",
                "процесс",
                "уступчивость",
                "предусмотрительность",
                "рассудительность",
                "серьезный",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Достоевский",
            [
                "интроверсия",
                "интуиция",
                "этика",
                "статика",
                "позитивизм",
                "деклатимность",
                "стратегия",
                "конструктивизм",
                "рациональность",
                "процесс",
                "уступчивость",
                "предусмотрительность",
                "рассудительность",
                "серьезный",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Гексли",
            [
                "экстраверсия",
                "интуиция",
                "этика",
                "статика",
                "негативизм",
                "деклатимность",
                "тактика",
                "эмотивизм",
                "иррациональность",
                "результат",
                "упрямость",
                "беспечность",
                "рассудительность",
                "серьезный",
                "аристократизм",
            ]);
            _allPsychoTypes.Add("Габен",
            [
                "интроверсия",
                "сенсорика",
                "логика",
                "динамика",
                "позитивизм",
                "квестимность",
                "стратегия",
                "конструктивизм",
                "иррациональность",
                "результат",
                "упрямость",
                "беспечность",
                "рассудительность",
                "серьезный",
                "аристократизм",
            ]);
        }

        public static HashSet<string> PsychoTypesToFeatures(HashSet<string> psychoTypes)
        {
            HashSet<string> result = [];

            if (psychoTypes.Count == 0) return result;

            foreach (var pt in psychoTypes)
            {
                if (_allPsychoTypes.ContainsKey(pt))
                {
                    result.UnionWith(_allPsychoTypes[pt]);
                }
            }

            return result;
        }
        public static HashSet<string>FeaturesToPsychoTypes(HashSet<string> features)
        {
            HashSet<string> result = [];
            if (features.Count == 0)
            {
                return result;
            }
            foreach (var pt in _allPsychoTypes)
            {
                if (pt.Value.IsSupersetOf(features))
                {
                    result.Add(pt.Key);
                }
            }
            return result;
        }
        public static string OppositeFeature(string feature)
        {
            return feature switch
            {
                "экстраверсия" => "интроверсия",
                "интроверсия" => "экстраверсия",
                "интуиция" => "сенсорика",
                "сенсорика" => "интуиция",
                "логика" => "этика",
                "этика" => "логика",
                "динамика" => "статика",
                "статика" => "динамика",
                "позитивизм" => "негативизм",
                "негативизм" => "позитивизм",
                "квестимность" => "деклатимность",
                "деклатимность" => "квестимность",
                "стратегия" => "тактика",
                "тактика" => "стратегия",
                "конструктивизм" => "эмотивизм",
                "эмотивизм" => "конструктивизм",
                "рациональность" => "иррациональность",
                "иррациональность" => "рациональность",
                "результат" => "процесс",
                "процесс" => "результат",
                "упрямость" => "уступчивость",
                "уступчивость" => "упрямость",
                "предусмотрительность" => "беспечность",
                "беспечность" => "предусмотрительность",
                "рассудительность" => "решительность",
                "решительность" => "рассудительность",
                "веселый" => "серьезный",
                "серьезный" => "веселый",
                "демократизм" => "аристократизм",
                "аристократизм" => "демократизм",
                _ => "",
            };
        }
    }
}
