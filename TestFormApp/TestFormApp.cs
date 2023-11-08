namespace TestFormApp
{
    public partial class TestFormApp : Form
    {
        private const string SHOW_LABEL = "Show Label";
        private const string HIDE_LABEL = "Hide Label";

        private int total_TestLabels = 0;

        public TestFormApp()
        {
            InitializeComponent();

            Click += (sender, e) =>
            {
                var clickEvent = (MouseEventArgs)e;
                AddLabelOnClick(clickEvent.X, clickEvent.Y);
            };
        }

        private void AddLabelOnClick(int x, int y)
        {
            var label = new Label
            {
                Text = "Test",
                Size = new Size(100, 20),
                Location = new Point(x, y),
            };

            Controls.Add(label);
            CountTestLabels();
            SetTestLabelCountLabel();
        }

        private void clickMeBtn_Click(object sender, EventArgs e)
        {
            this.displayLabel.Visible = !this.displayLabel.Visible;
            if (this.displayLabel.Visible)
                this.clickMeBtn.Text = HIDE_LABEL;
            else this.clickMeBtn.Text = SHOW_LABEL;
        }

        private void CountTestLabels()
        {
            int testLabelCount = 0;
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(Label) 
                    && ((Label)control).Name != "displayLabel" 
                    && ((Label)control).Name != "testLabelCount")
                {
                    testLabelCount++;
                }
            }

            total_TestLabels = testLabelCount;
        }

        private void SetTestLabelCountLabel()
        {
            this.testLabelCount.Text = $"Test Labels: {total_TestLabels}";
        }
    }
}