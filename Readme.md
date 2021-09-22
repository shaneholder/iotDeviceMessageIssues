cd client
npm install

set environment variable IotHubConnectionString to a device connection string
set environment variable IotHubModuleConnectionString to a module connection string
set environment varialbe DEBUG to "azure-iot-device:* azure-iot-device-mqtt:*"

node client.js

You should see output from the above debugs and two Client connected.

Build the c# sender and c_client project(s)  The c_client uses the same variables as the node project.

set the environment variable IOTHUB_CONNECTION_STRING to the hub connection string
set the enviornment variable IOTHUB_DEVICE to the device
set the environment variable IOTHUB_MODULE to the module

run Sender.exe

This should send 2 messages 

You should see c:message received
but you will not see the m:message received

however you will see:
azure-iot-device-mqtt:Mqtt message received on devices/sah-rfidprinter1/modules/hello/messages/devicebound/%24.mid=Hi%20module&%24.to=%2Fdevices%2Fsah-rfidprinter1%2Fmodules%2Fhello%2Fmessages%2FdeviceBound +3m
  azure-iot-device-mqtt:Mqtt "" +1ms

  indicating that a message for the module went through the MQTT transport but it is not ending up being emitted to the ModuleClient.

  