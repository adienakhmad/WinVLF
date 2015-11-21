using System;

namespace VLFLib.Data
{
    [Serializable]
    public class FraserData : VLFDataBase
    {
        
        internal FraserData(string name, int count, float spacing, float[] distances, float[] fraserValue): base(name,count,spacing,distances,fraserValue)
        {
            
        }

        public override void ExportToFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
