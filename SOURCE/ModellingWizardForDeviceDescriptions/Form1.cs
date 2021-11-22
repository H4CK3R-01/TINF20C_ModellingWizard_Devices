using Aml.Engine.AmlObjects;
using Aml.Engine.CAEX;
using Aml.Engine.CAEX.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // this.FormClosing += new FormClosingEventHandler(exitToolStripMenuItem_Click);
            // TODO Ask if user really wants to exit if Program.unsavedChanges is true
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.caexDocument = CAEXDocument.New_CAEXDocument();
            Program.unsavedChanges = true;
            loadData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.filepath == string.Empty)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                Program.caexDocument.SaveToFile(Program.filepath, true);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "AML Files (*.aml; *.amlx; *.xml; *.AML ) | *.aml; *.amlx; *.xml; *.AML;";
            save.FileName = textBoxVendor.Text + "-" + textBoxDevice.Text + "-V.1.0-" + DateTime.Now.Date.ToShortDateString();
            save.FilterIndex = 2;
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                Program.filepath = save.FileName;
                Program.caexDocument.SaveToFile(Program.filepath, true);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "AML Files (*.aml; *.amlx; *.xml; *.AML ) | *.aml; *.amlx; *.xml; *.AML;";
            open.FilterIndex = 2;
            open.RestoreDirectory = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
                Program.filepath = open.FileName;
                Program.filetype = null;
                if ((Program.filetype = Convert.ToString(Path.GetExtension(Program.filepath))) == ".amlx")
                {
                    // TODO
                    // AMLX Package
                }
                else
                {
                    Program.caexDocument = CAEXDocument.LoadFromFile(Program.filepath);
                    loadData();
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void loadLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program.unsavedChanges)
            {
                Application.Exit();
            }
            else
            {
                DialogResult dialog = new DialogResult();

                dialog = MessageBox.Show("Save changes before exiting?", "Alert!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (dialog == DialogResult.No)
                {
                    Application.Exit();
                }
                else if (dialog == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://github.com/H4CK3R-01/TINF20C_ModellingWizard_Devices/wiki")
            {
                UseShellExecute = true
            };
            Process.Start(ps);
        }

        private void expertModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switchMode(!Program.expertMode);
        }


        private void loadData()
        {
            clearData();

            // Change title of window to filepath or "New Document"
            if (Program.filepath != String.Empty)
            {
                this.Text += " - " + Program.filepath;
            }
            else
            {
                this.Text += " - New Document";
            }


            // Basic document information
            if (Program.caexDocument.CAEXFile.SourceDocumentInformation.Exists)
            {
                var documentInformation = Program.caexDocument.CAEXFile.SourceDocumentInformation[0];

                fillDataGrid(dataGridView2, "Name", "", documentInformation.OriginProjectTitle, "", "", "", "SourceDocumentInformation");
                fillDataGrid(dataGridView2, "Version", "", documentInformation.OriginVersion, "", "", "", "SourceDocumentInformation");
                fillDataGrid(dataGridView2, "Release", "", documentInformation.OriginRelease, "", "", "", "SourceDocumentInformation");
                fillDataGrid(dataGridView2, "Vendor", "", documentInformation.OriginVendor, "", "", "", "SourceDocumentInformation");
                fillDataGrid(dataGridView2, "Vendor URL", "", documentInformation.OriginVendorURL, "", "", "", "SourceDocumentInformation");
                fillDataGrid(dataGridView2, "Last write time", "", documentInformation.LastWritingDateTime.ToString(), "", "", "", "SourceDocumentInformation");

                textBoxVendor.Text = documentInformation.OriginVendor;
                textBoxDevice.Text = documentInformation.OriginProjectTitle;
            }
            else
            {
                // TODO Create attributes
            }

            // only CAEX3.0 documents allow to add an attribute type library
            if (Program.caexDocument.Schema == CAEXDocument.CAEXSchema.CAEX3_0)
            {
                AutomationMLBaseAttributeTypeLibType.AttributeTypeLib(Program.caexDocument);
            }


            // Parse CAEX file structure and create RoleClassLib-Tree
            foreach (var rl in Program.caexDocument.CAEXFile.RoleClassLib)
            {
                var node = treeView1.Nodes.Add(rl.Name);
                node.Tag = rl;
                foreach (var rc in rl.RoleClass)
                {
                    foreach (AttributeType attribute in rc.Attribute)
                    {
                        fillDataGrid(dataGridView2, attribute.Name, attribute.Description, attribute.Value, attribute.Unit, attribute.DefaultValue, attribute.AttributeDataType, rl.Name);
                    }

                    ShowRoleClasses(node, rc);
                }
            }

            // Parse CAEX file structure and create InterfaceClassLib-Tree
            foreach (var il in Program.caexDocument.CAEXFile.InterfaceClassLib)
            {
                var node = treeView2.Nodes.Add(il.Name);
                node.Tag = il;
                foreach (var ic in il.InterfaceClass)
                {
                    foreach (AttributeType attribute in ic.Attribute)
                    {
                        fillDataGrid(dataGridView2, attribute.Name, attribute.Description, attribute.Value, attribute.Unit, attribute.DefaultValue, attribute.AttributeDataType, il.Name);
                    }

                    ShowInterfaceClasses(node, ic);
                }
            }
        }

        // https://github.com/AutomationML/AMLEngine2.1/blob/master/Samples/ApplicationTutorialForBasics/src/Form1.cs
        private void ShowMyInternalElement(TreeNode node, InternalElementType ie)
        {
            var childNode = node.Nodes.Add(ie.Name);
            childNode.Tag = ie;
            foreach (var childIe in ie.InternalElement)
            {
                ShowMyInternalElement(childNode, childIe);
            }
        }

        private void ShowRoleClasses(TreeNode node, RoleFamilyType rc)
        {
            var childNode = node.Nodes.Add(rc.Name);
            childNode.Tag = rc;
            foreach (var childRc in rc.RoleClass)
            {
                foreach (AttributeType attribute in childRc.Attribute)
                {
                    fillDataGrid(dataGridView2, attribute.Name, attribute.Description, attribute.Value, attribute.Unit, attribute.DefaultValue, attribute.AttributeDataType, childRc.Name);
                }

                ShowRoleClasses(childNode, childRc);
            }
        }

        private void ShowInterfaceClasses(TreeNode node, InterfaceFamilyType ic)
        {
            var childNode = node.Nodes.Add(ic.Name);
            childNode.Tag = ic;
            foreach (var childRc in ic.InterfaceClass)
            {
                foreach (AttributeType attribute in childRc.Attribute)
                {
                    fillDataGrid(dataGridView2, attribute.Name, attribute.Description, attribute.Value, attribute.Unit, attribute.DefaultValue, attribute.AttributeDataType, childRc.Name);
                }

                ShowInterfaceClasses(childNode, childRc);
            }
        }

        private void fillDataGrid(DataGridView grid, String name, String description, String value, String unit, String defaultValue, String attributeDataType, String lib)
        {
            DataGridViewRow row = (DataGridViewRow)grid.Rows[0].Clone();
            row.Cells[0].Value = name;
            row.Cells[1].Value = description;
            row.Cells[2].Value = value;
            row.Cells[3].Value = unit;
            row.Cells[4].Value = defaultValue;
            row.Cells[5].Value = attributeDataType;
            row.Cells[7].Value = lib;
            grid.Rows.Add(row);
        }

        private void clearData()
        {
            this.Text = "AutomationML ModellingWizard";

            textBoxDevice.Text = "";
            textBoxVendor.Text = "";

            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();

            genericDataGridView.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        public void switchMode(Boolean expert)
        {
            Program.expertMode = expert;
            this.Semantic.Visible = expert;
            this.Default.Visible = expert;
            this.DataType.Visible = expert;

            if (Program.expertMode)
            {
                this.expertModeToolStripMenuItem.Text = "Switch to easy mode";
            }
            else
            {
                this.expertModeToolStripMenuItem.Text = "Switch to expert mode";
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Debug.WriteLine(treeView1.SelectedNode.Text);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[7].ToString().Trim().Contains(treeView1.SelectedNode.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    try
                    {
                        row.Visible = false;
                    }
                    catch (System.InvalidOperationException)
                    {
                        Debug.WriteLine(row);
                    }
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Debug.WriteLine(row.Cells[7].Value + " " + treeView2.SelectedNode.Text);
                if(row.Cells[7].Value != null)
                {
                    if (row.Cells[7].Value.ToString().Contains(treeView2.SelectedNode.Text))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
    }
}
