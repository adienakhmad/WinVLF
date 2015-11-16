using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleVLF
{
    public partial class SVLF
    {
        private string FindUniqeName(string originalName, ListView view)
        {
            // Find unique name if there is duplicate.
            var num = 2;
            var newname = originalName;

            while (view.Items.ContainsKey(newname))
            {
                newname = $"{originalName}({num})";
                num++;
            }

            return newname;
        }
    }
}
