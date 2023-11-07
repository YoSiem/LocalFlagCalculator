namespace LocalFlagCalculator
{
    public partial class FlagCalculator : Form
    {
        private Dictionary<CheckBox, int> localFlagMappings;
        // private Dictionary<CheckBox, int> itemFlagMappings;
        // private Dictionary<CheckBox, int> stateFlagMappings;

        public FlagCalculator()
        {
            InitializeComponent();
            InitializeFlagMappings();
        }

        private void InitializeFlagMappings()
        {
            localFlagMappings = new Dictionary<CheckBox, int>
            {
                { LOCAL_FLAG_KOREA,         (int)Local_Flags.LOCAL_FLAG_KOREA },
                { LOCAL_FLAG_HONGKONG,      (int)Local_Flags.LOCAL_FLAG_HONGKONG},
                { LOCAL_FLAG_AMERICA,       (int)Local_Flags.LOCAL_FLAG_AMERICA},
                { LOCAL_FLAG_GERMAN,        (int)Local_Flags.LOCAL_FLAG_GERMAN},
                { LOCAL_FLAG_JAPAN,         (int)Local_Flags.LOCAL_FLAG_JAPAN},
                { LOCAL_FLAG_TAIWAN,        (int)Local_Flags.LOCAL_FLAG_TAIWAN},
                { LOCAL_FLAG_CHINA,         (int)Local_Flags.LOCAL_FLAG_CHINA},
                { LOCAL_FLAG_FRANCE,        (int)Local_Flags.LOCAL_FLAG_FRANCE},
                { LOCAL_FLAG_RUSSIA,        (int)Local_Flags.LOCAL_FLAG_RUSSIA},
                { LOCAL_FLAG_MALAYSIA,      (int)Local_Flags.LOCAL_FLAG_MALAYSIA},
                { LOCAL_FLAG_SINGAPORE,     (int)Local_Flags.LOCAL_FLAG_SINGAPORE},
                { LOCAL_FLAG_VIETNAM,       (int)Local_Flags.LOCAL_FLAG_VIETNAM},
                { LOCAL_FLAG_THAILAND,      (int)Local_Flags.LOCAL_FLAG_THAILAND},
                { LOCAL_FLAG_MIDEAST,       (int)Local_Flags.LOCAL_FLAG_MIDEAST},
                { LOCAL_FLAG_TURKEY,        (int)Local_Flags.LOCAL_FLAG_TURKEY},
                { LOCAL_FLAG_POLAND,        (int)Local_Flags.LOCAL_FLAG_POLAND},
                { LOCAL_FLAG_ITALY,         (int)Local_Flags.LOCAL_FLAG_ITALY},
                { LOCAL_FLAG_BRAZIL,        (int)Local_Flags.LOCAL_FLAG_BRAZIL},
                { LOCAL_FLAG_ESPANIA,       (int)Local_Flags.LOCAL_FLAG_ESPANIA},
                { LOCAL_FLAG_INDONESIA,     (int)Local_Flags.LOCAL_FLAG_INDONESIA},
                { LOCAL_FLAG_TEST_SERV,     (int)Local_Flags.LOCAL_FLAG_TEST_SERV},
                { LOCAL_FLAG_SERVICE_SERV,  (int)Local_Flags.LOCAL_FLAG_SERVICE_SERV}
            };

            //TODO: Other flags.


            foreach (var checkBox in localFlagMappings.Keys)
            {
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags();
        }

        private void UpdateFlags()
        {
            int flags = FlagUtility.CalculateFlags(localFlagMappings);
            textBox1.Text = flags.ToString();
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Clipboard.GetText(), out int flags))
            {
                foreach (var mapping in localFlagMappings)
                {
                    mapping.Key.Checked = (flags & mapping.Value) != 0;
                }
            }
            else
            {
                MessageBox.Show("The clipboard does not contain a valid number.");
            }
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            ResetCheckBoxes();
        }
        private void ResetCheckBoxes()
        {
            foreach (var checkBox in localFlagMappings.Keys)
            {
                checkBox.Checked = false;
            }
        }

    }
}
