using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Defacto.ScormAnalysis.Core
{
   public class ScormAnalysisReportCreationException : Exception
   {
      public ScormAnalysisReportCreationException() : base("An unknown exception has occurred whilst creating the SCORM analysis report.") { }
   }
}
