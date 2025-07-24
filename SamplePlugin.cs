using System;
using System.Collections.Generic;
using SimSDK.Interfaces;
using SimSDK.Models;

namespace SamplePlugin
{
    public class SamplePlugin : IPlugin
    {
        public Manifest GetManifest()
        {
            return new Manifest
            {
                Name = "sample-plugin",
                Version = "v0.0.1",
                MessageTypes = new List<MessageType>
                {
                    new MessageType
                    {
                        Id = "sample.echo",
                        DisplayName = "Sample Echo",
                        Description = "Echoes back the input payload",
                        Fields = new List<FieldSpec>
                        {
                            new FieldSpec
                            {
                                Name = "message",
                                Type = FieldType.STRING,
                                Required = true,
                                Description = "The message to echo"
                            }
                        }
                    }
                },
                ControlFunctions = new List<ControlFunctionType>(), // none
                ComponentTypes = new List<ComponentType>
                {
                    new ComponentType
                    {
                        Id = "sample.component",
                        DisplayName = "Sample Component",
                        Description = "A dummy component",
                        Internal = false,
                        SupportsMultipleInstances = true
                    }
                },
                TransportTypes = new List<TransportType>() // none
            };
        }

        public void CreateComponentInstance(CreateComponentRequest request)
        {
            Console.WriteLine($"[SamplePlugin] Created component: {request.ComponentId} of type {request.ComponentType}");
        }

        public void DestroyComponentInstance(string componentId)
        {
            Console.WriteLine($"[SamplePlugin] Destroyed component: {componentId}");
        }

        public List<SimMessage> HandleMessage(SimMessage message)
        {
            Console.WriteLine($"[SamplePlugin] Received message: {message.MessageId} for component: {message.ComponentId}");

            return new List<SimMessage>
            {
                new SimMessage
                {
                    MessageType = "sample.echo.response",
                    MessageId = Guid.NewGuid().ToString(),
                    ComponentId = message.ComponentId,
                    Payload = message.Payload,
                    Metadata = new Dictionary<string, string> { { "sourceMessageId", message.MessageId } }
                }
            };
        }
    }
}