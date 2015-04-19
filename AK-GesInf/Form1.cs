using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AK_GesInf.classes;
using AK_GesInf.classes.utils;

namespace AK_GesInf
{
    public partial class Form1 : Form
    {
        private Icd10Loader icd10Loader;

        public Form1()
        {
            InitializeComponent();

            icd10Loader = new Icd10Loader();
            FillIcd10View();
        }


        private void FillIcd10View()
        {
            // @See: http://stackoverflow.com/questions/9008310/how-to-speed-adding-items-to-a-listview

            // clear listview
            icd10View.Columns.Clear();
            icd10View.Items.Clear();

            // some config
            icd10View.GridLines = true;
            icd10View.View = View.Details;
//            icd10View.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // add cols
            icd10View.Columns.Add("Code");
            icd10View.Columns.Add("Description");
//            icd10View.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            // add rows
//            foreach (var content in icd10Loader.Content)
//            {
//                string[] arr = new string[2];
//                arr[0] = content.Key;
//                arr[1] = content.Value;
//                icd10View.Items.Add(new ListViewItem(arr));
//            }

            // Due to performance issues limit to 100 entires until there is a specification to do some paging.
            List<Pair<String, String>> contents = icd10Loader.Content;
            int to = contents.Count < 100 ? contents.Count : 100;
            for (var i = 0; i < 100; i++)
            {
                Pair<String, String> content = contents[i];

                string[] arr = new string[2];
                arr[0] = content.Key;
                arr[1] = content.Value;
                icd10View.Items.Add(new ListViewItem(arr));
            }

            // finally size columsn
            icd10View.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}