using System;

namespace VLFLib.Data
{
    class KarousHjeltData
    {
        public string Name;
        public float Spacing;
        public bool IsNormalized;
        public float SkinDepth;
        private float[] _distanceArray;
        private float[] _depthArray;
        private float[] _karousHjeltArray;

        public KarousHjeltData(string name, float spacing, float skindepth, float[] distArray, float[] depthArray,
            float[] kharray)
        {
            Name = name;
            Spacing = spacing;
            SkinDepth = skindepth;
            _distanceArray = distArray;
            _depthArray = depthArray;
            _karousHjeltArray = kharray;

        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }

    }
}
