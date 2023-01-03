// #######################################################
// Copyright (c) VAVE 2022-23. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: Form1.cs
// Description: Main form for DesktopWidgets
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/12/29
// Last Updated: 2023/01/03
// #######################################################
// 

using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.IO;
using static DesktopWidgets.Utilities;
using System.Collections.Generic;

namespace DesktopWidgets {
    public partial class Form1 : Form {
        string saveDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VAVE\\DesktopWidgets\\widgets.json";
        string currentVer = "1.1.0";

        public Form1() {
            InitializeComponent();
        }

        public void LoadData() {
            var json = JsonConvert.DeserializeObject<SerializationSchema.Root>(File.ReadAllText(saveDataPath));

            if (json.Version == currentVer) {
                foreach (var widget in json.OpenWidgets) {
                    var frm = new Widget(widget.Path);
                    frm.Show();
                    frm.Location = JsonToPoint(widget.Location);
                    frm.Size = JsonToSize(widget.Scale);
                }
            }
            else {
                MessageBox.Show("Your DesktopWidgets save data may be corrupted or you are on an outdated version of the application.\nVersion data does not match application manifest");
            }
        }

        public void SaveData() {
            try {
                var root = new SerializationSchema.Root();

                root.OpenWidgets = new List<SerializationSchema.OpenWidget>();

                foreach (Form frm in Application.OpenForms) {
                    if (frm.GetType() == typeof(Widget)) {
                        Widget widget = (Widget)frm;

                        var entry = new SerializationSchema.OpenWidget();

                        entry.Location = PointToJson(frm.Location);
                        entry.Scale = SizeToJson(frm.Size);

                        entry.Path = widget.FilePath;

                        root.OpenWidgets.Add(entry);
                    }
                }

                root.LastSaved = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                root.Version = currentVer;

                var serialized = JsonConvert.SerializeObject(root);

                File.WriteAllText(saveDataPath, serialized);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void fromFileToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                var form = new Widget(openFileDialog1.FileName);
                form.Show();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveData();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Hide();

            LoadData();

            timer1.Start();
        }
    }
}
