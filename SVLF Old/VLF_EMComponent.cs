namespace Simple_VLF
{
    class VLF_EMComponent
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
    }

    static class VLF_EMComponents
    {
        public static VLF_EMComponent Real = new VLF_EMComponent
        {
            Type = "Real",Index = 0,Name = "Real (Tilt Angle)"

        };
        public static VLF_EMComponent Imaginary = new VLF_EMComponent
        {
            Type = "Imaginary",Index = 1,Name = "Imaginary (Ellipticity)"
        };
    }
}
