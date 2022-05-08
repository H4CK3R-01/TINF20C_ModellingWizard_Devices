using Aml.Engine.AmlObjects;
using Aml.Engine.CAEX;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Windows.Forms;


/// <summary>
/// MOD.002 Controller
/// This Module is the backend of the GUI. It covers all functions that are not frontend-related and makes sure that all errors occuring are caught by the program.
/// Every time a user makes a mistake, like triggering an error he gets feedback from this module (like an error message). The Controller is also responsible for opening, saving,
/// exporting and importing files
/// </summary>

namespace Aml.Editor.Plugin
{
    public partial class DeviceDescription : UserControl
    {
        /// <summary>
        /// These are private fields of this class.
        /// </summary>
        private MWController mWController;
        private MWData.MWFileType filetype;
        private object _row;
        private bool isEditing = false;
        private bool expertMode = false;
        private bool useCaex2_15 = false;
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        private List<string> AllInterfaces = new List<string>();


        /// <summary>
        /// These are public fields of this class.
        /// </summary>
        public object row //this is a property decleration
        {
            get { return this._row; }
            private set { this._row = value; }
        }
        public bool dragging = false; //this is your global boolean


        /// <summary>
        /// Instance of Animation Class is created.
        /// </summary>
        AnimationClass AMC = new AnimationClass();

        /// <summary>
        /// Instance of SearchforAMLLibraryFile is created.
        /// This class search for "Interface Class Libraries" and "Role Class Libraries" in AML file loaded by user into plugin.
        /// </summary>
        SearchAMLLibraryFile searchAMLLibraryFile = new SearchAMLLibraryFile();

        /// <summary>
        /// Instance of "SearchAMLComponentFile" is created
        /// This class search for "System Unit Class Libraries"  in AML Component  file loaded by user into plugin. 
        /// </summary>
        SearchAMLComponentFile searchAMLComponentFile = new SearchAMLComponentFile();

        /// <summary>
        /// Instance of MWDevice Class
        /// </summary>
        MWDevice device = new MWDevice();


        public void getAllInterfaces(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                AllInterfaces.Add(node.Name);
                if (node.Nodes.Count > 0)
                {
                    getAllInterfaces(node.Nodes);
                }
            }
        }

        /// <summary>
        /// Codepart for all the retarded methodes nobody understands
        /// </summary>

        /// <summary>
        /// Constructor with no arguments that intilizes Device Description GUI
        /// </summary>
        public DeviceDescription()
        {
            InitializeComponent();

            ShowHideElements();
        }
        /// <summary>
        /// This is a constructor of this class with MWControlle rargument. 
        /// </summary>
        /// <param name="mWController"></param>
        public DeviceDescription(MWController mWController)
        {
            // These are the dictionaries created in MWDevice Class to store attributes inside them.
            //These dictionaries are initiated as new dictionaries in here.
            device.DictionaryForInterfaceClassesInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            device.DictionaryForRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForExternalInterfacesUnderRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            this.mWController = mWController;
            InitializeComponent();

            ShowHideElements();

            // After intialization of this GUI, plugin all this function to load Standard Libraries.  
            loadStandardLibrary();

            // This Function look for "AutomationComponent" Role and assign it to "Generic Data Tab" as a compulsary role along with attributes.
            checkForAutomtionComponent();

            foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "AutomationComponent{Class:  AutomationMLBaseRole}")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This function loads "Interface Class Libraries" and"Role Class Libraries" from already defined libaraies in plugin or, 
        /// libraries from the AML file those user want ot load from local machine.
        /// </summary>
        public void loadStandardLibrary()
        {
            CAEXDocument doc = null;

            // These library already come along with plugin. This library is loaded into GUI automaticcally by plugin.
            doc = CAEXDocument.LoadFromBinary(Properties.Resources.AutomationComponentLibrary_v1_0_0_Full);

            //Following newly initiated dictionaries store "Interface Classes and its attributes" and "Role Classes and its attributes" of loaded file
            //in the respective libraries.
            //(Note:- This libaray is not used at all)
            searchAMLLibraryFile.dictionaryofRoleClassattributes = new Dictionary<string, List<ClassOfListsFromReferencefile>>();


            // These are the main libraraies used.
            searchAMLLibraryFile.DictionaryForInterfaceClassInstancesAttributes = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            searchAMLLibraryFile.DictionaryForExternalInterfacesInstanceAttributesofInterfaceClassLib = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            searchAMLLibraryFile.DictionaryForExternalInterfacesInstancesAttributesOfRoleClassLib = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();


            //(´Note:- This library is not used ata all.)
            searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes = new Dictionary<string, string>();

            // These are the tree hierarchies in the GUI, which has to be cleared all during intiation of plugin.
            treeViewRoleClassLib.Nodes.Clear();
            treeViewInterfaceClassLib.Nodes.Clear();
            {
                try
                {

                    // This is a string variable that store the name of the "referenced name" of each "Interface Class in ICL of loaded file"
                    // and/or "Referenced name" of each "Role Class in RCL of loaded file" 
                    string referencedClassName = "";

                    // This foreach loop look into every individual "Role Class libaray" in RCL in the loaded file. 
                    foreach (var classLibType in doc.CAEXFile.RoleClassLib)
                    {
                        // This Populate Role Class Tree Node in GUI
                        TreeNode libNode = treeViewRoleClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);

                        // This foreach loop looks inside the individual "Role Class" 
                        foreach (var classType in classLibType.RoleClass)
                        {

                            TreeNode roleNode;

                            // This If loop check for the "refernced name" of each role class.
                            if (classType.ReferencedClassName != "")
                            {
                                //Store "referenced name" in the String that declared above "referencedClassName"
                                referencedClassName = classType.ReferencedClassName;
                                // Print the role  node
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);

                                // Search for the "refernced name" (This referenced name will be as an "Role Class" in the RCL).....
                                //.....in the whole RCL to find the attribute behind it and also its further "referenced name"
                                searchAMLLibraryFile.SearchForReferencedClassName(doc, referencedClassName, classType);
                                //This method is responsible to check attributes of referenced Class
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                            }
                            // If there is no "Referenced Class name" then just print the name in GUI.
                            else
                            {
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }


                            // This If loop check for the "ExternalInterface" under each role class.
                            if (classType.ExternalInterface.Exists)
                            {
                                // This foreach loop look for number of "ExternalInterfaces" under "Role Class"
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    // This If loop check for the "refernced name" of each externalinterface.
                                    if (externalinterface.BaseClass != null)
                                    {
                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;

                                        //This method is responsible to check for "Referenced Class Name" of "External Interfaces" under the "Role Class"
                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(doc, referencedClassName, classType, externalinterface);

                                        // This Function is responsible to search attributes under the "Referenced Classs Name" i.e. in this part "RoleFamilyType"
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);


                                    }
                                    //Else directly print the node.
                                    else
                                    {
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                        // searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }

                                    //This method is called to print "External Interfaces" in both "Role class Library and Interface Class Library" in the plugin.
                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(doc, externalinterfacenode, externalinterface, classType);
                                }
                            }
                            //This method takes arguments "TreeNode" and "RoleFamilyType" to print tree nodes in "Role Class Library TreeView " in Plugin.
                            searchAMLLibraryFile.PrintNodesRecursiveInRoleClassLib(doc, roleNode, classType, referencedClassName);
                        }
                    }

                    foreach (var classLibType in doc.CAEXFile.InterfaceClassLib)
                    {
                        // Print a "Interface Class lib" treenode in GUI 
                        TreeNode libNode = treeViewInterfaceClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);


                        // for each "interface classlib" print chlid nodes of "Interface Classes"
                        foreach (var classType in classLibType.InterfaceClass)
                        {

                            TreeNode interfaceclassNode;
                            //If "refernced Class Name" is not null
                            if (classType.ReferencedClassName != "")
                            {
                                // Print Child node...
                                referencedClassName = classType.ReferencedClassName;
                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);

                                //This method search for "Referenced Class Name" "Interface Class"
                                searchAMLLibraryFile.SearchForReferencedClassName(doc, referencedClassName, classType);
                                //
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                            }
                            else
                            {
                                //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());
                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }

                            if (classType.ExternalInterface.Exists)
                            {
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    if (externalinterface.BaseClass != null)
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString()+ externalinterface.ToString(), externalinterface.ID.ToString());

                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;

                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(doc, referencedClassName, classType, externalinterface);
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }
                                    else
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString() + externalinterface.ToString(), externalinterface.ID.ToString());

                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                    }
                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(doc, externalinterfacenode, externalinterface, classType);
                                }
                            }
                            searchAMLLibraryFile.PrintNodesRecursiveInInterfaceClassLib(doc, interfaceclassNode, classType, referencedClassName);
                        }
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Missing names of attributes or same attribute sequence is repeated in the given file", "Missing Names", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }


        /// <summary>
        /// From here comes the part that is no longer even commented with tank methods
        /// </summary>

        private void treeViewInterfaceClassLib_MouseDown(object sender, MouseEventArgs e)
        {
            //this.treeViewInterfaceClassLib.MouseDown += new MouseEventHandler(this.tree_MouseDown);
        }

        private void treeViewInterfaceClassLib_DragOver(object sender, DragEventArgs e)
        {
            // this.treeViewInterfaceClassLib.DragOver += new DragEventHandler(this.tree_DragOver);

            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeViewInterfaceClassLib.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeViewInterfaceClassLib.SelectedNode = treeViewInterfaceClassLib.GetNodeAt(targetPoint);
        }

        private void treeViewRoleClassLib_DragOver(object sender, DragEventArgs e)
        {
            // this.treeViewInterfaceClassLib.DragOver += new DragEventHandler(this.tree_DragOver);

            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeViewRoleClassLib.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeViewRoleClassLib.SelectedNode = treeViewRoleClassLib.GetNodeAt(targetPoint);
        }

        private void treeViewInterfaceClassLib_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void treeViewInterfaceClassLib_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeViewInterfaceClassLib.SelectedNode = e.Node;
            e.Node.ContextMenuStrip = contextMenuStripforInterfaceClassLib;
        }

        private void treeViewInterfaceClassLib_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode targetNode = treeViewInterfaceClassLib.SelectedNode;

                targetNode.SelectedImageIndex = targetNode.ImageIndex;
            }
            catch (Exception)
            {

            }
        }

        private void treeViewInterfaceClassLib_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeViewInterfaceClassLib.SelectedNode == null)
            {
                dragging = false;
            }
            else
            {
                Cursor = Cursors.Hand;

                if (treeViewInterfaceClassLib.SelectedNode.ImageIndex == 2)
                {
                    return;
                }
                else
                {
                    dragging = true;
                    row = new object();


                    treeViewInterfaceClassLib.SelectedNode = (TreeNode)e.Item;//dragging doesn't automatically change the selected index
                    row = treeViewInterfaceClassLib.SelectedNode.Text;//or whatever value you need from the node
                }
            }



        }

        private void treeViewInterfaceClassLib_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void treeViewRoleClassLib_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeViewRoleClassLib.SelectedNode == null)
            {
                dragging = false;
            }
            else
            {
                Cursor = Cursors.Hand;

                if (treeViewRoleClassLib.SelectedNode.ImageIndex == 2)
                {
                    return;
                }
                else
                {
                    dragging = true;
                    row = new object();
                    treeViewRoleClassLib.SelectedNode = (TreeNode)e.Item;//dragging doesn't automatically change the selected index
                    row = treeViewRoleClassLib.SelectedNode.Text;//or whatever value you need from the node
                }
            }
        }

        private void treeViewRoleClassLib_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode targetNode = treeViewRoleClassLib.SelectedNode;
                if (targetNode != null)
                {
                    targetNode.SelectedImageIndex = targetNode.ImageIndex;
                }
            }
            catch (Exception)
            {
                return;
            }
        }




        private void treeViewElectricalInterfaces_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string searchName = "";
            var AutomationMLDataTables = new AutomationMLDataTables();

            TreeNode targetNode = treeViewElectricalInterfaces.SelectedNode;
            /* targetNode.SelectedImageIndex = targetNode.ImageIndex;*/

            elecInterAttDataGridView.Rows.Clear();

            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (targetNode != null)
                    {
                        if (targetNode.Parent != null)
                        {
                            searchName = targetNode.Parent.Text + targetNode.Text;
                            electricalInterfacesHeaderlabel.Text = searchName;
                            //nameTxtBxElecAttri.Text = searchName;
                            foreach (var pair in device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces)
                            {
                                if (pair.Key.ToString() == searchName)
                                {
                                    DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                                    AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, elecInterAttDataGridView, pair);
                                }
                            }
                        }
                        else
                        {
                            searchName = targetNode.Text;
                            electricalInterfacesHeaderlabel.Text = searchName;
                            //nameTxtBxElecAttri.Text = searchName;
                            foreach (var pair in device.DictionaryForInterfaceClassesInElectricalInterfaces)
                            {
                                if (pair.Key.ToString() == searchName)
                                {
                                    DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                                    AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, elecInterAttDataGridView, pair);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void treeViewElectricalInterfaces_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void importIODDFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filetype = MWData.MWFileType.IODD;
            openFileDialog.Filter = "IODD Files (*.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
        }

        private void importGSDFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filetype = MWData.MWFileType.GSD;
            openFileDialog.Filter = "GSDML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();
        }

        private void automationComponentLibraryv100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.AutomationComponentLibrary_v1_0_0);
        }

        private void automationComponentLibraryv100CAEX3BETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.AutomationComponentLibrary_v1_0_0_CAEX3_BETA);
        }

        private void automationComponentLibraryv100FullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.AutomationComponentLibrary_v1_0_0_Full);
        }

        private void automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.AutomationComponentLibrary_v1_0_0_Full_CAEX3_BETA);
        }

        private void electricConnectorLibraryv100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.ElectricConnectorLibrary_v1_0_0);
        }

        private void industrialSensorLibraryv100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectLibrary(Properties.Resources.IndustrialSensorLibrary_v1_0_0);
        }


        private void electricalInterfacesCollectionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!dragging)
                {
                    treeViewElectricalInterfaces.Nodes.Clear();

                    TreeNode parentNode;
                    TreeNode childNodes;

                    var AutomationMLDataTables = new AutomationMLDataTables();
                    electricalInterfacesCollectionDataGridView.CurrentRow.Selected = true;


                    if (electricalInterfacesCollectionDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        string interfaceSerialNumber = electricalInterfacesCollectionDataGridView.Rows[e.RowIndex].Cells[0]
                            .Value.ToString();

                        if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.CurrentRow.Cells[3].Value) == true)
                        {
                            elecInterAttDataGridView.Rows.Clear();
                            string interfaceClass = electricalInterfacesCollectionDataGridView.CurrentRow.Cells[1].Value
                                .ToString();
                            foreach (var pair in searchAMLLibraryFile.DictionaryForInterfaceClassInstancesAttributes)
                            {
                                if (pair.Key.ToString() == interfaceClass)
                                {
                                    try
                                    {
                                        if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey(
                                            "(" + interfaceSerialNumber + ")" + interfaceClass))
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass);
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }
                                }
                            }

                            parentNode = treeViewElectricalInterfaces.Nodes.Add(
                                "(" + interfaceSerialNumber + ")" + interfaceClass,
                                "(" + interfaceSerialNumber + ")" + interfaceClass, 2);

                            foreach (var pair in searchAMLLibraryFile
                                .DictionaryForExternalInterfacesInstanceAttributesofInterfaceClassLib)
                            {
                                if (pair.Key.Contains(interfaceClass))
                                {
                                    try
                                    {
                                        if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                            .ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }

                                    childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString(),
                                        pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                }
                            }

                            electricalInterfacesCollectionDataGridView.CurrentRow.Cells[3].Value = true;
                        }

                        if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.CurrentRow.Cells[4].Value) == true)
                        {
                            elecInterAttDataGridView.Rows.Clear();
                            string interfaceClass = electricalInterfacesCollectionDataGridView.CurrentRow.Cells[1].Value
                                .ToString();
                            foreach (var pair in searchAMLComponentFile.DictionaryofElectricalConnectorType)
                            {
                                if (pair.Key.ToString() == interfaceClass)
                                {
                                    try
                                    {
                                        if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey(
                                            "(" + interfaceSerialNumber + ")" + interfaceClass))
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass);
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add(
                                                "(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }
                                }
                            }

                            parentNode = treeViewElectricalInterfaces.Nodes.Add(
                                "(" + interfaceSerialNumber + ")" + interfaceClass,
                                "(" + interfaceSerialNumber + ")" + interfaceClass, 2);

                            foreach (var pair in searchAMLComponentFile.DictioanryofElectricalConnectorPinType)
                            {
                                if (pair.Key.Contains(interfaceClass))
                                {
                                    try
                                    {
                                        if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                            .ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                .Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        return;
                                    }

                                    childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString(),
                                        pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                }
                            }
                            // electricalInterfacesCollectionDataGridView.CurrentRow.Cells[4].Value = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;

            }
        }

        private void electricalInterfacesCollectionDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                try
                {
                    int num = electricalInterfacesCollectionDataGridView.Rows.Add();
                    List<string> listofSerialNumbers = new List<string>();
                    List<int> listofFinalSerialNumber = new List<int>();
                    string number = "";
                    int finalNumber = 0;
                    int ultimatenumber = 0;
                    if (electricalInterfacesCollectionDataGridView.Rows.Count > 2)
                    {
                        foreach (DataGridViewRow row in electricalInterfacesCollectionDataGridView.Rows)
                        {
                            if (row.Cells[0].Value == null)
                            {
                                number = "0";
                                listofSerialNumbers.Add(number);
                            }
                            if (row.Cells[0].Value != null)
                            {
                                number = row.Cells[0].Value.ToString();
                                listofSerialNumbers.Add(number);
                            }
                        }
                        foreach (string str in listofSerialNumbers)
                        {
                            finalNumber = Convert.ToInt32(str);
                            listofFinalSerialNumber.Add(finalNumber);
                        }
                        ultimatenumber = listofFinalSerialNumber.Max();
                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                    }
                    else
                    {
                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = 1;
                    }

                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value = row;
                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[3].Value = true;

                    electricalInterfacesCollectionDataGridView.Rows[num].Selected = false;

                    treeViewElectricalInterfaces.Nodes.Clear();

                    TreeNode parentNode;
                    TreeNode childNodes;

                    var AutomationMLDataTables = new AutomationMLDataTables();
                    electricalInterfacesCollectionDataGridView.CurrentRow.Selected = true;


                    if (electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value != null)
                    {
                        string interfaceSerialNumber = electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value.ToString();

                        if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.Rows[num].Cells[3].Value) == true)
                        {
                            elecInterAttDataGridView.Rows.Clear();
                            string interfaceClass = electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value.ToString();
                            foreach (var pair in searchAMLLibraryFile.DictionaryForInterfaceClassInstancesAttributes)
                            {
                                if (pair.Key.ToString() == interfaceClass)
                                {
                                    try
                                    {
                                        if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        return;
                                    }

                                }

                            }


                            parentNode = treeViewElectricalInterfaces.Nodes.Add("(" + interfaceSerialNumber + ")" + interfaceClass,
                                "(" + interfaceSerialNumber + ")" + interfaceClass, 2);


                            foreach (var pair in searchAMLLibraryFile.DictionaryForExternalInterfacesInstanceAttributesofInterfaceClassLib)
                            {
                                if (pair.Key.Contains(interfaceClass))
                                {
                                    try
                                    {
                                        if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        return;
                                    }


                                    childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString()
                                        , pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                }
                            }

                            electricalInterfacesCollectionDataGridView.CurrentRow.Cells[3].Value = true;
                        }

                        if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.Rows[num].Cells[4].Value) == true)
                        {
                            elecInterAttDataGridView.Rows.Clear();
                            string interfaceClass = electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value.ToString();
                            foreach (var pair in searchAMLComponentFile.DictionaryofElectricalConnectorType)
                            {
                                if (pair.Key.ToString() == interfaceClass)
                                {
                                    try
                                    {
                                        if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        return;
                                    }
                                }
                            }


                            parentNode = treeViewElectricalInterfaces.Nodes.Add("(" + interfaceSerialNumber + ")" + interfaceClass,
                                "(" + interfaceSerialNumber + ")" + interfaceClass, 2);


                            foreach (var pair in searchAMLComponentFile.DictioanryofElectricalConnectorPinType)
                            {
                                if (pair.Key.Contains(interfaceClass))
                                {
                                    try
                                    {
                                        if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                        else
                                        {
                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                        }
                                    }
                                    catch (Exception)
                                    {

                                        return;
                                    }
                                    childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString(), pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                }
                            }
                            // electricalInterfacesCollectionDataGridView.CurrentRow.Cells[4].Value = true;
                        }
                    }
                    dragging = false;
                }
                catch (Exception)
                {
                    dragging = false;
                    return;
                }

                Cursor = Cursors.Default;
            }
        }

        private void genericInformationDataGridView_MouseUp(object sender, MouseEventArgs e)
        {

            if (dragging)
            {
                try
                {
                    int num = genericInformationDataGridView.Rows.Add();
                    List<string> listofSerialNumbers = new List<string>();
                    List<int> listofFinalSerialNumber = new List<int>();
                    string number = "";
                    int finalNumber = 0;
                    int ultimatenumber = 0;
                    if (genericInformationDataGridView.Rows.Count > 2)
                    {
                        foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
                        {
                            if (row.Cells[0].Value == null)
                            {
                                number = "0";
                                listofSerialNumbers.Add(number);
                            }

                            if (row.Cells[0].Value != null)
                            {
                                number = row.Cells[0].Value.ToString();
                                listofSerialNumbers.Add(number);
                            }
                        }

                        foreach (string str in listofSerialNumbers)
                        {
                            finalNumber = Convert.ToInt32(str);
                            listofFinalSerialNumber.Add(finalNumber);
                        }

                        ultimatenumber = listofFinalSerialNumber.Max();
                        genericInformationDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                    }
                    else
                    {
                        genericInformationDataGridView.Rows[num].Cells[0].Value = 1;
                    }

                    genericInformationDataGridView.Rows[num].Cells[1].Value = row;
                    genericInformationDataGridView.Rows[num].Cells[3].Value = true;


                    dragging = false;

                    //set your cursor back to the deafault

                }
                catch (Exception)
                {
                    dragging = false;
                    return;
                }

                Cursor = Cursors.Default;
            }
        }

        private void genericInformationDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                genericInformationtreeView.Nodes.Clear();

                TreeNode parentNode;
                TreeNode childNodes;

                var AutomationMLDataTables = new AutomationMLDataTables();
                genericInformationDataGridView.CurrentRow.Selected = true;


                if (genericInformationDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    string SRCSerialNumber = genericInformationDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (Convert.ToBoolean(genericInformationDataGridView.CurrentRow.Cells[3].Value) == true)
                    {
                        genericparametersAttrDataGridView.Rows.Clear();

                        string SRC = genericInformationDataGridView.CurrentRow.Cells[1].Value.ToString();

                        foreach (var pair in searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber +
                                        ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" +
                                            SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC,
                                            pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC,
                                            pair.Value);
                                    }
                                }
                                catch (Exception)
                                {

                                    return;
                                }

                            }

                        }


                        parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                            "(" + SRCSerialNumber + ")" + SRC, 2);


                        foreach (var pair in searchAMLLibraryFile
                            .DictionaryForExternalInterfacesInstancesAttributesOfRoleClassLib)
                        {
                            if (pair.Key.Contains(SRC))
                            {
                                try
                                {
                                    if (device.DictionaryForExternalInterfacesUnderRoleClassofComponent.ContainsKey(
                                        "(" + SRCSerialNumber + ")" + pair.Key.ToString()))
                                    {
                                        device.DictionaryForExternalInterfacesUnderRoleClassofComponent.Remove(
                                            "(" + SRCSerialNumber + ")" + pair.Key.ToString());
                                        device.DictionaryForExternalInterfacesUnderRoleClassofComponent.Add(
                                            "(" + SRCSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForExternalInterfacesUnderRoleClassofComponent.Add(
                                            "(" + SRCSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                    }
                                }
                                catch (Exception)
                                {

                                    return;
                                }


                                childNodes = parentNode.Nodes.Add(pair.Key.Replace(SRC, "").ToString()
                                    , pair.Key.Replace(SRC, "").ToString(), 2);
                            }
                        }

                        genericInformationDataGridView.CurrentRow.Cells[3].Value = true;
                    }

                    if (Convert.ToBoolean(genericInformationDataGridView.CurrentRow.Cells[4].Value) == true)
                    {
                        genericparametersAttrDataGridView.Rows.Clear();
                        string SRC = genericInformationDataGridView.CurrentRow.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLComponentFile.DictionaryofRolesforAutomationComponenet)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber +
                                        ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" +
                                            SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC,
                                            pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC,
                                            pair.Value);
                                    }
                                }
                                catch (Exception)
                                {

                                    return;
                                }
                            }
                        }

                        parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC, "(" + SRCSerialNumber + ")" + SRC, 2);
                    }
                }

                vendorNameTextBox_Leave(new object(), new EventArgs());
                deviceNameTextBox_Leave(new object(), new EventArgs());
            }
            catch (Exception)
            {
                return;
            }
        }

        private void autoloadGenericInformationtreeView(TreeNode node)
        {
            string searchName = "";
            var AutomationMLDataTables = new AutomationMLDataTables();

            TreeNode targetNode = node;

            /* targetNode.SelectedImageIndex = targetNode.ImageIndex;*/
            genericparametersAttrDataGridView.Rows.Clear();

            try
            {
                if (targetNode.Parent != null)
                {
                    searchName = targetNode.Parent.Text + targetNode.Text;
                    genericDataHeaderLabel.Text = searchName;
                    foreach (var pair in device.DictionaryForExternalInterfacesUnderRoleClassofComponent)
                    {
                        if (pair.Key.ToString() == searchName)
                        {
                            DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                            AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, genericparametersAttrDataGridView, pair);
                        }

                    }
                }
                else
                {

                    searchName = targetNode.Text;
                    genericDataHeaderLabel.Text = searchName;
                    foreach (var pair in device.DictionaryForRoleClassofComponent)
                    {
                        if (pair.Key.ToString() == searchName)
                        {
                            DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                            AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, genericparametersAttrDataGridView, pair);

                        }

                    }
                }
            }
            catch (Exception) { }
        }

        private void genericInformationtreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string searchName = "";
            var AutomationMLDataTables = new AutomationMLDataTables();

            TreeNode targetNode = genericInformationtreeView.SelectedNode;

            /* targetNode.SelectedImageIndex = targetNode.ImageIndex;*/
            genericparametersAttrDataGridView.Rows.Clear();

            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (targetNode != null)
                    {
                        if (targetNode.Parent != null)
                        {
                            searchName = targetNode.Parent.Text + targetNode.Text;
                            genericDataHeaderLabel.Text = searchName;
                            foreach (var pair in device.DictionaryForExternalInterfacesUnderRoleClassofComponent)
                            {
                                if (pair.Key.ToString() == searchName)
                                {
                                    DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                                    AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, genericparametersAttrDataGridView, pair);
                                }

                            }
                        }
                        else
                        {

                            searchName = targetNode.Text;
                            genericDataHeaderLabel.Text = searchName;
                            foreach (var pair in device.DictionaryForRoleClassofComponent)
                            {
                                if (pair.Key.ToString() == searchName)
                                {
                                    DataTable AMLDataTable = AutomationMLDataTables.AMLAttributeParameters();
                                    AutomationMLDataTables.CreateDataTableWithColumns(AMLDataTable, genericparametersAttrDataGridView, pair);

                                }

                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void genericInformationtreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode targetNode = genericInformationtreeView.SelectedNode;

                targetNode.SelectedImageIndex = targetNode.ImageIndex;
            }
            catch (Exception) { }
        }

        private void deleterowsInelectricalInterfacesDataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                if (electricalInterfacesCollectionDataGridView.CurrentCell != null && electricalInterfacesCollectionDataGridView.Rows.Count != 0)
                {
                    int rowIndex = electricalInterfacesCollectionDataGridView.CurrentCell.RowIndex;
                    electricalInterfacesCollectionDataGridView.CurrentRow.Selected = true;

                    DataGridViewCell dataGridCell0 = electricalInterfacesCollectionDataGridView.Rows[rowIndex].Cells[0];
                    DataGridViewCell dataGridCell1 = electricalInterfacesCollectionDataGridView.Rows[rowIndex].Cells[1];

                    if (dataGridCell0.Value != null && dataGridCell1.Value != null)
                    {
                        string interfaceSerialNumber = dataGridCell0.Value.ToString();
                        string interfaceClass = dataGridCell1.Value.ToString();

                        try
                        {
                            if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                            {
                                device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                        foreach (var pair in searchAMLLibraryFile.DictionaryForExternalInterfacesInstanceAttributesofInterfaceClassLib)
                        {
                            if (pair.Key.Contains(interfaceClass))
                            {
                                try
                                {
                                    if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                    {
                                        device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());

                                    }

                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                            }
                        }
                        electricalInterfacesCollectionDataGridView.Rows.RemoveAt(rowIndex);
                    }
                }
            }
            catch (Exception) { }
        }

        private void deleteRoleClassButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (genericInformationDataGridView.CurrentCell != null)
                {
                    int rowIndex = genericInformationDataGridView.CurrentCell.RowIndex;
                    genericInformationDataGridView.CurrentRow.Selected = true;

                    DataGridViewCell dataGridCell0 = genericInformationDataGridView.Rows[rowIndex].Cells[0];
                    DataGridViewCell dataGridCell1 = genericInformationDataGridView.Rows[rowIndex].Cells[1];

                    if (dataGridCell0.Value != null && dataGridCell1.Value != null)
                    {
                        string interfaceSerialNumber = dataGridCell0.Value.ToString();
                        string interfaceClass = dataGridCell1.Value.ToString();


                        try
                        {
                            if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                            {
                                device.DictionaryForRoleClassofComponent.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);

                            }


                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        foreach (var pair in searchAMLLibraryFile.DictionaryForExternalInterfacesInstancesAttributesOfRoleClassLib)
                        {
                            if (pair.Key.Contains(interfaceClass))
                            {
                                try
                                {
                                    if (device.DictionaryForExternalInterfacesUnderRoleClassofComponent.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                    {
                                        device.DictionaryForExternalInterfacesUnderRoleClassofComponent.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());

                                    }

                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                        }

                        genericInformationDataGridView.Rows.RemoveAt(rowIndex);

                    }

                }
            }
            catch (Exception) { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vendorNameTextBox.Text == "" && deviceNameTextBox.Text == "")
            {
                MessageBox.Show("Enter Vendor Name and Device Name before saving an Automation Component", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (vendorNameTextBox.Text == "")
            {
                MessageBox.Show("Error no vendor name set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (deviceNameTextBox.Text == "")
            {
                MessageBox.Show("Error no device name set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var pair in device.DictionaryForRoleClassofComponent)
            {
                foreach (var valueList in pair.Value)
                {
                    foreach (var item in valueList)
                    {
                        var attributeName = item.AttributePath.ToString();

                        if (attributeName.Equals("IdentificationData.Manufacturer") || attributeName.Equals("IdentificationData.DeviceClass") || attributeName.Equals("IdentificationData.Model") || attributeName.Equals("IdentificationData.ProductCode"))
                        {
                            if (item.Value == null)
                            {
                                MessageBox.Show("Error no " + attributeName.Split('.')[1] + " set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (attributeName.Equals("IdentificationData.ManufacturerURI"))
                        {
                            if (item.Value == null)
                            {
                                MessageBox.Show("Error no " + attributeName.Split('.')[1] + " set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (!item.Value.StartsWith("https://") && !item.Value.StartsWith("http://") && !item.Value.StartsWith("www.") && !item.Value.StartsWith("WWW.") && !item.Value.StartsWith("/"))
                                {
                                    MessageBox.Show("Error " + attributeName.Split('.')[1] + " is not valid!", "URI not valid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            device.vendorName = vendorNameTextBox.Text;

            device.deviceName = deviceNameTextBox.Text;


            device.dataGridAttachablesParametrsList = new List<AttachablesDataGridViewParameters>();
            if (attachablesInfoDataGridView != null)
            {
                int i = 0;
                int j = attachablesInfoDataGridView.Rows.Count - 1;
                if (i <= 0)
                {
                    while (i < j)
                    {

                        AttachablesDataGridViewParameters parametersFromAttachablesDataGrid = new AttachablesDataGridViewParameters();

                        try
                        {
                            parametersFromAttachablesDataGrid.ElementName = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[0].Value);
                            parametersFromAttachablesDataGrid.FilePath = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[1].Value);
                            parametersFromAttachablesDataGrid.AddToFile = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[2].Value);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); }

                        device.dataGridAttachablesParametrsList.Add(parametersFromAttachablesDataGrid);
                        i++;
                    }
                }
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "AML Files( *.amlx )| *.amlx;",
                    FileName = vendorNameTextBox.Text + "-" + deviceNameTextBox.Text + "-V.1.0-" + DateTime.Now.Date.ToShortDateString()
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    device.filepath = Path.GetDirectoryName(saveFileDialog.FileName);
                    device.environment = Path.GetDirectoryName(saveFileDialog.FileName);
                    device.fileName = saveFileDialog.FileName;

                    // storing user defined values of Attachebles data grid view in to list 

                    // Pass the device to the controller
                    string result1 = mWController.CreateDeviceOnClick(device, isEditing, useCaex2_15);

                    //clear();

                    // Display the result
                    if (result1 != null)
                    {
                        // Display Dialog
                        MessageBox.Show(result1, "Automation Component Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void saveeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vendorNameTextBox.Text == "" && deviceNameTextBox.Text == "")
            {
                MessageBox.Show("Enter Vendor Name and Device Name before saving an Automation Component", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (vendorNameTextBox.Text == "")
            {
                MessageBox.Show("Error no vendor name set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (deviceNameTextBox.Text == "")
            {
                MessageBox.Show("Error no device name set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var pair in device.DictionaryForRoleClassofComponent)
            {
                foreach (var valueList in pair.Value)
                {
                    foreach (var item in valueList)
                    {
                        var attributeName = item.AttributePath.ToString();

                        if (attributeName.Equals("IdentificationData.Manufacturer") || attributeName.Equals("IdentificationData.DeviceClass") || attributeName.Equals("IdentificationData.Model") || attributeName.Equals("IdentificationData.ProductCode"))
                        {
                            if (item.Value == null)
                            {
                                MessageBox.Show("Error no " + attributeName.Split('.')[1] + " set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else if (attributeName.Equals("IdentificationData.ManufacturerURI"))
                        {
                            if (item.Value == null)
                            {
                                MessageBox.Show("Error no " + attributeName.Split('.')[1] + " set!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                if (!item.Value.StartsWith("https://") && !item.Value.StartsWith("http://") && !item.Value.StartsWith("www.") && !item.Value.StartsWith("WWW.") && !item.Value.StartsWith("/"))
                                {
                                    MessageBox.Show("Error " + attributeName.Split('.')[1] + " is not valid!", "URI not valid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            device.vendorName = vendorNameTextBox.Text;

            device.deviceName = deviceNameTextBox.Text;


            device.dataGridAttachablesParametrsList = new List<AttachablesDataGridViewParameters>();
            if (attachablesInfoDataGridView != null)
            {
                int i = 0;
                int j = attachablesInfoDataGridView.Rows.Count - 1;
                if (i <= 0)
                {
                    while (i < j)
                    {

                        AttachablesDataGridViewParameters parametersFromAttachablesDataGrid = new AttachablesDataGridViewParameters();

                        try
                        {
                            parametersFromAttachablesDataGrid.ElementName = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[0].Value);
                            parametersFromAttachablesDataGrid.FilePath = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[1].Value);
                            parametersFromAttachablesDataGrid.AddToFile = Convert.ToString(attachablesInfoDataGridView.Rows[i].Cells[2].Value);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning); }

                        device.dataGridAttachablesParametrsList.Add(parametersFromAttachablesDataGrid);
                        i++;
                    }
                }
            }

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // saveFileDialog.Filter = "AML Files( *.amlx )| *.amlx;";
                saveFileDialog.FileName = vendorNameTextBox.Text + "-" + deviceNameTextBox.Text + "-V.1.0-" + DateTime.Now.Date.ToShortDateString();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {

                    device.filepath = Path.GetDirectoryName(saveFileDialog.FileName);
                    device.environment = Path.GetDirectoryName(saveFileDialog.FileName);
                    //filePathLabel.Text = Path.GetDirectoryName(saveFileDialog.FileName);
                    device.fileName = saveFileDialog.FileName;


                    // storing user defined values of Attachebles data grid view in to list 

                    // Pass the device to the controller
                    string result1 = mWController.CreateDeviceOnClick(device, isEditing, useCaex2_15);



                    //clear();

                    // Display the result
                    if (result1 != null)
                    {
                        // Display error Dialog
                        MessageBox.Show(result1, "Automation Component Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        newToolStripMenuItem_Click(sender, e);
                    }

                    device.DictionaryForInterfaceClassesInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
                    device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

                    device.DictionaryForRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
                    device.DictionaryForExternalInterfacesUnderRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
                    // Assigning values and parameters in "Identification data grid" to properties given in class "DatatableParametersCarrier" in MWDevice
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEditing = false;
            clear();


            loadStandardLibrary();
            checkForAutomtionComponent();

            foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "AutomationComponent{Class:  AutomationMLBaseRole}")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Environment.Exit(0);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string search = "https://github.com/H4CK3R-01/TINF20C_ModellingWizard_Devices/wiki/6.-User-Manual";
            System.Diagnostics.Process.Start(search);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEditing = true;

            searchAMLComponentFile.DictionaryofElectricalConnectorType = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            searchAMLComponentFile.DictioanryofElectricalConnectorPinType = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            searchAMLComponentFile.DictionaryofRolesforAutomationComponenet = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForExternalInterfacesUnderRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForInterfaceClassesInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictofElectricalInterfaceParameters = new Dictionary<string, List<ElectricalInterfaceParameters>>();

            CAEXDocument document = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "AML Files(*.aml; *.amlx;*.xml;*.AML )|*.aml; *.amlx;*.xml;*.AML;";


            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.FileName != null)
                {
                    clear();
                    device.filepath = Path.GetDirectoryName(open.FileName);

                    //open and load interfaces from file
                    try
                    {
                        treeViewRoleClassLib.Nodes.Clear();
                        treeViewInterfaceClassLib.Nodes.Clear();

                        string file = open.FileName;
                        FileInfo fileInfo = new FileInfo(file);
                        string objectName = fileInfo.Name;
                        string filetype = null;
                        if ((filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".amlx")
                        {
                            // Load the amlx container from the given filepath
                            AutomationMLContainer amlx = new AutomationMLContainer(file);

                            // Get the root path -> main .aml file
                            IEnumerable<PackagePart> rootParts = amlx.GetPartsByRelationShipType(AutomationMLContainer.RelationshipType.Root);

                            // We expect the aml to only have one root part
                            if (rootParts.Count() != 0 && rootParts.First() != null)
                            {

                                PackagePart part = rootParts.First();

                                // load the aml file as an CAEX document
                                document = CAEXDocument.LoadFromStream(part.GetStream());

                                // Iterate over all SystemUnitClassLibs and SystemUnitClasses and scan if it matches our format
                                // since we expect only one device per aml(x) file, return after on is found
                            }
                            amlx.Close();
                        }

                        if ((filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".aml" || (filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".xml")
                        {
                            document = CAEXDocument.LoadFromFile(file);
                        }

                        string referencedClassName = "";

                        foreach (var classLibType in document.CAEXFile.RoleClassLib)
                        {

                            TreeNode libNode = treeViewRoleClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);


                            foreach (var classType in classLibType.RoleClass)
                            {
                                TreeNode roleNode;

                                if (classType.ReferencedClassName != "")
                                {
                                    referencedClassName = classType.ReferencedClassName;
                                    roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);

                                    searchAMLLibraryFile.SearchForReferencedClassName(document, referencedClassName, classType);
                                    searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                                }
                                else
                                {
                                    roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                                }



                                if (classType.ExternalInterface.Exists)
                                {
                                    foreach (var externalinterface in classType.ExternalInterface)
                                    {
                                        TreeNode externalinterfacenode;

                                        if (externalinterface.BaseClass != null)
                                        {
                                            referencedClassName = externalinterface.BaseClass.ToString();
                                            externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                            externalinterfacenode.ForeColor = SystemColors.GrayText;
                                            searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(document, referencedClassName, classType, externalinterface);
                                            searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);


                                        }
                                        else
                                        {
                                            externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                            // searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                        }



                                        searchAMLLibraryFile.PrintExternalInterfaceNodes(document, externalinterfacenode, externalinterface, classType);
                                    }

                                }
                                searchAMLLibraryFile.PrintNodesRecursiveInRoleClassLib(document, roleNode, classType, referencedClassName);
                            }

                        }

                        foreach (var classLibType in document.CAEXFile.InterfaceClassLib)
                        {
                            // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classLibType.Name.ToString(), classLibType.ID.ToString());
                            TreeNode libNode = treeViewInterfaceClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);



                            foreach (var classType in classLibType.InterfaceClass)
                            {
                                TreeNode interfaceclassNode;
                                if (classType.ReferencedClassName != "")
                                {
                                    // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());

                                    referencedClassName = classType.ReferencedClassName;
                                    interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);
                                    searchAMLLibraryFile.SearchForReferencedClassName(document, referencedClassName, classType);
                                    searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                                }
                                else
                                {
                                    //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());

                                    interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                                }



                                if (classType.ExternalInterface.Exists)
                                {
                                    foreach (var externalinterface in classType.ExternalInterface)
                                    {
                                        TreeNode externalinterfacenode;

                                        if (externalinterface.BaseClass != null)
                                        {
                                            //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString()+ externalinterface.ToString(), externalinterface.ID.ToString());

                                            referencedClassName = externalinterface.BaseClass.ToString();
                                            externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                            externalinterfacenode.ForeColor = SystemColors.GrayText;

                                            searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(document, referencedClassName, classType, externalinterface);
                                            searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                        }
                                        else
                                        {
                                            //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString() + externalinterface.ToString(), externalinterface.ID.ToString());

                                            externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                        }


                                        searchAMLLibraryFile.PrintExternalInterfaceNodes(document, externalinterfacenode, externalinterface, classType);
                                    }
                                }
                                searchAMLLibraryFile.PrintNodesRecursiveInInterfaceClassLib(document, interfaceclassNode, classType, referencedClassName);
                            }

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Missing names of attributes or same attribute sequence is repeated in the given file", "Missing Names", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }



                    //open and load data from file
                    try
                    {
                        string file = open.FileName;
                        FileInfo fileInfo = new FileInfo(file);
                        string objectName = fileInfo.Name;

                        // DirectoryInfo directory = new DirectoryInfo(Path.GetDirectoryName(file));
                        string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                        Directory.CreateDirectory(tempDirectory);

                        DirectoryInfo directory = new DirectoryInfo(tempDirectory);
                        // Load the amlx container from the given filepath

                        AutomationMLContainer amlx = new AutomationMLContainer(file);

                        amlx.ExtractAllFiles(tempDirectory);

                        /*amlx.ExtractAllFiles(Path.GetDirectoryName(file));
                          Get the root path -> main .aml file*/
                        IEnumerable<PackagePart> rootParts = amlx.GetPartsByRelationShipType(AutomationMLContainer.RelationshipType.Root);


                        // We expect the aml to only have one root part
                        if (rootParts.First() != null)
                        {
                            PackagePart part = rootParts.First();

                            // load the aml file as an CAEX document
                            document = CAEXDocument.LoadFromStream(part.GetStream());
                        }

                        getAllInterfaces(treeViewInterfaceClassLib.Nodes);

                        foreach (var classLibType in document.CAEXFile.SystemUnitClassLib)
                        {
                            foreach (var classType in classLibType.SystemUnitClass)
                            {
                                if (classType.SupportedRoleClass.Exists)
                                {
                                    int i = 1;

                                    //Generic Data
                                    foreach (var SRC in classType.SupportedRoleClass)
                                    {
                                        if (classType.Attribute.Exists)
                                        {
                                            foreach (var attribute in classType.Attribute)
                                            {
                                                searchForComponentNames(attribute);
                                                if (attribute.Name == "Manufacturer")
                                                {
                                                    if (attribute.Value != null)
                                                    {
                                                        vendorNameTextBox.Text = attribute.Value;
                                                    }
                                                    else
                                                    {
                                                        vendorNameTextBox.Text = "No Vendor Name Set";
                                                    }
                                                }

                                                if (attribute.Name == "Model")
                                                {
                                                    if (attribute.Value != null)
                                                    {
                                                        deviceNameTextBox.Text = attribute.Value;
                                                    }
                                                    else
                                                    {
                                                        deviceNameTextBox.Text = "No Device Name Set";
                                                    }
                                                }
                                            }
                                        }

                                        searchAMLComponentFile.CheckForAttributesOfComponent(i, SRC, classType);

                                        int num = genericInformationDataGridView.Rows.Add();
                                        List<string> listofSerialNumbers = new List<string>();
                                        List<int> listofFinalSerialNumber = new List<int>();
                                        string number = "";
                                        int finalNumber = 0;
                                        int ultimatenumber = 0;
                                        if (genericInformationDataGridView.Rows.Count > 2)
                                        {
                                            foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
                                            {
                                                if (row.Cells[0].Value == null)
                                                {
                                                    number = "0";
                                                    listofSerialNumbers.Add(number);
                                                }

                                                if (row.Cells[0].Value != null)
                                                {
                                                    number = row.Cells[0].Value.ToString();
                                                    listofSerialNumbers.Add(number);
                                                }
                                            }

                                            foreach (string str in listofSerialNumbers)
                                            {
                                                finalNumber = Convert.ToInt32(str);
                                                listofFinalSerialNumber.Add(finalNumber);
                                            }

                                            ultimatenumber = listofFinalSerialNumber.Max();
                                            genericInformationDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                                        }
                                        else
                                        {
                                            genericInformationDataGridView.Rows[num].Cells[0].Value = 1;
                                        }

                                        genericInformationDataGridView.Rows[num].Cells[1].Value =
                                            "(" + i + ")" + SRC.RoleReference.ToString();
                                        genericInformationDataGridView.Rows[num].Cells[4].Value = true;

                                        genericInformationtreeView.Nodes.Clear();

                                        TreeNode parentNode;

                                        var AutomationMLDataTables = new AutomationMLDataTables();
                                        genericInformationDataGridView.CurrentRow.Selected = true;

                                        if (genericInformationDataGridView.Rows[num].Cells[0].Value != null)
                                        {
                                            string SRCSerialNumber = genericInformationDataGridView.Rows[num].Cells[0].Value.ToString();

                                            if (Convert.ToBoolean(genericInformationDataGridView.Rows[num].Cells[4].Value) == true)
                                            {
                                                genericparametersAttrDataGridView.Rows.Clear();
                                                string SRCName = genericInformationDataGridView.Rows[num].Cells[1].Value.ToString();
                                                foreach (var pair in searchAMLComponentFile.DictionaryofRolesforAutomationComponenet)
                                                {
                                                    if (pair.Key.ToString() == SRCName)
                                                    {
                                                        try
                                                        {
                                                            if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRCName))
                                                            {
                                                                device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRCName);
                                                                device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRCName, pair.Value);
                                                            }
                                                            else
                                                            {
                                                                device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRCName, pair.Value);
                                                            }
                                                        }
                                                        catch (Exception)
                                                        {
                                                            throw;
                                                        }
                                                    }
                                                }

                                                parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRCName, "(" + SRCSerialNumber + ")" + SRCName, 2);

                                                autoloadGenericInformationtreeView(parentNode);

                                            }
                                        }

                                        vendorNameTextBox_Leave(new object(), new EventArgs());
                                        deviceNameTextBox_Leave(new object(), new EventArgs());

                                        i++;
                                    }

                                    //Internal elements --> Interfaces and Attachments
                                    foreach (var internalElements in classType.InternalElement)
                                    {
                                        //Interface Code 
                                        if (internalElements.Name == "Interfaces" || internalElements.Name == "ElectricalInterfaces")
                                        {
                                            int counter = 1;
                                            foreach (var subinternalElements in internalElements.InternalElement)
                                            {
                                                foreach (var electricalConnectorType in subinternalElements
                                                    .ExternalInterface)
                                                {

                                                    if (electricalConnectorType != null)
                                                    {

                                                        searchAMLComponentFile.CheckForAttributesOfExternalIterface(counter,
                                                            electricalConnectorType);

                                                        int num = electricalInterfacesCollectionDataGridView.Rows.Add();
                                                        List<string> listofSerialNumbers = new List<string>();
                                                        List<int> listofFinalSerialNumber = new List<int>();
                                                        string number = "";
                                                        int finalNumber = 0;
                                                        int ultimatenumber = 0;
                                                        if (electricalInterfacesCollectionDataGridView.Rows.Count > 2)
                                                        {
                                                            foreach (DataGridViewRow row in
                                                                electricalInterfacesCollectionDataGridView.Rows)
                                                            {
                                                                if (row.Cells[0].Value == null)
                                                                {
                                                                    number = "0";
                                                                    listofSerialNumbers.Add(number);
                                                                }

                                                                if (row.Cells[0].Value != null)
                                                                {
                                                                    number = row.Cells[0].Value.ToString();
                                                                    listofSerialNumbers.Add(number);
                                                                }
                                                            }

                                                            foreach (string str in listofSerialNumbers)
                                                            {
                                                                finalNumber = Convert.ToInt32(str);
                                                                listofFinalSerialNumber.Add(finalNumber);
                                                            }

                                                            ultimatenumber = listofFinalSerialNumber.Max();
                                                            electricalInterfacesCollectionDataGridView.Rows[num].Cells[0]
                                                                .Value = ++ultimatenumber;
                                                        }
                                                        else
                                                        {
                                                            electricalInterfacesCollectionDataGridView.Rows[num].Cells[0]
                                                                .Value = 1;
                                                        }

                                                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[1]
                                                                .Value = "(" + counter + ")" +
                                                                         electricalConnectorType.Name.ToString()
                                                                         + "{" + "Class:" + "  " +
                                                                         electricalConnectorType.BaseClass + "}";
                                                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[4]
                                                            .Value = true;


                                                        foreach (var electricalConnectorPins in electricalConnectorType
                                                            .ExternalInterface)
                                                        {
                                                            if (electricalConnectorPins != null)
                                                            {
                                                                searchAMLComponentFile
                                                                    .CheckForAttributesOfEclectricalConnectorPins(counter,
                                                                        electricalConnectorPins, electricalConnectorType);
                                                            }
                                                        }


                                                        treeViewElectricalInterfaces.Nodes.Clear();

                                                        TreeNode parentNode;
                                                        TreeNode childNodes;



                                                        if (electricalInterfacesCollectionDataGridView.Rows[num].Cells[0]
                                                            .Value != null)
                                                        {
                                                            string interfaceSerialNumber =
                                                                electricalInterfacesCollectionDataGridView.Rows[num]
                                                                    .Cells[0].Value.ToString();


                                                            if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView
                                                                .Rows[num].Cells[4].Value) == true)
                                                            {
                                                                elecInterAttDataGridView.Rows.Clear();
                                                                string interfaceClass =
                                                                    electricalInterfacesCollectionDataGridView.Rows[num]
                                                                        .Cells[1].Value.ToString();
                                                                foreach (var pair in searchAMLComponentFile
                                                                    .DictionaryofElectricalConnectorType)
                                                                {
                                                                    if (pair.Key.ToString() == interfaceClass)
                                                                    {
                                                                        try
                                                                        {
                                                                            if (device
                                                                                .DictionaryForInterfaceClassesInElectricalInterfaces
                                                                                .ContainsKey("(" + interfaceSerialNumber +
                                                                                    ")" + interfaceClass))
                                                                            {
                                                                                device
                                                                                    .DictionaryForInterfaceClassesInElectricalInterfaces
                                                                                    .Remove("(" + interfaceSerialNumber +
                                                                                        ")" + interfaceClass);
                                                                                device
                                                                                    .DictionaryForInterfaceClassesInElectricalInterfaces
                                                                                    .Add(
                                                                                        "(" + interfaceSerialNumber + ")" +
                                                                                        interfaceClass, pair.Value);
                                                                            }
                                                                            else
                                                                            {
                                                                                device
                                                                                    .DictionaryForInterfaceClassesInElectricalInterfaces
                                                                                    .Add(
                                                                                        "(" + interfaceSerialNumber + ")" +
                                                                                        interfaceClass, pair.Value);
                                                                            }
                                                                        }
                                                                        catch (Exception)
                                                                        {
                                                                            throw;
                                                                        }
                                                                    }
                                                                }

                                                                parentNode =
                                                                    treeViewElectricalInterfaces.Nodes.Add(
                                                                        "(" + interfaceSerialNumber + ")" + interfaceClass,
                                                                        "(" + interfaceSerialNumber + ")" + interfaceClass,
                                                                        2);

                                                                foreach (var pair in searchAMLComponentFile
                                                                    .DictioanryofElectricalConnectorPinType)
                                                                {
                                                                    if (pair.Key.Contains(interfaceClass))
                                                                    {
                                                                        try
                                                                        {
                                                                            if (device
                                                                                .DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                                                .ContainsKey("(" + interfaceSerialNumber +
                                                                                    ")" + pair.Key.ToString()))
                                                                            {
                                                                                device
                                                                                    .DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                                                    .Remove("(" + interfaceSerialNumber +
                                                                                        ")" + pair.Key.ToString());
                                                                                device
                                                                                    .DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                                                    .Add(
                                                                                        "(" + interfaceSerialNumber + ")" +
                                                                                        pair.Key.ToString(), pair.Value);
                                                                            }
                                                                            else
                                                                            {
                                                                                device
                                                                                    .DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces
                                                                                    .Add(
                                                                                        "(" + interfaceSerialNumber + ")" +
                                                                                        pair.Key.ToString(), pair.Value);
                                                                            }
                                                                        }
                                                                        catch (Exception)
                                                                        {

                                                                            throw;
                                                                        }


                                                                        childNodes = parentNode.Nodes.Add(
                                                                            pair.Key.Replace(interfaceClass, "").ToString()
                                                                            , pair.Key.Replace(interfaceClass, "").ToString(),
                                                                            2);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                                counter++;
                                            }
                                        }

                                        //Try Attachment, sonst Fehler
                                        else
                                        {
                                            //Attachment Code
                                            if (internalElements.Name != "Interfaces" && internalElements.Name != "ElectricalInterfaces" && internalElements.Name != "DeviceIdentification")
                                            {
                                                int num = attachablesInfoDataGridView.Rows.Add();
                                                attachablesInfoDataGridView.Rows[num].Cells[0].Value = internalElements.Name;
                                                foreach (var externalInterface in internalElements.ExternalInterface)
                                                {

                                                    foreach (var attribute in externalInterface.Attribute)
                                                    {
                                                        if (attribute.Value != null)
                                                        {
                                                            if (attribute.Value.Contains("https://") ||
                                                            attribute.Value.Contains("http://") ||
                                                            attribute.Value.Contains("www") || attribute.Value.Contains("WWW"))
                                                            {
                                                                attachablesInfoDataGridView.Rows[num].Cells[1].Value =
                                                                    attribute.Value;
                                                                attachablesInfoDataGridView.Rows[num].Cells[2].Value = true;
                                                            }

                                                            foreach (FileInfo fileInfo1 in directory.GetFiles())
                                                            {
                                                                string name = attribute.Value.ToString();
                                                                if (name.Contains("%20"))
                                                                {
                                                                    name = Uri.UnescapeDataString(name);
                                                                }

                                                                if (name.Contains("%28") || name.Contains("%29"))
                                                                {
                                                                    name = Uri.UnescapeDataString(name);
                                                                }

                                                                if (name.Contains(fileInfo1.ToString()))
                                                                {
                                                                    attachablesInfoDataGridView.Rows[num].Cells[1].Value =
                                                                        fileInfo1.FullName;
                                                                    attachablesInfoDataGridView.Rows[num].Cells[2].Value = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            //Fehlermeldung
                                            else
                                            {
                                                MessageBox.Show("An error occurred while loading internal elements:  " + internalElements.Name, "Error loading element", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (var classTypeTwo in classType.SystemUnitClass)
                                    {
                                        int i = 1;

                                        //Generic Data
                                        foreach (var SRC in classTypeTwo.SupportedRoleClass)
                                        {
                                            if (classTypeTwo.Attribute.Exists)
                                            {
                                                foreach (var attribute in classTypeTwo.Attribute)
                                                {
                                                    searchForComponentNames(attribute);
                                                    if (attribute.Name == "Manufacturer")
                                                    {
                                                        if (attribute.Value != null)
                                                        {
                                                            vendorNameTextBox.Text = attribute.Value;
                                                        }
                                                        else
                                                        {
                                                            vendorNameTextBox.Text = "No Vendor Name Set";
                                                        }
                                                    }

                                                    if (attribute.Name == "Model")
                                                    {
                                                        if (attribute.Value != null)
                                                        {
                                                            deviceNameTextBox.Text = attribute.Value;
                                                        }
                                                        else
                                                        {
                                                            deviceNameTextBox.Text = "No Device Name Set";
                                                        }
                                                    }
                                                }
                                            }

                                            searchAMLComponentFile.CheckForAttributesOfComponent(i, SRC, classTypeTwo);

                                            int num = genericInformationDataGridView.Rows.Add();
                                            List<string> listofSerialNumbers = new List<string>();
                                            List<int> listofFinalSerialNumber = new List<int>();
                                            string number = "";
                                            int finalNumber = 0;
                                            int ultimatenumber = 0;
                                            if (genericInformationDataGridView.Rows.Count > 2)
                                            {
                                                foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
                                                {
                                                    if (row.Cells[0].Value == null)
                                                    {
                                                        number = "0";
                                                        listofSerialNumbers.Add(number);
                                                    }

                                                    if (row.Cells[0].Value != null)
                                                    {
                                                        number = row.Cells[0].Value.ToString();
                                                        listofSerialNumbers.Add(number);
                                                    }
                                                }

                                                foreach (string str in listofSerialNumbers)
                                                {
                                                    finalNumber = Convert.ToInt32(str);
                                                    listofFinalSerialNumber.Add(finalNumber);
                                                }

                                                ultimatenumber = listofFinalSerialNumber.Max();
                                                genericInformationDataGridView.Rows[num].Cells[0].Value =
                                                    ++ultimatenumber;
                                            }
                                            else
                                            {
                                                genericInformationDataGridView.Rows[num].Cells[0].Value = 1;
                                            }

                                            genericInformationDataGridView.Rows[num].Cells[1].Value =
                                                "(" + i + ")" + SRC.RoleReference.ToString();
                                            genericInformationDataGridView.Rows[num].Cells[4].Value = true;

                                            genericInformationtreeView.Nodes.Clear();

                                            TreeNode parentNode;

                                            var AutomationMLDataTables = new AutomationMLDataTables();
                                            genericInformationDataGridView.CurrentRow.Selected = true;

                                            if (genericInformationDataGridView.Rows[num].Cells[0].Value != null)
                                            {
                                                string SRCSerialNumber = genericInformationDataGridView.Rows[num]
                                                    .Cells[0].Value.ToString();

                                                if (Convert.ToBoolean(genericInformationDataGridView.Rows[num].Cells[4]
                                                    .Value) == true)
                                                {
                                                    genericparametersAttrDataGridView.Rows.Clear();
                                                    string SRCName = genericInformationDataGridView.Rows[num].Cells[1]
                                                        .Value.ToString();
                                                    foreach (var pair in searchAMLComponentFile
                                                        .DictionaryofRolesforAutomationComponenet)
                                                    {
                                                        if (pair.Key.ToString() == SRCName)
                                                        {
                                                            try
                                                            {
                                                                if (device.DictionaryForRoleClassofComponent
                                                                    .ContainsKey("(" + SRCSerialNumber + ")" + SRCName))
                                                                {
                                                                    device.DictionaryForRoleClassofComponent.Remove(
                                                                        "(" + SRCSerialNumber + ")" + SRCName);
                                                                    device.DictionaryForRoleClassofComponent.Add(
                                                                        "(" + SRCSerialNumber + ")" + SRCName,
                                                                        pair.Value);
                                                                }
                                                                else
                                                                {
                                                                    device.DictionaryForRoleClassofComponent.Add(
                                                                        "(" + SRCSerialNumber + ")" + SRCName,
                                                                        pair.Value);
                                                                }
                                                            }
                                                            catch (Exception)
                                                            {
                                                                throw;
                                                            }
                                                        }
                                                    }

                                                    parentNode = genericInformationtreeView.Nodes.Add(
                                                        "(" + SRCSerialNumber + ")" + SRCName,
                                                        "(" + SRCSerialNumber + ")" + SRCName, 2);

                                                    autoloadGenericInformationtreeView(parentNode);

                                                }
                                            }

                                            vendorNameTextBox_Leave(new object(), new EventArgs());
                                            deviceNameTextBox_Leave(new object(), new EventArgs());

                                            i++;
                                        }

                                        //Internal elements --> Interfaces and Attachments
                                        foreach (var internalElements in classTypeTwo.InternalElement)
                                        {
                                            if (internalElements.IsDocumentElement())
                                            {
                                                foreach (var intface in internalElements.ExternalInterface)
                                                {
                                                    //Code for Interfaces 
                                                    if (AllInterfaces.Contains(intface.BaseClass.Name) && intface.BaseClass.Name != "ExternalDataConnector" && intface.BaseClass.Name != "ExternalDataReference")
                                                    {
                                                        int counter = 1;

                                                        if (intface != null)
                                                        {
                                                            searchAMLComponentFile.CheckForAttributesOfExternalIterface(counter, intface);

                                                            int num = electricalInterfacesCollectionDataGridView.Rows.Add();
                                                            List<string> listofSerialNumbers = new List<string>();
                                                            List<int> listofFinalSerialNumber = new List<int>();
                                                            string number = "";
                                                            int finalNumber = 0;
                                                            int ultimatenumber = 0;

                                                            if (electricalInterfacesCollectionDataGridView.Rows.Count > 2)
                                                            {
                                                                foreach (DataGridViewRow row in electricalInterfacesCollectionDataGridView.Rows)
                                                                {
                                                                    if (row.Cells[0].Value == null)
                                                                    {
                                                                        number = "0";
                                                                        listofSerialNumbers.Add(number);
                                                                    }

                                                                    if (row.Cells[0].Value != null)
                                                                    {
                                                                        number = row.Cells[0].Value.ToString();
                                                                        listofSerialNumbers.Add(number);
                                                                    }
                                                                }

                                                                foreach (string str in listofSerialNumbers)
                                                                {
                                                                    finalNumber = Convert.ToInt32(str);
                                                                    listofFinalSerialNumber.Add(finalNumber);
                                                                }

                                                                ultimatenumber = listofFinalSerialNumber.Max();
                                                                electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                                                            }
                                                            else
                                                            {
                                                                electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = 1;
                                                            }

                                                            electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value = "(" + counter + ")" + intface.Name.ToString() + "{" + "Class:" + "  " + intface.BaseClass + "}";
                                                            electricalInterfacesCollectionDataGridView.Rows[num].Cells[4].Value = true;

                                                            foreach (var electricalConnectorPins in intface.ExternalInterface)
                                                            {
                                                                if (electricalConnectorPins != null)
                                                                {
                                                                    searchAMLComponentFile.CheckForAttributesOfEclectricalConnectorPins(counter, electricalConnectorPins, intface);
                                                                }
                                                            }

                                                            treeViewElectricalInterfaces.Nodes.Clear();

                                                            TreeNode parentNode;
                                                            TreeNode childNodes;


                                                            if (electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value != null)
                                                            {
                                                                string interfaceSerialNumber = electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value.ToString();

                                                                if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.Rows[num].Cells[4].Value) == true)
                                                                {
                                                                    elecInterAttDataGridView.Rows.Clear();
                                                                    string interfaceClass = electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value.ToString();

                                                                    foreach (var pair in searchAMLComponentFile.DictionaryofElectricalConnectorType)
                                                                    {
                                                                        if (pair.Key.ToString() == interfaceClass)
                                                                        {
                                                                            try
                                                                            {
                                                                                if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                                                                                {
                                                                                    device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);
                                                                                    device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                                                                }
                                                                                else
                                                                                {
                                                                                    device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                                                                }
                                                                            }
                                                                            catch (Exception)
                                                                            {
                                                                                throw;
                                                                            }
                                                                        }
                                                                    }

                                                                    parentNode = treeViewElectricalInterfaces.Nodes.Add("(" + interfaceSerialNumber + ")" + interfaceClass, "(" + interfaceSerialNumber + ")" + interfaceClass, 2);

                                                                    foreach (var pair in searchAMLComponentFile.DictioanryofElectricalConnectorPinType)
                                                                    {
                                                                        if (pair.Key.Contains(interfaceClass))
                                                                        {
                                                                            try
                                                                            {
                                                                                if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                                                                {
                                                                                    device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                                                                    device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                                                                }
                                                                                else
                                                                                {
                                                                                    device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                                                                }
                                                                            }
                                                                            catch (Exception)
                                                                            {

                                                                                throw;
                                                                            }


                                                                            childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString(), pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        counter++;
                                                    }

                                                    //Try Attachment, sonst Fehler
                                                    else
                                                    {
                                                        //Code for Attachables
                                                        if (internalElements.Name != "Interfaces" && internalElements.Name != "ElectricalInterfaces" && internalElements.Name != "DeviceIdentification")
                                                        {
                                                            int num = attachablesInfoDataGridView.Rows.Add();
                                                            attachablesInfoDataGridView.Rows[num].Cells[0].Value =
                                                                internalElements.Name;
                                                            foreach (var externalInterface in internalElements.ExternalInterface)
                                                            {
                                                                foreach (var attribute in externalInterface.Attribute)
                                                                {
                                                                    if (attribute.Value != null)
                                                                    {
                                                                        if (attribute.Value.Contains("https://") ||
                                                                        attribute.Value.Contains("http://") ||
                                                                        attribute.Value.Contains("www") ||
                                                                        attribute.Value.Contains("WWW"))
                                                                        {
                                                                            attachablesInfoDataGridView.Rows[num].Cells[1]
                                                                                    .Value =
                                                                                attribute.Value;
                                                                            attachablesInfoDataGridView.Rows[num].Cells[2]
                                                                                .Value = true;
                                                                        }

                                                                        foreach (FileInfo fileInfo1 in directory.GetFiles())
                                                                        {
                                                                            string name = attribute.Value.ToString();
                                                                            if (name.Contains("%20"))
                                                                            {
                                                                                //name.Replace("%20", " ");
                                                                                name = Uri.UnescapeDataString(name);
                                                                            }

                                                                            if (name.Contains("%28") || name.Contains("%29"))
                                                                            {
                                                                                name = Uri.UnescapeDataString(name);
                                                                            }

                                                                            if (name.Contains(fileInfo1.ToString()))
                                                                            {
                                                                                attachablesInfoDataGridView.Rows[num].Cells[1]
                                                                                        .Value =
                                                                                    fileInfo1.FullName;
                                                                                attachablesInfoDataGridView.Rows[num].Cells[2]
                                                                                    .Value = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        //Fehlermeldung
                                                        else
                                                        {
                                                            MessageBox.Show("An error occurred while loading internal elements:  " + internalElements.Name, "Error loading element", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (var internalElementsTwo in internalElements.InternalElement)
                                                {
                                                    foreach (var intface in internalElementsTwo.ExternalInterface)
                                                    {

                                                        if (intface.BaseClass != null)
                                                        {
                                                            //Code for Interfaces 
                                                            if (AllInterfaces.Contains(intface.BaseClass.Name) && intface.BaseClass.Name != "ExternalDataConnector" && intface.BaseClass.Name != "ExternalDataReference")
                                                            {
                                                                int counter = 1;

                                                                if (intface != null)
                                                                {
                                                                    searchAMLComponentFile.CheckForAttributesOfExternalIterface(counter, intface);

                                                                    int num = electricalInterfacesCollectionDataGridView.Rows.Add();
                                                                    List<string> listofSerialNumbers = new List<string>();
                                                                    List<int> listofFinalSerialNumber = new List<int>();
                                                                    string number = "";
                                                                    int finalNumber = 0;
                                                                    int ultimatenumber = 0;

                                                                    if (electricalInterfacesCollectionDataGridView.Rows.Count > 2)
                                                                    {
                                                                        foreach (DataGridViewRow row in electricalInterfacesCollectionDataGridView.Rows)
                                                                        {
                                                                            if (row.Cells[0].Value == null)
                                                                            {
                                                                                number = "0";
                                                                                listofSerialNumbers.Add(number);
                                                                            }

                                                                            if (row.Cells[0].Value != null)
                                                                            {
                                                                                number = row.Cells[0].Value.ToString();
                                                                                listofSerialNumbers.Add(number);
                                                                            }
                                                                        }

                                                                        foreach (string str in listofSerialNumbers)
                                                                        {
                                                                            finalNumber = Convert.ToInt32(str);
                                                                            listofFinalSerialNumber.Add(finalNumber);
                                                                        }

                                                                        ultimatenumber = listofFinalSerialNumber.Max();
                                                                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                                                                    }
                                                                    else
                                                                    {
                                                                        electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = 1;
                                                                    }

                                                                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value = "(" + counter + ")" + intface.Name.ToString() + "{" + "Class:" + "  " + intface.BaseClass + "}";
                                                                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[4].Value = true;

                                                                    foreach (var electricalConnectorPins in intface.ExternalInterface)
                                                                    {
                                                                        if (electricalConnectorPins != null)
                                                                        {
                                                                            searchAMLComponentFile.CheckForAttributesOfEclectricalConnectorPins(counter, electricalConnectorPins, intface);
                                                                        }
                                                                    }

                                                                    treeViewElectricalInterfaces.Nodes.Clear();


                                                                    TreeNode parentNode;
                                                                    TreeNode childNodes;


                                                                    if (electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value != null)
                                                                    {
                                                                        string interfaceSerialNumber = electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value.ToString();

                                                                        if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.Rows[num].Cells[4].Value) == true)
                                                                        {
                                                                            elecInterAttDataGridView.Rows.Clear();
                                                                            string interfaceClass = electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value.ToString();

                                                                            foreach (var pair in searchAMLComponentFile.DictionaryofElectricalConnectorType)
                                                                            {
                                                                                if (pair.Key.ToString() == interfaceClass)
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        if (device.DictionaryForInterfaceClassesInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                                                                                        {
                                                                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);
                                                                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            device.DictionaryForInterfaceClassesInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + interfaceClass, pair.Value);
                                                                                        }
                                                                                    }
                                                                                    catch (Exception)
                                                                                    {
                                                                                        throw;
                                                                                    }
                                                                                }
                                                                            }

                                                                            parentNode = treeViewElectricalInterfaces.Nodes.Add("(" + interfaceSerialNumber + ")" + interfaceClass, "(" + interfaceSerialNumber + ")" + interfaceClass, 2);

                                                                            foreach (var pair in searchAMLComponentFile.DictioanryofElectricalConnectorPinType)
                                                                            {
                                                                                if (pair.Key.Contains(interfaceClass))
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        if (device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                                                                        {
                                                                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());
                                                                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces.Add("(" + interfaceSerialNumber + ")" + pair.Key.ToString(), pair.Value);
                                                                                        }
                                                                                    }
                                                                                    catch (Exception)
                                                                                    {

                                                                                        throw;
                                                                                    }


                                                                                    childNodes = parentNode.Nodes.Add(pair.Key.Replace(interfaceClass, "").ToString(), pair.Key.Replace(interfaceClass, "").ToString(), 2);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                                counter++;
                                                            }

                                                            //Try Attachment, sonst Fehler
                                                            else
                                                            {
                                                                //Code for Attachables
                                                                if (internalElementsTwo.Name != "Interfaces" && internalElementsTwo.Name != "ElectricalInterfaces" && internalElementsTwo.Name != "DeviceIdentification")
                                                                {
                                                                    int num = attachablesInfoDataGridView.Rows.Add();
                                                                    attachablesInfoDataGridView.Rows[num].Cells[0].Value =
                                                                        internalElementsTwo.Name;
                                                                    foreach (var externalInterface in internalElementsTwo.ExternalInterface)
                                                                    {
                                                                        foreach (var attribute in externalInterface.Attribute)
                                                                        {
                                                                            Console.WriteLine(attribute);
                                                                            Console.WriteLine(attribute.Value);

                                                                            if (attribute.Value != null)
                                                                            {
                                                                                if (attribute.Value.Contains("https://") || attribute.Value.Contains("http://") || attribute.Value.Contains("www") || attribute.Value.Contains("WWW"))
                                                                                {
                                                                                    attachablesInfoDataGridView.Rows[num].Cells[1].Value = attribute.Value;
                                                                                    attachablesInfoDataGridView.Rows[num].Cells[2].Value = true;
                                                                                }

                                                                                foreach (FileInfo fileInfo1 in directory.GetFiles())
                                                                                {
                                                                                    string name = attribute.Value.ToString();
                                                                                    if (name.Contains("%20"))
                                                                                    {
                                                                                        //name.Replace("%20", " ");
                                                                                        name = Uri.UnescapeDataString(name);
                                                                                    }

                                                                                    if (name.Contains("%28") || name.Contains("%29"))
                                                                                    {
                                                                                        name = Uri.UnescapeDataString(name);
                                                                                    }

                                                                                    if (name.Contains(fileInfo1.ToString()))
                                                                                    {
                                                                                        attachablesInfoDataGridView.Rows[num].Cells[1]
                                                                                                .Value =
                                                                                            fileInfo1.FullName;
                                                                                        attachablesInfoDataGridView.Rows[num].Cells[2]
                                                                                            .Value = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                                //Fehlermeldung
                                                                else
                                                                {
                                                                    MessageBox.Show("An error occurred while loading internal elements:  " + internalElements.Name, "Error loading element", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        amlx.Close();
                    }
                    catch (Exception)
                    {
                        open.Dispose();
                        newToolStripMenuItem_Click(sender, e);
                        MessageBox.Show("An error occurred while open file." + "\n" + "The AML file structure is not allowed. Check if there are two different aml files and merge them. Another error could be the structure of your AML file.", "Error opening file", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void loadLibraryFile_Click(object sender, EventArgs e)
        {
            searchAMLLibraryFile.dictionaryofRoleClassattributes = new Dictionary<string, List<ClassOfListsFromReferencefile>>();

            searchAMLLibraryFile.DictionaryForInterfaceClassInstancesAttributes = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            searchAMLLibraryFile.DictionaryForExternalInterfacesInstanceAttributesofInterfaceClassLib = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            searchAMLLibraryFile.DictionaryForExternalInterfacesInstancesAttributesOfRoleClassLib = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();

            searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes = new Dictionary<string, string>();

            CAEXDocument document = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "AML Files(*.aml; *.amlx;*.xml;*.AML )|*.aml; *.amlx;*.xml;*.AML;";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    treeViewRoleClassLib.Nodes.Clear();
                    treeViewInterfaceClassLib.Nodes.Clear();

                    string file = open.FileName;
                    FileInfo fileInfo = new FileInfo(file);
                    string objectName = fileInfo.Name;
                    string filetype = null;
                    if ((filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".amlx")
                    {
                        // Load the amlx container from the given filepath
                        AutomationMLContainer amlx = new AutomationMLContainer(file);

                        // Get the root path -> main .aml file
                        IEnumerable<PackagePart> rootParts = amlx.GetPartsByRelationShipType(AutomationMLContainer.RelationshipType.Root);

                        // We expect the aml to only have one root part
                        if (rootParts.First() != null)
                        {

                            PackagePart part = rootParts.First();

                            // load the aml file as an CAEX document
                            document = CAEXDocument.LoadFromStream(part.GetStream());

                            // Iterate over all SystemUnitClassLibs and SystemUnitClasses and scan if it matches our format
                            // since we expect only one device per aml(x) file, return after on is found
                        }
                        amlx.Close();
                    }

                    if ((filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".aml" || (filetype = Convert.ToString(Path.GetExtension(open.FileName))) == ".xml")
                    {
                        document = CAEXDocument.LoadFromFile(file);
                    }

                    string referencedClassName = "";

                    foreach (var classLibType in document.CAEXFile.RoleClassLib)
                    {

                        TreeNode libNode = treeViewRoleClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);


                        foreach (var classType in classLibType.RoleClass)
                        {
                            TreeNode roleNode;

                            if (classType.ReferencedClassName != "")
                            {
                                referencedClassName = classType.ReferencedClassName;
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);

                                searchAMLLibraryFile.SearchForReferencedClassName(document, referencedClassName, classType);
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                            }
                            else
                            {
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }



                            if (classType.ExternalInterface.Exists)
                            {
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    if (externalinterface.BaseClass != null)
                                    {
                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;
                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(document, referencedClassName, classType, externalinterface);
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);


                                    }
                                    else
                                    {
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                        // searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }



                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(document, externalinterfacenode, externalinterface, classType);
                                }

                            }
                            searchAMLLibraryFile.PrintNodesRecursiveInRoleClassLib(document, roleNode, classType, referencedClassName);
                        }

                    }

                    foreach (var classLibType in document.CAEXFile.InterfaceClassLib)
                    {
                        // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classLibType.Name.ToString(), classLibType.ID.ToString());
                        TreeNode libNode = treeViewInterfaceClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);



                        foreach (var classType in classLibType.InterfaceClass)
                        {
                            TreeNode interfaceclassNode;
                            if (classType.ReferencedClassName != "")
                            {
                                // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());

                                referencedClassName = classType.ReferencedClassName;
                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);
                                searchAMLLibraryFile.SearchForReferencedClassName(document, referencedClassName, classType);
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);

                            }
                            else
                            {
                                //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());

                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }



                            if (classType.ExternalInterface.Exists)
                            {
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    if (externalinterface.BaseClass != null)
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString()+ externalinterface.ToString(), externalinterface.ID.ToString());

                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;

                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(document, referencedClassName, classType, externalinterface);
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }
                                    else
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString() + externalinterface.ToString(), externalinterface.ID.ToString());

                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                    }


                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(document, externalinterfacenode, externalinterface, classType);
                                }
                            }
                            searchAMLLibraryFile.PrintNodesRecursiveInInterfaceClassLib(document, interfaceclassNode, classType, referencedClassName);
                        }

                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Missing names of attributes or same attribute sequence is repeated in the given file", "Missing Names", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void asInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                TreeNode sourceNode = treeViewInterfaceClassLib.SelectedNode;

                int num = electricalInterfacesCollectionDataGridView.Rows.Add();
                List<string> listofSerialNumbers = new List<string>();
                List<int> listofFinalSerialNumber = new List<int>();
                string number = "";
                int finalNumber = 0;
                int ultimatenumber = 0;
                if (electricalInterfacesCollectionDataGridView.Rows.Count > 2)
                {
                    foreach (DataGridViewRow row in electricalInterfacesCollectionDataGridView.Rows)
                    {
                        if (row.Cells[0].Value == null)
                        {
                            number = "0";
                            listofSerialNumbers.Add(number);
                        }
                        if (row.Cells[0].Value != null)
                        {
                            number = row.Cells[0].Value.ToString();
                            listofSerialNumbers.Add(number);
                        }
                    }
                    foreach (string str in listofSerialNumbers)
                    {
                        finalNumber = Convert.ToInt32(str);
                        listofFinalSerialNumber.Add(finalNumber);
                    }
                    ultimatenumber = listofFinalSerialNumber.Max();
                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                }
                else
                {
                    electricalInterfacesCollectionDataGridView.Rows[num].Cells[0].Value = 1;
                }

                electricalInterfacesCollectionDataGridView.Rows[num].Cells[1].Value = sourceNode.Text;


            }
            catch (Exception)
            {
                MessageBox.Show("A whole Interface Library cannot be added ", "Select Parent Node to add Inetrface", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void dataTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //Size, Name, Style change...
                Font Font;

                //For forground color
                Brush foreBrush;

                //Aktueller Focus
                if (e.Index == this.dataTabControl.SelectedIndex)
                {
                    //This line of code will help you to change the appearance like size,name,style.
                    Font = e.Font;

                    //backBrush = new System.Drawing.SolidBrush(Color.Black);
                    foreBrush = Brushes.Black;
                    treeViewInterfaceClassLib.Visible = false;
                    treeViewRoleClassLib.Visible = false;
                    if (e.Index == 0)
                    {
                        //treeViewInterfaceClassLib.Nodes.Clear();
                        treeViewRoleClassLib.Visible = true;
                        treeViewInterfaceClassLib.Visible = false;
                    }
                    else if (e.Index == 1)
                    {
                        //treeViewRoleClassLib.Nodes.Clear();
                        treeViewInterfaceClassLib.Visible = true;
                        treeViewRoleClassLib.Visible = false;
                    }
                }
                else
                {
                    Font = e.Font;
                    //backBrush = new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                }

                //To set the alignment of the caption.
                string sTabName = this.dataTabControl.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                /*e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);*/
                Rectangle rect = e.Bounds;
                rect = new Rectangle(rect.X, rect.Y + 3, rect.Width, rect.Height - 3);
                e.Graphics.DrawString(sTabName, Font, foreBrush, rect, sf);

                sf.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void automationMLRoleCmbBx_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (automationMLRoleCmbBx.Text != null && attachablesInfoDataGridView.Rows.Count > 0)
            {

                string searchValue = automationMLRoleCmbBx.Text;
                string mid = "_";

                int result = 1;
                string end = Convert.ToString(result);
                string final = searchValue + mid + end;

                List<string> listofstrings = new List<string>();
                List<int> listofintegers = new List<int>();

                int i;
                int result3;
                string ultrafinal = String.Empty;
                attachablesInfoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in attachablesInfoDataGridView.Rows)
                {
                    try
                    {
                        if (row.Cells[0].Value == null)
                        {
                            AMLfileLabel.Text = automationMLRoleCmbBx.Text;
                            AMLURLLabel.Text = automationMLRoleCmbBx.Text;
                        }
                    }
                    catch (Exception)
                    {
                    }

                }

                foreach (DataGridViewRow eachrow in attachablesInfoDataGridView.Rows)
                {
                    try
                    {
                        if (eachrow.Cells[0].Value != null)
                        {
                            if (eachrow.Cells[0].Value.Equals(searchValue))
                            {

                                foreach (DataGridViewRow eachrow3 in attachablesInfoDataGridView.Rows)
                                {
                                    try
                                    {
                                        if (eachrow3.Cells[0].Value != null &&
                                            eachrow3.Cells[0].Value.ToString().Contains(searchValue))
                                        {
                                            string eachstringindataGridView = eachrow3.Cells[0].Value.ToString();
                                            listofstrings.Add(eachstringindataGridView);
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }

                                foreach (string eachstring in listofstrings)
                                {
                                    bool success =
                                        int.TryParse(
                                            new string(eachstring.SkipWhile(x => !char.IsDigit(x))
                                                .TakeWhile(x => char.IsDigit(x)).ToArray()), out i);
                                    if (success == false)
                                    {
                                        i = 0;
                                    }

                                    listofintegers.Add(i);
                                }

                                result3 = listofintegers.Max();

                                ultrafinal = searchValue + mid + Convert.ToString(++result3);

                                AMLfileLabel.Text = ultrafinal;
                                AMLURLLabel.Text = ultrafinal;

                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void automationMLRoleCmbBx_Click(object sender, EventArgs e)
        {
            if (automationMLRoleCmbBx.SelectedItem != null)
            {
            }
        }

        private void addRole_Click(object sender, EventArgs e)
        {

            if (automationMLRoleCmbBx.Text != null && attachablesInfoDataGridView.Rows.Count > 0)
            {

                string searchValue = automationMLRoleCmbBx.Text;
                string mid = "_";

                int result = 1;
                string end = Convert.ToString(result);
                string final = searchValue + mid + end;

                List<string> listofstrings = new List<string>();
                List<int> listofintegers = new List<int>();

                int i;
                int result3;
                string ultrafinal = String.Empty;
                attachablesInfoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewRow row in attachablesInfoDataGridView.Rows)
                {
                    try
                    {
                        if (row.Cells[0].Value == null)
                        {
                            AMLfileLabel.Text = automationMLRoleCmbBx.Text;
                            AMLURLLabel.Text = automationMLRoleCmbBx.Text;
                        }
                    }
                    catch (Exception) { }

                }
                foreach (DataGridViewRow eachrow in attachablesInfoDataGridView.Rows)
                {
                    try
                    {
                        if (eachrow.Cells[0].Value != null)
                        {
                            if (eachrow.Cells[0].Value.Equals(searchValue))
                            {

                                foreach (DataGridViewRow eachrow3 in attachablesInfoDataGridView.Rows)
                                {
                                    try
                                    {
                                        if (eachrow3.Cells[0].Value != null && eachrow3.Cells[0].Value.ToString().Contains(searchValue))
                                        {
                                            string eachstringindataGridView = eachrow3.Cells[0].Value.ToString();
                                            listofstrings.Add(eachstringindataGridView);
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                }
                                foreach (string eachstring in listofstrings)
                                {
                                    bool success = int.TryParse(new string(eachstring.SkipWhile(x => !char.IsDigit(x)).TakeWhile(x => char.IsDigit(x)).ToArray()), out i);
                                    if (success == false)
                                    {
                                        i = 0;
                                    }
                                    listofintegers.Add(i);
                                }

                                result3 = listofintegers.Max();

                                ultrafinal = searchValue + mid + Convert.ToString(++result3);

                                AMLfileLabel.Text = ultrafinal;
                                AMLURLLabel.Text = ultrafinal;
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
            if (automationMLRoleCmbBx.SelectedItem == null || automationMLRoleCmbBx.SelectedItem != null)
            {
                automationMLRoleCmbBx.DroppedDown = true;
            }
        }

        private void selectFileBtn_Click(object sender, EventArgs e)
        {
            if (AMLfileLabel.Text != "")
            {

                string filename = AMC.OpenFileDialog(selectedFileLocationTxtBx);
                if (selectedFileLocationTxtBx.Text != "")
                {

                    var index = attachablesInfoDataGridView.Rows.Add();
                    attachablesInfoDataGridView.Rows[index].Cells["ElementName"].Value = AMLfileLabel.Text;
                    attachablesInfoDataGridView.Rows[index].Cells["FilePath"].Value = selectedFileLocationTxtBx.Text;

                    selectedFileLocationTxtBx.Text = "";
                    AMLfileLabel.Text = "";
                    AMLURLLabel.Text = "";
                }
            }

            else
            {
                MessageBox.Show("Select AutomationML Role type from the combo box and Click Add button.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void selectURLBtn_Click(object sender, EventArgs e)
        {
            if (AMLURLLabel.Text != "")
            {
                if (selectedFileURLTextBox.Text != "")
                {
                    var index = attachablesInfoDataGridView.Rows.Add();
                    attachablesInfoDataGridView.Rows[index].Cells["ElementName"].Value = AMLURLLabel.Text;
                    attachablesInfoDataGridView.Rows[index].Cells["FilePath"].Value = selectedFileURLTextBox.Text;

                    AMLURLLabel.Text = "";
                    AMLfileLabel.Text = "";
                    selectedFileURLTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Select AutomationML Role type from the combo box and Click Add button.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clear()
        {
            vendorNameTextBox.Text = "";
            deviceNameTextBox.Text = "";
            genericDataHeaderLabel.Text = "";
            electricalInterfacesHeaderlabel.Text = "";
            genericInformationDataGridView.Rows.Clear();
            genericInformationtreeView.Nodes.Clear();
            genericparametersAttrDataGridView.Rows.Clear();
            attachablesInfoDataGridView.Rows.Clear();
            electricalInterfacesCollectionDataGridView.Rows.Clear();
            elecInterAttDataGridView.Rows.Clear();
            treeViewElectricalInterfaces.Nodes.Clear();


            device.DictionaryForInterfaceClassesInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();


            device.DictionaryForRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
            device.DictionaryForExternalInterfacesUnderRoleClassofComponent = new Dictionary<string, List<List<ClassOfListsFromReferencefile>>>();
        }

        public void selectLibrary(byte[] file)
        {
            CAEXDocument doc = null;
            doc = CAEXDocument.LoadFromBinary(file);
            try
            {

                string referencedClassName = "";
                foreach (var classLibType in doc.CAEXFile.RoleClassLib)
                {
                    bool decisiontoPrint = true;
                    foreach (TreeNode node in treeViewRoleClassLib.Nodes)
                    {
                        if (node.Name == classLibType.Name.ToString())
                        {
                            decisiontoPrint = false;
                            break;
                        }
                    }

                    if (decisiontoPrint == true)
                    {
                        TreeNode libNode = treeViewRoleClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);


                        foreach (var classType in classLibType.RoleClass)
                        {
                            TreeNode roleNode;

                            if (classType.ReferencedClassName != "")
                            {
                                referencedClassName = classType.ReferencedClassName;
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);

                                searchAMLLibraryFile.SearchForReferencedClassName(doc, referencedClassName, classType);
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);
                            }
                            else
                            {
                                roleNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }



                            if (classType.ExternalInterface.Exists)
                            {
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    if (externalinterface.BaseClass != null)
                                    {
                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;
                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(doc, referencedClassName, classType, externalinterface);
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }
                                    else
                                    {
                                        externalinterfacenode = roleNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;
                                        // searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }

                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(doc, externalinterfacenode, externalinterface, classType);
                                }
                            }
                            searchAMLLibraryFile.PrintNodesRecursiveInRoleClassLib(doc, roleNode, classType, referencedClassName);
                        }
                    }
                }


                foreach (var classLibType in doc.CAEXFile.InterfaceClassLib)
                {
                    bool decisiontoPrint = true;
                    foreach (TreeNode node in treeViewInterfaceClassLib.Nodes)
                    {
                        if (node.Name == classLibType.Name.ToString())
                        {
                            decisiontoPrint = false;
                            break;
                        }
                    }
                    if (decisiontoPrint == true)
                    {
                        // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classLibType.Name.ToString(), classLibType.ID.ToString());
                        TreeNode libNode = treeViewInterfaceClassLib.Nodes.Add(classLibType.ToString(), classLibType.ToString(), 0);

                        foreach (var classType in classLibType.InterfaceClass)
                        {
                            TreeNode interfaceclassNode;
                            if (classType.ReferencedClassName != "")
                            {
                                // searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());
                                referencedClassName = classType.ReferencedClassName;
                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 1);
                                searchAMLLibraryFile.SearchForReferencedClassName(doc, referencedClassName, classType);
                                searchAMLLibraryFile.CheckForAttributesOfReferencedClassName(classType);
                            }
                            else
                            {
                                //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString(), classType.ID.ToString());
                                interfaceclassNode = libNode.Nodes.Add(classType.ToString(), classType.ToString(), 1);
                            }


                            if (classType.ExternalInterface.Exists)
                            {
                                foreach (var externalinterface in classType.ExternalInterface)
                                {
                                    TreeNode externalinterfacenode;

                                    if (externalinterface.BaseClass != null)
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString()+ externalinterface.ToString(), externalinterface.ID.ToString());

                                        referencedClassName = externalinterface.BaseClass.ToString();
                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString() + "{" + "Class:" + "  " + referencedClassName + "}", 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;

                                        searchAMLLibraryFile.SearchForReferencedClassNameofExternalIterface(doc, referencedClassName, classType, externalinterface);
                                        searchAMLLibraryFile.CheckForAttributesOfReferencedClassNameofExternalIterface(classType, externalinterface);
                                    }
                                    else
                                    {
                                        //searchAMLLibraryFile.DictioanryOfIDofInterfaceClassLibraryNodes.Add(classType.Name.ToString() + externalinterface.ToString(), externalinterface.ID.ToString());
                                        externalinterfacenode = interfaceclassNode.Nodes.Add(externalinterface.ToString(), externalinterface.ToString(), 2);
                                        externalinterfacenode.ForeColor = SystemColors.GrayText;
                                    }

                                    searchAMLLibraryFile.PrintExternalInterfaceNodes(doc, externalinterfacenode, externalinterface, classType);
                                }
                            }
                            searchAMLLibraryFile.PrintNodesRecursiveInInterfaceClassLib(doc, interfaceclassNode, classType, referencedClassName);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Missing names of attributes or Same atrribute sequence is repeated in the given file", "Missing Names", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        public void checkForAutomtionComponent()
        {
            foreach (TreeNode node in treeViewRoleClassLib.Nodes)
            {
                if (node.Nodes != null)
                {
                    foreach (TreeNode childNode in node.Nodes)
                    {

                        if (childNode.Name == "AutomationMLBaseRole")
                        {
                            autoloadGenericInformationtreeView(childNode);
                        }

                        if (childNode.Name == "AutomationComponent")
                        {
                            autoloadGenericInformationtreeView(childNode);

                            int num = genericInformationDataGridView.Rows.Add();
                            List<string> listofSerialNumbers = new List<string>();
                            List<int> listofFinalSerialNumber = new List<int>();
                            string number = "";
                            int finalNumber = 0;
                            int ultimatenumber = 0;
                            if (genericInformationDataGridView.Rows.Count > 2)
                            {
                                foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
                                {
                                    if (row.Cells[0].Value == null)
                                    {
                                        number = "0";
                                        listofSerialNumbers.Add(number);
                                    }
                                    if (row.Cells[0].Value != null)
                                    {
                                        number = row.Cells[0].Value.ToString();
                                        listofSerialNumbers.Add(number);
                                    }
                                }
                                foreach (string str in listofSerialNumbers)
                                {
                                    finalNumber = Convert.ToInt32(str);
                                    listofFinalSerialNumber.Add(finalNumber);
                                }
                                ultimatenumber = listofFinalSerialNumber.Max();
                                genericInformationDataGridView.Rows[num].Cells[0].Value = ++ultimatenumber;
                            }
                            else
                            {
                                genericInformationDataGridView.Rows[num].Cells[0].Value = 1;
                            }

                            genericInformationDataGridView.Rows[num].Cells[1].Value = childNode.Text.ToString();
                            genericInformationDataGridView.Rows[num].Cells[3].Value = true;
                        }
                    }
                }
            }
        }

        public void searchForComponentNames(AttributeType classType)
        {
            if (classType.Attribute.Exists)
            {

                foreach (var attribute in classType.Attribute)
                {
                    searchForComponentNames(attribute);
                    if (attribute.Name == "Manufacturer")
                    {
                        if (attribute.Value != null)
                        {
                            vendorNameTextBox.Text = attribute.Value;
                        }
                        else
                        {
                            vendorNameTextBox.Text = "No Vendor Name Set";
                        }
                    }
                    if (attribute.Name == "Model")
                    {
                        if (attribute.Value != null)
                        {
                            deviceNameTextBox.Text = attribute.Value;
                        }
                        else
                        {
                            deviceNameTextBox.Text = "No Device Name Set";
                        }
                    }
                }
            }
        }

        private void elecInterAttDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            elecInterAttDataGridView.CurrentRow.Selected = true;

            string attributeName = "";
            string values = "";
            string defaults = "";
            string Units = "";
            string datatype = "";


            if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {
                    if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        attributeName = elecInterAttDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        values = elecInterAttDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        defaults = elecInterAttDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[3].Value != null)
                    {
                        Units = elecInterAttDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    }
                }
                catch (Exception)
                { }
                try
                {
                    if (elecInterAttDataGridView.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        datatype = elecInterAttDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                }
                catch (Exception)
                { }


                List<string> lists = new List<string>();
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)elecInterAttDataGridView.Rows[e.RowIndex].Cells[5];

                foreach (var refsemantic in dgvcbc.Items)
                {
                    try
                    {
                        if (refsemantic != null)
                        {
                            lists.Add(refsemantic.ToString());
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }


                //if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.CurrentRow.Cells[3].Value) == false)
                {
                    string interfaceClass = electricalInterfacesHeaderlabel.Text;
                    foreach (var pair in device.DictionaryForInterfaceClassesInElectricalInterfaces)
                    {
                        if (pair.Key.ToString() == interfaceClass)
                        {
                            foreach (var valueList in pair.Value)
                            {
                                foreach (var item in valueList)
                                {
                                    if (item.Name.ToString() == attributeName)
                                    {
                                        foreach (var pair2 in device.DictionaryForInterfaceClassesInElectricalInterfaces)
                                        {
                                            if (pair2.Key.ToString() == interfaceClass)
                                            {
                                                foreach (var valueList2 in pair2.Value)
                                                {
                                                    foreach (var item2 in valueList2)
                                                    {
                                                        if (item2.Name.ToString() == attributeName)
                                                        {
                                                            item2.RefSemanticList.Remove();
                                                            item2.Name = attributeName;
                                                            item2.Value = values;
                                                            item2.Default = defaults;
                                                            item2.Unit = Units;


                                                            foreach (var str in lists)
                                                            {
                                                                var refsems = item2.RefSemanticList.Append();
                                                                refsems.CorrespondingAttributePath = str;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var pair in device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces)
                    {
                        if (pair.Key.ToString() == interfaceClass)
                        {
                            foreach (var valueList in pair.Value)
                            {
                                foreach (var item in valueList)
                                {
                                    if (item.Name.ToString() == attributeName)
                                    {
                                        /* item.Value = values;
                                         item.Default = defaults;
                                         item.Unit = Units;
                                         item.Semantic = semantics;*/
                                        foreach (var pair2 in device.DictionaryForExternalInterfacesUnderInterfaceClassInElectricalInterfaces)
                                        {
                                            if (pair2.Key.ToString() == interfaceClass)
                                            {
                                                foreach (var valueList2 in pair2.Value)
                                                {
                                                    foreach (var item2 in valueList2)
                                                    {
                                                        if (item2.Name.ToString() == attributeName)
                                                        {
                                                            item2.RefSemanticList.Remove();
                                                            item2.Name = attributeName;
                                                            item2.Value = values;
                                                            item2.Default = defaults;
                                                            item2.Unit = Units;

                                                            foreach (var str in lists)
                                                            {
                                                                var refsems = item2.RefSemanticList.Append();
                                                                refsems.CorrespondingAttributePath = str;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            elecInterAttDataGridView.CurrentRow.Selected = false;
        }

        private void vendorNameTextBox_Leave(object sender, EventArgs e)
        {
            foreach (var pair in device.DictionaryForRoleClassofComponent)
            {
                if (pair.Key != null && pair.Key.ToString() == "(" + 1 + ")" + "AutomationComponent{Class:  AutomationMLBaseRole}")
                {
                    foreach (var valueList in pair.Value)
                    {
                        foreach (var item in valueList)
                        {
                            if (item.Name == "Manufacturer")
                            {
                                item.Value = vendorNameTextBox.Text;
                            }
                        }
                    }
                }
                if (pair.Key != null && pair.Key.Contains("(" + 1 + ")"))
                {
                    foreach (var valueList in pair.Value)
                    {
                        foreach (var item in valueList)
                        {
                            if (item.Name == "Manufacturer")
                            {
                                item.Value = vendorNameTextBox.Text;
                            }
                        }
                    }
                }
            }
        }

        private void deviceNameTextBox_Leave(object sender, EventArgs e)
        {
            foreach (var pair in device.DictionaryForRoleClassofComponent)
            {
                if (pair.Key != null && pair.Key.ToString() == "(" + 1 + ")" + "AutomationComponent{Class:  AutomationMLBaseRole}")
                {
                    foreach (var valueList in pair.Value)
                    {
                        foreach (var item in valueList)
                        {
                            if (item.Name == "Model")
                            {
                                item.Value = deviceNameTextBox.Text;
                            }
                        }
                    }
                }
                if (pair.Key != null && pair.Key.Contains("(" + 1 + ")"))
                {
                    foreach (var valueList in pair.Value)
                    {
                        foreach (var item in valueList)
                        {
                            if (item.Name == "Model")
                            {
                                item.Value = deviceNameTextBox.Text;
                            }
                        }
                    }
                }
            }
        }

        private void clearSelectedRowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (attachablesInfoDataGridView.CurrentCell != null)
                {
                    int rowIndex = attachablesInfoDataGridView.CurrentCell.RowIndex;
                    attachablesInfoDataGridView.Rows.RemoveAt(rowIndex);
                }
            }
            catch (Exception) { }
        }

        private void genericParametersAttrDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            genericparametersAttrDataGridView.CurrentRow.Selected = true;

            string attributeName = "";
            string values = "";
            string defaults = "";
            string Units = "";
            string datatype = "";

            if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {
                    if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        attributeName = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        values = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[2].Value != null)
                    {
                        defaults = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                }
                catch (Exception)
                { }

                try
                {
                    if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[3].Value != null)
                    {
                        Units = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    }
                }
                catch (Exception)
                { }
                try
                {
                    if (genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        datatype = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                }
                catch (Exception)
                { }




                List<string> lists = new List<string>();
                DataGridViewComboBoxCell dgvcbc = (DataGridViewComboBoxCell)genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[5];

                foreach (var refsemantic in dgvcbc.Items)
                {
                    try
                    {
                        if (refsemantic != null)
                        {
                            lists.Add(refsemantic.ToString());
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
                /* string semantics = genericparametersAttrDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();*/



                //if (Convert.ToBoolean(electricalInterfacesCollectionDataGridView.CurrentRow.Cells[3].Value) == false)
                {

                    string interfaceClass = genericDataHeaderLabel.Text;
                    foreach (var pair in device.DictionaryForRoleClassofComponent)
                    {
                        if (pair.Key.ToString() == interfaceClass)
                        {
                            foreach (var valueList in pair.Value)
                            {
                                foreach (var item in valueList)
                                {
                                    if (item.Name.ToString() == attributeName)
                                    {
                                        foreach (var pair2 in device.DictionaryForRoleClassofComponent)
                                        {
                                            if (pair2.Key.ToString() == interfaceClass)
                                            {
                                                foreach (var valueList2 in pair2.Value)
                                                {
                                                    foreach (var item2 in valueList2)
                                                    {
                                                        if (item2.Name.ToString() == attributeName)
                                                        {
                                                            item2.RefSemanticList.Remove();
                                                            item2.Name = attributeName;
                                                            item2.Value = values;
                                                            item2.Default = defaults;
                                                            item2.Unit = Units;

                                                            foreach (var str in lists)
                                                            {
                                                                var refsems = item2.RefSemanticList.Append();
                                                                refsems.CorrespondingAttributePath = str;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (var pair in device.DictionaryForExternalInterfacesUnderRoleClassofComponent)
                    {
                        if (pair.Key.ToString() == interfaceClass)
                        {
                            foreach (var valueList in pair.Value)
                            {
                                foreach (var item in valueList)
                                {
                                    if (item.Name.ToString() == attributeName)
                                    {
                                        /* item.Value = values;
                                         item.Default = defaults;
                                         item.Unit = Units;
                                         item.Semantic = semantics;*/

                                        foreach (var pair2 in device.DictionaryForExternalInterfacesUnderRoleClassofComponent)
                                        {
                                            if (pair2.Key.ToString() == interfaceClass)
                                            {
                                                foreach (var valueList2 in pair2.Value)
                                                {
                                                    foreach (var item2 in valueList2)
                                                    {
                                                        if (item2.Name.ToString() == attributeName)
                                                        {
                                                            item2.RefSemanticList.Remove();
                                                            item2.Name = attributeName;
                                                            item2.Value = values;
                                                            item2.Default = defaults;
                                                            item2.Unit = Units;

                                                            foreach (var str in lists)
                                                            {
                                                                var refsems = item2.RefSemanticList.Append();
                                                                refsems.CorrespondingAttributePath = str;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            genericparametersAttrDataGridView.CurrentRow.Selected = false;
        }

        private void electricalInterfacesCollectionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
        }

        private void vendorNameTextBox_TextChanged(object sender, EventArgs e)
        {
            vendorNameTextBox_Leave(sender, e);
            foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "AutomationComponent{Class:  AutomationMLBaseRole}")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    genericInformationtreeView.Nodes.Clear();
                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                    else if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "(1)AutomationMLComponentStandardRCL/AutomationComponent")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLComponentFile.DictionaryofRolesforAutomationComponenet)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    genericInformationtreeView.Nodes.Clear();
                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void deviceNameTextBox_TextChanged(object sender, EventArgs e)
        {
            deviceNameTextBox_Leave(sender, e);
            foreach (DataGridViewRow row in genericInformationDataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "AutomationComponent{Class:  AutomationMLBaseRole}")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLLibraryFile.DictionaryForRoleClassInstanceAttributes)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    genericInformationtreeView.Nodes.Clear();
                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                    else if (row.Cells[0].Value.ToString() == "1" && row.Cells[1].Value.ToString() == "(1)AutomationMLComponentStandardRCL/AutomationComponent")
                    {
                        string SRCSerialNumber = row.Cells[0].Value.ToString();
                        string SRC = row.Cells[1].Value.ToString();
                        foreach (var pair in searchAMLComponentFile.DictionaryofRolesforAutomationComponenet)
                        {
                            if (pair.Key.ToString() == SRC)
                            {
                                try
                                {
                                    if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + SRCSerialNumber + ")" + SRC))
                                    {
                                        device.DictionaryForRoleClassofComponent.Remove("(" + SRCSerialNumber + ")" + SRC);
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }
                                    else
                                    {
                                        device.DictionaryForRoleClassofComponent.Add("(" + SRCSerialNumber + ")" + SRC, pair.Value);
                                    }

                                    genericInformationtreeView.Nodes.Clear();
                                    TreeNode parentNode = genericInformationtreeView.Nodes.Add("(" + SRCSerialNumber + ")" + SRC,
                                        "(" + SRCSerialNumber + ")" + SRC, 2);
                                    autoloadGenericInformationtreeView(parentNode);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void advancedModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Switch mode
            expertMode = !expertMode;

            // Change text
            if (expertMode)
            {
                this.advancedModeToolStripMenuItem.Text = "Easy mode";
            }
            else
            {
                this.advancedModeToolStripMenuItem.Text = "Advanced mode";
            }

            // Show/hide elements
            this.ShowHideElements();
        }


        private void ShowHideElements()
        {
            genericparametersAttrDataGridView.Columns[2].Visible = expertMode;
            genericparametersAttrDataGridView.Columns[3].Visible = expertMode;
            genericparametersAttrDataGridView.Columns[4].Visible = expertMode;
            genericparametersAttrDataGridView.Columns[5].Visible = expertMode;


            elecInterAttDataGridView.Columns[2].Visible = expertMode;
            elecInterAttDataGridView.Columns[3].Visible = expertMode;
            elecInterAttDataGridView.Columns[4].Visible = expertMode;
            elecInterAttDataGridView.Columns[5].Visible = expertMode;

        }

        private void deleteRoleClassButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (genericInformationDataGridView.CurrentCell != null)
                {
                    int rowIndex = genericInformationDataGridView.CurrentCell.RowIndex;
                    genericInformationDataGridView.CurrentRow.Selected = true;

                    DataGridViewCell dataGridCell0 = genericInformationDataGridView.Rows[rowIndex].Cells[0];
                    DataGridViewCell dataGridCell1 = genericInformationDataGridView.Rows[rowIndex].Cells[1];

                    if (dataGridCell0.Value != null && dataGridCell1.Value != null)
                    {
                        string interfaceSerialNumber = dataGridCell0.Value.ToString();
                        string interfaceClass = dataGridCell1.Value.ToString();


                        try
                        {
                            if (device.DictionaryForRoleClassofComponent.ContainsKey("(" + interfaceSerialNumber + ")" + interfaceClass))
                            {
                                device.DictionaryForRoleClassofComponent.Remove("(" + interfaceSerialNumber + ")" + interfaceClass);

                            }


                        }
                        catch (Exception)
                        {

                            throw;
                        }

                        foreach (var pair in searchAMLLibraryFile.DictionaryForExternalInterfacesInstancesAttributesOfRoleClassLib)
                        {
                            if (pair.Key.Contains(interfaceClass))
                            {
                                try
                                {
                                    if (device.DictionaryForExternalInterfacesUnderRoleClassofComponent.ContainsKey("(" + interfaceSerialNumber + ")" + pair.Key.ToString()))
                                    {
                                        device.DictionaryForExternalInterfacesUnderRoleClassofComponent.Remove("(" + interfaceSerialNumber + ")" + pair.Key.ToString());

                                    }

                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                            }
                        }

                        genericInformationDataGridView.Rows.RemoveAt(rowIndex);

                    }
                }

            }
            catch (Exception) { }
        }

        private void caexVersionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Switch mode
            useCaex2_15 = !useCaex2_15;

            // Change text
            if (useCaex2_15)
            {
                this.caexVersionFileToolStripMenuItem.Text = "Use CAEX 3.0 File";
            }
            else
            {
                this.caexVersionFileToolStripMenuItem.Text = "Use CAEX 2.15 File";
            }
        }
    }
}