using System;
using System.Collections.Generic;
using VLFLib.Data;

namespace VLFLib
{
    [Serializable]
    public class VlfProject
    {
        public string Name { get; }
        public int Version { get; }
        public int NObjects { get; set; }
        public List<string> NodeNames { get; }
        public ICollection<TiltData> TiltDatas { get; }
        public ICollection<FraserData> FraserDatas { get; }
        public ICollection<KarousHjeltData> KarousHjeltDatas { get; }
        public ICollection<Surface2D> Surface2DDatas { get; }

        public VlfProject(string name, int version, List<string> names,
            ICollection<TiltData> tiltDatas, ICollection<FraserData> fraserDatas,
            ICollection<KarousHjeltData> karousHjeltDatas, ICollection<Surface2D> surf2Ds)
        {
            NodeNames = names;
            TiltDatas = tiltDatas;
            FraserDatas = fraserDatas;
            KarousHjeltDatas = karousHjeltDatas;
            Version = version;
            Name = name;
            Surface2DDatas = surf2Ds;
            NObjects = TiltDatas.Count + FraserDatas.Count + KarousHjeltDatas.Count + Surface2DDatas.Count;
        }

        public VlfProject()
        {
            Name = string.Empty;
            TiltDatas = new List<TiltData>();
            FraserDatas = new List<FraserData>();
            KarousHjeltDatas = new List<KarousHjeltData>();
            Surface2DDatas = new List<Surface2D>();
            NObjects = 0;
            NodeNames = new List<string>();
        }
    }
}