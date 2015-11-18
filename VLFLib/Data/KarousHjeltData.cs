﻿using System;

namespace VLFLib.Data
{
    public class KarousHjeltData
    {
        public string Name;
        public float Spacing;
        public int RawLength;
        public bool IsNormalized;
        public float SkinDepth;
        public int DepthLevel;

        public float[] DistanceArray { get; }

        public float[] DepthArray { get; }

        public float[] KarousHjeltArray { get; }

        public KarousHjeltData(string name, float spacing, int rawlength, float skindepth, int dlevel,float[] distArray, float[] depthArray,
            float[] kharray)
        {
            Name = name;
            Spacing = spacing;
            SkinDepth = skindepth;
            RawLength = rawlength;
            DepthLevel = dlevel;
            DistanceArray = distArray;
            DepthArray = depthArray;
            KarousHjeltArray = kharray;

            if (skindepth > 0)
            {
                IsNormalized = true;
            }

        }

        public void Export(string filename)
        {
            throw new NotImplementedException();
        }

    }
}