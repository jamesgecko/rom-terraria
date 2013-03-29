using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace RomTerraria
{
    public class ZipContentManager : ContentManager
    {
        private ZipFile zipFile = null;
        
        public ZipContentManager(IServiceProvider services, string zipFile) : base(services, "")
        {
            this.zipFile = new ZipFile(zipFile);
        }

        protected override System.IO.Stream OpenStream(string assetName)
        {            
            var entry = zipFile.GetEntry(assetName.Replace('\\','/') + ".xnb");
            if (entry != null)
            {
                return zipFile.GetInputStream(entry);
            }
            return null;
        }
    }
}
