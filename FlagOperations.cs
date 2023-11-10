using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFlagCalculator
{
    public class FlagOperations
    {
        public int CalculateFlags(IEnumerable<KeyValuePair<CheckBox, Enum>> mappings)
        {
            int result = 0;
            foreach (var mapping in mappings)
            {
                if (mapping.Key.Checked)
                    result |= Convert.ToInt32(mapping.Value);
            }
            return result;
        }

        public void UpdateCheckBoxes(IDictionary<CheckBox, Enum> mappings, int flags)
        {
            foreach (var mapping in mappings)
            {
                int mappingValue = Convert.ToInt32(mapping.Value);
                mapping.Key.Checked = (flags & mappingValue) != 0;
            }
        }

        public void ResetCheckBoxes(IDictionary<CheckBox, Enum> mappings)
        {
            foreach (var checkBox in mappings.Keys)
            {
                checkBox.Checked = false;
            }
        }

        public void ResetAllCheckBoxes(IEnumerable<IDictionary<CheckBox, Enum>> checkBoxGroups)
        {
            foreach (var group in checkBoxGroups)
            {
                foreach (var checkBox in group.Keys)
                {
                    checkBox.Checked = false;
                }
            }
        }
    }
}
