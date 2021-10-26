## Requirements

 - Creation of usability concept and GUI
    - To convert the plugin to a standalone application, the current user experience needs to be evaluated. The same approach should be used for the graphical user interface. The insights gained from this can then be used to create an improved upon and streamlined experience. In addition, all of the changes to current plugin interface should be created with the aim to provide a uniform appearance across the entire application. Key factors in this step are the use of space on the main screen, creation of a guided wizard for ease of use and a new palette of colours for the interface. Overall, helping the user getting things done faster should be the main focus in our development.
 - Support of formats
    - CAEX 2.15 and CAEX 3.0 are set as requirements by the customer. The application to be developed has to support exporting device models in these formats in order to stay within specification.
 - Inputs for minimal AML-DD compatibility
    - The application needs to have all the inputs to conform with the minimum requirements of the AutomationML device description standard. All of these inputs need to fit seamlessly into the user interface that is to be developed.
 - Generic Interfaces
    - To help with the creation of new devices, there should be support in the form of generic interfaces. These interfaces represent the minimal requirements for that type of connector (electric, hydraulic, mechanical, etc.). A user shoudl be able to add such a generic interface to a new device after choosing which type is to be used. This interface can then be modified to the users preferences. Furthermore, to help with usability these default interface should be equipped with matching icons. Distinguishable iconography will make recognising the type of interface on the devices easier. A customisation option for these icons is possible addition in functionality.
 - Guided wizards for sensors
    - There should be supportive creation wizards for sensors. If a user wants to add sensors to their device, a wizard should ask for the minimal requirements for that type of sensor. This needs to at least cover all of the necessary options of that sensor so that without the wizard, the user will not be able to create individual new sensors on a device.
 - Support for AML interface library
    - Electrical interfaces shoud be able to be linked to the existing AutomationML interfaces library. The current linking in the existing plugin could be used for this functionality.
 - Documentation
    - The new application needs to be well documented for the user. Everything that can be accessed by the user in the interface needs to have supporting documentation. The installation process of the application needs a guide in the documentation. Simple tooltips inside the application may help with usability and speed up workflows. These tooltips can indicate the allowed contents of input fields or the functionality of a button. The documentation needs to be reachable from inside the application with ease and swiftness. All of this is additional to documentation of the source code.
