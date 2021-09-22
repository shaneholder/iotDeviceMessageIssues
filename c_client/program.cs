// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// This application uses the Azure IoT Hub service SDK for .NET
// For samples see: https://github.com/Azure/azure-iot-sdk-csharp/tree/master/iothub/service

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace InvokeDeviceMethod
{
  /// <summary>
  /// This sample illustrates the very basics of a service app invoking a method on a device.
  /// </summary>
  internal class Program
  {
    private static ModuleClient s_ModuleClient;

    // Connection string for your IoT Hub
    // az iot hub show-connection-string --hub-name {your iot hub name} --policy-name service
    private static string s_connectionString = Environment.GetEnvironmentVariable("IotHubModuleConnectionString");

    private static async Task Main(string[] args)
    {
      Console.WriteLine($"Receive Messages on {s_connectionString}");

      // Create a ServiceClient to communicate with service-facing endpoint on your hub.
      s_ModuleClient = ModuleClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);

      await s_ModuleClient.SetMessageHandlerAsync((m, c) =>
        {
          Console.WriteLine($"received default message SetMessageHandlerAsync {m.MessageId}");
          return Task.FromResult(MessageResponse.Completed);
        }, null);
    
      await Task.Delay(600000);
    }
  }
}
