namespace TestFormApp
{
    public partial class TestFormApp : Form
    {
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
        }
    }
}