namespace LocalFlagCalculator
{
    public partial class FlagCalculator : Form
    {
        private Dictionary<CheckBox, Enum> flagMappings;
        private FlagOperations logic = new FlagOperations();


        public FlagCalculator()
        {
            InitializeComponent();
            InitializeFlagMappings();
            RegisterCheckBoxEvents();
            InitializeTooltips();

            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);

        }

        private void InitializeFlagMappings()
        {
            flagMappings = new Dictionary<CheckBox, Enum>
            {
                { LOCAL_FLAG_KOREA,                                      Local_Flags.LOCAL_FLAG_KOREA },
                { LOCAL_FLAG_HONGKONG,                                   Local_Flags.LOCAL_FLAG_HONGKONG},
                { LOCAL_FLAG_AMERICA,                                    Local_Flags.LOCAL_FLAG_AMERICA},
                { LOCAL_FLAG_GERMAN,                                     Local_Flags.LOCAL_FLAG_GERMAN},
                { LOCAL_FLAG_JAPAN,                                      Local_Flags.LOCAL_FLAG_JAPAN},
                { LOCAL_FLAG_TAIWAN,                                     Local_Flags.LOCAL_FLAG_TAIWAN},
                { LOCAL_FLAG_CHINA,                                      Local_Flags.LOCAL_FLAG_CHINA},
                { LOCAL_FLAG_FRANCE,                                     Local_Flags.LOCAL_FLAG_FRANCE},
                { LOCAL_FLAG_RUSSIA,                                     Local_Flags.LOCAL_FLAG_RUSSIA},
                { LOCAL_FLAG_MALAYSIA,                                   Local_Flags.LOCAL_FLAG_MALAYSIA},
                { LOCAL_FLAG_SINGAPORE,                                  Local_Flags.LOCAL_FLAG_SINGAPORE},
                { LOCAL_FLAG_VIETNAM,                                    Local_Flags.LOCAL_FLAG_VIETNAM},
                { LOCAL_FLAG_THAILAND,                                   Local_Flags.LOCAL_FLAG_THAILAND},
                { LOCAL_FLAG_MIDEAST,                                    Local_Flags.LOCAL_FLAG_MIDEAST},
                { LOCAL_FLAG_TURKEY,                                     Local_Flags.LOCAL_FLAG_TURKEY},
                { LOCAL_FLAG_POLAND,                                     Local_Flags.LOCAL_FLAG_POLAND},
                { LOCAL_FLAG_ITALY,                                      Local_Flags.LOCAL_FLAG_ITALY},
                { LOCAL_FLAG_BRAZIL,                                     Local_Flags.LOCAL_FLAG_BRAZIL},
                { LOCAL_FLAG_ESPANIA,                                    Local_Flags.LOCAL_FLAG_ESPANIA},
                { LOCAL_FLAG_INDONESIA,                                  Local_Flags.LOCAL_FLAG_INDONESIA},
                { LOCAL_FLAG_TEST_SERV,                                  Local_Flags.LOCAL_FLAG_TEST_SERV},
                { LOCAL_FLAG_SERVICE_SERV,                               Local_Flags.LOCAL_FLAG_SERVICE_SERV},
                { STATE_TIME_FLAG_ERASE_ON_DEAD,                         State_Time_Flags.ERASE_ON_DEAD                   },
                { STATE_TIME_FLAG_ERASE_ON_LOGOUT,                       State_Time_Flags.ERASE_ON_LOGOUT                 },
                { STATE_TIME_FLAG_DECREASE_ON_LOGOUT,                    State_Time_Flags.TIME_DECREASE_ON_LOGOUT         },
                { STATE_TIME_FLAG_NOT_ACTABLE_TO_BOSS,                   State_Time_Flags.NOT_ACTABLE_TO_BOSS             },
                { STATE_TIME_FLAG_NOT_ERASABLE,                          State_Time_Flags.NOT_ERASABLE                    },
                { STATE_TIME_FLAG_ERASE_ON_REQUEST,                      State_Time_Flags.ERASE_ON_REQUEST                },
                { STATE_TIME_FLAG_ERASE_ON_DAMAGED,                      State_Time_Flags.ERASE_ON_DAMAGED                },
                { STATE_TIME_FLAG_ERASE_ON_RESURRECT,                    State_Time_Flags.ERASE_ON_RESURRECT              },
                { STATE_TIME_FLAG_ERASE_ON_QUIT_HUNTAHOLIC,              State_Time_Flags.ERASE_ON_QUIT_HUNTAHOLIC        },
                { STATE_TIME_FLAG_ERASE_ON_QUIT_DEATHMATCH,              State_Time_Flags.ERASE_ON_QUIT_DEATHMATCH        },
                { STATE_TIME_FLAG_NOT_ERASABLE_ON_ENTER_DEATHMATCH,      State_Time_Flags.NOT_ERASABLE_ON_ENTER_DEATHMATCH},
                { STATE_TIME_FLAG_NOT_ACTABLE_ON_DEATHMATCH,             State_Time_Flags.NOT_ACTABLE_ON_DEATHMATCH       },
                { STATE_TIME_FLAG_ERASE_ON_COMPETE_START,                State_Time_Flags.ERASE_ON_COMPETE_START          },
                { STATE_TIME_FLAG_NOT_ACTABLE_IN_COMPETE,                State_Time_Flags.NOT_ACTABLE_IN_COMPETE          },
                { STATE_TIME_FLAG_ONLY_FOR_WORLD_STATE,                  State_Time_Flags.ONLY_FOR_WORLD_STATE            },
                { STATE_TIME_FLAG_ERASE_ON_QUIT_BATTLE_ARENA,            State_Time_Flags.ERASE_ON_QUIT_BATTLE_ARENA      },
                { STATE_TIME_FLAG_ERASE_ON_STAND_UP,                     State_Time_Flags.ERASE_ON_STAND_UP               },
                { STATE_TIME_FLAG_UNKNOW1,                               State_Time_Flags.UNKNOW1                         },
                { STATE_TIME_FLAG_UNKNOW2,                               State_Time_Flags.UNKNOW2                         },
                { STATE_TIME_FLAG_UNKNOW3,                               State_Time_Flags.UNKNOW3                         }
            };

        }

        private void InitializeTooltips()
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;

            toolTip.ShowAlways = true;

            // Dodawanie podpowiedzi do ka¿dego CheckBox
            toolTip.SetToolTip(this.LOCAL_FLAG_KOREA, "Wyjaœnienie dla flagi Korei.");
            toolTip.SetToolTip(this.STATE_TIME_FLAG_ERASE_ON_DEAD, "Wyjaœnienie dla opcji 'Erase on Dead'.");
            // ... i tak dalej dla ka¿dego CheckBox
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ResetCheckBoxes(flagMappings);
        }

        private void RegisterCheckBoxEvents()
        {
            foreach (var checkBox in flagMappings.Keys)
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
            int result = logic.CalculateFlags(flagMappings);
            textBox1.Text = result.ToString();
        }

        private void Button_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Button_Import_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Clipboard.GetText(), out int flags))
            {
                logic.UpdateCheckBoxes(flagMappings, flags);
            }
            else
            {
                MessageBox.Show("The clipboard does not contain a valid number.");
            }
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            logic.ResetCheckBoxes(flagMappings);
        }
    }
}
