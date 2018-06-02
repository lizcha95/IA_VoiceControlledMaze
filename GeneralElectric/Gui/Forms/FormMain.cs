namespace Gui.Forms
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Drawing;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.Globalization;
    using System.Collections.Generic;
    using Logic;
    using Logic.Classes;
    using PagedList;
    using MaterialSkin.Controls;
    using MaterialSkin;

    public partial class FormMain : MaterialForm
    {

        private int pageNumberAgent = 1;
        private int pageNumberOrder = 1;


        private IPagedList<Agent> AgentsList;
        private IPagedList<Order> OrdersList;

        private Context currentContext;
        private GeneticAllocator geneticAllocator;

        private int generationLimit;

        //Speech Recognition
        private SpeechRecognitionEngine recorder;
        private SpeechSynthesizer speaker;
        private CultureInfo cultureInfo;
        

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;
            this.geneticAllocator = new GeneticAllocator(
                this.currentContext.Agents,
                this.currentContext.Services,
                this.currentContext.Orders
            );
            this.geneticAllocator.ProgressChanged += this.GeneticAllocator_ProgressChanged;
            this.geneticAllocator.RunWorkerCompleted += this.GeneticAllocator_RunWorkerCompleted;
            this.geneticAllocator.Stopped += this.GeneticAllocator_Stopped;

            this.generationLimit = 10; // Hay que poner una opción para modificar esto.

            this.recorder = new SpeechRecognitionEngine();
            this.speaker = new SpeechSynthesizer();
            this.cultureInfo = new CultureInfo("en-US");
            CreateGrammar();
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeDesignDataGridViews();
            
        }

        private void CreateGrammar()
        {

            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += delegate (object s, EventArgs ee)
            {
                ((Timer)s).Stop();
                try
                {
                    Choices commands = new Choices();
                    commands.Add(new string[] { "load data", "assign", "load agents", "load orders", "finish", "previous agents", "next agents",
                                                "previous orders", "next orders", "assign orders"});
                    GrammarBuilder gb = new GrammarBuilder();
                    gb.Culture = this.cultureInfo; // English Idiom
                    gb.Append(commands);

                    Grammar grammar = new Grammar(gb);
                    this.recorder.LoadGrammar(grammar); // Add grammar to the recognizer
                    this.recorder.SetInputToDefaultAudioDevice(); // Use the microphone
                    this.speaker.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior, 0, this.cultureInfo);
                    this.recorder.RecognizeAsync(RecognizeMode.Multiple);
                    this.speaker.SpeakAsync("Hello, Welcome to General Electric Services");
                    this.speaker.SpeakAsync("To change the window say load data or assign");
                    this.speaker.SpeakAsync("In the load data window you can load service agents and service orders");
                    this.speaker.SpeakAsync("To load service agents' table say load agents");
                    this.speaker.SpeakAsync("To load service orders' table say load orders");

                    this.recorder.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognized_listener);

                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("No se puede iniciar");
                }
            };

            timer.Start();


        }
        private async void recognized_listener(object sender, SpeechRecognizedEventArgs e)
        {
            float confidence = e.Result.Confidence;

            if (confidence < 0.65)
            {
                speaker.SpeakAsync("Speak louder, I don't understand what you say");
                return;

            }

            Console.WriteLine(e.Result.Text);

            if (e.Result.Text == "load data")
            {
                if (materialTabControl1.SelectedIndex != 0)
                {
                    materialTabControl1.SelectedTab = LoadData;

                    this.speaker.SpeakAsync("To load service agents' table say load agents");
                    this.speaker.SpeakAsync("To load service orders' table say load orders");

                }
                else
                {
                    speaker.SpeakAsync("You are already positioned in the tab load data");
                }

            }

            else if (e.Result.Text == "assign")
            {
                if (materialTabControl1.SelectedIndex != 1)
                {
                    materialTabControl1.SelectedTab = AssignOrders;

                    this.speaker.SpeakAsync("In the assign window you can assign service orders to the service agents");
                    this.speaker.SpeakAsync("To assign service orders say assign orders");
                    
                }
                else
                {
                    speaker.SpeakAsync("You are already positioned in the tab assign orders");
                    this.speaker.SpeakAsync("To assign service orders say assign orders");

                }

            }

            else if (e.Result.Text == "load agents")
            {
                if (materialTabControl1.SelectedIndex == 0)
                {
                    AgentsList = await GetPagedAgentsList();
                    this.gridViewAgents.DataSource = AgentsList.ToList();
                    this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);

                    speaker.SpeakAsync("You can say next agent or previous agent to look all the agents in the table");

                }
                else
                {
                    speaker.SpeakAsync("to load data, you must be positioned in the load data tab");
                }
            }

            else if (e.Result.Text == "load orders")
            {
                if (materialTabControl1.SelectedIndex == 0)
                {
                    OrdersList = await GetPagedOrdersList();
                    this.gridViewOrders.DataSource = OrdersList.ToList();
                    this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
                    speaker.SpeakAsync("You can say next order or previous order to look all the orders in the table");

                }
                else
                {
                    speaker.SpeakAsync("to load orders, you must be positioned in the load data tab");
                }
            }

            else if (e.Result.Text == "previous agents")
            {
                if (AgentsList.HasPreviousPage)
                {
                    AgentsList = await GetPagedAgentsList(--pageNumberAgent);
                    this.gridViewAgents.DataSource = AgentsList.ToList();
                    this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);
                }
                else
                {
                    speaker.SpeakAsync("there is not previous page");
                }
            }

            else if (e.Result.Text == "next agents")
            {
                if (AgentsList.HasNextPage)
                {
                    AgentsList = await GetPagedAgentsList(++pageNumberAgent);
                    this.gridViewAgents.DataSource = AgentsList.ToList();
                    this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);
                }
                else
                {
                    speaker.SpeakAsync("there is not next page");
                }
            }

            else if (e.Result.Text == "previous orders")
            {
                if (OrdersList.HasPreviousPage)
                {
                    OrdersList = await GetPagedOrdersList(--pageNumberOrder);;
                    this.gridViewOrders.DataSource = OrdersList.ToList();
                    this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
                }
                else
                {
                    speaker.SpeakAsync("there is not previous page");
                }
            }

            else if (e.Result.Text == "next orders")
            {
                if (OrdersList.HasNextPage)
                {
                    OrdersList = await GetPagedOrdersList(++pageNumberOrder);
                    this.gridViewOrders.DataSource = OrdersList.ToList();
                    this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
                }
                else
                {
                    speaker.SpeakAsync("there is not next page");
                }
            }
            else if (e.Result.Text == "assign orders")
            {
                if (materialTabControl1.SelectedIndex == 1)
                {
                    this.geneticAllocator.Execute(this.generationLimit);
                    speaker.SpeakAsync("Wait while the service assignment ends");
                }
                else
                {
                    speaker.SpeakAsync("to assign orders, you must be positioned in the assign tab");
                }
            }

            else if (e.Result.Text == "finish")
            {
                this.Close();
                speaker.SpeakAsync("Good Bye");
                return;
            }

        }
        private void InitializeDesignDataGridViews()
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700,Primary.BlueGrey700,Primary.BlueGrey500,Accent.LightBlue200,TextShade.WHITE);

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
            this.gridViewAgents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0,0,0);
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
;
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

        private void GeneticAllocator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.listBoxLog.Invoke(new Action(() =>
            {
                this.listBoxLog.Items.Add(e.UserState);
                this.listBoxLog.TopIndex = this.listBoxLog.Items.Count - 1;
            }));
        }

        private void GeneticAllocator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Esto se ejecuta cuando el algoritmo genético terminó. Falta imprimir los resultados.
        }

        private void GeneticAllocator_Stopped(object sender, EventArgs e)
        {
            // Esto se ejecuta cuando se cancela el proceso.
        }

        public async Task<IPagedList<Agent>> GetPagedAgentsList(int pageNumber = 1, int pageSize = 20)
        {

            return await Task.Factory.StartNew(() =>
            {
                return this.currentContext.Agents.ToPagedList(pageNumber, pageSize);

            });
        }


        public async Task<IPagedList<Order>> GetPagedOrdersList(int pageNumber = 1, int pageSize = 20){

              return await Task.Factory.StartNew(() =>
              {
                  return this.currentContext.Orders.ToPagedList(pageNumber,pageSize);

              });
          }

        private async void ButtonLoadAgents_Click(object sender, System.EventArgs e)
        {
            AgentsList = await GetPagedAgentsList();
            this.gridViewAgents.DataSource = AgentsList.ToList();
            this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);


        }

        private async void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
           
             OrdersList = await GetPagedOrdersList();
             this.gridViewOrders.DataSource = OrdersList.ToList();
             this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
        }        

        IEnumerable<object> GetPage(IEnumerable<object> input, int page, int pagesize)
        {
            return input.Skip(page * pagesize).Take(pagesize);
        }

        
        private async void ButtonNextAgent_Click(object sender, EventArgs e)
        {
            if (AgentsList.HasNextPage)
              {
                  AgentsList = await GetPagedAgentsList(++pageNumberAgent);
                  this.gridViewAgents.DataSource = AgentsList.ToList();
                  this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);
              }
        }

        private async void ButtonPreviousAgent_Click(object sender, EventArgs e)
        {
            if (AgentsList.HasPreviousPage)
            {
                AgentsList = await GetPagedAgentsList(--pageNumberAgent);
                this.gridViewAgents.DataSource = AgentsList.ToList();
                this.materialLabel3.Text = string.Format("Page {0}/{1}", pageNumberAgent, AgentsList.PageCount);
            }
        }
        private async void ButtonPreviousOrder_Click(object sender, EventArgs e)
        {
           
            if (OrdersList.HasPreviousPage)
            {
                OrdersList = await GetPagedOrdersList(--pageNumberOrder);
                this.gridViewOrders.DataSource = OrdersList.ToList();
                this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
            }

        }

        private async void ButtonNextOrder_Click(object sender, EventArgs e)
        {
            if (OrdersList.HasNextPage)
             {

                 OrdersList = await GetPagedOrdersList(++pageNumberOrder);
                 this.gridViewOrders.DataSource = OrdersList.ToList();
                 this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumberOrder, OrdersList.PageCount);
             }
        }

        private void ButtonAssignOrders_Click(object sender, EventArgs e)
        {
            this.geneticAllocator.Execute(this.generationLimit);
        }

        }
    }
  
    

        
    

