# sm70-cp-450-GUI
controller made for WhisperPower to use an Windows forms application to set and monitor Battery data using the SM15K series Bidirectional Charger.

# Changelog


## Commit 8: Refactored TCP Connection Code

  Refactor: Moved all TCP connection-related code into a new TcpConnectionHandler class for better separation of concerns.
  Connection Management: Added methods for initializing the TCP connection, sending queries, and receiving responses in a cleaner, more structured way.
  Error Handling: Improved error handling and feedback for connection issues and sending/receiving data from the battery device.


## Commit 7: Safety Features

  High Voltage Tracking: Added logic to monitor and store the highest battery voltage detected during the charging cycle.
  Locking Controls: Implemented functionality to lock certain UI controls during battery operations to prevent accidental input changes.


## Commit 6: Real-Time Data Updates

  Live Measurement Display: Improved the live display of voltage, current, and power using the UpdateLoop function. This allows real-time updates from the battery system.
  UI Feedback: Enhanced user feedback with more detailed status displays during operations like charging and discharging.

  
## Commit 5: Refactoring and Optimizations

  Code Cleanup: Refactored functions for measuring output voltage, current, and power.
  Button Logic: Improved logic for start/stop button functionality, controlling the flow of battery operations.


## Commit 4: Timer and Measurement Updates

  Update Loop: Added a timer to update voltage, current, and wattage readings every 500 milliseconds.
  Power Sink Functions: Introduced functions to measure and control the power sink (output) from the system.


## Commit 3: Battery Data Application

  Factory Data: Integrated functionality to apply battery factory information (voltage, amperage) from input.
  C Rating: Added support for C-Rating, improving the calculation of battery power and current.


## Commit 2: UI Enhancements

  Status Labels: Added constant voltage, constant current, and constant power status indicators for better visibility.
  Discharge Functionality: Implemented discharge-to-30% button.
  Remote Control: Improved UI control for remote CV, CC, and CP modes.


## Commit 1: Initial Commit

  GUI Implementation: Established basic layout with labels, buttons, and text boxes for displaying battery information (voltage, current, wattage).
  TCP Communication: Enabled TCP socket communication with the battery system.
  Core Functionality: Introduced key functions like charging and discharging control buttons.
