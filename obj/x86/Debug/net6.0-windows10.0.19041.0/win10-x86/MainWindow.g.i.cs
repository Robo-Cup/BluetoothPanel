// Updated by XamlIntelliSenseFileGenerator 9/29/2023 6:20:03 PM
#pragma checksum "C:\Users\nandy\Documents\GitHub\BluetoothPanel\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FD03E2FAED0B932FDA4827DFD670AB6E235C7F9EADAC27FAE5EB3E8DFBB7FDC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BluetoothPanel
{
    partial class MainWindow : global::Microsoft.UI.Xaml.Window
    {
#pragma warning restore 0649
#pragma warning restore 0169
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2306")]
        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;

            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///MainWindow.xaml");
            global::Microsoft.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Microsoft.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }

        partial void UnloadObject(global::Microsoft.UI.Xaml.DependencyObject unloadableObject);

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2306")]
        private interface IMainWindow_Bindings
        {
            void Initialize();
            void Update();
            void StopTracking();
            void DisconnectUnloadedObject(int connectionId);
        }

        private interface IMainWindow_BindingsScopeConnector
        {
            global::System.WeakReference Parent { get; set; }
            bool ContainsElement(int connectionId);
            void RegisterForElementConnection(int connectionId, global::Microsoft.UI.Xaml.Markup.IComponentConnector connector);
        }

        internal global::Microsoft.UI.Xaml.Controls.Grid Layout;
        internal global::Microsoft.UI.Xaml.Controls.ColumnDefinition gridColumn0;
        internal global::Microsoft.UI.Xaml.Controls.ColumnDefinition gridColumn1;
        internal global::Microsoft.UI.Xaml.Controls.ListView LeftListView;
        internal global::Microsoft.UI.Xaml.Controls.GridView RightGridView;
        internal global::Microsoft.UI.Xaml.Controls.Canvas BottomRightCanvas;
        internal global::Microsoft.UI.Xaml.Controls.DropDownButton BottomRightDropDown;
        internal global::Microsoft.UI.Xaml.Controls.MenuFlyout BottomRightDropDownFlyout;
        internal global::Microsoft.UI.Xaml.Controls.Button BottomRightButtonOne;
        internal global::Microsoft.UI.Xaml.Controls.Button BottomRightButtonTwo;
        internal global::Microsoft.UI.Xaml.Controls.Button BottomRightButtonThree;
#pragma warning restore 0649
#pragma warning restore 0169
    }
}


