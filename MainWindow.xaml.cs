using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WindowsGamingInput = Windows.Gaming.Input;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Core;
using SharpDX.XInput;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BluetoothPanel
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // Serial bluetooth communication
        public static readonly Guid SerialGuid = new Guid(0x00001101, 0x0000, 0x1000, 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB);

        private DispatcherQueue dispatcherQueue;

        String SelectedDeviceId;

        BluetoothDevice BTDevice;
        RfcommDeviceService BTService;
        StreamSocket BTSocket;
        private DataWriter _writer;
        private DataReader _reader;

        ObservableCollection<KeyValueListItem> KeyValueListItems = new ObservableCollection<KeyValueListItem>();
        ObservableCollection<KeyValueGridItem> KeyValueGridItems = new ObservableCollection<KeyValueGridItem>();

        private Controller currentController;
        bool listening = false;
        DispatcherTimer dispatcherTimer;
        public MainWindow()
        {
            this.InitializeComponent();
            dispatcherQueue = DispatcherQueue.GetForCurrentThread();
            LeftListView.ItemsSource = KeyValueListItems;
            RightGridView.ItemsSource = KeyValueGridItems;
            WindowsGamingInput.Gamepad.GamepadAdded += Gamepad_GamepadAdded;
        }

        private Gamepad gamepad;
        private void Gamepad_GamepadAdded(object sender, WindowsGamingInput.Gamepad e)
        {
            Debug.WriteLine("ADDED" + e);

            var controllers = new[] { new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three), new Controller(UserIndex.Four) };
            foreach (var controller in controllers)
            {
                if (controller.IsConnected)
                {
                    currentController = controller;
                }
            }
            if (currentController == null)
            {
                Debug.WriteLine("FAILED");
            }
            listening = true;
            Gamepad_GamepadListener();
            // Handle the connected gamepad.
            // You can access information about the gamepad using the 'e' parameter.
        }

        private void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            Debug.WriteLine("REMOVED" + e);
            currentController = null;
            listening = false;
            // Handle the connected gamepad.
            // You can access information about the gamepad using the 'e' parameter.
        }

        private void Gamepad_GamepadListener()
        {
            Task t = Task.Run(async () =>
            {
                while (listening)
                {
                    if (currentController == null)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        continue;
                    }
                    var state = currentController.GetState();
                    var buttons = state.Gamepad.Buttons;
                    Dictionary<String, object> dataToSend = new Dictionary<String, object>()
                    {
                        { "getLeftTrigger", state.Gamepad.LeftTrigger },
                        { "getRightTrigger", state.Gamepad.RightTrigger },
                        { "getLeftThumbX", state.Gamepad.LeftThumbX },
                        { "getLeftThumbY", state.Gamepad.LeftThumbY },
                        { "getRightThumbX", state.Gamepad.RightThumbX },
                        { "getRightThumbY", state.Gamepad.RightThumbY },
                        { "getAButton", buttons.HasFlag(GamepadButtonFlags.A) },
                        { "getBButton", buttons.HasFlag(GamepadButtonFlags.B) },
                        { "getXButton", buttons.HasFlag(GamepadButtonFlags.X) },
                        { "getYButton", buttons.HasFlag(GamepadButtonFlags.Y) },
                        { "getDPadUpButton", buttons.HasFlag(GamepadButtonFlags.DPadUp) },
                        { "getDPadDownButton", buttons.HasFlag(GamepadButtonFlags.DPadDown) },
                        { "getDPadLeftButton", buttons.HasFlag(GamepadButtonFlags.DPadLeft) },
                        { "getDPadRightButton", buttons.HasFlag(GamepadButtonFlags.DPadRight) },
                        { "getLeftShoulderButton", buttons.HasFlag(GamepadButtonFlags.LeftShoulder) },
                        { "getRightShoulderButton", buttons.HasFlag(GamepadButtonFlags.RightShoulder) },
                        { "getLeftThumbButton", buttons.HasFlag(GamepadButtonFlags.LeftThumb) },
                        { "getRightThumbButton", buttons.HasFlag(GamepadButtonFlags.RightThumb) },
                        { "getStartButton", buttons.HasFlag(GamepadButtonFlags.Start) },
                        { "getBackButton", buttons.HasFlag(GamepadButtonFlags.Back) },
                    };
                    addKeyFromApp(dataToSend);
                    await Task.Delay(TimeSpan.FromMilliseconds(20));
                   }
            });
        }

        private void addKeyFromApp(Dictionary<String, object> dataToSend)
        {
            Database.GetInstance().updateDBFromApp(dataToSend);
            UpdateLeftListView();
            UpdateRightGridView();
        }

        private void Window_Activated(object sender, Microsoft.UI.Xaml.WindowActivatedEventArgs e)
        {
            OffsetCanvasButtons(500, 500);
        }

        private void Window_SizeChanged(object sender, Microsoft.UI.Xaml.WindowSizeChangedEventArgs e)
        {
            double newWidth = e.Size.Width;
            double newHeight = e.Size.Height;

            OffsetCanvasButtons(newWidth, newHeight);
        }

        private void OffsetCanvasButtons(double width, double height)
        {
            Canvas.SetLeft(BottomRightButtonOne, width - 100);
            Canvas.SetTop(BottomRightButtonOne, height - 50);
            Canvas.SetLeft(BottomRightButtonTwo, width - 100);
            Canvas.SetTop(BottomRightButtonTwo, height - 100);
            Canvas.SetLeft(BottomRightButtonThree, width - 100);
            Canvas.SetTop(BottomRightButtonThree, height - 150);
            Canvas.SetLeft(BottomRightDropDown, width - 100);
            Canvas.SetTop(BottomRightDropDown, height - 200);
        }

        public void LeftListViewItemClicked(object sender, RoutedEventArgs e)
        {
            var tappedStackPanel = sender as StackPanel;
            var key = tappedStackPanel.DataContext as String;
            // Check if item is already in Grid View
            foreach (var item in KeyValueGridItems)
            {
                if (item.Key == key) return;
            }

            // Add Item to Grid View
            KeyValueGridItems.Add(new KeyValueGridItem(key, Database.GetInstance().data[key].ToString()));
        }

        public void GridItemFocused(object sender, RoutedEventArgs e)
        {
            var focusedTextBox = sender as TextBox;
            var key = focusedTextBox.DataContext as String;
            List<String> currentKeys = KeyValueGridItems.Select(item => item.Key).ToList();
            int index = currentKeys.IndexOf(key);
            if (index != -1)
            {
                KeyValueGridItems[index].IsFocused = true;
            }
        }

        public void GridItemUnfocused(object sender, RoutedEventArgs e)
        {
            // Remove item focus
            var focusedTextBox = sender as TextBox;
            var key = focusedTextBox.DataContext as String;
            List<String> currentKeys = KeyValueGridItems.Select(item => item.Key).ToList();
            int index = currentKeys.IndexOf(key);
            if (index != -1)
            {
                KeyValueGridItems[index].IsFocused = false;
            }
        }

        public void GridItemChanged(object sender, RoutedEventArgs e)
        {
            // Remove item focus
            var focusedTextBox = sender as TextBox;
            var key = focusedTextBox.DataContext as String;
            List<String> currentKeys = KeyValueGridItems.Select(item => item.Key).ToList();
            int index = currentKeys.IndexOf(key);

            Database instance = Database.GetInstance();
            Value currentValue = instance.data[key];
            String newValue = focusedTextBox.Text;

            KeyValueGridItems[index].Value = newValue;

            // If item is a getter, update database
            if (key.StartsWith("get"))
            {
                if (currentValue is BooleanValue)
                {
                    if (bool.TryParse(newValue, out bool bRes))
                    {
                        instance.data[key] = new BooleanValue(bRes);
                    }
                }
                else if (currentValue is NumberValue)
                {
                    if (double.TryParse(newValue, out double dRes))
                    {
                        instance.data[key] = new NumberValue(dRes);
                    }
                    else if (int.TryParse(newValue, out int iRes))
                    {
                        instance.data[key] = new NumberValue(iRes);
                    }
                }
                else if (currentValue is StringValue)
                {
                    instance.data[key] = new StringValue(newValue);
                }
            }
            UpdateLeftListView();
            UpdateRightGridView();
        }

        public void GridStackPanelClicked(object sender, PointerRoutedEventArgs e)
        {
            // Check if it is a right click
            if (e.GetCurrentPoint(sender as UIElement).Properties.IsRightButtonPressed)
            {
                var clickedStackPanel = sender as StackPanel;
                var key = clickedStackPanel.DataContext as String;
                List<String> currentKeys = KeyValueGridItems.Select(item => item.Key).ToList();
                int index = currentKeys.IndexOf(key);
                if (index != -1)
                {
                    KeyValueGridItems.RemoveAt(index);
                }
            }

        }

        public async void FindBluetoothConnections(object sender, RoutedEventArgs e)
        {
            BottomRightButtonTwo.IsEnabled = false;
            DeviceInformationCollection PairedBluetoothDevices =
       await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelectorFromPairingState(true));

            BottomRightDropDownFlyout.Items.Clear();

            Debug.WriteLine("Paired Devices: ");
            foreach (DeviceInformation device in PairedBluetoothDevices)
            {
                Debug.WriteLine(device.Name.ToString());
                MenuFlyoutItem temp = new MenuFlyoutItem { Text = device.Name };
                temp.Click += (s, e) =>
                {
                    DropDownSelected(device.Id);
                };
                BottomRightDropDownFlyout.Items.Add(temp);
            }
            BottomRightButtonTwo.IsEnabled = true;
        }

        public void ConnectToDevice(object sender, RoutedEventArgs e)
        {
            // await ConnectToDevice();
            _reader = null;
            _writer = null;
            BTSocket.Dispose();
            BTSocket = null;
            BTService.Dispose();
            BTService = null;
            BTDevice.Dispose();
            BTDevice = null;
            Database.GetInstance().resetShouldSendData();
        }

        public void ResetShouldSendData(object sender, RoutedEventArgs e)
        {
            Database.GetInstance().resetShouldSendData();
        }

        public async Task<bool> ConnectToDevice()
        {
            bool retVal = false;
            BottomRightButtonOne.IsEnabled = false;
            try
            {
                BTDevice = await BluetoothDevice.FromIdAsync(SelectedDeviceId);
                var result = await BTDevice.GetRfcommServicesForIdAsync(RfcommServiceId.FromUuid(SerialGuid));
                if (result.Services.Count > 0)
                {
                    BTService = result.Services[0];
                    BTSocket = new StreamSocket();
                    // Connect to thingy
                    await BTSocket.ConnectAsync(BTService.ConnectionHostName, BTService.ConnectionServiceName,
                        SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);

                    _writer = new DataWriter(BTSocket.OutputStream);
                    _reader = new DataReader(BTSocket.InputStream);

                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not connect to Serial Device");
                Console.WriteLine($"Error: {e}");
            }

            BottomRightButtonOne.IsEnabled = true;
            return retVal;
        }

        public async void DropDownSelected(String selected)
        {
            Debug.WriteLine(selected);
            SelectedDeviceId = selected;
            await ConnectToDevice();
            ReadListener(_reader);
            WriteSender(_writer);
        }

        public void ReadListener(DataReader reader)
        {
            Task t = Task.Run(async () =>
            {
                Debug.WriteLine("Started");
                StringBuilder receiveBuffer = new StringBuilder();
                while (true)
                {
                    if (reader == null) { return; }
                    uint buf;
                    buf = await reader.LoadAsync(1);
                    if (reader.UnconsumedBufferLength > 0)
                    {
                        string s = reader.ReadString(1);
                        if (s.Equals("\n") || s.Equals("\r"))
                        {
                            try
                            {
                                OnMessageReceived(receiveBuffer.ToString());
                                receiveBuffer.Clear();
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                        }
                        else
                        {
                            receiveBuffer.Append(s);
                        }
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromSeconds(0));
                    }
                }
            });
        }

        public void OnMessageReceived(String message)
        {
            Debug.WriteLine(message);
            try
            {
                Dictionary<String, object> temp = JsonSerializer.Deserialize<Dictionary<String, object>>(message);
                Database.GetInstance().updateDB(temp);
                UpdateLeftListView();
                UpdateRightGridView();
            }
            catch (Exception e)
            {
                // TODO: FUTURE ME FIX THE ERROR BEING TRHROWN IN THS FUNCTION
                // Debug.WriteLine(e);
            }
        }

        public void WriteSender(DataWriter writer)
        {
            Task t = Task.Run(async () => {
                while (true)
                {
                    if (writer == null) return;
                    try
                    {
                        String db = Database.GetInstance().ToString();
                        writer.WriteString(db + "|");
                        await writer.StoreAsync();
                        await Task.Delay(50);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return;
                    }

                }
            });
        }

        public void UpdateLeftListView()
        {
            // Update UI From non UI Thread
            dispatcherQueue.TryEnqueue(() => {
                List<String> currentKeys = KeyValueListItems.Select(item => item.Key).ToList();
                foreach (var item in Database.GetInstance().data)
                {
                    int index = currentKeys.IndexOf(item.Key);
                    // Is item in UI?
                    if (index != -1)
                    {
                        // ITEM ALREADY IN UI
                        // Check if value is different
                        if (KeyValueListItems[index].Value != item.Value.ToString())
                        {
                            // Value is different, update value
                            KeyValueListItems[index] = new KeyValueListItem(item.Key, item.Value.ToString());
                        }
                    }
                    else
                    {
                        // ITEM NOT IN UI
                        // Add item to UI
                        KeyValueListItems.Add(new KeyValueListItem(item.Key, item.Value.ToString()));
                    }
                }
            });

        }

        public void UpdateRightGridView()
        {
            dispatcherQueue.TryEnqueue(() =>
            {
                List<String> currentKeys = KeyValueGridItems.Select(item => item.Key).ToList();
                foreach (var item in Database.GetInstance().data)
                {
                    int index = currentKeys.IndexOf(item.Key);
                    // Is item in UI?
                    if (index != -1)
                    {
                        // ITEM ALREADY IN UI
                        // If item is being edited, do not update
                        if (KeyValueGridItems[index].IsFocused)
                        {
                            continue;
                        }
                        // Check if value is different
                        if (KeyValueGridItems[index].Value != item.Value.ToString())
                        {
                            // Value is different, update value
                            KeyValueGridItems[index] = new KeyValueGridItem(item.Key, item.Value.ToString());
                        }
                    }
                }
            });
        }
    }

    public class KeyValueListItem
    {
        public String Key { get; set; }
        public String Value { get; set; }

        public KeyValueListItem(String Key, String Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }

    public class KeyValueGridItem
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public bool IsFocused { get; set; }
        public KeyValueGridItem(String Key, String Value)
        {
            this.Key = Key;
            this.Value = Value;
            this.IsFocused = false;
        }
    }
}
