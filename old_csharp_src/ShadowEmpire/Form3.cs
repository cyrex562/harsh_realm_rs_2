﻿// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Form3
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class Form3 : Form
  {
    private Form1 formref;
    private WindowClass WindowRef;
    private IContainer components;
    [AccessedThroughProperty("Label1")]
    private Label _Label1;
    [AccessedThroughProperty("ListBox1")]
    private ListBox _ListBox1;
    [AccessedThroughProperty("Button1")]
    private Button _Button1;
    [AccessedThroughProperty("Button3")]
    private Button _Button3;
    [AccessedThroughProperty("Button2")]
    private Button _Button2;
    public int type;
    public int nr;
    public int nr2;
    public int nr3;
    public DataClass Data;
    public GameClass Game;

    public Form3(Form tformref)
    {
      this.Load += new EventHandler(this.Form3_Load);
      this.formref = (Form1) tformref;
      this.formref.Enabled = false;
      this.InitializeComponent();
    }

    public Form3(Form tformref, WindowClass tWindowRef)
    {
      this.Load += new EventHandler(this.Form3_Load);
      this.WindowRef = tWindowRef;
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

    internal virtual Button Button3
    {
      get => this._Button3;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        if (this._Button3 != null)
          this._Button3.Click -= eventHandler;
        this._Button3 = value;
        if (this._Button3 == null)
          return;
        this._Button3.Click += eventHandler;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form3));
      this.Label1 = new Label();
      this.ListBox1 = new ListBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.Button3 = new Button();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      Label label1_1 = this.Label1;
      Point point1 = new Point(58, 9);
      Point point2 = point1;
      label1_1.Location = point2;
      this.Label1.Name = "Label1";
      Label label1_2 = this.Label1;
      Size size1 = new Size(537, 28);
      Size size2 = size1;
      label1_2.Size = size2;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Label1";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.ListBox1.ItemHeight = 16;
      ListBox listBox1_1 = this.ListBox1;
      point1 = new Point(86, 65);
      Point point3 = point1;
      listBox1_1.Location = point3;
      this.ListBox1.Name = "ListBox1";
      ListBox listBox1_2 = this.ListBox1;
      size1 = new Size(461, 340);
      Size size3 = size1;
      listBox1_2.Size = size3;
      this.ListBox1.TabIndex = 1;
      Button button1_1 = this.Button1;
      point1 = new Point(106, 489);
      Point point4 = point1;
      button1_1.Location = point4;
      this.Button1.Name = "Button1";
      Button button1_2 = this.Button1;
      size1 = new Size(153, 46);
      Size size4 = size1;
      button1_2.Size = size4;
      this.Button1.TabIndex = 2;
      this.Button1.Text = "OK";
      Button button2_1 = this.Button2;
      point1 = new Point(384, 489);
      Point point5 = point1;
      button2_1.Location = point5;
      this.Button2.Name = "Button2";
      Button button2_2 = this.Button2;
      size1 = new Size(144, 46);
      Size size5 = size1;
      button2_2.Size = size5;
      this.Button2.TabIndex = 3;
      this.Button2.Text = "Cancel";
      Button button3_1 = this.Button3;
      point1 = new Point(575, 352);
      Point point6 = point1;
      button3_1.Location = point6;
      this.Button3.Name = "Button3";
      Button button3_2 = this.Button3;
      size1 = new Size(117, 51);
      Size size6 = size1;
      button3_2.Size = size6;
      this.Button3.TabIndex = 4;
      this.Button3.Text = "Sort";
      this.Button3.UseVisualStyleBackColor = true;
      size1 = new Size(6, 15);
      this.AutoScaleBaseSize = size1;
      size1 = new Size(720, 559);
      this.ClientSize = size1;
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button3);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.ListBox1);
      this.Controls.Add((Control) this.Label1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (Form3);
      this.Text = "Select";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

    private void Form3_Load(object sender, EventArgs e)
    {
    }

    public void Initialize(
      DataClass tData,
      int ttype,
      int tnr,
      int tnr2 = -1,
      GameClass tGame = null,
      int tnr3 = -1)
    {
      this.BringToFront();
      this.type = ttype;
      this.nr = tnr;
      this.nr2 = tnr2;
      this.nr3 = tnr3;
      this.Data = tData;
      this.Game = tGame;
      this.Button2.Visible = true;
      if (this.type == 130)
        this.Button2.Visible = false;
      int num1;
      if (this.type == 1)
      {
        int num2 = -1;
        int index = 100;
        do
        {
          ++num2;
          string Name = Strings.Trim(Conversion.Str((object) num2)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(num2, Name));
          ++index;
        }
        while (index <= 199);
        if (this.nr2 > -1)
          this.ListBox1.SelectedIndex = this.nr2;
      }
      else if (this.type == 2)
      {
        int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
        for (int index = 0; index <= landscapeTypeCounter; ++index)
        {
          if (!this.Data.LandscapeTypeObj[this.nr].CheckOverride(index))
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
      }
      else if (this.type == 3)
      {
        int peopleCounter = this.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 4)
      {
        int index = 0;
        do
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
          ++index;
        }
        while (index <= 99);
      }
      else if (this.type == 5)
      {
        int num3 = -1;
        int index = 400;
        do
        {
          ++num3;
          string Name = Strings.Trim(Conversion.Str((object) num3)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(num3, Name));
          ++index;
        }
        while (index <= 499);
      }
      else if (this.type == 6)
      {
        int sfTypeCounter = this.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 7)
      {
        int peopleCounter = this.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 8)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
        int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
        for (int index = 0; index <= landscapeTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 9)
      {
        int basicSpriteCounter = this.Data.LandscapeTypeObj[this.Data.LocTypeObj[this.nr].OverdrawLTNr].BasicSpriteCounter;
        for (int index = 0; index <= basicSpriteCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[this.Data.LocTypeObj[this.nr].OverdrawLTNr].BasicSpriteFileName[index];
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 10)
      {
        this.ListBox1.Items.Add((object) new ListItem(-2, "***No Morph***"));
        this.ListBox1.Items.Add((object) new ListItem(-1, "***No Destruct***"));
        int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
        for (int index = 0; index <= landscapeTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 11)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
        int basicSpriteCounter = this.Data.LandscapeTypeObj[this.Data.LocTypeObj[this.nr].OnDestructLT].BasicSpriteCounter;
        for (int index = 0; index <= basicSpriteCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[this.Data.LocTypeObj[this.nr].OnDestructLT].BasicSpriteFileName[index];
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 12)
      {
        int num4 = -1;
        int index = 500;
        do
        {
          ++num4;
          string Name = Strings.Trim(Conversion.Str((object) num4)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(num4, Name));
          ++index;
        }
        while (index <= 599);
      }
      else if (this.type == 13)
      {
        int num5 = -1;
        int index = 200;
        do
        {
          ++num5;
          string Name = Strings.Trim(Conversion.Str((object) num5)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(num5, Name));
          ++index;
        }
        while (index <= 299);
      }
      else if (this.type == 14 | this.type == 15)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
        int regimeCounter = this.Data.RegimeCounter;
        for (int index = 0; index <= regimeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.RegimeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 16)
      {
        int peopleCounter = this.Data.PeopleCounter;
        for (int index = 0; index <= peopleCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 17)
      {
        int num6 = -1;
        int index = 300;
        do
        {
          ++num6;
          string Name = Strings.Trim(Conversion.Str((object) num6)) + ") " + this.Data.TempString[index];
          this.ListBox1.Items.Add((object) new ListItem(num6, Name));
          ++index;
        }
        while (index <= 399);
      }
      else if (this.type == 18)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int researchCounter = this.Data.ResearchCounter;
        for (int index = 0; index <= researchCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ResearchObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 19)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int sfTypeCounter = this.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 20)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
        int itemTypeCounter = this.Data.ItemTypeCounter;
        for (int index = 0; index <= itemTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ItemTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 21)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None needed***"));
        int sfTypeCounter = this.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 22 | this.type == 23)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int researchCounter = this.Data.ResearchCounter;
        for (int index = 0; index <= researchCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ResearchObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 24)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int researchCounter = this.Data.ResearchCounter;
        for (int index = 0; index <= researchCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ResearchObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type == 25)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int index = 0;
        do
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.GameSlotName[index];
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
          ++index;
        }
        while (index <= 499);
      }
      else if (this.type == 26)
      {
        this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
        int sfTypeCounter = this.Data.SFTypeCounter;
        for (int index = 0; index <= sfTypeCounter; ++index)
        {
          string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
          this.ListBox1.Items.Add((object) new ListItem(index, Name));
        }
      }
      else if (this.type != 27)
      {
        if (this.type == 28)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int index = 0; index <= peopleCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 29)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int regimeCounter = this.Data.RegimeCounter;
          for (int index = 0; index <= regimeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.RegimeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 30)
        {
          int num7 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int index = 200;
          do
          {
            ++num7;
            string Name = Strings.Trim(Conversion.Str((object) num7)) + ") " + this.Data.TempString[index];
            this.ListBox1.Items.Add((object) new ListItem(num7, Name));
            ++index;
          }
          while (index <= 299);
        }
        else if (this.type == 31)
        {
          int num8 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num8;
            string Name = Strings.Trim(Conversion.Str((object) num8)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num8, Name));
          }
        }
        else if (this.type == 32)
        {
          int num9 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int num10 = 0;
          do
          {
            ++num9;
            string Name = Strings.Trim(Conversion.Str((object) num9)) + ") " + this.Data.TempString[800 + num10];
            this.ListBox1.Items.Add((object) new ListItem(num9, Name));
            ++num10;
          }
          while (num10 <= 99);
        }
        else if (this.type == 33)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int unitCounter = this.Data.UnitCounter;
          for (int ID = 0; ID <= unitCounter; ++ID)
          {
            if (this.Data.UnitObj[ID].Regime == this.Data.Turn && this.Data.UnitObj[ID].PreDef == -1 && this.Data.UnitObj[ID].X > -1 && this.Data.UnitObj[ID].IsHQ)
              this.ListBox1.Items.Add((object) new ListItem(ID, this.Data.UnitObj[ID].Name + " (" + Strings.Trim(Conversion.Str((object) this.Data.UnitObj[ID].X)) + "," + Strings.Trim(Conversion.Str((object) this.Data.UnitObj[ID].Y)) + ")"));
          }
        }
        else if (this.type == 34)
        {
          int num11 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int index = 0; index <= sfTypeCounter; ++index)
          {
            ++num11;
            string Name = Strings.Trim(Conversion.Str((object) num11)) + ") " + this.Data.SFTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num11, Name));
          }
        }
        else if (this.type == 35)
        {
          int num12 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num12;
            string Name = Strings.Trim(Conversion.Str((object) num12)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num12, Name));
          }
        }
        else if (this.type == 36)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          this.ListBox1.Items.Add((object) new ListItem(1, "1) Independent Unit"));
          this.ListBox1.Items.Add((object) new ListItem(2, "2) Division"));
          this.ListBox1.Items.Add((object) new ListItem(5, "5) Corps"));
          this.ListBox1.Items.Add((object) new ListItem(6, "6) Army"));
          this.ListBox1.Items.Add((object) new ListItem(7, "7) Armygroup"));
          this.ListBox1.Items.Add((object) new ListItem(8, "8) Supreme HQ"));
        }
        else if (this.type == 37 | this.type == 46 | this.type == 47)
        {
          int Number = -1;
          int[] numArray1 = new int[this.Data.HistoricalUnitCounter + 1];
          int unitCounter = this.Data.UnitCounter;
          for (int index1 = 0; index1 <= unitCounter; ++index1)
          {
            if (this.Data.UnitObj[index1].Historical > -1)
            {
              int[] numArray2 = numArray1;
              int[] numArray3 = numArray2;
              int historical = this.Data.UnitObj[index1].Historical;
              int index2 = historical;
              int num13 = numArray2[historical] + 1;
              numArray3[index2] = num13;
            }
          }
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int ID = 0; ID <= historicalUnitCounter; ++ID)
          {
            int num14 = 0;
            if (this.type == 47 | this.type == 46)
              num14 = 1;
            else if (this.Data.UnitObj[tnr].Regime == this.Data.HistoricalUnitObj[ID].TempRegime & this.type == 37 | this.type == 47)
              num14 = 1;
            if (this.type == 46 && this.Data.HistoricalUnitObj[this.nr].TempRegime == this.Data.HistoricalUnitObj[ID].TempRegime)
              num14 = 1;
            if (num14 == 1)
            {
              int num15 = 0;
              if (this.type == 47 | this.type == 46)
                num15 = 1;
              else if (this.Data.UnitObj[tnr].IsHQ & (this.Data.HistoricalUnitObj[ID].Type >= 5 | this.Data.HistoricalUnitObj[ID].Type == -1) | !this.Data.UnitObj[tnr].IsHQ & this.Data.HistoricalUnitObj[ID].Type < 5 | this.type >= 46)
                num15 = 1;
              if (num15 == 1 && this.type == 37 | this.Data.HistoricalUnitObj[ID].Model)
              {
                ++Number;
                string str = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[ID].Name + "(";
                if (this.Data.HistoricalUnitObj[ID].Type == 1)
                  str += "Ind";
                if (this.Data.HistoricalUnitObj[ID].Type == 2)
                  str += "Div";
                if (this.Data.HistoricalUnitObj[ID].Type == 5)
                  str += "Corps";
                if (this.Data.HistoricalUnitObj[ID].Type == 6)
                  str += "Army";
                if (this.Data.HistoricalUnitObj[ID].Type == 7)
                  str += "Armygroup";
                if (this.Data.HistoricalUnitObj[ID].Type == 8)
                  str += "High Command";
                string Name = str + ")" + ", units = " + Conversion.Str((object) numArray1[ID]);
                this.ListBox1.Items.Add((object) new ListItem(ID, Name));
              }
            }
          }
        }
        else if (this.type == 38 | this.type == 139)
        {
          int num16 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int actionCardCounter = this.Data.ActionCardCounter;
          for (int index = 0; index <= actionCardCounter; ++index)
          {
            ++num16;
            string Name = Strings.Trim(Conversion.Str((object) num16)) + ") " + this.Data.ActionCardObj[index].Title;
            this.ListBox1.Items.Add((object) new ListItem(num16, Name));
          }
        }
        else if (this.type == 39)
        {
          int num17 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num17;
            string Name = Strings.Trim(Conversion.Str((object) num17)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num17, Name));
          }
        }
        else if (this.type == 40)
        {
          int num18 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int actionCardCounter = this.Data.ActionCardCounter;
          for (int index = 0; index <= actionCardCounter; ++index)
          {
            ++num18;
            string Name = Strings.Trim(Conversion.Str((object) num18)) + ") " + this.Data.ActionCardObj[index].Title;
            this.ListBox1.Items.Add((object) new ListItem(num18, Name));
          }
        }
        else if (this.type == 41)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          if (this.Game.Data.UnitObj[this.Game.EditObj.OrderUnit].TempCategory == 1)
          {
            int counter = this.Game.NewAIObj.MarkerList.Counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (this.Game.NewAIObj.MarkerList.Data1[index] == this.Game.SelectX & this.Game.NewAIObj.MarkerList.Data2[index] == this.Game.SelectY)
              {
                string Name = Strings.Trim(Conversion.Str((object) index)) + ") Normal Target = " + Conversion.Str((object) this.Game.NewAIObj.MarkerList.Data3[index]) + "," + Conversion.Str((object) this.Game.NewAIObj.MarkerList.Data4[index]);
                this.ListBox1.Items.Add((object) new ListItem(index, Name));
              }
            }
          }
          if (this.Game.Data.UnitObj[this.Game.EditObj.OrderUnit].TempCategory == 2)
          {
            int counter = this.Game.NewAIObj.ArtMarkerList.Counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (this.Game.NewAIObj.ArtMarkerList.Data1[index] == this.Game.SelectX & this.Game.NewAIObj.ArtMarkerList.Data2[index] == this.Game.SelectY)
              {
                string Name = Strings.Trim(Conversion.Str((object) index)) + ") Artillery Target = " + Conversion.Str((object) this.Game.NewAIObj.ArtMarkerList.Data3[index]) + "," + Conversion.Str((object) this.Game.NewAIObj.ArtMarkerList.Data4[index]);
                this.ListBox1.Items.Add((object) new ListItem(index, Name));
              }
            }
          }
          if (this.Game.Data.UnitObj[this.Game.EditObj.OrderUnit].TempCategory == 3)
          {
            int counter = this.Game.NewAIObj.AirMarkerList.Counter;
            for (int index = 0; index <= counter; ++index)
            {
              if (this.Game.NewAIObj.AirMarkerList.Data1[index] == this.Game.SelectX & this.Game.NewAIObj.AirMarkerList.Data2[index] == this.Game.SelectY)
              {
                string Name = Strings.Trim(Conversion.Str((object) index)) + ") Air Target = " + Conversion.Str((object) this.Game.NewAIObj.AirMarkerList.Data3[index]) + "," + Conversion.Str((object) this.Game.NewAIObj.AirMarkerList.Data4[index]);
                this.ListBox1.Items.Add((object) new ListItem(index, Name));
              }
            }
          }
          if (this.Game.Data.UnitObj[this.Game.EditObj.OrderUnit].TempCategory == 4)
          {
            if (this.Game.NewAIObj.EngineerMarkerList.Counter > -1)
            {
              int counter = this.Game.NewAIObj.EngineerMarkerList.Counter;
              for (int index = 0; index <= counter; ++index)
              {
                if (this.Game.NewAIObj.EngineerMarkerList.Data1[index] == this.Game.SelectX & this.Game.NewAIObj.EngineerMarkerList.Data2[index] == this.Game.SelectY)
                {
                  string Name = Strings.Trim(Conversion.Str((object) index)) + ") Engineer Target = " + Conversion.Str((object) this.Game.NewAIObj.EngineerMarkerList.Data3[index]) + "," + Conversion.Str((object) this.Game.NewAIObj.EngineerMarkerList.Data4[index]);
                  this.ListBox1.Items.Add((object) new ListItem(index, Name));
                }
              }
            }
            else
            {
              int counter = this.Game.NewAIObj.MarkerList.Counter;
              for (int index = 0; index <= counter; ++index)
              {
                if (this.Game.NewAIObj.MarkerList.Data1[index] == this.Game.SelectX & this.Game.NewAIObj.MarkerList.Data2[index] == this.Game.SelectY)
                {
                  string Name = Strings.Trim(Conversion.Str((object) index)) + ") Normal Target = " + Conversion.Str((object) this.Game.NewAIObj.MarkerList.Data3[index]) + "," + Conversion.Str((object) this.Game.NewAIObj.MarkerList.Data4[index]);
                  this.ListBox1.Items.Add((object) new ListItem(index, Name));
                }
              }
            }
          }
        }
        else if (this.type == 42)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None needed***"));
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int index = 0; index <= sfTypeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 43)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None needed***"));
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int index = 0; index <= sfTypeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 44)
        {
          int num19 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***Default***"));
          int index = 0;
          do
          {
            ++num19;
            string Name = Strings.Trim(Conversion.Str((object) num19)) + ") " + this.Data.TempString[index];
            this.ListBox1.Items.Add((object) new ListItem(num19, Name));
            ++index;
          }
          while (index <= 99);
        }
        else if (this.type == 45 | this.type == 136)
        {
          int num20 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None/Default***"));
          int unitCounter = this.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.Data.UnitObj[index].PreDef > -1)
            {
              ++num20;
              string Name = Strings.Trim(Conversion.Str((object) this.Data.UnitObj[index].PreDef)) + ") " + this.Data.UnitObj[index].Name;
              this.ListBox1.Items.Add((object) new ListItem(this.Data.UnitObj[index].PreDef, Name));
            }
          }
        }
        else if (this.type == 48)
        {
          int num21 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***Default***"));
          int index = 0;
          do
          {
            if (this.Data.HistoricalUnitObj[this.nr2].SubParts[index] > -1 | this.Data.HistoricalUnitObj[this.nr2].Designation[index] > -1)
            {
              ++num21;
              string Name;
              if (this.Data.HistoricalUnitObj[this.nr2].SubParts[index] > -1)
                Name = Conversion.Str((object) index) + ") " + this.Data.UnitObj[this.Data.HistoricalUnitObj[this.nr2].SubParts[index]].Name + ", " + Conversion.Str((object) this.Data.HistoricalUnitObj[this.nr2].Designation[index]);
              else
                Name = Conversion.Str((object) index) + ") " + Conversion.Str((object) this.Data.HistoricalUnitObj[this.nr2].Designation[index]);
              this.ListBox1.Items.Add((object) new ListItem(index, Name));
            }
            ++index;
          }
          while (index <= 9);
        }
        else if (this.type == 49)
        {
          int num22 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** None / No overrule ***"));
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** People of the Regime Producing ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int index = 0; index <= peopleCounter; ++index)
          {
            ++num22;
            string Name = Conversion.Str((object) index) + ") " + this.Data.PeopleObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 50)
        {
          int num23 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***Default***"));
          int index = 0;
          do
          {
            ++num23;
            string Name = Strings.Trim(Conversion.Str((object) num23)) + ") " + this.Data.TempString[index];
            this.ListBox1.Items.Add((object) new ListItem(num23, Name));
            ++index;
          }
          while (index <= 99);
        }
        else if (this.type == 51)
        {
          int num24 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***Default***"));
          int reinfCounter = this.Data.ReinfCounter;
          for (int index = 0; index <= reinfCounter; ++index)
          {
            ++num24;
            string Name = Strings.Trim(Conversion.Str((object) num24)) + ") " + this.Data.ReinfName[index];
            this.ListBox1.Items.Add((object) new ListItem(num24, Name));
          }
        }
        else if (this.type == 53 | this.type == 54)
        {
          int num25 = -1;
          int regimeCounter = this.Data.RegimeCounter;
          for (int ID = 0; ID <= regimeCounter; ++ID)
          {
            ++num25;
            if (this.Data.Turn != ID && this.Data.RegimeObj[this.Data.Turn].RegimeRel[ID] == 2)
            {
              if (this.type == 53)
              {
                string name = this.Data.RegimeObj[ID].Name;
                this.ListBox1.Items.Add((object) new ListItem(ID, name));
              }
              else if (this.type != 54 | !this.Data.RegimeObj[ID].ResField[this.nr])
              {
                string name = this.Data.RegimeObj[ID].Name;
                this.ListBox1.Items.Add((object) new ListItem(ID, name));
              }
            }
          }
        }
        else if (this.type == 52)
        {
          int num26 = -1;
          int regimeCounter = this.Data.RegimeCounter;
          for (int ID = 0; ID <= regimeCounter; ++ID)
          {
            ++num26;
            if (this.Data.Turn != ID && this.Data.RegimeObj[this.Data.Turn].RegimeRel[ID] == 2 && this.Data.UnitObj[this.nr].Regime != ID)
            {
              string name = this.Data.RegimeObj[ID].Name;
              this.ListBox1.Items.Add((object) new ListItem(ID, name));
            }
          }
          if (this.Data.RegimeObj[this.Data.UnitObj[this.nr].Regime].UberRegime == this.Data.Turn)
            this.ListBox1.Items.Add((object) new ListItem(this.Data.Turn, "*** Give to your self (as uber-regime) ***"));
        }
        else if (this.type == 55)
        {
          int num27 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
          int stringListCounter = this.Data.StringListCounter;
          for (int index = 0; index <= stringListCounter; ++index)
          {
            ++num27;
            string Name = Conversion.Str((object) this.Data.StringListObj[index].ID) + ") " + this.Data.StringListObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(this.Data.StringListObj[index].ID, Name));
          }
        }
        else if (this.type == 56)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Format ***"));
          this.ListBox1.Items.Add((object) new ListItem(0, "UDS Management Tabs Format"));
        }
        else if (this.type == 57)
        {
          int num28 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No UberRegime ***"));
          int regimeCounter = this.Data.RegimeCounter;
          for (int ID = 0; ID <= regimeCounter; ++ID)
          {
            ++num28;
            string name = this.Data.RegimeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, name));
          }
        }
        else if (this.type == 58)
        {
          int num29 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num29;
            string Name = Strings.Trim(Conversion.Str((object) num29)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num29, Name));
          }
        }
        else if (this.type == 59)
        {
          num1 = -1;
          int unitCounter = this.Data.UnitCounter;
          for (int index3 = 0; index3 <= unitCounter; ++index3)
          {
            if (tGame.Data.UnitObj[index3].Regime == tGame.Data.Turn && tGame.HandyFunctionsObj.HasUnitAirSF(index3))
            {
              if (tGame.HandyFunctionsObj.CanDoAirStrike(index3, new Coordinate()
              {
                x = tGame.EditObj.TargetX,
                y = tGame.EditObj.TargetY
              }))
              {
                string Name = this.Data.UnitObj[index3].Name;
                if (tGame.EditObj.TempUnitList.CheckIfPresent(index3))
                  Name = "SELECTED " + Name;
                if (tGame.Data.UnitObj[index3].HQ > -1)
                  Name = Name + ", " + tGame.Data.UnitObj[tGame.Data.UnitObj[index3].HQ].Name;
                int sfCount = this.Game.Data.UnitObj[index3].SFCount;
                for (int index4 = 0; index4 <= sfCount; ++index4)
                {
                  int sf = tGame.Data.UnitObj[index3].SFList[index4];
                  int type = tGame.Data.SFObj[sf].Type;
                  if (tGame.Data.SFTypeObj[type].Theater == 2)
                    Name = Name + ", " + Strings.Trim(Conversion.Str((object) (tGame.Data.SFObj[sf].Qty * tGame.Data.SFTypeObj[type].Ratio))) + "x " + tGame.Data.SFTypeObj[type].Name;
                }
                this.ListBox1.Items.Add((object) new ListItem(index3, Name));
              }
            }
          }
        }
        else if (this.type == 60)
        {
          num1 = -1;
          int unitCounter = tGame.Data.UnitCounter;
          for (int ID = 0; ID <= unitCounter; ++ID)
          {
            if (tGame.Data.UnitObj[ID].Regime == tGame.Data.Turn && tGame.Data.UnitObj[ID].IsHQ & (tGame.Data.UnitObj[ID].LandCap > 0 | tGame.Data.UnitObj[ID].AirCap > 0 | tGame.Data.UnitObj[ID].NavyCap > 0))
            {
              string Name = this.Data.UnitObj[ID].Name + ", LandCap=" + Strings.Trim(Conversion.Str((object) this.Game.Data.UnitObj[ID].LandCap)) + ", NavyCap=" + Strings.Trim(Conversion.Str((object) this.Game.Data.UnitObj[ID].NavyCap)) + ", RailCap=" + Strings.Trim(Conversion.Str((object) this.Game.Data.UnitObj[ID].AirCap));
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 61)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
          for (int index = 0; index <= landscapeTypeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 62)
        {
          int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
          for (int index = 0; index <= landscapeTypeCounter; ++index)
          {
            if (!this.Data.LandscapeTypeObj[this.nr].CheckOverride2(index))
            {
              string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.LandscapeTypeObj[index].Name;
              this.ListBox1.Items.Add((object) new ListItem(index, Name));
            }
          }
        }
        else if (this.type == 63)
        {
          int num30 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num30;
            string Name = Strings.Trim(Conversion.Str((object) num30)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num30, Name));
          }
        }
        else if (this.type == 64)
        {
          int num31 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num31;
            string Name = Strings.Trim(Conversion.Str((object) num31)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num31, Name));
          }
        }
        else if (this.type == 65)
        {
          int num32 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None***"));
          int stringListCounter = this.Data.StringListCounter;
          for (int index = 0; index <= stringListCounter; ++index)
          {
            ++num32;
            string Name = Conversion.Str((object) this.Data.StringListObj[index].ID) + ") " + this.Data.StringListObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(this.Data.StringListObj[index].ID, Name));
          }
        }
        else if (this.type == 66)
        {
          int num33 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num33;
            string Name = Strings.Trim(Conversion.Str((object) num33)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num33, Name));
          }
        }
        else if (this.type == 67)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** All ***"));
          int itemTypeCounter = this.Data.ItemTypeCounter;
          for (int index = 0; index <= itemTypeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ItemTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 68 | this.type == 69)
        {
          int num34 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** All ***"));
          int index = 400;
          do
          {
            ++num34;
            string Name = Strings.Trim(Conversion.Str((object) num34)) + ") " + this.Data.TempString[index];
            this.ListBox1.Items.Add((object) new ListItem(num34, Name));
            ++index;
          }
          while (index <= 499);
        }
        else if (this.type == 70)
        {
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int index = 0; index <= sfTypeCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.SFTypeObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 71 | this.type == 72)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int researchCounter = this.Data.ResearchCounter;
          for (int index = 0; index <= researchCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.ResearchObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 73)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int index = 0;
          do
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.RegimeSlotName[index];
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
            ++index;
          }
          while (index <= 499);
        }
        else if (this.type == 74)
        {
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          ListClass listClass = new ListClass();
          int num35 = -1;
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int tdata = 0; tdata <= sfTypeCounter; ++tdata)
          {
            if (!this.Data.SFTypeObj[tdata].DontShowInList && this.Data.SFTypeObj[tdata].Name.Length > 1)
            {
              ++num35;
              string name = this.Data.SFTypeObj[tdata].Name;
              listClass.add(name, tdata);
            }
          }
          listClass.Sort();
          int listCount = listClass.ListCount;
          for (int index = 0; index <= listCount; ++index)
            this.ListBox1.Items.Add((object) new ListItem(listClass.ListData[index], listClass.ListName[index]));
        }
        else if (this.type >= 75 & this.type <= 78 | this.type == 81)
        {
          int num36 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int eventCounter = this.Data.EventCounter;
          for (int index = 0; index <= eventCounter; ++index)
          {
            ++num36;
            string Name = Strings.Trim(Conversion.Str((object) num36)) + ") " + this.Data.EventObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(num36, Name));
          }
        }
        else if (this.type == 79)
        {
          int num37 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No Alteration***"));
          int modelVariantCounter = this.Data.SFTypeObj[this.nr].ModelVariantCounter;
          for (int ID = 0; ID <= modelVariantCounter; ++ID)
          {
            if (this.Data.SFTypeObj[this.nr].TempAlterationPossible[ID])
            {
              ++num37;
              string Name = this.Data.SFTypeObj[this.nr].ModelVariantName[ID];
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 80)
        {
          int num38 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No AutoProd ***"));
          int itemTypeCounter = this.Data.ItemTypeCounter;
          for (int ID = 0; ID <= itemTypeCounter; ++ID)
          {
            ++num38;
            string name = this.Data.ItemTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, name));
          }
        }
        else if (this.type == 82)
        {
          num1 = -1;
          if (this.Game.EditObj.inSimpleEditor)
            this.ListBox1.Items.Add((object) new ListItem(-1, "***No HQ****"));
          int unitCounter = this.Data.UnitCounter;
          for (int index = 0; index <= unitCounter; ++index)
          {
            if (this.Data.UnitObj[index].PreDef == -1 & this.Data.UnitObj[index].X > -1 && this.nr > -1 && this.nr != index & this.Game.Data.UnitObj[this.nr].HQ != index & this.Game.Data.UnitObj[index].IsHQ & (this.Game.Data.UnitObj[index].Regime == this.Game.Data.Turn | this.Game.Data.UnitObj[index].Regime == this.Game.Data.UnitObj[this.nr].Regime) && this.Game.HandyFunctionsObj.CanUnitBecomeHQfor(index, this.nr))
            {
              int num39 = 0;
              if (this.Game.Data.UnitObj[this.nr].IsHQ)
                num39 = 1;
              if ((double) this.Game.Data.RuleVar[304] == 0.0 | (double) (this.Game.HandyFunctionsObj.HowmanyHQsAbove(index) + this.Game.HandyFunctionsObj.HowmanyHQsBelow(this.nr) + 1 + num39) <= (double) this.Game.Data.RuleVar[304])
              {
                string name = this.Game.Data.UnitObj[index].Name;
                this.ListBox1.Items.Add((object) new ListItem(index, name));
              }
            }
          }
        }
        else if (this.type == 83 | this.type == 137)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No ppl ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int index = 0; index <= peopleCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 84 | this.type == 100 | this.type == 138)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** None ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if (this.Data.HistoricalUnitObj[index].Model & this.Data.HistoricalUnitObj[index].SubParts[0] > -1)
            {
              if (this.type == 100)
              {
                if (this.Game.Data.HistoricalUnitObj[index].TempRegime == this.nr)
                {
                  string Name = Strings.Trim(Conversion.Str((object) index)) + ") MODEL " + this.Data.HistoricalUnitObj[index].Name;
                  this.ListBox1.Items.Add((object) new ListItem(index, Name, RealName: this.Data.HistoricalUnitObj[index].Name));
                }
              }
              else
              {
                string Name = Strings.Trim(Conversion.Str((object) index)) + ") MODEL " + this.Data.HistoricalUnitObj[index].Name;
                this.ListBox1.Items.Add((object) new ListItem(index, Name, RealName: this.Data.HistoricalUnitObj[index].Name));
              }
            }
          }
        }
        else if (this.type == 85)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** None ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if (this.Data.HistoricalUnitObj[index].DeckCardCounter > -1)
            {
              string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.HistoricalUnitObj[index].Name;
              this.ListBox1.Items.Add((object) new ListItem(index, Name, RealName: this.Data.HistoricalUnitObj[index].Name));
            }
          }
        }
        else if (this.type == 86)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** None ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if (this.Data.HistoricalUnitObj[index].HisVarCount > -1)
            {
              string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.HistoricalUnitObj[index].Name;
              this.ListBox1.Items.Add((object) new ListItem(index, Name, RealName: this.Data.HistoricalUnitObj[index].Name));
            }
          }
        }
        else if (this.type == 87 | this.type == 101)
        {
          int Number = -1;
          int[] numArray4 = new int[this.Data.HistoricalUnitCounter + 1];
          int unitCounter = this.Data.UnitCounter;
          for (int index5 = 0; index5 <= unitCounter; ++index5)
          {
            if (this.Data.UnitObj[index5].Historical > -1)
            {
              int[] numArray5 = numArray4;
              int[] numArray6 = numArray5;
              int historical = this.Data.UnitObj[index5].Historical;
              int index6 = historical;
              int num40 = numArray5[historical] + 1;
              numArray6[index6] = num40;
            }
          }
          int num41 = -1;
          if (this.Game.SelectX > -1 & this.Game.SelectY > -1)
            num41 = this.Game.Data.MapObj[0].HexObj[this.Game.SelectX, this.Game.SelectY].Regime;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int ID = 0; ID <= historicalUnitCounter; ++ID)
          {
            int num42 = 1;
            if (numArray4[ID] > 0)
              num42 = 0;
            if (num42 == 1 && !this.Data.HistoricalUnitObj[ID].Model && num41 == -1 | this.Data.HistoricalUnitObj[ID].TempRegime == num41 & !(this.type == 101 & this.Data.HistoricalUnitObj[ID].CommanderName.Length > 0))
            {
              ++Number;
              string str = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[ID].Name + "(";
              if (this.Data.HistoricalUnitObj[ID].Type == 1)
                str += "Ind";
              if (this.Data.HistoricalUnitObj[ID].Type == 2)
                str += "Multi-Unit";
              if (this.Data.HistoricalUnitObj[ID].Type == 5)
                str += "Low HQ";
              if (this.Data.HistoricalUnitObj[ID].Type == 6)
                str += "Med HQ";
              if (this.Data.HistoricalUnitObj[ID].Type == 7)
                str += "High HQ";
              if (this.Data.HistoricalUnitObj[ID].Type == 8)
                str += "High Command";
              string Name = str + ")" + ", units = " + Conversion.Str((object) numArray4[ID]);
              this.ListBox1.Items.Add((object) new ListItem(ID, Name, RealName: this.Data.HistoricalUnitObj[ID].Name));
            }
          }
        }
        else if (this.type == 88)
        {
          num1 = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No ppl ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int index = 0; index <= peopleCounter; ++index)
          {
            string Name = Strings.Trim(Conversion.Str((object) index)) + ") " + this.Data.PeopleObj[index].Name;
            this.ListBox1.Items.Add((object) new ListItem(index, Name));
          }
        }
        else if (this.type == 89)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***Default***"));
          int reinfCounter = this.Data.ReinfCounter;
          for (int ID = 0; ID <= reinfCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.ReinfName[ID];
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 90)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int libraryCounter = this.Data.LibraryCounter;
          for (int ID = 0; ID <= libraryCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LibraryObj[ID].name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 91)
        {
          this.ListBox1.Items.Add((object) new ListItem(0, "Global/General"));
          this.ListBox1.Items.Add((object) new ListItem(1, "Landscape"));
          this.ListBox1.Items.Add((object) new ListItem(2, "Road"));
          this.ListBox1.Items.Add((object) new ListItem(3, "River"));
          this.ListBox1.Items.Add((object) new ListItem(4, "Hex"));
          this.ListBox1.Items.Add((object) new ListItem(5, "SFType"));
          this.ListBox1.Items.Add((object) new ListItem(6, "LocationType"));
          this.ListBox1.Items.Add((object) new ListItem(7, "HistoricalUnit"));
          this.ListBox1.Items.Add((object) new ListItem(8, "HistoricalUnitModel"));
          this.ListBox1.Items.Add((object) new ListItem(9, "Officer"));
          this.ListBox1.Items.Add((object) new ListItem(10, "People"));
          this.ListBox1.Items.Add((object) new ListItem(11, "Regime"));
        }
        else if (this.type == 92 | this.type == 105)
        {
          this.ListBox1.Items.Add((object) new ListItem(0, "Number"));
          this.ListBox1.Items.Add((object) new ListItem(1, "Text"));
          this.ListBox1.Items.Add((object) new ListItem(2, "RoadSlot"));
          this.ListBox1.Items.Add((object) new ListItem(3, "LandscapeSlot"));
          this.ListBox1.Items.Add((object) new ListItem(4, "RiverSlot"));
          this.ListBox1.Items.Add((object) new ListItem(5, "DateString"));
          this.ListBox1.Items.Add((object) new ListItem(6, "SFTypeSlot"));
          this.ListBox1.Items.Add((object) new ListItem(7, "HistoricalUnitSlot"));
          this.ListBox1.Items.Add((object) new ListItem(8, "HistoricalUnitModelSlot"));
          this.ListBox1.Items.Add((object) new ListItem(9, "OfficerSlot"));
          this.ListBox1.Items.Add((object) new ListItem(10, "PeopleSlot"));
          this.ListBox1.Items.Add((object) new ListItem(11, "RegimeSlot"));
          this.ListBox1.Items.Add((object) new ListItem(12, "Yes/No"));
          this.ListBox1.Items.Add((object) new ListItem(13, "LocationType"));
          this.ListBox1.Items.Add((object) new ListItem(14, "SmallGfx"));
          this.ListBox1.Items.Add((object) new ListItem(15, "EventPic"));
          this.ListBox1.Items.Add((object) new ListItem(16, "ActionCardSlot"));
        }
        else if (this.type == 93)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int libraryCounter = this.Data.LibraryCounter;
          for (int ID = 0; ID <= libraryCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LibraryObj[ID].name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 94)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int libraryCounter = this.Data.LibraryCounter;
          for (int ID = 0; ID <= libraryCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LibraryObj[ID].name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 95 | this.type == 96 | this.type == 97 | this.type == 107 | this.type == 108 | this.type == 109 | this.type == 129)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int libraryCounter = this.Data.LibraryCounter;
          for (int ID = 0; ID <= libraryCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LibraryObj[ID].name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 98)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT substitute ***"));
          int regimeCounter = this.Data.RegimeCounter;
          for (int ID = 0; ID <= regimeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RegimeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 99)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT substitute ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int ID = 0; ID <= peopleCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.PeopleObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 102)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** No commander ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if (this.Game.Data.HistoricalUnitObj[index].TempRegime == this.nr & this.Game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 & !this.Game.Data.HistoricalUnitObj[index].Pool & this.Game.HandyFunctionsObj.GetUnitByHistorical(index) == -1)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[index].CommanderName;
              this.ListBox1.Items.Add((object) new ListItem(index, Name));
            }
          }
        }
        else if (this.type == 103)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** No commander ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if (this.Game.Data.HistoricalUnitObj[index].TempRegime == this.nr & this.Game.Data.HistoricalUnitObj[index].CommanderName.Length > 0 & this.Game.Data.HistoricalUnitObj[index].Pool & this.Game.HandyFunctionsObj.GetUnitByHistorical(index) == -1)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[index].CommanderName;
              this.ListBox1.Items.Add((object) new ListItem(index, Name));
            }
          }
        }
        else if (this.type == 104)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***None ***"));
          int libraryCounter = this.Data.LibraryCounter;
          for (int ID = 0; ID <= libraryCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LibraryObj[ID].name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 106 | this.type == 123)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Regime ***"));
          int regimeCounter = this.Data.RegimeCounter;
          for (int ID = 0; ID <= regimeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RegimeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 110 | this.type == 118)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No His Unit ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int index = 0; index <= historicalUnitCounter; ++index)
          {
            if ((this.type == 110 | !this.Data.HistoricalUnitObj[index].Model) & this.Data.HistoricalUnitObj[index].CommanderName.Length < 1 && this.type != 110 | this.Game.HandyFunctionsObj.GetUnitByHistorical(index) == -1)
            {
              ++Number;
              string Name;
              if (this.Data.HistoricalUnitObj[index].TempRegime > -1)
                Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[index].Name + " (" + this.Data.RegimeObj[this.Data.HistoricalUnitObj[index].TempRegime].Name + ")";
              else
                Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[index].Name;
              this.ListBox1.Items.Add((object) new ListItem(index, Name));
            }
          }
        }
        else if (this.type == 144)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No His Unit ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int ID = 0; ID <= historicalUnitCounter; ++ID)
          {
            if (!this.Data.HistoricalUnitObj[ID].Model)
            {
              ++Number;
              string Name;
              if (this.Data.HistoricalUnitObj[ID].TempRegime > -1)
                Name = this.Data.HistoricalUnitObj[ID].Name + " (" + this.Data.RegimeObj[this.Data.HistoricalUnitObj[ID].TempRegime].Name + ") [" + Strings.Trim(Conversion.Str((object) Number)) + "]";
              else
                Name = this.Data.HistoricalUnitObj[ID].Name + " [" + Strings.Trim(Conversion.Str((object) Number)) + "]";
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 111 | this.type == 119 | this.type == 135)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Model ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int ID = 0; ID <= historicalUnitCounter; ++ID)
          {
            if (this.Data.HistoricalUnitObj[ID].Model & this.Data.HistoricalUnitObj[ID].CommanderName.Length < 1)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[ID].Name;
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 112 | this.type == 121)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Officer ***"));
          int historicalUnitCounter = this.Data.HistoricalUnitCounter;
          for (int ID = 0; ID <= historicalUnitCounter; ++ID)
          {
            if (!this.Data.HistoricalUnitObj[ID].Model & this.Data.HistoricalUnitObj[ID].CommanderName.Length > 0)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.HistoricalUnitObj[ID].CommanderName;
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 113 | this.type == 120)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Landscape ***"));
          int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
          for (int ID = 0; ID <= landscapeTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LandscapeTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 114 | this.type == 122 | this.type == 132 | this.type == 134 | this.type == 138)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No People ***"));
          int peopleCounter = this.Data.PeopleCounter;
          for (int ID = 0; ID <= peopleCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.PeopleObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 115 | this.type == 124)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No River ***"));
          int riverTypeCounter = this.Data.RiverTypeCounter;
          for (int ID = 0; ID <= riverTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RiverTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 116 | this.type == 125)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Road ***"));
          int roadTypeCounter = this.Data.RoadTypeCounter;
          for (int ID = 0; ID <= roadTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RoadTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 131 | this.type == 145)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No SFtype***"));
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int ID = 0; ID <= sfTypeCounter; ++ID)
          {
            if (!this.Data.SFTypeObj[ID].DontShowInList)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.SFTypeObj[ID].Name;
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 117 | this.type == 126)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No SFtype***"));
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int ID = 0; ID <= sfTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.SFTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == (int) sbyte.MaxValue | this.type == 128)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No Loctype***"));
          int locTypeCounter = this.Data.LocTypeCounter;
          for (int ID = 0; ID <= locTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LocTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 130)
        {
          int Number = -1;
          int sfTypeCounter = this.Data.SFTypeCounter;
          for (int ID = 0; ID <= sfTypeCounter; ++ID)
          {
            if (this.Game.Data.SFTypeObj[ID].DontShowInList & Operators.CompareString(this.Game.Data.SFTypeObj[ID].Name, "Reserved SFType", false) != 0 && Strings.InStr(this.Game.Data.SFTypeObj[ID].Name.ToLower(), "unused") <= 0 && Strings.InStr(this.Game.Data.SFTypeObj[ID].Name.ToLower(), "n/a") <= 0)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.SFTypeObj[ID].Name;
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
              if (Number == 0)
                this.ListBox1.SelectedItem = RuntimeHelpers.GetObjectValue(this.ListBox1.Items[0]);
            }
          }
        }
        else if (this.type == 133)
        {
          this.ListBox1.Items.Add((object) new ListItem(1, "Individual Unit"));
          this.ListBox1.Items.Add((object) new ListItem(2, "Multi Unit"));
          this.ListBox1.Items.Add((object) new ListItem(5, "Lowest HQ"));
          this.ListBox1.Items.Add((object) new ListItem(6, "Medium HQ"));
          this.ListBox1.Items.Add((object) new ListItem(7, "High HQ"));
          this.ListBox1.Items.Add((object) new ListItem(8, "Supreme HQ"));
        }
        else if (this.type == 140 | this.type == 142)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No Small Graphic***"));
          int smallPicCounter = this.Data.SmallPicCounter;
          for (int ID = 0; ID <= smallPicCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.SmallPicName[ID];
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 141 | this.type == 143)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "***No Event Pic***"));
          int eventPicCounter = this.Data.EventPicCounter;
          for (int ID = 0; ID <= eventPicCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.EventPicName[ID];
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 146)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-1, "*** No ActionCard ***"));
          int actionCardCounter = this.Data.ActionCardCounter;
          for (int ID = 0; ID <= actionCardCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.ActionCardObj[ID].Title;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 147)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT replace ***"));
          int landscapeTypeCounter = this.Data.LandscapeTypeCounter;
          for (int ID = 0; ID <= landscapeTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LandscapeTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 148)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT replace ***"));
          int roadTypeCounter = this.Data.RoadTypeCounter;
          for (int ID = 0; ID <= roadTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RoadTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 149)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT replace ***"));
          int riverTypeCounter = this.Data.RiverTypeCounter;
          for (int ID = 0; ID <= riverTypeCounter; ++ID)
          {
            ++Number;
            string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.RiverTypeObj[ID].Name;
            this.ListBox1.Items.Add((object) new ListItem(ID, Name));
          }
        }
        else if (this.type == 150)
        {
          int num43 = -1;
          this.ListBox1.Items.Add((object) new ListItem(0, "*** Nothing ***"));
          int stringListById = this.Game.HandyFunctionsObj.GetStringListByID(this.Game.Data.StringListObj[this.nr].LookUpCol[this.nr3]);
          if (stringListById > -1)
          {
            int length = this.Data.StringListObj[stringListById].Length;
            for (int index = 0; index <= length; ++index)
            {
              ++num43;
              string Name = this.Data.StringListObj[stringListById].Data[index, this.Data.StringListObj[stringListById].LookUpLabel] + " [" + this.Data.StringListObj[stringListById].Data[index, this.Data.StringListObj[stringListById].LookUpId] + "]";
              this.ListBox1.Items.Add((object) new ListItem((int) Math.Round(Conversion.Val(this.Data.StringListObj[stringListById].Data[index, this.Data.StringListObj[stringListById].LookUpId])), Name));
            }
          }
          ArrayList arrayList = new ArrayList();
          int num44 = this.ListBox1.Items.Count - 1;
          for (int index = 0; index <= num44; ++index)
            arrayList.Add(RuntimeHelpers.GetObjectValue(this.ListBox1.Items[index]));
          SortListArray sortListArray = new SortListArray(true);
          this.ListBox1.Items.Clear();
          int num45 = arrayList.Count - 1;
          for (int index = 0; index <= num45; ++index)
            this.ListBox1.Items.Add(RuntimeHelpers.GetObjectValue(arrayList[index]));
        }
        else if (this.type == 151)
        {
          int Number = -1;
          this.ListBox1.Items.Add((object) new ListItem(-2, "*** Do NOT replace ***"));
          int locTypeCounter = this.Data.LocTypeCounter;
          for (int ID = 0; ID <= locTypeCounter; ++ID)
          {
            if (!this.Data.LocTypeObj[ID].editorBlock)
            {
              ++Number;
              string Name = Strings.Trim(Conversion.Str((object) Number)) + ") " + this.Data.LocTypeObj[ID].Name;
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
        else if (this.type == 153)
        {
          num1 = -1;
          int num46 = 1;
          do
          {
            Coordinate coordinate = this.Game.HandyFunctionsObj.HexNeighbourSameMap(this.Game.SelectX, this.Game.SelectY, 0, num46);
            if (coordinate.onmap && this.Game.Data.MapObj[0].HexObj[this.Game.SelectX, this.Game.SelectY].Bridge[num46 - 1] & this.Game.Data.MapObj[0].HexObj[this.Game.SelectX, this.Game.SelectY].RiverType[num46 - 1] > -1)
            {
              string Name;
              if (num46 == 1)
                Name = "North";
              if (num46 == 2)
                Name = "North-East";
              if (num46 == 3)
                Name = "South-East";
              if (num46 == 4)
                Name = "South";
              if (num46 == 5)
                Name = "South-West";
              if (num46 == 6)
                Name = "North-West";
              Name = Name + " (" + coordinate.x.ToString() + "," + coordinate.y.ToString() + ")";
              this.ListBox1.Items.Add((object) new ListItem(num46, Name));
            }
            ++num46;
          }
          while (num46 <= 6);
        }
        else if (this.type == 154)
        {
          num1 = -1;
          CoordList coordList = this.Game.HandyFunctionsObj.InfraHexHighlight_getCoordList(this.Game.SelectX, this.Game.SelectY, 0, this.Game.EditObj.UnitSelected);
          int counter = coordList.counter;
          for (int index = 0; index <= counter; ++index)
          {
            Coordinate coordinate = coordList.coord[index];
            if (coordinate.onmap)
            {
              int ID = this.Game.HandyFunctionsObj.HexFacing(this.Game.SelectX, this.Game.SelectY, 0, coordinate.x, coordinate.y, 0);
              string Name;
              if (ID == 1)
                Name = "North";
              if (ID == 2)
                Name = "North-East";
              if (ID == 3)
                Name = "South-East";
              if (ID == 4)
                Name = "South";
              if (ID == 5)
                Name = "South-West";
              if (ID == 6)
                Name = "North-West";
              Name = Name + " (" + coordinate.x.ToString() + "," + coordinate.y.ToString() + ")";
              this.ListBox1.Items.Add((object) new ListItem(ID, Name));
            }
          }
        }
      }
      this.Button1.Text = "OK";
      if (this.type == 1)
        this.Label1.Text = "Select a groundtype for landscapetype " + this.Data.LandscapeTypeObj[this.nr].Name;
      if (this.type == 2)
        this.Label1.Text = "Select a new landscape to be overriden by " + this.Data.LandscapeTypeObj[this.nr].Name;
      if (this.type == 3)
        this.Label1.Text = "Select a new people for " + this.Data.RegimeObj[this.nr].Name;
      if (this.type == 4)
        this.Label1.Text = "Select a movetype for " + this.Data.SFTypeObj[this.nr].Name;
      if (this.type == 5)
        this.Label1.Text = "Select a unitgroup for " + this.Data.SFTypeObj[this.nr].Name;
      if (this.type == 6)
        this.Label1.Text = "Select a SFType for subformation ";
      if (this.type == 7)
        this.Label1.Text = "Select a people for subformation ";
      if (this.type == 8)
        this.Label1.Text = "Select a Landscape Type for " + this.Data.LocTypeObj[this.nr].Name;
      if (this.type == 9)
        this.Label1.Text = "Select a Sprite for " + this.Data.LocTypeObj[this.nr].Name;
      if (this.type == 10)
        this.Label1.Text = "Select a Landscape Type for destructing " + this.Data.LocTypeObj[this.nr].Name;
      if (this.type == 11)
        this.Label1.Text = "Select a Sprite for destructing " + this.Data.LocTypeObj[this.nr].Name;
      if (this.type == 12)
        this.Label1.Text = "Select loctype group for " + this.Data.LocTypeObj[this.nr].Name;
      if (this.type == 13)
        this.Label1.Text = "Select peoplegroup for " + this.Data.PeopleObj[this.nr].Name;
      if (this.type == 14)
        this.Label1.Text = "Select regime for regimecol of " + this.Data.PeopleObj[this.nr].Name;
      if (this.type == 15)
        this.Label1.Text = "Select regime";
      if (this.type == 16)
        this.Label1.Text = "Select people for location " + this.Data.LocObj[this.nr].Name;
      if (this.type == 17)
        this.Label1.Text = "Select itemtypegroup for itemtype " + this.Data.ItemTypeObj[this.nr].Name;
      if (this.type == 18)
        this.Label1.Text = "Select researchfield needed for itemtype " + this.Data.ItemTypeObj[this.nr].Name;
      if (this.type == 19)
        this.Label1.Text = "Select sftype for itemtype " + this.Data.ItemTypeObj[this.nr].Name;
      if (this.type == 20)
        this.Label1.Text = "Select itemtype blocked by itemtype " + this.Data.ItemTypeObj[this.nr].Name;
      if (this.type == 21)
        this.Label1.Text = "Select sftype picture for researchfield " + this.Data.ResearchObj[this.nr].Name;
      if (this.type == 22 | this.type == 23)
        this.Label1.Text = "Select prereq research for " + this.Data.ResearchObj[this.nr].Name;
      if (this.type == 24)
        this.Label1.Text = "Select which field is blocked for " + this.Data.ResearchObj[this.nr].Name;
      if (this.type == 25)
        this.Label1.Text = "Select gameslot for variant # " + Conversion.Str((object) this.nr);
      if (this.type == 26)
        this.Label1.Text = "Select upgrade option for " + this.Data.SFTypeObj[this.nr].Name;
      if (this.type == 27)
        this.Label1.Text = "Select historical unit for unit# " + Conversion.Str((object) this.nr);
      if (this.type == 31)
        this.Label1.Text = "Select eventnr to be fired by playing actioncard: " + this.Data.ActionCardObj[this.nr].Title;
      if (this.type == 32)
        this.Label1.Text = "Select eventcategory: ";
      if (this.type == 33)
        this.Label1.Text = "Select new HQ for " + this.Data.LocObj[this.nr].Name + ":";
      if (this.type == 34)
        this.Label1.Text = "Select SFType: ";
      if (this.type == 35)
        this.Label1.Text = "Select eventnr for pre execute event nr: " + this.Data.ActionCardObj[this.nr].Title;
      if (this.type == 36)
        this.Label1.Text = "Select Type of Historical Unit: ";
      if (this.type == 37)
        this.Label1.Text = "Select Historical Unit: ";
      if (this.type == 38)
        this.Label1.Text = "Set CampaignRoom Auto ActionCard: ";
      if (this.type == 39)
        this.Label1.Text = "Set auto-event for historical unit";
      if (this.type == 40)
        this.Label1.Text = "Set action card for historical unit";
      if (this.type == 41)
        this.Label1.Text = "Set marker for unit";
      if (this.type == 42)
        this.Label1.Text = "Select SFType to View";
      if (this.type == 43)
        this.Label1.Text = "Select SFType to Copy";
      if (this.type == 44)
        this.Label1.Text = "Select Override MoveType for Subformation";
      if (this.type == 45)
        this.Label1.Text = "Select Predef unit";
      if (this.type == 46)
        this.Label1.Text = "Select historical unit to use as a MODEL";
      if (this.type == 47)
        this.Label1.Text = "Select historical unit to use as a MODEL";
      if (this.type == 48)
        this.Label1.Text = "Choose subpart for unit";
      if (this.type == 49)
        this.Label1.Text = "Choose peoplemod for itemtype";
      if (this.type == 50)
        this.Label1.Text = "Choose movetype for itemtype";
      if (this.type == 51)
        this.Label1.Text = "Choose reinforcementtype for sftype";
      if (this.type == 52)
        this.Label1.Text = "Choose ally to give unit too";
      if (this.type == 53)
        this.Label1.Text = "Choose ally to give selected hex too";
      if (this.type == 54)
        this.Label1.Text = "Choose ally to give selected research too";
      if (this.type == 55)
        this.Label1.Text = "Choose a stringlist for the officerpool algorithm";
      if (this.type == 56)
        this.Label1.Text = "Choose a format for this stringlist (or no format)";
      if (this.type == 57)
        this.Label1.Text = "Choose a UberRegime";
      if (this.type == 58)
        this.Label1.Text = "Select an event to immediatly execute upon change of this variant.";
      if (this.type == 59)
        this.Label1.Text = "Select an air unit to join in attack";
      if (this.type == 60)
        this.Label1.Text = "Select a HQ to provide CAP pts for strategic transfer";
      if (this.type == 61)
        this.Label1.Text = "Select a Landscapetype who's special 6/64 sprites to use for exterior transitions";
      if (this.type == 62)
        this.Label1.Text = "Select a new landscape to be overriden by " + this.Data.LandscapeTypeObj[this.nr].Name;
      if (this.type == 63)
        this.Label1.Text = "Pick Improvement Event for researchfield " + this.Data.ResearchObj[this.nr2].Name;
      if (this.type == 64)
        this.Label1.Text = "Pick event for new/upgrade ";
      if (this.type == 65)
        this.Label1.Text = "Pick stringlist for model names ";
      if (this.type == 66)
        this.Label1.Text = "Pick event for InitialEvent ";
      if (this.type == 67)
        this.Label1.Text = "Pick itemtype for model";
      if (this.type == 68)
        this.Label1.Text = "Pick SfTypeGroup for PreventHitOn";
      if (this.type == 69)
        this.Label1.Text = "Pick SfTypeGroup for PreventHitFrom";
      if (this.type == 70)
        this.Label1.Text = "Pick SfType to copy this attack table stats from";
      if (this.type == 71)
        this.Label1.Text = "Choose extra research necc to make new model or upgrade";
      if (this.type == 72)
        this.Label1.Text = "Choose research to make building loctype possible";
      if (this.type == 73)
        this.Label1.Text = "Choose regimeslot (resource) that is necc for constructing loctype";
      if (this.type == 74)
        this.Label1.Text = "Choose a trooptype to compare with";
      if (this.type == 75 | this.type == 76)
        this.Label1.Text = "Choose an event to call";
      if (this.type == 77 | this.type == 78)
        this.Label1.Text = "Choose an event to call";
      if (this.type == 79)
        this.Label1.Text = "Choose an alteration to make";
      if (this.type == 80)
        this.Label1.Text = "Choose an itemtype for autoprod of LT";
      if (this.type == 81)
        this.Label1.Text = "Choose an event to call";
      if (this.type == 82 & this.nr > -1)
        this.Label1.Text = "Choose an HQ to assign " + this.Data.UnitObj[this.nr].Name + " too.";
      if (this.type == 83)
        this.Label1.Text = "Choose a people for historical unit/commander.";
      if (this.type == 84)
        this.Label1.Text = "Choose historical unit model.";
      if (this.type == 85)
        this.Label1.Text = "Choose historical unit with deck cards";
      if (this.type == 86)
        this.Label1.Text = "Choose historical unit with hisvar variables";
      if (this.type == 87)
        this.Label1.Text = "Choose non-model historical unit not yet placed on map you want to put on map";
      if (this.type == 88)
        this.Label1.Text = "Choose a people for historical unit GfxUse";
      if (this.type == 89)
        this.Label1.Text = "Choose sec. reinforcementtype for sftype";
      if (this.type == 90)
        this.Label1.Text = "Select a library";
      if (this.type == 91)
        this.Label1.Text = "Select a type";
      if (this.type == 92)
        this.Label1.Text = "Select a valueType";
      if (this.type == 93)
        this.Label1.Text = "Select a library";
      if (this.type == 94)
        this.Label1.Text = "Select a library";
      if (this.type == 95 | this.type == 96 | this.type == 97)
        this.Label1.Text = "Select a library";
      if (this.type == 98)
        this.Label1.Text = "Substitute by which existing regime?";
      if (this.type == 99)
        this.Label1.Text = "Substitute by which existing people?";
      if (this.type == 100)
        this.Label1.Text = "Select MODEL to place an instance of on the map";
      if (this.type == 101)
        this.Label1.Text = "Select his.unit to place on the map";
      if (this.type == 102)
        this.Label1.Text = "Select commander to add to pool";
      if (this.type == 103)
        this.Label1.Text = "Select commander to assign to selected unit";
      if (this.type == 104)
        this.Label1.Text = "Select a library";
      if (this.type == 105)
        this.Label1.Text = "Select a valueType";
      if (this.type == 106)
        this.Label1.Text = "Select regime for stringlist cell";
      if (this.type == 107)
        this.Label1.Text = "Set Library of eventpic";
      if (this.type == 108)
        this.Label1.Text = "Set Library of small gfx";
      if (this.type == 109)
        this.Label1.Text = "Set Library of cards";
      if (this.type == 110)
        this.Label1.Text = "Set Historical Unit";
      if (this.type == 111)
        this.Label1.Text = "Set Model His Unit";
      if (this.type == 112)
        this.Label1.Text = "Set Commander Historical Unit";
      if (this.type == 113)
        this.Label1.Text = "Set Landscape";
      if (this.type == 114)
        this.Label1.Text = "Set People";
      if (this.type == 115)
        this.Label1.Text = "Set River";
      if (this.type == 116)
        this.Label1.Text = "Set Road";
      if (this.type == 117)
        this.Label1.Text = "Set Troop&Equip";
      if (this.type == 118)
        this.Label1.Text = "Set Historical";
      if (this.type == 119)
        this.Label1.Text = "Set His MODEL";
      if (this.type == 120)
        this.Label1.Text = "Set Landscape";
      if (this.type == 121)
        this.Label1.Text = "Set Commander";
      if (this.type == 122)
        this.Label1.Text = "Set People";
      if (this.type == 123)
        this.Label1.Text = "Set Regime";
      if (this.type == 124)
        this.Label1.Text = "Set River";
      if (this.type == 125)
        this.Label1.Text = "Set Road";
      if (this.type == 126)
        this.Label1.Text = "Set Troop&Equip";
      if (this.type == (int) sbyte.MaxValue)
        this.Label1.Text = "Set LocType";
      if (this.type == 128)
        this.Label1.Text = "Set LocType";
      if (this.type == 129)
        this.Label1.Text = "Set Library of reinf.type";
      if (this.type == 130)
        this.Label1.Text = "Select based on which troop type?";
      if (this.type == 131)
        this.Label1.Text = "Select Troop&Equip";
      if (this.type == 132)
        this.Label1.Text = "Select People";
      if (this.type == 133)
        this.Label1.Text = "Select Type of historical unit";
      if (this.type == 134)
        this.Label1.Text = "Select People";
      if (this.type == 135)
        this.Label1.Text = "Select Model";
      if (this.type == 136)
        this.Label1.Text = "Select Unit";
      if (this.type == 137)
        this.Label1.Text = "Select People";
      if (this.type == 138)
        this.Label1.Text = "Select Model";
      if (this.type == 139)
        this.Label1.Text = "Select Deck card";
      if (this.type == 140)
        this.Label1.Text = "Select Small Gfx";
      if (this.type == 141)
        this.Label1.Text = "Select Event Picture";
      if (this.type == 142)
        this.Label1.Text = "Select Small Gfx";
      if (this.type == 143)
        this.Label1.Text = "Select Event Picture";
      if (this.type == 144)
        this.Label1.Text = "Set Historical Unit";
      if (this.type == 145)
        this.Label1.Text = "Set Troop&Equip";
      if (this.type == 146)
        this.Label1.Text = "Select Actioncard";
      if (this.type == 147)
        this.Label1.Text = "Select Replacement";
      if (this.type == 148)
        this.Label1.Text = "Select Replacement";
      if (this.type == 149)
        this.Label1.Text = "Select Replacement";
      if (this.type == 150)
        this.Label1.Text = "Select Lookup Id/Label";
      if (this.type == 151)
        this.Label1.Text = "Select Replacement";
      if (this.type == 153)
        this.Label1.Text = "Select bridge to blow";
      if (this.type == 154)
        this.Label1.Text = "Select bridge to construct/repair";
      this.Show();
      this.Focus();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.ListBox1.SelectedIndex >= 0)
      {
        ListItem selectedItem = (ListItem) this.ListBox1.SelectedItem;
        int num1;
        if (this.type == 1)
          this.Data.LandscapeTypeObj[this.nr].BuildGround = selectedItem.ID;
        else if (this.type == 2)
          this.Data.LandscapeTypeObj[this.nr].AddOverride(selectedItem.ID);
        else if (this.type == 3)
          this.Data.RegimeObj[this.nr].People = selectedItem.ID;
        else if (this.type == 4)
          this.Data.SFTypeObj[this.nr].MoveType = selectedItem.ID;
        else if (this.type == 5)
          this.Data.SFTypeObj[this.nr].UnitGroup = selectedItem.ID;
        else if (this.type == 6)
          this.Data.SFObj[this.nr].Type = selectedItem.ID;
        else if (this.type == 7)
          this.Data.SFObj[this.nr].People = selectedItem.ID;
        else if (this.type == 8)
        {
          this.Data.LocTypeObj[this.nr].OverdrawLTNr = selectedItem.ID;
          this.Data.LocTypeObj[this.nr].OverdrawSpriteNr = 0;
        }
        else if (this.type == 9)
          this.Data.LocTypeObj[this.nr].OverdrawSpriteNr = selectedItem.ID;
        else if (this.type == 10)
        {
          this.Data.LocTypeObj[this.nr].OnDestructLT = selectedItem.ID;
          this.Data.LocTypeObj[this.nr].OnDestructSpriteNr = 0;
        }
        else if (this.type == 11)
          this.Data.LocTypeObj[this.nr].OnDestructSpriteNr = selectedItem.ID;
        else if (this.type == 12)
          this.Data.LocTypeObj[this.nr].LocTypeGroup = selectedItem.ID;
        else if (this.type == 13)
          this.Data.PeopleObj[this.nr].PeopleGroup = selectedItem.ID;
        else if (this.type == 14)
          this.Data.PeopleObj[this.nr].RegCol = selectedItem.ID;
        else if (this.type == 15)
          this.Data.HistoricalUnitObj[this.nr].TempRegime = selectedItem.ID;
        else if (this.type == 16)
          this.Data.LocObj[this.nr].People = selectedItem.ID;
        else if (this.type == 17)
          this.Data.ItemTypeObj[this.nr].ItemGroup = selectedItem.ID;
        else if (this.type == 18)
          this.Data.ItemTypeObj[this.nr].ResFieldNeeded[this.nr2] = selectedItem.ID;
        else if (this.type == 19)
          this.Data.ItemTypeObj[this.nr].IsSFType = selectedItem.ID;
        else if (this.type == 20)
          this.Data.ItemTypeObj[this.nr].Blocks = selectedItem.ID;
        else if (this.type == 21)
          this.Data.ResearchObj[this.nr].SFTypePic = selectedItem.ID;
        else if (this.type == 22)
          this.Data.ResearchObj[this.nr].PreReq = selectedItem.ID;
        else if (this.type == 23)
          this.Data.ResearchObj[this.nr].PreReq2 = selectedItem.ID;
        else if (this.type == 24)
          this.Data.ResearchObj[this.nr].Blocks = selectedItem.ID;
        else if (this.type == 25)
          this.Data.Variants[this.nr] = selectedItem.ID;
        else if (this.type == 26)
          this.Data.SFTypeObj[this.nr].UpgradeToo = selectedItem.ID;
        else if (this.type != 27 && this.type != 28 && this.type != 29 && this.type != 30)
        {
          if (this.type == 31)
            this.Data.ActionCardObj[this.nr].ExecuteEvent = selectedItem.ID;
          else if (this.type == 32)
            this.Data.EventObj[this.nr].Category = selectedItem.ID;
          else if (this.type == 33)
            this.Data.LocObj[this.nr].HQ = selectedItem.ID;
          else if (this.type == 34)
            this.Data.ItemTypeObj[this.nr].UseSFType = selectedItem.ID;
          else if (this.type == 35)
            this.Data.ActionCardObj[this.nr].PreExecuteEvent = selectedItem.ID;
          else if (this.type == 36)
            this.Data.HistoricalUnitObj[this.nr].Type = selectedItem.ID;
          else if (this.type == 37)
          {
            this.Data.UnitObj[this.nr].Historical = selectedItem.ID;
            if (selectedItem.ID > -1)
              this.Data.HistoricalUnitObj[selectedItem.ID].TempRegime = this.Data.UnitObj[this.nr].Regime;
          }
          else if (this.type == 38)
            this.Data.CampaignRoom = selectedItem.ID;
          else if (this.type == 39)
          {
            HistoricalUnitClass[] historicalUnitObj = this.Data.HistoricalUnitObj;
            HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
            int nr = this.nr;
            int index = nr;
            historicalUnitClassArray[index].AutoEventCounter = historicalUnitObj[nr].AutoEventCounter + 1;
            this.Data.HistoricalUnitObj[this.nr].AutoEvent = (int[]) Utils.CopyArray((Array) this.Data.HistoricalUnitObj[this.nr].AutoEvent, (Array) new int[this.Data.HistoricalUnitObj[this.nr].AutoEventCounter + 1]);
            this.Data.HistoricalUnitObj[this.nr].AutoChance = (int[]) Utils.CopyArray((Array) this.Data.HistoricalUnitObj[this.nr].AutoChance, (Array) new int[this.Data.HistoricalUnitObj[this.nr].AutoEventCounter + 1]);
            this.Data.HistoricalUnitObj[this.nr].AutoEvent[this.Data.HistoricalUnitObj[this.nr].AutoEventCounter] = selectedItem.ID;
            this.Data.HistoricalUnitObj[this.nr].AutoChance[this.Data.HistoricalUnitObj[this.nr].AutoEventCounter] = 10;
          }
          else if (this.type == 40)
          {
            HistoricalUnitClass[] historicalUnitObj = this.Data.HistoricalUnitObj;
            HistoricalUnitClass[] historicalUnitClassArray = historicalUnitObj;
            int nr = this.nr;
            int index = nr;
            historicalUnitClassArray[index].DeckCardCounter = historicalUnitObj[nr].DeckCardCounter + 1;
            this.Data.HistoricalUnitObj[this.nr].DeckCard = (int[]) Utils.CopyArray((Array) this.Data.HistoricalUnitObj[this.nr].DeckCard, (Array) new int[this.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1]);
            this.Data.HistoricalUnitObj[this.nr].DeckChance = (int[]) Utils.CopyArray((Array) this.Data.HistoricalUnitObj[this.nr].DeckChance, (Array) new int[this.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1]);
            this.Data.HistoricalUnitObj[this.nr].DeckCard[this.Data.HistoricalUnitObj[this.nr].DeckCardCounter] = selectedItem.ID;
            this.Data.HistoricalUnitObj[this.nr].DeckChance[this.Data.HistoricalUnitObj[this.nr].DeckCardCounter] = 10;
          }
          else if (this.type == 41)
          {
            int index1 = -1;
            int moveMatrixCounter = this.Game.NewAIObj.MoveMatrixCounter;
            for (int index2 = 0; index2 <= moveMatrixCounter; ++index2)
            {
              if (this.Game.NewAIObj.MoveMatrixUnit[index2] == this.Game.EditObj.OrderUnit)
              {
                index1 = index2;
                break;
              }
            }
            if (index1 > -1)
              this.Game.NewAIObj.MoveMatrixUnitMarker[index1] = selectedItem.ID;
          }
          else if (this.type == 42)
            DrawMod.TGame.EditObj.TempSelected = selectedItem.ID;
          else if (this.type == 43)
            DrawMod.TGame.EditObj.TempCopy = selectedItem.ID;
          else if (this.type == 44)
            DrawMod.TGame.Data.SFObj[this.nr].MoveType = selectedItem.ID;
          else if (this.type == 45)
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].SubParts[this.nr2] = selectedItem.ID;
          else if (this.type == 46)
          {
            if (selectedItem.ID > -1)
            {
              num1 = 0;
              int num2 = this.type != 47 ? 7 : (int) Interaction.MsgBox((object) "Do you want to overwrite te units composition with the MODELS?", MsgBoxStyle.YesNo);
              this.Data.HistoricalUnitObj[this.nr].Counter = this.Data.HistoricalUnitObj[selectedItem.ID].Counter;
              this.Data.HistoricalUnitObj[this.nr].Green = this.Data.HistoricalUnitObj[selectedItem.ID].Green;
              this.Data.HistoricalUnitObj[this.nr].SmallGfx = this.Data.HistoricalUnitObj[selectedItem.ID].SmallGfx;
              this.Data.HistoricalUnitObj[this.nr].Red = this.Data.HistoricalUnitObj[selectedItem.ID].Red;
              this.Data.HistoricalUnitObj[this.nr].People = this.Data.HistoricalUnitObj[selectedItem.ID].People;
              this.Data.HistoricalUnitObj[this.nr].Blue = this.Data.HistoricalUnitObj[selectedItem.ID].Blue;
              this.Data.HistoricalUnitObj[this.nr].Type = this.Data.HistoricalUnitObj[selectedItem.ID].Type;
              this.Data.HistoricalUnitObj[this.nr].TempRegime = this.Data.HistoricalUnitObj[selectedItem.ID].TempRegime;
              this.Data.HistoricalUnitObj[this.nr].ModelMaster = selectedItem.ID;
              int unitCounter1 = this.Data.UnitCounter;
              for (int index = 0; index <= unitCounter1; ++index)
              {
                if (this.Data.UnitObj[index].Historical == this.nr)
                  this.Data.UnitObj[index].HistoricalSubPart = -1;
              }
              int index3 = 0;
              do
              {
                this.Data.HistoricalUnitObj[this.nr].SubParts[index3] = this.Data.HistoricalUnitObj[selectedItem.ID].SubParts[index3];
                this.Data.HistoricalUnitObj[this.nr].Designation[index3] = this.Data.HistoricalUnitObj[selectedItem.ID].Designation[index3];
                this.Data.HistoricalUnitObj[this.nr].DesignationSmall[index3] = this.Data.HistoricalUnitObj[selectedItem.ID].DesignationSmall[index3];
                if (this.Data.HistoricalUnitObj[this.nr].SubParts[index3] > -1)
                {
                  int unitCounter2 = this.Data.UnitCounter;
                  for (int unr = 0; unr <= unitCounter2; ++unr)
                  {
                    if (this.Data.UnitObj[unr].Historical == this.nr & this.Data.UnitObj[unr].HistoricalSubPart == -1)
                    {
                      this.Data.UnitObj[unr].HistoricalSubPart = index3;
                      if (num2 == 6)
                      {
                        int hq = this.Data.UnitObj[unr].HQ;
                        DrawMod.TGame.HandyFunctionsObj.CopyUnit(unr, DrawMod.TGame.HandyFunctionsObj.GetPreDef(this.Data.HistoricalUnitObj[this.nr].SubParts[index3]), false);
                        this.Data.UnitObj[unr].HQ = hq;
                        break;
                      }
                      break;
                    }
                  }
                }
                ++index3;
              }
              while (index3 <= 9);
            }
            else
            {
              this.Data.HistoricalUnitObj[this.nr].ModelMaster = selectedItem.ID;
              int unitCounter = this.Data.UnitCounter;
              for (int index = 0; index <= unitCounter; ++index)
              {
                if (this.Data.UnitObj[index].Historical == this.nr)
                  this.Data.UnitObj[index].HistoricalSubPart = -1;
              }
            }
          }
          else if (this.type == 47)
          {
            if (selectedItem.ID > -1 & this.nr > -1 & this.nr2 > -1)
            {
              num1 = 0;
              bool flag = false;
              if (Interaction.MsgBox((object) "Auto name and shortname?", MsgBoxStyle.YesNo, (object) "Shadow Empire : Planetary Conquest") == MsgBoxResult.Yes)
              {
                this.Game.ProcessingObj.AddNewUnitBasedOnHistorical(this.Game.SelectX, this.Game.SelectY, 0, this.Game.Data.MapObj[0].HexObj[this.Game.SelectX, this.Game.SelectY].Regime, selectedItem.ID, freePPnoUnit: true);
                flag = true;
                this.nr = this.Data.HistoricalUnitCounter;
              }
              if (!flag)
              {
                this.Data.AddHistoricalUnit();
                this.nr = this.Data.HistoricalUnitCounter;
                this.Data.HistoricalUnitObj[this.nr].Counter = this.Data.HistoricalUnitObj[selectedItem.ID].Counter;
                this.Data.HistoricalUnitObj[this.nr].Name = this.Data.HistoricalUnitObj[selectedItem.ID].Name;
                if (this.Data.HistoricalUnitObj[selectedItem.ID].NameCounter == -1 & this.Data.HistoricalUnitObj[selectedItem.ID].Type < 5)
                  this.Data.HistoricalUnitObj[this.nr].CounterString = this.Data.HistoricalUnitObj[selectedItem.ID].CounterString;
                else if (!flag)
                {
                  this.Data.HistoricalUnitObj[this.nr].Name = Interaction.InputBox("Give historical unit name (example: 22nd inf div, III Corps)", "Shadow Empire : Planetary Conquest");
                  this.Data.HistoricalUnitObj[this.nr].CounterString = Interaction.InputBox("Give CounterString(shortname) (22, III)", "Shadow Empire : Planetary Conquest");
                }
                this.Data.HistoricalUnitObj[this.nr].Green = this.Data.HistoricalUnitObj[selectedItem.ID].Green;
                this.Data.HistoricalUnitObj[this.nr].Red = this.Data.HistoricalUnitObj[selectedItem.ID].Red;
                this.Data.HistoricalUnitObj[this.nr].Blue = this.Data.HistoricalUnitObj[selectedItem.ID].Blue;
                this.Data.HistoricalUnitObj[this.nr].Type = this.Data.HistoricalUnitObj[selectedItem.ID].Type;
                this.Data.HistoricalUnitObj[this.nr].TempRegime = this.Data.HistoricalUnitObj[selectedItem.ID].TempRegime;
                if (this.Data.HistoricalUnitObj[this.nr].TempRegime == -1)
                  this.Data.HistoricalUnitObj[this.nr].TempRegime = this.Data.MapObj[0].HexObj[DrawMod.TGame.SelectX, DrawMod.TGame.SelectY].Regime;
                if (this.Data.HistoricalUnitObj[this.nr].TempRegime > -1)
                  this.Data.HistoricalUnitObj[this.nr].ModelMaster = selectedItem.ID;
              }
              int num3 = 9999;
              int num4 = -1;
              int num5 = this.Game.Data.UnitObj[this.Game.Data.UnitCounter].Regime;
              if (num5 == -1)
                num5 = this.Game.Data.HistoricalUnitObj[this.nr].TempRegime;
              int unitCounter3 = this.Game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter3; ++index)
              {
                if (this.Game.Data.UnitObj[index].Regime == num5 && this.Game.Data.UnitObj[index].PreDef == -1 && this.Game.Data.UnitObj[index].IsHQ && index != this.Game.Data.UnitCounter)
                {
                  int num6 = this.Game.HandyFunctionsObj.Distance(DrawMod.TGame.Data.UnitObj[index].X, DrawMod.TGame.Data.UnitObj[index].Y, DrawMod.TGame.Data.UnitObj[index].Map, DrawMod.TGame.SelectX, DrawMod.TGame.SelectY, DrawMod.TGame.EditObj.MapSelected);
                  if (num6 < num3)
                  {
                    num3 = num6;
                    num4 = index;
                  }
                }
              }
              if (!flag)
              {
                int index = 0;
                do
                {
                  this.Data.HistoricalUnitObj[this.nr].SubParts[index] = this.Data.HistoricalUnitObj[selectedItem.ID].SubParts[index];
                  this.Data.HistoricalUnitObj[this.nr].Designation[index] = this.Data.HistoricalUnitObj[selectedItem.ID].Designation[index];
                  if (this.Data.HistoricalUnitObj[this.nr].SubParts[index] > -1)
                  {
                    this.Data.AddUnit(DrawMod.TGame.SelectX, DrawMod.TGame.SelectY, DrawMod.TGame.EditObj.MapSelected);
                    int unitCounter4 = this.Data.UnitCounter;
                    this.Data.UnitObj[unitCounter4].Name = this.Data.HistoricalUnitObj[this.nr].Name;
                    this.Data.UnitObj[unitCounter4].Historical = this.nr;
                    this.Data.UnitObj[unitCounter4].Regime = this.Data.HistoricalUnitObj[this.nr].TempRegime;
                    this.Data.UnitObj[unitCounter4].HistoricalSubPart = index;
                    DrawMod.TGame.HandyFunctionsObj.CopyUnit(unitCounter4, DrawMod.TGame.HandyFunctionsObj.GetPreDef(this.Data.HistoricalUnitObj[this.nr].SubParts[index]), false);
                    this.Data.UnitObj[unitCounter4].HQ = num4;
                  }
                  ++index;
                }
                while (index <= 9);
              }
              else
              {
                int unitCounter5 = this.Game.Data.UnitCounter;
                for (int unr = 0; unr <= unitCounter5; ++unr)
                {
                  if (this.Game.Data.UnitObj[unr].Historical == this.Game.Data.HistoricalUnitCounter)
                  {
                    int historicalSubPart = this.Data.UnitObj[unr].HistoricalSubPart;
                    DrawMod.TGame.HandyFunctionsObj.CopyUnit(unr, DrawMod.TGame.HandyFunctionsObj.GetPreDef(this.Data.HistoricalUnitObj[this.nr].SubParts[historicalSubPart]), false);
                    this.Data.UnitObj[unr].HQ = num4;
                  }
                }
              }
            }
            else
            {
              this.Data.RemoveHistoricalUnit(this.Data.HistoricalUnitCounter);
              int num7 = (int) Interaction.MsgBox((object) "Aborted because selected hex has no owner");
            }
          }
          else if (this.type == 48)
            DrawMod.TGame.Data.UnitObj[this.nr].HistoricalSubPart = selectedItem.ID;
          else if (this.type == 49)
            DrawMod.TGame.Data.ItemTypeObj[this.nr].PeopleMod = selectedItem.ID;
          else if (this.type == 50)
            DrawMod.TGame.Data.ItemTypeObj[this.nr].MoveTypeMod = selectedItem.ID;
          else if (this.type == 51)
            DrawMod.TGame.Data.SFTypeObj[this.nr].ReinforcementType = selectedItem.ID;
          else if (this.type == 52)
          {
            ++DrawMod.TGame.Data.StepNr;
            if (!DrawMod.TGame.Data.UnitObj[this.nr].IsHQ)
            {
              int num8 = 0;
              if (DrawMod.TGame.Data.UnitObj[this.nr].Historical > -1)
              {
                int unitCounter = DrawMod.TGame.Data.UnitCounter;
                for (int index = 0; index <= unitCounter; ++index)
                {
                  if (DrawMod.TGame.Data.UnitObj[index].Historical == DrawMod.TGame.Data.UnitObj[this.nr].Historical && DrawMod.TGame.Data.UnitObj[index].HQ == DrawMod.TGame.Data.UnitObj[this.nr].HQ && index != this.nr)
                  {
                    if (DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[index].Regime].UberRegime != DrawMod.TGame.Data.Turn && DrawMod.TGame.Data.RegimeObj[selectedItem.ID].UberRegime != DrawMod.TGame.Data.Turn)
                      DrawMod.TGame.Data.UnitObj[index].HQ = -1;
                    DrawMod.TGame.Data.UnitObj[index].Regime = selectedItem.ID;
                    DrawMod.TGame.Data.UnitObj[index].UnitIsGiven = true;
                    ++num8;
                  }
                }
              }
              if (DrawMod.TGame.Data.UnitObj[this.nr].Regime != DrawMod.TGame.Data.Turn)
                DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has taken over command of " + DrawMod.TGame.Data.UnitObj[this.nr].Name, DrawMod.TGame.Data.UnitObj[this.nr].Regime, -1, 1);
              if (DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[this.nr].Regime].UberRegime != DrawMod.TGame.Data.Turn && DrawMod.TGame.Data.RegimeObj[selectedItem.ID].UberRegime != DrawMod.TGame.Data.Turn)
                DrawMod.TGame.Data.UnitObj[this.nr].HQ = -1;
              DrawMod.TGame.Data.UnitObj[this.nr].Regime = selectedItem.ID;
              DrawMod.TGame.Data.UnitObj[this.nr].UnitIsGiven = true;
              DrawMod.TGame.HandyFunctionsObj.HistoryAddHex(DrawMod.TGame.Data.UnitObj[this.nr].X, DrawMod.TGame.Data.UnitObj[this.nr].Y, DrawMod.TGame.Data.UnitObj[this.nr].Map, DrawMod.TGame.Data.Turn, infostring: "Giving unit");
              DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has given command of " + DrawMod.TGame.Data.UnitObj[this.nr].Name + " to you.", selectedItem.ID, -1, 1);
            }
            else
            {
              int Number = 0;
              int unitCounter = DrawMod.TGame.Data.UnitCounter;
              for (int unr = 0; unr <= unitCounter; ++unr)
              {
                if (DrawMod.TGame.HandyFunctionsObj.IsUnitInHQChain(unr, this.nr))
                {
                  ++Number;
                  DrawMod.TGame.Data.UnitObj[unr].Regime = selectedItem.ID;
                  DrawMod.TGame.Data.UnitObj[unr].UnitIsGiven = true;
                  DrawMod.TGame.HandyFunctionsObj.HistoryAddHex(DrawMod.TGame.Data.UnitObj[unr].X, DrawMod.TGame.Data.UnitObj[unr].Y, DrawMod.TGame.Data.UnitObj[unr].Map, DrawMod.TGame.Data.Turn, infostring: "Giving unit");
                }
              }
              if (DrawMod.TGame.Data.UnitObj[this.nr].Regime != DrawMod.TGame.Data.Turn)
                DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has taken over command of " + DrawMod.TGame.Data.UnitObj[this.nr].Name + " and " + Conversion.Str((object) Number) + " subordinate units..", DrawMod.TGame.Data.UnitObj[this.nr].Regime, -1, 1);
              if (DrawMod.TGame.Data.RegimeObj[selectedItem.ID].UberRegime != DrawMod.TGame.Data.Turn && DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.UnitObj[this.nr].Regime].UberRegime != DrawMod.TGame.Data.Turn)
                DrawMod.TGame.Data.UnitObj[this.nr].HQ = -1;
              DrawMod.TGame.Data.UnitObj[this.nr].Regime = selectedItem.ID;
              DrawMod.TGame.Data.UnitObj[this.nr].UnitIsGiven = true;
              DrawMod.TGame.HandyFunctionsObj.HistoryAddHex(DrawMod.TGame.Data.UnitObj[this.nr].X, DrawMod.TGame.Data.UnitObj[this.nr].Y, DrawMod.TGame.Data.UnitObj[this.nr].Map, DrawMod.TGame.Data.Turn, infostring: "Giving unit");
              DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has given command of " + DrawMod.TGame.Data.UnitObj[this.nr].Name + " and " + Conversion.Str((object) Number) + " subordinate units to you.", selectedItem.ID, -1, 1);
            }
          }
          else if (this.type == 53)
          {
            ++DrawMod.TGame.Data.StepNr;
            int Number1 = 0;
            int Number2 = 0;
            int num9 = DrawMod.TGame.SelectX - (this.nr + 2);
            int num10 = DrawMod.TGame.SelectX + (this.nr + 2);
            for (int index4 = num9; index4 <= num10; ++index4)
            {
              int num11 = DrawMod.TGame.SelectY - (this.nr + 2);
              int num12 = DrawMod.TGame.SelectY + (this.nr + 2);
              for (int index5 = num11; index5 <= num12; ++index5)
              {
                if (index4 >= 0 & index5 >= 0 & index4 <= DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapWidth & index5 <= DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].MapHeight && DrawMod.TGame.HandyFunctionsObj.Distance(DrawMod.TGame.SelectX, DrawMod.TGame.SelectY, DrawMod.TGame.EditObj.MapSelected, index4, index5, DrawMod.TGame.EditObj.MapSelected) <= this.nr && DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].HexObj[index4, index5].Regime == DrawMod.TGame.Data.Turn)
                {
                  DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].HexObj[index4, index5].Regime = selectedItem.ID;
                  DrawMod.TGame.HandyFunctionsObj.HistoryAddHex(index4, index5, DrawMod.TGame.EditObj.MapSelected, DrawMod.TGame.Data.Turn, infostring: "Giving hex");
                  ++Number2;
                  if (DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].HexObj[index4, index5].Location > -1)
                  {
                    DrawMod.TGame.Data.LocObj[DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].HexObj[index4, index5].Location].HQ = -1;
                    ++Number1;
                  }
                }
              }
            }
            DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has given " + Conversion.Str((object) Number2) + " hexes and " + Conversion.Str((object) Number1) + " locations to you.", selectedItem.ID, -1, 1);
          }
          else if (this.type == 54)
          {
            DrawMod.TGame.Data.RegimeObj[selectedItem.ID].ResField[this.nr] = true;
            DrawMod.TGame.HandyFunctionsObj.AddMessageForOne(DrawMod.TGame.Data.RegimeObj[DrawMod.TGame.Data.Turn].Name + " has given " + DrawMod.TGame.Data.ResearchObj[this.nr].Name + " research to you.", selectedItem.ID, -1, 1);
            int sfTypeCounter = DrawMod.TGame.Data.SFTypeCounter;
            for (int index = 0; index <= sfTypeCounter; ++index)
            {
              if (DrawMod.TGame.Data.SFTypeObj[index].ModelID > 0 & DrawMod.TGame.Data.SFTypeObj[index].ModelRegime == selectedItem.ID)
              {
                int modelItemType = DrawMod.TGame.Data.SFTypeObj[index].ModelItemType;
                int tv9 = index;
                int tv7 = 0;
                int tv8 = 0;
                if (DrawMod.TGame.Data.SFTypeObj[index].ModelAutoImprovement[this.nr] && DrawMod.TGame.Data.SFTypeObj[index].ModelLastState[this.nr] == 0 & DrawMod.TGame.Data.SFTypeObj[index].ModelImproveEvent[this.nr] > 0 && DrawMod.TGame.Data.RegimeObj[selectedItem.ID].ResField[this.nr])
                {
                  DrawMod.TGame.EventRelatedObj.DoCheckSpecificEvent(DrawMod.TGame.Data.SFTypeObj[index].ModelImproveEvent[this.nr], tv9: tv9, tv7: tv7, tv8: tv8, tv10: modelItemType);
                  DrawMod.TGame.Data.SFTypeObj[index].ModelLastState[this.nr] = 1;
                }
              }
            }
            SimpleList simpleList = new SimpleList();
            int itemTypeCounter = DrawMod.TGame.Data.ItemTypeCounter;
            for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
            {
              if (DrawMod.TGame.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[0] == this.nr | DrawMod.TGame.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[1] == this.nr | DrawMod.TGame.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[2] == this.nr | DrawMod.TGame.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[3] == this.nr | DrawMod.TGame.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[4] == this.nr && DrawMod.TGame.Data.ItemTypeObj[itemtypenr].Blocks > -1)
              {
                int blocks = DrawMod.TGame.Data.ItemTypeObj[itemtypenr].Blocks;
                int locCounter = DrawMod.TGame.Data.LocCounter;
                for (int locnr = 0; locnr <= locCounter; ++locnr)
                {
                  if (DrawMod.TGame.Data.MapObj[DrawMod.TGame.EditObj.MapSelected].HexObj[DrawMod.TGame.Data.LocObj[locnr].X, DrawMod.TGame.Data.LocObj[locnr].Y].Regime == selectedItem.ID)
                  {
                    int index = 0;
                    do
                    {
                      if (DrawMod.TGame.Data.LocObj[locnr].Production[index] == DrawMod.TGame.Data.ItemTypeObj[itemtypenr].Blocks && DrawMod.TGame.HandyFunctionsObj.CanProduceItem(locnr, selectedItem.ID, itemtypenr).result)
                      {
                        DrawMod.TGame.Data.LocObj[locnr].Production[index] = itemtypenr;
                        int num13;
                        ++num13;
                      }
                      ++index;
                    }
                    while (index <= 3);
                  }
                }
              }
            }
          }
          else if (this.type == 55)
            DrawMod.TGame.Data.RegimeObj[this.nr].OfficerPool = selectedItem.ID;
          else if (this.type == 56)
          {
            if (selectedItem.ID == 0)
            {
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(0, "ID");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[0] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(1, "Type");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[1] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(2, "Parent");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[2] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(3, "Z-order");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[3] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(4, "Title");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[4] = NewEnums.LibVarValueType.Text;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(5, "Style");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[5] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(6, "Event");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[6] = NewEnums.LibVarValueType.Number;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(7, "Indicator");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[7] = NewEnums.LibVarValueType.SmallGfxId;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(8, "Text");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[8] = NewEnums.LibVarValueType.Text;
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(9, "AutoGray");
              DrawMod.TGame.Data.StringListObj[this.nr].ColValueType[9] = NewEnums.LibVarValueType.YesNo;
              DrawMod.TGame.Data.StringListObj[this.nr].Name = "UDS Management Tabs Format";
            }
            if (DrawMod.TGame.Data.StringListObj[this.nr].Width == -1)
              DrawMod.TGame.Data.StringListObj[this.nr].AddCol(-1);
            if (DrawMod.TGame.Data.StringListObj[this.nr].Length == -1)
              DrawMod.TGame.Data.StringListObj[this.nr].AddRow(-1);
          }
          else if (this.type == 57)
            DrawMod.TGame.Data.RegimeObj[this.nr].UberRegime = selectedItem.ID;
          else if (this.type == 58)
            DrawMod.TGame.Data.VariantEvent[this.nr] = selectedItem.ID;
          else if (this.type == 59)
          {
            if (DrawMod.TGame.EditObj.TempUnitList.CheckIfPresent(selectedItem.ID))
              DrawMod.TGame.EditObj.TempUnitList.remove(selectedItem.ID);
            else
              DrawMod.TGame.EditObj.TempUnitList.add(selectedItem.ID);
          }
          else if (this.type == 60)
            DrawMod.TGame.EditObj.OrderTarget = selectedItem.ID;
          else if (this.type == 61)
            DrawMod.TGame.Data.LandscapeTypeObj[this.nr].ExtraExterior = selectedItem.ID;
          else if (this.type == 62)
            this.Data.LandscapeTypeObj[this.nr].AddOverride2(selectedItem.ID);
          else if (this.type == 63)
            this.Data.SFTypeObj[this.nr].ModelImproveEvent[this.nr2] = selectedItem.ID;
          else if (this.type == 64)
            this.Data.SFTypeObj[this.nr].ModelNewEvent = selectedItem.ID;
          else if (this.type == 65)
            this.Data.SFTypeObj[this.nr].ModelNameList = selectedItem.ID;
          else if (this.type == 66)
            this.Data.SFTypeObj[this.nr].ModelInitialEvent = selectedItem.ID;
          else if (this.type == 67)
            this.Data.SFTypeObj[this.nr].ModelItemType = selectedItem.ID;
          else if (this.type == 68)
            this.Data.SFTypeObj[this.nr].PreventHitOn[this.nr2] = selectedItem.ID;
          else if (this.type == 69)
            this.Data.SFTypeObj[this.nr].PreventHitFrom[this.nr2] = selectedItem.ID;
          else if (this.type == 70)
          {
            int index = 0;
            do
            {
              this.Data.SFTypeObj[this.nr].FavTarget[index] = this.Data.SFTypeObj[selectedItem.ID].FavTarget[index];
              this.Data.SFTypeObj[this.nr].AttackPower[index] = this.Data.SFTypeObj[selectedItem.ID].AttackPower[index];
              this.Data.SFTypeObj[this.nr].AttackPowerDef[index] = this.Data.SFTypeObj[selectedItem.ID].AttackPowerDef[index];
              this.Data.SFTypeObj[this.nr].AttackArt[index] = RuntimeHelpers.GetObjectValue(this.Data.SFTypeObj[selectedItem.ID].AttackArt[index]);
              this.Data.SFTypeObj[this.nr].FavArtTarget[index] = this.Data.SFTypeObj[selectedItem.ID].FavArtTarget[index];
              this.Data.SFTypeObj[this.nr].HitPoints[index] = this.Data.SFTypeObj[selectedItem.ID].HitPoints[index];
              this.Data.SFTypeObj[this.nr].HitPointsDef[index] = this.Data.SFTypeObj[selectedItem.ID].HitPointsDef[index];
              ++index;
            }
            while (index <= 99);
          }
          else if (this.type == 71)
            this.Data.SFTypeObj[this.nr].ModelExtraResearch = selectedItem.ID;
          else if (this.type == 72)
            this.Data.LocTypeObj[this.nr].Research[this.nr2] = selectedItem.ID;
          else if (this.type == 73)
            this.Data.LocTypeObj[this.nr].VarType[this.nr2] = selectedItem.ID;
          else if (this.type == 74)
            DrawMod.TGame.EditObj.SFCompare = selectedItem.ID;
          else if (this.type == 75)
            DrawMod.TGame.Data.LocTypeObj[this.nr].AIEvent = selectedItem.ID;
          else if (this.type == 76)
            DrawMod.TGame.Data.LocTypeObj[this.nr].AILocEvent = selectedItem.ID;
          else if (this.type == 77)
            DrawMod.TGame.Data.SFTypeObj[this.nr].ModelVariantCheck[this.nr2] = selectedItem.ID;
          else if (this.type == 78)
            DrawMod.TGame.Data.SFTypeObj[this.nr].ModelVariantExec[this.nr2] = selectedItem.ID;
          else if (this.type == 79)
          {
            if (selectedItem.ID > -1 && DrawMod.TGame.Data.SFTypeObj[this.nr].ModelVariantExec[selectedItem.ID] > -1)
            {
              DrawMod.TGame.EventRelatedObj.DoCheckSpecificEvent(DrawMod.TGame.Data.SFTypeObj[this.nr].ModelVariantExec[selectedItem.ID], tv9: this.nr);
              int num14 = (int) Interaction.MsgBox((object) "Alteration to model has been made", Title: ((object) "Shadow Empire : Planetary Conquest"));
            }
          }
          else if (this.type == 80)
            DrawMod.TGame.Data.LocTypeObj[this.nr].AutoProd = selectedItem.ID;
          else if (this.type == 81)
            DrawMod.TGame.Data.LocTypeObj[this.nr].AIAfterBuildEvent = selectedItem.ID;
          else if (this.type == 82)
            DrawMod.TGame.ProcessingObj.SetUnitHq(this.nr, selectedItem.ID);
          else if (this.type == 83)
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].People = selectedItem.ID;
          else if (this.type == 84)
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].UseModelCounter = selectedItem.ID;
          else if (this.type == 85)
          {
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckCardCounter = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].DeckCardCounter;
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckCard = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1];
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckChance = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1];
            int deckCardCounter = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].DeckCardCounter;
            for (int index = 0; index <= deckCardCounter; ++index)
            {
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckCard[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].DeckCard[index];
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].DeckChance[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].DeckChance[index];
            }
          }
          else if (this.type == 86)
          {
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarCount = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarCount;
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarNato = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarCount + 1];
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarType = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarCount + 1];
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarValue = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarCount + 1];
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarSmall = new int[DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarCount + 1];
            int hisVarCount = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarCount;
            for (int index = 0; index <= hisVarCount; ++index)
            {
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarNato[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarNato[index];
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarType[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarType[index];
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarValue[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarValue[index];
              DrawMod.TGame.Data.HistoricalUnitObj[this.nr].HisVarSmall[index] = DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].HisVarSmall[index];
            }
          }
          else if (this.type == 87)
          {
            this.nr = selectedItem.ID;
            if (this.Data.HistoricalUnitObj[this.nr].TempRegime > -1)
            {
              int num15 = 9999;
              int num16 = -1;
              int unitCounter6 = this.Game.Data.UnitCounter;
              for (int index = 0; index <= unitCounter6; ++index)
              {
                if (this.Game.Data.UnitObj[index].Regime == this.Data.HistoricalUnitObj[this.nr].TempRegime && this.Game.Data.UnitObj[index].Historical > -1 && this.Game.Data.HistoricalUnitObj[this.nr].Type < this.Game.Data.HistoricalUnitObj[this.Game.Data.UnitObj[index].Historical].Type && this.Game.Data.UnitObj[index].PreDef == -1 && this.Game.Data.UnitObj[index].IsHQ)
                {
                  int num17 = this.Game.HandyFunctionsObj.Distance(DrawMod.TGame.Data.UnitObj[index].X, DrawMod.TGame.Data.UnitObj[index].Y, DrawMod.TGame.Data.UnitObj[index].Map, DrawMod.TGame.SelectX, DrawMod.TGame.SelectY, DrawMod.TGame.EditObj.MapSelected);
                  if (num17 < num15)
                  {
                    num15 = num17;
                    num16 = index;
                  }
                }
              }
              int index6 = 0;
              do
              {
                if (this.Data.HistoricalUnitObj[this.nr].SubParts[index6] > -1)
                {
                  this.Data.AddUnit(DrawMod.TGame.SelectX, DrawMod.TGame.SelectY, DrawMod.TGame.EditObj.MapSelected);
                  int unitCounter7 = this.Data.UnitCounter;
                  this.Data.UnitObj[unitCounter7].Name = this.Data.HistoricalUnitObj[this.nr].Name;
                  this.Data.UnitObj[unitCounter7].Historical = this.nr;
                  this.Data.UnitObj[unitCounter7].Regime = this.Data.HistoricalUnitObj[this.nr].TempRegime;
                  this.Data.UnitObj[unitCounter7].HistoricalSubPart = index6;
                  DrawMod.TGame.HandyFunctionsObj.CopyUnit(unitCounter7, DrawMod.TGame.HandyFunctionsObj.GetPreDef(this.Data.HistoricalUnitObj[this.nr].SubParts[index6]), false);
                  this.Data.UnitObj[unitCounter7].HQ = num16;
                }
                ++index6;
              }
              while (index6 <= 9);
            }
          }
          else if (this.type == 88)
            DrawMod.TGame.Data.HistoricalUnitObj[this.nr].UsePeopleGfx = selectedItem.ID;
          else if (this.type == 89)
            DrawMod.TGame.Data.SFTypeObj[this.nr].ReinforcementType2 = selectedItem.ID;
          else if (this.type == 90)
            this.Data.EventObj[this.nr].LibId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 91)
            this.Data.LibVarObj[this.nr].type = (NewEnums.LibVarType) selectedItem.ID;
          else if (this.type == 92)
            this.Data.LibVarObj[this.nr].valueType = (NewEnums.LibVarValueType) selectedItem.ID;
          else if (this.type == 93)
            this.Data.SFTypeObj[this.nr].LibId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 94)
            this.Data.HistoricalUnitObj[this.nr].LibId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 95)
            this.Data.UnitObj[this.nr].LibId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 96)
            this.Data.PeopleObj[this.nr].LibId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 97)
            this.Data.RegimeObj[this.nr].libId.SetFromAdvancedEditor(ref this.Data, selectedItem.ID);
          else if (this.type == 98)
            DrawMod.TGame.EditObj.TempRegimeSlot = selectedItem.ID;
          else if (this.type == 99)
            DrawMod.TGame.EditObj.TempPeopleSlot = selectedItem.ID;
          else if (this.type == 100)
            DrawMod.TGame.EditObj.TempHisModelUnit = selectedItem.ID;
          else if (this.type == 101)
            DrawMod.TGame.EditObj.TempHisUnit = selectedItem.ID;
          else if (this.type == 102)
          {
            if (selectedItem.ID > -1)
              DrawMod.TGame.Data.HistoricalUnitObj[selectedItem.ID].Pool = true;
          }
          else if (this.type == 103)
            DrawMod.TGame.EditObj.TempRandom = selectedItem.ID;
          else if (this.type == 104)
          {
            DrawMod.TGame.Data.StringListObj[this.nr].LibId.libSlot = selectedItem.ID;
            if (DrawMod.TGame.Data.Product == 7)
            {
              if (selectedItem.ID > -1)
              {
                DrawMod.TGame.Data.StringListObj[this.nr].LibId.id = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ID for stringlist in this lib")));
                if (DrawMod.TGame.Data.StringListObj[this.nr].LibId.id > this.Data.StringIDCounter)
                  this.Data.StringIDCounter = DrawMod.TGame.Data.StringListObj[this.nr].LibId.id;
              }
              else
                DrawMod.TGame.Data.StringListObj[this.nr].LibId.id = -1;
            }
          }
          else if (this.type == 105)
            this.Data.StringListObj[this.nr].ColValueType[this.nr2] = (NewEnums.LibVarValueType) selectedItem.ID;
          else if (this.type == 106)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 107)
          {
            this.Data.eventPicLibId[this.nr].libSlot = selectedItem.ID;
            if (selectedItem.ID > -1)
            {
              this.Data.eventPicLibId[this.nr].id = (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ID for eventpic in this lib")));
              if (this.Data.eventPicLibId[this.nr].id > this.Data.EventIdCounter)
                this.Data.EventIdCounter = this.Data.eventPicLibId[this.nr].id;
            }
            else
              this.Data.eventPicLibId[this.nr].id = -1;
          }
          else if (this.type == 108)
          {
            this.Data.SmallLibId[this.nr].libSlot = selectedItem.ID;
            this.Data.SmallLibId[this.nr].id = selectedItem.ID <= -1 ? -1 : (int) Math.Round(Conversion.Val(Interaction.InputBox("Give ID for eventpic in this lib")));
          }
          else if (this.type == 109)
            this.Data.ActionCardObj[this.nr].LibId.libSlot = selectedItem.ID;
          else if (this.type == 110)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 111)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 112 | this.type >= 113 & this.type <= 117 | this.type == (int) sbyte.MaxValue)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type >= 118 & this.type <= 126 | this.type == 128)
            this.Data.LibVarObj[this.nr].value = selectedItem.ID;
          else if (this.type == 129)
            this.Data.ReinfLibId[this.nr].libSlot = selectedItem.ID;
          else if (this.type == 130)
          {
            this.Data.SFTypeObj[this.nr].CopyDataFrom = selectedItem.ID;
            string name = this.Data.SFTypeObj[this.nr].Name;
            string description = this.Data.SFTypeObj[this.nr].Description;
            int reinforcementType = this.Data.SFTypeObj[this.nr].ReinforcementType;
            int reinforcementType2 = this.Data.SFTypeObj[this.nr].ReinforcementType2;
            string symbolFileName = this.Data.SFTypeObj[this.nr].SymbolFileName;
            string sidewaysFileName = this.Data.SFTypeObj[this.nr].SidewaysFileName;
            string moveWav = this.Data.SFTypeObj[this.nr].MoveWAV;
            string battleWav = this.Data.SFTypeObj[this.nr].BattleWAV;
            int id = this.Data.SFTypeObj[this.nr].Id;
            int[] numArray1 = new int[100];
            int[] numArray2 = (int[]) this.Data.SFTypeObj[this.nr].SFTypeVar.Clone();
            this.Data.SFTypeObj[this.nr] = this.Data.SFTypeObj[selectedItem.ID].Clone();
            this.Data.SFTypeObj[this.nr].CopyDataFrom = selectedItem.ID;
            this.Data.SFTypeObj[this.nr].Id = id;
            this.Data.SFTypeObj[this.nr].DontShowInList = false;
            if (this.nr2 < 1)
            {
              this.Data.SFTypeObj[this.nr].Name = name;
              this.Data.SFTypeObj[this.nr].Description = description;
              this.Data.SFTypeObj[this.nr].SFTypeVar = (int[]) numArray2.Clone();
              this.Data.SFTypeObj[this.nr].ReinforcementType = reinforcementType;
              this.Data.SFTypeObj[this.nr].ReinforcementType2 = reinforcementType2;
              this.Data.SFTypeObj[this.nr].SymbolFileName = symbolFileName;
              this.Data.SFTypeObj[this.nr].SymbolFileName2 = symbolFileName;
              this.Data.SFTypeObj[this.nr].SidewaysFileName = sidewaysFileName;
              this.Data.SFTypeObj[this.nr].MoveWAV = moveWav;
              this.Data.SFTypeObj[this.nr].MoveWAV = battleWav;
            }
            this.Data.SFTypeObj[this.nr].LoadSprites();
          }
          else if (this.type == 131)
            this.Data.SFObj[this.nr].Type = selectedItem.ID;
          else if (this.type == 132)
            this.Data.SFObj[this.nr].People = selectedItem.ID;
          else if (this.type == 133)
            this.Data.HistoricalUnitObj[this.nr].Type = selectedItem.ID;
          else if (this.type == 134)
            this.Data.HistoricalUnitObj[this.nr].UsePeopleGfx = selectedItem.ID;
          else if (this.type == 135)
            this.Data.HistoricalUnitObj[this.nr].UseModelCounter = selectedItem.ID;
          else if (this.type == 136)
            this.Data.HistoricalUnitObj[this.nr].SubParts[this.nr2] = selectedItem.ID;
          else if (this.type == 137)
            this.Data.HistoricalUnitObj[this.nr].People = selectedItem.ID;
          else if (this.type == 138)
            this.Data.HistoricalUnitObj[this.nr].ModelMaster = selectedItem.ID;
          else if (this.type == 139)
          {
            if (selectedItem.ID > -1)
            {
              if (this.nr2 > this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter)
              {
                this.Game.Data.HistoricalUnitObj[this.nr].DeckCard = (int[]) Utils.CopyArray((Array) this.Game.Data.HistoricalUnitObj[this.nr].DeckCard, (Array) new int[this.nr2 + 1]);
                this.Game.Data.HistoricalUnitObj[this.nr].DeckChance = (int[]) Utils.CopyArray((Array) this.Game.Data.HistoricalUnitObj[this.nr].DeckChance, (Array) new int[this.nr2 + 1]);
                this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter = this.nr2;
              }
            }
            else if (this.nr2 <= this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter)
            {
              this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter = this.nr2 - 1;
              if (this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter == -1)
              {
                this.Game.Data.HistoricalUnitObj[this.nr].DeckCard = new int[1];
                this.Game.Data.HistoricalUnitObj[this.nr].DeckChance = new int[1];
              }
              else
              {
                this.Game.Data.HistoricalUnitObj[this.nr].DeckCard = (int[]) Utils.CopyArray((Array) this.Game.Data.HistoricalUnitObj[this.nr].DeckCard, (Array) new int[this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1]);
                this.Game.Data.HistoricalUnitObj[this.nr].DeckChance = (int[]) Utils.CopyArray((Array) this.Game.Data.HistoricalUnitObj[this.nr].DeckChance, (Array) new int[this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter + 1]);
              }
            }
            if (this.nr2 <= this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter)
              this.Data.HistoricalUnitObj[this.nr].DeckCard[this.nr2] = selectedItem.ID;
            int deckCardCounter = this.Game.Data.HistoricalUnitObj[this.nr].DeckCardCounter;
            for (int index = 0; index <= deckCardCounter; ++index)
              this.Game.Data.HistoricalUnitObj[this.nr].DeckChance[index] = 100;
          }
          else if (this.type >= 140 & this.type <= 141)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type >= 142 & this.type <= 143)
            this.Data.LibVarObj[this.nr].value = selectedItem.ID;
          else if (this.type == 144)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 145)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 146)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 147)
          {
            if (selectedItem.ID > -1)
            {
              int mapWidth = this.Game.Data.MapObj[0].MapWidth;
              for (int index7 = 0; index7 <= mapWidth; ++index7)
              {
                int mapHeight = this.Game.Data.MapObj[0].MapHeight;
                for (int index8 = 0; index8 <= mapHeight; ++index8)
                {
                  if (this.Game.Data.MapObj[0].HexObj[index7, index8].LandscapeType == this.nr)
                    this.Game.Data.MapObj[0].HexObj[index7, index8].LandscapeType = selectedItem.ID;
                }
              }
            }
          }
          else if (this.type == 148)
          {
            if (selectedItem.ID > -1)
            {
              int mapWidth = this.Game.Data.MapObj[0].MapWidth;
              for (int index9 = 0; index9 <= mapWidth; ++index9)
              {
                int mapHeight = this.Game.Data.MapObj[0].MapHeight;
                for (int index10 = 0; index10 <= mapHeight; ++index10)
                {
                  int index11 = 0;
                  do
                  {
                    if (this.Game.Data.MapObj[0].HexObj[index9, index10].RoadType[index11] == this.nr)
                      this.Game.Data.MapObj[0].HexObj[index9, index10].RoadType[index11] = selectedItem.ID;
                    ++index11;
                  }
                  while (index11 <= 5);
                }
              }
            }
          }
          else if (this.type == 149)
          {
            if (selectedItem.ID > -1)
            {
              int mapWidth = this.Game.Data.MapObj[0].MapWidth;
              for (int index12 = 0; index12 <= mapWidth; ++index12)
              {
                int mapHeight = this.Game.Data.MapObj[0].MapHeight;
                for (int index13 = 0; index13 <= mapHeight; ++index13)
                {
                  int index14 = 0;
                  do
                  {
                    if (this.Game.Data.MapObj[0].HexObj[index12, index13].RiverType[index14] == this.nr)
                      this.Game.Data.MapObj[0].HexObj[index12, index13].RiverType[index14] = selectedItem.ID;
                    ++index14;
                  }
                  while (index14 <= 5);
                }
              }
            }
          }
          else if (this.type == 150)
            this.Data.StringListObj[this.nr].Data[this.nr2, this.nr3] = Conversions.ToString(selectedItem.ID);
          else if (this.type == 151)
          {
            if (selectedItem.ID > -1)
            {
              int mapWidth = this.Game.Data.MapObj[0].MapWidth;
              for (int index15 = 0; index15 <= mapWidth; ++index15)
              {
                int mapHeight = this.Game.Data.MapObj[0].MapHeight;
                for (int index16 = 0; index16 <= mapHeight; ++index16)
                {
                  if (this.Game.Data.MapObj[0].HexObj[index15, index16].Location > -1 && this.Game.Data.LocObj[this.Game.Data.MapObj[0].HexObj[index15, index16].Location].Type == this.nr)
                  {
                    this.Game.Data.LocObj[this.Game.Data.MapObj[0].HexObj[index15, index16].Location].Type = selectedItem.ID;
                    this.Game.Data.LocObj[this.Game.Data.MapObj[0].HexObj[index15, index16].Location].StructuralPts = this.Game.Data.LocTypeObj[selectedItem.ID].StructuralPts;
                  }
                }
              }
            }
          }
          else if (this.type == 153)
          {
            if (selectedItem.ID > -1 && this.Game.HandyFunctionsObj.HexNeighbour(this.Game.SelectX, this.Game.SelectY, 0, selectedItem.ID).onmap)
            {
              this.WindowRef.form3_orderResult = this.Game.ProcessingObj.BlowBridge(this.Game.EditObj.UnitSelected, this.Game.SelectX, this.Game.SelectY, 0, selectedItem.ID - 1);
              this.WindowRef.form3_returnInstruction = true;
              this.WindowRef.form3_data1 = 35;
            }
          }
          else if (this.type == 154 && selectedItem.ID > -1 && this.Game.HandyFunctionsObj.HexNeighbour(this.Game.SelectX, this.Game.SelectY, 0, selectedItem.ID).onmap)
          {
            this.WindowRef.form3_orderResult = this.Game.ProcessingObj.BuildInfra(this.Game.EditObj.UnitSelected, this.Game.SelectX, this.Game.SelectY, 0, selectedItem.ID - 1);
            this.WindowRef.form3_returnInstruction = true;
            this.WindowRef.form3_data1 = 36;
          }
        }
      }
      this.Close();
      this.formref.Enabled = true;
      this.formref.DoRefresh();
      this.formref.Show();
      this.formref.Focus();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      this.Close();
      this.formref.Enabled = true;
      this.formref.DoRefresh();
      this.formref.Show();
      this.formref.Focus();
    }

    private void Button3_Click(object sender, EventArgs e)
    {
      ArrayList arrayList = new ArrayList();
      int num1 = this.ListBox1.Items.Count - 1;
      for (int index = 0; index <= num1; ++index)
        arrayList.Add(RuntimeHelpers.GetObjectValue(this.ListBox1.Items[index]));
      SortListArray sortListArray = new SortListArray(true);
      arrayList.Sort((IComparer) sortListArray);
      this.ListBox1.Items.Clear();
      int num2 = arrayList.Count - 1;
      for (int index = 0; index <= num2; ++index)
        this.ListBox1.Items.Add(RuntimeHelpers.GetObjectValue(arrayList[index]));
    }
  }
}
