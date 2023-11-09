namespace LocalFlagCalculator
{
    public partial class FlagCalculator : Form
    {
        private Dictionary<CheckBox, Local_Flags> localFlagMappings;
        private Dictionary<CheckBox, State_Time_Flags> stateTimeFlagMappings;


        public FlagCalculator()
        {
            InitializeComponent();
            InitializeFlagMappings();
            RegisterCheckBoxEvents();

            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
        }

        private void InitializeFlagMappings()
        {
            localFlagMappings = new Dictionary<CheckBox, Local_Flags>
            {
                { LOCAL_FLAG_KOREA,         Local_Flags.LOCAL_FLAG_KOREA },
                { LOCAL_FLAG_HONGKONG,      Local_Flags.LOCAL_FLAG_HONGKONG},
                { LOCAL_FLAG_AMERICA,       Local_Flags.LOCAL_FLAG_AMERICA},
                { LOCAL_FLAG_GERMAN,        Local_Flags.LOCAL_FLAG_GERMAN},
                { LOCAL_FLAG_JAPAN,         Local_Flags.LOCAL_FLAG_JAPAN},
                { LOCAL_FLAG_TAIWAN,        Local_Flags.LOCAL_FLAG_TAIWAN},
                { LOCAL_FLAG_CHINA,         Local_Flags.LOCAL_FLAG_CHINA},
                { LOCAL_FLAG_FRANCE,        Local_Flags.LOCAL_FLAG_FRANCE},
                { LOCAL_FLAG_RUSSIA,        Local_Flags.LOCAL_FLAG_RUSSIA},
                { LOCAL_FLAG_MALAYSIA,      Local_Flags.LOCAL_FLAG_MALAYSIA},
                { LOCAL_FLAG_SINGAPORE,     Local_Flags.LOCAL_FLAG_SINGAPORE},
                { LOCAL_FLAG_VIETNAM,       Local_Flags.LOCAL_FLAG_VIETNAM},
                { LOCAL_FLAG_THAILAND,      Local_Flags.LOCAL_FLAG_THAILAND},
                { LOCAL_FLAG_MIDEAST,       Local_Flags.LOCAL_FLAG_MIDEAST},
                { LOCAL_FLAG_TURKEY,        Local_Flags.LOCAL_FLAG_TURKEY},
                { LOCAL_FLAG_POLAND,        Local_Flags.LOCAL_FLAG_POLAND},
                { LOCAL_FLAG_ITALY,         Local_Flags.LOCAL_FLAG_ITALY},
                { LOCAL_FLAG_BRAZIL,        Local_Flags.LOCAL_FLAG_BRAZIL},
                { LOCAL_FLAG_ESPANIA,       Local_Flags.LOCAL_FLAG_ESPANIA},
                { LOCAL_FLAG_INDONESIA,     Local_Flags.LOCAL_FLAG_INDONESIA},
                { LOCAL_FLAG_TEST_SERV,     Local_Flags.LOCAL_FLAG_TEST_SERV},
                { LOCAL_FLAG_SERVICE_SERV,  Local_Flags.LOCAL_FLAG_SERVICE_SERV}
            };

            stateTimeFlagMappings = new Dictionary<CheckBox, State_Time_Flags>
            {
                {STATE_TIME_FLAG_ERASE_ON_DEAD,                         State_Time_Flags.ERASE_ON_DEAD                   },
                {STATE_TIME_FLAG_ERASE_ON_LOGOUT,                       State_Time_Flags.ERASE_ON_LOGOUT                 },
                {STATE_TIME_FLAG_DECREASE_ON_LOGOUT,                    State_Time_Flags.TIME_DECREASE_ON_LOGOUT         },
                {STATE_TIME_FLAG_NOT_ACTABLE_TO_BOSS,                   State_Time_Flags.NOT_ACTABLE_TO_BOSS             },
                {STATE_TIME_FLAG_NOT_ERASABLE,                          State_Time_Flags.NOT_ERASABLE                    },
                {STATE_TIME_FLAG_ERASE_ON_REQUEST,                      State_Time_Flags.ERASE_ON_REQUEST                },
                {STATE_TIME_FLAG_ERASE_ON_DAMAGED,                      State_Time_Flags.ERASE_ON_DAMAGED                },
                {STATE_TIME_FLAG_ERASE_ON_RESURRECT,                    State_Time_Flags.ERASE_ON_RESURRECT              },
                {STATE_TIME_FLAG_ERASE_ON_QUIT_HUNTAHOLIC,              State_Time_Flags.ERASE_ON_QUIT_HUNTAHOLIC        },
                {STATE_TIME_FLAG_ERASE_ON_QUIT_DEATHMATCH,              State_Time_Flags.ERASE_ON_QUIT_DEATHMATCH        },
                {STATE_TIME_FLAG_NOT_ERASABLE_ON_ENTER_DEATHMATCH,      State_Time_Flags.NOT_ERASABLE_ON_ENTER_DEATHMATCH},
                {STATE_TIME_FLAG_NOT_ACTABLE_ON_DEATHMATCH,             State_Time_Flags.NOT_ACTABLE_ON_DEATHMATCH       },
                {STATE_TIME_FLAG_ERASE_ON_COMPETE_START,                State_Time_Flags.ERASE_ON_COMPETE_START          },
                {STATE_TIME_FLAG_NOT_ACTABLE_IN_COMPETE,                State_Time_Flags.NOT_ACTABLE_IN_COMPETE          },
                {STATE_TIME_FLAG_ONLY_FOR_WORLD_STATE,                  State_Time_Flags.ONLY_FOR_WORLD_STATE            },
                {STATE_TIME_FLAG_ERASE_ON_QUIT_BATTLE_ARENA,            State_Time_Flags.ERASE_ON_QUIT_BATTLE_ARENA      },
                {STATE_TIME_FLAG_ERASE_ON_STAND_UP,                     State_Time_Flags.ERASE_ON_STAND_UP               },
                {STATE_TIME_FLAG_UNKNOW1,                               State_Time_Flags.UNKNOW1                         },
                {STATE_TIME_FLAG_UNKNOW2,                               State_Time_Flags.UNKNOW2                         },
                {STATE_TIME_FLAG_UNKNOW3,                               State_Time_Flags.UNKNOW3                         }
            };
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetCheckBoxes();
        }

        private void RegisterCheckBoxEvents()
        {
            foreach (var checkBox in localFlagMappings.Keys)
            {
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            }
            foreach (var checkBox in stateTimeFlagMappings.Keys)
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
            var flags = GetCurrentFlagDictionary();
            int result = 0;
            foreach (var mapping in flags)
            {
                if (mapping.Key.Checked)
                {
                    result |= (int)(object)mapping.Value; // Casting to object first avoids boxing issues
                }
            }
            textBox1.Text = result.ToString();
        }

        private IDictionary<CheckBox, Enum> GetCurrentFlagDictionary()
        {
            // Assuming you have a TabControl named tabControl1
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    return localFlagMappings.ToDictionary(pair => pair.Key, pair => (Enum)pair.Value);
                case 1:
                    return stateTimeFlagMappings.ToDictionary(pair => pair.Key, pair => (Enum)pair.Value);
                default:
                    throw new InvalidOperationException("Unknown tab selected.");
            }
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Clipboard.GetText(), out int flags))
            {
                var currentMappings = GetCurrentFlagDictionary();
                foreach (var mapping in currentMappings)
                {
                    // Musimy przekonwertowaæ Enum na int, aby wykonaæ operacjê bitow¹
                    int mappingValue = Convert.ToInt32(mapping.Value);
                    mapping.Key.Checked = (flags & mappingValue) != 0;
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
            var flags = GetCurrentFlagDictionary();
            foreach (var checkBox in flags.Keys)
            {
                checkBox.Checked = false;
            }
        }

    }
}
