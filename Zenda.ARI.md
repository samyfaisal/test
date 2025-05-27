
please generate comprehensive documentation for the Zenda.ARI module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.ARI

## Overview

The Zenda.ARI module serves as the communication bridge between the Zenda VoIP Call Manager and Asterisk PBX systems. It implements the Asterisk REST Interface (ARI) protocol, enabling the application to control and monitor Asterisk resources through a WebSocket connection and REST API calls. This module abstracts the complexity of direct Asterisk communication, providing a clean, object-oriented interface for telephony operations such as call management, media playback, recording, and real-time event processing.

## Features

1. **WebSocket Connection Management**: Establishes and maintains persistent WebSocket connections to Asterisk for real-time event processing.

2. **REST API Integration**: Provides a comprehensive wrapper around Asterisk's REST API endpoints for controlling telephony resources.

3. **Event-Driven Architecture**: Implements an event-based system for handling Asterisk events like channel creation, hangups, DTMF input, and state changes.

4. **Resource Management**: Offers interfaces for managing Asterisk resources including channels, bridges, recordings, and playbacks.

5. **Stasis Application Support**: Integrates with Asterisk's Stasis application framework to intercept and control calls.

6. **Asynchronous Operation**: Leverages async/await patterns for non-blocking communication with Asterisk.

7. **Error Handling**: Provides specialized exception types and error management for ARI-related issues.

## Dependencies

- **System.Net.WebSockets**: For WebSocket communication with Asterisk
- **System.Net.Http**: For REST API calls to Asterisk
- **System.Text.Json**: For JSON serialization/deserialization
- **Zenda.Loging**: For diagnostic logging
- **Zenda.Engine**: Consumes ARI services for call processing

## Data Flow

1. **Outgoing Control Flow**:
   - Application code calls methods on AriClient
   - AriClient translates these calls to REST API requests
   - Requests are sent to Asterisk
   - Responses are parsed and returned to the calling code

2. **Incoming Event Flow**:
   - Events from Asterisk arrive via WebSocket
   - Events are deserialized into strongly-typed objects
   - Events are dispatched to registered event handlers
   - Application code processes events through these handlers

## Configuration

The ARI connection is configured through the `StasisEndpoint` class, which requires:

- **Host**: Asterisk server hostname or IP address
- **Port**: Port number for ARI (typically 8088)
- **Username**: Authentication username
- **Password**: Authentication password
- **SSL**: Boolean flag indicating whether to use secure WebSocket connection

Additional configuration options include:

- **Application Name**: The Stasis application name registered in Asterisk
- **Reconnection Settings**: Timeout and retry parameters
- **Event Filtering**: Options to filter specific event types

## Core Classes and Functions

### StasisEndpoint

#### Overview
Represents the connection parameters for an Asterisk ARI endpoint.

#### Constructor
```csharp
public StasisEndpoint(string host, int port, string username, string password, bool ssl = false)
```
- **host**: Hostname or IP address of the Asterisk server
- **port**: Port number for the ARI service
- **username**: Authentication username
- **password**: Authentication password
- **ssl**: Whether to use SSL/TLS for the connection

#### Properties
- **Host**: Gets or sets the hostname
- **Port**: Gets or sets the port number
- **Username**: Gets or sets the username
- **Password**: Gets or sets the password
- **Ssl**: Gets or sets whether SSL is enabled
- **AriEndPoint**: Gets the formatted endpoint URL

#### Example
```csharp
var endpoint = new StasisEndpoint("192.168.1.100", 8088, "admin", "password", false);
string url = endpoint.AriEndPoint; // "http://192.168.1.100:8088/ari"
```

### AriClient

#### Overview
The main client class for interacting with Asterisk ARI. Implements both `IAriActionClient` and `IAriEventClient` interfaces.

#### Constructor
```csharp
public AriClient(StasisEndpoint endpoint, string applicationName)
```
- **endpoint**: The StasisEndpoint configuration
- **applicationName**: The Stasis application name registered in Asterisk

#### Key Methods

##### Connect
```csharp
public async Task<bool> Connect()
```
- **Returns**: True if connection was successful, otherwise false
- **Description**: Establishes a WebSocket connection to the Asterisk server and starts listening for events

##### Disconnect
```csharp
public void Disconnect()
```
- **Description**: Closes the WebSocket connection and stops event processing

##### SubscribeEvent
```csharp
public void SubscribeEvent<T>(EventHandler<T> handler) where T : Event
```
- **handler**: Event handler delegate to be called when events of type T occur
- **Description**: Registers an event handler for a specific event type

##### UnsubscribeEvent
```csharp
public void UnsubscribeEvent<T>(EventHandler<T> handler) where T : Event
```
- **handler**: Event handler to unregister
- **Description**: Removes an event handler for a specific event type

##### Example
```csharp
var client = new AriClient(endpoint, "zenda");
await client.Connect();

// Subscribe to channel creation events
client.SubscribeEvent<ChannelCreatedEvent>((sender, e) => {
    Console.WriteLine($"New channel created: {e.Channel.Id}");
});

// Later, when done
client.Disconnect();
```

### Channel Operations

#### GetChannels
```csharp
public async Task<List<Channel>> GetChannels()
```
- **Returns**: List of active channels
- **Description**: Retrieves all active channels from Asterisk

#### GetChannel
```csharp
public async Task<Channel> GetChannel(string channelId)
```
- **channelId**: ID of the channel to retrieve
- **Returns**: Channel object if found
- **Description**: Retrieves a specific channel by ID

#### OriginateChannel
```csharp
public async Task<Channel> OriginateChannel(string endpoint, string app, string appArgs = null, string callerId = null, int timeout = 30)
```
- **endpoint**: SIP endpoint to call (e.g., "SIP/1001")
- **app**: Stasis application name
- **appArgs**: Optional application arguments
- **callerId**: Optional caller ID to use
- **timeout**: Timeout in seconds
- **Returns**: The created channel object
- **Description**: Creates a new outbound call to the specified endpoint

#### Example
```csharp
// Make an outbound call
var channel = await client.OriginateChannel("SIP/1001", "zenda", "call_id_123", "Customer Service <2000>");

// Get all active channels
var channels = await client.GetChannels();
foreach (var ch in channels) {
    Console.WriteLine($"Channel: {ch.Id}, State: {ch.State}");
}
```

### Bridge Operations

#### CreateBridge
```csharp
public async Task<Bridge> CreateBridge(string type = "mixing", string name = null)
```
- **type**: Bridge type (typically "mixing")
- **name**: Optional name for the bridge
- **Returns**: The created bridge object
- **Description**: Creates a new bridge for connecting multiple channels

#### AddChannelToBridge
```csharp
public async Task AddChannelToBridge(string bridgeId, string channelId)
```
- **bridgeId**: ID of the bridge
- **channelId**: ID of the channel to add
- **Description**: Adds a channel to a bridge

#### RemoveChannelFromBridge
```csharp
public async Task RemoveChannelFromBridge(string bridgeId, string channelId)
```
- **bridgeId**: ID of the bridge
- **channelId**: ID of the channel to remove
- **Description**: Removes a channel from a bridge

#### Example
```csharp
// Create a mixing bridge
var bridge = await client.CreateBridge("mixing", "conference_123");

// Add two channels to the bridge
await client.AddChannelToBridge(bridge.Id, channel1.Id);
await client.AddChannelToBridge(bridge.Id, channel2.Id);

// Later, remove a channel
await client.RemoveChannelFromBridge(bridge.Id, channel1.Id);
```

### Media Operations

#### PlaySound
```csharp
public async Task<Playback> PlaySound(string channelId, string soundFile, string lang = null)
```
- **channelId**: ID of the channel to play sound on
- **soundFile**: Path to the sound file
- **lang**: Optional language code
- **Returns**: Playback object representing the operation
- **Description**: Plays a sound file on a channel

#### StartRecording
```csharp
public async Task<LiveRecording> StartRecording(string channelId, string name, string format = "wav")
```
- **channelId**: ID of the channel to record
- **name**: Name for the recording file
- **format**: Recording format (default: wav)
- **Returns**: LiveRecording object representing the operation
- **Description**: Starts recording a channel

#### StopRecording
```csharp
public async Task StopRecording(string recordingName)
```
- **recordingName**: Name of the recording to stop
- **Description**: Stops an active recording

#### Example
```csharp
// Play a greeting to the caller
var playback = await client.PlaySound(channel.Id, "hello-world");

// Start recording the call
var recording = await client.StartRecording(channel.Id, $"call_{DateTime.Now:yyyyMMdd_HHmmss}");

// Later, stop the recording
await client.StopRecording(recording.Name);
```

### DTMF and Input Operations

#### SendDTMF
```csharp
public async Task SendDTMF(string channelId, string dtmf, int between = 100, int duration = 100)
```
- **channelId**: ID of the channel
- **dtmf**: DTMF digits to send
- **between**: Time between digits in ms
- **duration**: Duration of each digit in ms
- **Description**: Sends DTMF tones on a channel

#### Example
```csharp
// Send DTMF digits to navigate an IVR
await client.SendDTMF(channel.Id, "123#");
```

## Exception Handling

### AriException

#### Overview
Specialized exception for ARI-related errors.

#### Properties
- **StatusCode**: HTTP status code if applicable
- **Message**: Error message

#### Example
```csharp
try {
    await client.GetChannel("non_existent_channel");
} catch (AriException ex) {
    Console.WriteLine($"ARI Error: {ex.Message}, Status: {ex.StatusCode}");
}
```

## Event Handling

### Event Types
The module provides strongly-typed event classes for all Asterisk events, including:

- **ChannelCreatedEvent**: Fired when a new channel is created
- **ChannelDestroyedEvent**: Fired when a channel is destroyed
- **ChannelStateChangeEvent**: Fired when a channel's state changes
- **ChannelDtmfReceivedEvent**: Fired when DTMF is received on a channel
- **BridgeCreatedEvent**: Fired when a bridge is created
- **BridgeDestroyedEvent**: Fired when a bridge is destroyed
- **PlaybackStartedEvent**: Fired when media playback starts
- **PlaybackFinishedEvent**: Fired when media playback finishes
- **RecordingStartedEvent**: Fired when recording starts
- **RecordingFinishedEvent**: Fired when recording finishes

### Example Event Handling
```csharp
// Subscribe to DTMF events
client.SubscribeEvent<ChannelDtmfReceivedEvent>((sender, e) => {
    Console.WriteLine($"DTMF {e.Digit} received on channel {e.Channel.Id}");
    
    // Process IVR input
    if (e.Digit == "1") {
        // Transfer to sales
    } else if (e.Digit == "2") {
        // Transfer to support
    }
});

// Subscribe to channel state changes
client.SubscribeEvent<ChannelStateChangeEvent>((sender, e) => {
    Console.WriteLine($"Channel {e.Channel.Id} changed state to {e.Channel.State}");
    
    if (e.Channel.State == "Up") {
        // Call was answered
    } else if (e.Channel.State == "Ringing") {
        // Call is ringing
    }
});
```

## Usage Scenarios

### Scenario 1: Inbound Call Handling

```csharp
// Set up the ARI client
var endpoint = new StasisEndpoint("127.0.0.1", 8088, "admin", "password");
var ariClient = new AriClient(endpoint, "zenda");
await ariClient.Connect();

// Subscribe to new channel events
ariClient.SubscribeEvent<ChannelCreatedEvent>(async (sender, e) => {
    // Answer the call
    await ariClient.AnswerChannel(e.Channel.Id);
    
    // Play a greeting
    await ariClient.PlaySound(e.Channel.Id, "welcome");
    
    // Create a bridge for potential transfer
    var bridge = await ariClient.CreateBridge("mixing", $"call_{e.Channel.Id}");
    
    // Add the channel to the bridge
    await ariClient.AddChannelToBridge(bridge.Id, e.Channel.Id);
    
    // Start recording
    await ariClient.StartRecording(e.Channel.Id, $"call_{DateTime.Now:yyyyMMdd}_{e.Channel.Id}");
});

// Subscribe to DTMF for menu navigation
ariClient.SubscribeEvent<ChannelDtmfReceivedEvent>(async (sender, e) => {
    switch (e.Digit) {
        case "1":
            // Transfer to sales
            var salesChannel = await ariClient.OriginateChannel("SIP/sales", "zenda");
            await ariClient.AddChannelToBridge(e.Channel.BridgeId, salesChannel.Id);
            break;
        case "2":
            // Transfer to support
            var supportChannel = await ariClient.OriginateChannel("SIP/support", "zenda");
            await ariClient.AddChannelToBridge(e.Channel.BridgeId, supportChannel.Id);
            break;
    }
});
```

### Scenario 2: Outbound Campaign Call

```csharp
async Task MakeOutboundCall(string destination, string customerId) {
    try {
        // Create outbound channel
        var channel = await ariClient.OriginateChannel($"SIP/{destination}", "zenda", customerId);
        
        // Subscribe to state changes for this specific channel
        EventHandler<ChannelStateChangeEvent> stateHandler = null;
        stateHandler = async (sender, e) => {
            if (e.Channel.Id == channel.Id) {
                if (e.Channel.State == "Up") {
                    // Call answered
                    await ariClient.PlaySound(channel.Id, "greeting");
                    
                    // Start recording
                    await ariClient.StartRecording(channel.Id, $"outbound_{customerId}_{DateTime.Now:yyyyMMdd}");
                    
                    // Transfer to agent
                    var agentChannel = await ariClient.OriginateChannel("SIP/agent", "zenda");
                    var bridge = await ariClient.CreateBridge("mixing");
                    await ariClient.AddChannelToBridge(bridge.Id, channel.Id);
                    await ariClient.AddChannelToBridge(bridge.Id, agentChannel.Id);
                    
                    // Unsubscribe from state events
                    ariClient.UnsubscribeEvent(stateHandler);
                } else if (e.Channel.State == "Busy" || e.Channel.State == "NoAnswer") {
                    // Call failed
                    LogFailedCall(customerId, e.Channel.State);
                    ariClient.UnsubscribeEvent(stateHandler);
                }
            }
        };
        
        ariClient.SubscribeEvent(stateHandler);
    } catch (AriException ex) {
        Console.WriteLine($"Failed to make outbound call: {ex.Message}");
    }
}
```

## Best Practices

1. **Connection Management**:
   - Always handle connection failures gracefully
   - Implement automatic reconnection logic
   - Close connections properly when done

2. **Event Handling**:
   - Keep event handlers lightweight
   - Use async methods for event processing
   - Unsubscribe from events when no longer needed

3. **Error Handling**:
   - Catch and handle AriExceptions appropriately
   - Log errors for troubleshooting
   - Implement retry logic for transient failures

4. **Resource Management**:
   - Clean up bridges when no longer needed
   - Stop recordings explicitly
   - Handle channel lifecycle properly

5. **Performance Considerations**:
   - Minimize the number of API calls
   - Use batch operations when available
   - Implement proper throttling for high-volume scenarios

## Conclusion

The Zenda.ARI module provides a robust, object-oriented interface to Asterisk's REST Interface, enabling the Zenda VoIP Call Manager to control telephony resources effectively. By abstracting the complexities of direct Asterisk communication, it allows developers to focus on implementing business logic rather than dealing with low-level telephony protocols. The event-driven architecture makes it suitable for real-time applications like call centers, IVR systems, and unified communications platforms.

```csharp
public StasisEndpoint(string host, int port, string username, string password, bool ssl = false)
```

```csharp
var endpoint = new StasisEndpoint("192.168.1.100", 8088, "admin", "password", false);
string url = endpoint.AriEndPoint; // "http://192.168.1.100:8088/ari"
```

```csharp
public AriClient(StasisEndpoint endpoint, string applicationName)
```

```csharp
public async Task<bool> Connect()
```

```csharp
public void Disconnect()
```

```csharp
public void SubscribeEvent<T>(EventHandler<T> handler) where T : Event
```

```csharp
public void UnsubscribeEvent<T>(EventHandler<T> handler) where T : Event
```

```csharp
var client = new AriClient(endpoint, "zenda");
await client.Connect();

// Subscribe to channel creation events
client.SubscribeEvent<ChannelCreatedEvent>((sender, e) => {
    Console.WriteLine($"New channel created: {e.Channel.Id}");
});

// Later, when done
client.Disconnect();
```

```csharp
public async Task<List<Channel>> GetChannels()
```

```csharp
public async Task<Channel> GetChannel(string channelId)
```

```csharp
public async Task<Channel> OriginateChannel(string endpoint, string app, string appArgs = null, string callerId = null, int timeout = 30)
```

```csharp
// Make an outbound call
var channel = await client.OriginateChannel("SIP/1001", "zenda", "call_id_123", "Customer Service <2000>");

// Get all active channels
var channels = await client.GetChannels();
foreach (var ch in channels) {
    Console.WriteLine($"Channel: {ch.Id}, State: {ch.State}");
}
```

```csharp
public async Task<Bridge> CreateBridge(string type = "mixing", string name = null)
```

```csharp
public async Task AddChannelToBridge(string bridgeId, string channelId)
```

```csharp
public async Task RemoveChannelFromBridge(string bridgeId, string channelId)
```

```csharp
// Create a mixing bridge
var bridge = await client.CreateBridge("mixing", "conference_123");

// Add two channels to the bridge
await client.AddChannelToBridge(bridge.Id, channel1.Id);
await client.AddChannelToBridge(bridge.Id, channel2.Id);

// Later, remove a channel
await client.RemoveChannelFromBridge(bridge.Id, channel1.Id);
```

```csharp
public async Task<Playback> PlaySound(string channelId, string soundFile, string lang = null)
```

```csharp
public async Task<LiveRecording> StartRecording(string channelId, string name, string format = "wav")
```

```csharp
public async Task StopRecording(string recordingName)
```

```csharp
// Play a greeting to the caller
var playback = await client.PlaySound(channel.Id, "hello-world");

// Start recording the call
var recording = await client.StartRecording(channel.Id, $"call_{DateTime.Now:yyyyMMdd_HHmmss}");

// Later, stop the recording
await client.StopRecording(recording.Name);
```

```csharp
public async Task SendDTMF(string channelId, string dtmf, int between = 100, int duration = 100)
```

```csharp
// Send DTMF digits to navigate an IVR
await client.SendDTMF(channel.Id, "123#");
```

```csharp
try {
    await client.GetChannel("non_existent_channel");
} catch (AriException ex) {
    Console.WriteLine($"ARI Error: {ex.Message}, Status: {ex.StatusCode}");
}
```

```csharp
// Subscribe to DTMF events
client.SubscribeEvent<ChannelDtmfReceivedEvent>((sender, e) => {
    Console.WriteLine($"DTMF {e.Digit} received on channel {e.Channel.Id}");
    
    // Process IVR input
    if (e.Digit == "1") {
        // Transfer to sales
    } else if (e.Digit == "2") {
        // Transfer to support
    }
});

// Subscribe to channel state changes
client.SubscribeEvent<ChannelStateChangeEvent>((sender, e) => {
    Console.WriteLine($"Channel {e.Channel.Id} changed state to {e.Channel.State}");
    
    if (e.Channel.State == "Up") {
        // Call was answered
    } else if (e.Channel.State == "Ringing") {
        // Call is ringing
    }
});
```

```csharp
// Set up the ARI client
var endpoint = new StasisEndpoint("127.0.0.1", 8088, "admin", "password");
var ariClient = new AriClient(endpoint, "zenda");
await ariClient.Connect();

// Subscribe to new channel events
ariClient.SubscribeEvent<ChannelCreatedEvent>(async (sender, e) => {
    // Answer the call
    await ariClient.AnswerChannel(e.Channel.Id);
    
    // Play a greeting
    await ariClient.PlaySound(e.Channel.Id, "welcome");
    
    // Create a bridge for potential transfer
    var bridge = await ariClient.CreateBridge("mixing", $"call_{e.Channel.Id}");
    
    // Add the channel to the bridge
    await ariClient.AddChannelToBridge(bridge.Id, e.Channel.Id);
    
    // Start recording
    await ariClient.StartRecording(e.Channel.Id, $"call_{DateTime.Now:yyyyMMdd}_{e.Channel.Id}");
});

// Subscribe to DTMF for menu navigation
ariClient.SubscribeEvent<ChannelDtmfReceivedEvent>(async (sender, e) => {
    switch (e.Digit) {
        case "1":
            // Transfer to sales
            var salesChannel = await ariClient.OriginateChannel("SIP/sales", "zenda");
            await ariClient.AddChannelToBridge(e.Channel.BridgeId, salesChannel.Id);
            break;
        case "2":
            // Transfer to support
            var supportChannel = await ariClient.OriginateChannel("SIP/support", "zenda");
            await ariClient.AddChannelToBridge(e.Channel.BridgeId, supportChannel.Id);
            break;
    }
});
```

```csharp
async Task MakeOutboundCall(string destination, string customerId) {
    try {
        // Create outbound channel
        var channel = await ariClient.OriginateChannel($"SIP/{destination}", "zenda", customerId);
        
        // Subscribe to state changes for this specific channel
        EventHandler<ChannelStateChangeEvent> stateHandler = null;
        stateHandler = async (sender, e) => {
            if (e.Channel.Id == channel.Id) {
                if (e.Channel.State == "Up") {
                    // Call answered
                    await ariClient.PlaySound(channel.Id, "greeting");
                    
                    // Start recording
                    await ariClient.StartRecording(channel.Id, $"outbound_{customerId}_{DateTime.Now:yyyyMMdd}");
                    
                    // Transfer to agent
                    var agentChannel = await ariClient.OriginateChannel("SIP/agent", "zenda");
                    var bridge = await ariClient.CreateBridge("mixing");
                    await ariClient.AddChannelToBridge(bridge.Id, channel.Id);
                    await ariClient.AddChannelToBridge(bridge.Id, agentChannel.Id);
                    
                    // Unsubscribe from state events
                    ariClient.UnsubscribeEvent(stateHandler);
                } else if (e.Channel.State == "Busy" || e.Channel.State == "NoAnswer") {
                    // Call failed
                    LogFailedCall(customerId, e.Channel.State);
                    ariClient.UnsubscribeEvent(stateHandler);
                }
            }
        };
        
        ariClient.SubscribeEvent(stateHandler);
    } catch (AriException ex) {
        Console.WriteLine($"Failed to make outbound call: {ex.Message}");
    }
}
```

---
