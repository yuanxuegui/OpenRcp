using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using System.ComponentModel;

namespace OpenRcp.Desktop.Exhibition.Modules.DevicesToolBox.ViewModels
{
    [Export(typeof(DevicesToolBoxViewModel))]
    public class DevicesToolBoxViewModel : Tool
    {
        private string hello;

        [Category("Information")]
        [DisplayName("Hello String")]
        [Description("This property uses a TextBox as the default editor.")]
        public string Hello
        {
            get { return hello; }
            set { hello = value; }
        }

        public DevicesToolBoxViewModel()
        {
            hello = "Hello World";
        }
        
        public override PaneLocation PreferredLocation
        {
            get { return PaneLocation.Left; }
        }

        public override string DisplayName
        {
            get
            {
                return "设备工具箱";
            }
            set
            {
                base.DisplayName = value;
            }
        }

        private TestPropertyModel TestProperty = new TestPropertyModel()
        {
            Name = "Yuan"
        };

        public void Test()
        {
            MessageBox.Show("Hello");
            SelectPropertyObject(TestProperty);
        }

        public bool CanTest()
        {
            return true;
        }

    }

    public class TestPropertyModel
    {
        public string Name { get; set; }
    }
}
