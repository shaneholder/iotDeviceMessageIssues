// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

'use strict';

// var Protocol = require('azure-iot-device-mqtt').Mqtt;
// var ModuleClient = require('azure-iot-device').ModuleClient;

import pkg from 'azure-iot-device';
const { ModuleClient, Client } = pkg;

import { Mqtt } from 'azure-iot-device-mqtt'
const Protocol = Mqtt

var client = Client.fromConnectionString(process.env.IotHubConnectionString, Mqtt);

client.on('message', (d) => {
  console.log("c:message received", d)
});

client.on('inputMessage',  (d) => {
  console.log('c:inputMessage received', d)
});

client.onDeviceMethod('onDeviceMethod', (d) => {
  console.log('c:invoked', d);
})

var mClient = ModuleClient.fromConnectionString(process.env.IotHubModuleConnectionString, Mqtt);

mClient.on('message', (d) => {
  console.log("m:message received", d)
});

mClient.on('inputMessage',  (d) => {
  console.log('m:inputMessage received', d)
});

mClient.onMethod('onDeviceMethod', (d) => {
  console.log('m:invoked', d);
})

// connect to the edge instance
client.open(function (err) {
  if (err) {
    console.error('Could not connect: ' + err.message);
  } else {
    console.log('Client connected');
  }
});

mClient.open(function (err) {
  if (err) {
    console.error('Could not connect: ' + err.message);
  } else {
    console.log('Client connected');
  }
});
