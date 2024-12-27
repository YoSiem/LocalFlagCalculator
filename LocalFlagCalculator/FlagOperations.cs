using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocalFlagCalculator.LocalFlagCalculator
{
    public class FlagOperations
    {
        // Calculate flag value by combining all checked checkboxes
        public int CalculateFlags(IEnumerable<KeyValuePair<CheckBox, Enum>> mappings)
        {
            int result = 0;
            foreach (var mapping in mappings)
            {
                if (mapping.Key.Checked)
                {
                    result |= Convert.ToInt32(mapping.Value);
                }
            }
            return result;
        }

        // Update checkboxes based on the provided flag value
        public void UpdateCheckBoxes(IDictionary<CheckBox, Enum> mappings, int flags)
        {
            foreach (var mapping in mappings)
            {
                int mappingValue = Convert.ToInt32(mapping.Value);
                mapping.Key.Checked = (flags & mappingValue) != 0;
            }
        }

        // Reset all checkboxes to unchecked state
        public void ResetCheckBoxes(IDictionary<CheckBox, Enum> mappings)
        {
            foreach (var checkBox in mappings.Keys)
            {
                checkBox.Checked = false;
            }
        }

        // Reset all checkboxes across multiple groups
        public void ResetAllCheckBoxes(IEnumerable<IDictionary<CheckBox, Enum>> checkBoxGroups)
        {
            foreach (var group in checkBoxGroups)
            {
                ResetCheckBoxes(group);
            }
        }
    }
}
