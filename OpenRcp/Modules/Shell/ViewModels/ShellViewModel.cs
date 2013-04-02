﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;

namespace OpenRcp
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<IDocument>.Collection.OneActive, IShell
    {
        [ImportMany(typeof(IModule))]
        private IEnumerable<IModule> _modules = null;
        
        private WindowState _windowState = WindowState.Normal;
        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                _windowState = value;
                NotifyOfPropertyChange(() => WindowState);
            }
        }

        private string _title = "[Default Title]";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                NotifyOfPropertyChange(() => Icon);
            }
        }

        [Import]
        private IMenu _mainMenu = null;
        public IMenu MainMenu
        {
            get { return _mainMenu; }
        }

        [Import]
        private IStatusBar _statusBar = null;
        public IStatusBar StatusBar
        {
            get { return _statusBar; }
        }

        private readonly BindableCollection<ITool> _tools;
        public IObservableCollection<ITool> Tools
        {
            get { return _tools; }
        }

        public IObservableCollection<IDocument> Documents
        {
            get { return Items; }
        }

        public ShellViewModel()
        {
            _tools = new BindableCollection<ITool>();       
        }

        protected override void OnViewLoaded(object view)
        {
            foreach (IModule module in _modules)
                module.Initialize();
            base.OnViewLoaded(view);
        }

        public void ShowTool(ITool model)
        {
            if (!Tools.Contains(model))
            {
                Tools.Add(model);
            }
            model.IsVisible = true;
            model.Activate();
        }

        public void HideTool(ITool model)
        {
            if (Tools.Contains(model))
            {
                model.IsVisible = false;
            }
        }

        public void OpenDocument(IDocument model)
        {
            ActivateItem(model);
        }

        public void CloseDocument(IDocument document)
        {
            DeactivateItem(document, true);
        }

        public void ActivateDocument(IDocument document)
        {
            ActivateItem(document);
        }

        public void Close()
        {
            Application.Current.MainWindow.Close();
        }
    }
}