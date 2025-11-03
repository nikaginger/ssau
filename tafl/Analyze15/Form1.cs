namespace Analyze15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Analyze.Analyzing(text.Text);
                idBox.Text = "";
                constBox.Text = "";
                errorMessage.Text = "Ошибок не найдено, строка принадлежит языку!";
                string[] res = Analyze.Analyzing(text.Text);
                idBox.Text = res[0];
                constBox.Text = res[1];
            }
            catch (ExceptionWithPosition ex)
            {
                idBox.Text = "";
                constBox.Text = "";
                errorMessage.Text = ex.Message;
                text.Focus();
                text.SelectionStart = ex.Position;

            }
        }

        private void text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
