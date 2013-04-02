using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenRcp
{
	public interface IResourceService
	{
		Stream GetStream(string relativeUri, string assemblyName);
		BitmapImage GetBitmap(string relativeUri, string assemblyName);
		BitmapImage GetBitmap(string relativeUri);

        IResourceService AddResource(IResource resource);
        
        void ChangeLanguage(string language);
        string GetString(string name);
        event EventHandler LanguageChanged;
	}
}