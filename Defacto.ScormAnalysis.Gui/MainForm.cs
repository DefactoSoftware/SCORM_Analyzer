using Defacto.ScormAnalysis.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Defacto.ScormAnalysis.Gui
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         switch (openScormModuleZipFileDialog.ShowDialog())
         {
            case System.Windows.Forms.DialogResult.OK:
               ScormAnalysisReport scormAnalysisReport;
               try
               {
                  using (FileStream file = File.Open(openScormModuleZipFileDialog.FileName, FileMode.Open))
                     scormAnalysisReport = ScormAnalysisReport.TryCreate(file);
               }
               catch (ScormAnalysisReportCreationException ex)
               {
                  MessageBox.Show(ex.Message, "Unexpected exception encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               break;
         }
      }
   }
}
