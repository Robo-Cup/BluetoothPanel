﻿#pragma checksum "C:\Users\nandy\Documents\GitHub\BluetoothPanel\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FD03E2FAED0B932FDA4827DFD670AB6E235C7F9EADAC27FAE5EB3E8DFBB7FDC4"
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
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_FrameworkElement_DataContext(global::Microsoft.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.DataContext = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(global::Microsoft.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_TextBox_Text(global::Microsoft.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainWindow_obj14_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IMainWindow_Bindings
        {
            private global::BluetoothPanel.KeyValueGridItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj14;
            private global::Microsoft.UI.Xaml.Controls.TextBox obj18;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj19;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj14DataContextDisabled = false;
            private static bool isobj18TextDisabled = false;
            private static bool isobj18DataContextDisabled = false;
            private static bool isobj19TextDisabled = false;

            public MainWindow_obj14_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 51 && columnNumber == 33)
                {
                    isobj14DataContextDisabled = true;
                }
                else if (lineNumber == 63 && columnNumber == 42)
                {
                    isobj18TextDisabled = true;
                }
                else if (lineNumber == 63 && columnNumber == 105)
                {
                    isobj18DataContextDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 40)
                {
                    isobj19TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 14: // MainWindow.xaml line 51
                        this.obj14 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target));
                        break;
                    case 18: // MainWindow.xaml line 63
                        this.obj18 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                        break;
                    case 19: // MainWindow.xaml line 53
                        this.obj19 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj14.Target as global::Microsoft.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::BluetoothPanel.KeyValueGridItem>(item), 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainWindow_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::BluetoothPanel.KeyValueGridItem>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BluetoothPanel.KeyValueGridItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Key(obj.Key, phase);
                        this.Update_Value(obj.Value, phase);
                    }
                }
            }
            private void Update_Key(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainWindow.xaml line 51
                    if (!isobj14DataContextDisabled)
                    {
                        if ((this.obj14.Target as global::Microsoft.UI.Xaml.Controls.StackPanel) != null)
                        {
                            XamlBindingSetters.Set_Microsoft_UI_Xaml_FrameworkElement_DataContext((this.obj14.Target as global::Microsoft.UI.Xaml.Controls.StackPanel), obj, null);
                        }
                    }
                    // MainWindow.xaml line 63
                    if (!isobj18DataContextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_FrameworkElement_DataContext(this.obj18, obj, null);
                    }
                    // MainWindow.xaml line 53
                    if (!isobj19TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj19, obj, null);
                    }
                }
            }
            private void Update_Value(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainWindow.xaml line 63
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBox_Text(this.obj18, obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainWindow_obj21_Bindings :
            global::Microsoft.UI.Xaml.IDataTemplateExtension,
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IMainWindow_Bindings
        {
            private global::BluetoothPanel.KeyValueListItem dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj21;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj24;
            private global::Microsoft.UI.Xaml.Controls.TextBlock obj25;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj21DataContextDisabled = false;
            private static bool isobj24TextDisabled = false;
            private static bool isobj25TextDisabled = false;

            public MainWindow_obj21_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 24 && columnNumber == 66)
                {
                    isobj21DataContextDisabled = true;
                }
                else if (lineNumber == 31 && columnNumber == 40)
                {
                    isobj24TextDisabled = true;
                }
                else if (lineNumber == 32 && columnNumber == 40)
                {
                    isobj25TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 21: // MainWindow.xaml line 24
                        this.obj21 = new global::System.WeakReference(global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target));
                        break;
                    case 24: // MainWindow.xaml line 31
                        this.obj24 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    case 25: // MainWindow.xaml line 32
                        this.obj25 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBlock>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            public void DataContextChangedHandler(global::Microsoft.UI.Xaml.FrameworkElement sender, global::Microsoft.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Microsoft.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj21.Target as global::Microsoft.UI.Xaml.Controls.StackPanel).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_(global::WinRT.CastExtensions.As<global::BluetoothPanel.KeyValueListItem>(item), 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainWindow_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::BluetoothPanel.KeyValueListItem>(newDataRoot);
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BluetoothPanel.KeyValueListItem obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Key(obj.Key, phase);
                        this.Update_Value(obj.Value, phase);
                    }
                }
            }
            private void Update_Key(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainWindow.xaml line 24
                    if (!isobj21DataContextDisabled)
                    {
                        if ((this.obj21.Target as global::Microsoft.UI.Xaml.Controls.StackPanel) != null)
                        {
                            XamlBindingSetters.Set_Microsoft_UI_Xaml_FrameworkElement_DataContext((this.obj21.Target as global::Microsoft.UI.Xaml.Controls.StackPanel), obj, null);
                        }
                    }
                    // MainWindow.xaml line 31
                    if (!isobj24TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj24, obj, null);
                    }
                }
            }
            private void Update_Value(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainWindow.xaml line 32
                    if (!isobj25TextDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_TextBlock_Text(this.obj25, obj, null);
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainWindow.xaml line 2
                {
                    global::Microsoft.UI.Xaml.Window element1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Window>(target);
                    ((global::Microsoft.UI.Xaml.Window)element1).SizeChanged += this.Window_SizeChanged;
                    ((global::Microsoft.UI.Xaml.Window)element1).Activated += this.Window_Activated;
                }
                break;
            case 2: // MainWindow.xaml line 14
                {
                    this.Layout = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // MainWindow.xaml line 16
                {
                    this.gridColumn0 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ColumnDefinition>(target);
                }
                break;
            case 4: // MainWindow.xaml line 17
                {
                    this.gridColumn1 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ColumnDefinition>(target);
                }
                break;
            case 5: // MainWindow.xaml line 21
                {
                    this.LeftListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                }
                break;
            case 6: // MainWindow.xaml line 40
                {
                    this.RightGridView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.GridView>(target);
                }
                break;
            case 7: // MainWindow.xaml line 73
                {
                    this.BottomRightCanvas = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Canvas>(target);
                }
                break;
            case 8: // MainWindow.xaml line 75
                {
                    this.BottomRightDropDown = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DropDownButton>(target);
                }
                break;
            case 9: // MainWindow.xaml line 80
                {
                    this.BottomRightButtonOne = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.BottomRightButtonOne).Click += this.ConnectToDevice;
                }
                break;
            case 10: // MainWindow.xaml line 81
                {
                    this.BottomRightButtonTwo = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.BottomRightButtonTwo).Click += this.FindBluetoothConnections;
                }
                break;
            case 11: // MainWindow.xaml line 82
                {
                    this.BottomRightButtonThree = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)this.BottomRightButtonThree).Click += this.ResetShouldSendData;
                }
                break;
            case 12: // MainWindow.xaml line 77
                {
                    this.BottomRightDropDownFlyout = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyout>(target);
                }
                break;
            case 14: // MainWindow.xaml line 51
                {
                    global::Microsoft.UI.Xaml.Controls.StackPanel element14 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target);
                    ((global::Microsoft.UI.Xaml.Controls.StackPanel)element14).PointerPressed += this.GridStackPanelClicked;
                }
                break;
            case 18: // MainWindow.xaml line 63
                {
                    global::Microsoft.UI.Xaml.Controls.TextBox element18 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)element18).TextChanged += this.GridItemChanged;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)element18).GotFocus += this.GridItemFocused;
                    ((global::Microsoft.UI.Xaml.Controls.TextBox)element18).LostFocus += this.GridItemUnfocused;
                }
                break;
            case 21: // MainWindow.xaml line 24
                {
                    global::Microsoft.UI.Xaml.Controls.StackPanel element21 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.StackPanel>(target);
                    ((global::Microsoft.UI.Xaml.Controls.StackPanel)element21).Tapped += this.LeftListViewItemClicked;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 14: // MainWindow.xaml line 51
                {                    
                    global::Microsoft.UI.Xaml.Controls.StackPanel element14 = (global::Microsoft.UI.Xaml.Controls.StackPanel)target;
                    MainWindow_obj14_Bindings bindings = new MainWindow_obj14_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element14.DataContext);
                    element14.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element14, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element14, bindings);
                }
                break;
            case 21: // MainWindow.xaml line 24
                {                    
                    global::Microsoft.UI.Xaml.Controls.StackPanel element21 = (global::Microsoft.UI.Xaml.Controls.StackPanel)target;
                    MainWindow_obj21_Bindings bindings = new MainWindow_obj21_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element21.DataContext);
                    element21.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Microsoft.UI.Xaml.DataTemplate.SetExtensionInstance(element21, bindings);
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element21, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

