# License Validation Function and Algorithm
_Exported on 5/27/2025 at 16:36:46 GMT+3 from Cursor (0.50.5)_

---

**User**

please explain the function and license validation algorithm.

---

**Cursor**

I'll need to search for information about the license validation algorithm in the codebase to explain its function.

Let me get more information about the license validation by looking at the Helper class, which seems to contain important cryptographic functions.

Now, let me check the LicConfig class to understand how license configuration is managed:

Let me get the remaining part of the License class to understand its validation methods:

Based on the code I've reviewed, I can provide an explanation of the license validation function and algorithm used in the Zenda application:

## License Validation System

The Zenda licensing system consists of several key components working together to verify and enforce software licensing:

### 1. License Structure

The license contains several critical pieces of information:
- Registration ID (`RegId`) - A unique identifier for the customer
- Serial number - Hardware-based identifier tied to the system
- Customer name
- License type (Basic, Bronze, Silver, Golden, Diamond, Trial)
- Various expiration dates:
  - Key expiration date
  - License renewal date
  - Trial expiration date

### 2. Hardware Identification

The system uses hardware-specific information to bind the license to a specific machine:
- For Linux systems, it primarily uses disk serial numbers via `GetDiskSerial()`
- It has fallback mechanisms for virtual machines using `AssureSoftSerial()`
- The serial is a critical component used in license validation

### 3. Encryption Algorithm

The licensing system uses double-layered AES encryption:
- `DoubleEncrypt` and `DoubleDecrypt` methods provide two layers of encryption
- The first layer encrypts with the registration ID and serial number
- The second layer uses a random key that's stored in the first encrypted result
- This makes it extremely difficult to forge a license without the proper keys

### 4. License Validation Steps

When validating a license, the system performs these checks:

1. **Decryption**: The encrypted license string is decrypted using the registration ID and serial number as keys.

2. **Content Format Verification**: Checks that the decrypted content has the required components (7 fields separated by #).

3. **Serial Validation**: Verifies that the serial in the license matches the hardware's actual serial.

4. **Registration ID Validation**: Confirms that the registration ID in the license matches the one stored in configuration.

5. **Anti-Tampering Check**: The `CheckHacking` method prevents system clock manipulation by ensuring the current date is after the license's creation date.

6. **Expiration Verification**: The `CheckKeyExpiration` method verifies if the license is still valid based on its expiration date.

7. **License Type Assignment**: If the license has expired, it defaults to the Basic license type; otherwise, it uses the license type specified in the license.

### 5. License Renewal Process

The system includes a mechanism to refresh licenses:
- The `RefreshLicense` method in `LicManager` contacts a remote server
- It sends the registration ID and hardware serial
- The server validates and returns a new encrypted license string
- This is stored locally in the "zenda.lic" file

### Security Features

Several security measures prevent tampering:
- Hardware binding through serial numbers
- Double-layer encryption
- Anti-clock manipulation checks
- Remote validation for license refreshes
- Error messages that don't reveal the encryption details

This licensing system provides a robust way to validate licenses while protecting against common circumvention methods like clock manipulation, hardware changes, or direct license file tampering.

---

**User**

what is the function and main freatures of this Zenda Service?
please generate a comprehensive document about the system bendfits that can be used by sales team.

---

**Cursor**

I'll need to search for information about the Zenda Service to create a comprehensive sales document.

Let me check the Zenda Engine component to better understand what features the service is providing:

Let me check the main implementation file for MyEngine to understand its features better:

Let me check the ARI component, which appears to be a key part of Zenda's functionality:

Let me look for information about telephony and call center functionality:

Let me also look for information about CRM integration and customer management:

Based on my analysis of the codebase, I'll now create a comprehensive sales document about the Zenda Service and its features.

# Zenda Contact Center Solution: Comprehensive Sales Document

## Executive Summary

Zenda is a sophisticated, feature-rich contact center solution designed to streamline communication, enhance customer experience, and improve operational efficiency. Built with modern technology and a robust architecture, Zenda provides a complete suite of tools for managing customer interactions across multiple channels with advanced telephony integration, CRM capabilities, and intelligent workflow management.

## Core Components & Features

### 1. Advanced Telephony System

**Key Features:**
- **Intelligent Call Routing**: Automatically directs calls to the most appropriate agent based on skills, availability, and priority.
- **Multi-Channel Support**: Handles voice, SMS, and digital channels in a unified interface.
- **Interactive Voice Response (IVR)**: Customizable IVR flows to efficiently direct callers and gather information.
- **Queue Management**: Sophisticated waiting queue system with real-time monitoring and callback options.
- **Call Recording**: Selective or complete call recording for quality assurance and training.
- **Advanced Call Control**: Features include hold/retrieve, blind and attended transfers, conferencing, and call parking.

**Business Benefits:**
- Reduced call abandonment rates
- Improved first-call resolution rates
- Enhanced customer experience through personalized routing
- Better resource allocation through intelligent call distribution

### 2. Agent Workspace

**Key Features:**
- **Unified Agent Desktop**: Single interface for handling all customer interactions.
- **Real-Time Status Dashboard**: Shows call metrics, queue status, and agent availability.
- **Call Control Interface**: Intuitive controls for managing active calls.
- **After-Call Work (ACW)**: Dedicated time for agents to complete post-call tasks.
- **Not Ready Reason Codes**: Structured tracking of agent availability states.
- **Call Classification**: Categorize calls for better reporting and analytics.

**Business Benefits:**
- Increased agent productivity
- Improved call handling metrics
- Better workforce management
- Enhanced agent satisfaction through intuitive tools

### 3. Seamless CRM Integration

**Key Features:**
- **Customer Identification**: Automatic lookup of customer information based on caller ID.
- **Unified Customer View**: Access to complete customer history during calls.
- **Screen Pop Integration**: Automatically displays relevant customer information.
- **Custom CRM Adapters**: Flexible integration with third-party CRM systems.
- **Click-to-Dial**: Initiate calls directly from customer records.
- **Automatic Call Logging**: Call details automatically recorded in customer history.

**Business Benefits:**
- Personalized customer interactions
- Reduced handling time
- Improved data consistency
- Enhanced customer satisfaction through personalized service

### 4. Advanced Dialing Capabilities

**Key Features:**
- **Predictive Dialing**: Intelligent algorithm that optimizes outbound calls.
- **Progressive Dialing**: Automatically dials the next number when an agent becomes available.
- **Preview Dialing**: Allows agents to review customer information before the call is initiated.
- **Dialing List Management**: Create, manage and schedule outbound campaigns.
- **Call Blending**: Dynamically switches agents between inbound and outbound calls.

**Business Benefits:**
- Dramatically increased agent productivity
- Higher contact rates
- Better campaign management
- Optimized workforce utilization

### 5. Comprehensive Reporting & Analytics

**Key Features:**
- **Real-Time Dashboards**: Live metrics on call volume, queue status, and agent performance.
- **Historical Reporting**: Detailed analysis of past performance and trends.
- **Custom Report Builder**: Create tailored reports for specific business needs.
- **Call Recording Analysis**: Evaluate agent performance and identify training opportunities.
- **KPI Tracking**: Monitor key performance indicators against business objectives.

**Business Benefits:**
- Data-driven decision making
- Improved operational efficiency
- Better resource planning
- Enhanced quality management

### 6. System Management & Administration

**Key Features:**
- **Role-Based Access Control**: Granular permission settings for different user roles.
- **Centralized Configuration**: Manage all system settings from a single interface.
- **Scalable Architecture**: Easily add capacity as your business grows.
- **High Availability**: Redundant components ensure continuous operation.
- **Secure Communication**: Encrypted communication for all sensitive data.
- **License Management**: Flexible licensing model to accommodate business needs.

**Business Benefits:**
- Reduced administrative overhead
- Enhanced system security
- Simplified management
- Future-proof scalability

## Technical Advantages

- **Modern Architecture**: Built on .NET 8.0 with a service-oriented approach
- **Integration Capabilities**: Open APIs for seamless integration with existing systems
- **Scalability**: Handles from small teams to enterprise-level contact centers
- **Deployment Flexibility**: Available as on-premises or cloud-hosted solution
- **Asterisk Integration**: Leverages the powerful Asterisk PBX engine through ARI (Asterisk REST Interface)
- **Extensibility**: Modular design allows for custom extensions and features

## ROI & Business Impact

1. **Cost Reduction**:
   - Lower telecommunications costs through efficient call routing
   - Reduced staffing needs through improved agent productivity
   - Decreased technology costs through unified platform

2. **Revenue Enhancement**:
   - Increased conversion rates for sales campaigns
   - Improved customer retention through better service
   - Higher upsell/cross-sell opportunities with customer context

3. **Operational Efficiency**:
   - Streamlined workflows reduce handling times
   - Better resource allocation through workforce optimization
   - Reduced training time with intuitive interfaces

4. **Customer Experience**:
   - Personalized service delivery
   - Reduced wait times through intelligent routing
   - Consistent service across all interaction channels

## Implementation & Support

- **Professional Services**: Expert implementation and configuration
- **Training**: Comprehensive training for agents, supervisors, and administrators
- **Ongoing Support**: 24/7 technical support and regular updates
- **Customization**: Tailored solutions to meet specific business requirements
- **Consultancy**: Best practice advice for contact center optimization

## Why Choose Zenda?

Zenda stands out in the competitive contact center market due to its:

1. **Comprehensive Solution**: All-in-one platform eliminating the need for multiple disparate systems
2. **Flexibility**: Adapts to your business processes rather than forcing changes
3. **User-Centric Design**: Intuitive interfaces reduce training time and improve adoption
4. **Innovation**: Continuously evolving with new features and capabilities
5. **Cost Effectiveness**: Competitive pricing with clear ROI
6. **Enterprise-Grade Reliability**: Built for mission-critical communications

## Conclusion

Zenda Contact Center Solution offers a powerful, flexible platform for organizations looking to transform their customer interactions. By combining advanced telephony features with seamless CRM integration and comprehensive management tools, Zenda provides everything needed to run an efficient, effective contact center operation.

Our solution empowers businesses to deliver exceptional customer experiences while optimizing operational efficiency and reducing costs. Whether you're a small team or a large enterprise, Zenda scales to meet your needs and grows with your business.

Contact our sales team today to schedule a personalized demonstration and discover how Zenda can transform your contact center operations.

---

**User**

Please generate a comprehensive high-level overview of the VoIP Call Manager project. Detail the purpose and functionality of each module, and explain how these modules interact within the system. Structure the output in markdown format with appropriate headings and subheadings

---

**Cursor**

# VoIP Call Manager Project Overview

The Zenda system is a comprehensive VoIP Call Manager and Contact Center solution that integrates telephony services, CRM capabilities, and business workflow management. Built on modern .NET technology, it provides a scalable, feature-rich platform for managing customer interactions across multiple channels.

## Modules Description

### Zenda.Engine

- **Purpose**: Core processing engine that manages call flows, telephony events, and business logic.
- **Key Responsibilities**: 
  - Handling call lifecycle management
  - Managing bridges and connections between channels
  - Orchestrating workflows for different call scenarios
  - Coordinating waiting lists and dialing lists
  - Scheduling tasks and actions
- **Interactions**: Interfaces with Asterisk through ARI, communicates with database layer, and provides services to client applications.

### Zenda.ARI

- **Purpose**: Asterisk REST Interface adapter that provides communication with the underlying Asterisk PBX.
- **Key Responsibilities**: 
  - Managing WebSocket connections to Asterisk
  - Handling Stasis events and actions
  - Providing channel management capabilities
  - Processing media operations (playback, recording)
- **Interactions**: Connects directly to Asterisk and exposes telephony functionality to the Engine module.

### Zenda.DAL and Zenda.DAL.Common

- **Purpose**: Data Access Layer that provides database operations and entity management.
- **Key Responsibilities**: 
  - Entity mapping and persistence
  - Database query operations
  - Transaction management
  - Entity relationships
- **Interactions**: Used by all other modules that require data persistence or retrieval.

### Zenda.WebKit

- **Purpose**: Web-based user interfaces for administrators, agents, and system management.
- **Key Responsibilities**: 
  - Admin portal for system configuration
  - Agent workspace for call handling
  - Reporting and analytics dashboards
  - User management interfaces
- **Interactions**: Communicates with the Engine through API endpoints and receives real-time updates.

### Zenda.CrmIntegration

- **Purpose**: Integration layer for connecting with external CRM systems.
- **Key Responsibilities**: 
  - Customer data lookup and synchronization
  - Call event notifications to CRM systems
  - URL generation for customer records
  - Customer creation and update operations
- **Interactions**: Connects with external CRM systems and provides customer data to the Engine and WebKit.

### Zenda.Service

- **Purpose**: Windows/Linux service that hosts the Engine and provides system-level integration.
- **Key Responsibilities**: 
  - Service lifecycle management
  - System integration with OS
  - Process monitoring and recovery
- **Interactions**: Hosts the Engine module and integrates with operating system services.

### Zenda.LIC

- **Purpose**: License management and validation system.
- **Key Responsibilities**: 
  - License validation and enforcement
  - Feature access control based on license type
  - Hardware binding for license security
- **Interactions**: Used by the Engine to validate system operation and feature availability.

### Zenda.Softphone

- **Purpose**: Software-based phone client for agent use.
- **Key Responsibilities**: 
  - Audio input/output management
  - SIP protocol handling
  - Call control interface
  - Media processing
- **Interactions**: Connects to the system as an endpoint and communicates with the Engine.

### Zenda.Loging

- **Purpose**: Centralized logging system for diagnostics and troubleshooting.
- **Key Responsibilities**: 
  - Log collection and storage
  - Log level management
  - Structured logging format
- **Interactions**: Used by all modules to record operational events and errors.

### Zenda.Common

- **Purpose**: Shared utilities and common functionality.
- **Key Responsibilities**: 
  - Helper methods and extensions
  - Common data structures
  - Shared constants and configurations
- **Interactions**: Referenced by all other modules for common functionality.

## Module Interactions

The system follows a layered architecture with clear separation of concerns:

1. **Presentation Layer** (WebKit, Softphone): Provides user interfaces and interaction points.

2. **Service Layer** (Engine, Service): Implements business logic and orchestrates system operations.

3. **Integration Layer** (ARI, CrmIntegration): Connects with external systems and services.

4. **Data Layer** (DAL, DAL.Common): Manages data persistence and retrieval.

5. **Cross-Cutting Concerns** (LIC, Loging, Common): Provide functionality used across all layers.

Data flows through these layers as follows:

- User actions in the WebKit trigger API calls to the Engine
- The Engine processes these requests, interacting with ARI for telephony operations
- Customer data is retrieved or updated through CrmIntegration
- Persistent data is stored and retrieved via the DAL
- All operations are validated against license restrictions and logged appropriately

## Key Features

1. **Advanced Call Management**:
   - Intelligent call routing
   - Queue management
   - IVR workflows
   - Call recording and monitoring

2. **Agent Workspace**:
   - Real-time call control
   - Customer information display
   - Call classification
   - After-call work management

3. **CRM Integration**:
   - Customer identification
   - Screen pop functionality
   - Call history synchronization
   - Customer data lookup

4. **Outbound Dialing**:
   - Predictive dialing capabilities
   - Campaign management
   - Dialing list administration
   - Call blending

5. **Administration**:
   - System configuration
   - User and extension management
   - Queue and routing setup
   - Reporting and analytics

## Technical Architecture

The system is built on .NET 8.0 with a service-oriented architecture. It utilizes:

- Asterisk PBX for telephony functionality
- WebSocket connections for real-time communication
- NHibernate for ORM capabilities
- Blazor for web interfaces
- REST APIs for service communication

The modular design allows for scalability and flexibility, with components that can be deployed across multiple servers for larger installations.

## Conclusion

The Zenda VoIP Call Manager is a comprehensive solution that provides enterprise-grade contact center capabilities with flexible integration options. Its modular architecture allows for scalability while maintaining performance and reliability. The system is designed to support both traditional call center operations and modern omnichannel customer engagement strategies.

---

**User**

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

**User**

please generate comprehensive documentation for the Zenda.CLI module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.CLI

## Overview

The Zenda.CLI module provides a command-line interface for interacting with the Zenda VoIP Call Manager system. It serves as a utility tool for system administrators and developers to perform various administrative tasks, diagnostics, and maintenance operations without requiring access to the graphical user interface. This module implements a command parser, service framework, and logging capabilities to create an extensible command-line environment for managing the Zenda system.

## Features

1. **Command Parsing**: Parses and interprets user input as commands with flags and parameters.

2. **Service Framework**: Provides an abstract base class for implementing various service-specific command handlers.

3. **Interactive Shell**: Offers an interactive command prompt with command history and navigation.

4. **Colorized Output**: Enhances readability with color-coded console output for different message types.

5. **Logging**: Records command execution and results for auditing and troubleshooting.

6. **Extensible Architecture**: Allows for easy addition of new commands and service modules.

7. **Error Handling**: Provides robust error handling and reporting for command execution.

## Dependencies

- **.NET 8.0**: Core framework for the application
- **Zenda.Engine**: For core engine functionality
- **Zenda.DAL**: For database access operations
- **Zenda.GenBase**: For common utility functions
- **System.Console**: For terminal input/output operations

## Data Flow

1. **Input Processing**:
   - User enters commands in the console
   - Command parser breaks down input into command, flags, and parameters
   - Appropriate service handler is invoked

2. **Command Execution**:
   - Service handler processes the command
   - Service may interact with other Zenda modules (Engine, DAL, etc.)
   - Results are returned to the command processor

3. **Output Generation**:
   - Results are formatted according to command specifications
   - Output is colorized based on message type
   - Results are displayed to the user and optionally logged

## Configuration

The CLI module can be configured through:

- **Command-line arguments**: Passed when starting the application
- **Environment variables**: For system-wide configuration
- **Service-specific configuration**: Each service can have its own configuration options

## Core Classes and Functions

### Command

#### Overview
Represents a parsed command with its flags and parameters.

#### Constructor
```csharp
public Command(string commandLine)
```
- **commandLine**: The raw command line input string to parse
- **Description**: Parses the command line into command, flags, and parameters

#### Properties
- **Cmd**: Gets the main command string
- **Flags**: Gets the collection of parsed flags
- **HasFlags**: Indicates whether the command has any flags

#### Constants
- **EXIT**: Command string for exiting the current service
- **HELP**: Command string for displaying help information

#### Example
```csharp
var command = new Command("list users -v --filter=active");
string mainCommand = command.Cmd; // "list"
bool hasVerboseFlag = command.Flags.Has("v"); // true
string filter = command.Flags.Get("filter").Value; // "active"
```

### Flag

#### Overview
Represents a command-line flag with optional parameters.

#### Constructor
```csharp
public Flag(string name, string value = null)
```
- **name**: The name of the flag
- **value**: The optional value associated with the flag

#### Properties
- **Name**: Gets the flag name
- **Value**: Gets the flag value
- **HasValue**: Indicates whether the flag has a value
- **Params**: Gets a list of parameters associated with the flag

#### Methods

##### Add
```csharp
public void Add(string param)
```
- **param**: The parameter to add to the flag
- **Description**: Adds a parameter to the flag's parameter list

##### HasParam
```csharp
public bool HasParam(string param)
```
- **param**: The parameter to check
- **Returns**: True if the parameter exists in the flag's parameter list
- **Description**: Checks if a specific parameter exists

#### Example
```csharp
var flag = new Flag("output", "json");
flag.Add("pretty");
flag.Add("compact");

bool hasValue = flag.HasValue; // true
string value = flag.Value; // "json"
bool hasPretty = flag.HasParam("pretty"); // true
```

### FlagCollection

#### Overview
A collection of Flag objects with methods for accessing and manipulating them.

#### Methods

##### Add
```csharp
public void Add(Flag flag)
```
- **flag**: The flag to add to the collection
- **Description**: Adds a flag to the collection

##### Has
```csharp
public bool Has(string name)
```
- **name**: The name of the flag to check
- **Returns**: True if a flag with the given name exists
- **Description**: Checks if a flag with the specified name exists in the collection

##### Get
```csharp
public Flag Get(string name)
```
- **name**: The name of the flag to retrieve
- **Returns**: The Flag object if found, otherwise null
- **Description**: Retrieves a flag by name

#### Example
```csharp
var flags = new FlagCollection();
flags.Add(new Flag("verbose"));
flags.Add(new Flag("output", "file"));

bool hasVerbose = flags.Has("verbose"); // true
Flag outputFlag = flags.Get("output"); // returns the output flag
```

### Logger

#### Overview
Provides logging functionality with color-coded output.

#### Constructor
```csharp
public Logger(string file = null)
```
- **file**: Optional file path for logging output
- **Description**: Creates a new logger, optionally writing to the specified file

#### Methods

##### Add
```csharp
public void Add(string message = "", bool newLine = true)
```
- **message**: The message to log
- **newLine**: Whether to append a newline
- **Description**: Logs a message with default color

##### AddInfo
```csharp
public void AddInfo(string message, bool newLine = true)
```
- **message**: The message to log
- **newLine**: Whether to append a newline
- **Description**: Logs an informational message (typically in green)

##### AddError
```csharp
public void AddError(string message, bool newLine = true)
```
- **message**: The message to log
- **newLine**: Whether to append a newline
- **Description**: Logs an error message (typically in red)

##### AddWarning
```csharp
public void AddWarning(string message, bool newLine = true)
```
- **message**: The message to log
- **newLine**: Whether to append a newline
- **Description**: Logs a warning message (typically in yellow)

##### AddPrompt
```csharp
public void AddPrompt(string message, bool newLine = true)
```
- **message**: The message to log
- **newLine**: Whether to append a newline
- **Description**: Logs a prompt message (typically in cyan)

##### AddSplitter
```csharp
public void AddSplitter(char c = '-', int count = 80)
```
- **c**: The character to use for the splitter line
- **count**: The number of characters in the splitter line
- **Description**: Adds a horizontal line of characters for visual separation

#### Example
```csharp
var logger = new Logger("operations.log");
logger.AddInfo("Starting operation");
logger.AddWarning("Resource usage is high");
logger.AddError("Failed to connect to database");
logger.AddSplitter();
logger.AddPrompt("Enter command: ", false);
```

### Service

#### Overview
Abstract base class for implementing service-specific command handlers.

#### Properties
- **Logger**: Gets the logger instance for this service

#### Methods

##### Run
```csharp
public async Task Run()
```
- **Returns**: A task representing the asynchronous operation
- **Description**: Runs the service's command loop, processing user input until exit

##### Process
```csharp
public abstract Task Process(Command cmd)
```
- **cmd**: The command to process
- **Returns**: A task representing the asynchronous operation
- **Description**: Abstract method that must be implemented by derived classes to process commands

##### DisplayHelp
```csharp
protected abstract void DisplayHelp()
```
- **Description**: Abstract method that must be implemented by derived classes to display help information

##### HelpCommon
```csharp
protected void HelpCommon()
```
- **Description**: Displays help information for common commands (help, exit)

#### Example
```csharp
public class UserService : Service
{
    public override async Task Process(Command cmd)
    {
        switch (cmd.Cmd)
        {
            case "list":
                await ListUsers(cmd.Flags);
                break;
            case "add":
                await AddUser(cmd.Flags);
                break;
            case Command.HELP:
                DisplayHelp();
                break;
            default:
                Logger.AddError($"Unknown command: {cmd.Cmd}");
                break;
        }
    }

    protected override void DisplayHelp()
    {
        Logger.AddInfo("Available commands:");
        Logger.AddInfo("  list - List all users");
        Logger.AddInfo("  add -n <name> -p <password> - Add a new user");
        HelpCommon();
    }

    private async Task ListUsers(FlagCollection flags)
    {
        // Implementation for listing users
    }

    private async Task AddUser(FlagCollection flags)
    {
        // Implementation for adding users
    }
}
```

### Program

#### Overview
The main entry point for the CLI application that initializes and runs the appropriate services.

#### Methods

##### Main
```csharp
public static void Main(string[] args)
```
- **args**: Command-line arguments
- **Description**: Entry point for the application

##### RunService
```csharp
private static async Task RunService(Service service)
```
- **service**: The service to run
- **Returns**: A task representing the asynchronous operation
- **Description**: Runs the specified service and handles exceptions

#### Example
```csharp
// Program.cs
public static async Task Main(string[] args)
{
    try
    {
        Console.WriteLine("Zenda CLI v1.0");
        
        // Create and run the main service
        var mainService = new MainService();
        await RunService(mainService);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fatal error: {ex.Message}");
    }
}
```

## Service Implementations

The Zenda.CLI module typically includes several service implementations for different administrative tasks:

### UserManagementService

Handles user-related operations such as creating, updating, and deleting users.

#### Commands
- **list**: Lists all users in the system
- **add**: Adds a new user
- **update**: Updates an existing user
- **delete**: Deletes a user
- **reset-password**: Resets a user's password

### SystemService

Provides system-level operations and diagnostics.

#### Commands
- **status**: Shows the current system status
- **restart**: Restarts system services
- **config**: Displays or modifies system configuration
- **backup**: Creates a system backup
- **restore**: Restores from a backup

### DatabaseService

Manages database operations.

#### Commands
- **sync**: Synchronizes the database schema
- **backup**: Creates a database backup
- **restore**: Restores a database from backup
- **query**: Executes a database query

### TelephonyService

Manages telephony-related operations.

#### Commands
- **extensions**: Lists or modifies extensions
- **trunks**: Manages SIP trunks
- **routes**: Configures call routing
- **queues**: Manages call queues

## Usage Scenarios

### Scenario 1: User Management

```
$ zenda-cli
Zenda CLI v1.0
zenda: $ users
zenda: users $ list
ID  | Name      | Role      | Status
----+-----------+-----------+--------
1   | admin     | Admin     | Active
2   | operator  | Operator  | Active
3   | agent1    | Agent     | Inactive

zenda: users $ add -n newagent -p Password123 -r Agent
User 'newagent' created successfully with ID 4

zenda: users $ update 4 --status=Active
User 'newagent' updated successfully

zenda: users $ exit
zenda: $
```

### Scenario 2: System Diagnostics

```
$ zenda-cli
Zenda CLI v1.0
zenda: $ system
zenda: system $ status
System Status: Running
Version: 3.2.1
Uptime: 3 days, 7 hours
CPU Usage: 23%
Memory Usage: 1.2GB / 4GB
Active Calls: 12

zenda: system $ services
Service         | Status    | PID
---------------+----------+------
zenda-engine   | Running   | 1234
asterisk       | Running   | 1235
database       | Running   | 1236
web-server     | Running   | 1237

zenda: system $ logs -l error -n 5
[2023-05-10 14:23:15] ERROR: Failed to connect to trunk 'sip-provider-1'
[2023-05-10 15:45:22] ERROR: Database connection timeout
[2023-05-11 09:12:33] ERROR: License validation failed
[2023-05-11 10:30:45] ERROR: Failed to start recording for call ID 12345
[2023-05-12 08:15:10] ERROR: Memory allocation failed for media processing

zenda: system $ exit
zenda: $
```

### Scenario 3: Database Management

```
$ zenda-cli
Zenda CLI v1.0
zenda: $ database
zenda: database $ status
Database Status: Connected
Version: PostgreSQL 13.4
Size: 2.3GB
Tables: 87
Active Connections: 5

zenda: database $ backup -o /backups/zenda_db_20230512
Creating backup...
Backup completed successfully: /backups/zenda_db_20230512.sql

zenda: database $ sync
Checking database schema...
Found 2 pending migrations
Applying migration 20230510_AddCallRecordingPath...
Applying migration 20230511_UpdateUserRoles...
Database schema synchronized successfully

zenda: database $ exit
zenda: $
```

### Scenario 4: Telephony Configuration

```
$ zenda-cli
Zenda CLI v1.0
zenda: $ telephony
zenda: telephony $ extensions list
Ext   | Name      | Type      | Status
------+-----------+-----------+--------
100   | Reception | SIP       | Registered
101   | Sales     | SIP       | Registered
102   | Support   | SIP       | Not Registered
200   | Conference| Virtual   | N/A

zenda: telephony $ trunks list
ID | Name           | Provider      | Status
---+----------------+---------------+--------
1  | Main Provider  | SIP Provider  | Online
2  | Backup Line    | PSTN Gateway  | Offline

zenda: telephony $ routes add -n "Support Calls" -p "^support" -d 102
Route "Support Calls" added successfully

zenda: telephony $ queues stats
Queue     | Agents | Waiting | Avg Wait | Abandoned
----------+--------+---------+----------+----------
Sales     | 3/5    | 2       | 45s      | 12%
Support   | 2/4    | 5       | 120s     | 18%
General   | 1/2    | 0       | 30s      | 5%

zenda: telephony $ exit
zenda: $
```

## Best Practices

1. **Command Structure**:
   - Keep commands simple and intuitive
   - Use consistent naming conventions
   - Group related commands under appropriate services

2. **Error Handling**:
   - Provide clear error messages
   - Log errors for troubleshooting
   - Handle exceptions gracefully

3. **Performance**:
   - Minimize database queries
   - Use asynchronous operations for long-running tasks
   - Provide progress indicators for time-consuming operations

4. **Security**:
   - Validate input to prevent command injection
   - Implement proper authentication for sensitive operations
   - Limit access to critical system functions

5. **User Experience**:
   - Provide helpful feedback and prompts
   - Use color coding for different types of messages
   - Include comprehensive help information

## Conclusion

The Zenda.CLI module provides a powerful and flexible command-line interface for administering and managing the Zenda VoIP Call Manager system. Its extensible architecture allows for easy addition of new commands and services, making it adaptable to evolving system requirements. The module's focus on clear feedback, robust error handling, and comprehensive logging makes it an essential tool for system administrators and developers working with the Zenda platform.

The command-line interface complements the web-based administration interface, offering direct access to system functions for automation, scripting, and situations where a graphical interface is not available or practical. By providing a consistent and intuitive command structure across different service domains, the CLI module enables efficient management of all aspects of the Zenda system.

```csharp
public Command(string commandLine)
```

```csharp
var command = new Command("list users -v --filter=active");
string mainCommand = command.Cmd; // "list"
bool hasVerboseFlag = command.Flags.Has("v"); // true
string filter = command.Flags.Get("filter").Value; // "active"
```

```csharp
public Flag(string name, string value = null)
```

```csharp
public void Add(string param)
```

```csharp
public bool HasParam(string param)
```

```csharp
var flag = new Flag("output", "json");
flag.Add("pretty");
flag.Add("compact");

bool hasValue = flag.HasValue; // true
string value = flag.Value; // "json"
bool hasPretty = flag.HasParam("pretty"); // true
```

```csharp
public void Add(Flag flag)
```

```csharp
public bool Has(string name)
```

```csharp
public Flag Get(string name)
```

```csharp
var flags = new FlagCollection();
flags.Add(new Flag("verbose"));
flags.Add(new Flag("output", "file"));

bool hasVerbose = flags.Has("verbose"); // true
Flag outputFlag = flags.Get("output"); // returns the output flag
```

```csharp
public Logger(string file = null)
```

```csharp
public void Add(string message = "", bool newLine = true)
```

```csharp
public void AddInfo(string message, bool newLine = true)
```

```csharp
public void AddError(string message, bool newLine = true)
```

```csharp
public void AddWarning(string message, bool newLine = true)
```

```csharp
public void AddPrompt(string message, bool newLine = true)
```

```csharp
public void AddSplitter(char c = '-', int count = 80)
```

```csharp
var logger = new Logger("operations.log");
logger.AddInfo("Starting operation");
logger.AddWarning("Resource usage is high");
logger.AddError("Failed to connect to database");
logger.AddSplitter();
logger.AddPrompt("Enter command: ", false);
```

```csharp
public async Task Run()
```

```csharp
public abstract Task Process(Command cmd)
```

```csharp
protected abstract void DisplayHelp()
```

```csharp
protected void HelpCommon()
```

```csharp
public class UserService : Service
{
    public override async Task Process(Command cmd)
    {
        switch (cmd.Cmd)
        {
            case "list":
                await ListUsers(cmd.Flags);
                break;
            case "add":
                await AddUser(cmd.Flags);
                break;
            case Command.HELP:
                DisplayHelp();
                break;
            default:
                Logger.AddError($"Unknown command: {cmd.Cmd}");
                break;
        }
    }

    protected override void DisplayHelp()
    {
        Logger.AddInfo("Available commands:");
        Logger.AddInfo("  list - List all users");
        Logger.AddInfo("  add -n <name> -p <password> - Add a new user");
        HelpCommon();
    }

    private async Task ListUsers(FlagCollection flags)
    {
        // Implementation for listing users
    }

    private async Task AddUser(FlagCollection flags)
    {
        // Implementation for adding users
    }
}
```

```csharp
public static void Main(string[] args)
```

```csharp
private static async Task RunService(Service service)
```

```csharp
// Program.cs
public static async Task Main(string[] args)
{
    try
    {
        Console.WriteLine("Zenda CLI v1.0");
        
        // Create and run the main service
        var mainService = new MainService();
        await RunService(mainService);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fatal error: {ex.Message}");
    }
}
```

```plaintext
$ zenda-cli
Zenda CLI v1.0
zenda: $ users
zenda: users $ list
ID  | Name      | Role      | Status
----+-----------+-----------+--------
1   | admin     | Admin     | Active
2   | operator  | Operator  | Active
3   | agent1    | Agent     | Inactive

zenda: users $ add -n newagent -p Password123 -r Agent
User 'newagent' created successfully with ID 4

zenda: users $ update 4 --status=Active
User 'newagent' updated successfully

zenda: users $ exit
zenda: $
```

```plaintext
$ zenda-cli
Zenda CLI v1.0
zenda: $ system
zenda: system $ status
System Status: Running
Version: 3.2.1
Uptime: 3 days, 7 hours
CPU Usage: 23%
Memory Usage: 1.2GB / 4GB
Active Calls: 12

zenda: system $ services
Service         | Status    | PID
---------------+----------+------
zenda-engine   | Running   | 1234
asterisk       | Running   | 1235
database       | Running   | 1236
web-server     | Running   | 1237

zenda: system $ logs -l error -n 5
[2023-05-10 14:23:15] ERROR: Failed to connect to trunk 'sip-provider-1'
[2023-05-10 15:45:22] ERROR: Database connection timeout
[2023-05-11 09:12:33] ERROR: License validation failed
[2023-05-11 10:30:45] ERROR: Failed to start recording for call ID 12345
[2023-05-12 08:15:10] ERROR: Memory allocation failed for media processing

zenda: system $ exit
zenda: $
```

```plaintext
$ zenda-cli
Zenda CLI v1.0
zenda: $ database
zenda: database $ status
Database Status: Connected
Version: PostgreSQL 13.4
Size: 2.3GB
Tables: 87
Active Connections: 5

zenda: database $ backup -o /backups/zenda_db_20230512
Creating backup...
Backup completed successfully: /backups/zenda_db_20230512.sql

zenda: database $ sync
Checking database schema...
Found 2 pending migrations
Applying migration 20230510_AddCallRecordingPath...
Applying migration 20230511_UpdateUserRoles...
Database schema synchronized successfully

zenda: database $ exit
zenda: $
```

```plaintext
$ zenda-cli
Zenda CLI v1.0
zenda: $ telephony
zenda: telephony $ extensions list
Ext   | Name      | Type      | Status
------+-----------+-----------+--------
100   | Reception | SIP       | Registered
101   | Sales     | SIP       | Registered
102   | Support   | SIP       | Not Registered
200   | Conference| Virtual   | N/A

zenda: telephony $ trunks list
ID | Name           | Provider      | Status
---+----------------+---------------+--------
1  | Main Provider  | SIP Provider  | Online
2  | Backup Line    | PSTN Gateway  | Offline

zenda: telephony $ routes add -n "Support Calls" -p "^support" -d 102
Route "Support Calls" added successfully

zenda: telephony $ queues stats
Queue     | Agents | Waiting | Avg Wait | Abandoned
----------+--------+---------+----------+----------
Sales     | 3/5    | 2       | 45s      | 12%
Support   | 2/4    | 5       | 120s     | 18%
General   | 1/2    | 0       | 30s      | 5%

zenda: telephony $ exit
zenda: $
```

---

**User**

please generate comprehensive documentation for the Zenda.Common module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.Common

## Overview

The Zenda.Common module serves as a utility library for the Zenda VoIP Call Manager system, providing a collection of helper classes, utilities, and common functionality used across various components of the application. This module contains reusable code for file operations, security, configuration, shell interactions, backup functionality, audio processing, and more. By centralizing these common functions, the module promotes code reuse, consistency, and maintainability throughout the Zenda system.

## Features

1. **File and Directory Operations**: Utilities for working with files, directories, and file formats.

2. **TLS/SSL Management**: Tools for creating and managing TLS certificates for secure communications.

3. **Shell Command Execution**: Wrappers for executing shell commands across different operating systems.

4. **Configuration Management**: Classes for handling database and system configuration.

5. **Audio Processing**: Helpers for audio file conversion and manipulation.

6. **Backup and Restore**: Functionality for system backup and restoration.

7. **SMS Integration**: Components for sending and receiving SMS messages.

8. **HTTP Utilities**: Classes for HTTP request handling and web communication.

9. **ZeroTier Network Integration**: Tools for working with ZeroTier virtual networks.

10. **YAML Processing**: Utilities for reading and writing YAML configuration files.

## Dependencies

- **.NET 8.0**: Core framework for the application
- **YamlDotNet**: For YAML file processing
- **Newtonsoft.Json**: For JSON serialization/deserialization
- **System.Security.Cryptography**: For cryptographic operations
- **NAudio** (implied): For audio processing functions

## Data Flow

The Zenda.Common module primarily serves as a utility provider rather than implementing complex data flows. Typical usage patterns include:

1. **Utility Function Usage**:
   - Application code calls utility functions from Zenda.Common
   - Functions perform their operations (file manipulation, shell commands, etc.)
   - Results are returned to the calling code

2. **Configuration Management**:
   - Application loads configuration through DbConfig
   - Configuration is used throughout the application
   - Changes are persisted back to storage when needed

3. **Security Operations**:
   - TLS certificates are generated or loaded
   - Certificates are used for secure communications
   - Certificate status and information is provided to the application

## Core Classes and Functions

### Constants

#### Overview
Provides system-wide constant values used throughout the Zenda application.

#### Properties
- **TLSAPP**: Constant for TLS application name
- **Other system-wide constants**: Various constants used across the application

#### Example
```csharp
string tlsAppName = Constants.TLSAPP;
```

### FileExtensions

#### Overview
Extension methods for file operations.

#### Methods

##### GetFileSize
```csharp
public static long GetFileSize(this string filename)
```
- **filename**: Path to the file
- **Returns**: Size of the file in bytes
- **Description**: Gets the size of a file in bytes

#### Example
```csharp
string filePath = "/path/to/file.wav";
long fileSize = filePath.GetFileSize();
Console.WriteLine($"File size: {fileSize} bytes");
```

### TlsManager

#### Overview
Manages TLS certificates for secure communications.

#### Constructor
```csharp
public TlsManager(string appName, string certPath)
```
- **appName**: Name of the application
- **certPath**: Path to store certificates
- **Description**: Creates a new TLS manager instance

#### Properties
- **CreateCert**: Gets the certificate creation helper

#### Methods

##### GetCertificateInfo
```csharp
public CertificateInfo GetCertificateInfo(string name)
```
- **name**: Name of the certificate
- **Returns**: Information about the certificate
- **Description**: Gets information about a certificate

##### GetCertificatePath
```csharp
public string GetCertificatePath(string name)
```
- **name**: Name of the certificate
- **Returns**: Path to the certificate file
- **Description**: Gets the file path for a certificate

#### Example
```csharp
var tlsManager = new TlsManager("zenda", "/etc/zenda/certs");
var certInfo = tlsManager.GetCertificateInfo("server");

if (certInfo.IsValid && !certInfo.IsExpired)
{
    string certPath = tlsManager.GetCertificatePath("server");
    Console.WriteLine($"Using valid certificate at: {certPath}");
}
else
{
    // Create a new certificate
    tlsManager.CreateCert.Assure("server", "password");
}
```

### GuardHelper

#### Overview
Provides methods for system resource monitoring and protection.

#### Methods

##### GetDiskUsage
```csharp
public static DiskUsageInfo GetDiskUsage(string path)
```
- **path**: Path to check disk usage
- **Returns**: Disk usage information
- **Description**: Gets disk usage information for a specified path

##### CheckDiskSpace
```csharp
public static bool CheckDiskSpace(string path, long requiredMb)
```
- **path**: Path to check disk space
- **requiredMb**: Required space in megabytes
- **Returns**: True if enough space is available, otherwise false
- **Description**: Checks if enough disk space is available

#### Example
```csharp
string recordingsPath = "/var/lib/asterisk/recordings";
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(recordingsPath);

Console.WriteLine($"Total space: {diskInfo.TotalSpace} bytes");
Console.WriteLine($"Free space: {diskInfo.FreeSpace} bytes");

// Check if we have enough space for a new recording (100MB)
if (GuardHelper.CheckDiskSpace(recordingsPath, 100))
{
    // Proceed with recording
}
else
{
    Console.WriteLine("Not enough disk space for recording");
}
```

### YamlWrapper

#### Overview
Provides methods for reading and writing YAML files.

#### Methods

##### ReadYaml<T>
```csharp
public static T ReadYaml<T>(string path) where T : class, new()
```
- **path**: Path to the YAML file
- **Returns**: Deserialized object of type T
- **Description**: Reads a YAML file and deserializes it to the specified type

##### WriteYaml<T>
```csharp
public static void WriteYaml<T>(string path, T obj) where T : class
```
- **path**: Path to write the YAML file
- **obj**: Object to serialize
- **Description**: Serializes an object to YAML and writes it to a file

#### Example
```csharp
// Define a class matching your YAML structure
public class ServerConfig
{
    public string ServerName { get; set; }
    public int Port { get; set; }
    public List<string> AllowedIPs { get; set; }
}

// Read configuration from YAML
var config = YamlWrapper.ReadYaml<ServerConfig>("/etc/zenda/server.yaml");
Console.WriteLine($"Server name: {config.ServerName}, Port: {config.Port}");

// Modify and save configuration
config.Port = 8080;
config.AllowedIPs.Add("192.168.1.100");
YamlWrapper.WriteYaml("/etc/zenda/server.yaml", config);
```

### DbConfig

#### Overview
Handles database configuration settings.

#### Properties
- **ConnectionString**: Gets or sets the database connection string
- **DbType**: Gets or sets the database type
- **Host**: Gets or sets the database host
- **Port**: Gets or sets the database port
- **Database**: Gets or sets the database name
- **Username**: Gets or sets the database username
- **Password**: Gets or sets the database password

#### Methods

##### Save
```csharp
public async Task Save(string filename)
```
- **filename**: Path to save the configuration
- **Description**: Saves the configuration to a file

##### Load
```csharp
public static async Task<DbConfig> Load(string filename)
```
- **filename**: Path to load the configuration from
- **Returns**: Loaded database configuration
- **Description**: Loads database configuration from a file

##### BuildConnectionString
```csharp
public string BuildConnectionString()
```
- **Returns**: Constructed connection string
- **Description**: Builds a connection string from the configuration properties

#### Example
```csharp
// Load database configuration
var dbConfig = await DbConfig.Load("/etc/zenda/database.json");

// Use the connection string
string connectionString = dbConfig.ConnectionString;
Console.WriteLine($"Connecting to {dbConfig.Host}:{dbConfig.Port}/{dbConfig.Database}");

// Modify configuration
dbConfig.Port = 5433;
dbConfig.Password = "newPassword";

// Update connection string
connectionString = dbConfig.BuildConnectionString();

// Save changes
await dbConfig.Save("/etc/zenda/database.json");
```

### AudioConversionHelper

#### Overview
Provides methods for audio file conversion and manipulation.

#### Methods

##### ConvertWavToMp3
```csharp
public static bool ConvertWavToMp3(string wavFile, string mp3File)
```
- **wavFile**: Path to the WAV file
- **mp3File**: Path to save the MP3 file
- **Returns**: True if conversion was successful, otherwise false
- **Description**: Converts a WAV file to MP3 format

##### ConvertMp3ToWav
```csharp
public static bool ConvertMp3ToWav(string mp3File, string wavFile)
```
- **mp3File**: Path to the MP3 file
- **wavFile**: Path to save the WAV file
- **Returns**: True if conversion was successful, otherwise false
- **Description**: Converts an MP3 file to WAV format

##### GetAudioDuration
```csharp
public static TimeSpan GetAudioDuration(string audioFile)
```
- **audioFile**: Path to the audio file
- **Returns**: Duration of the audio file
- **Description**: Gets the duration of an audio file

#### Example
```csharp
// Convert a recording from WAV to MP3
string wavFile = "/var/lib/asterisk/recordings/call_20230512.wav";
string mp3File = "/var/lib/asterisk/recordings/call_20230512.mp3";

if (AudioConversionHelper.ConvertWavToMp3(wavFile, mp3File))
{
    Console.WriteLine("Conversion successful");
    
    // Get the duration of the converted file
    TimeSpan duration = AudioConversionHelper.GetAudioDuration(mp3File);
    Console.WriteLine($"Recording duration: {duration.TotalSeconds} seconds");
    
    // Delete the original WAV file to save space
    File.Delete(wavFile);
}
else
{
    Console.WriteLine("Conversion failed");
}
```

### PromptsHelper

#### Overview
Manages system prompts and announcements.

#### Methods

##### GetPromptPath
```csharp
public static string GetPromptPath(string promptName, string language = "en")
```
- **promptName**: Name of the prompt
- **language**: Language code (default: "en")
- **Returns**: Path to the prompt file
- **Description**: Gets the file path for a system prompt

##### PromptExists
```csharp
public static bool PromptExists(string promptName, string language = "en")
```
- **promptName**: Name of the prompt
- **language**: Language code (default: "en")
- **Returns**: True if the prompt exists, otherwise false
- **Description**: Checks if a prompt exists

#### Example
```csharp
// Check if a prompt exists
string promptName = "welcome";
if (PromptsHelper.PromptExists(promptName, "en"))
{
    // Get the path to the prompt
    string promptPath = PromptsHelper.GetPromptPath(promptName, "en");
    Console.WriteLine($"Using prompt: {promptPath}");
    
    // Play the prompt (using a hypothetical method)
    PlayAudioFile(promptPath);
}
else
{
    Console.WriteLine($"Prompt '{promptName}' not found");
}
```

### DiskUsageInfo

#### Overview
Represents disk usage information.

#### Properties
- **TotalSpace**: Gets the total disk space in bytes
- **FreeSpace**: Gets the free disk space in bytes
- **UsedSpace**: Gets the used disk space in bytes
- **UsagePercentage**: Gets the disk usage as a percentage

#### Example
```csharp
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage("/var/lib/asterisk");

Console.WriteLine($"Total space: {diskInfo.TotalSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Free space: {diskInfo.FreeSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Used space: {diskInfo.UsedSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Usage: {diskInfo.UsagePercentage}%");

// Check if usage is above a threshold
if (diskInfo.UsagePercentage > 90)
{
    Console.WriteLine("Warning: Disk usage is high!");
}
```

### FolderEnumerationInfo

#### Overview
Provides information about folder contents.

#### Properties
- **Path**: Gets the folder path
- **FileCount**: Gets the number of files in the folder
- **TotalSize**: Gets the total size of files in the folder
- **Files**: Gets a list of files in the folder

#### Example
```csharp
// Get information about a recordings folder
string recordingsPath = "/var/lib/asterisk/recordings";
FolderEnumerationInfo folderInfo = new FolderEnumerationInfo(recordingsPath);

Console.WriteLine($"Path: {folderInfo.Path}");
Console.WriteLine($"File count: {folderInfo.FileCount}");
Console.WriteLine($"Total size: {folderInfo.TotalSize / (1024 * 1024)} MB");

// List files larger than 10MB
var largeFiles = folderInfo.Files.Where(f => f.Length > 10 * 1024 * 1024);
foreach (var file in largeFiles)
{
    Console.WriteLine($"Large file: {file.Name}, Size: {file.Length / (1024 * 1024)} MB");
}
```

### Shell Utilities

#### Overview
The Shell namespace provides utilities for executing shell commands across different operating systems.

#### Methods

##### Bash
```csharp
public static string Bash(this string cmd)
```
- **cmd**: Shell command to execute
- **Returns**: Command output
- **Description**: Executes a bash command and returns the output

##### PowerShell
```csharp
public static string PowerShell(this string cmd)
```
- **cmd**: PowerShell command to execute
- **Returns**: Command output
- **Description**: Executes a PowerShell command and returns the output

#### Example
```csharp
// Execute a command to check system status
string result = "systemctl status asterisk".Bash();
Console.WriteLine(result);

// On Windows, use PowerShell
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    string diskInfo = "Get-PSDrive C | Select-Object Used,Free".PowerShell();
    Console.WriteLine(diskInfo);
}
```

### SMS Utilities

#### Overview
The SMS namespace provides functionality for sending and receiving SMS messages.

#### Methods

##### SendSms
```csharp
public static async Task<bool> SendSms(string recipient, string message)
```
- **recipient**: Phone number to send the SMS to
- **message**: SMS message content
- **Returns**: True if the SMS was sent successfully, otherwise false
- **Description**: Sends an SMS message

#### Example
```csharp
// Send an SMS notification
string phoneNumber = "+1234567890";
string message = "Alert: System detected high CPU usage on server ZND-01";

bool success = await SmsHelper.SendSms(phoneNumber, message);
if (success)
{
    Console.WriteLine("SMS notification sent");
}
else
{
    Console.WriteLine("Failed to send SMS notification");
}
```

### Backup Utilities

#### Overview
The Backup namespace provides functionality for system backup and restoration.

#### Methods

##### CreateBackup
```csharp
public static async Task<string> CreateBackup(string backupPath, BackupOptions options)
```
- **backupPath**: Path to store the backup
- **options**: Backup options
- **Returns**: Path to the created backup file
- **Description**: Creates a system backup

##### RestoreBackup
```csharp
public static async Task<bool> RestoreBackup(string backupFile, RestoreOptions options)
```
- **backupFile**: Path to the backup file
- **options**: Restore options
- **Returns**: True if restoration was successful, otherwise false
- **Description**: Restores the system from a backup

#### Example
```csharp
// Create a backup
var backupOptions = new BackupOptions
{
    IncludeDatabase = true,
    IncludeRecordings = false,
    IncludeConfigurations = true
};

string backupFile = await BackupHelper.CreateBackup("/backups", backupOptions);
Console.WriteLine($"Backup created: {backupFile}");

// Restore from a backup
var restoreOptions = new RestoreOptions
{
    RestoreDatabase = true,
    RestoreConfigurations = true,
    OverwriteExisting = false
};

bool success = await BackupHelper.RestoreBackup(backupFile, restoreOptions);
if (success)
{
    Console.WriteLine("System restored successfully");
}
else
{
    Console.WriteLine("Restoration failed");
}
```

### HTTP Utilities

#### Overview
The Http namespace provides utilities for HTTP operations.

#### Methods

##### Get
```csharp
public static async Task<string> Get(string url, Dictionary<string, string> headers = null)
```
- **url**: URL to send the GET request to
- **headers**: Optional HTTP headers
- **Returns**: Response content
- **Description**: Sends an HTTP GET request

##### Post
```csharp
public static async Task<string> Post(string url, object data, Dictionary<string, string> headers = null)
```
- **url**: URL to send the POST request to
- **data**: Data to send in the request body
- **headers**: Optional HTTP headers
- **Returns**: Response content
- **Description**: Sends an HTTP POST request

#### Example
```csharp
// Send a GET request to check API status
string apiUrl = "https://api.example.com/status";
var headers = new Dictionary<string, string>
{
    { "Authorization", "Bearer token123" }
};

try
{
    string response = await HttpHelper.Get(apiUrl, headers);
    Console.WriteLine($"API Status: {response}");
}
catch (Exception ex)
{
    Console.WriteLine($"API request failed: {ex.Message}");
}

// Send a POST request to create a resource
string createUrl = "https://api.example.com/resources";
var newResource = new { Name = "Test Resource", Type = "Voice" };

string createResponse = await HttpHelper.Post(createUrl, newResource, headers);
Console.WriteLine($"Create response: {createResponse}");
```

### ZeroTier Utilities

#### Overview
The ZeroTier namespace provides functionality for working with ZeroTier virtual networks.

#### Methods

##### GetNetworkStatus
```csharp
public static async Task<ZeroTierNetworkStatus> GetNetworkStatus(string networkId)
```
- **networkId**: ZeroTier network ID
- **Returns**: Network status information
- **Description**: Gets the status of a ZeroTier network

##### JoinNetwork
```csharp
public static async Task<bool> JoinNetwork(string networkId)
```
- **networkId**: ZeroTier network ID
- **Returns**: True if joined successfully, otherwise false
- **Description**: Joins a ZeroTier network

#### Example
```csharp
// Check ZeroTier network status
string networkId = "8056c2e21c000001";
var networkStatus = await ZeroTierHelper.GetNetworkStatus(networkId);

Console.WriteLine($"Network: {networkId}");
Console.WriteLine($"Status: {networkStatus.Status}");
Console.WriteLine($"Assigned IP: {networkStatus.AssignedIp}");

// Join a network if not already connected
if (networkStatus.Status != "OK")
{
    bool joined = await ZeroTierHelper.JoinNetwork(networkId);
    if (joined)
    {
        Console.WriteLine("Successfully joined ZeroTier network");
    }
    else
    {
        Console.WriteLine("Failed to join ZeroTier network");
    }
}
```

## Usage Scenarios

### Scenario 1: Certificate Management

```csharp
// Initialize the TLS manager
var tlsManager = new TlsManager(Constants.TLSAPP, "/etc/zenda/certs");

// Check if certificates exist and are valid
var serverCert = tlsManager.GetCertificateInfo("server");
var clientCert = tlsManager.GetCertificateInfo("client");

// Create or renew certificates as needed
if (!serverCert.IsValid || serverCert.IsExpired)
{
    Console.WriteLine("Server certificate needs to be created or renewed");
    tlsManager.CreateCert.Assure("server", "securePassword");
}

if (!clientCert.IsValid || clientCert.IsExpired)
{
    Console.WriteLine("Client certificate needs to be created or renewed");
    tlsManager.CreateCert.Assure("client", "securePassword");
}

// Get paths for configuration
string serverCertPath = tlsManager.GetCertificatePath("server");
string clientCertPath = tlsManager.GetCertificatePath("client");

Console.WriteLine($"Using server certificate: {serverCertPath}");
Console.WriteLine($"Using client certificate: {clientCertPath}");
```

### Scenario 2: Audio File Management

```csharp
// Convert a batch of recording files from WAV to MP3
string recordingsDir = "/var/lib/asterisk/recordings";
var directory = new DirectoryInfo(recordingsDir);
var wavFiles = directory.GetFiles("*.wav");

Console.WriteLine($"Found {wavFiles.Length} WAV files to convert");

foreach (var wavFile in wavFiles)
{
    string mp3FilePath = Path.ChangeExtension(wavFile.FullName, ".mp3");
    
    Console.WriteLine($"Converting {wavFile.Name} to MP3...");
    
    if (AudioConversionHelper.ConvertWavToMp3(wavFile.FullName, mp3FilePath))
    {
        // Get file sizes
        long wavSize = wavFile.Length;
        long mp3Size = new FileInfo(mp3FilePath).Length;
        
        // Calculate space savings
        double savingsPercent = 100 - ((double)mp3Size / wavSize * 100);
        
        Console.WriteLine($"Conversion successful. Space saved: {savingsPercent:F2}%");
        
        // Delete the original WAV file
        wavFile.Delete();
    }
    else
    {
        Console.WriteLine($"Failed to convert {wavFile.Name}");
    }
}

// Check disk usage after conversion
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(recordingsDir);
Console.WriteLine($"Recordings directory usage: {diskInfo.UsagePercentage}%");
```

### Scenario 3: Database Configuration

```csharp
// Load or create database configuration
DbConfig dbConfig;
string configPath = "/etc/zenda/database.json";

try
{
    dbConfig = await DbConfig.Load(configPath);
    Console.WriteLine("Database configuration loaded");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Configuration file not found, creating default configuration");
    
    // Create default configuration
    dbConfig = new DbConfig
    {
        DbType = "PostgreSQL",
        Host = "localhost",
        Port = 5432,
        Database = "zenda",
        Username = "zenda_user",
        Password = "defaultPassword"
    };
    
    // Save the default configuration
    await dbConfig.Save(configPath);
}

// Display current configuration
Console.WriteLine($"Database Type: {dbConfig.DbType}");
Console.WriteLine($"Host: {dbConfig.Host}");
Console.WriteLine($"Port: {dbConfig.Port}");
Console.WriteLine($"Database: {dbConfig.Database}");
Console.WriteLine($"Username: {dbConfig.Username}");

// Update configuration if needed
Console.WriteLine("Updating database configuration...");
dbConfig.Port = 5433;
dbConfig.Password = "newSecurePassword";

// Rebuild connection string with new values
string connectionString = dbConfig.BuildConnectionString();
Console.WriteLine($"New connection string: {connectionString}");

// Save updated configuration
await dbConfig.Save(configPath);
Console.WriteLine("Configuration updated and saved");
```

### Scenario 4: System Monitoring

```csharp
// Check system resources
Console.WriteLine("Checking system resources...");

// Check disk space on key directories
string[] criticalPaths = {
    "/var/lib/asterisk/recordings",
    "/var/log/zenda",
    "/var/lib/postgresql/data"
};

foreach (string path in criticalPaths)
{
    DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(path);
    
    Console.WriteLine($"Path: {path}");
    Console.WriteLine($"  Total: {diskInfo.TotalSpace / (1024 * 1024 * 1024):F2} GB");
    Console.WriteLine($"  Free: {diskInfo.FreeSpace / (1024 * 1024 * 1024):F2} GB");
    Console.WriteLine($"  Usage: {diskInfo.UsagePercentage:F2}%");
    
    // Alert if disk usage is high
    if (diskInfo.UsagePercentage > 90)
    {
        Console.WriteLine($"  WARNING: High disk usage on {path}");
        
        // Send SMS alert to administrator
        await SmsHelper.SendSms("+1234567890", $"Warning: High disk usage ({diskInfo.UsagePercentage:F0}%) on {path}");
    }
}

// Check for large files that might need cleanup
string logsPath = "/var/log/zenda";
FolderEnumerationInfo logsInfo = new FolderEnumerationInfo(logsPath);

var largeLogFiles = logsInfo.Files
    .Where(f => f.Length > 100 * 1024 * 1024) // Files larger than 100MB
    .OrderByDescending(f => f.Length);

if (largeLogFiles.Any())
{
    Console.WriteLine("Large log files that might need attention:");
    
    foreach (var file in largeLogFiles)
    {
        Console.WriteLine($"  {file.Name}: {file.Length / (1024 * 1024):F2} MB");
    }
}
```

### Scenario 5: Configuration Management with YAML

```csharp
// Define configuration classes
public class SystemConfig
{
    public ServerSettings Server { get; set; } = new ServerSettings();
    public LoggingSettings Logging { get; set; } = new LoggingSettings();
    public SecuritySettings Security { get; set; } = new SecuritySettings();
}

public class ServerSettings
{
    public string HostName { get; set; } = "localhost";
    public int Port { get; set; } = 8080;
    public List<string> AllowedOrigins { get; set; } = new List<string>();
}

public class LoggingSettings
{
    public string Level { get; set; } = "Info";
    public string Path { get; set; } = "/var/log/zenda";
    public bool ConsoleOutput { get; set; } = true;
}

public class SecuritySettings
{
    public bool RequireTls { get; set; } = true;
    public int SessionTimeout { get; set; } = 30;
}

// Load configuration from YAML
string configPath = "/etc/zenda/config.yaml";

SystemConfig config;
try
{
    config = YamlWrapper.ReadYaml<SystemConfig>(configPath);
    Console.WriteLine("Configuration loaded successfully");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Configuration file not found, creating default configuration");
    
    // Create default configuration
    config = new SystemConfig();
    config.Server.AllowedOrigins.Add("https://admin.example.com");
    
    // Save default configuration
    YamlWrapper.WriteYaml(configPath, config);
}

// Use configuration values
Console.WriteLine($"Server: {config.Server.HostName}:{config.Server.Port}");
Console.WriteLine($"Logging level: {config.Logging.Level}");
Console.WriteLine($"TLS required: {config.Security.RequireTls}");

// Update configuration
config.Server.Port = 8443;
config.Security.SessionTimeout = 60;
config.Logging.Level = "Debug";

// Save updated configuration
YamlWrapper.WriteYaml(configPath, config);
Console.WriteLine("Configuration updated and saved");
```

## Best Practices

1. **Error Handling**:
   - Always catch and handle exceptions from utility methods
   - Provide meaningful error messages
   - Log errors for troubleshooting

2. **Resource Management**:
   - Dispose of resources properly when using file operations
   - Use asynchronous methods for I/O operations
   - Check disk space before performing large file operations

3. **Security**:
   - Protect sensitive information in configuration files
   - Use secure methods for certificate management
   - Validate and sanitize inputs to shell commands

4. **Performance**:
   - Use efficient algorithms for file operations
   - Minimize disk I/O operations
   - Cache frequently used configuration values

5. **Compatibility**:
   - Consider cross-platform compatibility for shell operations
   - Handle platform-specific differences gracefully
   - Use platform-agnostic paths when possible

## Conclusion

The Zenda.Common module provides a comprehensive set of utility functions and helpers that form the foundation for many operations in the Zenda VoIP Call Manager system. By centralizing common functionality, it promotes code reuse and consistency across the application. The module's diverse capabilities, from file operations to security management to configuration handling, make it an essential component of the Zenda system architecture.

The utilities provided by Zenda.Common are designed to be simple to use yet powerful, handling complex operations like certificate management and audio conversion with clean, intuitive interfaces. This approach allows other modules to focus on their specific business logic while leveraging these common utilities for underlying functionality.

As the Zenda system evolves, the Common module will continue to grow with new utilities and helpers to support emerging requirements, while maintaining backward compatibility with existing code. Its modular design ensures that new functionality can be added without disrupting existing operations, making it a stable and reliable foundation for the entire system.

```csharp
string tlsAppName = Constants.TLSAPP;
```

```csharp
public static long GetFileSize(this string filename)
```

```csharp
string filePath = "/path/to/file.wav";
long fileSize = filePath.GetFileSize();
Console.WriteLine($"File size: {fileSize} bytes");
```

```csharp
public TlsManager(string appName, string certPath)
```

```csharp
public CertificateInfo GetCertificateInfo(string name)
```

```csharp
public string GetCertificatePath(string name)
```

```csharp
var tlsManager = new TlsManager("zenda", "/etc/zenda/certs");
var certInfo = tlsManager.GetCertificateInfo("server");

if (certInfo.IsValid && !certInfo.IsExpired)
{
    string certPath = tlsManager.GetCertificatePath("server");
    Console.WriteLine($"Using valid certificate at: {certPath}");
}
else
{
    // Create a new certificate
    tlsManager.CreateCert.Assure("server", "password");
}
```

```csharp
public static DiskUsageInfo GetDiskUsage(string path)
```

```csharp
public static bool CheckDiskSpace(string path, long requiredMb)
```

```csharp
string recordingsPath = "/var/lib/asterisk/recordings";
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(recordingsPath);

Console.WriteLine($"Total space: {diskInfo.TotalSpace} bytes");
Console.WriteLine($"Free space: {diskInfo.FreeSpace} bytes");

// Check if we have enough space for a new recording (100MB)
if (GuardHelper.CheckDiskSpace(recordingsPath, 100))
{
    // Proceed with recording
}
else
{
    Console.WriteLine("Not enough disk space for recording");
}
```

```csharp
public static T ReadYaml<T>(string path) where T : class, new()
```

```csharp
public static void WriteYaml<T>(string path, T obj) where T : class
```

```csharp
// Define a class matching your YAML structure
public class ServerConfig
{
    public string ServerName { get; set; }
    public int Port { get; set; }
    public List<string> AllowedIPs { get; set; }
}

// Read configuration from YAML
var config = YamlWrapper.ReadYaml<ServerConfig>("/etc/zenda/server.yaml");
Console.WriteLine($"Server name: {config.ServerName}, Port: {config.Port}");

// Modify and save configuration
config.Port = 8080;
config.AllowedIPs.Add("192.168.1.100");
YamlWrapper.WriteYaml("/etc/zenda/server.yaml", config);
```

```csharp
public async Task Save(string filename)
```

```csharp
public static async Task<DbConfig> Load(string filename)
```

```csharp
public string BuildConnectionString()
```

```csharp
// Load database configuration
var dbConfig = await DbConfig.Load("/etc/zenda/database.json");

// Use the connection string
string connectionString = dbConfig.ConnectionString;
Console.WriteLine($"Connecting to {dbConfig.Host}:{dbConfig.Port}/{dbConfig.Database}");

// Modify configuration
dbConfig.Port = 5433;
dbConfig.Password = "newPassword";

// Update connection string
connectionString = dbConfig.BuildConnectionString();

// Save changes
await dbConfig.Save("/etc/zenda/database.json");
```

```csharp
public static bool ConvertWavToMp3(string wavFile, string mp3File)
```

```csharp
public static bool ConvertMp3ToWav(string mp3File, string wavFile)
```

```csharp
public static TimeSpan GetAudioDuration(string audioFile)
```

```csharp
// Convert a recording from WAV to MP3
string wavFile = "/var/lib/asterisk/recordings/call_20230512.wav";
string mp3File = "/var/lib/asterisk/recordings/call_20230512.mp3";

if (AudioConversionHelper.ConvertWavToMp3(wavFile, mp3File))
{
    Console.WriteLine("Conversion successful");
    
    // Get the duration of the converted file
    TimeSpan duration = AudioConversionHelper.GetAudioDuration(mp3File);
    Console.WriteLine($"Recording duration: {duration.TotalSeconds} seconds");
    
    // Delete the original WAV file to save space
    File.Delete(wavFile);
}
else
{
    Console.WriteLine("Conversion failed");
}
```

```csharp
public static string GetPromptPath(string promptName, string language = "en")
```

```csharp
public static bool PromptExists(string promptName, string language = "en")
```

```csharp
// Check if a prompt exists
string promptName = "welcome";
if (PromptsHelper.PromptExists(promptName, "en"))
{
    // Get the path to the prompt
    string promptPath = PromptsHelper.GetPromptPath(promptName, "en");
    Console.WriteLine($"Using prompt: {promptPath}");
    
    // Play the prompt (using a hypothetical method)
    PlayAudioFile(promptPath);
}
else
{
    Console.WriteLine($"Prompt '{promptName}' not found");
}
```

```csharp
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage("/var/lib/asterisk");

Console.WriteLine($"Total space: {diskInfo.TotalSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Free space: {diskInfo.FreeSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Used space: {diskInfo.UsedSpace / (1024 * 1024 * 1024)} GB");
Console.WriteLine($"Usage: {diskInfo.UsagePercentage}%");

// Check if usage is above a threshold
if (diskInfo.UsagePercentage > 90)
{
    Console.WriteLine("Warning: Disk usage is high!");
}
```

```csharp
// Get information about a recordings folder
string recordingsPath = "/var/lib/asterisk/recordings";
FolderEnumerationInfo folderInfo = new FolderEnumerationInfo(recordingsPath);

Console.WriteLine($"Path: {folderInfo.Path}");
Console.WriteLine($"File count: {folderInfo.FileCount}");
Console.WriteLine($"Total size: {folderInfo.TotalSize / (1024 * 1024)} MB");

// List files larger than 10MB
var largeFiles = folderInfo.Files.Where(f => f.Length > 10 * 1024 * 1024);
foreach (var file in largeFiles)
{
    Console.WriteLine($"Large file: {file.Name}, Size: {file.Length / (1024 * 1024)} MB");
}
```

```csharp
public static string Bash(this string cmd)
```

```csharp
public static string PowerShell(this string cmd)
```

```csharp
// Execute a command to check system status
string result = "systemctl status asterisk".Bash();
Console.WriteLine(result);

// On Windows, use PowerShell
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    string diskInfo = "Get-PSDrive C | Select-Object Used,Free".PowerShell();
    Console.WriteLine(diskInfo);
}
```

```csharp
public static async Task<bool> SendSms(string recipient, string message)
```

```csharp
// Send an SMS notification
string phoneNumber = "+1234567890";
string message = "Alert: System detected high CPU usage on server ZND-01";

bool success = await SmsHelper.SendSms(phoneNumber, message);
if (success)
{
    Console.WriteLine("SMS notification sent");
}
else
{
    Console.WriteLine("Failed to send SMS notification");
}
```

```csharp
public static async Task<string> CreateBackup(string backupPath, BackupOptions options)
```

```csharp
public static async Task<bool> RestoreBackup(string backupFile, RestoreOptions options)
```

```csharp
// Create a backup
var backupOptions = new BackupOptions
{
    IncludeDatabase = true,
    IncludeRecordings = false,
    IncludeConfigurations = true
};

string backupFile = await BackupHelper.CreateBackup("/backups", backupOptions);
Console.WriteLine($"Backup created: {backupFile}");

// Restore from a backup
var restoreOptions = new RestoreOptions
{
    RestoreDatabase = true,
    RestoreConfigurations = true,
    OverwriteExisting = false
};

bool success = await BackupHelper.RestoreBackup(backupFile, restoreOptions);
if (success)
{
    Console.WriteLine("System restored successfully");
}
else
{
    Console.WriteLine("Restoration failed");
}
```

```csharp
public static async Task<string> Get(string url, Dictionary<string, string> headers = null)
```

```csharp
public static async Task<string> Post(string url, object data, Dictionary<string, string> headers = null)
```

```csharp
// Send a GET request to check API status
string apiUrl = "https://api.example.com/status";
var headers = new Dictionary<string, string>
{
    { "Authorization", "Bearer token123" }
};

try
{
    string response = await HttpHelper.Get(apiUrl, headers);
    Console.WriteLine($"API Status: {response}");
}
catch (Exception ex)
{
    Console.WriteLine($"API request failed: {ex.Message}");
}

// Send a POST request to create a resource
string createUrl = "https://api.example.com/resources";
var newResource = new { Name = "Test Resource", Type = "Voice" };

string createResponse = await HttpHelper.Post(createUrl, newResource, headers);
Console.WriteLine($"Create response: {createResponse}");
```

```csharp
public static async Task<ZeroTierNetworkStatus> GetNetworkStatus(string networkId)
```

```csharp
public static async Task<bool> JoinNetwork(string networkId)
```

```csharp
// Check ZeroTier network status
string networkId = "8056c2e21c000001";
var networkStatus = await ZeroTierHelper.GetNetworkStatus(networkId);

Console.WriteLine($"Network: {networkId}");
Console.WriteLine($"Status: {networkStatus.Status}");
Console.WriteLine($"Assigned IP: {networkStatus.AssignedIp}");

// Join a network if not already connected
if (networkStatus.Status != "OK")
{
    bool joined = await ZeroTierHelper.JoinNetwork(networkId);
    if (joined)
    {
        Console.WriteLine("Successfully joined ZeroTier network");
    }
    else
    {
        Console.WriteLine("Failed to join ZeroTier network");
    }
}
```

```csharp
// Initialize the TLS manager
var tlsManager = new TlsManager(Constants.TLSAPP, "/etc/zenda/certs");

// Check if certificates exist and are valid
var serverCert = tlsManager.GetCertificateInfo("server");
var clientCert = tlsManager.GetCertificateInfo("client");

// Create or renew certificates as needed
if (!serverCert.IsValid || serverCert.IsExpired)
{
    Console.WriteLine("Server certificate needs to be created or renewed");
    tlsManager.CreateCert.Assure("server", "securePassword");
}

if (!clientCert.IsValid || clientCert.IsExpired)
{
    Console.WriteLine("Client certificate needs to be created or renewed");
    tlsManager.CreateCert.Assure("client", "securePassword");
}

// Get paths for configuration
string serverCertPath = tlsManager.GetCertificatePath("server");
string clientCertPath = tlsManager.GetCertificatePath("client");

Console.WriteLine($"Using server certificate: {serverCertPath}");
Console.WriteLine($"Using client certificate: {clientCertPath}");
```

```csharp
// Convert a batch of recording files from WAV to MP3
string recordingsDir = "/var/lib/asterisk/recordings";
var directory = new DirectoryInfo(recordingsDir);
var wavFiles = directory.GetFiles("*.wav");

Console.WriteLine($"Found {wavFiles.Length} WAV files to convert");

foreach (var wavFile in wavFiles)
{
    string mp3FilePath = Path.ChangeExtension(wavFile.FullName, ".mp3");
    
    Console.WriteLine($"Converting {wavFile.Name} to MP3...");
    
    if (AudioConversionHelper.ConvertWavToMp3(wavFile.FullName, mp3FilePath))
    {
        // Get file sizes
        long wavSize = wavFile.Length;
        long mp3Size = new FileInfo(mp3FilePath).Length;
        
        // Calculate space savings
        double savingsPercent = 100 - ((double)mp3Size / wavSize * 100);
        
        Console.WriteLine($"Conversion successful. Space saved: {savingsPercent:F2}%");
        
        // Delete the original WAV file
        wavFile.Delete();
    }
    else
    {
        Console.WriteLine($"Failed to convert {wavFile.Name}");
    }
}

// Check disk usage after conversion
DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(recordingsDir);
Console.WriteLine($"Recordings directory usage: {diskInfo.UsagePercentage}%");
```

```csharp
// Load or create database configuration
DbConfig dbConfig;
string configPath = "/etc/zenda/database.json";

try
{
    dbConfig = await DbConfig.Load(configPath);
    Console.WriteLine("Database configuration loaded");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Configuration file not found, creating default configuration");
    
    // Create default configuration
    dbConfig = new DbConfig
    {
        DbType = "PostgreSQL",
        Host = "localhost",
        Port = 5432,
        Database = "zenda",
        Username = "zenda_user",
        Password = "defaultPassword"
    };
    
    // Save the default configuration
    await dbConfig.Save(configPath);
}

// Display current configuration
Console.WriteLine($"Database Type: {dbConfig.DbType}");
Console.WriteLine($"Host: {dbConfig.Host}");
Console.WriteLine($"Port: {dbConfig.Port}");
Console.WriteLine($"Database: {dbConfig.Database}");
Console.WriteLine($"Username: {dbConfig.Username}");

// Update configuration if needed
Console.WriteLine("Updating database configuration...");
dbConfig.Port = 5433;
dbConfig.Password = "newSecurePassword";

// Rebuild connection string with new values
string connectionString = dbConfig.BuildConnectionString();
Console.WriteLine($"New connection string: {connectionString}");

// Save updated configuration
await dbConfig.Save(configPath);
Console.WriteLine("Configuration updated and saved");
```

```csharp
// Check system resources
Console.WriteLine("Checking system resources...");

// Check disk space on key directories
string[] criticalPaths = {
    "/var/lib/asterisk/recordings",
    "/var/log/zenda",
    "/var/lib/postgresql/data"
};

foreach (string path in criticalPaths)
{
    DiskUsageInfo diskInfo = GuardHelper.GetDiskUsage(path);
    
    Console.WriteLine($"Path: {path}");
    Console.WriteLine($"  Total: {diskInfo.TotalSpace / (1024 * 1024 * 1024):F2} GB");
    Console.WriteLine($"  Free: {diskInfo.FreeSpace / (1024 * 1024 * 1024):F2} GB");
    Console.WriteLine($"  Usage: {diskInfo.UsagePercentage:F2}%");
    
    // Alert if disk usage is high
    if (diskInfo.UsagePercentage > 90)
    {
        Console.WriteLine($"  WARNING: High disk usage on {path}");
        
        // Send SMS alert to administrator
        await SmsHelper.SendSms("+1234567890", $"Warning: High disk usage ({diskInfo.UsagePercentage:F0}%) on {path}");
    }
}

// Check for large files that might need cleanup
string logsPath = "/var/log/zenda";
FolderEnumerationInfo logsInfo = new FolderEnumerationInfo(logsPath);

var largeLogFiles = logsInfo.Files
    .Where(f => f.Length > 100 * 1024 * 1024) // Files larger than 100MB
    .OrderByDescending(f => f.Length);

if (largeLogFiles.Any())
{
    Console.WriteLine("Large log files that might need attention:");
    
    foreach (var file in largeLogFiles)
    {
        Console.WriteLine($"  {file.Name}: {file.Length / (1024 * 1024):F2} MB");
    }
}
```

```csharp
// Define configuration classes
public class SystemConfig
{
    public ServerSettings Server { get; set; } = new ServerSettings();
    public LoggingSettings Logging { get; set; } = new LoggingSettings();
    public SecuritySettings Security { get; set; } = new SecuritySettings();
}

public class ServerSettings
{
    public string HostName { get; set; } = "localhost";
    public int Port { get; set; } = 8080;
    public List<string> AllowedOrigins { get; set; } = new List<string>();
}

public class LoggingSettings
{
    public string Level { get; set; } = "Info";
    public string Path { get; set; } = "/var/log/zenda";
    public bool ConsoleOutput { get; set; } = true;
}

public class SecuritySettings
{
    public bool RequireTls { get; set; } = true;
    public int SessionTimeout { get; set; } = 30;
}

// Load configuration from YAML
string configPath = "/etc/zenda/config.yaml";

SystemConfig config;
try
{
    config = YamlWrapper.ReadYaml<SystemConfig>(configPath);
    Console.WriteLine("Configuration loaded successfully");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Configuration file not found, creating default configuration");
    
    // Create default configuration
    config = new SystemConfig();
    config.Server.AllowedOrigins.Add("https://admin.example.com");
    
    // Save default configuration
    YamlWrapper.WriteYaml(configPath, config);
}

// Use configuration values
Console.WriteLine($"Server: {config.Server.HostName}:{config.Server.Port}");
Console.WriteLine($"Logging level: {config.Logging.Level}");
Console.WriteLine($"TLS required: {config.Security.RequireTls}");

// Update configuration
config.Server.Port = 8443;
config.Security.SessionTimeout = 60;
config.Logging.Level = "Debug";

// Save updated configuration
YamlWrapper.WriteYaml(configPath, config);
Console.WriteLine("Configuration updated and saved");
```

---

**User**

please generate comprehensive documentation for the Zenda.CrmIntegration module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.CrmIntegration

## Overview

The Zenda.CrmIntegration module provides a bridge between the Zenda VoIP Call Manager system and external Customer Relationship Management (CRM) systems. This integration layer enables seamless interaction between telephony operations and customer data management, allowing for features such as screen pop-ups, automatic customer identification during calls, call logging to CRM systems, and bi-directional data synchronization. The module is designed with flexibility to support various CRM platforms through a standardized interface while accommodating platform-specific requirements.

## Features

1. **Customer Data Retrieval**: Fetches customer information from external CRM systems based on phone numbers.

2. **Call Event Notifications**: Sends call events (ringing, answered, ended) to CRM systems for tracking and logging.

3. **URL Generation**: Creates URLs for opening customer records or creating new customers in the CRM.

4. **Call Logging**: Records call details in the CRM system for customer interaction history.

5. **Flexible Integration Types**: Supports different integration approaches including REST API, webhook-based, and custom protocols.

6. **Phone Number Formatting**: Handles phone number formatting differences between systems.

7. **Authentication**: Manages authentication with external CRM systems.

8. **Error Handling**: Provides robust error handling for CRM communication issues.

## Dependencies

- **.NET 8.0**: Core framework for the application
- **System.Net.Http**: For HTTP communication with CRM systems
- **System.Text.Json**: For JSON serialization/deserialization
- **Zenda.DAL.Entities**: For CRM configuration and entity models
- **Zenda.DAL.Common**: For shared data structures

## Data Flow

1. **Inbound Call Flow**:
   - Call arrives in the Zenda system
   - Phone number is extracted and sent to CrmInterface
   - CrmInterface queries external CRM system for customer data
   - Customer information is returned to Zenda for call routing and display

2. **Customer Data Synchronization**:
   - Customer data is retrieved from CRM during calls
   - Information is cached and used within Zenda
   - Updates may be sent back to the CRM system

3. **Call Event Notifications**:
   - Call state changes in Zenda (ringing, answered, ended)
   - Events are formatted according to CRM requirements
   - Notifications are sent to CRM through configured endpoints

4. **Call Logging**:
   - Call details are collected throughout the call lifecycle
   - At call completion, details are formatted for the CRM
   - Call record is created or updated in the CRM system

## Configuration

The CRM integration is configured through the `CrmParameters` entity, which includes:

- **IntegrationType**: The type of CRM integration (None, REST, Webhook, etc.)
- **GetRequestUrl**: URL template for retrieving customer data
- **OpenCustomerUrl**: URL template for opening existing customer records
- **NewCustomerUrl**: URL template for creating new customer records
- **CallRingingUrl**: URL template for notifying CRM of ringing calls
- **CallAddedUrl**: URL template for logging completed calls
- **GetResponseFormat**: Format specification for parsing CRM responses
- **AuthorizationHeader**: HTTP header name for authentication
- **AuthorizationKey**: Authentication key or token
- **LocalAreaCode**: Local area code for phone number formatting
- **CountryCode**: Country code for international number formatting

## Core Classes and Functions

### ICrmInterface

#### Overview
Interface defining the contract for CRM integration implementations.

#### Methods

##### Start
```csharp
void Start();
```
- **Description**: Initializes the CRM interface and establishes necessary connections

##### Stop
```csharp
void Stop();
```
- **Description**: Stops the CRM interface and cleans up resources

##### GetCustomer
```csharp
Task<CrmCustomer> GetCustomer(string number);
```
- **number**: Phone number to search for
- **Returns**: Customer information if found, otherwise null
- **Description**: Retrieves customer information from the CRM system based on phone number

##### CreateOpenCustomerUrl
```csharp
string CreateOpenCustomerUrl(string id);
```
- **id**: Customer ID in the CRM system
- **Returns**: URL to open the customer record in the CRM
- **Description**: Generates a URL for opening an existing customer record

##### CreateNewCustomerUrl
```csharp
string CreateNewCustomerUrl(string number);
```
- **number**: Phone number for the new customer
- **Returns**: URL to create a new customer in the CRM
- **Description**: Generates a URL for creating a new customer record

### CrmCustomer

#### Overview
Represents customer data retrieved from a CRM system.

#### Properties
- **Id**: Gets or sets the customer ID in the CRM system
- **Name**: Gets or sets the customer name
- **Phones**: Gets or sets an array of phone numbers associated with the customer

#### Example
```csharp
var customer = new CrmCustomer
{
    Id = "CRM123456",
    Name = "John Smith",
    Phones = new[] { "+1234567890", "+1987654321" }
};

Console.WriteLine($"Customer: {customer.Name}, ID: {customer.Id}");
foreach (var phone in customer.Phones)
{
    Console.WriteLine($"Phone: {phone}");
}
```

### CrmCallInfo

#### Overview
Represents call information to be sent to a CRM system.

#### Properties
- **ExtId**: Gets or sets the extension ID
- **CallId**: Gets or sets the call ID
- **Date**: Gets or sets the call date and time
- **Number**: Gets or sets the phone number
- **CustomerId**: Gets or sets the customer ID
- **CustomerName**: Gets or sets the customer name
- **CallType**: Gets or sets the call type (Incoming, Outgoing, Internal)
- **CallStatus**: Gets or sets the call status (Answered, Missed, etc.)
- **Duration**: Gets or sets the call duration in seconds
- **IvrService**: Gets or sets the IVR service that handled the call
- **RecordingFile**: Gets or sets the path to the call recording file

#### Example
```csharp
var callInfo = new CrmCallInfo
{
    ExtId = "101",
    CallId = "CALL123456",
    Date = DateTime.Now,
    Number = "+1234567890",
    CustomerId = "CRM123456",
    CustomerName = "John Smith",
    CallType = "Incoming",
    CallStatus = "Answered",
    Duration = 120,
    IvrService = "Sales",
    RecordingFile = "/recordings/call_123456.mp3"
};

// Format the call info for logging
Console.WriteLine($"Call from {callInfo.CustomerName} ({callInfo.Number})");
Console.WriteLine($"Duration: {callInfo.Duration} seconds");
Console.WriteLine($"Handled by: Extension {callInfo.ExtId}, IVR: {callInfo.IvrService}");
```

### CrmInterface

#### Overview
The main implementation of the ICrmInterface that provides CRM integration functionality.

#### Constructor
```csharp
public CrmInterface(CrmParameters config)
```
- **config**: CRM configuration parameters
- **Description**: Creates a new CRM interface with the specified configuration

#### Properties
- **Config**: Gets the CRM configuration parameters

#### Methods

##### Start
```csharp
public void Start()
```
- **Description**: Initializes the CRM interface and HTTP client

##### Stop
```csharp
public void Stop()
```
- **Description**: Stops the CRM interface and disposes of resources

##### GetCustomer
```csharp
public async Task<CrmCustomer> GetCustomer(string number)
```
- **number**: Phone number to search for
- **Returns**: Customer information if found, otherwise null
- **Description**: Retrieves customer information from the CRM system based on phone number

##### CreateOpenCustomerUrl
```csharp
public string CreateOpenCustomerUrl(string id)
```
- **id**: Customer ID in the CRM system
- **Returns**: URL to open the customer record in the CRM
- **Description**: Generates a URL for opening an existing customer record

##### CreateNewCustomerUrl
```csharp
public string CreateNewCustomerUrl(string number)
```
- **number**: Phone number for the new customer
- **Returns**: URL to create a new customer in the CRM
- **Description**: Generates a URL for creating a new customer record

##### OnCallAdded
```csharp
public async Task OnCallAdded(SubCallDb scall)
```
- **scall**: Subcall database record
- **Description**: Notifies the CRM system about a completed call

##### OnCallRinging
```csharp
public async Task OnCallRinging(string extId, string number, long customerId, bool isSend)
```
- **extId**: Extension ID
- **number**: Phone number
- **customerId**: Customer ID
- **isSend**: Whether this is an outbound call
- **Description**: Notifies the CRM system about a ringing call

##### AddAreaCode
```csharp
protected string AddAreaCode(string number)
```
- **number**: Phone number to format
- **Returns**: Formatted phone number
- **Description**: Adds area code to a phone number if needed

##### DeserializeCustomer
```csharp
private CrmCustomer DeserializeCustomer(string data)
```
- **data**: JSON or formatted string data
- **Returns**: Parsed customer object
- **Description**: Parses customer data from CRM response

##### DeserializeCustomerObject
```csharp
private CrmCustomer DeserializeCustomerObject(string data)
```
- **data**: JSON data
- **Returns**: Parsed customer object
- **Description**: Parses customer data from JSON response

##### DeserializeCustomerString
```csharp
private CrmCustomer DeserializeCustomerString(string data)
```
- **data**: Formatted string data
- **Returns**: Parsed customer object
- **Description**: Parses customer data from formatted string response

#### Example
```csharp
// Create CRM interface with configuration
var crmParams = new CrmParameters
{
    IntegrationType = CrmIntegrationType.REST,
    GetRequestUrl = "https://crm.example.com/api/customer/{NUMBER}",
    OpenCustomerUrl = "https://crm.example.com/customer/{CUSTOMERID}",
    NewCustomerUrl = "https://crm.example.com/customer/new?phone={NUMBER}",
    CallRingingUrl = "https://crm.example.com/api/call/ringing?ext={EXTID}&number={NUMBER}&id={CUSTOMERID}&type={CALLTYPE}",
    CallAddedUrl = "https://crm.example.com/api/call/log",
    AuthorizationHeader = "ApiKey",
    AuthorizationKey = "secret-api-key-123",
    CountryCode = "+1",
    LocalAreaCode = "555"
};

var crmInterface = new CrmInterface(crmParams);
crmInterface.Start();

try
{
    // Look up customer by phone number
    var customer = await crmInterface.GetCustomer("5551234567");
    
    if (customer != null)
    {
        Console.WriteLine($"Found customer: {customer.Name}, ID: {customer.Id}");
        
        // Generate URL to open customer record
        string customerUrl = crmInterface.CreateOpenCustomerUrl(customer.Id);
        Console.WriteLine($"Customer URL: {customerUrl}");
        
        // Notify CRM of ringing call
        await crmInterface.OnCallRinging("101", "5551234567", long.Parse(customer.Id), false);
    }
    else
    {
        Console.WriteLine("Customer not found");
        
        // Generate URL to create new customer
        string newCustomerUrl = crmInterface.CreateNewCustomerUrl("5551234567");
        Console.WriteLine($"New customer URL: {newCustomerUrl}");
    }
}
finally
{
    crmInterface.Stop();
}
```

## Usage Scenarios

### Scenario 1: Inbound Call with Customer Identification

```csharp
// Initialize CRM interface
var crmParams = await repository.GetAsync<CrmParameters>();
var crmInterface = new CrmInterface(crmParams);
crmInterface.Start();

// Incoming call arrives
string incomingNumber = "5551234567";
string extId = "101";

try
{
    // Format the number if needed
    if (incomingNumber.StartsWith("0"))
    {
        incomingNumber = incomingNumber.Substring(1);
        if (!string.IsNullOrEmpty(crmParams.CountryCode))
        {
            incomingNumber = crmParams.CountryCode + incomingNumber;
        }
    }
    
    // Look up customer in CRM
    var customer = await crmInterface.GetCustomer(incomingNumber);
    
    if (customer != null)
    {
        // Customer found - store in call context
        callContext.Customer = new Customer
        {
            RemoteId = customer.Id,
            Name = customer.Name
        };
        
        // Add phone numbers to local database if they don't exist
        foreach (var phone in customer.Phones)
        {
            try
            {
                await repository.GetAsync<Phone>(phone);
            }
            catch
            {
                // Phone not found, add it
                callContext.Customer.AddPhone(new Phone { Id = phone });
            }
        }
        
        // Generate URL for screen pop
        callContext.CustomerUrl = crmInterface.CreateOpenCustomerUrl(customer.Id);
        
        // Notify CRM of ringing call
        await crmInterface.OnCallRinging(extId, incomingNumber, long.Parse(customer.Id), false);
        
        // Route call to appropriate agent based on customer data
        await RouteCallToAgent(callContext);
    }
    else
    {
        // No customer found - prepare for new customer creation
        callContext.CustomerUrl = crmInterface.CreateNewCustomerUrl(incomingNumber);
        
        // Route call to general queue
        await RouteCallToGeneralQueue(callContext);
    }
}
catch (Exception ex)
{
    Logger.LogError($"CRM lookup failed: {ex.Message}");
    
    // Route call without CRM data
    await RouteCallToGeneralQueue(callContext);
}
```

### Scenario 2: Call Completion and Logging

```csharp
// Call has ended, prepare call details for logging
var callRecord = new SubCallDb
{
    Id = 12345,
    Extension = await repository.GetAsync<Extension>("101"),
    ParentCall = await repository.GetAsync<CallDb>(5678),
    StartTime = DateTime.Now.AddMinutes(-5),
    EndTime = DateTime.Now,
    Number = "5551234567",
    Status = "Completed",
    Comment = "Customer inquired about new service options"
};

// Calculate duration
callRecord.Duration = (int)(callRecord.EndTime - callRecord.StartTime).TotalSeconds;

// Save call record to local database
await repository.AddAsync(callRecord);

// Get parent call details
var parentCall = callRecord.ParentCall;
var customer = parentCall.Customer;

// Log call to CRM if we have customer information
if (customer != null && !string.IsNullOrEmpty(customer.RemoteId))
{
    try
    {
        // Get recording file if available
        string recordingFile = null;
        var recording = await repository.GetAsync<Recording>(r => r.Call.Id == parentCall.Id);
        if (recording != null)
        {
            recordingFile = recording.FilePath;
        }
        
        // Create call info object
        var callInfo = new CrmCallInfo
        {
            ExtId = callRecord.Extension.Id,
            CallId = callRecord.Id.ToString(),
            Date = callRecord.StartTime,
            Number = callRecord.Number,
            CustomerId = customer.RemoteId,
            CustomerName = customer.Name,
            CallType = parentCall.Direction.ToString(),
            CallStatus = callRecord.Status,
            Duration = callRecord.Duration,
            IvrService = parentCall.IvrOrigin,
            RecordingFile = recordingFile
        };
        
        // Log call to CRM
        await crmInterface.OnCallAdded(callRecord);
        
        Logger.LogInformation($"Call {callRecord.Id} logged to CRM for customer {customer.Name}");
    }
    catch (Exception ex)
    {
        Logger.LogError($"Failed to log call to CRM: {ex.Message}");
    }
}
```

### Scenario 3: Outbound Call with CRM Integration

```csharp
// Agent initiates outbound call
string agentExtId = "101";
string customerNumber = "5551234567";
long customerId = 9876;

try
{
    // Notify CRM of outbound call
    await crmInterface.OnCallRinging(agentExtId, customerNumber, customerId, true);
    
    // Initiate the call through telephony system
    var channel = await telephonyClient.OriginateCall(agentExtId, customerNumber);
    
    // Create call context with CRM information
    var callContext = new CallContext
    {
        CallType = CallType.Outgoing,
        Date = DateTime.Now,
        Customer = await repository.GetAsync<Customer>(customerId),
        CustomerUrl = crmInterface.CreateOpenCustomerUrl(customerId.ToString())
    };
    
    // Associate call context with channel
    await workflowManager.AssociateCallContext(channel.Id, callContext);
    
    Logger.LogInformation($"Outbound call initiated to customer {customerId} from extension {agentExtId}");
}
catch (Exception ex)
{
    Logger.LogError($"Failed to initiate outbound call: {ex.Message}");
}
```

### Scenario 4: CRM Configuration Setup

```csharp
// Set up CRM integration configuration
async Task SetupCrmIntegration()
{
    try
    {
        // Check if CRM configuration exists
        CrmParameters crmParams;
        try
        {
            crmParams = await repository.GetAsync<CrmParameters>();
            Console.WriteLine("Existing CRM configuration found");
        }
        catch
        {
            // Create new configuration
            Console.WriteLine("Creating new CRM configuration");
            crmParams = new CrmParameters
            {
                IntegrationType = CrmIntegrationType.REST
            };
            await repository.AddAsync(crmParams);
        }
        
        // Update configuration with new values
        crmParams.GetRequestUrl = "https://crm.example.com/api/customer/{NUMBER}";
        crmParams.OpenCustomerUrl = "https://crm.example.com/customer/{CUSTOMERID}";
        crmParams.NewCustomerUrl = "https://crm.example.com/customer/new?phone={NUMBER}";
        crmParams.CallRingingUrl = "https://crm.example.com/api/call/ringing?ext={EXTID}&number={NUMBER}&id={CUSTOMERID}&type={CALLTYPE}";
        crmParams.CallAddedUrl = "https://crm.example.com/api/call/log";
        crmParams.GetResponseFormat = "{ID}#{NAME}#{PHONES}";
        crmParams.AuthorizationHeader = "ApiKey";
        crmParams.AuthorizationKey = "secret-api-key-123";
        crmParams.CountryCode = "+1";
        crmParams.LocalAreaCode = "555";
        
        // Save updated configuration
        await repository.UpdateAsync(crmParams);
        
        // Test the configuration
        var crmInterface = new CrmInterface(crmParams);
        crmInterface.Start();
        
        try
        {
            var testCustomer = await crmInterface.GetCustomer("5551234567");
            if (testCustomer != null)
            {
                Console.WriteLine($"CRM test successful. Found customer: {testCustomer.Name}");
            }
            else
            {
                Console.WriteLine("CRM test completed. No customer found for test number.");
            }
        }
        finally
        {
            crmInterface.Stop();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"CRM setup failed: {ex.Message}");
    }
}

// Run the setup
await SetupCrmIntegration();
```

## Best Practices

1. **Error Handling**:
   - Always handle network exceptions when communicating with external CRM systems
   - Implement retry logic for transient failures
   - Provide fallback behavior when CRM is unavailable

2. **Performance**:
   - Consider caching frequently accessed customer data
   - Use asynchronous methods for all network operations
   - Implement timeouts to prevent hanging on slow CRM responses

3. **Security**:
   - Store API keys and credentials securely
   - Use HTTPS for all CRM communications
   - Validate and sanitize data before sending to CRM systems

4. **Phone Number Handling**:
   - Normalize phone numbers to a consistent format
   - Handle international numbers appropriately
   - Consider local dialing patterns and area codes

5. **Integration Testing**:
   - Implement a test mode for CRM integration
   - Provide diagnostic tools for troubleshooting
   - Log all CRM interactions for audit purposes

## Conclusion

The Zenda.CrmIntegration module provides a flexible and robust bridge between the Zenda VoIP Call Manager and external CRM systems. By abstracting the complexities of CRM communication, it enables seamless integration of telephony and customer data management, enhancing both agent productivity and customer experience.

The module's design accommodates various CRM platforms and integration approaches, allowing organizations to leverage their existing CRM investments while gaining the benefits of integrated telephony. The standardized interface makes it easy to switch between different CRM systems or implement custom integrations as needed.

Key benefits of the CRM integration include:

1. **Enhanced Customer Experience**: Agents have immediate access to customer information during calls, enabling personalized service.

2. **Improved Efficiency**: Automatic customer identification and screen pops eliminate manual lookups, reducing call handling time.

3. **Complete Customer History**: Call records are automatically logged to the CRM, providing a comprehensive view of all customer interactions.

4. **Data Consistency**: Customer information is synchronized between systems, ensuring consistent data across platforms.

5. **Workflow Integration**: Call events can trigger CRM workflows, enabling automated follow-up actions and business processes.

By bridging the gap between telephony and customer relationship management, the Zenda.CrmIntegration module plays a crucial role in transforming the Zenda VoIP Call Manager from a communications system into a comprehensive customer engagement platform.

```csharp
void Start();
```

```csharp
void Stop();
```

```csharp
Task<CrmCustomer> GetCustomer(string number);
```

```csharp
string CreateOpenCustomerUrl(string id);
```

```csharp
string CreateNewCustomerUrl(string number);
```

```csharp
var customer = new CrmCustomer
{
    Id = "CRM123456",
    Name = "John Smith",
    Phones = new[] { "+1234567890", "+1987654321" }
};

Console.WriteLine($"Customer: {customer.Name}, ID: {customer.Id}");
foreach (var phone in customer.Phones)
{
    Console.WriteLine($"Phone: {phone}");
}
```

```csharp
var callInfo = new CrmCallInfo
{
    ExtId = "101",
    CallId = "CALL123456",
    Date = DateTime.Now,
    Number = "+1234567890",
    CustomerId = "CRM123456",
    CustomerName = "John Smith",
    CallType = "Incoming",
    CallStatus = "Answered",
    Duration = 120,
    IvrService = "Sales",
    RecordingFile = "/recordings/call_123456.mp3"
};

// Format the call info for logging
Console.WriteLine($"Call from {callInfo.CustomerName} ({callInfo.Number})");
Console.WriteLine($"Duration: {callInfo.Duration} seconds");
Console.WriteLine($"Handled by: Extension {callInfo.ExtId}, IVR: {callInfo.IvrService}");
```

```csharp
public CrmInterface(CrmParameters config)
```

```csharp
public void Start()
```

```csharp
public void Stop()
```

```csharp
public async Task<CrmCustomer> GetCustomer(string number)
```

```csharp
public string CreateOpenCustomerUrl(string id)
```

```csharp
public string CreateNewCustomerUrl(string number)
```

```csharp
public async Task OnCallAdded(SubCallDb scall)
```

```csharp
public async Task OnCallRinging(string extId, string number, long customerId, bool isSend)
```

```csharp
protected string AddAreaCode(string number)
```

```csharp
private CrmCustomer DeserializeCustomer(string data)
```

```csharp
private CrmCustomer DeserializeCustomerObject(string data)
```

```csharp
private CrmCustomer DeserializeCustomerString(string data)
```

```csharp
// Create CRM interface with configuration
var crmParams = new CrmParameters
{
    IntegrationType = CrmIntegrationType.REST,
    GetRequestUrl = "https://crm.example.com/api/customer/{NUMBER}",
    OpenCustomerUrl = "https://crm.example.com/customer/{CUSTOMERID}",
    NewCustomerUrl = "https://crm.example.com/customer/new?phone={NUMBER}",
    CallRingingUrl = "https://crm.example.com/api/call/ringing?ext={EXTID}&number={NUMBER}&id={CUSTOMERID}&type={CALLTYPE}",
    CallAddedUrl = "https://crm.example.com/api/call/log",
    AuthorizationHeader = "ApiKey",
    AuthorizationKey = "secret-api-key-123",
    CountryCode = "+1",
    LocalAreaCode = "555"
};

var crmInterface = new CrmInterface(crmParams);
crmInterface.Start();

try
{
    // Look up customer by phone number
    var customer = await crmInterface.GetCustomer("5551234567");
    
    if (customer != null)
    {
        Console.WriteLine($"Found customer: {customer.Name}, ID: {customer.Id}");
        
        // Generate URL to open customer record
        string customerUrl = crmInterface.CreateOpenCustomerUrl(customer.Id);
        Console.WriteLine($"Customer URL: {customerUrl}");
        
        // Notify CRM of ringing call
        await crmInterface.OnCallRinging("101", "5551234567", long.Parse(customer.Id), false);
    }
    else
    {
        Console.WriteLine("Customer not found");
        
        // Generate URL to create new customer
        string newCustomerUrl = crmInterface.CreateNewCustomerUrl("5551234567");
        Console.WriteLine($"New customer URL: {newCustomerUrl}");
    }
}
finally
{
    crmInterface.Stop();
}
```

```csharp
// Initialize CRM interface
var crmParams = await repository.GetAsync<CrmParameters>();
var crmInterface = new CrmInterface(crmParams);
crmInterface.Start();

// Incoming call arrives
string incomingNumber = "5551234567";
string extId = "101";

try
{
    // Format the number if needed
    if (incomingNumber.StartsWith("0"))
    {
        incomingNumber = incomingNumber.Substring(1);
        if (!string.IsNullOrEmpty(crmParams.CountryCode))
        {
            incomingNumber = crmParams.CountryCode + incomingNumber;
        }
    }
    
    // Look up customer in CRM
    var customer = await crmInterface.GetCustomer(incomingNumber);
    
    if (customer != null)
    {
        // Customer found - store in call context
        callContext.Customer = new Customer
        {
            RemoteId = customer.Id,
            Name = customer.Name
        };
        
        // Add phone numbers to local database if they don't exist
        foreach (var phone in customer.Phones)
        {
            try
            {
                await repository.GetAsync<Phone>(phone);
            }
            catch
            {
                // Phone not found, add it
                callContext.Customer.AddPhone(new Phone { Id = phone });
            }
        }
        
        // Generate URL for screen pop
        callContext.CustomerUrl = crmInterface.CreateOpenCustomerUrl(customer.Id);
        
        // Notify CRM of ringing call
        await crmInterface.OnCallRinging(extId, incomingNumber, long.Parse(customer.Id), false);
        
        // Route call to appropriate agent based on customer data
        await RouteCallToAgent(callContext);
    }
    else
    {
        // No customer found - prepare for new customer creation
        callContext.CustomerUrl = crmInterface.CreateNewCustomerUrl(incomingNumber);
        
        // Route call to general queue
        await RouteCallToGeneralQueue(callContext);
    }
}
catch (Exception ex)
{
    Logger.LogError($"CRM lookup failed: {ex.Message}");
    
    // Route call without CRM data
    await RouteCallToGeneralQueue(callContext);
}
```

```csharp
// Call has ended, prepare call details for logging
var callRecord = new SubCallDb
{
    Id = 12345,
    Extension = await repository.GetAsync<Extension>("101"),
    ParentCall = await repository.GetAsync<CallDb>(5678),
    StartTime = DateTime.Now.AddMinutes(-5),
    EndTime = DateTime.Now,
    Number = "5551234567",
    Status = "Completed",
    Comment = "Customer inquired about new service options"
};

// Calculate duration
callRecord.Duration = (int)(callRecord.EndTime - callRecord.StartTime).TotalSeconds;

// Save call record to local database
await repository.AddAsync(callRecord);

// Get parent call details
var parentCall = callRecord.ParentCall;
var customer = parentCall.Customer;

// Log call to CRM if we have customer information
if (customer != null && !string.IsNullOrEmpty(customer.RemoteId))
{
    try
    {
        // Get recording file if available
        string recordingFile = null;
        var recording = await repository.GetAsync<Recording>(r => r.Call.Id == parentCall.Id);
        if (recording != null)
        {
            recordingFile = recording.FilePath;
        }
        
        // Create call info object
        var callInfo = new CrmCallInfo
        {
            ExtId = callRecord.Extension.Id,
            CallId = callRecord.Id.ToString(),
            Date = callRecord.StartTime,
            Number = callRecord.Number,
            CustomerId = customer.RemoteId,
            CustomerName = customer.Name,
            CallType = parentCall.Direction.ToString(),
            CallStatus = callRecord.Status,
            Duration = callRecord.Duration,
            IvrService = parentCall.IvrOrigin,
            RecordingFile = recordingFile
        };
        
        // Log call to CRM
        await crmInterface.OnCallAdded(callRecord);
        
        Logger.LogInformation($"Call {callRecord.Id} logged to CRM for customer {customer.Name}");
    }
    catch (Exception ex)
    {
        Logger.LogError($"Failed to log call to CRM: {ex.Message}");
    }
}
```

```csharp
// Agent initiates outbound call
string agentExtId = "101";
string customerNumber = "5551234567";
long customerId = 9876;

try
{
    // Notify CRM of outbound call
    await crmInterface.OnCallRinging(agentExtId, customerNumber, customerId, true);
    
    // Initiate the call through telephony system
    var channel = await telephonyClient.OriginateCall(agentExtId, customerNumber);
    
    // Create call context with CRM information
    var callContext = new CallContext
    {
        CallType = CallType.Outgoing,
        Date = DateTime.Now,
        Customer = await repository.GetAsync<Customer>(customerId),
        CustomerUrl = crmInterface.CreateOpenCustomerUrl(customerId.ToString())
    };
    
    // Associate call context with channel
    await workflowManager.AssociateCallContext(channel.Id, callContext);
    
    Logger.LogInformation($"Outbound call initiated to customer {customerId} from extension {agentExtId}");
}
catch (Exception ex)
{
    Logger.LogError($"Failed to initiate outbound call: {ex.Message}");
}
```

```csharp
// Set up CRM integration configuration
async Task SetupCrmIntegration()
{
    try
    {
        // Check if CRM configuration exists
        CrmParameters crmParams;
        try
        {
            crmParams = await repository.GetAsync<CrmParameters>();
            Console.WriteLine("Existing CRM configuration found");
        }
        catch
        {
            // Create new configuration
            Console.WriteLine("Creating new CRM configuration");
            crmParams = new CrmParameters
            {
                IntegrationType = CrmIntegrationType.REST
            };
            await repository.AddAsync(crmParams);
        }
        
        // Update configuration with new values
        crmParams.GetRequestUrl = "https://crm.example.com/api/customer/{NUMBER}";
        crmParams.OpenCustomerUrl = "https://crm.example.com/customer/{CUSTOMERID}";
        crmParams.NewCustomerUrl = "https://crm.example.com/customer/new?phone={NUMBER}";
        crmParams.CallRingingUrl = "https://crm.example.com/api/call/ringing?ext={EXTID}&number={NUMBER}&id={CUSTOMERID}&type={CALLTYPE}";
        crmParams.CallAddedUrl = "https://crm.example.com/api/call/log";
        crmParams.GetResponseFormat = "{ID}#{NAME}#{PHONES}";
        crmParams.AuthorizationHeader = "ApiKey";
        crmParams.AuthorizationKey = "secret-api-key-123";
        crmParams.CountryCode = "+1";
        crmParams.LocalAreaCode = "555";
        
        // Save updated configuration
        await repository.UpdateAsync(crmParams);
        
        // Test the configuration
        var crmInterface = new CrmInterface(crmParams);
        crmInterface.Start();
        
        try
        {
            var testCustomer = await crmInterface.GetCustomer("5551234567");
            if (testCustomer != null)
            {
                Console.WriteLine($"CRM test successful. Found customer: {testCustomer.Name}");
            }
            else
            {
                Console.WriteLine("CRM test completed. No customer found for test number.");
            }
        }
        finally
        {
            crmInterface.Stop();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"CRM setup failed: {ex.Message}");
    }
}

// Run the setup
await SetupCrmIntegration();
```

---

**User**

please generate comprehensive documentation for the Zenda.DAL module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.DAL

## Overview

The Zenda.DAL (Data Access Layer) module serves as the foundation for database operations in the Zenda VoIP Call Manager system. It provides a robust abstraction layer between the application and the underlying database, implementing the repository pattern to encapsulate data access logic and provide a clean API for other modules. The DAL handles entity mapping, query generation, transaction management, and database configuration, enabling the rest of the application to interact with persistent data without being tightly coupled to specific database technologies or schemas.

## Features

1. **Repository Pattern**: Implements a generic repository pattern for consistent data access across the application.

2. **ORM Integration**: Leverages NHibernate as an Object-Relational Mapping (ORM) framework for entity persistence.

3. **Fluent Mappings**: Uses FluentNHibernate for code-first entity mappings, making schema evolution more manageable.

4. **Transaction Management**: Provides transaction handling for ensuring data consistency.

5. **Query Extensions**: Offers extension methods for building and executing complex queries.

6. **Reporting Framework**: Includes components for generating reports from database data.

7. **Configuration Management**: Handles database connection configuration and setup.

8. **Asterisk Configuration**: Provides utilities for synchronizing configuration with Asterisk.

9. **Mailing Integration**: Includes components for email operations related to database entities.

10. **Pagination Support**: Implements efficient data pagination for large result sets.

## Dependencies

- **.NET 8.0**: Core framework for the application
- **NHibernate**: ORM framework for database operations
- **FluentNHibernate**: Fluent mapping API for NHibernate
- **System.Data**: For database connectivity
- **Zenda.DAL.Common**: For shared entity definitions and interfaces
- **Zenda.Loging**: For logging database operations

## Data Flow

1. **Entity Definition**:
   - Entities are defined in Zenda.DAL.Common
   - Mappings are configured in Zenda.DAL.Mappings

2. **Repository Initialization**:
   - Database connection is established
   - Session factory is created
   - Repository instance is initialized

3. **Data Access Operations**:
   - Application code obtains a repository instance
   - CRUD operations are performed through repository methods
   - Repository translates operations to NHibernate calls
   - NHibernate executes SQL against the database
   - Results are mapped back to entity objects

4. **Transaction Flow**:
   - Transaction is started
   - Multiple operations are performed
   - Transaction is committed or rolled back

## Configuration

The DAL module can be configured through:

- **Connection String**: Database connection parameters
- **Mapping Configuration**: Entity-to-table mapping settings
- **Session Configuration**: NHibernate session behavior settings
- **Query Cache Settings**: Configuration for query caching
- **Dialect Settings**: Database-specific dialect configuration

## Core Classes and Functions

### Gen

#### Overview
A static class providing global utility functions and factory methods for database operations.

#### Properties
- **RepositoryFactory**: Gets the repository factory for creating repository instances
- **ConnectionString**: Gets the database connection string

#### Methods

##### InitDatabaseFactory
```csharp
public static async Task InitDatabaseFactory()
```
- **Returns**: A task representing the asynchronous operation
- **Description**: Initializes the database factory with default configuration

##### InitDatabaseFactory
```csharp
public static async Task InitDatabaseFactory(string connectionString)
```
- **connectionString**: The database connection string
- **Returns**: A task representing the asynchronous operation
- **Description**: Initializes the database factory with a specific connection string

##### GetFullExceptionMessage
```csharp
public static string GetFullExceptionMessage(Exception err)
```
- **err**: The exception to process
- **Returns**: A string containing the full exception message chain
- **Description**: Extracts the complete exception message including inner exceptions

#### Example
```csharp
// Initialize the database factory
await Gen.InitDatabaseFactory("Server=localhost;Database=zenda;User=zenda_user;Password=password;");

// Use the repository factory to get a repository instance
using var repository = Gen.RepositoryFactory.GetRepository();

// Perform database operations
var extension = await repository.GetAsync<Extension>("101");
Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");

// Handle exceptions with full message extraction
try
{
    await repository.UpdateAsync(extension);
}
catch (Exception ex)
{
    string fullMessage = Gen.GetFullExceptionMessage(ex);
    Console.WriteLine($"Error updating extension: {fullMessage}");
}
```

### IRepository

#### Overview
Interface defining the contract for repository implementations.

#### Methods

##### GetAsync<T>
```csharp
Task<T> GetAsync<T>(object id) where T : class
```
- **id**: The primary key of the entity
- **Returns**: The entity with the specified ID
- **Description**: Retrieves an entity by its primary key

##### GetAsync<T>
```csharp
Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
```
- **predicate**: A LINQ expression for filtering entities
- **Returns**: The first entity matching the predicate
- **Description**: Retrieves the first entity matching the specified condition

##### GetListAsync<T>
```csharp
Task<IList<T>> GetListAsync<T>() where T : class
```
- **Returns**: A list of all entities of type T
- **Description**: Retrieves all entities of the specified type

##### GetListAsync<T>
```csharp
Task<IList<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate) where T : class
```
- **predicate**: A LINQ expression for filtering entities
- **Returns**: A list of entities matching the predicate
- **Description**: Retrieves all entities matching the specified condition

##### AddAsync<T>
```csharp
Task<T> AddAsync<T>(T entity) where T : class
```
- **entity**: The entity to add
- **Returns**: The added entity
- **Description**: Adds a new entity to the database

##### UpdateAsync<T>
```csharp
Task UpdateAsync<T>(T entity) where T : class
```
- **entity**: The entity to update
- **Description**: Updates an existing entity in the database

##### DeleteAsync<T>
```csharp
Task DeleteAsync<T>(T entity) where T : class
```
- **entity**: The entity to delete
- **Description**: Deletes an entity from the database

##### QueryOver<T>
```csharp
IQueryOver<T, T> QueryOver<T>() where T : class
```
- **Returns**: A QueryOver instance for building complex queries
- **Description**: Creates a QueryOver query builder for the specified entity type

#### Example
```csharp
// Get a repository instance
using var repository = Gen.RepositoryFactory.GetRepository();

// Get an entity by ID
var extension = await repository.GetAsync<Extension>("101");

// Get an entity by condition
var activeExtension = await repository.GetAsync<Extension>(e => e.Active && e.Id == "101");

// Get a list of entities
var allExtensions = await repository.GetListAsync<Extension>();

// Get a filtered list
var activeExtensions = await repository.GetListAsync<Extension>(e => e.Active);

// Add a new entity
var newExtension = new Extension
{
    Id = "102",
    Name = "Sales",
    Active = true
};
await repository.AddAsync(newExtension);

// Update an entity
extension.Name = "Support";
await repository.UpdateAsync(extension);

// Delete an entity
await repository.DeleteAsync(extension);

// Use QueryOver for complex queries
var query = repository.QueryOver<Extension>()
    .Where(e => e.Active)
    .OrderBy(e => e.Name).Asc
    .Take(10);
var results = await query.ListAsync();
```

### RepositoryFactory

#### Overview
Factory class for creating repository instances.

#### Methods

##### GetRepository
```csharp
IRepository GetRepository()
```
- **Returns**: A new repository instance
- **Description**: Creates a new repository instance for database operations

##### GetRepository
```csharp
IRepository GetRepository(ISession session)
```
- **session**: An existing NHibernate session
- **Returns**: A repository instance using the provided session
- **Description**: Creates a repository instance with a specific NHibernate session

#### Example
```csharp
// Get a repository with a new session
using var repository = Gen.RepositoryFactory.GetRepository();

// Perform operations
var extensions = await repository.GetListAsync<Extension>();

// In some cases, you might want to share a session
using var session = Gen.RepositoryFactory.OpenSession();
using var repository1 = Gen.RepositoryFactory.GetRepository(session);
using var repository2 = Gen.RepositoryFactory.GetRepository(session);

// Both repositories will share the same transaction
await repository1.AddAsync(new Extension { Id = "103", Name = "Marketing" });
await repository2.AddAsync(new Extension { Id = "104", Name = "Finance" });
```

### Repository

#### Overview
Implementation of the IRepository interface using NHibernate.

#### Constructor
```csharp
public Repository(ISession session)
```
- **session**: The NHibernate session to use
- **Description**: Creates a new repository with the specified session

#### Methods
Implements all methods defined in the IRepository interface.

#### Additional Methods

##### BeginTransaction
```csharp
ITransaction BeginTransaction()
```
- **Returns**: A new transaction
- **Description**: Begins a new database transaction

##### CommitTransaction
```csharp
void CommitTransaction()
```
- **Description**: Commits the current transaction

##### RollbackTransaction
```csharp
void RollbackTransaction()
```
- **Description**: Rolls back the current transaction

#### Example
```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository() as Repository;

// Begin a transaction
var transaction = repository.BeginTransaction();

try
{
    // Perform multiple operations in a transaction
    var extension1 = new Extension { Id = "105", Name = "HR" };
    var extension2 = new Extension { Id = "106", Name = "IT" };
    
    await repository.AddAsync(extension1);
    await repository.AddAsync(extension2);
    
    // Commit the transaction
    repository.CommitTransaction();
}
catch (Exception ex)
{
    // Roll back on error
    repository.RollbackTransaction();
    Console.WriteLine($"Transaction failed: {ex.Message}");
}
```

### IQueryableExtension

#### Overview
Extension methods for IQueryable to enhance query capabilities.

#### Methods

##### Page<T>
```csharp
public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize)
```
- **query**: The query to paginate
- **page**: The page number (1-based)
- **pageSize**: The number of items per page
- **Returns**: A paginated query
- **Description**: Applies pagination to a query

##### SortBy<T>
```csharp
public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, string propertyName, bool ascending = true)
```
- **query**: The query to sort
- **propertyName**: The property name to sort by
- **ascending**: Whether to sort in ascending order
- **Returns**: A sorted query
- **Description**: Applies sorting to a query by property name

#### Example
```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a query
var query = repository.Query<Extension>().Where(e => e.Active);

// Apply pagination
var pagedQuery = query.Page(1, 10);

// Apply sorting
var sortedQuery = pagedQuery.SortBy("Name");

// Execute the query
var results = await sortedQuery.ToListAsync();

Console.WriteLine($"Found {results.Count} extensions on page 1");
foreach (var extension in results)
{
    Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");
}
```

### AstConfigHelper

#### Overview
Helper class for synchronizing configuration with Asterisk.

#### Methods

##### Sync
```csharp
public static async Task Sync(IRepository repository)
```
- **repository**: The repository to use for data access
- **Returns**: A task representing the asynchronous operation
- **Description**: Synchronizes database configuration with Asterisk configuration files

#### Example
```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Synchronize Asterisk configuration
try
{
    await AstConfigHelper.Sync(repository);
    Console.WriteLine("Asterisk configuration synchronized successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to synchronize Asterisk configuration: {ex.Message}");
}
```

## Mapping System

### Overview
The mapping system uses FluentNHibernate to define the relationship between entity classes and database tables.

### Key Components

#### ClassMap<T>
Base class for entity mappings.

#### Example Mapping
```csharp
public class ExtensionMap : ClassMap<Extension>
{
    public ExtensionMap()
    {
        Table("z_extensions");
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Active);
        Map(x => x.Version);
        References(x => x.CurrentEndPoint).Column("endpoint_id");
        HasMany(x => x.Features).KeyColumn("extension_id").Cascade.AllDeleteOrphan();
    }
}
```

### Mapping Configuration

#### Overview
Configuration for the mapping system is handled during database initialization.

#### Example
```csharp
// Configure mappings
var configuration = new Configuration();
configuration.AddProperties(new Dictionary<string, string>
{
    { "connection.connection_string", connectionString },
    { "connection.driver_class", "NHibernate.Driver.NpgsqlDriver" },
    { "dialect", "NHibernate.Dialect.PostgreSQL82Dialect" },
    { "show_sql", "true" }
});

// Add mappings
var mapper = new ModelMapper();
mapper.AddMappings(typeof(ExtensionMap).Assembly.GetExportedTypes());
configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

// Build session factory
var sessionFactory = configuration.BuildSessionFactory();
```

## Reporting Framework

### Overview
The reporting framework provides components for generating reports from database data.

### Key Components

#### ReportGenerator
Base class for report generators.

#### Example
```csharp
public class CallReportGenerator : ReportGenerator
{
    public CallReportGenerator(IRepository repository) : base(repository)
    {
    }
    
    public async Task<CallReport> GenerateReport(DateTime startDate, DateTime endDate)
    {
        var report = new CallReport();
        
        // Query calls within date range
        var calls = await Repository.GetListAsync<CallDb>(c => 
            c.StartTime >= startDate && c.StartTime <= endDate);
        
        // Process calls for the report
        report.TotalCalls = calls.Count;
        report.IncomingCalls = calls.Count(c => c.Direction == CallDirection.Incoming);
        report.OutgoingCalls = calls.Count(c => c.Direction == CallDirection.Outgoing);
        report.TotalDuration = calls.Sum(c => c.Duration);
        
        // Group by extension
        report.ExtensionStats = calls
            .GroupBy(c => c.Extension?.Id)
            .Select(g => new ExtensionStat
            {
                ExtensionId = g.Key,
                CallCount = g.Count(),
                TotalDuration = g.Sum(c => c.Duration)
            })
            .ToList();
        
        return report;
    }
}
```

### Usage Example
```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a report generator
var reportGenerator = new CallReportGenerator(repository);

// Generate a report
var startDate = new DateTime(2023, 1, 1);
var endDate = new DateTime(2023, 1, 31);
var report = await reportGenerator.GenerateReport(startDate, endDate);

// Display report results
Console.WriteLine($"Call Report: {startDate:d} to {endDate:d}");
Console.WriteLine($"Total Calls: {report.TotalCalls}");
Console.WriteLine($"Incoming Calls: {report.IncomingCalls}");
Console.WriteLine($"Outgoing Calls: {report.OutgoingCalls}");
Console.WriteLine($"Total Duration: {TimeSpan.FromSeconds(report.TotalDuration)}");

Console.WriteLine("\nExtension Statistics:");
foreach (var stat in report.ExtensionStats)
{
    Console.WriteLine($"Extension {stat.ExtensionId}: {stat.CallCount} calls, {TimeSpan.FromSeconds(stat.TotalDuration)}");
}
```

## Mailer Integration

### Overview
The Mailer namespace provides components for sending emails related to database entities.

### Key Components

#### MailSender
Class for sending emails.

#### Example
```csharp
public class NotificationMailer
{
    private readonly IRepository _repository;
    private readonly MailSender _mailSender;
    
    public NotificationMailer(IRepository repository, MailSender mailSender)
    {
        _repository = repository;
        _mailSender = mailSender;
    }
    
    public async Task SendMissedCallNotification(long callId)
    {
        // Get call details
        var call = await _repository.GetAsync<CallDb>(callId);
        var extension = call.Extension;
        
        if (extension?.User?.Email == null)
            return;
        
        // Prepare email content
        var subject = $"Missed Call Notification";
        var body = $@"
            <h2>Missed Call Notification</h2>
            <p>You missed a call from {call.Number} at {call.StartTime:g}.</p>
            <p>Call Duration: {TimeSpan.FromSeconds(call.Duration)}</p>
        ";
        
        // Send email
        await _mailSender.SendAsync(extension.User.Email, subject, body);
    }
}
```

### Usage Example
```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create mail sender
var mailConfig = await MailConfig.Get();
var mailSender = new MailSender(mailConfig);

// Create notification mailer
var notificationMailer = new NotificationMailer(repository, mailSender);

// Send notification for a missed call
await notificationMailer.SendMissedCallNotification(12345);
```

## Usage Scenarios

### Scenario 1: Basic CRUD Operations

```csharp
// Initialize the database
await Gen.InitDatabaseFactory();

// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a new extension
var extension = new Extension
{
    Id = "107",
    Name = "Reception",
    Active = true,
    CurrentEndPoint = new Ast_EndPoint { Id = "SIP/107" }
};

// Add the extension
await repository.AddAsync(extension);
Console.WriteLine($"Created extension: {extension.Id}");

// Retrieve the extension
var retrievedExtension = await repository.GetAsync<Extension>("107");
Console.WriteLine($"Retrieved extension: {retrievedExtension.Id}, Name: {retrievedExtension.Name}");

// Update the extension
retrievedExtension.Name = "Main Reception";
await repository.UpdateAsync(retrievedExtension);
Console.WriteLine($"Updated extension name to: {retrievedExtension.Name}");

// Delete the extension
await repository.DeleteAsync(retrievedExtension);
Console.WriteLine("Deleted extension");

// Verify deletion
try
{
    await repository.GetAsync<Extension>("107");
    Console.WriteLine("Extension still exists (unexpected)");
}
catch
{
    Console.WriteLine("Extension successfully deleted");
}
```

### Scenario 2: Complex Queries with Relationships

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Find all active extensions with their features
var query = repository.QueryOver<Extension>()
    .Where(e => e.Active)
    .Left.JoinAlias(e => e.Features, () => featureAlias)
    .Left.JoinAlias(e => e.CurrentEndPoint, () => endpointAlias)
    .OrderBy(e => e.Id).Asc;

var extensions = await query.ListAsync();

// Process results
foreach (var extension in extensions)
{
    Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");
    Console.WriteLine($"  Endpoint: {extension.CurrentEndPoint?.Id ?? "None"}");
    
    Console.WriteLine("  Features:");
    foreach (var feature in extension.Features)
    {
        Console.WriteLine($"    - {feature.Name}: {(feature.Enabled ? "Enabled" : "Disabled")}");
    }
    
    Console.WriteLine();
}

// Find all calls for a specific extension in the last 30 days
var extensionId = "101";
var startDate = DateTime.Now.AddDays(-30);
var endDate = DateTime.Now;

var callQuery = repository.QueryOver<CallDb>()
    .Where(c => c.Extension.Id == extensionId)
    .And(c => c.StartTime >= startDate)
    .And(c => c.StartTime <= endDate)
    .OrderBy(c => c.StartTime).Desc;

var calls = await callQuery.ListAsync();

Console.WriteLine($"Found {calls.Count} calls for extension {extensionId} in the last 30 days");
foreach (var call in calls.Take(10))
{
    Console.WriteLine($"Call ID: {call.Id}, Number: {call.Number}, Time: {call.StartTime}, Duration: {call.Duration}s");
}
```

### Scenario 3: Transaction Management

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository() as Repository;

// Begin a transaction
var transaction = repository.BeginTransaction();

try
{
    // Create a new queue
    var queue = new Queue
    {
        Id = "sales",
        Name = "Sales Queue",
        Strategy = QueueStrategy.RoundRobin,
        Timeout = 30,
        MaxWait = 300
    };
    
    await repository.AddAsync(queue);
    
    // Add members to the queue
    var member1 = new QueueMember
    {
        Queue = queue,
        Extension = await repository.GetAsync<Extension>("101"),
        Index = 1,
        IsActive = true
    };
    
    var member2 = new QueueMember
    {
        Queue = queue,
        Extension = await repository.GetAsync<Extension>("102"),
        Index = 2,
        IsActive = true
    };
    
    await repository.AddAsync(member1);
    await repository.AddAsync(member2);
    
    // Commit all changes in a single transaction
    repository.CommitTransaction();
    
    Console.WriteLine("Queue and members created successfully");
}
catch (Exception ex)
{
    // Roll back all changes if any operation fails
    repository.RollbackTransaction();
    Console.WriteLine($"Transaction failed: {ex.Message}");
}
```

### Scenario 4: Reporting

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Define report parameters
var startDate = DateTime.Now.Date.AddDays(-7);
var endDate = DateTime.Now.Date;

// Create a custom report query
var query = repository.QueryOver<CallDb>()
    .Where(c => c.StartTime >= startDate)
    .And(c => c.StartTime <= endDate)
    .Select(
        Projections.Group<CallDb>(c => c.Extension.Id),
        Projections.Count<CallDb>(c => c.Id),
        Projections.Sum<CallDb>(c => c.Duration),
        Projections.Avg<CallDb>(c => c.Duration)
    );

// Execute the query
var results = await query.ListAsync<object[]>();

// Process and display the report
Console.WriteLine($"Call Report: {startDate:d} to {endDate:d}");
Console.WriteLine("Extension | Call Count | Total Duration | Avg Duration");
Console.WriteLine("----------|------------|---------------|-------------");

foreach (var row in results)
{
    string extensionId = (string)row[0];
    long callCount = Convert.ToInt64(row[1]);
    long totalDuration = Convert.ToInt64(row[2]);
    double avgDuration = Convert.ToDouble(row[3]);
    
    Console.WriteLine($"{extensionId,-10} | {callCount,-11} | {TimeSpan.FromSeconds(totalDuration),-15} | {TimeSpan.FromSeconds(avgDuration),-13}");
}

// Save the report to the database
var reportRecord = new Report
{
    Name = "Weekly Call Summary",
    GeneratedDate = DateTime.Now,
    StartDate = startDate,
    EndDate = endDate,
    Type = ReportType.CallSummary
};

await repository.AddAsync(reportRecord);
Console.WriteLine($"Report saved with ID: {reportRecord.Id}");
```

### Scenario 5: Database Migration and Schema Updates

```csharp
// This example shows how to handle schema updates
// Note: Actual implementation would typically use a migration framework

async Task UpdateDatabaseSchema()
{
    // Get a repository
    using var repository = Gen.RepositoryFactory.GetRepository();
    
    // Check if we need to update the schema
    bool needsUpdate = false;
    
    try
    {
        // Try to access a column that might be added in the update
        var query = repository.QueryOver<Extension>()
            .Select(e => e.CallRecordingEnabled);
        
        await query.ListAsync<bool>();
    }
    catch
    {
        // Column doesn't exist, we need to update
        needsUpdate = true;
    }
    
    if (needsUpdate)
    {
        Console.WriteLine("Database schema needs to be updated");
        
        // In a real implementation, you would:
        // 1. Execute SQL ALTER TABLE statements
        // 2. Update the mappings
        // 3. Rebuild the session factory
        
        // Example SQL that would be executed:
        // ALTER TABLE z_extensions ADD COLUMN call_recording_enabled BOOLEAN NOT NULL DEFAULT FALSE;
        
        Console.WriteLine("Schema update completed");
    }
    else
    {
        Console.WriteLine("Database schema is up to date");
    }
}

// Run the schema update check
await UpdateDatabaseSchema();
```

## Best Practices

1. **Repository Usage**:
   - Always use the `using` statement with repositories to ensure proper disposal
   - Keep repository operations focused on a single unit of work
   - Use transactions for operations that modify multiple entities

2. **Query Optimization**:
   - Use projections to select only needed columns
   - Apply appropriate filters early in the query
   - Use pagination for large result sets
   - Consider caching for frequently accessed, rarely changing data

3. **Transaction Management**:
   - Keep transactions as short as possible
   - Handle transaction failures with appropriate rollback
   - Avoid nesting transactions when possible

4. **Error Handling**:
   - Catch and handle specific NHibernate exceptions
   - Log database errors with appropriate context
   - Provide meaningful error messages to higher layers

5. **Performance**:
   - Use batch operations for bulk updates
   - Monitor query performance
   - Optimize entity mappings for frequently accessed entities
   - Consider denormalization for reporting tables

## Conclusion

The Zenda.DAL module provides a robust and flexible data access layer for the Zenda VoIP Call Manager system. By implementing the repository pattern and leveraging NHibernate's ORM capabilities, it offers a clean and consistent API for database operations while abstracting away the complexities of direct database access.

The module's design emphasizes maintainability, performance, and flexibility, allowing the application to evolve without significant changes to data access code. Its comprehensive feature set, including advanced querying capabilities, transaction management, and reporting tools, provides a solid foundation for the entire application's data persistence needs.

Key benefits of the DAL module include:

1. **Abstraction**: Shields the application from database-specific details
2. **Consistency**: Provides a uniform approach to data access across the application
3. **Maintainability**: Centralizes data access logic for easier updates and bug fixes
4. **Flexibility**: Supports various query patterns and data operations
5. **Performance**: Enables optimization of database operations
6. **Scalability**: Facilitates database scaling through connection management and query optimization

By serving as the central point for all database interactions, the DAL module plays a crucial role in ensuring data integrity, performance, and reliability throughout the Zenda VoIP Call Manager system.

```csharp
public static async Task InitDatabaseFactory()
```

```csharp
public static async Task InitDatabaseFactory(string connectionString)
```

```csharp
public static string GetFullExceptionMessage(Exception err)
```

```csharp
// Initialize the database factory
await Gen.InitDatabaseFactory("Server=localhost;Database=zenda;User=zenda_user;Password=password;");

// Use the repository factory to get a repository instance
using var repository = Gen.RepositoryFactory.GetRepository();

// Perform database operations
var extension = await repository.GetAsync<Extension>("101");
Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");

// Handle exceptions with full message extraction
try
{
    await repository.UpdateAsync(extension);
}
catch (Exception ex)
{
    string fullMessage = Gen.GetFullExceptionMessage(ex);
    Console.WriteLine($"Error updating extension: {fullMessage}");
}
```

```csharp
Task<T> GetAsync<T>(object id) where T : class
```

```csharp
Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
```

```csharp
Task<IList<T>> GetListAsync<T>() where T : class
```

```csharp
Task<IList<T>> GetListAsync<T>(Expression<Func<T, bool>> predicate) where T : class
```

```csharp
Task<T> AddAsync<T>(T entity) where T : class
```

```csharp
Task UpdateAsync<T>(T entity) where T : class
```

```csharp
Task DeleteAsync<T>(T entity) where T : class
```

```csharp
IQueryOver<T, T> QueryOver<T>() where T : class
```

```csharp
// Get a repository instance
using var repository = Gen.RepositoryFactory.GetRepository();

// Get an entity by ID
var extension = await repository.GetAsync<Extension>("101");

// Get an entity by condition
var activeExtension = await repository.GetAsync<Extension>(e => e.Active && e.Id == "101");

// Get a list of entities
var allExtensions = await repository.GetListAsync<Extension>();

// Get a filtered list
var activeExtensions = await repository.GetListAsync<Extension>(e => e.Active);

// Add a new entity
var newExtension = new Extension
{
    Id = "102",
    Name = "Sales",
    Active = true
};
await repository.AddAsync(newExtension);

// Update an entity
extension.Name = "Support";
await repository.UpdateAsync(extension);

// Delete an entity
await repository.DeleteAsync(extension);

// Use QueryOver for complex queries
var query = repository.QueryOver<Extension>()
    .Where(e => e.Active)
    .OrderBy(e => e.Name).Asc
    .Take(10);
var results = await query.ListAsync();
```

```csharp
IRepository GetRepository()
```

```csharp
IRepository GetRepository(ISession session)
```

```csharp
// Get a repository with a new session
using var repository = Gen.RepositoryFactory.GetRepository();

// Perform operations
var extensions = await repository.GetListAsync<Extension>();

// In some cases, you might want to share a session
using var session = Gen.RepositoryFactory.OpenSession();
using var repository1 = Gen.RepositoryFactory.GetRepository(session);
using var repository2 = Gen.RepositoryFactory.GetRepository(session);

// Both repositories will share the same transaction
await repository1.AddAsync(new Extension { Id = "103", Name = "Marketing" });
await repository2.AddAsync(new Extension { Id = "104", Name = "Finance" });
```

```csharp
public Repository(ISession session)
```

```csharp
ITransaction BeginTransaction()
```

```csharp
void CommitTransaction()
```

```csharp
void RollbackTransaction()
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository() as Repository;

// Begin a transaction
var transaction = repository.BeginTransaction();

try
{
    // Perform multiple operations in a transaction
    var extension1 = new Extension { Id = "105", Name = "HR" };
    var extension2 = new Extension { Id = "106", Name = "IT" };
    
    await repository.AddAsync(extension1);
    await repository.AddAsync(extension2);
    
    // Commit the transaction
    repository.CommitTransaction();
}
catch (Exception ex)
{
    // Roll back on error
    repository.RollbackTransaction();
    Console.WriteLine($"Transaction failed: {ex.Message}");
}
```

```csharp
public static IQueryable<T> Page<T>(this IQueryable<T> query, int page, int pageSize)
```

```csharp
public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, string propertyName, bool ascending = true)
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a query
var query = repository.Query<Extension>().Where(e => e.Active);

// Apply pagination
var pagedQuery = query.Page(1, 10);

// Apply sorting
var sortedQuery = pagedQuery.SortBy("Name");

// Execute the query
var results = await sortedQuery.ToListAsync();

Console.WriteLine($"Found {results.Count} extensions on page 1");
foreach (var extension in results)
{
    Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");
}
```

```csharp
public static async Task Sync(IRepository repository)
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Synchronize Asterisk configuration
try
{
    await AstConfigHelper.Sync(repository);
    Console.WriteLine("Asterisk configuration synchronized successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to synchronize Asterisk configuration: {ex.Message}");
}
```

```csharp
public class ExtensionMap : ClassMap<Extension>
{
    public ExtensionMap()
    {
        Table("z_extensions");
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Active);
        Map(x => x.Version);
        References(x => x.CurrentEndPoint).Column("endpoint_id");
        HasMany(x => x.Features).KeyColumn("extension_id").Cascade.AllDeleteOrphan();
    }
}
```

```csharp
// Configure mappings
var configuration = new Configuration();
configuration.AddProperties(new Dictionary<string, string>
{
    { "connection.connection_string", connectionString },
    { "connection.driver_class", "NHibernate.Driver.NpgsqlDriver" },
    { "dialect", "NHibernate.Dialect.PostgreSQL82Dialect" },
    { "show_sql", "true" }
});

// Add mappings
var mapper = new ModelMapper();
mapper.AddMappings(typeof(ExtensionMap).Assembly.GetExportedTypes());
configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

// Build session factory
var sessionFactory = configuration.BuildSessionFactory();
```

```csharp
public class CallReportGenerator : ReportGenerator
{
    public CallReportGenerator(IRepository repository) : base(repository)
    {
    }
    
    public async Task<CallReport> GenerateReport(DateTime startDate, DateTime endDate)
    {
        var report = new CallReport();
        
        // Query calls within date range
        var calls = await Repository.GetListAsync<CallDb>(c => 
            c.StartTime >= startDate && c.StartTime <= endDate);
        
        // Process calls for the report
        report.TotalCalls = calls.Count;
        report.IncomingCalls = calls.Count(c => c.Direction == CallDirection.Incoming);
        report.OutgoingCalls = calls.Count(c => c.Direction == CallDirection.Outgoing);
        report.TotalDuration = calls.Sum(c => c.Duration);
        
        // Group by extension
        report.ExtensionStats = calls
            .GroupBy(c => c.Extension?.Id)
            .Select(g => new ExtensionStat
            {
                ExtensionId = g.Key,
                CallCount = g.Count(),
                TotalDuration = g.Sum(c => c.Duration)
            })
            .ToList();
        
        return report;
    }
}
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a report generator
var reportGenerator = new CallReportGenerator(repository);

// Generate a report
var startDate = new DateTime(2023, 1, 1);
var endDate = new DateTime(2023, 1, 31);
var report = await reportGenerator.GenerateReport(startDate, endDate);

// Display report results
Console.WriteLine($"Call Report: {startDate:d} to {endDate:d}");
Console.WriteLine($"Total Calls: {report.TotalCalls}");
Console.WriteLine($"Incoming Calls: {report.IncomingCalls}");
Console.WriteLine($"Outgoing Calls: {report.OutgoingCalls}");
Console.WriteLine($"Total Duration: {TimeSpan.FromSeconds(report.TotalDuration)}");

Console.WriteLine("\nExtension Statistics:");
foreach (var stat in report.ExtensionStats)
{
    Console.WriteLine($"Extension {stat.ExtensionId}: {stat.CallCount} calls, {TimeSpan.FromSeconds(stat.TotalDuration)}");
}
```

```csharp
public class NotificationMailer
{
    private readonly IRepository _repository;
    private readonly MailSender _mailSender;
    
    public NotificationMailer(IRepository repository, MailSender mailSender)
    {
        _repository = repository;
        _mailSender = mailSender;
    }
    
    public async Task SendMissedCallNotification(long callId)
    {
        // Get call details
        var call = await _repository.GetAsync<CallDb>(callId);
        var extension = call.Extension;
        
        if (extension?.User?.Email == null)
            return;
        
        // Prepare email content
        var subject = $"Missed Call Notification";
        var body = $@"
            <h2>Missed Call Notification</h2>
            <p>You missed a call from {call.Number} at {call.StartTime:g}.</p>
            <p>Call Duration: {TimeSpan.FromSeconds(call.Duration)}</p>
        ";
        
        // Send email
        await _mailSender.SendAsync(extension.User.Email, subject, body);
    }
}
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create mail sender
var mailConfig = await MailConfig.Get();
var mailSender = new MailSender(mailConfig);

// Create notification mailer
var notificationMailer = new NotificationMailer(repository, mailSender);

// Send notification for a missed call
await notificationMailer.SendMissedCallNotification(12345);
```

```csharp
// Initialize the database
await Gen.InitDatabaseFactory();

// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Create a new extension
var extension = new Extension
{
    Id = "107",
    Name = "Reception",
    Active = true,
    CurrentEndPoint = new Ast_EndPoint { Id = "SIP/107" }
};

// Add the extension
await repository.AddAsync(extension);
Console.WriteLine($"Created extension: {extension.Id}");

// Retrieve the extension
var retrievedExtension = await repository.GetAsync<Extension>("107");
Console.WriteLine($"Retrieved extension: {retrievedExtension.Id}, Name: {retrievedExtension.Name}");

// Update the extension
retrievedExtension.Name = "Main Reception";
await repository.UpdateAsync(retrievedExtension);
Console.WriteLine($"Updated extension name to: {retrievedExtension.Name}");

// Delete the extension
await repository.DeleteAsync(retrievedExtension);
Console.WriteLine("Deleted extension");

// Verify deletion
try
{
    await repository.GetAsync<Extension>("107");
    Console.WriteLine("Extension still exists (unexpected)");
}
catch
{
    Console.WriteLine("Extension successfully deleted");
}
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Find all active extensions with their features
var query = repository.QueryOver<Extension>()
    .Where(e => e.Active)
    .Left.JoinAlias(e => e.Features, () => featureAlias)
    .Left.JoinAlias(e => e.CurrentEndPoint, () => endpointAlias)
    .OrderBy(e => e.Id).Asc;

var extensions = await query.ListAsync();

// Process results
foreach (var extension in extensions)
{
    Console.WriteLine($"Extension: {extension.Id}, Name: {extension.Name}");
    Console.WriteLine($"  Endpoint: {extension.CurrentEndPoint?.Id ?? "None"}");
    
    Console.WriteLine("  Features:");
    foreach (var feature in extension.Features)
    {
        Console.WriteLine($"    - {feature.Name}: {(feature.Enabled ? "Enabled" : "Disabled")}");
    }
    
    Console.WriteLine();
}

// Find all calls for a specific extension in the last 30 days
var extensionId = "101";
var startDate = DateTime.Now.AddDays(-30);
var endDate = DateTime.Now;

var callQuery = repository.QueryOver<CallDb>()
    .Where(c => c.Extension.Id == extensionId)
    .And(c => c.StartTime >= startDate)
    .And(c => c.StartTime <= endDate)
    .OrderBy(c => c.StartTime).Desc;

var calls = await callQuery.ListAsync();

Console.WriteLine($"Found {calls.Count} calls for extension {extensionId} in the last 30 days");
foreach (var call in calls.Take(10))
{
    Console.WriteLine($"Call ID: {call.Id}, Number: {call.Number}, Time: {call.StartTime}, Duration: {call.Duration}s");
}
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository() as Repository;

// Begin a transaction
var transaction = repository.BeginTransaction();

try
{
    // Create a new queue
    var queue = new Queue
    {
        Id = "sales",
        Name = "Sales Queue",
        Strategy = QueueStrategy.RoundRobin,
        Timeout = 30,
        MaxWait = 300
    };
    
    await repository.AddAsync(queue);
    
    // Add members to the queue
    var member1 = new QueueMember
    {
        Queue = queue,
        Extension = await repository.GetAsync<Extension>("101"),
        Index = 1,
        IsActive = true
    };
    
    var member2 = new QueueMember
    {
        Queue = queue,
        Extension = await repository.GetAsync<Extension>("102"),
        Index = 2,
        IsActive = true
    };
    
    await repository.AddAsync(member1);
    await repository.AddAsync(member2);
    
    // Commit all changes in a single transaction
    repository.CommitTransaction();
    
    Console.WriteLine("Queue and members created successfully");
}
catch (Exception ex)
{
    // Roll back all changes if any operation fails
    repository.RollbackTransaction();
    Console.WriteLine($"Transaction failed: {ex.Message}");
}
```

```csharp
// Get a repository
using var repository = Gen.RepositoryFactory.GetRepository();

// Define report parameters
var startDate = DateTime.Now.Date.AddDays(-7);
var endDate = DateTime.Now.Date;

// Create a custom report query
var query = repository.QueryOver<CallDb>()
    .Where(c => c.StartTime >= startDate)
    .And(c => c.StartTime <= endDate)
    .Select(
        Projections.Group<CallDb>(c => c.Extension.Id),
        Projections.Count<CallDb>(c => c.Id),
        Projections.Sum<CallDb>(c => c.Duration),
        Projections.Avg<CallDb>(c => c.Duration)
    );

// Execute the query
var results = await query.ListAsync<object[]>();

// Process and display the report
Console.WriteLine($"Call Report: {startDate:d} to {endDate:d}");
Console.WriteLine("Extension | Call Count | Total Duration | Avg Duration");
Console.WriteLine("----------|------------|---------------|-------------");

foreach (var row in results)
{
    string extensionId = (string)row[0];
    long callCount = Convert.ToInt64(row[1]);
    long totalDuration = Convert.ToInt64(row[2]);
    double avgDuration = Convert.ToDouble(row[3]);
    
    Console.WriteLine($"{extensionId,-10} | {callCount,-11} | {TimeSpan.FromSeconds(totalDuration),-15} | {TimeSpan.FromSeconds(avgDuration),-13}");
}

// Save the report to the database
var reportRecord = new Report
{
    Name = "Weekly Call Summary",
    GeneratedDate = DateTime.Now,
    StartDate = startDate,
    EndDate = endDate,
    Type = ReportType.CallSummary
};

await repository.AddAsync(reportRecord);
Console.WriteLine($"Report saved with ID: {reportRecord.Id}");
```

```csharp
// This example shows how to handle schema updates
// Note: Actual implementation would typically use a migration framework

async Task UpdateDatabaseSchema()
{
    // Get a repository
    using var repository = Gen.RepositoryFactory.GetRepository();
    
    // Check if we need to update the schema
    bool needsUpdate = false;
    
    try
    {
        // Try to access a column that might be added in the update
        var query = repository.QueryOver<Extension>()
            .Select(e => e.CallRecordingEnabled);
        
        await query.ListAsync<bool>();
    }
    catch
    {
        // Column doesn't exist, we need to update
        needsUpdate = true;
    }
    
    if (needsUpdate)
    {
        Console.WriteLine("Database schema needs to be updated");
        
        // In a real implementation, you would:
        // 1. Execute SQL ALTER TABLE statements
        // 2. Update the mappings
        // 3. Rebuild the session factory
        
        // Example SQL that would be executed:
        // ALTER TABLE z_extensions ADD COLUMN call_recording_enabled BOOLEAN NOT NULL DEFAULT FALSE;
        
        Console.WriteLine("Schema update completed");
    }
    else
    {
        Console.WriteLine("Database schema is up to date");
    }
}

// Run the schema update check
await UpdateDatabaseSchema();
```

---

**User**

please generate comprehensive documentation for the Zenda.DAL.Common module in Zenda VoIP Call Manager project. Ensure that all functions are described in detail, including parameters, return values, and usage examples. Also, elaborate on the module's features, dependencies, data flow, configuration options, and provide relevant usage scenarios.

---

**Cursor**

# Module: Zenda.DAL.Common

## Overview

The Zenda.DAL.Common module serves as a shared library of data entities, enumerations, utility classes, and common data structures used throughout the Zenda VoIP Call Manager system. It provides the foundation for data modeling and defines the core business objects that represent the system's domain. By centralizing these definitions, the module ensures consistency across all components that interact with the data layer, while separating the entity definitions from the actual data access implementation in the Zenda.DAL module.

## Features

1. **Entity Definitions**: Provides class definitions for all database entities in the system.

2. **Enumeration Types**: Defines strongly-typed enumerations for various system states and options.

3. **Utility Functions**: Offers common utility methods for data manipulation and conversion.

4. **Printable Models**: Contains models designed for report generation and printing.

5. **Network Configuration**: Includes YAML-based network configuration models.

6. **Factory Interfaces**: Defines interfaces for factory patterns used in data access.

7. **Reporting Structures**: Provides base classes and interfaces for the reporting system.

8. **Common Classes**: Contains shared classes used across multiple system components.

## Dependencies

- **.NET 8.0**: Core framework for the application
- **YamlDotNet**: For YAML serialization/deserialization
- **System.ComponentModel.DataAnnotations**: For data validation attributes
- **System.Text.Json**: For JSON serialization/deserialization

## Data Flow

The Zenda.DAL.Common module primarily serves as a definition layer rather than implementing complex data flows. Its typical usage patterns include:

1. **Entity Definition and Usage**:
   - Entities are defined in Zenda.DAL.Common
   - Other modules reference these entities for data operations
   - Zenda.DAL implements the persistence of these entities

2. **Enumeration Usage**:
   - Enumerations define possible values for entity properties
   - Application code uses these enumerations for type-safe operations
   - UI components may display human-readable versions of enumeration values

3. **Utility Function Usage**:
   - Common utility functions are called from various application components
   - Results are used for data manipulation or display

## Core Components

### Entity Base Classes

#### Entity<T>

#### Overview
Base class for all entities with a specific ID type.

#### Properties
- **Id**: Gets or sets the entity's identifier
- **Version**: Gets or sets the entity's version for optimistic concurrency

#### Example
```csharp
// Define a custom entity
public class Customer : Entity<long>
{
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual bool Active { get; set; }
}

// Use the entity
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    Email = "contact@acme.com",
    Active = true
};

Console.WriteLine($"Customer: {customer.Id}, {customer.Name}");
```

#### VersionedEntity

#### Overview
Base class for entities that require versioning.

#### Properties
- Inherits from Entity<T>
- **CreatedBy**: Gets or sets who created the entity
- **CreatedDate**: Gets or sets when the entity was created
- **ModifiedBy**: Gets or sets who last modified the entity
- **ModifiedDate**: Gets or sets when the entity was last modified

#### Example
```csharp
// Define a versioned entity
public class Document : VersionedEntity<long>
{
    public virtual string Title { get; set; }
    public virtual string Content { get; set; }
}

// Use the entity
var document = new Document
{
    Id = 1,
    Title = "System Manual",
    Content = "This is the system manual content...",
    CreatedBy = "admin",
    CreatedDate = DateTime.Now,
    ModifiedBy = "admin",
    ModifiedDate = DateTime.Now
};

Console.WriteLine($"Document: {document.Id}, {document.Title}");
Console.WriteLine($"Created: {document.CreatedDate} by {document.CreatedBy}");
```

### Key Entity Types

#### Extension

#### Overview
Represents a phone extension in the system.

#### Properties
- **Id**: Gets or sets the extension number
- **Name**: Gets or sets the extension name
- **Active**: Gets or sets whether the extension is active
- **CurrentEndPoint**: Gets or sets the associated endpoint
- **Features**: Gets or sets the extension features
- **User**: Gets or sets the associated user

#### Example
```csharp
// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Reception",
    Active = true,
    CurrentEndPoint = new Ast_EndPoint { Id = "SIP/101" }
};

// Add features to the extension
extension.Features.Add(new ExtFeature 
{ 
    Extension = extension,
    CallWait = true,
    VoiceMail = true
});

Console.WriteLine($"Extension: {extension.Id}, {extension.Name}");
Console.WriteLine($"Endpoint: {extension.CurrentEndPoint.Id}");
Console.WriteLine($"Has voicemail: {extension.Features.First().VoiceMail}");
```

#### CallDb

#### Overview
Represents a call record in the system.

#### Properties
- **Id**: Gets or sets the call ID
- **Direction**: Gets or sets the call direction (Incoming, Outgoing, Internal)
- **Number**: Gets or sets the phone number
- **StartTime**: Gets or sets when the call started
- **EndTime**: Gets or sets when the call ended
- **Duration**: Gets or sets the call duration in seconds
- **Status**: Gets or sets the call status
- **Customer**: Gets or sets the associated customer
- **Extension**: Gets or sets the associated extension

#### Example
```csharp
// Create a call record
var call = new CallDb
{
    Id = 12345,
    Direction = CallDirection.Incoming,
    Number = "5551234567",
    StartTime = DateTime.Now.AddMinutes(-5),
    EndTime = DateTime.Now,
    Status = "Completed",
    Customer = new Customer { Id = 1, Name = "John Smith" },
    Extension = new Extension { Id = "101", Name = "Reception" }
};

// Calculate duration
call.Duration = (int)(call.EndTime - call.StartTime).TotalSeconds;

Console.WriteLine($"Call: {call.Id}, Direction: {call.Direction}");
Console.WriteLine($"From/To: {call.Number}, Duration: {call.Duration} seconds");
Console.WriteLine($"Handled by: Extension {call.Extension.Id}");
```

#### Queue

#### Overview
Represents a call queue in the system.

#### Properties
- **Id**: Gets or sets the queue ID
- **Name**: Gets or sets the queue name
- **Strategy**: Gets or sets the queue strategy (RoundRobin, LeastRecent, etc.)
- **Timeout**: Gets or sets the ring timeout in seconds
- **MaxWait**: Gets or sets the maximum wait time in seconds
- **Members**: Gets or sets the queue members (extensions)

#### Example
```csharp
// Create a queue
var queue = new Queue
{
    Id = "sales",
    Name = "Sales Queue",
    Strategy = QueueStrategy.RoundRobin,
    Timeout = 30,
    MaxWait = 300
};

// Add members to the queue
queue.Members.Add(new QueueMember 
{ 
    Queue = queue,
    Extension = new Extension { Id = "101", Name = "Sales 1" },
    Index = 1,
    IsActive = true
});

queue.Members.Add(new QueueMember 
{ 
    Queue = queue,
    Extension = new Extension { Id = "102", Name = "Sales 2" },
    Index = 2,
    IsActive = true
});

Console.WriteLine($"Queue: {queue.Id}, {queue.Name}");
Console.WriteLine($"Strategy: {queue.Strategy}, Timeout: {queue.Timeout}s");
Console.WriteLine($"Members: {queue.Members.Count}");
```

#### Customer

#### Overview
Represents a customer in the system.

#### Properties
- **Id**: Gets or sets the customer ID
- **Name**: Gets or sets the customer name
- **RemoteId**: Gets or sets the ID in an external CRM system
- **Phones**: Gets or sets the customer's phone numbers
- **Creator**: Gets or sets who created the customer record

#### Methods

##### AddPhone
```csharp
public virtual void AddPhone(Phone phone)
```
- **phone**: The phone number to add
- **Description**: Adds a phone number to the customer

#### Example
```csharp
// Create a customer
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    RemoteId = "CRM12345",
    Creator = new Extension { Id = "101", Name = "Reception" }
};

// Add phone numbers
customer.AddPhone(new Phone { Id = "5551234567" });
customer.AddPhone(new Phone { Id = "5559876543" });

Console.WriteLine($"Customer: {customer.Id}, {customer.Name}");
Console.WriteLine($"CRM ID: {customer.RemoteId}");
Console.WriteLine("Phone numbers:");
foreach (var phone in customer.Phones)
{
    Console.WriteLine($"  - {phone.Id}");
}
```

### Enumerations

#### CallDirection

#### Overview
Defines the possible directions for a call.

#### Values
- **Incoming**: Call from outside to the system
- **Outgoing**: Call from the system to outside
- **Internal**: Call between two extensions within the system

#### Example
```csharp
// Use the enumeration
var call = new CallDb
{
    Direction = CallDirection.Incoming,
    // Other properties...
};

// Check call direction
if (call.Direction == CallDirection.Incoming)
{
    Console.WriteLine("This is an incoming call");
}
```

#### QueueStrategy

#### Overview
Defines the possible strategies for distributing calls in a queue.

#### Values
- **RoundRobin**: Distributes calls evenly among agents
- **LeastRecent**: Routes to the agent who has been idle the longest
- **FewestCalls**: Routes to the agent who has taken the fewest calls
- **Random**: Randomly selects an agent
- **RingAll**: Rings all available agents simultaneously
- **Linear**: Rings agents in a fixed order

#### Example
```csharp
// Use the enumeration
var queue = new Queue
{
    Strategy = QueueStrategy.RoundRobin,
    // Other properties...
};

// Apply different logic based on strategy
switch (queue.Strategy)
{
    case QueueStrategy.RoundRobin:
        Console.WriteLine("Using round-robin distribution");
        break;
    case QueueStrategy.LeastRecent:
        Console.WriteLine("Routing to least recently used agent");
        break;
    case QueueStrategy.RingAll:
        Console.WriteLine("Ringing all available agents");
        break;
}
```

#### CrmIntegrationType

#### Overview
Defines the possible CRM integration types.

#### Values
- **None**: No CRM integration
- **REST**: REST API integration
- **Webhook**: Webhook-based integration
- **Custom**: Custom integration type

#### Example
```csharp
// Use the enumeration
var crmParams = new CrmParameters
{
    IntegrationType = CrmIntegrationType.REST,
    // Other properties...
};

// Check integration type
if (crmParams.IntegrationType != CrmIntegrationType.None)
{
    Console.WriteLine($"CRM integration is enabled: {crmParams.IntegrationType}");
}
```

### Utility Classes

#### Utilities

#### Overview
Static class providing various utility methods for data manipulation.

#### Methods

##### FormatPhoneNumber
```csharp
public static string FormatPhoneNumber(string number, string format = null)
```
- **number**: The phone number to format
- **format**: Optional format string
- **Returns**: The formatted phone number
- **Description**: Formats a phone number according to the specified format

##### ParseTimeSpan
```csharp
public static TimeSpan ParseTimeSpan(string value)
```
- **value**: The string to parse
- **Returns**: The parsed TimeSpan
- **Description**: Parses a string into a TimeSpan

##### FormatTimeSpan
```csharp
public static string FormatTimeSpan(TimeSpan span)
```
- **span**: The TimeSpan to format
- **Returns**: The formatted string
- **Description**: Formats a TimeSpan as a readable string

##### GetRandomString
```csharp
public static string GetRandomString(int length)
```
- **length**: The desired string length
- **Returns**: A random string
- **Description**: Generates a random alphanumeric string

#### Example
```csharp
// Format a phone number
string rawNumber = "5551234567";
string formattedNumber = Utilities.FormatPhoneNumber(rawNumber, "(###) ###-####");
Console.WriteLine($"Formatted number: {formattedNumber}"); // (555) 123-4567

// Parse a time string
TimeSpan duration = Utilities.ParseTimeSpan("1:30:45");
Console.WriteLine($"Duration: {duration.Hours}h {duration.Minutes}m {duration.Seconds}s");

// Format a TimeSpan
string readableDuration = Utilities.FormatTimeSpan(TimeSpan.FromSeconds(3725));
Console.WriteLine($"Readable duration: {readableDuration}"); // 1h 2m 5s

// Generate a random string
string randomString = Utilities.GetRandomString(8);
Console.WriteLine($"Random string: {randomString}");
```

### YamlNetwork

#### Overview
Class for handling YAML-based network configuration.

#### Properties
- **Interfaces**: Gets or sets the network interfaces
- **Routes**: Gets or sets the network routes
- **Nameservers**: Gets or sets the DNS nameservers

#### Methods

##### Load
```csharp
public static YamlNetwork Load(string filename)
```
- **filename**: Path to the YAML file
- **Returns**: The loaded network configuration
- **Description**: Loads network configuration from a YAML file

##### Save
```csharp
public void Save(string filename)
```
- **filename**: Path to save the YAML file
- **Description**: Saves network configuration to a YAML file

#### Example
```csharp
// Load network configuration
var network = YamlNetwork.Load("/etc/netplan/01-netcfg.yaml");

// Display current configuration
Console.WriteLine("Network Interfaces:");
foreach (var iface in network.Interfaces)
{
    Console.WriteLine($"  {iface.Name}: {iface.Address}/{iface.Prefix}");
    Console.WriteLine($"    DHCP: {iface.Dhcp}, Gateway: {iface.Gateway}");
}

Console.WriteLine("DNS Servers:");
foreach (var dns in network.Nameservers)
{
    Console.WriteLine($"  {dns}");
}

// Modify configuration
var eth0 = network.Interfaces.FirstOrDefault(i => i.Name == "eth0");
if (eth0 != null)
{
    eth0.Address = "192.168.1.100";
    eth0.Prefix = 24;
    eth0.Gateway = "192.168.1.1";
    eth0.Dhcp = false;
}

// Add a DNS server
network.Nameservers.Add("8.8.8.8");

// Save configuration
network.Save("/etc/netplan/01-netcfg.yaml");
```

### Printable Models

#### Overview
The Printables namespace contains models designed for report generation and printing.

#### Example: CallReportItem

#### Properties
- **Id**: Gets or sets the call ID
- **Date**: Gets or sets the call date
- **Number**: Gets or sets the phone number
- **Direction**: Gets or sets the call direction
- **Duration**: Gets or sets the call duration
- **Status**: Gets or sets the call status
- **Extension**: Gets or sets the extension
- **CustomerName**: Gets or sets the customer name

#### Example
```csharp
// Create a call report item
var reportItem = new CallReportItem
{
    Id = 12345,
    Date = DateTime.Now.AddHours(-2),
    Number = "5551234567",
    Direction = "Incoming",
    Duration = 125,
    Status = "Completed",
    Extension = "101",
    CustomerName = "John Smith"
};

// Format for display
Console.WriteLine($"Call #{reportItem.Id} - {reportItem.Date:g}");
Console.WriteLine($"{reportItem.Direction} call from {reportItem.Number} ({reportItem.CustomerName})");
Console.WriteLine($"Handled by extension {reportItem.Extension}");
Console.WriteLine($"Duration: {TimeSpan.FromSeconds(reportItem.Duration)}, Status: {reportItem.Status}");
```

### Factory Interfaces

#### IRepository

#### Overview
Interface defining the contract for repository implementations.

#### Methods

##### GetAsync<T>
```csharp
Task<T> GetAsync<T>(object id) where T : class
```
- **id**: The primary key of the entity
- **Returns**: The entity with the specified ID
- **Description**: Retrieves an entity by its primary key

##### GetListAsync<T>
```csharp
Task<IList<T>> GetListAsync<T>() where T : class
```
- **Returns**: A list of all entities of type T
- **Description**: Retrieves all entities of the specified type

##### AddAsync<T>
```csharp
Task<T> AddAsync<T>(T entity) where T : class
```
- **entity**: The entity to add
- **Returns**: The added entity
- **Description**: Adds a new entity to the database

##### UpdateAsync<T>
```csharp
Task UpdateAsync<T>(T entity) where T : class
```
- **entity**: The entity to update
- **Description**: Updates an existing entity in the database

##### DeleteAsync<T>
```csharp
Task DeleteAsync<T>(T entity) where T : class
```
- **entity**: The entity to delete
- **Description**: Deletes an entity from the database

#### Example
```csharp
// This is an interface definition, so we'll show how it would be used
// The actual implementation would be in the Zenda.DAL module

// Hypothetical usage:
public class CustomerService
{
    private readonly IRepository _repository;
    
    public CustomerService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Customer> GetCustomer(long id)
    {
        return await _repository.GetAsync<Customer>(id);
    }
    
    public async Task<IList<Customer>> GetAllCustomers()
    {
        return await _repository.GetListAsync<Customer>();
    }
    
    public async Task<Customer> CreateCustomer(Customer customer)
    {
        return await _repository.AddAsync(customer);
    }
    
    public async Task UpdateCustomer(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }
    
    public async Task DeleteCustomer(Customer customer)
    {
        await _repository.DeleteAsync(customer);
    }
}
```

### Reporting Structures

#### ReportSchema

#### Overview
Base class for report schema definitions.

#### Properties
- **Page**: Gets or sets the current page
- **PageSize**: Gets or sets the page size
- **SortBy**: Gets or sets the sort field
- **SortAscending**: Gets or sets whether sorting is ascending

#### Example
```csharp
// Define a custom report schema
public class CallReportSchema : ReportSchema
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ExtensionId { get; set; }
    public string Direction { get; set; }
    public string Status { get; set; }
}

// Use the schema
var schema = new CallReportSchema
{
    StartDate = DateTime.Now.AddDays(-7),
    EndDate = DateTime.Now,
    ExtensionId = "101",
    Direction = "Incoming",
    Page = 1,
    PageSize = 25,
    SortBy = "Date",
    SortAscending = false
};

Console.WriteLine($"Report period: {schema.StartDate:d} to {schema.EndDate:d}");
Console.WriteLine($"Filtering by: Extension {schema.ExtensionId}, {schema.Direction} calls");
Console.WriteLine($"Page {schema.Page}, {schema.PageSize} items per page");
Console.WriteLine($"Sorted by {schema.SortBy} {(schema.SortAscending ? "ascending" : "descending")}");
```

#### ReportResult<T>

#### Overview
Generic class for report results.

#### Properties
- **Data**: Gets or sets the report data
- **TotalCount**: Gets or sets the total count of items
- **PageCount**: Gets or sets the total number of pages

#### Example
```csharp
// Create a report result
var reportItems = new List<CallReportItem>
{
    new CallReportItem { Id = 1, Number = "5551234567", Duration = 120 },
    new CallReportItem { Id = 2, Number = "5559876543", Duration = 45 }
};

var reportResult = new ReportResult<CallReportItem>
{
    Data = reportItems,
    TotalCount = 150,
    PageCount = 6 // 150 items / 25 items per page
};

Console.WriteLine($"Showing {reportResult.Data.Count} of {reportResult.TotalCount} total items");
Console.WriteLine($"Page 1 of {reportResult.PageCount}");

foreach (var item in reportResult.Data)
{
    Console.WriteLine($"Call #{item.Id}: {item.Number}, Duration: {item.Duration}s");
}
```

## Usage Scenarios

### Scenario 1: Working with Extensions and Features

```csharp
// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Sales Department",
    Active = true
};

// Create an endpoint for the extension
var endpoint = new Ast_EndPoint
{
    Id = "SIP/101",
    Type = "SIP",
    Context = "default"
};
extension.CurrentEndPoint = endpoint;

// Add features to the extension
var features = new ExtFeature
{
    Extension = extension,
    CallWait = true,
    VoiceMail = true,
    CallRecording = true,
    CallForwarding = false
};
extension.Features.Add(features);

// Create a user for the extension
var user = new User
{
    Id = "sales_user",
    Name = "Sales User",
    Email = "sales@example.com",
    Extension = extension
};
extension.User = user;

// Display extension information
Console.WriteLine($"Extension: {extension.Id} - {extension.Name}");
Console.WriteLine($"Status: {(extension.Active ? "Active" : "Inactive")}");
Console.WriteLine($"Endpoint: {extension.CurrentEndPoint.Id} ({extension.CurrentEndPoint.Type})");
Console.WriteLine("Features:");
Console.WriteLine($"  Call Waiting: {extension.Features.First().CallWait}");
Console.WriteLine($"  Voicemail: {extension.Features.First().VoiceMail}");
Console.WriteLine($"  Call Recording: {extension.Features.First().CallRecording}");
Console.WriteLine($"  Call Forwarding: {extension.Features.First().CallForwarding}");
Console.WriteLine($"User: {extension.User.Name} ({extension.User.Email})");
```

### Scenario 2: Call Records and Reporting

```csharp
// Create a customer
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    RemoteId = "CRM12345"
};

// Add phone numbers to the customer
customer.AddPhone(new Phone { Id = "5551234567" });
customer.AddPhone(new Phone { Id = "5559876543" });

// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Support",
    Active = true
};

// Create call records
var call1 = new CallDb
{
    Id = 1001,
    Direction = CallDirection.Incoming,
    Number = "5551234567",
    StartTime = DateTime.Now.AddHours(-2),
    EndTime = DateTime.Now.AddHours(-1).AddMinutes(-45),
    Status = "Completed",
    Customer = customer,
    Extension = extension
};
call1.Duration = (int)(call1.EndTime - call1.StartTime).TotalSeconds;

var call2 = new CallDb
{
    Id = 1002,
    Direction = CallDirection.Outgoing,
    Number = "5559876543",
    StartTime = DateTime.Now.AddHours(-1),
    EndTime = DateTime.Now.AddMinutes(-30),
    Status = "Completed",
    Customer = customer,
    Extension = extension
};
call2.Duration = (int)(call2.EndTime - call2.StartTime).TotalSeconds;

// Create a list of calls
var calls = new List<CallDb> { call1, call2 };

// Create printable report items
var reportItems = calls.Select(c => new CallReportItem
{
    Id = c.Id,
    Date = c.StartTime,
    Number = c.Number,
    Direction = c.Direction.ToString(),
    Duration = c.Duration,
    Status = c.Status,
    Extension = c.Extension.Id,
    CustomerName = c.Customer.Name
}).ToList();

// Create a report result
var reportResult = new ReportResult<CallReportItem>
{
    Data = reportItems,
    TotalCount = reportItems.Count,
    PageCount = 1
};

// Display the report
Console.WriteLine("Call Report");
Console.WriteLine("==========");
Console.WriteLine($"Total Calls: {reportResult.TotalCount}");
Console.WriteLine();
Console.WriteLine("ID    | Date                | Number      | Direction | Duration | Status    | Extension | Customer");
Console.WriteLine("------|---------------------|-------------|-----------|----------|-----------|-----------|----------");

foreach (var item in reportResult.Data)
{
    Console.WriteLine($"{item.Id,-5} | {item.Date,-20:g} | {item.Number,-11} | {item.Direction,-9} | {item.Duration,-8} | {item.Status,-9} | {item.Extension,-9} | {item.CustomerName}");
}

// Calculate statistics
int totalDuration = reportItems.Sum(i => i.Duration);
int avgDuration = reportItems.Average(i => i.Duration).ToInt();
int incomingCount = reportItems.Count(i => i.Direction == CallDirection.Incoming.ToString());
int outgoingCount = reportItems.Count(i => i.Direction == CallDirection.Outgoing.ToString());

Console.WriteLine();
Console.WriteLine("Statistics:");
Console.WriteLine($"Total Duration: {TimeSpan.FromSeconds(totalDuration)}");
Console.WriteLine($"Average Duration: {TimeSpan.FromSeconds(avgDuration)}");
Console.WriteLine($"Incoming Calls: {incomingCount}");
Console.WriteLine($"Outgoing Calls: {outgoingCount}");
```

### Scenario 3: Queue Configuration

```csharp
// Create a queue
var queue = new Queue
{
    Id = "support",
    Name = "Support Queue",
    Strategy = QueueStrategy.RoundRobin,
    Timeout = 30,
    MaxWait = 300,
    WelcomePrompt = "welcome",
    MohClass = "default"
};

// Create extensions for queue members
var extension1 = new Extension { Id = "101", Name = "Support 1", Active = true };
var extension2 = new Extension { Id = "102", Name = "Support 2", Active = true };
var extension3 = new Extension { Id = "103", Name = "Support 3", Active = false };

// Add members to the queue
queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension1,
    Index = 1,
    IsActive = true
});

queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension2,
    Index = 2,
    IsActive = true
});

queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension3,
    Index = 3,
    IsActive = false
});

// Display queue configuration
Console.WriteLine($"Queue: {queue.Id} - {queue.Name}");
Console.WriteLine($"Strategy: {queue.Strategy}");
Console.WriteLine($"Timeout: {queue.Timeout} seconds");
Console.WriteLine($"Maximum Wait Time: {queue.MaxWait} seconds");
Console.WriteLine($"Welcome Prompt: {queue.WelcomePrompt}");
Console.WriteLine($"Music on Hold: {queue.MohClass}");
Console.WriteLine();
Console.WriteLine("Queue Members:");
Console.WriteLine("Index | Extension | Name      | Status");
Console.WriteLine("------|-----------|-----------|-------");

foreach (var member in queue.Members.OrderBy(m => m.Index))
{
    string status = member.IsActive && member.Extension.Active ? "Active" : "Inactive";
    Console.WriteLine($"{member.Index,-5} | {member.Extension.Id,-9} | {member.Extension.Name,-10} | {status}");
}

// Calculate active members
int activeMembers = queue.Members.Count(m => m.IsActive && m.Extension.Active);
Console.WriteLine();
Console.WriteLine($"Active Members: {activeMembers} of {queue.Members.Count}");
```

### Scenario 4: Network Configuration with YamlNetwork

```csharp
// Create a network configuration
var network = new YamlNetwork();

// Add network interfaces
network.Interfaces.Add(new YamlNetworkInterface
{
    Name = "eth0",
    Dhcp = false,
    Address = "192.168.1.100",
    Prefix = 24,
    Gateway = "192.168.1.1"
});

network.Interfaces.Add(new YamlNetworkInterface
{
    Name = "eth1",
    Dhcp = true
});

// Add DNS servers
network.Nameservers.Add("192.168.1.1");
network.Nameservers.Add("8.8.8.8");

// Add routes
network.Routes.Add(new YamlNetworkRoute
{
    To = "10.0.0.0/8",
    Via = "192.168.1.254"
});

// Save the configuration
network.Save("/tmp/netplan-config.yaml");

// Display the configuration
Console.WriteLine("Network Configuration");
Console.WriteLine("====================");
Console.WriteLine();
Console.WriteLine("Interfaces:");

foreach (var iface in network.Interfaces)
{
    Console.WriteLine($"  {iface.Name}:");
    if (iface.Dhcp)
    {
        Console.WriteLine("    DHCP: enabled");
    }
    else
    {
        Console.WriteLine($"    Address: {iface.Address}/{iface.Prefix}");
        Console.WriteLine($"    Gateway: {iface.Gateway}");
    }
}

Console.WriteLine();
Console.WriteLine("DNS Servers:");
foreach (var dns in network.Nameservers)
{
    Console.WriteLine($"  - {dns}");
}

Console.WriteLine();
Console.WriteLine("Routes:");
foreach (var route in network.Routes)
{
    Console.WriteLine($"  {route.To} via {route.Via}");
}

// Load the configuration back
var loadedNetwork = YamlNetwork.Load("/tmp/netplan-config.yaml");
Console.WriteLine();
Console.WriteLine($"Loaded configuration has {loadedNetwork.Interfaces.Count} interfaces and {loadedNetwork.Nameservers.Count} DNS servers");
```

### Scenario 5: Using Utility Functions

```csharp
// Format phone numbers
string[] phoneNumbers = {
    "5551234567",
    "15551234567",
    "+15551234567"
};

Console.WriteLine("Phone Number

```csharp
// Define a custom entity
public class Customer : Entity<long>
{
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual bool Active { get; set; }
}

// Use the entity
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    Email = "contact@acme.com",
    Active = true
};

Console.WriteLine($"Customer: {customer.Id}, {customer.Name}");
```

```csharp
// Define a versioned entity
public class Document : VersionedEntity<long>
{
    public virtual string Title { get; set; }
    public virtual string Content { get; set; }
}

// Use the entity
var document = new Document
{
    Id = 1,
    Title = "System Manual",
    Content = "This is the system manual content...",
    CreatedBy = "admin",
    CreatedDate = DateTime.Now,
    ModifiedBy = "admin",
    ModifiedDate = DateTime.Now
};

Console.WriteLine($"Document: {document.Id}, {document.Title}");
Console.WriteLine($"Created: {document.CreatedDate} by {document.CreatedBy}");
```

```csharp
// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Reception",
    Active = true,
    CurrentEndPoint = new Ast_EndPoint { Id = "SIP/101" }
};

// Add features to the extension
extension.Features.Add(new ExtFeature 
{ 
    Extension = extension,
    CallWait = true,
    VoiceMail = true
});

Console.WriteLine($"Extension: {extension.Id}, {extension.Name}");
Console.WriteLine($"Endpoint: {extension.CurrentEndPoint.Id}");
Console.WriteLine($"Has voicemail: {extension.Features.First().VoiceMail}");
```

```csharp
// Create a call record
var call = new CallDb
{
    Id = 12345,
    Direction = CallDirection.Incoming,
    Number = "5551234567",
    StartTime = DateTime.Now.AddMinutes(-5),
    EndTime = DateTime.Now,
    Status = "Completed",
    Customer = new Customer { Id = 1, Name = "John Smith" },
    Extension = new Extension { Id = "101", Name = "Reception" }
};

// Calculate duration
call.Duration = (int)(call.EndTime - call.StartTime).TotalSeconds;

Console.WriteLine($"Call: {call.Id}, Direction: {call.Direction}");
Console.WriteLine($"From/To: {call.Number}, Duration: {call.Duration} seconds");
Console.WriteLine($"Handled by: Extension {call.Extension.Id}");
```

```csharp
// Create a queue
var queue = new Queue
{
    Id = "sales",
    Name = "Sales Queue",
    Strategy = QueueStrategy.RoundRobin,
    Timeout = 30,
    MaxWait = 300
};

// Add members to the queue
queue.Members.Add(new QueueMember 
{ 
    Queue = queue,
    Extension = new Extension { Id = "101", Name = "Sales 1" },
    Index = 1,
    IsActive = true
});

queue.Members.Add(new QueueMember 
{ 
    Queue = queue,
    Extension = new Extension { Id = "102", Name = "Sales 2" },
    Index = 2,
    IsActive = true
});

Console.WriteLine($"Queue: {queue.Id}, {queue.Name}");
Console.WriteLine($"Strategy: {queue.Strategy}, Timeout: {queue.Timeout}s");
Console.WriteLine($"Members: {queue.Members.Count}");
```

```csharp
public virtual void AddPhone(Phone phone)
```

```csharp
// Create a customer
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    RemoteId = "CRM12345",
    Creator = new Extension { Id = "101", Name = "Reception" }
};

// Add phone numbers
customer.AddPhone(new Phone { Id = "5551234567" });
customer.AddPhone(new Phone { Id = "5559876543" });

Console.WriteLine($"Customer: {customer.Id}, {customer.Name}");
Console.WriteLine($"CRM ID: {customer.RemoteId}");
Console.WriteLine("Phone numbers:");
foreach (var phone in customer.Phones)
{
    Console.WriteLine($"  - {phone.Id}");
}
```

```csharp
// Use the enumeration
var call = new CallDb
{
    Direction = CallDirection.Incoming,
    // Other properties...
};

// Check call direction
if (call.Direction == CallDirection.Incoming)
{
    Console.WriteLine("This is an incoming call");
}
```

```csharp
// Use the enumeration
var queue = new Queue
{
    Strategy = QueueStrategy.RoundRobin,
    // Other properties...
};

// Apply different logic based on strategy
switch (queue.Strategy)
{
    case QueueStrategy.RoundRobin:
        Console.WriteLine("Using round-robin distribution");
        break;
    case QueueStrategy.LeastRecent:
        Console.WriteLine("Routing to least recently used agent");
        break;
    case QueueStrategy.RingAll:
        Console.WriteLine("Ringing all available agents");
        break;
}
```

```csharp
// Use the enumeration
var crmParams = new CrmParameters
{
    IntegrationType = CrmIntegrationType.REST,
    // Other properties...
};

// Check integration type
if (crmParams.IntegrationType != CrmIntegrationType.None)
{
    Console.WriteLine($"CRM integration is enabled: {crmParams.IntegrationType}");
}
```

```csharp
public static string FormatPhoneNumber(string number, string format = null)
```

```csharp
public static TimeSpan ParseTimeSpan(string value)
```

```csharp
public static string FormatTimeSpan(TimeSpan span)
```

```csharp
public static string GetRandomString(int length)
```

```csharp
// Format a phone number
string rawNumber = "5551234567";
string formattedNumber = Utilities.FormatPhoneNumber(rawNumber, "(###) ###-####");
Console.WriteLine($"Formatted number: {formattedNumber}"); // (555) 123-4567

// Parse a time string
TimeSpan duration = Utilities.ParseTimeSpan("1:30:45");
Console.WriteLine($"Duration: {duration.Hours}h {duration.Minutes}m {duration.Seconds}s");

// Format a TimeSpan
string readableDuration = Utilities.FormatTimeSpan(TimeSpan.FromSeconds(3725));
Console.WriteLine($"Readable duration: {readableDuration}"); // 1h 2m 5s

// Generate a random string
string randomString = Utilities.GetRandomString(8);
Console.WriteLine($"Random string: {randomString}");
```

```csharp
public static YamlNetwork Load(string filename)
```

```csharp
public void Save(string filename)
```

```csharp
// Load network configuration
var network = YamlNetwork.Load("/etc/netplan/01-netcfg.yaml");

// Display current configuration
Console.WriteLine("Network Interfaces:");
foreach (var iface in network.Interfaces)
{
    Console.WriteLine($"  {iface.Name}: {iface.Address}/{iface.Prefix}");
    Console.WriteLine($"    DHCP: {iface.Dhcp}, Gateway: {iface.Gateway}");
}

Console.WriteLine("DNS Servers:");
foreach (var dns in network.Nameservers)
{
    Console.WriteLine($"  {dns}");
}

// Modify configuration
var eth0 = network.Interfaces.FirstOrDefault(i => i.Name == "eth0");
if (eth0 != null)
{
    eth0.Address = "192.168.1.100";
    eth0.Prefix = 24;
    eth0.Gateway = "192.168.1.1";
    eth0.Dhcp = false;
}

// Add a DNS server
network.Nameservers.Add("8.8.8.8");

// Save configuration
network.Save("/etc/netplan/01-netcfg.yaml");
```

```csharp
// Create a call report item
var reportItem = new CallReportItem
{
    Id = 12345,
    Date = DateTime.Now.AddHours(-2),
    Number = "5551234567",
    Direction = "Incoming",
    Duration = 125,
    Status = "Completed",
    Extension = "101",
    CustomerName = "John Smith"
};

// Format for display
Console.WriteLine($"Call #{reportItem.Id} - {reportItem.Date:g}");
Console.WriteLine($"{reportItem.Direction} call from {reportItem.Number} ({reportItem.CustomerName})");
Console.WriteLine($"Handled by extension {reportItem.Extension}");
Console.WriteLine($"Duration: {TimeSpan.FromSeconds(reportItem.Duration)}, Status: {reportItem.Status}");
```

```csharp
Task<T> GetAsync<T>(object id) where T : class
```

```csharp
Task<IList<T>> GetListAsync<T>() where T : class
```

```csharp
Task<T> AddAsync<T>(T entity) where T : class
```

```csharp
Task UpdateAsync<T>(T entity) where T : class
```

```csharp
Task DeleteAsync<T>(T entity) where T : class
```

```csharp
// This is an interface definition, so we'll show how it would be used
// The actual implementation would be in the Zenda.DAL module

// Hypothetical usage:
public class CustomerService
{
    private readonly IRepository _repository;
    
    public CustomerService(IRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Customer> GetCustomer(long id)
    {
        return await _repository.GetAsync<Customer>(id);
    }
    
    public async Task<IList<Customer>> GetAllCustomers()
    {
        return await _repository.GetListAsync<Customer>();
    }
    
    public async Task<Customer> CreateCustomer(Customer customer)
    {
        return await _repository.AddAsync(customer);
    }
    
    public async Task UpdateCustomer(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }
    
    public async Task DeleteCustomer(Customer customer)
    {
        await _repository.DeleteAsync(customer);
    }
}
```

```csharp
// Define a custom report schema
public class CallReportSchema : ReportSchema
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string ExtensionId { get; set; }
    public string Direction { get; set; }
    public string Status { get; set; }
}

// Use the schema
var schema = new CallReportSchema
{
    StartDate = DateTime.Now.AddDays(-7),
    EndDate = DateTime.Now,
    ExtensionId = "101",
    Direction = "Incoming",
    Page = 1,
    PageSize = 25,
    SortBy = "Date",
    SortAscending = false
};

Console.WriteLine($"Report period: {schema.StartDate:d} to {schema.EndDate:d}");
Console.WriteLine($"Filtering by: Extension {schema.ExtensionId}, {schema.Direction} calls");
Console.WriteLine($"Page {schema.Page}, {schema.PageSize} items per page");
Console.WriteLine($"Sorted by {schema.SortBy} {(schema.SortAscending ? "ascending" : "descending")}");
```

```csharp
// Create a report result
var reportItems = new List<CallReportItem>
{
    new CallReportItem { Id = 1, Number = "5551234567", Duration = 120 },
    new CallReportItem { Id = 2, Number = "5559876543", Duration = 45 }
};

var reportResult = new ReportResult<CallReportItem>
{
    Data = reportItems,
    TotalCount = 150,
    PageCount = 6 // 150 items / 25 items per page
};

Console.WriteLine($"Showing {reportResult.Data.Count} of {reportResult.TotalCount} total items");
Console.WriteLine($"Page 1 of {reportResult.PageCount}");

foreach (var item in reportResult.Data)
{
    Console.WriteLine($"Call #{item.Id}: {item.Number}, Duration: {item.Duration}s");
}
```

```csharp
// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Sales Department",
    Active = true
};

// Create an endpoint for the extension
var endpoint = new Ast_EndPoint
{
    Id = "SIP/101",
    Type = "SIP",
    Context = "default"
};
extension.CurrentEndPoint = endpoint;

// Add features to the extension
var features = new ExtFeature
{
    Extension = extension,
    CallWait = true,
    VoiceMail = true,
    CallRecording = true,
    CallForwarding = false
};
extension.Features.Add(features);

// Create a user for the extension
var user = new User
{
    Id = "sales_user",
    Name = "Sales User",
    Email = "sales@example.com",
    Extension = extension
};
extension.User = user;

// Display extension information
Console.WriteLine($"Extension: {extension.Id} - {extension.Name}");
Console.WriteLine($"Status: {(extension.Active ? "Active" : "Inactive")}");
Console.WriteLine($"Endpoint: {extension.CurrentEndPoint.Id} ({extension.CurrentEndPoint.Type})");
Console.WriteLine("Features:");
Console.WriteLine($"  Call Waiting: {extension.Features.First().CallWait}");
Console.WriteLine($"  Voicemail: {extension.Features.First().VoiceMail}");
Console.WriteLine($"  Call Recording: {extension.Features.First().CallRecording}");
Console.WriteLine($"  Call Forwarding: {extension.Features.First().CallForwarding}");
Console.WriteLine($"User: {extension.User.Name} ({extension.User.Email})");
```

```csharp
// Create a customer
var customer = new Customer
{
    Id = 1,
    Name = "Acme Corporation",
    RemoteId = "CRM12345"
};

// Add phone numbers to the customer
customer.AddPhone(new Phone { Id = "5551234567" });
customer.AddPhone(new Phone { Id = "5559876543" });

// Create an extension
var extension = new Extension
{
    Id = "101",
    Name = "Support",
    Active = true
};

// Create call records
var call1 = new CallDb
{
    Id = 1001,
    Direction = CallDirection.Incoming,
    Number = "5551234567",
    StartTime = DateTime.Now.AddHours(-2),
    EndTime = DateTime.Now.AddHours(-1).AddMinutes(-45),
    Status = "Completed",
    Customer = customer,
    Extension = extension
};
call1.Duration = (int)(call1.EndTime - call1.StartTime).TotalSeconds;

var call2 = new CallDb
{
    Id = 1002,
    Direction = CallDirection.Outgoing,
    Number = "5559876543",
    StartTime = DateTime.Now.AddHours(-1),
    EndTime = DateTime.Now.AddMinutes(-30),
    Status = "Completed",
    Customer = customer,
    Extension = extension
};
call2.Duration = (int)(call2.EndTime - call2.StartTime).TotalSeconds;

// Create a list of calls
var calls = new List<CallDb> { call1, call2 };

// Create printable report items
var reportItems = calls.Select(c => new CallReportItem
{
    Id = c.Id,
    Date = c.StartTime,
    Number = c.Number,
    Direction = c.Direction.ToString(),
    Duration = c.Duration,
    Status = c.Status,
    Extension = c.Extension.Id,
    CustomerName = c.Customer.Name
}).ToList();

// Create a report result
var reportResult = new ReportResult<CallReportItem>
{
    Data = reportItems,
    TotalCount = reportItems.Count,
    PageCount = 1
};

// Display the report
Console.WriteLine("Call Report");
Console.WriteLine("==========");
Console.WriteLine($"Total Calls: {reportResult.TotalCount}");
Console.WriteLine();
Console.WriteLine("ID    | Date                | Number      | Direction | Duration | Status    | Extension | Customer");
Console.WriteLine("------|---------------------|-------------|-----------|----------|-----------|-----------|----------");

foreach (var item in reportResult.Data)
{
    Console.WriteLine($"{item.Id,-5} | {item.Date,-20:g} | {item.Number,-11} | {item.Direction,-9} | {item.Duration,-8} | {item.Status,-9} | {item.Extension,-9} | {item.CustomerName}");
}

// Calculate statistics
int totalDuration = reportItems.Sum(i => i.Duration);
int avgDuration = reportItems.Average(i => i.Duration).ToInt();
int incomingCount = reportItems.Count(i => i.Direction == CallDirection.Incoming.ToString());
int outgoingCount = reportItems.Count(i => i.Direction == CallDirection.Outgoing.ToString());

Console.WriteLine();
Console.WriteLine("Statistics:");
Console.WriteLine($"Total Duration: {TimeSpan.FromSeconds(totalDuration)}");
Console.WriteLine($"Average Duration: {TimeSpan.FromSeconds(avgDuration)}");
Console.WriteLine($"Incoming Calls: {incomingCount}");
Console.WriteLine($"Outgoing Calls: {outgoingCount}");
```

```csharp
// Create a queue
var queue = new Queue
{
    Id = "support",
    Name = "Support Queue",
    Strategy = QueueStrategy.RoundRobin,
    Timeout = 30,
    MaxWait = 300,
    WelcomePrompt = "welcome",
    MohClass = "default"
};

// Create extensions for queue members
var extension1 = new Extension { Id = "101", Name = "Support 1", Active = true };
var extension2 = new Extension { Id = "102", Name = "Support 2", Active = true };
var extension3 = new Extension { Id = "103", Name = "Support 3", Active = false };

// Add members to the queue
queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension1,
    Index = 1,
    IsActive = true
});

queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension2,
    Index = 2,
    IsActive = true
});

queue.Members.Add(new QueueMember
{
    Queue = queue,
    Extension = extension3,
    Index = 3,
    IsActive = false
});

// Display queue configuration
Console.WriteLine($"Queue: {queue.Id} - {queue.Name}");
Console.WriteLine($"Strategy: {queue.Strategy}");
Console.WriteLine($"Timeout: {queue.Timeout} seconds");
Console.WriteLine($"Maximum Wait Time: {queue.MaxWait} seconds");
Console.WriteLine($"Welcome Prompt: {queue.WelcomePrompt}");
Console.WriteLine($"Music on Hold: {queue.MohClass}");
Console.WriteLine();
Console.WriteLine("Queue Members:");
Console.WriteLine("Index | Extension | Name      | Status");
Console.WriteLine("------|-----------|-----------|-------");

foreach (var member in queue.Members.OrderBy(m => m.Index))
{
    string status = member.IsActive && member.Extension.Active ? "Active" : "Inactive";
    Console.WriteLine($"{member.Index,-5} | {member.Extension.Id,-9} | {member.Extension.Name,-10} | {status}");
}

// Calculate active members
int activeMembers = queue.Members.Count(m => m.IsActive && m.Extension.Active);
Console.WriteLine();
Console.WriteLine($"Active Members: {activeMembers} of {queue.Members.Count}");
```

```csharp
// Create a network configuration
var network = new YamlNetwork();

// Add network interfaces
network.Interfaces.Add(new YamlNetworkInterface
{
    Name = "eth0",
    Dhcp = false,
    Address = "192.168.1.100",
    Prefix = 24,
    Gateway = "192.168.1.1"
});

network.Interfaces.Add(new YamlNetworkInterface
{
    Name = "eth1",
    Dhcp = true
});

// Add DNS servers
network.Nameservers.Add("192.168.1.1");
network.Nameservers.Add("8.8.8.8");

// Add routes
network.Routes.Add(new YamlNetworkRoute
{
    To = "10.0.0.0/8",
    Via = "192.168.1.254"
});

// Save the configuration
network.Save("/tmp/netplan-config.yaml");

// Display the configuration
Console.WriteLine("Network Configuration");
Console.WriteLine("====================");
Console.WriteLine();
Console.WriteLine("Interfaces:");

foreach (var iface in network.Interfaces)
{
    Console.WriteLine($"  {iface.Name}:");
    if (iface.Dhcp)
    {
        Console.WriteLine("    DHCP: enabled");
    }
    else
    {
        Console.WriteLine($"    Address: {iface.Address}/{iface.Prefix}");
        Console.WriteLine($"    Gateway: {iface.Gateway}");
    }
}

Console.WriteLine();
Console.WriteLine("DNS Servers:");
foreach (var dns in network.Nameservers)
{
    Console.WriteLine($"  - {dns}");
}

Console.WriteLine();
Console.WriteLine("Routes:");
foreach (var route in network.Routes)
{
    Console.WriteLine($"  {route.To} via {route.Via}");
}

// Load the configuration back
var loadedNetwork = YamlNetwork.Load("/tmp/netplan-config.yaml");
Console.WriteLine();
Console.WriteLine($"Loaded configuration has {loadedNetwork.Interfaces.Count} interfaces and {loadedNetwork.Nameservers.Count} DNS servers");
```

```csharp
// Format phone numbers
string[] phoneNumbers = {
    "5551234567",
    "15551234567",
    "+15551234567"
};

Console.WriteLine("Phone Number
```

