using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityMaker
{
    public partial class Create : Form
    {

        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        CGenerator CG;
        bool connected = false;
        public Create()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    var result = CG.Generate(textBox1.Text);
                    if(result.Item1)
                        txtCode.Text = result.Item2;
                    else
                        MessageBox.Show(result.Item2, "Error", MessageBoxButtons.OK);
                }
                    
                else
                {
                    MessageBox.Show("Please enter table name", "No Table", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Database Connection not established", "Not Connected", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CG = new CGenerator(temptxt.Text);
            try
            {
                DBConnectionForm dBConnectionForm = new DBConnectionForm();
                var dResult =dBConnectionForm.ShowDialog();
                if (dResult == DialogResult.OK)
                {
                    var result = CG.Initilize($"database={dBConnectionForm.dbName};user id={dBConnectionForm.dbUsername};pwd={dBConnectionForm.dbPassword};server={dBConnectionForm.dbserver};port={dBConnectionForm.dbPort};Persist Security Info=False;Integrated Security=FALSE;Max Pool Size=1000;Pooling=true;allow user variables = true;CacheServerProperties=true;");
                    if (!result.Item1)
                    {
                        if (MessageBox.Show(result.Item2, "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                            dBConnectionForm.ShowDialog();

                    }
                    else
                    {
                        connected = true;
                        lblStatus.Text = "Connected!";
                        lblStatus.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }

        private void Create_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Not Connected!";
            lblStatus.ForeColor = Color.Red;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                saveFileDialog1.Filter = "C# Class|*.cs";
                saveFileDialog1.Title = "Save as C# Class";
                saveFileDialog1.FileName = textBox1.Text;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                    File.WriteAllText(saveFileDialog1.FileName, txtCode.Text);

                }
            }
        }

        private void txtCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            CSharpSyntaxHighlight(e);
        }
        private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        {
            txtCode.LeftBracket = '(';
            txtCode.RightBracket = ')';
            txtCode.LeftBracket2 = '\x0';
            txtCode.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                 button1_Click(sender,e);

        }
    }
}
