// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// This application uses the Azure IoT Hub service SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/service

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace InvokeDeviceMethod
{
  /// <summary>
  /// This sample illustrates the very basics of a service app invoking a method on a device.
  /// </summary>
  internal class Program
  {
    private static ServiceClient s_serviceClient;

    // Connection string for your IoT Hub
    // az iot hub show-connection-string --hub-name {your iot hub name} --policy-name service
    private static string s_connectionString = Environment.GetEnvironmentVariable("IOTHUB_CONNECTION_STRING");
    private static string s_Device = Environment.GetEnvironmentVariable("IOTHUB_DEVICE");
    private static string s_Module = Environment.GetEnvironmentVariable("IOTHUB_MODULE");

    private static async Task Main(string[] args)
    {
      Console.WriteLine("IoT Hub Quickstarts #2 - InvokeDeviceMethod application.");

      // Create a ServiceClient to communicate with service-facing endpoint on your hub.
      s_serviceClient = ServiceClient.CreateFromConnectionString(s_connectionString);


      await InvokeMethodAsync();

      s_serviceClient.Dispose();

    }

    // Invoke the direct method on the device, passing the payload
    private static async Task InvokeMethodAsync()
    {

      await s_serviceClient.SendAsync(s_Device, s_Module, new Message() { MessageId = "Hi module", To = "hello" });
      await s_serviceClient.SendAsync(s_Device, new Message() { MessageId = "Hi client" });

    }
  }
}
