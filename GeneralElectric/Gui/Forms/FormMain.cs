namespace Gui.Forms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Windows.Forms;
    using Logic.Classes;
    using Logic.Utils;
    using MaterialSkin;
    using MaterialSkin.Controls;
    using PagedList;

    public partial class FormMain : MaterialForm
    {
        private Context currentContext;
        private int generationLimit;

        // Data pages.
        private int currentIndexAgents = 1;
        private int currentIndexOrders = 1;
        private int currentIndexResult = 1;
        private IPagedList<Agent> currentPageAgents;
        private IPagedList<Order> currentPageOrders;
        private IPagedList<Assignment> currentPageResult;

        // Speech recognition.
        private SpeechRecognitionEngine recorder;
        private SpeechSynthesizer speaker;
        private CultureInfo cultureInfo;

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;

            this.generationLimit = 10; // Hay que poner una opción para modificar esto.

            this.cultureInfo = new CultureInfo("en-US");
            this.recorder = new SpeechRecognitionEngine(this.cultureInfo);
            this.speaker = new SpeechSynthesizer();

            this.CreateGrammar();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.InitializeDesignDataGridViews();
        }

        private void CreateGrammar()
        {
            Timer timer = new Timer
            {
                Interval = 1,
            };
            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((Timer)sender).Stop();
                try
                {
                    Choices commands = new Choices(Constants.Commands.COLLECTION);
                    GrammarBuilder grammarBuilder = new GrammarBuilder();
                    grammarBuilder.Culture = this.cultureInfo; // English language.
                    grammarBuilder.Append(commands);
                    Grammar grammar = new Grammar(grammarBuilder);

                    this.recorder.LoadGrammar(grammar); // Add grammar to the recognizer.
                    this.recorder.SetInputToDefaultAudioDevice(); // Use the microphone.
                    this.recorder.RecognizeAsync(RecognizeMode.Multiple);

                    this.speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior, 0, this.cultureInfo);
                    this.speaker.SpeakAsync(Constants.Messages.WELCOME);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_SWITCH);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_LOAD_DATA);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_LOAD_AGENTS);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_LOAD_ORDERS);
                    this.recorder.SpeechRecognized += this.Recognized_Listener;
                }
                catch (Exception)
                {
                    MessageBox.Show(this, Constants.Reports.SPEECH_ERROR);
                }
            };
            timer.Start();
        }

        private void Recognized_Listener(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < Constants.Percents.CONFIDENCE)
            {
                speaker.SpeakAsync(Constants.Messages.LOW_CONFIDENCE);
                return;
            }

            Console.WriteLine(e.Result.Text);
            switch (e.Result.Text)
            {
                case Constants.Commands.SWITCH:
                    if (this.materialTabControl.SelectedTab == this.LoadDataTab)
                    {
                        this.materialTabControl.SelectedTab = this.AssignOrdersTab;
                        this.speaker.SpeakAsync(Constants.Messages.ASSIGN_FUNCTIONALITY);
                        this.speaker.SpeakAsync(Constants.Messages.HINT_ASSIGN);
                    }
                    else
                    {
                        this.materialTabControl.SelectedTab = this.LoadDataTab;
                        this.speaker.SpeakAsync(Constants.Messages.HINT_LOAD_AGENTS);
                        this.speaker.SpeakAsync(Constants.Messages.HINT_LOAD_ORDERS);
                    }
                    break;
                case Constants.Commands.AGENTS_LOAD:
                    this.materialTabControl.SelectedTab = this.LoadDataTab;
                    this.currentIndexAgents = 1;
                    this.SetAgentsPage(1);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_PAGE_AGENTS);
                    break;
                case Constants.Commands.ORDERS_LOAD:
                    this.materialTabControl.SelectedTab = this.LoadDataTab;
                    this.currentIndexOrders = 1;
                    this.SetOrdersPage(1);
                    this.speaker.SpeakAsync(Constants.Messages.HINT_PAGE_ORDERS);
                    break;
                case Constants.Commands.AGENTS_PREVIOUS:
                    if (this.currentPageAgents != null)
                    {
                        if (this.currentPageAgents.HasPreviousPage)
                            this.SetAgentsPage(--this.currentIndexAgents);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_PREVIOUS_PAGE, "agents"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.LOAD_AGENTS_FIRST);
                    break;
                case Constants.Commands.AGENTS_NEXT:
                    if (this.currentPageAgents != null)
                    {
                        if (this.currentPageAgents.HasNextPage)
                            this.SetAgentsPage(++this.currentIndexAgents);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_NEXT_PAGE, "agents"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.LOAD_AGENTS_FIRST);
                    break;
                case Constants.Commands.ORDERS_PREVIOUS:
                    if (this.currentPageOrders != null)
                    {
                        if (this.currentPageOrders.HasPreviousPage)
                            this.SetOrdersPage(--this.currentIndexOrders);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_PREVIOUS_PAGE, "orders"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.LOAD_ORDERS_FIRST);
                    break;
                case Constants.Commands.ORDERS_NEXT:
                    if (this.currentPageOrders != null)
                    {
                        if (this.currentPageOrders.HasNextPage)
                            this.SetOrdersPage(++this.currentIndexOrders);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_NEXT_PAGE, "orders"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.LOAD_ORDERS_FIRST);
                    break;
                case Constants.Commands.RESULT_PREVIOUS:
                    if (this.currentPageResult != null)
                    {
                        if (this.currentPageResult.HasPreviousPage)
                            this.SetResultPage(--this.currentIndexResult);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_PREVIOUS_PAGE, "result"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.PROCESS_RUN_FIRST);
                    break;
                case Constants.Commands.RESULT_NEXT:
                    if (this.currentPageResult != null)
                    {
                        if (this.currentPageResult.HasNextPage)
                            this.SetResultPage(++this.currentIndexResult);
                        else
                            this.speaker.SpeakAsync(string.Format(Constants.Messages.NO_NEXT_PAGE, "result"));
                    }
                    else
                        this.speaker.SpeakAsync(Constants.Messages.PROCESS_RUN_FIRST);
                    break;
                case Constants.Commands.ASSIGN:
                    this.gridViewResults.DataSource = null;
                    this.currentIndexResult = 1;

                    this.materialTabControl.SelectedTab = this.AssignOrdersTab;
                    this.currentContext.CreateAllocator(
                        new ProgressChangedEventHandler(this.Allocator_ProgressChanged),
                        new RunWorkerCompletedEventHandler(this.Allocator_RunWorkerCompleted),
                        new EventHandler<EventArgs>(this.Allocator_Stopped)
                    );
                    this.currentContext.ExecuteAllocator(this.generationLimit);
                    speaker.SpeakAsync(Constants.Messages.PROCESS_WAIT);
                    break;
                case Constants.Commands.SKIP:
                    this.speaker.SpeakAsyncCancelAll();
                    break;
                case Constants.Commands.CLOSE:
                    this.speaker.Speak(Constants.Messages.GOOD_BYE);
                    Application.Exit();
                    break;
            }
        }

        private void SetAgentsPage(int number)
        {
            this.currentPageAgents = this.currentContext.GetAgentsPage(number);
            this.gridViewAgents.DataSource = currentPageAgents.ToList();
            this.labelPageNumberAgents.Text = this.currentPageAgents.GuideText();
        }

        private void SetOrdersPage(int number)
        {
            this.currentPageOrders = this.currentContext.GetOrdersPage(number);
            this.gridViewOrders.DataSource = this.currentPageOrders.ToList();
            this.labelPageNumberOrders.Text = this.currentPageOrders.GuideText();
        }

        private void SetResultPage(int number)
        {
            this.currentPageResult = this.currentContext.GetResultPage(number);
            this.gridViewResults.DataSource = this.currentPageResult.ToList();
            this.labelPageNumberResult.Text = this.currentPageResult.GuideText();
        }

        private void Allocator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.listBoxLog.SafeInvoke(new Action(() =>
            {
                this.listBoxLog.Items.Add(e.UserState);
                this.listBoxLog.TopIndex = this.listBoxLog.Items.Count - 1;
            }));
        }

        private void Allocator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.PrintResult();
        }

        private void Allocator_Stopped(object sender, EventArgs e)
        {
            if (this.currentContext.ResultAvailable)
                this.PrintResult();
        }

        private void PrintResult()
        {
            this.currentIndexResult = 1;
            this.SetResultPage(1);
            this.gridViewResults.DataSource = this.currentPageResult;
        }

        private void InitializeDesignDataGridViews()
        {
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey700, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.gridViewAgents.BorderStyle = BorderStyle.Fixed3D;
            this.gridViewAgents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewAgents.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.gridViewAgents.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            this.gridViewAgents.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewAgents.BackgroundColor = Color.White;

            this.gridViewAgents.EnableHeadersVisualStyles = false;
            this.gridViewAgents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewAgents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewAgents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewAgents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            this.gridViewAgents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.gridViewOrders.BorderStyle = BorderStyle.Fixed3D;
            this.gridViewOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewOrders.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.gridViewOrders.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
            this.gridViewOrders.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewOrders.BackgroundColor = Color.White;

            this.gridViewOrders.EnableHeadersVisualStyles = false;
            this.gridViewOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            this.gridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.gridViewResults.BorderStyle = BorderStyle.Fixed3D;
            this.gridViewResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewResults.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.gridViewResults.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.gridViewResults.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewResults.BackgroundColor = Color.White;

            this.gridViewResults.EnableHeadersVisualStyles = false;
            this.gridViewResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
            this.gridViewResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}