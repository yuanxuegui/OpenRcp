using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;

namespace OpenRcp
{
    [Export(typeof(IModule))]
    public class ThemeModule : ModuleBase
    {
        protected override void PreInit()
        {
            PublishMessage(new ModuleInitMessage
            {
                Content = "Loading Theme Module"
            });
        }

        protected override void RegisterMenus()
        {
            IList<RadioMenuItem> themeGroup = new List<RadioMenuItem>();
            MainMenu["Tool"].Add(new MenuItem("Theme"){
                new RadioMenuItem("Dark", themeGroup, changeThemeToDark),
                new RadioMenuItem("Light", themeGroup, changeThemeToLight),
                new RadioMenuItem("VS2010", themeGroup, changeThemeToVS2010)
            });
        }

        private IEnumerable<IResult> changeThemeToDark(bool isChecked)
        {
            if (isChecked)
            {
                MahApps.Metro.ThemeManager.ChangeTheme(Application.Current.MainWindow, MahApps.Metro.ThemeManager.DefaultAccents.First(a => a.Name == "Blue"), MahApps.Metro.Theme.Dark);
                yield break;
            }
            else
            {
                yield return ResultsHelper.ChangeTheme("Default");
            }
        }

        private IEnumerable<IResult> changeThemeToLight(bool isChecked)
        {
            if (isChecked)
            {
                MahApps.Metro.ThemeManager.ChangeTheme(Application.Current.MainWindow, MahApps.Metro.ThemeManager.DefaultAccents.First(a => a.Name == "Blue"), MahApps.Metro.Theme.Light);
                yield break;
            }
            else
            {
                yield return ResultsHelper.ChangeTheme("Default");
            }
        }

        private IEnumerable<IResult> changeThemeToVS2010(bool isChecked)
        {
            if (isChecked)
            {
                yield return ResultsHelper.ChangeTheme("VS2010");
            }
            else
            {
                yield return ResultsHelper.ChangeTheme("Default");
            }
        }
    }
}