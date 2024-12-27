using System.ComponentModel;
using System.Reflection;

namespace LocalFlagCalculator.LocalFlagCalculator
{
    public partial class FlagCalculator : Form
    {
        private Dictionary<CheckBox, Enum> flagMappings;
        private FlagOperations logic = new FlagOperations();

        public FlagCalculator()
        {
            InitializeComponent();
            Initialize();
        }

        // Initialize all necessary components and setup methods
        private void Initialize()
        {
            flagMappings = new Dictionary<CheckBox, Enum>();
            GenerateTabsAndCheckBoxes();
            InitializeTooltips();
            RegisterCheckBoxEvents();
            AttachEventHandlers();
        }

        // Attach necessary event handlers
        private void AttachEventHandlers()
        {
            this.tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            this.Resize += FlagCalculator_Resize;
            this.Resize += (sender, e) => CenterBottomControls();
        }

        // Handle form resizing to adjust tab control and bottom buttons
        private void FlagCalculator_Resize(object sender, EventArgs e)
        {
            ResizeTabControl();
            CenterBottomControls();
            GenerateTabsAndCheckBoxes();  // Regenerate tabs on resize to adjust layout
        }

        // Adjust tab control size dynamically based on form resizing
        private void ResizeTabControl()
        {
            tabControl1.Width = this.ClientSize.Width;
            tabControl1.Height = this.ClientSize.Height - 80;

            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                tabPage.Width = tabControl1.ClientSize.Width - 10;
                tabPage.Height = tabControl1.ClientSize.Height - 30;
            }
        }

        // Center bottom control buttons and textbox horizontally
        private void CenterBottomControls()
        {
            int formWidth = this.ClientSize.Width;
            int centerX = formWidth / 2;

            int buttonWidth = Button_Reset.Width;
            int textBoxWidth = textBox1.Width;
            int buttonSpacing = 10;

            int totalWidth = buttonWidth * 2 + textBoxWidth + buttonSpacing * 2;
            int startX = centerX - totalWidth / 2;

            // Set new positions for buttons and textbox
            Button_Copy.Left = startX;
            textBox1.Left = Button_Copy.Right + buttonSpacing;
            Button_Import.Left = textBox1.Right + buttonSpacing;
            Button_Reset.Left = centerX - (Button_Reset.Width / 2);

            // Vertical alignment
            int bottomPadding = 50;
            Button_Copy.Top = this.ClientSize.Height - Button_Copy.Height - bottomPadding;
            textBox1.Top = Button_Copy.Top;
            Button_Import.Top = Button_Copy.Top;
            Button_Reset.Top = Button_Copy.Bottom + 10;
        }

        // Generate tabs for each enum type and dynamically create checkboxes
        private void GenerateTabsAndCheckBoxes()
        {
            tabControl1.TabPages.Clear();

            Type[] enumTypes = new Type[]
            {
                typeof(Local_Flags),
                typeof(State_Time_Flags),
                typeof(AttributeFlags),
                typeof(ResistanceFlags),
                typeof(EquipmentFlags)
            };

            foreach (var enumType in enumTypes)
            {
                GenerateTabForEnum(enumType);
            }

            LoadDynamicEnums();
        }
        // Generate tab for hardcoded enums
        private void GenerateTabForEnum(Type enumType)
        {
            TabPage tabPage = new TabPage
            {
                Text = GetEnumDisplayName(enumType),
                AutoScroll = false
            };

            tabControl1.TabPages.Add(tabPage);
            GenerateCheckBoxesFromEnum(tabPage, enumType, 10, 20, 25, 200, tabControl1.Height - 50);
        }

        // Load enums from file dynamically
        private void LoadDynamicEnums()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/enums.json");
            var loader = new EnumLoader();

            try
            {
                var dynamicEnums = loader.LoadEnums(filePath);

                foreach (var dynamicEnum in dynamicEnums)
                {
                    // Create a new tab for each dynamic enum
                    TabPage tabPage = new TabPage
                    {
                        Text = dynamicEnum.EnumName.Replace('_', ' '),
                        AutoScroll = false
                    };

                    tabControl1.TabPages.Add(tabPage);

                    // Dynamically create the enum type
                    Type dynamicType = EnumBuilderHelper.CreateEnum(dynamicEnum.EnumName, dynamicEnum.Values);

                    int y = 20;
                    foreach (var value in dynamicEnum.Values)
                    {
                        int calculatedValue = value.GetCalculatedValue();  // Przesuniêcie bitowe
                        CheckBox checkBox = new CheckBox
                        {
                            Text = value.DisplayName,
                            Location = new Point(10, y),
                            AutoSize = true,
                            Tag = calculatedValue
                        };

                        // Create enum value and map it to checkbox
                        Enum dynamicValue = (Enum)Enum.ToObject(dynamicType, calculatedValue);
                        flagMappings.Add(checkBox, dynamicValue);
                        tabPage.Controls.Add(checkBox);

                        y += 30;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        // Generate checkboxes dynamically from enum values
        private void GenerateCheckBoxesFromEnum(TabPage tabPage, Type enumType, int startX, int startY, int yOffset, int columnWidth, int maxHeight)
        {
            int x = startX;
            int y = startY;
            int currentMaxWidth = 0;
            int columnMaxWidth = 0;
            tabPage.Controls.Clear();

            foreach (var value in Enum.GetValues(enumType))
            {
                string displayName = EnumUtils.GetEnumDisplayName((Enum)value);

                CheckBox checkBox = new CheckBox
                {
                    Text = displayName,
                    Location = new Point(x, y),
                    AutoSize = true,
                    Tag = value
                };

                flagMappings.Add(checkBox, (Enum)value);
                tabPage.Controls.Add(checkBox);

                int checkBoxWidth = checkBox.PreferredSize.Width;
                columnMaxWidth = Math.Max(columnMaxWidth, checkBoxWidth);

                y += yOffset;

                // Move to new column if the height limit is reached
                if (y + yOffset > maxHeight)
                {
                    y = startY;
                    x += columnMaxWidth + 20;
                    currentMaxWidth = Math.Max(currentMaxWidth, x);
                    columnMaxWidth = 0;
                }
            }

            tabPage.AutoScrollMinSize = new Size(currentMaxWidth + columnMaxWidth, maxHeight);
        }

        // Reset checkboxes when tab changes
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.ResetCheckBoxes(flagMappings);
        }

        // Initialize tooltips for checkboxes (optional enhancement)
        private void InitializeTooltips()
        {
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };
        }

        // Register events for all checkboxes
        private void RegisterCheckBoxEvents()
        {
            foreach (var checkBox in flagMappings.Keys)
            {
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
            }
        }

        // Update flags when checkbox state changes
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFlags();
        }

        // Calculate and display updated flags
        private void UpdateFlags()
        {
            int result = logic.CalculateFlags(flagMappings);
            textBox1.Text = result.ToString();
        }

        // Copy flag result to clipboard
        private void Button_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        // Import flag values from clipboard
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

        // Reset all checkboxes
        private void Button_Reset_Click(object sender, EventArgs e)
        {
            logic.ResetCheckBoxes(flagMappings);
        }

        // Get display name for enum types
        private string GetEnumDisplayName(Type enumType)
        {
            var description = enumType.GetCustomAttribute<DescriptionAttribute>();
            return description != null ? description.Description : enumType.Name.Replace('_', ' ');
        }
    }
}
