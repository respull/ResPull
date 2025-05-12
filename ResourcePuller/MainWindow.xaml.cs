using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Vestris.ResourceLib;

namespace ResourcePuller
{
    public partial class MainWindow : MetroWindow
    {
        private string openedFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Executable Files (*.exe;*.dll)|*.exe;*.dll"
            };

            if (dlg.ShowDialog() == true)
            {
                openedFilePath = dlg.FileName;
                LoadResources(openedFilePath);
            }
        }

        private void LoadResources(string filePath)
        {
            ResourceTree.Items.Clear();

            try
            {
                var resources = new ResourceInfo();
                resources.Load(filePath);

                foreach (var res in resources)
                {
                    string typeName = res.Type.ToString();
                    string name = res.Name.ToString();
                    string lang = res.Language.ToString();

                    // Find or create the type node
                    var typeNode = ResourceTree.Items.Cast<TreeViewItem>()
                        .FirstOrDefault(n => n.Header.ToString() == typeName);

                    if (typeNode == null)
                    {
                        typeNode = new TreeViewItem { Header = typeName };
                        ResourceTree.Items.Add(typeNode);
                    }

                    // Find or create the name node under the type
                    var nameNode = typeNode.Items.Cast<TreeViewItem>()
                        .FirstOrDefault(n => n.Header.ToString() == name);

                    if (nameNode == null)
                    {
                        nameNode = new TreeViewItem { Header = name };
                        typeNode.Items.Add(nameNode);
                    }

                    // Add the language node, this is the leaf with actual resource
                    var langNode = new TreeViewItem
                    {
                        Header = $"Lang: {lang}",
                        Tag = res
                    };
                    langNode.Selected += ResourceItem_Selected;
                    nameNode.Items.Add(langNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading resources: " + ex.Message);
            }
        }


        private void ResourceItem_Selected(object sender, RoutedEventArgs e)
        {
            e.Handled = true;

            if (sender is TreeViewItem item && item.Tag is Resource resource)
            {
                try
                {
                    if (resource is GenericResource generic)
                    {
                        var data = generic.Data;
                        ResourceEditor.Text = System.Text.Encoding.UTF8.GetString(data);
                    }
                    else
                    {
                        ResourceEditor.Text = "Selected resource type not editable in this preview.";
                    }
                }
                catch (Exception ex)
                {
                    ResourceEditor.Text = "Error displaying resource: " + ex.Message;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(openedFilePath))
            {
                MessageBox.Show("No file is open.");
                return;
            }

            if (ResourceTree.SelectedItem is TreeViewItem item && item.Tag is GenericResource generic)
            {
                try
                {
                    var newData = System.Text.Encoding.UTF8.GetBytes(ResourceEditor.Text);
                    generic.Data = newData;

                    var tempFile = Path.Combine(Path.GetDirectoryName(openedFilePath), "modified_" + Path.GetFileName(openedFilePath));
                    File.Copy(openedFilePath, tempFile, true);
                    generic.SaveTo(tempFile);

                    MessageBox.Show("Resource saved to: " + tempFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Saving is only supported for editable RCData resources.");
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.Owner = this;
            aboutWindow.ShowDialog();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
