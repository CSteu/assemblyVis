using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace assemblyVis
{
    public partial class nasmVis : Form
    {
        private int eax, ebx, ecx, edx, esi, edi, esp, ebp, currentLine = 0, labelIndex = 0;
        private int start = 1, stackNum;
        private int flag, registersType = 1;
        private bool isInputGiven = false;
        string[] labels = new string[100];
        int[] labelLine = new int[100];
        List<int> stack = new List<int>();

        public nasmVis()
        {
            InitializeComponent();
            randRegisters();
        }

        #region Register Type Buttons
        private void button6_Click(object sender, EventArgs e)
        {
            registersType = 1;
            updateRegisters();
        }

        private void binaryButton_Click(object sender, EventArgs e)
        {
            registersType = 2;
            updateRegisters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registersType = 3;
            updateRegisters();
        }
        #endregion
        #region Registers

        public void randRegisters()
        {
            Random num = new Random();
            eax = num.Next(1, 2147483647);
            ebx = num.Next(1, 2147483647);
            ecx = num.Next(1, 2147483647);
            edx = num.Next(1, 2147483647);
            esi = num.Next(1, 2147483647);
            edi = num.Next(1, 2147483647);
            ebp = 0;
            esp = 0;
            updateRegisters();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int lineCount = textBox1.Lines.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= lineCount; i++)
            {
                sb.AppendLine(i.ToString());
            }
            label6.Text = sb.ToString();
        }

        private void nasmVis_Load(object sender, EventArgs e)
        {

        }

        public void updateRegisters()
        {
            if (registersType == 1) {
                registers.Text = "EAX: " + eax.ToString("X8") + Environment.NewLine + "EBX: " + ebx.ToString("X8") + Environment.NewLine +
                 "ECX: " + ecx.ToString("X8") + Environment.NewLine + "EDX: " + edx.ToString("X8") + Environment.NewLine +
                 "ESI: " + esi.ToString("X8") + Environment.NewLine + "EDI: " + edi.ToString("X8") + Environment.NewLine +
                 "EBP: " + ebp.ToString("X8") + Environment.NewLine + "ESP: " + esp.ToString("X8") + Environment.NewLine +
                 "Flag: " + flag.ToString();
            }
            else if (registersType == 2)
            {
                registers.Text = "EAX: " + Convert.ToString(eax, 2).PadLeft(32, '0') + Environment.NewLine +
                 "EBX: " + Convert.ToString(ebx, 2).PadLeft(32, '0') + Environment.NewLine +
                 "ECX: " + Convert.ToString(ecx, 2).PadLeft(32, '0') + Environment.NewLine +
                 "EDX: " + Convert.ToString(edx, 2).PadLeft(32, '0') + Environment.NewLine +
                 "ESI: " + Convert.ToString(esi, 2).PadLeft(32, '0') + Environment.NewLine +
                 "EDI: " + Convert.ToString(edi, 2).PadLeft(32, '0') + Environment.NewLine +
                 "EBP: " + Convert.ToString(ebp, 2).PadLeft(32, '0') + Environment.NewLine +
                 "ESP: " + Convert.ToString(esp, 2).PadLeft(32, '0') + Environment.NewLine +
                 "Flag: " + flag.ToString();
            }
            else if (registersType == 3)
            {
                registers.Text = "EAX: " + eax.ToString("N0") + Environment.NewLine +
                 "EBX: " + ebx.ToString("N0") + Environment.NewLine +
                 "ECX: " + ecx.ToString("N0") + Environment.NewLine +
                 "EDX: " + edx.ToString("N0") + Environment.NewLine +
                 "ESI: " + esi.ToString("N0") + Environment.NewLine +
                 "EDI: " + edi.ToString("N0") + Environment.NewLine +
                 "EBP: " + ebp.ToString("N0") + Environment.NewLine +
                 "ESP: " + esp.ToString("N0") + Environment.NewLine +
                 "Flag: " + flag;
            }
        }

        public void updateStack()
        {
            Random num = new Random();
            stackNum = num.Next(250, 1000);
            stackNum *= 4;
            stackText.Clear();
            for (int k = 0; k < 3; k++)
            {
                stackText.Text += "     +------------------+ - " + stackNum + "\n";
                stackText.Text += "     |                  |\n";
                stackNum += 4;
            }
            for (int k = stack.Count() - 1; k >= 0; k--)
            {
                stackText.Text += "     +------------------+ - " + stackNum + "\n";
                stackText.Text += "     | " + stack[k].ToString("X8") + " |\n";
                stackNum += 4;
            }
            for (int k = 0; k < 3; k++)
            {
                stackText.Text += "     +------------------+ - " + stackNum + "\n";
                stackText.Text += "     |                  |\n";
                stackNum += 4;
            }
            stackText.Text += "     +------------------+ - " + stackNum + "\n";

            stackText.ScrollToCaret();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.Text.Length;
            textBox2.ScrollToCaret();
        }

        private void readLabels()
        {
            int i = 0;
            foreach (string line in textBox1.Lines)
            {
                if (line.EndsWith(":"))
                {
                    labels[labelIndex] = line;
                    labelLine[labelIndex] = i;
                    labelIndex++;
                }
                if(start == 1 && line == "asm_main:")
                {
                    start = 0;
                    currentLine = i;
                }
                i++;
            }
        }

        #endregion
        #region Buttons
        private void button5_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            readLabels();
            string[] lines = textBox1.Text.Split('\n');
            while (currentLine < lines.Length)
            {
                runLine(lines[currentLine]);
                currentLine++;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isInputGiven = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = textBox1.Text.Split('\n');
            if (lines.Length == currentLine)
                return;
            readLabels();

            if (currentLine > 0)
            {
                int st = textBox1.GetFirstCharIndexFromLine(currentLine - 1);
                int len = lines[currentLine - 1].Length;
                textBox1.Select(st, len);
                textBox1.SelectionBackColor = Color.FromArgb(37, 37, 38);
                textBox1.SelectionColor = Color.White;

            }
            int startIndex = textBox1.GetFirstCharIndexFromLine(currentLine);
            int length = lines[currentLine].Length;
            textBox1.Select(startIndex, length);
            textBox1.SelectionBackColor = Color.FromArgb(62, 120, 138);

            runLine(textBox1.Lines[currentLine]);
            currentLine++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            currentLine = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            string[] lines = textBox1.Text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                int st = textBox1.GetFirstCharIndexFromLine(i);
                int len = lines[i].Length;
                textBox1.Select(st, len);
                textBox1.SelectionBackColor = Color.FromArgb(37, 37, 38);
                textBox1.SelectionColor = Color.White;

            }
            currentLine = 0;
            stack.Clear();
            updateRegisters();
            updateStack();
        }

        private void entButton()
        {
            textUser.BackColor = Color.FromArgb(60, 60, 60);
            while (!isInputGiven)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            textBox3.Text += textUser.Text + Environment.NewLine;
            eax = int.Parse(textUser.Text);
            isInputGiven = false;
            textUser.BackColor = Color.FromArgb(37, 37, 38);
        }
        #endregion
        private void runLine(string line)
        {
            string text = line;
            text = text.TrimStart();
            if (string.IsNullOrEmpty(text))
                return;
            string start = text.Substring(0, 4);
            string command = text.Substring(4);
            command = command.Replace("\t", "");
            command = command.Replace(" ", "");
            #region call (blank)
            if (start == "call")
            {
                if (command == "print_int")
                {
                    textBox2.Text += "print " + eax + Environment.NewLine;
                    textBox3.Text += eax;
                }
                else if (command == "print_nl")
                {
                    textBox2.Text += "print new line" + Environment.NewLine;
                    textBox3.Text += Environment.NewLine;
                }
                else if (command == "read_int")
                {
                    entButton();
                }
            }
            #endregion
            #region mov
            else if (start == "mov " || start == "mov\t")
            {
                string reg1 = "";
                int amount;
                string reg2 = "";
                command = command.Replace(" ", "");
                int i = 0;
                while (command[i] != ',')
                {
                    reg1 += command[i];
                    i++;
                }
                i++;
                if (command[i] == 'e' || command[i] == 'a')
                {
                    reg2 = command.Substring(i);
                    switch (reg1)
                    {
                        case "eax":
                            switch (reg2)
                            {
                                case "ebx":
                                    eax = ebx;
                                    break;
                                case "ecx":
                                    eax = ecx;
                                    break;
                                case "edx":
                                    eax = edx;
                                    break;
                                case "edi":
                                    eax = edi;
                                    break;
                                case "esi":
                                    eax = esi;
                                    break;
                            }
                            break;
                        case "ebx":
                            switch (reg2)
                            {
                                case "eax":
                                    ebx = eax;
                                    break;
                                case "ecx":
                                    ebx = ecx;
                                    break;
                                case "edx":
                                    ebx = edx;
                                    break;
                                case "edi":
                                    ebx = edi;
                                    break;
                                case "esi":
                                    ebx = esi;
                                    break;
                            }
                            break;
                        case "ecx":
                            switch (reg2)
                            {
                                case "ebx":
                                    ecx = ebx;
                                    break;
                                case "eax":
                                    ecx = eax;
                                    break;
                                case "edx":
                                    ecx = edx;
                                    break;
                                case "edi":
                                    ecx = edi;
                                    break;
                                case "esi":
                                    ecx = esi;
                                    break;
                            }
                            break;
                        case "edx":
                            switch (reg2)
                            {
                                case "ebx":
                                    edx = ebx;
                                    break;
                                case "ecx":
                                    edx = ecx;
                                    break;
                                case "eax":
                                    edx = eax;
                                    break;
                                case "edi":
                                    edx = edi;
                                    break;
                                case "esi":
                                    edx = esi;
                                    break;
                            }
                            break;
                        case "esi":
                            switch (reg2)
                            {
                                case "eax":
                                    esi = eax;
                                    break;
                                case "ebx":
                                    esi = ebx;
                                    break;
                                case "ecx":
                                    esi = ecx;
                                    break;
                                case "edx":
                                    esi = edx;
                                    break;
                                case "edi":
                                    esi = edi;
                                    break;
                            }
                            break;
                        case "edi":
                            switch (reg2)
                            {
                                case "eax":
                                    edi = eax;
                                    break;
                                case "ebx":
                                    edi = ebx;
                                    break;
                                case "ecx":
                                    edi = ecx;
                                    break;
                                case "edx":
                                    edi = edx;
                                    break;
                                case "esi":
                                    edi = esi;
                                    break;
                            }
                            break;
                        case "ebp":
                            ebp = esp;
                            break;
                        case "esp":
                            esp = ebp;
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Moved " + reg2 + " into " + reg1 + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    switch (reg1)
                    {
                        case "eax":
                            eax = amount;
                            break;
                        case "ebx":
                            ebx = amount;
                            break;
                        case "ecx":
                            ecx = amount;
                            break;
                        case "edx":
                            edx = amount;
                            break;
                        case "edi":
                            edi = amount;
                            break;
                        case "esi":
                            esi = amount;
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Moved " + amount + " into " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region inc and dec
            else if (start == "inc ")
            {
                switch (command)
                {
                    case "eax":
                        eax++;
                        break;
                    case "ebx":
                        ebx++; 
                        break;
                    case "ecx":
                        ecx++;
                        break;
                    case "edx":
                        edx++;
                        break;
                    case "edi":
                        edi++;
                        break;
                    case "esi":
                        esi++;
                        break;
                }

            }
            else if (start == "dec ")
            {
                switch (command)
                {
                    case "eax":
                        eax--;
                        break;
                    case "ebx":
                        ebx--;
                        break;
                    case "ecx":
                        ecx--;
                        break;
                    case "edx":
                        edx--;
                        break;
                    case "edi":
                        edi--;
                        break;
                    case "esi":
                        esi--;
                        break;
                }

            }
            #endregion
            #region add
            else if (start == "add ")
            {
                string reg1 = "";
                int amount;
                string reg2 = "";
                int i = 0;
                while (command[i] != ',')
                {
                    reg1 += command[i];
                    i++;
                }
                i++;
                if (command[i] == 'e' || command[i] == 'a')
                {
                    reg2 = command.Substring(i);

                    switch (reg1)
                    {
                        case "eax":
                            switch (reg2)
                            {
                                case "ebx":
                                    eax += ebx;
                                    break;
                                case "ecx":
                                    eax += ecx;
                                    break;
                                case "edx":
                                    eax += edx;
                                    break;
                                case "esi":
                                    eax += esi;
                                    break;
                                case "edi":
                                    eax += edi;
                                    break;
                            }
                            break;
                        case "ebx":
                            switch (reg2)
                            {
                                case "eax":
                                    ebx += eax;
                                    break;
                                case "ecx":
                                    ebx += ecx;
                                    break;
                                case "edx":
                                    ebx += edx;
                                    break;
                                case "esi":
                                    ebx += esi;
                                    break;
                                case "edi":
                                    ebx += edi;
                                    break;
                            }
                            break;
                        case "ecx":
                            switch (reg2)
                            {
                                case "ebx":
                                    ecx += ebx;
                                    break;
                                case "eax":
                                    ecx += eax;
                                    break;
                                case "edx":
                                    ecx += edx;
                                    break;
                                case "esi":
                                    ecx += esi;
                                    break;
                                case "edi":
                                    ecx += edi;
                                    break;
                            }
                            break;
                        case "edx":
                            switch (reg2)
                            {
                                case "ebx":
                                    edx += ebx;
                                    break;
                                case "ecx":
                                    edx += ecx;
                                    break;
                                case "eax":
                                    edx += eax;
                                    break;
                                case "esi":
                                    edx += esi;
                                    break;
                                case "edi":
                                    edx += edi;
                                    break;
                            }
                            break;
                        case "esi":
                            switch (reg2)
                            {
                                case "eax":
                                    esi += eax;
                                    break;
                                case "ebx":
                                    esi += ebx;
                                    break;
                                case "ecx":
                                    esi += ecx;
                                    break;
                                case "edx":
                                    esi += edx;
                                    break;
                                case "edi":
                                    esi += edi;
                                    break;
                            }
                            break;
                        case "edi":
                            switch (reg2)
                            {
                                case "eax":
                                    edi += eax;
                                    break;
                                case "ebx":
                                    edi += ebx;
                                    break;
                                case "ecx":
                                    edi += ecx;
                                    break;
                                case "edx":
                                    edi += edx;
                                    break;
                                case "esi":
                                    edi += esi;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Added " + reg2 + " to " + reg1 + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    switch (reg1)
                    {
                        case "eax":
                            eax += amount;
                            break;
                        case "ebx":
                            ebx += amount;
                            break;
                        case "ecx":
                            ecx += amount;
                            break;
                        case "edx":
                            edx += amount;
                            break;
                        case "esi":
                            esi += amount;
                            break;
                        case "edi":
                            edi += amount;
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Added " + amount + " to " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region subtract
            else if (start == "sub ")
            {
                string reg1 = "";
                int amount;
                string reg2 = "";
                int i = 0;
                while (command[i] != ',')
                {
                    reg1 += command[i];
                    i++;
                }
                i++;
                if (command[i] == 'e' || command[i] == 'a')
                {
                    reg2 = command.Substring(i);

                    switch (reg1)
                    {
                        case "eax":
                            switch (reg2)
                            {
                                case "ebx":
                                    eax -= ebx;
                                    break;
                                case "ecx":
                                    eax -= ecx;
                                    break;
                                case "edx":
                                    eax -= edx;
                                    break;
                                case "esi":
                                    eax -= esi;
                                    break;
                                case "edi":
                                    eax -= edi;
                                    break;
                            }
                            break;
                        case "ebx":
                            switch (reg2)
                            {
                                case "eax":
                                    ebx -= eax;
                                    break;
                                case "ecx":
                                    ebx -= ecx;
                                    break;
                                case "edx":
                                    ebx -= edx;
                                    break;
                                case "esi":
                                    ebx -= esi;
                                    break;
                                case "edi":
                                    ebx -= edi;
                                    break;
                            }
                            break;
                        case "ecx":
                            switch (reg2)
                            {
                                case "ebx":
                                    ecx -= ebx;
                                    break;
                                case "eax":
                                    ecx -= eax;
                                    break;
                                case "edx":
                                    ecx -= edx;
                                    break;
                                case "esi":
                                    ecx -= esi;
                                    break;
                                case "edi":
                                    ecx -= edi;
                                    break;
                            }
                            break;
                        case "edx":
                            switch (reg2)
                            {
                                case "ebx":
                                    edx -= ebx;
                                    break;
                                case "ecx":
                                    edx -= ecx;
                                    break;
                                case "eax":
                                    edx -= eax;
                                    break;
                                case "esi":
                                    edx -= esi;
                                    break;
                                case "edi":
                                    edx -= edi;
                                    break;
                            }
                            break;
                        case "esi":
                            switch (reg2)
                            {
                                case "eax":
                                    esi -= eax;
                                    break;
                                case "ebx":
                                    esi -= ebx;
                                    break;
                                case "ecx":
                                    esi -= ecx;
                                    break;
                                case "edx":
                                    esi -= edx;
                                    break;
                                case "edi":
                                    esi -= edi;
                                    break;
                            }
                            break;
                        case "edi":
                            switch (reg2)
                            {
                                case "eax":
                                    edi -= eax;
                                    break;
                                case "ebx":
                                    edi -= ebx;
                                    break;
                                case "ecx":
                                    edi -= ecx;
                                    break;
                                case "edx":
                                    edi -= edx;
                                    break;
                                case "esi":
                                    edi -= esi;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Subtracted " + reg2 + " from " + reg1 + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    switch (reg1)
                    {
                        case "eax":
                            eax -= amount;
                            break;
                        case "ebx":
                            ebx -= amount;
                            break;
                        case "ecx":
                            ecx -= amount;
                            break;
                        case "edx":
                            edx -= amount;
                            break;
                        case "esi":
                            esi -= amount;
                            break;
                        case "edi":
                            edi -= amount;
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Subtracted " + amount + " from " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region multiplication
            else if (start == "mul ")
            {
                string reg1 = "";
                int amount;
                long result;
                int i = 0;
                reg1 = command;
                if (command[i] == 'e' || command[i] == 'a')
                {

                    switch (reg1)
                    {
                        case "eax":
                            result = (long)eax * eax;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= eax;
                            }
                            break;
                        case "ebx":
                            result = (long)eax * ebx;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= ebx;
                            }
                            break;
                        case "ecx":
                            result = (long)eax * ecx;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= ecx;
                            }
                            break;
                        case "edx":
                            result = (long)eax * edx;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= edx;
                            }
                            break;
                        case "esi":
                            result = (long)eax * esi;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= esi;
                            }
                            break;
                        case "edi":
                            result = (long)eax * edi;
                            edx = 0;
                            if (result > int.MaxValue)
                            {
                                eax = (int)result;
                                edx = (int)(result >> 32);
                            }
                            else
                            {
                                eax *= edi;
                            }
                            break;
                    }
                    textBox2.Text += "Multiplied " + reg1 + " with eax" + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    eax *= amount;
                    textBox2.Text += "Multiplied " + amount + " with " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region division
            else if (start == "div ")
            {
                string reg1 = "";
                int amount;
                int i = 0;
                reg1 = command;
                if (command[i] == 'e' || command[i] == 'a')
                {

                    switch (reg1)
                    {
                        case "eax":
                            eax = 1;
                            edx = 0;
                            break;
                        case "ebx":
                            edx = eax % ebx;
                            eax /= ebx;
                            break;
                        case "ecx":
                            edx = eax % ecx;
                            eax /= ecx;
                            break;
                        case "edx":
                            edx = eax % edx;
                            eax /= edx;
                            break;
                        case "esi":
                            edx = eax % esi;
                            eax /= esi;
                            break;
                        case "edi":
                            edx = eax % edi;
                            eax /= edi;
                            break;
                    }
                    textBox2.Text += "Divivded " + reg1 + " from eax" + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    eax /= amount;
                    textBox2.Text += "Divided " + amount + " from " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region loop
            else if (start == "loop")
            {
                int i = 0;
                if (ecx > 1)
                {
                    for (i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i] - 1;
                            break;
                        }
                    }
                    textBox2.Text += "loop back to " + labels[i] + Environment.NewLine;
                }
                ecx--;
            }
            #endregion
            #region jump
            else if (start == "jmp ")
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    if (command + ':' == labels[i])
                    {
                        currentLine = labelLine[i] - 1;
                        int st = textBox1.GetFirstCharIndexFromLine(currentLine);
                        int len = textBox1.Lines[currentLine].Length;
                        textBox1.Select(st, len);
                        textBox1.SelectionBackColor = Color.FromArgb(37, 37, 38);
                        textBox1.SelectionColor = Color.White;
                        break;
                    }
                }
                textBox2.Text += "jump to " + command + Environment.NewLine;
            }
            #endregion
            #region cmp
            else if (start == "cmp ")
            {
                string reg1 = "";
                int amount;
                string reg2 = "";
                int i = 0;
                while (command[i] != ',')
                {
                    reg1 += command[i];
                    i++;
                }
                i++;
                if (command[i] == 'e' || command[i] == 'a')
                {
                    reg2 = command.Substring(i);
                    switch (reg1)
                    {
                        case "eax":
                            switch (reg2)
                            {
                                case "ebx":
                                    if (ebx > eax) flag = -1;
                                    else if (ebx < eax) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ecx":
                                    if (ecx > eax) flag = -1;
                                    else if (ecx < eax) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edx":
                                    if (edx > eax) flag = -1;
                                    else if (edx < eax) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edi":
                                    if (edi > eax) flag = -1;
                                    else if (edi < eax) flag = 1;
                                    else flag = 0;
                                    break;
                                case "esi":
                                    if (esi > eax) flag = -1;
                                    else if (esi < eax) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        case "ebx":
                            switch (reg2)
                            {
                                case "eax":
                                    if (eax > ebx) flag = -1;
                                    else if (eax < ebx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ecx":
                                    if (ecx > ebx) flag = -1;
                                    else if (ecx < ebx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edx":
                                    if (ecx > ebx) flag = -1;
                                    else if (ecx < ebx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edi":
                                    if (edi > ebx) flag = -1;
                                    else if (edi < ebx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "esi":
                                    if (esi > ebx) flag = -1;
                                    else if (esi < ebx) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        case "ecx":
                            switch (reg2)
                            {
                                case "ebx":
                                    if (ebx > ecx) flag = -1;
                                    else if (ebx < ecx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "eax":
                                    if (eax > ecx) flag = -1;
                                    else if (eax < ecx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edx":
                                    if (edx > ecx) flag = -1;
                                    else if (edx < ecx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edi":
                                    if (edi > ecx) flag = -1;
                                    else if (edi < ecx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "esi":
                                    if (esi > ecx) flag = -1;
                                    else if (esi < ecx) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        case "edx":
                            switch (reg2)
                            {
                                case "ebx":
                                    if (ebx > edx) flag = -1;
                                    else if (ebx < edx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ecx":
                                    if (ecx > edx) flag = -1;
                                    else if (ecx < edx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "eax":
                                    if (eax > edx) flag = -1;
                                    else if (eax < edx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edi":
                                    if (edi > edx) flag = -1;
                                    else if (edi < edx) flag = 1;
                                    else flag = 0;
                                    break;
                                case "esi":
                                    if (esi > edx) flag = -1;
                                    else if (esi < edx) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        case "esi":
                            switch (reg2)
                            {
                                case "eax":
                                    if (eax > esi) flag = -1;
                                    else if (eax < esi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ebx":
                                    if (ebx > esi) flag = -1;
                                    else if (ebx < esi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ecx":
                                    if (ecx > esi) flag = -1;
                                    else if (ecx < esi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edx":
                                    if (edx > esi) flag = -1;
                                    else if (edx < esi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edi":
                                    if (edi > esi) flag = -1;
                                    else if (edi < esi) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        case "edi":
                            switch (reg2)
                            {
                                case "eax":
                                    if (eax > edi) flag = -1;
                                    else if (eax < edi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ebx":
                                    if (ebx > edi) flag = -1;
                                    else if (ebx < edi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "ecx":
                                    if (ecx > edi) flag = -1;
                                    else if (ecx < edi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "edx":
                                    if (edx > edi) flag = -1;
                                    else if (edx < edi) flag = 1;
                                    else flag = 0;
                                    break;
                                case "esi":
                                    if (esi > edi) flag = -1;
                                    else if (esi < edi) flag = 1;
                                    else flag = 0;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Compared " + reg2 + " to " + reg1 + Environment.NewLine;
                }
                else
                {
                    string num = command.Substring(i);
                    amount = int.Parse(num);
                    switch (reg1)
                    {
                        case "eax":
                            if (eax > amount) flag = -1;
                            else if (eax < amount) flag = 1;
                            else flag = 0;
                            break;
                        case "ebx":
                            if (ebx > amount) flag = -1;
                            else if (ebx < amount) flag = 1;
                            else flag = 0;
                            break;
                        case "ecx":
                            if (ecx > amount) flag = -1;
                            else if (ecx < amount) flag = 1;
                            else flag = 0;
                            break;
                        case "edx":
                            if (edx > amount) flag = -1;
                            else if (edx < amount) flag = 1;
                            else flag = 0;
                            break;
                        case "edi":
                            if (edi > amount) flag = -1;
                            else if (edi < amount) flag = 1;
                            else flag = 0;
                            break;
                        case "esi":
                            if (esi > amount) flag = -1;
                            else if (esi < amount) flag = 1;
                            else flag = 0;
                            break;
                        default:
                            break;
                    }
                    textBox2.Text += "Compared " + amount + " to " + reg1 + Environment.NewLine;
                }
            }
            #endregion
            #region jmp comparisons
            else if (start == "jle ")
            {
                if (flag == -1 || flag == 0)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            else if (start == "jge ")
            {
                if (flag == 1 || flag == 0)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            else if (start.Substring(0, 3) == "jg ")
            {
                if (flag == 1)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            else if (start.Substring(0, 3) == "jl ")
            {
                if (flag == -1)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            else if (start.Substring(0, 3) == "je ")
            {
                if (flag == 0)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            else if (start == "jne ")
            {
                if (flag != 0)
                {
                    for (int i = 0; i < labels.Length; i++)
                    {
                        if (command + ':' == labels[i])
                        {
                            currentLine = labelLine[i];
                            break;
                        }
                    }

                    textBox2.Text += "jump to " + command + ":" + Environment.NewLine;
                }
            }
            #endregion
            #region push and pop
            else if (start == "push")
            {
                if (command == "eax")
                {
                    stack.Add(eax);
                }
                else if (command == "ebx")
                {
                    stack.Add(ebx);
                }
                else if (command == "ecx")
                {
                    stack.Add(ecx);
                }
                else if (command == "edx")
                {
                    stack.Add(edx);
                }
                else if (command == "esi")
                {
                    stack.Add(esi);
                }
                else if (command == "edi")
                {
                    stack.Add(ebx);
                }
                else if(command == "ebp")
                {
                    ebp = stackNum;
                    stack.Add(ebp);
                }
                textBox2.Text += "pushed " + command + " onto stack" + Environment.NewLine;
            }
            else if (start == "pop ")
            {
                if (command == "eax")
                {
                    eax = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (command == "ebx")
                {
                    ebx = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (command == "ecx")
                {
                    ecx = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (command == "edx")
                {
                    edx = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (command == "esi")
                {
                    esi = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if (command == "edi")
                {
                    edi = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                else if(command == "ebp")
                {
                    ebp = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                }
                textBox2.Text += "popped " + command + " off of stack" + Environment.NewLine;
            }

            #endregion
            #region label
            else
            {
                int l = text.Length;
                if (text[l - 1] == ':')
                {
                    labels[labelIndex] = text;
                    labelLine[labelIndex] = currentLine;
                    textBox2.Text += "Label: '" + text + "'" + Environment.NewLine;
                }
                if (start == "ret ")
                    return;
            }
            #endregion
            updateRegisters();
            updateStack();
        }
    }
}


