using bpac;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SnipeIT_bPAC
{
    public partial class ServerForm : Form
    {
        public HttpListener? Listener;

        private bool StartMinimized = false;

        public ServerForm(string[] args)
        {
            if (args.Contains("-m"))
            {
                StartMinimized = true;
            }

            InitializeComponent();

            label_mode.Text = Environment.Is64BitProcess ? "64-bit" : "32-bit";
            label_mode.ForeColor = Environment.Is64BitProcess ? Color.DarkGreen : Color.DarkOrange;

            notifyIcon1.Icon = Icon;
            textBox_log.BackColor = Color.White;

            numericUpDown_port.DataBindings.Add("Value", Properties.Settings.Default, "ServerPort");
            textBox_accesskey.DataBindings.Add("Text", Properties.Settings.Default, "AccessKey");
            textBox_template.DataBindings.Add("Text", Properties.Settings.Default, "TemplateFile");
        }

        protected override void SetVisibleCore(bool value)
        {
            if (StartMinimized)
            {
                StartMinimized = false;
                base.SetVisibleCore(false);
                return;
            }
            base.SetVisibleCore(value);
        }

        private void Log(string data) => Invoke(() =>
        {
            textBox_log.AppendText("[" + DateTime.Now.ToString("G") + "] " + data + Environment.NewLine);
        });

        private void ServerForm_Load(object sender, EventArgs e)
        {
            button_start.PerformClick();
        }

        private void ServerForm_VisibleChanged(object sender, EventArgs e) => notifyIcon1.Visible = !Visible;

        private void ServerForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox_accesskey.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button_selectFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Title = "Select Template File",
                Filter = "Template Files|*.lbx|All Files|*.*",
                CheckFileExists = true,
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.TemplateFile = textBox_template.Text = dialog.FileName;
                SaveSettings();
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                var port = (ushort)numericUpDown_port.Value;

                Listener = new HttpListener();
                Listener.Prefixes.Add($"http://127.0.0.1:{port}/");

                Listener.Start();
                BeginGetContext();

                Log("Server started on port: " + port);
            }
            catch (Exception ex)
            {
                Log("Unable to start server: " + ex);
                return;
            }
            numericUpDown_port.Enabled = button_start.Enabled = false;
            button_stop.Enabled = true;
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            Listener?.Stop();
            Listener = null;
            Log("Server stopped");

            numericUpDown_port.Enabled = button_start.Enabled = true;
            button_stop.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/xWTF/SnipeIT-bPAC",
            UseShellExecute = true,
        });

        private void DoPrint(Dictionary<string, object>[] requests)
        {
            var document = new DocumentClass();
            if (!document.Open(textBox_template.Text))
            {
                throw new Exception("Print error: Unable to open template");
            }
            document.StartPrint("", PrintOptionConstants.bpoDefault);
            foreach (var r in requests)
            {
                foreach (var kv in r)
                {
                    var obj = document.GetObject(kv.Key);
                    if (obj != null)
                    {
                        obj.Text = kv.Value.ToString();
                    }
                }
                document.PrintOut(1, PrintOptionConstants.bpoDefault);
            }
            document.EndPrint();
            document.Close();
        }

        private void SaveSettings(object? sender = null, EventArgs? e = null) => Properties.Settings.Default.Save();

        private void HandleRequest(HttpListenerContext ctx)
        {
            var req = ctx.Request;
            if (req.Url?.AbsolutePath != "/print")
            {
                ctx.SendJson(new { code = 404 });
                return;
            }

            if (req.HttpMethod == "OPTIONS")
            {
                ctx.SendJson(null);
                return;
            }
            else if (req.HttpMethod != "POST")
            {
                ctx.SendJson(new { code = 403, msg = "bad method" });
                return;
            }

            var auth = req.Headers["Authorization"]?.Split(" ");
            if (auth == null || auth.Length != 2 || auth[0].ToLower() != "bearer" || auth[1] != Invoke(() => textBox_accesskey.Text))
            {
                Log("Access denied: " + req.RemoteEndPoint.ToString());
                ctx.SendJson(new { code = 403, msg = "access denied" });
                return;
            }

            using var reader = new StreamReader(req.InputStream, Encoding.UTF8);
            var requests = JsonSerializer.Deserialize<Dictionary<string, object>[]>(reader.ReadToEnd());
            if (requests == null)
            {
                ctx.SendJson(new { code = 400, msg = "Unable to deserialize the JSON" });
                return;
            }

            try
            {
                // Call the bPAC in STAThread
                Invoke(() => DoPrint(requests));

                Log("Printed " + requests.Length + " labels from " + req.RemoteEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Log("Print error: " + ex);
                ctx.SendJson(new { code = 500, msg = "Unknown error occured: " + ex.Message });
                return;
            }
            ctx.SendJson(new { code = 200 });
        }

        private void BeginGetContext() => Listener?.BeginGetContext(new AsyncCallback(ListenerCallback), Listener);

        private void ListenerCallback(IAsyncResult result)
        {
            try
            {
                if (Listener == null)
                {
                    return;
                }
                HandleRequest(Listener.EndGetContext(result));
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception ex)
            {
                Log("Unknown error:" + ex);
            }
            BeginGetContext();
        }
    }
}
