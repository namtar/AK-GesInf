using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AK_GesInf.classes;
using AK_GesInf.classes.utils;
using AK_GesInf.Properties;

namespace AK_GesInf
{
    public partial class Form1 : Form
    {
        private Icd10Loader icd10Loader;

        public Form1()
        {
            // @See: http://www.codeproject.com/Articles/15013/Windows-Forms-User-Settings-in-C
            InitializeComponent();

            icd10Loader = new Icd10Loader();
            ConfigListView();
            FillListViewData(new List<Pair<String, String>>());
//            FillIcd10View();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // when form loads perform Settings parameter
            if (Settings.Default.WindowState != null)
            {
                WindowState = Settings.Default.WindowState;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.WindowState = WindowState;

            // when storing windows size mention the window state, because when window is minimized or maximized we will get invalid values.
        }
       

        private void ConfigListView()
        {
            // some config
            icd10View.GridLines = true;
            icd10View.View = View.Details;
            //            icd10View.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FillListViewData(List<Pair<String, String>> data)
        {
            // @See: http://stackoverflow.com/questions/9008310/how-to-speed-adding-items-to-a-listview

            // clear listview
            icd10View.Columns.Clear();
            icd10View.Items.Clear();

            // add cols
            icd10View.Columns.Add("Code");
            icd10View.Columns.Add("Description");

            // add rows
//            foreach (var content in icd10Loader.Content)
            foreach (var content in data)
            {
                string[] arr = new string[2];
                arr[0] = content.Key;
                arr[1] = content.Value;
                icd10View.Items.Add(new ListViewItem(arr));
            }

            // finally size columns
            icd10View.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listViewSearchButton_Click(object sender, EventArgs e)
        {
            // perform a search in key and description for the given searchBox content.
            var searchString = listViewSearchBox.Text;
            List<Pair<String, String>> values = icd10Loader.Content;
            List<Pair<String, String>> searchResult = values.FindAll(delegate(Pair<String, String> pair)
            {
                if (pair.Key.StartsWith(searchString) || pair.Value.StartsWith(searchString))
                {
                    return true;
                }
                return false;
            });
            FillListViewData(searchResult);
        }
      
    }
}