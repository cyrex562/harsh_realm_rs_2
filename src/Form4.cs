// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Form4
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class Form4 : Form
  {
    private IContainer components;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("ListBox1")]
    private ListBox _ListBox1;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Button2")]
    private Button _Button2;
    public int type;
    public int nr;
    public int nr2;
    public DataClass Data;
    public GameClass Game;
    private Form1 formref;

    public Form4(Form tformref)
    {
      this.Load += new EventHandler(this.Form4_Load);
      this.formref = (Form1) tformref;
      this.formref.Enabled = false;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label Label1
    {
      get => this._Label1;
      [MethodImpl(MethodImplOptions.Synchronized)] set => this._Label1 = value;
    }

    internal virtual ListBox ListBox1
    {
      get => this._ListBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set => this._ListBox1 = value;
    }

    internal virtual Button Button1
    {
      get => this._Button1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        if (this._Button1 != null)
          this._Button1.Click -= eventHandler;
        this._Button1 = value;
        if (this._Button1 == null)
          return;
        this._Button1.Click += eventHandler;
      }
    }

    internal virtual Button Button2
    {
      get => this._Button2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        if (this._Button2 != null)
          this._Button2.Click -= eventHandler;
        this._Button2 = value;
        if (this._Button2 == null)
          return;
        this._Button2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form4));
      this.Label1 = new Label();
      this.ListBox1 = new ListBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label1_1 = this.Label1;
      Point point1 = new Point(68, 30);
      Point point2 = point1;
      label1_1.Location = point2;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      Size size1 = new Size(162, 23);
      Size size2 = size1;
      label1_2.Size = size2;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Mods";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.ListBox1.ItemHeight = 16;
      ListBox listBox1_1 = this.ListBox1;
      point1 = new Point(50, 57);
      Point point3 = point1;
      listBox1_1.Location = point3;
      this.ListBox1.Name = "ListBox1";
      ListBox listBox1_2 = this.ListBox1;
      size1 = new Size(206, 196);
      Size size3 = size1;
      listBox1_2.Size = size3;
      this.ListBox1.TabIndex = 1;
      Button button1_1 = this.Button1;
      point1 = new Point(50, 278);
      Point point4 = point1;
      button1_1.Location = point4;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(206, 47);
      Size size4 = size1;
      button1_2.Size = size4;
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Start as Mod";
      Button button2_1 = this.Button2;
      point1 = new Point(346, 278);
      Point point5 = point1;
      button2_1.Location = point5;
      this.Button2.Name = "Button2";
      Button button2_2 = this.Button2;
      size1 = new Size(278, 47);
      Size size5 = size1;
      button2_2.Size = size5;
      this.Button2.TabIndex = 3;
      this.Button2.Text = "Start Normally";
      size1 = new Size(6, 15);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(658, 359);
      this.ClientSize = size1;
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.ListBox1);
      this.Controls.Add((Control) this.Label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form4);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Start Game As...";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    private void Form4_Load(object sender, EventArgs e)
    {
    }

    public void Initialize(GameClass tGame)
    {
      this.BringToFront();
      this.Game = tGame;
      foreach (FileInfo file in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "mods/").GetFiles("*.txt"))
      {
        int ID;
        ++ID;
        StreamReader streamReader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "mods/" + file.Name);
        string Name = streamReader.ReadLine();
        streamReader.Close();
        this.ListBox1.Items.Add((object) new ListItem(ID, Name, file.Name));
      }
      this.Button1.Text = "OK";
      this.Show();
      this.Focus();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.ListBox1.SelectedIndex >= 0)
        DrawMod.ModFile = "mods/" + ((ListItem) this.ListBox1.SelectedItem).File;
      this.Close();
      this.formref.Enabled = true;
      this.formref.Show();
      this.formref.Focus();
      this.formref.FinishUp();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.Close();
      DrawMod.ModFile = "defaultmod.txt";
      this.formref.Enabled = true;
      this.formref.Show();
      this.formref.Focus();
      this.formref.FinishUp();
    }
  }
}
