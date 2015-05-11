using System;
using FileHelpers;

namespace Simple_VLF
{
    [DelimitedRecord("	")]
    public sealed class VLF_KarousHjeltRecord
    {

        private Double mDistance;

        public Double Distance
        {
            get { return mDistance; }
            set { mDistance = value; }
        }


        private Double mDepth;

        public Double Depth
        {
            get { return mDepth; }
            set { mDepth = value; }
        }


        private Double mKH;

        public Double KH
        {
            get { return mKH; }
            set { mKH = value; }
        }

        public VLF_KarousHjeltRecord(double distance, double depth, double khvalue)
        {
            mDistance = distance;
            mDepth = depth;
            mKH = khvalue;
        }

        public VLF_KarousHjeltRecord()
        {
            
        }



    }
}
