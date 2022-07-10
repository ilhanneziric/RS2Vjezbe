namespace eProdaja.WinUI
{
    public partial class Form1 : Form
    {
        public APIService UserService { get; set; } = new APIService("Korisnici");

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var list = await UserService.Get<dynamic>();
        }
    }
}