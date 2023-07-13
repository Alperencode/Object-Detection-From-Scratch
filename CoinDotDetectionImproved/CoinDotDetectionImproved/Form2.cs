namespace CoinDotDetectionImproved
{
    public partial class Form2 : Form
    {
        Form1 form;
        readonly string filePath;
        public Form2(Form1 form, string filePath) {
            this.form = form;
            this.filePath = filePath;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BlackSequenceLengthLabel_MouseHover(object sender, EventArgs e)
        {
            BlackSequenceToolTip.Show(
                "This argument updates Black and White image's pixel cleaning calculation" +
                "\nOptimal value is: 25" +
                "\nIncreasing it will slow the performance",
                BSLLabel
            );
        }

        private void HPTLabel_MouseHover(object sender, EventArgs e)
        {
            HPTToolTip.Show(
                "This argument determines how many black pixel will be tolerated in coin while detecting coin' height" +
                "\nOptimal value is: 50 (For default image)" +
                "\nIncreasing it may cause false detections",
                HPTLabel
            );
        }

        private void WPTLabel_MouseHover(object sender, EventArgs e)
        {
            WPTToolTip.Show(
                "This argument determines how many black pixel will be tolerated in coin while detecting coin' width" +
                "\nOptimal value is: 0 (For default image)" +
                "\nIncreasing it may cause false detections",
                WPTLabel
            );
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Updating values
            form.BlackSequenceLength = (int)BSLNumeric.Value;
            Methods.HeightTolerance = (int)HPTNumeric.Value;
            Methods.WidthTolerance = (int)WPTNumeric.Value;

            // Calling Main function
            form.Main(filePath);
        }
    }
}
