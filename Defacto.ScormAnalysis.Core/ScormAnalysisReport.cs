using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Defacto.ScormAnalysis.Core
{
   public sealed class ScormAnalysisReport
   {
      #region Instantiation

      public static ScormAnalysisReport TryCreate(FileStream fileStream)
      {
         return new ScormAnalysisReport(ZipFileHelper.GetFileStreamAsZipFile(fileStream));
      }

      #endregion

      #region Constructor

      private ScormAnalysisReport(ZipFile zipFile)
      {
         ImsManifestExtractor.Load(zipFile);
      }

      #endregion

      #region Nested type: IMSManifestExtractor

      private static class ImsManifestExtractor
      {
         public static void Load(ZipFile zipFile)
         {
            if (zipFile.FindEntry("imsmanifest.xml", true) == -1)
               throw new ScormAnalysisReportCreationException("The loaded package does not contain an 'IMSManifest.xml'-file.");
         }
      }

      #endregion

      #region Nested type: ZipFileHelper

      private static class ZipFileHelper
      {
         public static ZipFile GetFileStreamAsZipFile(FileStream fileStream)
         {
            try
            {
               return new ZipFile(fileStream);
            }
            catch (ZipException)
            {
               throw new ScormAnalysisReportCreationException();
            }
         }
      }
      #endregion
   }
}
