using System;
using System.Collections.Generic;
using VLFLib.Data;

namespace SimpleVLF
{
    [Serializable]
    public class VlfProject
    {
        public string Name { get; }
        public int Version { get; }
        public ICollection<TiltData> TiltDatas { get; }
        public ICollection<FraserData> FraserDatas { get; }
        public ICollection<KarousHjeltData> KarousHjeltDatas { get; }

        public VlfProject(string name1, int version, ICollection<TiltData> tiltDatas, ICollection<FraserData> fraserDatas, ICollection<KarousHjeltData> karousHjeltDatas)
        {
            TiltDatas = tiltDatas;
            FraserDatas = fraserDatas;
            KarousHjeltDatas = karousHjeltDatas;
            Version = version;
            Name = name1;
        }

        public VlfProject()
        {
            Name = string.Empty;
            TiltDatas = new List<TiltData>();
            FraserDatas = new List<FraserData>();
            KarousHjeltDatas = new List<KarousHjeltData>();
        }
    }
}
