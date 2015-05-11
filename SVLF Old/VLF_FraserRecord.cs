using System;
using FileHelpers;

namespace Simple_VLF
{
    [DelimitedRecord("	")]
    public sealed class VLF_FraserRecord
    {

        private Double mDistance;

        public Double Distance
        {
            get { return mDistance; }
            set { mDistance = value; }
        }


        private Double mFraser;

        public Double Fraser
        {
            get { return mFraser; }
            set { mFraser = value; }
        }

        public VLF_FraserRecord()
        {
            
        }
        public VLF_FraserRecord(double distance, double fraser)
        {
            mDistance = distance;
            mFraser = fraser;
        }
    }
}
    
    
