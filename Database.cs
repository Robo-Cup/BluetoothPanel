using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace BluetoothPanel
{

    public class Database
    {
        static Database Instance;
        public Dictionary<String, Value> data;
        public Dictionary<String, (string, int)> sendData;

        public Database()
        {
            data = new Dictionary<String, Value>();
            sendData = new Dictionary<String, (string, int)>();
        }

        public static Database GetInstance()
        {
            if (Instance == null)
                Instance = new Database();
            return Instance;
        }

        public void setString(String key, String value)
        {
            data[key] = new StringValue(value);
        }

        public void setNumber(String key, double value)
        {
            data[key] = new NumberValue(value);
        }

        public void setBoolean(String key, bool value)
        {
            data[key] = new BooleanValue(value);
        }

        public void updateDB(Dictionary<String, object> newData)
        {
            foreach (KeyValuePair<String, object> kv in newData)
            {
                if (kv.Key.StartsWith("get") && data.ContainsKey(kv.Key)) return;
                String value = kv.Value.ToString();
                if (double.TryParse(value, out double dRes))
                {
                    data[kv.Key] = new NumberValue(dRes);
                } else if (int.TryParse(value, out int iRes))
                {
                    data[kv.Key] = new NumberValue((double)iRes);
                } else if (bool.TryParse(value, out bool bRes))
                {
                    data[kv.Key] = new BooleanValue(bRes);
                } else
                {
                    data[kv.Key] = new StringValue(value);
                }
            }
        }

        public void updateDBFromApp(Dictionary<String, object> newData)
        {
            foreach (KeyValuePair<String, object> kv in newData)
            {
                String value = kv.Value.ToString();
                if (double.TryParse(value, out double dRes))
                {
                    data[kv.Key] = new NumberValue(dRes);
                }
                else if (int.TryParse(value, out int iRes))
                {
                    data[kv.Key] = new NumberValue((double)iRes);
                }
                else if (bool.TryParse(value, out bool bRes))
                {
                    data[kv.Key] = new BooleanValue(bRes);
                }
                else
                {
                    data[kv.Key] = new StringValue(value);
                }
            }
        }

        public void printDB()
        {
            Debug.WriteLine("printing");
            foreach (KeyValuePair<string, Value> kvp in data)
            {
                Debug.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        public override String ToString()
        {
            Dictionary<String, object> retVal = new Dictionary<string, object>();
            foreach (var item in data)
            {
                if (item.Key.StartsWith("get") && shouldSendData(item.Key, item.Value.ToString()))
                {
                    if (item.Value is NumberValue numberValue)
                    {
                        retVal.Add(item.Key, numberValue.Number);
                    } else if (item.Value is BooleanValue bValue)
                    {
                        retVal.Add(item.Key, bValue.Boolean);
                    } else
                    {
                        retVal.Add(item.Key, item.Value.ToString());
                    }
                }
            }
            // Serialize the 'data' dictionary to a JSON string
            return JsonSerializer.Serialize(retVal);
        }

        private int EXTRA_SENDS = 4;

        private bool shouldSendData(String key, String value)
        {
            if (sendData.ContainsKey(key))
            {
                (string, int) temp = sendData[key];
                if (value == temp.Item1)
                {
                    if (sendData[key].Item2 > EXTRA_SENDS)
                    {
                        return false;
                    }
                    sendData[key] = (value, temp.Item2 + 1);
                    return true;
                   
                } else
                {
                    sendData[key] = (value, 0);
                    return true;
                }
            } else
            {
                sendData[key] = (value, 0);
                return true;
            }
        }

        public void resetShouldSendData()
        {
            sendData.Clear();
        }


    }

    public abstract class Value
    {
        // This is an abstract base class for representing different value types.
        // Subclasses will define the specific value types.

        // You can add common methods or properties here if needed.
    }

    public class NumberValue : Value
    {
        public double Number { get; }

        public NumberValue(double number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public double getNumber()
        {
            return Number;
        }
    }

    public class StringValue : Value
    {
        public string String { get; }

        public StringValue(string str)
        {
            String = str;
        }

        public override String ToString()
        {
            return String;
        }
    }

    public class BooleanValue : Value
    {
        public bool Boolean { get; }

        public BooleanValue(bool boolean)
        {
            Boolean = boolean;
        }

        public override string ToString()
        {
            return Boolean.ToString();
        }
    }
}
