using System;
using System.Collections.Generic;

namespace Aml.Editor.Plugin
{
    /// <summary>
    /// This class passes the inputs of the GUIs to <see cref="MWData"/> where needed and it is in controll of what is displayed at the screen
    /// </summary>
    public class MWController
    {
        // the (initialised) GUIs



        private DeviceDescription deviceDescriptionForm;


        // the interface class to the AML Editor
        private ModellingWizard modellingWizard;

        // the MWData instance of the the plugin which handles all the AMLX stuff
        private MWData mWData;

        // the list of the currently loaded amlx devices / interfaces
        // these will be displayed on the start GUI
        private List<MWData.MWObject> devices = new List<MWData.MWObject>();

        /// <summary>
        /// Init the controller and reload all amlx devices
        /// </summary>
        public MWController()
        {
            mWData = new MWData(this);
        }

        /// <summary>
        /// Create the new CreateDevice GUI or return the previously created GUI
        /// </summary>
        /// <returns>the CreateDevice GUI for this session</returns>

        /// <summary>
        /// create the new DeviceDescription GUI or return the previously created GUI
        /// </summary>
        public DeviceDescription GetDeviceDescriptionForm()
        {
            if (deviceDescriptionForm == null)
            {
                deviceDescriptionForm = new DeviceDescription(this);
            }
            return deviceDescriptionForm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDevice"></param>
        /// <param name="isEdit"></param>
        /// <returns></returns>
        public String CreateDeviceOnClick(MWDevice newDevice, bool isEdit, bool useCaex2_15)
        {
            string result = "";

            if (newDevice.deviceName != null && newDevice.vendorName != null)
            {
                // create the device
                result = mWData.CreateDevice(newDevice, isEdit, useCaex2_15);
            }

            // update the device list
            if (isEdit)
            {

            }
            else
            {
                devices.Add(newDevice);

            }


            return result;

        }

        /// <summary>
        /// Show the correct GUI for the selected device
        /// </summary>
        /// <param name="selectedIndex">The index of the selected item in the dropdown</param>

        /// <summary>
        /// Reload all .amlx files in ./modellingwizard/ and update the dropdown.
        /// </summary>


        /// <summary>
        /// Switch the displayed 
        /// </summary>
        /// <param name="targetGUI">the GUI Type to display</param>
        public void ChangeGui(MWGUIType targetGUI)
        {
            // TODO modellingWizard is null
            switch (targetGUI)
            {

                case MWGUIType.DeviceDescription:
                    modellingWizard.changeGUI(GetDeviceDescriptionForm());
                    break;

            }
        }

        /// <summary>
        /// Enum to represent the GUI
        /// </summary>
        public enum MWGUIType { CreateDevice, CreateInterface, Start, DeviceDescription }

        /// <summary>
        /// Call the Converter with the given file
        /// </summary>
        /// <param name="filename">the full path to the file</param>
        /// <param name="filetype">whether the file is an IODD or an GSD file</param>
        /// <returns></returns>
        public string importFile(string filename, MWData.MWFileType filetype)
        {

            // call the correct import function for the file type
            string result = null;
            switch (filetype)
            {
                case MWData.MWFileType.IODD:
                    result = mWData.ImportIODD2AML(filename);
                    break;
                case MWData.MWFileType.GSD:
                    result = mWData.ImportGSD2AML(filename);
                    break;
                default:
                    result = "Invalid Filetype";
                    break;
            }

            return result;
        }
    }
}
