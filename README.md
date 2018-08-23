# UiPrime SAP Activities Package

Activities designed for automating SAP system, by encapsulating script actions into UiPath activities through DLL interface provided by SAP. (Requires script to be enabled in SAP)

It is known that you can automate SAP using just standard UiPath activities, however this package allows access to a bunch of SAP components and methods that are not accessible otherwise.
Another great feature of this package is that all methods can be used through a standard Assign activity (with intellisense available)
because all classes provided by SAP are accessible. You just need to import sapfewse.dll.

This facilitates actions like "Open Transaction", "Select a column in a grid view", "Display column Title", "Is column filtered", "Scroll Down and count rows", and others.

You can use the built in SAP scripting to record the actions that will help you replicate the steps into the UiPath workflow.
However, we recommend you to use the freeware Scripting Tracker below to record the SAP interactions with more details and information.
https://tracker.stschnell.de/

We also recommend you to use the Official SAP Documentation found in the link below, to understand the structure and events of each SAP component available:
https://github.com/uiprimeteam/UiPrimePackage/blob/master/Documentation/SAP%20Gui%20Components%20Guide.pdf

