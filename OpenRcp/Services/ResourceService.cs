using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace OpenRcp
{
	[Export(typeof(IResourceService))]
	public class ResourceService : IResourceService
	{
        public IList<IResource> Resources { get; set; }

        public ResourceService()
        {
            Resources = new List<IResource>();
        }
        
        public Stream GetStream(string relativeUri, string assemblyName)
		{
			try
			{
				var resource = Application.GetResourceStream(new Uri(assemblyName + ";component/" + relativeUri, UriKind.Relative))
					?? Application.GetResourceStream(new Uri(relativeUri, UriKind.Relative));

				return (resource != null)
					? resource.Stream
					: null;
			}
			catch
			{
				return null;
			}
		}

		public BitmapImage GetBitmap(string relativeUri, string assemblyName)
		{
			var s = GetStream(relativeUri, assemblyName);
			if (s == null) return null;

			using (s)
			{
				var bmp = new BitmapImage();
				bmp.BeginInit();
				bmp.StreamSource = s;
				bmp.EndInit();
				bmp.Freeze();
				return bmp;
			}
		}

		public BitmapImage GetBitmap(string relativeUri)
		{
			return GetBitmap(relativeUri, ExtensionMethods.GetExecutingAssemblyName());
		}


        public void ChangeLanguage(string language)
        {
            CultureInfo culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Resources.Apply(item => item.CurrentCulture = culture);

            IEventAggregator eventAggregator = IoC.Get<IEventAggregator>();
            eventAggregator.Publish(new LanguageChangedMessage());

            if (LanguageChanged != null)
            {
                LanguageChanged(this, null);
            }
        }

        public string GetString(string name)
        {
            string str = null;

            foreach (var resource in Resources)
            {
                str = resource.GetString(name);
                if (str != null)
                {
                    break;
                }
            }
            return str;
        }

        public event EventHandler LanguageChanged;


        public IResourceService AddResource(IResource resource)
        {
            Resources.Add(resource);
            return this;
        }
    }
}