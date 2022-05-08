/// <summary>
/// MOD.001 GUI
/// This Module is responsible for the look of the GUI. Everything related to the frontend of the plugin can be changed here. For Example the size of elements,
/// their color, their types...
/// This can be edited with the WinForm GUI of VisualStudio or in this class. To edit anything of the GUI in this Code double-click line 30 ("Component Designer generated code").
/// </summary>

namespace Aml.Editor.Plugin
{
    partial class DeviceDescription
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceDescription));
            this.toolStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importIODDFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGSDFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLibraryFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librariesSplitButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.automationComponentLibraryv100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automationComponentLibraryv100FullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electricConnectorLibraryv100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.industrialSensorLibraryv100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caexVersionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.filePathLabel = new System.Windows.Forms.ToolStripLabel();
            this.deviceNameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Page0_FullWindow = new System.Windows.Forms.Panel();
            this.Page0_FullWindowPanel2 = new System.Windows.Forms.Panel();
            this.Page0_FastFullWindow = new System.Windows.Forms.Panel();
            this.Page0_FastFullWindow2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataTabControl = new System.Windows.Forms.TabControl();
            this.genericData = new System.Windows.Forms.TabPage();
            this.Page1_MainPanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.genericInformationtreeView = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.genericInformationDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadfromLibrary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loadFromComponentFile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.deleteRoleClassesButton = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
            this.deleteRoleClassButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.genericparametersAttrDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.genericDataHeaderLabel = new System.Windows.Forms.ToolStripLabel();
            this.Interface = new System.Windows.Forms.TabPage();
            this.electricalInterfacesPanel = new System.Windows.Forms.Panel();
            this.Page3_BottomPanel = new System.Windows.Forms.Panel();
            this.tabControlElectricalAttributes = new System.Windows.Forms.TabControl();
            this.attributestab = new System.Windows.Forms.TabPage();
            this.elecInterAttDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.electricalInterfacesHeaderlabel = new System.Windows.Forms.ToolStripLabel();
            this.Page3_TopPanel = new System.Windows.Forms.Panel();
            this.treeViewElectricalInterfaces = new System.Windows.Forms.TreeView();
            this.electricalInterfacesCollectionDataGridView = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedClassorInterface = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libraryFile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.componentFile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip24 = new System.Windows.Forms.ToolStrip();
            this.deleterowsInelectricalInterfacesDataGridView = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.DocsTabPage = new System.Windows.Forms.TabPage();
            this.addPicturesandDocsPanel = new System.Windows.Forms.Panel();
            this.Page2_BottomPanel = new System.Windows.Forms.Panel();
            this.attachablesInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip19 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
            this.clearSelectedRowBtn = new System.Windows.Forms.ToolStripButton();
            this.Page2_VerstecktesPanel = new System.Windows.Forms.Panel();
            this.toolStrip13 = new System.Windows.Forms.ToolStrip();
            this.AutomationMLRole = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.addRole = new System.Windows.Forms.ToolStripButton();
            this.automationMLRoleCmbBx = new System.Windows.Forms.ToolStripComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.selectFileBtn = new System.Windows.Forms.Button();
            this.selectURLBtn = new System.Windows.Forms.Button();
            this.selectedFileLocationTxtBx = new System.Windows.Forms.TextBox();
            this.AMLfileLabel = new System.Windows.Forms.Label();
            this.AMLURLLabel = new System.Windows.Forms.Label();
            this.selectedFileURLTextBox = new System.Windows.Forms.TextBox();
            this.treeViewPanel = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Page0_RoleClassPanel = new System.Windows.Forms.Panel();
            this.treeViewRoleClassLib = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.treeViewInterfaceClassLibPanel = new System.Windows.Forms.Panel();
            this.treeViewInterfaceClassLib = new System.Windows.Forms.TreeView();
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.InterfaceClassLibLabel = new System.Windows.Forms.ToolStripLabel();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageListRCL = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripforInterfaceClassLib = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identificationDataGridView = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.commercialDataTabControl = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.dataGridViewManufacturerDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridViewProductPriceDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewProductOrderDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridViewProductDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.identificationDataBtn = new System.Windows.Forms.Button();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.commercialDataBtn = new System.Windows.Forms.Button();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.Page0_FullWindow.SuspendLayout();
            this.Page0_FullWindowPanel2.SuspendLayout();
            this.Page0_FastFullWindow.SuspendLayout();
            this.Page0_FastFullWindow2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.dataTabControl.SuspendLayout();
            this.genericData.SuspendLayout();
            this.Page1_MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericInformationDataGridView)).BeginInit();
            this.deleteRoleClassesButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericparametersAttrDataGridView)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.Interface.SuspendLayout();
            this.electricalInterfacesPanel.SuspendLayout();
            this.Page3_BottomPanel.SuspendLayout();
            this.tabControlElectricalAttributes.SuspendLayout();
            this.attributestab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.elecInterAttDataGridView)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.Page3_TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electricalInterfacesCollectionDataGridView)).BeginInit();
            this.toolStrip24.SuspendLayout();
            this.DocsTabPage.SuspendLayout();
            this.addPicturesandDocsPanel.SuspendLayout();
            this.Page2_BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachablesInfoDataGridView)).BeginInit();
            this.toolStrip19.SuspendLayout();
            this.Page2_VerstecktesPanel.SuspendLayout();
            this.toolStrip13.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.treeViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.Page0_RoleClassPanel.SuspendLayout();
            this.toolStrip7.SuspendLayout();
            this.treeViewInterfaceClassLibPanel.SuspendLayout();
            this.toolStrip9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.identificationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManufacturerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.librariesSplitButton,
            this.optionsToolStripMenuItem,
            this.helpButton,
            this.vendorNameTextBox,
            this.filePathLabel,
            this.deviceNameTextBox,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1750, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveeToolStripMenuItem,
            this.importToolStripMenuItem,
            this.loadLibraryFile,
            this.exitToolStripMenuItem});
            this.fileButton.Name = "fileButton";
            this.fileButton.ShowDropDownArrow = false;
            this.fileButton.Size = new System.Drawing.Size(29, 20);
            this.fileButton.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveeToolStripMenuItem
            // 
            this.saveeToolStripMenuItem.Name = "saveeToolStripMenuItem";
            this.saveeToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.saveeToolStripMenuItem.Text = "Save and Close File";
            this.saveeToolStripMenuItem.Click += new System.EventHandler(this.saveeToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importIODDFileToolStripMenuItem,
            this.importGSDFileToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importIODDFileToolStripMenuItem
            // 
            this.importIODDFileToolStripMenuItem.Name = "importIODDFileToolStripMenuItem";
            this.importIODDFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importIODDFileToolStripMenuItem.Text = "Import  IODD-File";
            this.importIODDFileToolStripMenuItem.Click += new System.EventHandler(this.importIODDFileToolStripMenuItem_Click);
            // 
            // importGSDFileToolStripMenuItem
            // 
            this.importGSDFileToolStripMenuItem.Name = "importGSDFileToolStripMenuItem";
            this.importGSDFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.importGSDFileToolStripMenuItem.Text = "Import GSD-File";
            this.importGSDFileToolStripMenuItem.Click += new System.EventHandler(this.importGSDFileToolStripMenuItem_Click);
            // 
            // loadLibraryFile
            // 
            this.loadLibraryFile.Name = "loadLibraryFile";
            this.loadLibraryFile.Size = new System.Drawing.Size(174, 22);
            this.loadLibraryFile.Text = "Load Library";
            this.loadLibraryFile.Click += new System.EventHandler(this.loadLibraryFile_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // librariesSplitButton
            // 
            this.librariesSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automationComponentLibraryv100ToolStripMenuItem,
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem,
            this.automationComponentLibraryv100FullToolStripMenuItem,
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem,
            this.electricConnectorLibraryv100ToolStripMenuItem,
            this.industrialSensorLibraryv100ToolStripMenuItem});
            this.librariesSplitButton.Name = "librariesSplitButton";
            this.librariesSplitButton.ShowDropDownArrow = false;
            this.librariesSplitButton.Size = new System.Drawing.Size(55, 20);
            this.librariesSplitButton.Text = "Libraries";
            // 
            // automationComponentLibraryv100ToolStripMenuItem
            // 
            this.automationComponentLibraryv100ToolStripMenuItem.Name = "automationComponentLibraryv100ToolStripMenuItem";
            this.automationComponentLibraryv100ToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.automationComponentLibraryv100ToolStripMenuItem.Text = "AutomationComponentLibrary_v1_0_0";
            this.automationComponentLibraryv100ToolStripMenuItem.Click += new System.EventHandler(this.automationComponentLibraryv100ToolStripMenuItem_Click);
            // 
            // automationComponentLibraryv100CAEX3BETAToolStripMenuItem
            // 
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem.Name = "automationComponentLibraryv100CAEX3BETAToolStripMenuItem";
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem.Text = "AutomationComponentLibrary_v1_0_0_CAEX3_BETA";
            this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem.Click += new System.EventHandler(this.automationComponentLibraryv100CAEX3BETAToolStripMenuItem_Click);
            // 
            // automationComponentLibraryv100FullToolStripMenuItem
            // 
            this.automationComponentLibraryv100FullToolStripMenuItem.Name = "automationComponentLibraryv100FullToolStripMenuItem";
            this.automationComponentLibraryv100FullToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.automationComponentLibraryv100FullToolStripMenuItem.Text = "AutomationComponentLibrary_v1_0_0_Full";
            this.automationComponentLibraryv100FullToolStripMenuItem.Click += new System.EventHandler(this.automationComponentLibraryv100FullToolStripMenuItem_Click);
            // 
            // automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem
            // 
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem.Name = "automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem";
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem.Text = "AutomationComponentLibrary_v1_0_0_Full_CAEX3_BETA";
            this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem.Click += new System.EventHandler(this.automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem_Click);
            // 
            // electricConnectorLibraryv100ToolStripMenuItem
            // 
            this.electricConnectorLibraryv100ToolStripMenuItem.Name = "electricConnectorLibraryv100ToolStripMenuItem";
            this.electricConnectorLibraryv100ToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.electricConnectorLibraryv100ToolStripMenuItem.Text = "ElectricConnectorLibrary_v1_0_0";
            this.electricConnectorLibraryv100ToolStripMenuItem.Click += new System.EventHandler(this.electricConnectorLibraryv100ToolStripMenuItem_Click);
            // 
            // industrialSensorLibraryv100ToolStripMenuItem
            // 
            this.industrialSensorLibraryv100ToolStripMenuItem.Name = "industrialSensorLibraryv100ToolStripMenuItem";
            this.industrialSensorLibraryv100ToolStripMenuItem.Size = new System.Drawing.Size(372, 22);
            this.industrialSensorLibraryv100ToolStripMenuItem.Text = "IndustrialSensorLibrary_v1_0_0";
            this.industrialSensorLibraryv100ToolStripMenuItem.Click += new System.EventHandler(this.industrialSensorLibraryv100ToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedModeToolStripMenuItem,
            this.caexVersionFileToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 23);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // advancedModeToolStripMenuItem
            // 
            this.advancedModeToolStripMenuItem.Name = "advancedModeToolStripMenuItem";
            this.advancedModeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.advancedModeToolStripMenuItem.Text = "Advanced Mode";
            this.advancedModeToolStripMenuItem.Click += new System.EventHandler(this.advancedModeToolStripMenuItem_Click);
            // 
            // caexVersionFileToolStripMenuItem
            // 
            this.caexVersionFileToolStripMenuItem.Name = "caexVersionFileToolStripMenuItem";
            this.caexVersionFileToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.caexVersionFileToolStripMenuItem.Text = "Use CAEX 2.15 File";
            this.caexVersionFileToolStripMenuItem.Click += new System.EventHandler(this.caexVersionFileToolStripMenuItem_Click);
            // 
            // helpButton
            // 
            this.helpButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.manualToolStripMenuItem});
            this.helpButton.Name = "helpButton";
            this.helpButton.ShowDropDownArrow = false;
            this.helpButton.Size = new System.Drawing.Size(36, 20);
            this.helpButton.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // vendorNameTextBox
            // 
            this.vendorNameTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.vendorNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vendorNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.vendorNameTextBox.Name = "vendorNameTextBox";
            this.vendorNameTextBox.Size = new System.Drawing.Size(150, 23);
            this.vendorNameTextBox.TextChanged += new System.EventHandler(this.vendorNameTextBox_TextChanged);
            // 
            // filePathLabel
            // 
            this.filePathLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(53, 20);
            this.filePathLabel.Text = "  Vendor:";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deviceNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deviceNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.Size = new System.Drawing.Size(150, 23);
            this.deviceNameTextBox.TextChanged += new System.EventHandler(this.deviceNameTextBox_TextChanged);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(80, 20);
            this.toolStripLabel4.Text = "Device Name:";
            // 
            // Page0_FullWindow
            // 
            this.Page0_FullWindow.BackColor = System.Drawing.SystemColors.Control;
            this.Page0_FullWindow.Controls.Add(this.Page0_FullWindowPanel2);
            this.Page0_FullWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0_FullWindow.Location = new System.Drawing.Point(0, 0);
            this.Page0_FullWindow.Margin = new System.Windows.Forms.Padding(0);
            this.Page0_FullWindow.Name = "Page0_FullWindow";
            this.Page0_FullWindow.Size = new System.Drawing.Size(1750, 866);
            this.Page0_FullWindow.TabIndex = 2;
            // 
            // Page0_FullWindowPanel2
            // 
            this.Page0_FullWindowPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.Page0_FullWindowPanel2.Controls.Add(this.Page0_FastFullWindow);
            this.Page0_FullWindowPanel2.Controls.Add(this.toolStrip1);
            this.Page0_FullWindowPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0_FullWindowPanel2.Location = new System.Drawing.Point(0, 0);
            this.Page0_FullWindowPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.Page0_FullWindowPanel2.Name = "Page0_FullWindowPanel2";
            this.Page0_FullWindowPanel2.Size = new System.Drawing.Size(1750, 866);
            this.Page0_FullWindowPanel2.TabIndex = 1;
            // 
            // Page0_FastFullWindow
            // 
            this.Page0_FastFullWindow.BackColor = System.Drawing.SystemColors.Control;
            this.Page0_FastFullWindow.Controls.Add(this.Page0_FastFullWindow2);
            this.Page0_FastFullWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0_FastFullWindow.Location = new System.Drawing.Point(0, 27);
            this.Page0_FastFullWindow.Margin = new System.Windows.Forms.Padding(0);
            this.Page0_FastFullWindow.Name = "Page0_FastFullWindow";
            this.Page0_FastFullWindow.Size = new System.Drawing.Size(1750, 839);
            this.Page0_FastFullWindow.TabIndex = 3;
            // 
            // Page0_FastFullWindow2
            // 
            this.Page0_FastFullWindow2.Controls.Add(this.splitContainer1);
            this.Page0_FastFullWindow2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0_FastFullWindow2.Location = new System.Drawing.Point(0, 0);
            this.Page0_FastFullWindow2.Margin = new System.Windows.Forms.Padding(0);
            this.Page0_FastFullWindow2.Name = "Page0_FastFullWindow2";
            this.Page0_FastFullWindow2.Size = new System.Drawing.Size(1750, 839);
            this.Page0_FastFullWindow2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.dataTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeViewPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1750, 839);
            this.splitContainer1.SplitterDistance = 1333;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataTabControl
            // 
            this.dataTabControl.Controls.Add(this.genericData);
            this.dataTabControl.Controls.Add(this.Interface);
            this.dataTabControl.Controls.Add(this.DocsTabPage);
            this.dataTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.dataTabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTabControl.ItemSize = new System.Drawing.Size(100, 22);
            this.dataTabControl.Location = new System.Drawing.Point(0, 0);
            this.dataTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.dataTabControl.Name = "dataTabControl";
            this.dataTabControl.SelectedIndex = 0;
            this.dataTabControl.Size = new System.Drawing.Size(1333, 839);
            this.dataTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.dataTabControl.TabIndex = 0;
            this.dataTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.dataTabControl_DrawItem);
            // 
            // genericData
            // 
            this.genericData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.genericData.Controls.Add(this.Page1_MainPanel);
            this.genericData.Location = new System.Drawing.Point(4, 26);
            this.genericData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.genericData.Name = "genericData";
            this.genericData.Size = new System.Drawing.Size(1325, 809);
            this.genericData.TabIndex = 7;
            this.genericData.Text = "Generic Data";
            // 
            // Page1_MainPanel
            // 
            this.Page1_MainPanel.AutoScroll = true;
            this.Page1_MainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page1_MainPanel.Controls.Add(this.splitContainer2);
            this.Page1_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page1_MainPanel.Location = new System.Drawing.Point(0, 0);
            this.Page1_MainPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Page1_MainPanel.MinimumSize = new System.Drawing.Size(686, 100);
            this.Page1_MainPanel.Name = "Page1_MainPanel";
            this.Page1_MainPanel.Size = new System.Drawing.Size(1325, 809);
            this.Page1_MainPanel.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.genericInformationtreeView);
            this.splitContainer2.Panel1.Controls.Add(this.genericInformationDataGridView);
            this.splitContainer2.Panel1.Controls.Add(this.deleteRoleClassesButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip5);
            this.splitContainer2.Size = new System.Drawing.Size(1325, 809);
            this.splitContainer2.SplitterDistance = 404;
            this.splitContainer2.TabIndex = 0;
            // 
            // genericInformationtreeView
            // 
            this.genericInformationtreeView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.genericInformationtreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genericInformationtreeView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.genericInformationtreeView.ImageIndex = 0;
            this.genericInformationtreeView.ImageList = this.imageList2;
            this.genericInformationtreeView.Location = new System.Drawing.Point(0, 329);
            this.genericInformationtreeView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.genericInformationtreeView.Name = "genericInformationtreeView";
            this.genericInformationtreeView.SelectedImageIndex = 0;
            this.genericInformationtreeView.Size = new System.Drawing.Size(1325, 75);
            this.genericInformationtreeView.TabIndex = 6;
            this.genericInformationtreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.genericInformationtreeView_AfterSelect);
            this.genericInformationtreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.genericInformationtreeView_NodeMouseClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ICL.JPG");
            this.imageList2.Images.SetKeyName(1, "IC.JPG");
            this.imageList2.Images.SetKeyName(2, "Interface.JPG");
            // 
            // genericInformationDataGridView
            // 
            this.genericInformationDataGridView.AllowDrop = true;
            this.genericInformationDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.genericInformationDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genericInformationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genericInformationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.loadfromLibrary,
            this.loadFromComponentFile,
            this.dataGridViewCheckBoxColumn2});
            this.genericInformationDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.genericInformationDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.genericInformationDataGridView.Location = new System.Drawing.Point(0, 25);
            this.genericInformationDataGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.genericInformationDataGridView.Name = "genericInformationDataGridView";
            this.genericInformationDataGridView.ReadOnly = true;
            this.genericInformationDataGridView.RowHeadersWidth = 51;
            this.genericInformationDataGridView.RowTemplate.Height = 24;
            this.genericInformationDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.genericInformationDataGridView.Size = new System.Drawing.Size(1325, 176);
            this.genericInformationDataGridView.TabIndex = 5;
            this.genericInformationDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.genericInformationDataGridView_CellClick);
            this.genericInformationDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.genericInformationDataGridView_MouseUp);
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "Index";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 50;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn32.HeaderText = "Role ";
            this.dataGridViewTextBoxColumn32.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // loadfromLibrary
            // 
            this.loadfromLibrary.HeaderText = "LoadfromLibrary";
            this.loadfromLibrary.MinimumWidth = 6;
            this.loadfromLibrary.Name = "loadfromLibrary";
            this.loadfromLibrary.ReadOnly = true;
            this.loadfromLibrary.Visible = false;
            this.loadfromLibrary.Width = 125;
            // 
            // loadFromComponentFile
            // 
            this.loadFromComponentFile.HeaderText = "LoadFromComponentFile";
            this.loadFromComponentFile.MinimumWidth = 6;
            this.loadFromComponentFile.Name = "loadFromComponentFile";
            this.loadFromComponentFile.ReadOnly = true;
            this.loadFromComponentFile.Visible = false;
            this.loadFromComponentFile.Width = 125;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Add to AML-File";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            this.dataGridViewCheckBoxColumn2.Width = 125;
            // 
            // deleteRoleClassesButton
            // 
            this.deleteRoleClassesButton.AllowMerge = false;
            this.deleteRoleClassesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.deleteRoleClassesButton.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.deleteRoleClassesButton.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.deleteRoleClassesButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel20,
            this.deleteRoleClassButton});
            this.deleteRoleClassesButton.Location = new System.Drawing.Point(0, 0);
            this.deleteRoleClassesButton.Name = "deleteRoleClassesButton";
            this.deleteRoleClassesButton.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.deleteRoleClassesButton.Size = new System.Drawing.Size(1325, 25);
            this.deleteRoleClassesButton.TabIndex = 4;
            this.deleteRoleClassesButton.Text = "toolStrip25";
            // 
            // toolStripLabel20
            // 
            this.toolStripLabel20.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel20.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel20.Name = "toolStripLabel20";
            this.toolStripLabel20.Size = new System.Drawing.Size(113, 22);
            this.toolStripLabel20.Text = "Generic Information";
            // 
            // deleteRoleClassButton
            // 
            this.deleteRoleClassButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteRoleClassButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteRoleClassButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteRoleClassButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.deleteRoleClassButton.ForeColor = System.Drawing.Color.Black;
            this.deleteRoleClassButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteRoleClassButton.Image")));
            this.deleteRoleClassButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteRoleClassButton.Name = "deleteRoleClassButton";
            this.deleteRoleClassButton.Size = new System.Drawing.Size(49, 22);
            this.deleteRoleClassButton.Text = "Delete";
            this.deleteRoleClassButton.Click += new System.EventHandler(this.deleteRoleClassButton_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1325, 376);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.genericparametersAttrDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(1317, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Attributes";
            // 
            // genericparametersAttrDataGridView
            // 
            this.genericparametersAttrDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.genericparametersAttrDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genericparametersAttrDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.genericparametersAttrDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29});
            this.genericparametersAttrDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genericparametersAttrDataGridView.Location = new System.Drawing.Point(2, 3);
            this.genericparametersAttrDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.genericparametersAttrDataGridView.Name = "genericparametersAttrDataGridView";
            this.genericparametersAttrDataGridView.RowHeadersWidth = 50;
            this.genericparametersAttrDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.genericparametersAttrDataGridView.Size = new System.Drawing.Size(1313, 340);
            this.genericparametersAttrDataGridView.TabIndex = 8;
            this.genericparametersAttrDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.genericParametersAttrDataGridView_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.HeaderText = "AttributeName";
            this.dataGridViewTextBoxColumn24.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn25.HeaderText = "Values";
            this.dataGridViewTextBoxColumn25.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.HeaderText = "Default";
            this.dataGridViewTextBoxColumn26.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn27.HeaderText = "Units";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.HeaderText = "DataType";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.HeaderText = "Semantic";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip5
            // 
            this.toolStrip5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genericDataHeaderLabel});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip5.Size = new System.Drawing.Size(1325, 25);
            this.toolStrip5.TabIndex = 12;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // genericDataHeaderLabel
            // 
            this.genericDataHeaderLabel.BackColor = System.Drawing.Color.Transparent;
            this.genericDataHeaderLabel.Name = "genericDataHeaderLabel";
            this.genericDataHeaderLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // Interface
            // 
            this.Interface.AutoScroll = true;
            this.Interface.BackColor = System.Drawing.Color.Transparent;
            this.Interface.Controls.Add(this.electricalInterfacesPanel);
            this.Interface.Location = new System.Drawing.Point(4, 26);
            this.Interface.Margin = new System.Windows.Forms.Padding(0);
            this.Interface.Name = "Interface";
            this.Interface.Size = new System.Drawing.Size(1325, 809);
            this.Interface.TabIndex = 6;
            this.Interface.Text = "Interfaces";
            // 
            // electricalInterfacesPanel
            // 
            this.electricalInterfacesPanel.AutoScroll = true;
            this.electricalInterfacesPanel.BackColor = System.Drawing.Color.White;
            this.electricalInterfacesPanel.Controls.Add(this.Page3_BottomPanel);
            this.electricalInterfacesPanel.Controls.Add(this.Page3_TopPanel);
            this.electricalInterfacesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.electricalInterfacesPanel.Location = new System.Drawing.Point(0, 0);
            this.electricalInterfacesPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.electricalInterfacesPanel.MinimumSize = new System.Drawing.Size(686, 22);
            this.electricalInterfacesPanel.Name = "electricalInterfacesPanel";
            this.electricalInterfacesPanel.Size = new System.Drawing.Size(1325, 809);
            this.electricalInterfacesPanel.TabIndex = 0;
            // 
            // Page3_BottomPanel
            // 
            this.Page3_BottomPanel.AutoSize = true;
            this.Page3_BottomPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page3_BottomPanel.Controls.Add(this.tabControlElectricalAttributes);
            this.Page3_BottomPanel.Controls.Add(this.toolStrip2);
            this.Page3_BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page3_BottomPanel.Location = new System.Drawing.Point(0, 454);
            this.Page3_BottomPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Page3_BottomPanel.MinimumSize = new System.Drawing.Size(0, 400);
            this.Page3_BottomPanel.Name = "Page3_BottomPanel";
            this.Page3_BottomPanel.Size = new System.Drawing.Size(1325, 400);
            this.Page3_BottomPanel.TabIndex = 10;
            // 
            // tabControlElectricalAttributes
            // 
            this.tabControlElectricalAttributes.Controls.Add(this.attributestab);
            this.tabControlElectricalAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlElectricalAttributes.Location = new System.Drawing.Point(0, 25);
            this.tabControlElectricalAttributes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControlElectricalAttributes.Name = "tabControlElectricalAttributes";
            this.tabControlElectricalAttributes.SelectedIndex = 0;
            this.tabControlElectricalAttributes.Size = new System.Drawing.Size(1325, 375);
            this.tabControlElectricalAttributes.TabIndex = 9;
            // 
            // attributestab
            // 
            this.attributestab.Controls.Add(this.elecInterAttDataGridView);
            this.attributestab.Location = new System.Drawing.Point(4, 26);
            this.attributestab.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.attributestab.Name = "attributestab";
            this.attributestab.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.attributestab.Size = new System.Drawing.Size(1317, 345);
            this.attributestab.TabIndex = 0;
            this.attributestab.Text = "Attributes";
            this.attributestab.UseVisualStyleBackColor = true;
            // 
            // elecInterAttDataGridView
            // 
            this.elecInterAttDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.elecInterAttDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.elecInterAttDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elecInterAttDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22});
            this.elecInterAttDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elecInterAttDataGridView.Location = new System.Drawing.Point(2, 3);
            this.elecInterAttDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.elecInterAttDataGridView.Name = "elecInterAttDataGridView";
            this.elecInterAttDataGridView.RowHeadersWidth = 51;
            this.elecInterAttDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.elecInterAttDataGridView.Size = new System.Drawing.Size(1313, 339);
            this.elecInterAttDataGridView.TabIndex = 8;
            this.elecInterAttDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.elecInterAttDataGridView_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.HeaderText = "AttributeName";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.HeaderText = "Values";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.HeaderText = "Default";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.HeaderText = "Units";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.HeaderText = "DataType";
            this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn22.HeaderText = "Semantic";
            this.dataGridViewTextBoxColumn22.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electricalInterfacesHeaderlabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(1325, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // electricalInterfacesHeaderlabel
            // 
            this.electricalInterfacesHeaderlabel.BackColor = System.Drawing.Color.Transparent;
            this.electricalInterfacesHeaderlabel.ForeColor = System.Drawing.Color.Black;
            this.electricalInterfacesHeaderlabel.Name = "electricalInterfacesHeaderlabel";
            this.electricalInterfacesHeaderlabel.Size = new System.Drawing.Size(0, 22);
            // 
            // Page3_TopPanel
            // 
            this.Page3_TopPanel.AutoSize = true;
            this.Page3_TopPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.Page3_TopPanel.Controls.Add(this.treeViewElectricalInterfaces);
            this.Page3_TopPanel.Controls.Add(this.electricalInterfacesCollectionDataGridView);
            this.Page3_TopPanel.Controls.Add(this.toolStrip24);
            this.Page3_TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Page3_TopPanel.Location = new System.Drawing.Point(0, 0);
            this.Page3_TopPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Page3_TopPanel.MinimumSize = new System.Drawing.Size(0, 400);
            this.Page3_TopPanel.Name = "Page3_TopPanel";
            this.Page3_TopPanel.Size = new System.Drawing.Size(1325, 454);
            this.Page3_TopPanel.TabIndex = 1;
            // 
            // treeViewElectricalInterfaces
            // 
            this.treeViewElectricalInterfaces.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeViewElectricalInterfaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewElectricalInterfaces.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.treeViewElectricalInterfaces.ImageIndex = 0;
            this.treeViewElectricalInterfaces.ImageList = this.imageList2;
            this.treeViewElectricalInterfaces.Location = new System.Drawing.Point(0, 379);
            this.treeViewElectricalInterfaces.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeViewElectricalInterfaces.Name = "treeViewElectricalInterfaces";
            this.treeViewElectricalInterfaces.SelectedImageIndex = 0;
            this.treeViewElectricalInterfaces.Size = new System.Drawing.Size(1325, 75);
            this.treeViewElectricalInterfaces.TabIndex = 0;
            this.treeViewElectricalInterfaces.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRoleClassLib_AfterSelect);
            this.treeViewElectricalInterfaces.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewElectricalInterfaces_NodeMouseClick);
            this.treeViewElectricalInterfaces.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewElectricalInterfaces_MouseClick);
            // 
            // electricalInterfacesCollectionDataGridView
            // 
            this.electricalInterfacesCollectionDataGridView.AllowDrop = true;
            this.electricalInterfacesCollectionDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.electricalInterfacesCollectionDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.electricalInterfacesCollectionDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.electricalInterfacesCollectionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.electricalInterfacesCollectionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.SelectedClassorInterface,
            this.libraryFile,
            this.componentFile,
            this.dataGridViewCheckBoxColumn1});
            this.electricalInterfacesCollectionDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.electricalInterfacesCollectionDataGridView.Location = new System.Drawing.Point(0, 25);
            this.electricalInterfacesCollectionDataGridView.Margin = new System.Windows.Forms.Padding(2, 3, 10, 0);
            this.electricalInterfacesCollectionDataGridView.Name = "electricalInterfacesCollectionDataGridView";
            this.electricalInterfacesCollectionDataGridView.ReadOnly = true;
            this.electricalInterfacesCollectionDataGridView.RowHeadersWidth = 51;
            this.electricalInterfacesCollectionDataGridView.RowTemplate.Height = 24;
            this.electricalInterfacesCollectionDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.electricalInterfacesCollectionDataGridView.Size = new System.Drawing.Size(1325, 354);
            this.electricalInterfacesCollectionDataGridView.TabIndex = 1;
            this.electricalInterfacesCollectionDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.electricalInterfacesCollectionDataGridView_CellClick);
            this.electricalInterfacesCollectionDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.electricalInterfacesCollectionDataGridView_CellContentClick);
            this.electricalInterfacesCollectionDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.electricalInterfacesCollectionDataGridView_MouseUp);
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "Index";
            this.SerialNumber.MinimumWidth = 6;
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            this.SerialNumber.Width = 50;
            // 
            // SelectedClassorInterface
            // 
            this.SelectedClassorInterface.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SelectedClassorInterface.HeaderText = "Interface ";
            this.SelectedClassorInterface.MinimumWidth = 6;
            this.SelectedClassorInterface.Name = "SelectedClassorInterface";
            this.SelectedClassorInterface.ReadOnly = true;
            // 
            // libraryFile
            // 
            this.libraryFile.HeaderText = "LibraryFile";
            this.libraryFile.MinimumWidth = 6;
            this.libraryFile.Name = "libraryFile";
            this.libraryFile.ReadOnly = true;
            this.libraryFile.Visible = false;
            this.libraryFile.Width = 125;
            // 
            // componentFile
            // 
            this.componentFile.HeaderText = "ComponentFile";
            this.componentFile.MinimumWidth = 6;
            this.componentFile.Name = "componentFile";
            this.componentFile.ReadOnly = true;
            this.componentFile.Visible = false;
            this.componentFile.Width = 125;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Add to AML-File";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 125;
            // 
            // toolStrip24
            // 
            this.toolStrip24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.toolStrip24.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip24.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip24.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleterowsInelectricalInterfacesDataGridView,
            this.toolStripLabel3});
            this.toolStrip24.Location = new System.Drawing.Point(0, 0);
            this.toolStrip24.Name = "toolStrip24";
            this.toolStrip24.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip24.Size = new System.Drawing.Size(1325, 25);
            this.toolStrip24.TabIndex = 0;
            this.toolStrip24.Text = "toolStrip24";
            // 
            // deleterowsInelectricalInterfacesDataGridView
            // 
            this.deleterowsInelectricalInterfacesDataGridView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleterowsInelectricalInterfacesDataGridView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleterowsInelectricalInterfacesDataGridView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleterowsInelectricalInterfacesDataGridView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.deleterowsInelectricalInterfacesDataGridView.ForeColor = System.Drawing.Color.Black;
            this.deleterowsInelectricalInterfacesDataGridView.Image = ((System.Drawing.Image)(resources.GetObject("deleterowsInelectricalInterfacesDataGridView.Image")));
            this.deleterowsInelectricalInterfacesDataGridView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleterowsInelectricalInterfacesDataGridView.Name = "deleterowsInelectricalInterfacesDataGridView";
            this.deleterowsInelectricalInterfacesDataGridView.Size = new System.Drawing.Size(49, 22);
            this.deleterowsInelectricalInterfacesDataGridView.Text = "Delete";
            this.deleterowsInelectricalInterfacesDataGridView.Click += new System.EventHandler(this.deleterowsInelectricalInterfacesDataGridView_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabel3.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel3.Text = "Interfaces";
            // 
            // DocsTabPage
            // 
            this.DocsTabPage.AllowDrop = true;
            this.DocsTabPage.BackColor = System.Drawing.Color.LightGray;
            this.DocsTabPage.Controls.Add(this.addPicturesandDocsPanel);
            this.DocsTabPage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DocsTabPage.Location = new System.Drawing.Point(4, 26);
            this.DocsTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.DocsTabPage.Name = "DocsTabPage";
            this.DocsTabPage.Size = new System.Drawing.Size(1325, 809);
            this.DocsTabPage.TabIndex = 4;
            this.DocsTabPage.Text = "Attachments";
            // 
            // addPicturesandDocsPanel
            // 
            this.addPicturesandDocsPanel.BackColor = System.Drawing.Color.Transparent;
            this.addPicturesandDocsPanel.Controls.Add(this.Page2_BottomPanel);
            this.addPicturesandDocsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addPicturesandDocsPanel.Location = new System.Drawing.Point(0, 0);
            this.addPicturesandDocsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.addPicturesandDocsPanel.MinimumSize = new System.Drawing.Size(691, 22);
            this.addPicturesandDocsPanel.Name = "addPicturesandDocsPanel";
            this.addPicturesandDocsPanel.Size = new System.Drawing.Size(1325, 809);
            this.addPicturesandDocsPanel.TabIndex = 0;
            // 
            // Page2_BottomPanel
            // 
            this.Page2_BottomPanel.AutoSize = true;
            this.Page2_BottomPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page2_BottomPanel.Controls.Add(this.attachablesInfoDataGridView);
            this.Page2_BottomPanel.Controls.Add(this.toolStrip19);
            this.Page2_BottomPanel.Controls.Add(this.Page2_VerstecktesPanel);
            this.Page2_BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page2_BottomPanel.Location = new System.Drawing.Point(0, 0);
            this.Page2_BottomPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Page2_BottomPanel.MinimumSize = new System.Drawing.Size(0, 750);
            this.Page2_BottomPanel.Name = "Page2_BottomPanel";
            this.Page2_BottomPanel.Size = new System.Drawing.Size(1325, 809);
            this.Page2_BottomPanel.TabIndex = 3;
            // 
            // attachablesInfoDataGridView
            // 
            this.attachablesInfoDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.attachablesInfoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.attachablesInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attachablesInfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementName,
            this.FilePath,
            this.Add});
            this.attachablesInfoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attachablesInfoDataGridView.Location = new System.Drawing.Point(0, 141);
            this.attachablesInfoDataGridView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.attachablesInfoDataGridView.Name = "attachablesInfoDataGridView";
            this.attachablesInfoDataGridView.RowHeadersWidth = 51;
            this.attachablesInfoDataGridView.RowTemplate.Height = 24;
            this.attachablesInfoDataGridView.Size = new System.Drawing.Size(1325, 668);
            this.attachablesInfoDataGridView.TabIndex = 4;
            // 
            // ElementName
            // 
            this.ElementName.HeaderText = "Element Name";
            this.ElementName.MinimumWidth = 6;
            this.ElementName.Name = "ElementName";
            this.ElementName.Width = 250;
            // 
            // FilePath
            // 
            this.FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilePath.HeaderText = "File Path";
            this.FilePath.MinimumWidth = 6;
            this.FilePath.Name = "FilePath";
            // 
            // Add
            // 
            this.Add.HeaderText = "Column1";
            this.Add.Name = "Add";
            this.Add.Visible = false;
            // 
            // toolStrip19
            // 
            this.toolStrip19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.toolStrip19.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip19.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip19.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel12,
            this.clearSelectedRowBtn});
            this.toolStrip19.Location = new System.Drawing.Point(0, 116);
            this.toolStrip19.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.toolStrip19.Name = "toolStrip19";
            this.toolStrip19.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip19.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip19.Size = new System.Drawing.Size(1325, 25);
            this.toolStrip19.TabIndex = 3;
            this.toolStrip19.Text = "toolStrip19";
            // 
            // toolStripLabel12
            // 
            this.toolStripLabel12.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel12.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel12.Name = "toolStripLabel12";
            this.toolStripLabel12.Size = new System.Drawing.Size(135, 22);
            this.toolStripLabel12.Text = "Attachables Information";
            // 
            // clearSelectedRowBtn
            // 
            this.clearSelectedRowBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.clearSelectedRowBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clearSelectedRowBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearSelectedRowBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.clearSelectedRowBtn.ForeColor = System.Drawing.Color.Black;
            this.clearSelectedRowBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearSelectedRowBtn.Image")));
            this.clearSelectedRowBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearSelectedRowBtn.Name = "clearSelectedRowBtn";
            this.clearSelectedRowBtn.Size = new System.Drawing.Size(49, 22);
            this.clearSelectedRowBtn.Text = "Delete";
            this.clearSelectedRowBtn.Click += new System.EventHandler(this.clearSelectedRowBtn_Click);
            // 
            // Page2_VerstecktesPanel
            // 
            this.Page2_VerstecktesPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Page2_VerstecktesPanel.Controls.Add(this.toolStrip13);
            this.Page2_VerstecktesPanel.Controls.Add(this.tableLayoutPanel4);
            this.Page2_VerstecktesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Page2_VerstecktesPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Page2_VerstecktesPanel.Location = new System.Drawing.Point(0, 0);
            this.Page2_VerstecktesPanel.Margin = new System.Windows.Forms.Padding(10);
            this.Page2_VerstecktesPanel.Name = "Page2_VerstecktesPanel";
            this.Page2_VerstecktesPanel.Size = new System.Drawing.Size(1325, 116);
            this.Page2_VerstecktesPanel.TabIndex = 6;
            // 
            // toolStrip13
            // 
            this.toolStrip13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.toolStrip13.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip13.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip13.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutomationMLRole,
            this.toolStripSeparator29,
            this.addRole,
            this.automationMLRoleCmbBx});
            this.toolStrip13.Location = new System.Drawing.Point(0, 0);
            this.toolStrip13.Name = "toolStrip13";
            this.toolStrip13.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip13.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip13.Size = new System.Drawing.Size(1325, 30);
            this.toolStrip13.TabIndex = 1;
            this.toolStrip13.Text = "toolStrip13";
            // 
            // AutomationMLRole
            // 
            this.AutomationMLRole.BackColor = System.Drawing.Color.Transparent;
            this.AutomationMLRole.ForeColor = System.Drawing.Color.Black;
            this.AutomationMLRole.Name = "AutomationMLRole";
            this.AutomationMLRole.Size = new System.Drawing.Size(114, 27);
            this.AutomationMLRole.Text = "AutomationML Role";
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.BackColor = System.Drawing.Color.Red;
            this.toolStripSeparator29.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(6, 30);
            // 
            // addRole
            // 
            this.addRole.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.addRole.ForeColor = System.Drawing.Color.Black;
            this.addRole.Image = ((System.Drawing.Image)(resources.GetObject("addRole.Image")));
            this.addRole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addRole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addRole.Margin = new System.Windows.Forms.Padding(3);
            this.addRole.Name = "addRole";
            this.addRole.Size = new System.Drawing.Size(53, 24);
            this.addRole.Text = "Add";
            this.addRole.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addRole.Click += new System.EventHandler(this.addRole_Click);
            // 
            // automationMLRoleCmbBx
            // 
            this.automationMLRoleCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.automationMLRoleCmbBx.Items.AddRange(new object[] {
            "BillofMaterials",
            "Certificate",
            "ComponentIcon",
            "ComponentPicture",
            "ManufacturerIcon",
            "ShortGuide"});
            this.automationMLRoleCmbBx.Margin = new System.Windows.Forms.Padding(3);
            this.automationMLRoleCmbBx.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.automationMLRoleCmbBx.Name = "automationMLRoleCmbBx";
            this.automationMLRoleCmbBx.Size = new System.Drawing.Size(132, 24);
            this.automationMLRoleCmbBx.Sorted = true;
            this.automationMLRoleCmbBx.SelectedIndexChanged += new System.EventHandler(this.automationMLRoleCmbBx_SelectedIndexChanged);
            this.automationMLRoleCmbBx.Click += new System.EventHandler(this.automationMLRoleCmbBx_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.selectFileBtn, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.selectURLBtn, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.selectedFileLocationTxtBx, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.AMLfileLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.AMLURLLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.selectedFileURLTextBox, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1325, 63);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // selectFileBtn
            // 
            this.selectFileBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectFileBtn.ForeColor = System.Drawing.Color.Black;
            this.selectFileBtn.Location = new System.Drawing.Point(1160, 3);
            this.selectFileBtn.Name = "selectFileBtn";
            this.selectFileBtn.Size = new System.Drawing.Size(162, 25);
            this.selectFileBtn.TabIndex = 0;
            this.selectFileBtn.Text = "Select File";
            this.selectFileBtn.UseVisualStyleBackColor = true;
            this.selectFileBtn.Click += new System.EventHandler(this.selectFileBtn_Click);
            // 
            // selectURLBtn
            // 
            this.selectURLBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectURLBtn.ForeColor = System.Drawing.Color.Black;
            this.selectURLBtn.Location = new System.Drawing.Point(1160, 34);
            this.selectURLBtn.Name = "selectURLBtn";
            this.selectURLBtn.Size = new System.Drawing.Size(162, 26);
            this.selectURLBtn.TabIndex = 1;
            this.selectURLBtn.Text = "Add Path";
            this.selectURLBtn.UseVisualStyleBackColor = true;
            this.selectURLBtn.Click += new System.EventHandler(this.selectURLBtn_Click);
            // 
            // selectedFileLocationTxtBx
            // 
            this.selectedFileLocationTxtBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedFileLocationTxtBx.Location = new System.Drawing.Point(5, 3);
            this.selectedFileLocationTxtBx.Name = "selectedFileLocationTxtBx";
            this.selectedFileLocationTxtBx.ReadOnly = true;
            this.selectedFileLocationTxtBx.Size = new System.Drawing.Size(1149, 25);
            this.selectedFileLocationTxtBx.TabIndex = 0;
            // 
            // AMLfileLabel
            // 
            this.AMLfileLabel.AutoSize = true;
            this.AMLfileLabel.BackColor = System.Drawing.Color.Transparent;
            this.AMLfileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AMLfileLabel.Location = new System.Drawing.Point(0, 0);
            this.AMLfileLabel.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.AMLfileLabel.Name = "AMLfileLabel";
            this.AMLfileLabel.Size = new System.Drawing.Size(1, 31);
            this.AMLfileLabel.TabIndex = 8;
            this.AMLfileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AMLURLLabel
            // 
            this.AMLURLLabel.AutoSize = true;
            this.AMLURLLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AMLURLLabel.Location = new System.Drawing.Point(0, 31);
            this.AMLURLLabel.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.AMLURLLabel.Name = "AMLURLLabel";
            this.AMLURLLabel.Size = new System.Drawing.Size(1, 32);
            this.AMLURLLabel.TabIndex = 9;
            this.AMLURLLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectedFileURLTextBox
            // 
            this.selectedFileURLTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedFileURLTextBox.Location = new System.Drawing.Point(5, 34);
            this.selectedFileURLTextBox.Name = "selectedFileURLTextBox";
            this.selectedFileURLTextBox.Size = new System.Drawing.Size(1149, 25);
            this.selectedFileURLTextBox.TabIndex = 1;
            // 
            // treeViewPanel
            // 
            this.treeViewPanel.AutoScroll = true;
            this.treeViewPanel.BackColor = System.Drawing.Color.Transparent;
            this.treeViewPanel.Controls.Add(this.splitContainer3);
            this.treeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewPanel.Location = new System.Drawing.Point(0, 0);
            this.treeViewPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeViewPanel.Name = "treeViewPanel";
            this.treeViewPanel.Size = new System.Drawing.Size(414, 839);
            this.treeViewPanel.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Page0_RoleClassPanel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.treeViewInterfaceClassLibPanel);
            this.splitContainer3.Size = new System.Drawing.Size(414, 839);
            this.splitContainer3.SplitterDistance = 419;
            this.splitContainer3.TabIndex = 0;
            // 
            // Page0_RoleClassPanel
            // 
            this.Page0_RoleClassPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.Page0_RoleClassPanel.Controls.Add(this.treeViewRoleClassLib);
            this.Page0_RoleClassPanel.Controls.Add(this.toolStrip7);
            this.Page0_RoleClassPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Page0_RoleClassPanel.Location = new System.Drawing.Point(0, 0);
            this.Page0_RoleClassPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Page0_RoleClassPanel.Name = "Page0_RoleClassPanel";
            this.Page0_RoleClassPanel.Size = new System.Drawing.Size(414, 419);
            this.Page0_RoleClassPanel.TabIndex = 0;
            // 
            // treeViewRoleClassLib
            // 
            this.treeViewRoleClassLib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.treeViewRoleClassLib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewRoleClassLib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRoleClassLib.ImageKey = "RCL.JPG";
            this.treeViewRoleClassLib.ImageList = this.imageList1;
            this.treeViewRoleClassLib.Location = new System.Drawing.Point(0, 25);
            this.treeViewRoleClassLib.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeViewRoleClassLib.Name = "treeViewRoleClassLib";
            this.treeViewRoleClassLib.SelectedImageKey = "RCL.JPG";
            this.treeViewRoleClassLib.ShowNodeToolTips = true;
            this.treeViewRoleClassLib.Size = new System.Drawing.Size(414, 394);
            this.treeViewRoleClassLib.TabIndex = 9;
            this.treeViewRoleClassLib.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewRoleClassLib_ItemDrag);
            this.treeViewRoleClassLib.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewRoleClassLib_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "RCL.JPG");
            this.imageList1.Images.SetKeyName(1, "RC.JPG");
            this.imageList1.Images.SetKeyName(2, "Interface.JPG");
            // 
            // toolStrip7
            // 
            this.toolStrip7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip7.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(414, 25);
            this.toolStrip7.TabIndex = 8;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel1.Text = "Role Class Library";
            // 
            // treeViewInterfaceClassLibPanel
            // 
            this.treeViewInterfaceClassLibPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.treeViewInterfaceClassLibPanel.Controls.Add(this.treeViewInterfaceClassLib);
            this.treeViewInterfaceClassLibPanel.Controls.Add(this.toolStrip9);
            this.treeViewInterfaceClassLibPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewInterfaceClassLibPanel.Location = new System.Drawing.Point(0, 0);
            this.treeViewInterfaceClassLibPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeViewInterfaceClassLibPanel.Name = "treeViewInterfaceClassLibPanel";
            this.treeViewInterfaceClassLibPanel.Size = new System.Drawing.Size(414, 416);
            this.treeViewInterfaceClassLibPanel.TabIndex = 1;
            // 
            // treeViewInterfaceClassLib
            // 
            this.treeViewInterfaceClassLib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.treeViewInterfaceClassLib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewInterfaceClassLib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewInterfaceClassLib.ImageIndex = 0;
            this.treeViewInterfaceClassLib.ImageList = this.imageList2;
            this.treeViewInterfaceClassLib.Location = new System.Drawing.Point(0, 25);
            this.treeViewInterfaceClassLib.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeViewInterfaceClassLib.Name = "treeViewInterfaceClassLib";
            this.treeViewInterfaceClassLib.SelectedImageKey = "ICL.JPG";
            this.treeViewInterfaceClassLib.Size = new System.Drawing.Size(414, 391);
            this.treeViewInterfaceClassLib.TabIndex = 10;
            this.treeViewInterfaceClassLib.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewInterfaceClassLib_ItemDrag);
            this.treeViewInterfaceClassLib.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewInterfaceClassLib_BeforeSelect);
            this.treeViewInterfaceClassLib.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewInterfaceClassLib_AfterSelect);
            this.treeViewInterfaceClassLib.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewInterfaceClassLib_NodeMouseClick);
            this.treeViewInterfaceClassLib.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewInterfaceClassLib_DragDrop);
            this.treeViewInterfaceClassLib.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewInterfaceClassLib_DragOver);
            this.treeViewInterfaceClassLib.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewInterfaceClassLib_MouseDown);
            // 
            // toolStrip9
            // 
            this.toolStrip9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip9.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip9.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InterfaceClassLibLabel});
            this.toolStrip9.Location = new System.Drawing.Point(0, 0);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(414, 25);
            this.toolStrip9.TabIndex = 9;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // InterfaceClassLibLabel
            // 
            this.InterfaceClassLibLabel.ForeColor = System.Drawing.Color.Black;
            this.InterfaceClassLibLabel.Name = "InterfaceClassLibLabel";
            this.InterfaceClassLibLabel.Size = new System.Drawing.Size(122, 22);
            this.InterfaceClassLibLabel.Text = "Interface Class Library";
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "IC.JPG");
            this.imageList3.Images.SetKeyName(1, "Interface.JPG");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // imageListRCL
            // 
            this.imageListRCL.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRCL.ImageStream")));
            this.imageListRCL.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListRCL.Images.SetKeyName(0, "RCL.JPG");
            // 
            // contextMenuStripforInterfaceClassLib
            // 
            this.contextMenuStripforInterfaceClassLib.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripforInterfaceClassLib.Name = "contextMenuStripforInterfaceClassLib";
            this.contextMenuStripforInterfaceClassLib.Size = new System.Drawing.Size(61, 4);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asInterfaceToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // asInterfaceToolStripMenuItem
            // 
            this.asInterfaceToolStripMenuItem.Name = "asInterfaceToolStripMenuItem";
            this.asInterfaceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.asInterfaceToolStripMenuItem.Text = "As Electrical Interface";
            this.asInterfaceToolStripMenuItem.Click += new System.EventHandler(this.asInterfaceToolStripMenuItem_Click);
            // 
            // identificationDataGridView
            // 
            this.identificationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.identificationDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.identificationDataGridView.Location = new System.Drawing.Point(0, 23);
            this.identificationDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.identificationDataGridView.Name = "identificationDataGridView";
            this.identificationDataGridView.RowHeadersWidth = 51;
            this.identificationDataGridView.RowTemplate.Height = 24;
            this.identificationDataGridView.Size = new System.Drawing.Size(787, 251);
            this.identificationDataGridView.TabIndex = 1;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 6;
            this.Value.Name = "Value";
            this.Value.Width = 175;
            // 
            // Attributes
            // 
            this.Attributes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Attributes.HeaderText = "Attributes";
            this.Attributes.MinimumWidth = 6;
            this.Attributes.Name = "Attributes";
            // 
            // ReferenceID
            // 
            this.ReferenceID.HeaderText = "Reference ID";
            this.ReferenceID.MinimumWidth = 6;
            this.ReferenceID.Name = "ReferenceID";
            this.ReferenceID.Width = 175;
            // 
            // toolStrip8
            // 
            this.toolStrip8.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip8.Location = new System.Drawing.Point(0, 274);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(787, 27);
            this.toolStrip8.TabIndex = 2;
            // 
            // commercialDataTabControl
            // 
            this.commercialDataTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.commercialDataTabControl.Location = new System.Drawing.Point(0, 23);
            this.commercialDataTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commercialDataTabControl.Name = "commercialDataTabControl";
            this.commercialDataTabControl.SelectedIndex = 0;
            this.commercialDataTabControl.Size = new System.Drawing.Size(787, 256);
            this.commercialDataTabControl.TabIndex = 1;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage8.Location = new System.Drawing.Point(4, 25);
            this.tabPage8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(779, 227);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Manufacturer Details";
            // 
            // dataGridViewManufacturerDetails
            // 
            this.dataGridViewManufacturerDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManufacturerDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewManufacturerDetails.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewManufacturerDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewManufacturerDetails.Name = "dataGridViewManufacturerDetails";
            this.dataGridViewManufacturerDetails.RowHeadersWidth = 51;
            this.dataGridViewManufacturerDetails.RowTemplate.Height = 24;
            this.dataGridViewManufacturerDetails.Size = new System.Drawing.Size(779, 251);
            this.dataGridViewManufacturerDetails.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Value";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 175;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Attributes";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Reference ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 175;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(779, 227);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Product Price Details";
            // 
            // dataGridViewProductPriceDetails
            // 
            this.dataGridViewProductPriceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductPriceDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewProductPriceDetails.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProductPriceDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewProductPriceDetails.Name = "dataGridViewProductPriceDetails";
            this.dataGridViewProductPriceDetails.RowHeadersWidth = 51;
            this.dataGridViewProductPriceDetails.RowTemplate.Height = 24;
            this.dataGridViewProductPriceDetails.Size = new System.Drawing.Size(779, 251);
            this.dataGridViewProductPriceDetails.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 175;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Attributes";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Reference ID";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 175;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage6.Size = new System.Drawing.Size(779, 227);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Product Order Details";
            // 
            // dataGridViewProductOrderDetails
            // 
            this.dataGridViewProductOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductOrderDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewProductOrderDetails.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewProductOrderDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewProductOrderDetails.Name = "dataGridViewProductOrderDetails";
            this.dataGridViewProductOrderDetails.RowHeadersWidth = 51;
            this.dataGridViewProductOrderDetails.RowTemplate.Height = 24;
            this.dataGridViewProductOrderDetails.Size = new System.Drawing.Size(773, 251);
            this.dataGridViewProductOrderDetails.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Value";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 175;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "Attributes";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Reference ID";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 175;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage5.Size = new System.Drawing.Size(779, 227);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Product Details";
            // 
            // dataGridViewProductDetails
            // 
            this.dataGridViewProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewProductDetails.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewProductDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewProductDetails.Name = "dataGridViewProductDetails";
            this.dataGridViewProductDetails.RowHeadersWidth = 51;
            this.dataGridViewProductDetails.RowTemplate.Height = 24;
            this.dataGridViewProductDetails.Size = new System.Drawing.Size(773, 251);
            this.dataGridViewProductDetails.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Value";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 175;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "Attributes";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Reference ID";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 175;
            // 
            // toolStrip10
            // 
            this.toolStrip10.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip10.Location = new System.Drawing.Point(0, 279);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(787, 27);
            this.toolStrip10.TabIndex = 3;
            // 
            // identificationDataBtn
            // 
            this.identificationDataBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.identificationDataBtn.Image = ((System.Drawing.Image)(resources.GetObject("identificationDataBtn.Image")));
            this.identificationDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.identificationDataBtn.Location = new System.Drawing.Point(0, 0);
            this.identificationDataBtn.Margin = new System.Windows.Forms.Padding(0);
            this.identificationDataBtn.Name = "identificationDataBtn";
            this.identificationDataBtn.Size = new System.Drawing.Size(787, 23);
            this.identificationDataBtn.TabIndex = 0;
            this.identificationDataBtn.Text = "Identification Data";
            this.identificationDataBtn.UseVisualStyleBackColor = true;
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(57, 24);
            this.toolStripButton7.Text = "Cancel";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(47, 24);
            this.toolStripButton8.Text = "Clear";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(44, 24);
            this.toolStripButton9.Text = "Save";
            // 
            // commercialDataBtn
            // 
            this.commercialDataBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.commercialDataBtn.Image = ((System.Drawing.Image)(resources.GetObject("commercialDataBtn.Image")));
            this.commercialDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.commercialDataBtn.Location = new System.Drawing.Point(0, 0);
            this.commercialDataBtn.Margin = new System.Windows.Forms.Padding(0);
            this.commercialDataBtn.Name = "commercialDataBtn";
            this.commercialDataBtn.Size = new System.Drawing.Size(787, 23);
            this.commercialDataBtn.TabIndex = 0;
            this.commercialDataBtn.Text = "Commercial Data";
            this.commercialDataBtn.UseVisualStyleBackColor = true;
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(57, 24);
            this.toolStripButton13.Text = "Cancel";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.Size = new System.Drawing.Size(47, 24);
            this.toolStripButton14.Text = "Clear";
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.Size = new System.Drawing.Size(44, 24);
            this.toolStripButton15.Text = "Save";
            // 
            // DeviceDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Page0_FullWindow);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DeviceDescription";
            this.Size = new System.Drawing.Size(1750, 866);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Page0_FullWindow.ResumeLayout(false);
            this.Page0_FullWindowPanel2.ResumeLayout(false);
            this.Page0_FullWindowPanel2.PerformLayout();
            this.Page0_FastFullWindow.ResumeLayout(false);
            this.Page0_FastFullWindow2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.dataTabControl.ResumeLayout(false);
            this.genericData.ResumeLayout(false);
            this.Page1_MainPanel.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genericInformationDataGridView)).EndInit();
            this.deleteRoleClassesButton.ResumeLayout(false);
            this.deleteRoleClassesButton.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genericparametersAttrDataGridView)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.Interface.ResumeLayout(false);
            this.electricalInterfacesPanel.ResumeLayout(false);
            this.electricalInterfacesPanel.PerformLayout();
            this.Page3_BottomPanel.ResumeLayout(false);
            this.Page3_BottomPanel.PerformLayout();
            this.tabControlElectricalAttributes.ResumeLayout(false);
            this.attributestab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.elecInterAttDataGridView)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.Page3_TopPanel.ResumeLayout(false);
            this.Page3_TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electricalInterfacesCollectionDataGridView)).EndInit();
            this.toolStrip24.ResumeLayout(false);
            this.toolStrip24.PerformLayout();
            this.DocsTabPage.ResumeLayout(false);
            this.addPicturesandDocsPanel.ResumeLayout(false);
            this.addPicturesandDocsPanel.PerformLayout();
            this.Page2_BottomPanel.ResumeLayout(false);
            this.Page2_BottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachablesInfoDataGridView)).EndInit();
            this.toolStrip19.ResumeLayout(false);
            this.toolStrip19.PerformLayout();
            this.Page2_VerstecktesPanel.ResumeLayout(false);
            this.Page2_VerstecktesPanel.PerformLayout();
            this.toolStrip13.ResumeLayout(false);
            this.toolStrip13.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.treeViewPanel.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.Page0_RoleClassPanel.ResumeLayout(false);
            this.Page0_RoleClassPanel.PerformLayout();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.treeViewInterfaceClassLibPanel.ResumeLayout(false);
            this.treeViewInterfaceClassLibPanel.PerformLayout();
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.identificationDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManufacturerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductPriceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip toolStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel Page0_FullWindow;
        private System.Windows.Forms.Panel Page0_FullWindowPanel2;
        private System.Windows.Forms.Panel Page0_FastFullWindow;
        private System.Windows.Forms.TabControl dataTabControl;
        private System.Windows.Forms.Panel Page0_FastFullWindow2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel treeViewPanel;
        private System.Windows.Forms.TabPage DocsTabPage;
        private System.Windows.Forms.Panel addPicturesandDocsPanel;
        private System.Windows.Forms.ToolStrip toolStrip13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button selectFileBtn;
        private System.Windows.Forms.Button selectURLBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel Page2_BottomPanel;
        private System.Windows.Forms.ToolStrip toolStrip19;
        private System.Windows.Forms.ToolStripLabel toolStripLabel12;
        private System.Windows.Forms.Panel Page2_VerstecktesPanel;
        private System.Windows.Forms.TextBox selectedFileLocationTxtBx;
        private System.Windows.Forms.ToolStripComboBox automationMLRoleCmbBx;
        private System.Windows.Forms.ToolStripLabel AutomationMLRole;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripButton addRole;
        private System.Windows.Forms.ToolStripButton clearSelectedRowBtn;
        private System.Windows.Forms.Panel Page0_RoleClassPanel;
        private System.Windows.Forms.TreeView treeViewRoleClassLib;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ImageList imageListRCL;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripforInterfaceClassLib;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton helpButton;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.TabPage Interface;
        private System.Windows.Forms.Panel electricalInterfacesPanel;
        private System.Windows.Forms.Panel Page3_TopPanel;
        private System.Windows.Forms.DataGridView electricalInterfacesCollectionDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip24;
        private System.Windows.Forms.Panel treeViewInterfaceClassLibPanel;
        private System.Windows.Forms.ToolStripButton deleterowsInelectricalInterfacesDataGridView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridView elecInterAttDataGridView;
        private System.Windows.Forms.DataGridView attachablesInfoDataGridView;
        private System.Windows.Forms.Button identificationDataBtn;
        private System.Windows.Forms.DataGridView identificationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceID;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.Button commercialDataBtn;
        private System.Windows.Forms.TabControl commercialDataTabControl;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.DataGridView dataGridViewManufacturerDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridViewProductPriceDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridViewProductOrderDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridViewProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.Panel Page3_BottomPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControlElectricalAttributes;
        private System.Windows.Forms.TabPage attributestab;
        private System.Windows.Forms.ToolStripLabel electricalInterfacesHeaderlabel;
        private System.Windows.Forms.TreeView treeViewElectricalInterfaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.TextBox selectedFileURLTextBox;
        private System.Windows.Forms.Label AMLfileLabel;
        private System.Windows.Forms.Label AMLURLLabel;
        private System.Windows.Forms.TabPage genericData;
        private System.Windows.Forms.Panel Page1_MainPanel;
        private System.Windows.Forms.ToolStripDropDownButton fileButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importIODDFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGSDFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLibraryFile;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel filePathLabel;
        private System.Windows.Forms.ToolStripTextBox vendorNameTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox deviceNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedClassorInterface;
        private System.Windows.Forms.DataGridViewCheckBoxColumn libraryFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn componentFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add;
        private System.Windows.Forms.ToolStripDropDownButton librariesSplitButton;
        private System.Windows.Forms.ToolStripMenuItem automationComponentLibraryv100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automationComponentLibraryv100CAEX3BETAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automationComponentLibraryv100FullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automationComponentLibraryv100FullCAEX3BETAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electricConnectorLibraryv100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem industrialSensorLibraryv100ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewInterfaceClassLib;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripLabel InterfaceClassLibLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView genericInformationtreeView;
        private System.Windows.Forms.DataGridView genericInformationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewCheckBoxColumn loadfromLibrary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn loadFromComponentFile;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.ToolStrip deleteRoleClassesButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel20;
        private System.Windows.Forms.ToolStripButton deleteRoleClassButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView genericparametersAttrDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel genericDataHeaderLabel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caexVersionFileToolStripMenuItem;
    }
}
