using System.ComponentModel;
using System.IO;
using OpenRcp.Demo.Modules.TextEditor.Views;

namespace OpenRcp.Demo.Modules.TextEditor.ViewModels
{
    public class EditorViewModel : Document, IPropertySelectable
    {
        private string _originalText;
        private string _path;
        private string _fileName;
        private bool _isDirty;

        private string firstName;

        [Category("Information")]
        [DisplayName("First Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                System.Windows.MessageBox.Show(firstName);
            }
        }

        [Category("Information")]
        [DisplayName("Last Name")]
        [Description("This property uses a TextBox as the default editor.")]
        public string LastName { get; set; }

        public override string DisplayName
        {
            get
            {
                if (IsDirty)
                    return _fileName + "*";
                return _fileName;
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                if (value == _isDirty)
                    return;

                _isDirty = value;
                NotifyOfPropertyChange(() => IsDirty);
                NotifyOfPropertyChange(() => DisplayName);
            }
        }

        public override void CanClose(System.Action<bool> callback)
        {
            callback(!IsDirty);
        }

        public void Open(string path)
        {
            _path = path;
            _fileName = Path.GetFileName(_path);
        }

        protected override void OnViewLoaded(object view)
        {
            using (var stream = File.OpenText(_path))
            {
                _originalText = stream.ReadToEnd();
            }

            var editor = (EditorView)view;
            editor.textBox.Text = _originalText;

            editor.textBox.TextChanged += delegate
            {
                IsDirty = string.Compare(_originalText, editor.textBox.Text) != 0;
            };
        }

        public override bool Equals(object obj)
        {
            var other = obj as EditorViewModel;
            return other != null && string.Compare(_path, other._path) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object SelectProperty()
        {
            return this;
        }
    }
}