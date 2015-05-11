using System;
using FileHelpers;

namespace Simple_VLF
{
    [IgnoreFirst(1)]
// ReSharper disable once RedundantAttributeParentheses
    [IgnoreEmptyLines()]
    [IgnoreCommentedLines("#", true)]
    [DelimitedRecord("	")]
    public sealed class VLF_SurveyRecord
    {

        private Double mDistance;

        public Double Distance
        {
            get { return mDistance; }
            set { mDistance = value; }
        }


        private Double mTilt;

        public Double Tilt
        {
            get { return mTilt; }
            set { mTilt = value; }
        }


        private Double mEllips;

        public Double Ellips
        {
            get { return mEllips; }
            set { mEllips = value; }
        }



    }
}