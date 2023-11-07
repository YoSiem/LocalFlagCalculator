using System.Collections.Generic;
using System.Windows.Forms;

namespace LocalFlagCalculator
{
    public static class FlagUtility
    {

        public static int CalculateFlags(Dictionary<CheckBox, int> flagMappings)
        {
            int flags = 0;
            foreach (var mapping in flagMappings)
            {
                if (mapping.Key.Checked)
                {
                    flags |= mapping.Value;
                }
            }
            return flags;
        }

        public static void UpdateCheckBoxes(Dictionary<CheckBox, int> flagMappings, int flags)
        {
            foreach (var mapping in flagMappings)
            {
                mapping.Key.Checked = (flags & mapping.Value) != 0;
            }
        }

        public static void ResetCheckBoxes(Dictionary<CheckBox, int> flagMappings)
        {
            foreach (var checkBox in flagMappings.Keys)
            {
                checkBox.Checked = false;
            }
        }
    }
}
