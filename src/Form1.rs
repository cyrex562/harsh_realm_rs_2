// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.Form1
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WindowsApplication1
{
  pub class Form1 : ImmoveableForm
  {
    pub const int ENUM_CURRENT_SETTINGS = -1;
    pub const int CDS_UPDATEREGISTRY = 1;
    pub const int CDS_TEST = 2;
    pub const int CDS_FULLSCREEN = 4;
    pub const int DISP_CHANGE_SUCCESSFUL = 0;
    pub const int DISP_CHANGE_RESTART = 1;
    pub const int DISP_CHANGE_FAILED = -1;
     int TempKeyTest;
     GameClass Game;
    pub ScreenClass Screeny;
    pub ScreenClass StoredScreeny;
    pub MouseClicked: bool;
     DateTime MouseTime;
    pub FullScreen: bool;
    pub RightMousePressed: bool;
    pub LastMouseX: i32;
    pub LastMouseY: i32;
    pub LastMouseOverX: i32;
    pub LastMouseOverY: i32;
    pub LastTipX: i32;
    pub LastTipY: i32;
    pub LastTipText: String;
    pub LastTipTextX: i32;
    pub LastTipTextY: i32;
     int StartupPhase;
    pub Buisy: bool;
     int CollectCount;
     int CheckMouseMove;
    pub doubleSize: bool;
    pub float doubleModX;
    pub float doubleModY;
     bool tempOnlyToolTip;
    [AccessedThroughProperty("Label1")]
     Label _Label1;
    pub startedWithDPIaware: bool;
    pub windowsTxtFormPlease: bool;
    pub windowsFormWidth: i32;
    pub windowsFormHeight: i32;
     bool hasFocus;
     bool currentlyInMouseLock;
    pub clickInProgress: bool;
     Bitmap sbmp;
    pub SimpleStringList DebugL;
    pub DateTime lastTimerTime;
    pub DateTime lastTimerTime_DebugPoint1;
    pub onlyTimerRun: bool;
    pub debugPoint2: i32;
    pub debugPoint3: i32;
    pub debugPoint4: i32;
     IContainer components;
    [AccessedThroughProperty("Timer1")]
     System.Windows.Forms.Timer _Timer1;
    [AccessedThroughProperty("ToolTip1")]
     ToolTip _ToolTip1;
    [AccessedThroughProperty("ColorDialog1")]
     ColorDialog _ColorDialog1;

    [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
    pub static extern int GetSystemMetrics(int nIndex);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    pub static extern bool SetProcessDPIAware();

    [DllImport("steam_api64.dll", CharSet = CharSet.Auto, SetLastError = true)]
    pub static extern int SteamAPI_RestartAppIfNecessary(int appId);

    [DllImport("user32", EntryPoint = "ChangeDisplaySettingsA", CharSet = CharSet.Ansi, SetLastError = true)]
    pub static extern int ChangeDisplaySettings( DEVMODE1 lpDevMode, int dwFlags);

    [DllImport("user32", EntryPoint = "EnumDisplaySettingsA", CharSet = CharSet.Ansi, SetLastError = true)]
    pub static extern bool EnumDisplaySettings(
      int lpszDeviceName,
      int iModeNum,
       DEVMODE1 lpDevMode);

    internal virtual Label Label1
    {
      get => this._Label1;
      [MethodImpl(MethodImplOptions.Synchronized)] set => this._Label1 = value;
    }

    pub Form1()
    {
      this.MouseUp += new MouseEventHandler(this.Form1_Mouseup);
      this.MouseLeave += new EventHandler(this.Form1_mouseleave);
      this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
      this.KeyPress += new KeyPressEventHandler(this.Form1_KeyPress);
      this.KeyDown += new KeyEventHandler(this.Form1_Keydown);
      this.KeyUp += new KeyEventHandler(this.Form1_Keyup);
      this.MouseWheel += new MouseEventHandler(this.Form1_MouseWheel);
      this.GotFocus += new EventHandler(this.Form1_GotFocus);
      this.LostFocus += new EventHandler(this.Form1_LostFocus);
      this.Load += new EventHandler(this.Form1_Load);
      this.Paint += new PaintEventHandler(this.Form1_Paint);
      this.MouseDown += new MouseEventHandler(this.Form1_Mousedown);
      this.TempKeyTest = 0;
      this.doubleSize = false;
      this.tempOnlyToolTip = false;
      this.startedWithDPIaware = false;
      this.windowsTxtFormPlease = false;
      this.hasFocus = true;
      this.currentlyInMouseLock = true;
      this.clickInProgress = false;
      this.DebugL = SimpleStringList::new();
      this.onlyTimerRun = false;
      CultureInfo specificCulture = CultureInfo.CreateSpecificCulture("en-US");
      CultureInfo.DefaultThreadCurrentCulture = specificCulture;
      CultureInfo.DefaultThreadCurrentUICulture = specificCulture;
      Thread.CurrentThread.CurrentCulture = specificCulture;
      Thread.CurrentThread.CurrentUICulture = specificCulture;
      bool flag;
      if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "windows.txt"))
      {
        try
        {
          flag = Form1.SetProcessDPIAware();
          this.startedWithDPIaware = true;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        try
        {
          StreamReader streamReader = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "windows.txt");
          while (!streamReader.EndOfStream)
          {
            string[] strArray = streamReader.ReadLine().Split('=');
            if (Operators.CompareString(strArray[0], "dpi_by_windows", false) == 0)
            {
              if (Operators.CompareString(strArray[1], "on", false) == 0)
              {
                this.startedWithDPIaware = false;
              }
              else
              {
                flag = Form1.SetProcessDPIAware();
                this.startedWithDPIaware = true;
              }
            }
            if (Operators.CompareString(strArray[0], "windowed_mode", false) == 0)
              this.windowsTxtFormPlease = Operators.CompareString(strArray[1], "on", false) == 0;
            if (Operators.CompareString(strArray[0], "windowed_mode_w", false) == 0)
            {
              this.windowsFormWidth = Conversions.ToInteger(strArray[1]);
              if (this.windowsFormWidth < 1024)
                this.windowsFormWidth = 1024;
            }
            if (Operators.CompareString(strArray[0], "windowed_mode_h", false) == 0)
            {
              this.windowsFormHeight = Conversions.ToInteger(strArray[1]);
              if (this.windowsFormHeight < 768)
                this.windowsFormHeight = 768;
            }
          }
          streamReader.Close();
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          int num =  Interaction.MsgBox((object) "Error trying to read windows.txt file.");
          ProjectData.ClearProjectError();
        }
      }
      this.InitializeComponent();
      this.Timer1.Enabled = true;
    }

    protected void Dispose(bool disposing)
    {
      if (!Information.IsNothing((object) this.Game))
        SoundMod.EndSound();
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual System.Windows.Forms.Timer Timer1
    {
      get => this._Timer1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
        if (this._Timer1 != null)
          this._Timer1.Tick -= eventHandler;
        this._Timer1 = value;
        if (this._Timer1 == null)
          return;
        this._Timer1.Tick += eventHandler;
      }
    }

    internal virtual ToolTip ToolTip1
    {
      get => this._ToolTip1;
      [MethodImpl(MethodImplOptions.Synchronized)] set => this._ToolTip1 = value;
    }

    internal virtual ColorDialog ColorDialog1
    {
      get => this._ColorDialog1;
      [MethodImpl(MethodImplOptions.Synchronized)] set => this._ColorDialog1 = value;
    }

     void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.Timer1 = new System.Windows.Forms.Timer(this.components);
      this.ToolTip1 = new ToolTip(this.components);
      this.ColorDialog1 = ColorDialog::new();
      this.Label1 = Label::new();
      this.SuspendLayout();
      this.Timer1.Interval = 50;
      this.Label1.Anchor = AnchorStyles.None;
      this.Label1.AutoSize = true;
      this.Label1.Font = Font::new("Microsoft Sans Serif", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.White;
      this.Label1.Location = new Point(119, 113);
      this.Label1.Name = "Label1";
      Label label1 = this.Label1;
      Size size1 = new Size(110, 31);
      Size size2 = size1;
      label1.Size = size2;
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Loading";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleMode = AutoScaleMode.Inherit;
      this.BackColor = Color.Black;
      size1 = new Size(364, 252);
      this.ClientSize = size1;
      this.Controls.Add((Control) this.Label1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MaximizeBox = false;
      if (this.windowsTxtFormPlease)
        this.Moveable = true;
      else
        this.Moveable = false;
      this.Name = nameof (Form1);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Game";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

     void Form1_Load(object sender, EventArgs e) => this.Cursor = Cursors.WaitCursor;

    pub void Startup()
    {
      this.Text = "Shadow Empire : Planetary Conquest";
      this.Icon = new Icon(AppDomain.CurrentDomain.BaseDirectory + "se1.ico");
      try
      {
        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "logs/ServerLog.txt"))
          File.Delete(AppDomain.CurrentDomain.BaseDirectory + "logs/ServerLog.txt");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      FileInfo[] files;
      bool flag;
      try
      {
        files = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "mods/").GetFiles("*.txt");
        flag = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = true;
        ProjectData.ClearProjectError();
      }
      if (!flag)
      {
        if (files.Length > 0)
        {
          StreamReader streamReader1 = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "defaultmod.txt");
          str1: String = streamReader1.ReadLine();
          streamReader1.Close();
          Prompt: String = "0] " + str1 + "\r\n";
          int Number = 0;
          foreach (FileInfo fileInfo in files)
          {
            Number += 1;
            StreamReader streamReader2 = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + "mods/" + fileInfo.Name);
            str2: String = streamReader2.ReadLine();
            streamReader2.Close();
            Prompt = Prompt + Strings.Trim(Conversion.Str((object) Number)) + "] " + str2 + "\r\n";
          }
          int num =  Math.Round(Conversion.Val(Interaction.InputBox(Prompt, "Shadow Empire : Planetary Conquest : Select Mod")));
          if (num > 0 & num <= files.Length)
          {
            DrawMod.ModFile = "mods/" + files[num - 1].Name;
            this.FinishUp();
          }
          else
          {
            DrawMod.ModFile = "defaultmod.txt";
            this.FinishUp();
          }
        }
        else
        {
          DrawMod.ModFile = "defaultmod.txt";
          this.FinishUp();
        }
      }
      else
      {
        DrawMod.ModFile = "defaultmod.txt";
        this.FinishUp();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    pub void FinishUp()
    {
      Graphics Expression = Graphics.FromHwnd(this.Handle);
      DrawMod.DPIx =  Math.Round((double) Expression.DpiX);
      DrawMod.DPIy =  Math.Round((double) Expression.DpiY);
      this.Game = new GameClass(this);
      DrawMod.TGame = this.Game;
      if (!this.startedWithDPIaware)
        DrawMod.TGame.EditObj.DoubleSize = false;
      this.doubleSize = DrawMod.TGame.EditObj.DoubleSize;
      if (Form1.SteamAPI_RestartAppIfNecessary(1154840) == 1)
      {
        int num =  Interaction.MsgBox((object) "The game is not launched from Steam. The game will close down. Please start the game up from Steam. ", Title: ((object) "Copy protection check"));
        ProjectData.EndApp();
      }
      this.Game.EditObj.ShownWelcome = false;
      this.Game.FormRef = this;
      DrawMod.TGame = this.Game;
      Rectangle workingArea = Screen.FromControl((Control) this).WorkingArea;
      if (this.windowsTxtFormPlease)
      {
        this.Width = this.windowsFormWidth;
        this.Height = this.windowsFormHeight;
        if (this.Game.Data.Product >= 7 && this.Game.EditObj.DoubleSizePercentage > 100)
        {
          if ( Math.Round((double) (this.Width * 100) / (double) this.Game.EditObj.DoubleSizePercentage) < 1280)
          {
            this.Game.EditObj.DoubleSizePercentage = 100;
            this.Game.EditObj.DoubleSize = false;
            this.Game.EditObj.Save(this.Game.AppPath + "editobj.txt");
          }
          if ( Math.Round((double) (this.Height * 100) / (double) this.Game.EditObj.DoubleSizePercentage) < 768)
          {
            this.Game.EditObj.DoubleSizePercentage = 100;
            this.Game.EditObj.DoubleSize = false;
            this.Game.EditObj.Save(this.Game.AppPath + "editobj.txt");
          }
        }
        this.BackColor = Color.Black;
        this.Visible = true;
        this.Label1.Dispose();
        this.FullScreen = false;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.Refresh();
      }
      else
      {
        bool flag = false;
        Point point;
        if (this.Game.Data.Product >= 6 & this.Game.EditObj.overruleScreenResWidth >= 1280 & this.Game.EditObj.overruleScreenResHeight >= 768)
        {
          DEVMODE1 lpDevMode = DEVMODE1::new();
          lpDevMode.dmSize = (short) Marshal.SizeOf((object) lpDevMode);
          if (Form1.EnumDisplaySettings(0, 0,  lpDevMode))
          {
            this.Game.StartupScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            this.Game.StartupScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            lpDevMode.dmDeviceName = new string(new char[33]);
            lpDevMode.dmFormName = new string(new char[33]);
            lpDevMode.dmSize = (short) Marshal.SizeOf((object) lpDevMode);
            lpDevMode.dmPelsWidth = this.Game.EditObj.overruleScreenResWidth;
            lpDevMode.dmPelsHeight = this.Game.EditObj.overruleScreenResHeight;
            if (Form1.ChangeDisplaySettings( lpDevMode, 4) == 0)
              flag = true;
            if (flag)
            {
              this.Width = lpDevMode.dmPelsWidth;
              this.Height = lpDevMode.dmPelsHeight;
              point = new Point(0, 0);
              this.Location = point;
              this.BackColor = Color.Black;
              this.Visible = true;
              this.Label1.Dispose();
              this.FullScreen = true;
            }
          }
        }
        if (!flag)
        {
          this.Game.StartupScreenWidth = Screen.PrimaryScreen.Bounds.Width;
          this.Game.StartupScreenHeight = Screen.PrimaryScreen.Bounds.Height;
          this.Width = workingArea.Width;
          this.Height = workingArea.Height;
          point = new Point(0, 0);
          this.Location = point;
          this.Bounds = Screen.PrimaryScreen.Bounds;
          this.BackColor = Color.Black;
          this.Visible = true;
          this.Label1.Dispose();
          this.FullScreen = true;
        }
      }
      if (!this.FullScreen)
      {
        this.Game.ScreenWidth = this.windowsFormWidth;
        this.Game.ScreenHeight = this.windowsFormHeight;
      }
      else
      {
        this.Game.ScreenHeight = this.Height;
        this.Game.ScreenWidth = this.Width;
      }
      this.Game.RealScreenWidth = this.Game.ScreenWidth;
      this.Game.RealScreenHeight = this.Game.ScreenHeight;
      if (this.Game.ScreenWidth == this.Game.RealScreenWidth & this.Game.ScreenHeight == this.Game.RealScreenHeight && this.FullScreen && !this.Game.EditObj.AutoDpiCheckDone & !this.Game.EditObj.DoubleSize && this.Game.ScreenWidth >= 3840 & this.Game.ScreenHeight >= 2160 && this.Game.ScreenWidth % 2 == 0 && this.Game.ScreenHeight % 2 == 0)
      {
        this.Game.EditObj.DoubleSize = true;
        this.Game.EditObj.DoubleSizePercentage = 200;
        this.Game.EditObj.AutoDpiCheckDone = true;
        this.Game.EditObj.Save(this.Game.AppPath + "editobj.txt");
        this.doubleSize = true;
      }
      if (this.Game.ScreenWidth < 1280 | this.Game.ScreenHeight < 768)
      {
        int num1 =  Interaction.MsgBox((object) "The minimum screen resolution your desktop needs to have is 1280x768.", Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      if (this.doubleSize)
      {
        HandyFunctionsclass handyFunctionsObj = this.Game.HandyFunctionsObj;
        Form1 form1 = this;
         Form1 local =  form1;
        handyFunctionsObj.SwitchResolution( local);
      }
      SoundMod.InitSound( this);
      this.Screeny = DrawMod.TGame.ModIntroType != 0 ? (DrawMod.TGame.ModIntroType != 2 ? (ScreenClass) new FirstScreenClass2( this.Game, this, true) : (ScreenClass) new CinematicsScreenClass( this.Game, this)) : (ScreenClass) new FirstScreenClass( this.Game, this);
      this.PaintScreeny();
      this.AutoScaleMode = AutoScaleMode.None;
      this.Timer1.Enabled = true;
      this.StartupPhase = 2;
      this.Cursor = Cursors.Default;
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    protected void OnPaintBackground(PaintEventArgs e)
    {
      if (this.StartupPhase >= 2)
        return;
      base.OnPaintBackground(e);
    }

    pub int GetMemorySize() =>  Math.Round((double) (32 * this.Width * this.Height) / 8000.0) + this.Screeny.GetMemorySize();

    pub void SuperImposeMessage(string texty, string texty2)
    {
      int num1 =  Math.Round((double) this.Game.RealScreenWidth / 2.0 - 185.0);
      int num2 =  Math.Round((double) this.Game.RealScreenHeight / 2.0 - 106.0);
      Graphics objgraphics = Graphics.FromHwnd(this.Handle);
       Graphics local1 =  objgraphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.Game.SE1_SUPERIMPOSEBACKGROUND);
       Bitmap local2 =  bitmap;
      int x = num1;
      int y = num2;
      DrawMod.DrawSimple( local1,  local2, x, y);
      if (texty.Length > 1)
      {
        DrawMod.DrawTextColouredConsoleCenter( objgraphics, texty, this.Game.MarcFont3, num1 + 185 + 1, num2 + 66 + 1, this.Game.seColBrown);
        DrawMod.DrawTextColouredConsoleCenter( objgraphics, texty, this.Game.MarcFont3, num1 + 185, num2 + 66, this.Game.seColWhite);
      }
      if (texty2.Length > 1)
      {
        DrawMod.DrawTextColouredConsoleCenter( objgraphics, texty2, this.Game.MarcFont4, num1 + 185 + 1, num2 + 116 + 1, this.Game.seColBrown);
        DrawMod.DrawTextColouredConsoleCenter( objgraphics, texty2, this.Game.MarcFont4, num1 + 185, num2 + 116, this.Game.seColWhite);
      }
      objgraphics.Dispose();
      this.Refresh();
    }

    protected void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (this.StartupPhase < 2 || this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      try
      {
        if (this.Screeny != null)
        {
          int num1 = e.ClipRectangle.Width > 0 ? 1 : 0;
          Rectangle clipRectangle = e.ClipRectangle;
          int num2 = clipRectangle.Height > 0 ? 1 : 0;
          if ((num1 & num2) != 0)
          {
            if (this.doubleSize)
            {
              Rectangle rect;
               Rectangle local =  rect;
              clipRectangle = e.ClipRectangle;
              int x =  Math.Round((double) ((float) clipRectangle.X * this.doubleModX));
              int y =  Math.Round((double) ((float) e.ClipRectangle.Y * this.doubleModY));
              int width =  Math.Round((double) ((float) e.ClipRectangle.Width * this.doubleModX));
              int height =  Math.Round((double) ((float) e.ClipRectangle.Height * this.doubleModY));
              local = new Rectangle(x, y, width, height);
              this.PaintScreeny(rect);
            }
            else
              this.PaintScreeny(e.ClipRectangle);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      this.Buisy = false;
    }

     void Form1_Mousedown(object sender, MouseEventArgs e)
    {
      if (this.StartupPhase < 2 || e.Button != MouseButtons.Left & e.Button != MouseButtons.Right || this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      if (SoundMod.NOSOUND && !Information.IsNothing((object) this.Game) && !Information.IsNothing((object) this.Game.EditObj) && !this.Game.EditObj.InEditor)
      {
        SoundMod.NOSOUND = false;
        SoundMod.RestartLastBackground( this.Game.EditObj);
      }
      int b;
      if (e.Button == MouseButtons.Left)
      {
        b = 1;
        this.MouseTime = DateAndTime.Now;
        this.MouseClicked = true;
        DrawMod.MouseClicked = true;
        this.RightMousePressed = false;
      }
      else if (e.Button == MouseButtons.Right)
      {
        b = 2;
        this.MouseClicked = false;
        DrawMod.MouseClicked = false;
        this.RightMousePressed = true;
      }
      int x1;
      int y1;
      if (this.windowsTxtFormPlease)
      {
        x1 = e.X;
        y1 = e.Y;
      }
      else
      {
        int x2 = e.X;
        Rectangle bounds = Screen.FromControl((Control) this).Bounds;
        int x3 = bounds.X;
        x1 = x2 - x3;
        int y2 = e.Y;
        bounds = Screen.FromControl((Control) this).Bounds;
        int y3 = bounds.Y;
        y1 = y2 - y3;
      }
      if (this.doubleSize)
      {
        x1 =  Math.Round((double) ((float) x1 * this.doubleModX));
        y1 =  Math.Round((double) ((float) y1 * this.doubleModY));
      }
      this.LastMouseX = x1;
      this.LastMouseY = y1;
      ScreenReturnClass screenReturnClass = this.Screeny.HandleMouseClick(x1, y1, b);
      if (screenReturnClass.NewScreen > 0)
      {
        if (screenReturnClass.OpenPopUp)
        {
          if (Information.IsNothing((object) this.StoredScreeny))
            this.StoredScreeny = this.Screeny;
        }
        else
        {
          this.Screeny.Dispose();
          this.Screeny = (ScreenClass) null;
        }
        if (screenReturnClass.NewScreen == 1 & DrawMod.TGame.ModIntroType != 0)
          screenReturnClass.NewScreen = 12;
        if (screenReturnClass.NewScreen == 24)
          this.Screeny = (ScreenClass) new ManagementScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 12)
          this.Screeny = (ScreenClass) new FirstScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 13)
          this.Screeny = (ScreenClass) new GameLoopScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 14)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 16)
          this.Screeny = (ScreenClass) new HistoryScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 15)
          this.Screeny = (ScreenClass) new SFScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 11)
          this.Screeny = (ScreenClass) new PlayScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 22)
          this.Screeny = (ScreenClass) new DynamicCinematicsScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 17)
          this.Screeny = (ScreenClass) new SimpleEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 25)
          this.Screeny = (ScreenClass) new SS_ScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 18)
          this.Screeny = (ScreenClass) new SimpleTroopTypeScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 19)
          this.Screeny = (ScreenClass) new SimpleHisScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 20)
          this.Screeny = (ScreenClass) new SimpleOfficerScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 21)
          this.Screeny = (ScreenClass) new SimpleMapScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 23)
          this.Screeny = (ScreenClass) new RandomScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 3)
          this.Screeny = (ScreenClass) new PlayScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 2)
          this.Screeny = (ScreenClass) new MainEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 1)
          this.Screeny = (ScreenClass) new FirstScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 4)
          this.Screeny = (ScreenClass) new GameLoopScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 5)
          this.Screeny = (ScreenClass) new CombatScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 6)
          this.Screeny = (ScreenClass) new HistoryScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 7)
          this.Screeny = (ScreenClass) new EventScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 8)
          this.Screeny = (ScreenClass) new SFScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 9)
          this.Screeny = (ScreenClass) new StatsScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 10)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass( this.Game, this);
        this.PaintScreeny();
        screenReturnClass.flag = false;
      }
      else if (screenReturnClass.ClosePopUp)
      {
        this.Screeny.Dispose();
        this.Screeny = (ScreenClass) null;
        this.Screeny = this.StoredScreeny;
        this.StoredScreeny = (ScreenClass) null;
        this.Game.EditObj.MapPopupMode = false;
        this.Game.EditObj.TempCoordList = CoordList::new();
        this.Game.EditObj.MyDelegate();
        if (this.Game.Data.Product >= 7 && !Information.IsNothing((object) this.Game.EditObj.MyDelegateMap))
          this.Game.EditObj.MyDelegateMap();
        this.Screeny.FlagAllIncludingRefresh();
        this.PaintScreeny();
        this.Buisy = false;
        this.Timer1_Tick(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
        return;
      }
      if (screenReturnClass.flag)
        this.PaintScreeny();
      Application.DoEvents();
      this.Buisy = false;
    }

     void Form1_Mouseup(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left & e.Button != MouseButtons.Right || this.StartupPhase < 2)
        return;
      if (this.Buisy)
      {
        int x;
        int y;
        if (this.windowsTxtFormPlease)
        {
          x = e.X;
          y = e.Y;
        }
        else
        {
          x = e.X - Screen.FromControl((Control) this).Bounds.X;
          y = e.Y - Screen.FromControl((Control) this).Bounds.Y;
        }
        if (this.doubleSize)
        {
          x =  Math.Round((double) ((float) x * this.doubleModX));
          y =  Math.Round((double) ((float) y * this.doubleModY));
        }
        if (!Information.IsNothing((object) this.Screeny))
          return;
        try
        {
          this.Screeny.HandleBLOCKEDMouseUp(x, y,  e.Button);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          e = e;
          ProjectData.ClearProjectError();
        }
      }
      else
      {
        this.Buisy = true;
        this.MouseClicked = false;
        DrawMod.MouseClicked = false;
        if (e.Button == MouseButtons.Right)
          this.RightMousePressed = false;
        int x;
        int y;
        if (this.windowsTxtFormPlease)
        {
          x = e.X;
          y = e.Y;
        }
        else
        {
          x = e.X - Screen.FromControl((Control) this).Bounds.X;
          y = e.Y - Screen.FromControl((Control) this).Bounds.Y;
        }
        if (this.doubleSize)
        {
          x =  Math.Round((double) ((float) x * this.doubleModX));
          y =  Math.Round((double) ((float) y * this.doubleModY));
        }
        this.LastMouseX = x;
        this.LastMouseY = y;
        ScreenReturnClass screenReturnClass = this.Screeny.HandleMouseUp(x, y,  e.Button);
        if (screenReturnClass.NewScreen > 0)
        {
          if (screenReturnClass.OpenPopUp)
          {
            if (Information.IsNothing((object) this.StoredScreeny))
              this.StoredScreeny = this.Screeny;
          }
          else
          {
            this.Screeny.Dispose();
            this.Screeny = (ScreenClass) null;
          }
          if (screenReturnClass.NewScreen == 1 & DrawMod.TGame.ModIntroType != 0)
            screenReturnClass.NewScreen = 12;
          if (screenReturnClass.NewScreen == 24)
            this.Screeny = (ScreenClass) new ManagementScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 12)
            this.Screeny = (ScreenClass) new FirstScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 13)
            this.Screeny = (ScreenClass) new GameLoopScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 14)
            this.Screeny = (ScreenClass) new MessagePopUpScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 16)
            this.Screeny = (ScreenClass) new HistoryScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 15)
            this.Screeny = (ScreenClass) new SFScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 11)
            this.Screeny = (ScreenClass) new PlayScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 17)
            this.Screeny = (ScreenClass) new SimpleEditScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 25)
            this.Screeny = (ScreenClass) new SS_ScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 18)
            this.Screeny = (ScreenClass) new SimpleTroopTypeScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 19)
            this.Screeny = (ScreenClass) new SimpleHisScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 20)
            this.Screeny = (ScreenClass) new SimpleOfficerScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 21)
            this.Screeny = (ScreenClass) new SimpleMapScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 22)
            this.Screeny = (ScreenClass) new DynamicCinematicsScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 23)
            this.Screeny = (ScreenClass) new RandomScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 3)
            this.Screeny = (ScreenClass) new PlayScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 2)
            this.Screeny = (ScreenClass) new MainEditScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 1)
            this.Screeny = (ScreenClass) new FirstScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 4)
            this.Screeny = (ScreenClass) new GameLoopScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 5)
            this.Screeny = (ScreenClass) new CombatScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 6)
            this.Screeny = (ScreenClass) new HistoryScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 7)
            this.Screeny = (ScreenClass) new EventScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 8)
            this.Screeny = (ScreenClass) new SFScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 9)
            this.Screeny = (ScreenClass) new StatsScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 10)
            this.Screeny = (ScreenClass) new MessagePopUpScreenClass( this.Game, this);
          this.PaintScreeny();
          screenReturnClass.flag = false;
        }
        else if (screenReturnClass.ClosePopUp)
        {
          this.Screeny.Dispose();
          this.Screeny = (ScreenClass) null;
          this.Screeny = this.StoredScreeny;
          this.StoredScreeny = (ScreenClass) null;
          this.Game.EditObj.MapPopupMode = false;
          this.Game.EditObj.TempCoordList = CoordList::new();
          this.Game.EditObj.MyDelegate();
          this.Screeny.FlagAllIncludingRefresh();
          this.PaintScreeny();
          this.Buisy = false;
          this.Timer1_Tick(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
          return;
        }
        if (screenReturnClass.flag)
          this.PaintScreeny();
        this.Buisy = false;
      }
    }

     void Form1_mouseleave(object sender, EventArgs e)
    {
      if (this.StartupPhase < 2)
        return;
      DrawMod.MouseClicked = false;
    }

     void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      this.CheckMouseMove = 0;
      int x1;
      int y1;
      if (this.windowsTxtFormPlease)
      {
        x1 = e.X;
        y1 = e.Y;
      }
      else
      {
        x1 = e.X - Screen.FromControl((Control) this).Bounds.X;
        y1 = e.Y - Screen.FromControl((Control) this).Bounds.Y;
      }
      if (this.doubleSize)
      {
        x1 =  Math.Round((double) ((float) x1 * this.doubleModX));
        y1 =  Math.Round((double) ((float) y1 * this.doubleModY));
      }
      if (this.StartupPhase < 2)
        return;
      if (Information.IsNothing((object) this.LastTipText))
        this.LastTipText = "";
      if (Information.IsNothing((object) this.Game.EditObj.TipText))
        this.Game.EditObj.TipText = "";
      if (Operators.CompareString(this.LastTipText, this.Game.EditObj.TipText, false) != 0 & this.Game.EditObj.MouseOverVisible)
      {
        this.CheckMouseMove = 0;
        this.Game.EditObj.MouseOverVisible = false;
        this.LastTipText = this.Game.EditObj.TipText;
        this.LastTipTextX = x1;
        this.LastTipTextY = y1;
      }
      else if (!(Math.Abs(this.LastTipTextX - this.LastMouseX) < 20 & Math.Abs(this.LastTipTextY - this.LastMouseY) < 20) & (this.LastTipTextX > 0 | this.LastTipTextY > 0))
      {
        this.Game.EditObj.MouseOverVisible = false;
        this.CheckMouseMove = 0;
        this.LastTipTextX = x1;
        this.LastTipTextY = y1;
      }
      if (this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      this.Game.EditObj.MouseOverX = -1;
      this.Game.EditObj.MouseOverY = -1;
      this.LastMouseX = x1;
      this.LastMouseY = y1;
      if (this.Screeny.HandleMouseMove(x1, y1).flag)
        this.PaintScreeny();
      this.Buisy = false;
      Rectangle rectangle;
      if (this.Game.EditObj.mouseScreenLock)
      {
        this.currentlyInMouseLock = true;
        int num1 = this.hasFocus ? 1 : 0;
        int x2 = Cursor.Clip.X;
        Rectangle bounds1 = this.Bounds;
        int x3 = bounds1.X;
        int num2 = x2 == x3 ? 1 : 0;
        int y2 = Cursor.Clip.Y;
        Rectangle bounds2 = this.Bounds;
        int y3 = bounds2.Y;
        int num3 = y2 == y3 ? 1 : 0;
        int num4 = (num2 & num3 & (this.Bounds.Width == Cursor.Clip.Width ? 1 : 0) & (this.Bounds.Height == Cursor.Clip.Height ? 1 : 0)) == 0 ? 1 : 0;
        if ((num1 & num4) != 0)
        {
          Cursor.Clip = this.Bounds;
        }
        else
        {
          if (Information.IsNothing((object) Cursor.Clip))
            return;
          int num5 = !this.hasFocus ? 1 : 0;
          int num6 = Cursor.Clip.X == Screen.PrimaryScreen.Bounds.X & Cursor.Clip.Y == Screen.PrimaryScreen.Bounds.Y ? 1 : 0;
          bounds2 = Screen.PrimaryScreen.Bounds;
          int num7 = bounds2.Width == Cursor.Clip.Width ? 1 : 0;
          int num8 = num6 & num7;
          bounds1 = Screen.PrimaryScreen.Bounds;
          int num9 = bounds1.Height == Cursor.Clip.Height ? 1 : 0;
          int num10 = (num8 & num9) == 0 ? 1 : 0;
          if ((num5 & num10) == 0)
            return;
          Cursor.Clip = rectangle;
        }
      }
      else
      {
        if (!this.currentlyInMouseLock)
          return;
        this.currentlyInMouseLock = false;
        if (Information.IsNothing((object) Cursor.Clip))
          return;
        Cursor.Clip = rectangle;
      }
    }

     void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
      e.Handled = true;
      if (this.StartupPhase < 2)
        return;
      bool flag = false;
      if (e.KeyChar >= '0' & e.KeyChar <= '9')
        flag = true;
      if (e.KeyChar >= 'A' & e.KeyChar <= 'Z')
        flag = true;
      if (e.KeyChar >= 'a' & e.KeyChar <= 'z')
        flag = true;
      if (e.KeyChar >= '\u0080' & e.KeyChar <= '¥')
        flag = true;
      if (e.KeyChar == '\b' | e.KeyChar == ' ')
        flag = true;
      if (e.KeyChar == '@' | e.KeyChar == '_')
        flag = true;
      if (e.KeyChar == '.' | e.KeyChar == '.')
        flag = true;
      if (!flag)
        return;
      this.Game.EditObj.TextInputString += Conversions.ToString(e.KeyChar);
    }

     void Form1_Keydown(object sender, KeyEventArgs e)
    {
      if (this.StartupPhase < 2 || this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      this += 1.TempKeyTest;
      if (this.TempKeyTest == 2)
        this.TempKeyTest = this.TempKeyTest;
      ScreenReturnClass screenReturnClass = this.Screeny.HandleKeyPress( Math.Round(Conversion.Val((object) e.KeyValue)));
      if (screenReturnClass.NewScreen > 0)
      {
        if (screenReturnClass.OpenPopUp)
        {
          if (Information.IsNothing((object) this.StoredScreeny))
            this.StoredScreeny = this.Screeny;
        }
        else
        {
          this.Screeny.Dispose();
          this.Screeny = (ScreenClass) null;
        }
        if (screenReturnClass.NewScreen == 1 & DrawMod.TGame.ModIntroType != 0)
          screenReturnClass.NewScreen = 12;
        if (screenReturnClass.NewScreen == 24)
          this.Screeny = (ScreenClass) new ManagementScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 12)
          this.Screeny = (ScreenClass) new FirstScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 13)
          this.Screeny = (ScreenClass) new GameLoopScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 14)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 16)
          this.Screeny = (ScreenClass) new HistoryScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 15)
          this.Screeny = (ScreenClass) new SFScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 11)
          this.Screeny = (ScreenClass) new PlayScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 17)
          this.Screeny = (ScreenClass) new SimpleEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 25)
          this.Screeny = (ScreenClass) new SS_ScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 18)
          this.Screeny = (ScreenClass) new SimpleTroopTypeScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 19)
          this.Screeny = (ScreenClass) new SimpleHisScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 20)
          this.Screeny = (ScreenClass) new SimpleOfficerScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 21)
          this.Screeny = (ScreenClass) new SimpleMapScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 22)
          this.Screeny = (ScreenClass) new DynamicCinematicsScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 23)
          this.Screeny = (ScreenClass) new RandomScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 3)
          this.Screeny = (ScreenClass) new PlayScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 2)
          this.Screeny = (ScreenClass) new MainEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 1)
          this.Screeny = (ScreenClass) new FirstScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 4)
          this.Screeny = (ScreenClass) new GameLoopScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 5)
          this.Screeny = (ScreenClass) new CombatScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 6)
          this.Screeny = (ScreenClass) new HistoryScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 7)
          this.Screeny = (ScreenClass) new EventScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 8)
          this.Screeny = (ScreenClass) new SFScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 9)
          this.Screeny = (ScreenClass) new StatsScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 10)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass( this.Game, this);
        this.PaintScreeny();
        screenReturnClass.flag = false;
      }
      else if (screenReturnClass.ClosePopUp)
      {
        this.Screeny.Dispose();
        this.Screeny = (ScreenClass) null;
        this.Screeny = this.StoredScreeny;
        this.StoredScreeny = (ScreenClass) null;
        this.Game.EditObj.MapPopupMode = false;
        this.Game.EditObj.TempCoordList = CoordList::new();
        this.Game.EditObj.MyDelegate();
        this.Screeny.FlagAllIncludingRefresh();
        this.PaintScreeny();
        this.Buisy = false;
        this.Timer1_Tick(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
        return;
      }
      if (screenReturnClass.flag)
        this.PaintScreeny();
      this.Buisy = false;
    }

     void Form1_Keyup(object sender, KeyEventArgs e)
    {
      if (this.StartupPhase < 2 || this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      ScreenReturnClass screenReturnClass = this.Screeny.HandleKeyup( Math.Round(Conversion.Val((object) e.KeyValue)));
      if (screenReturnClass.NewScreen > 0)
      {
        if (screenReturnClass.OpenPopUp)
        {
          if (Information.IsNothing((object) this.StoredScreeny))
            this.StoredScreeny = this.Screeny;
        }
        else
        {
          this.Screeny.Dispose();
          this.Screeny = (ScreenClass) null;
        }
        if (screenReturnClass.NewScreen == 1 & DrawMod.TGame.ModIntroType != 0)
          screenReturnClass.NewScreen = 12;
        if (screenReturnClass.NewScreen == 24)
          this.Screeny = (ScreenClass) new ManagementScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 12)
          this.Screeny = (ScreenClass) new FirstScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 13)
          this.Screeny = (ScreenClass) new GameLoopScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 14)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 16)
          this.Screeny = (ScreenClass) new HistoryScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 15)
          this.Screeny = (ScreenClass) new SFScreenClass2( this.Game, this, true);
        if (screenReturnClass.NewScreen == 11)
          this.Screeny = (ScreenClass) new PlayScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 17)
          this.Screeny = (ScreenClass) new SimpleEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 25)
          this.Screeny = (ScreenClass) new SS_ScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 18)
          this.Screeny = (ScreenClass) new SimpleTroopTypeScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 19)
          this.Screeny = (ScreenClass) new SimpleHisScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 20)
          this.Screeny = (ScreenClass) new SimpleOfficerScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 21)
          this.Screeny = (ScreenClass) new SimpleMapScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 22)
          this.Screeny = (ScreenClass) new DynamicCinematicsScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 23)
          this.Screeny = (ScreenClass) new RandomScreenClass2( this.Game, this);
        if (screenReturnClass.NewScreen == 3)
          this.Screeny = (ScreenClass) new PlayScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 2)
          this.Screeny = (ScreenClass) new MainEditScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 1)
          this.Screeny = (ScreenClass) new FirstScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 4)
          this.Screeny = (ScreenClass) new GameLoopScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 5)
          this.Screeny = (ScreenClass) new CombatScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 6)
          this.Screeny = (ScreenClass) new HistoryScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 7)
          this.Screeny = (ScreenClass) new EventScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 8)
          this.Screeny = (ScreenClass) new SFScreenClass( this.Game, this);
        if (screenReturnClass.NewScreen == 9)
          this.Screeny = (ScreenClass) new StatsScreenClass( this.Game);
        if (screenReturnClass.NewScreen == 10)
          this.Screeny = (ScreenClass) new MessagePopUpScreenClass( this.Game, this);
        this.PaintScreeny();
        screenReturnClass.flag = false;
      }
      else if (screenReturnClass.ClosePopUp)
      {
        this.Screeny.Dispose();
        this.Screeny = (ScreenClass) null;
        this.Screeny = this.StoredScreeny;
        this.StoredScreeny = (ScreenClass) null;
        this.Game.EditObj.MapPopupMode = false;
        this.Game.EditObj.TempCoordList = CoordList::new();
        this.Game.EditObj.MyDelegate();
        this.Screeny.FlagAllIncludingRefresh();
        this.PaintScreeny();
        this.Buisy = false;
        this.Timer1_Tick(RuntimeHelpers.GetObjectValue(sender), (EventArgs) e);
        return;
      }
      if (screenReturnClass.flag)
        this.PaintScreeny();
      this.Buisy = false;
    }

    pub void DoRefresh()
    {
      if (this.StartupPhase < 2 || this.Buisy || Conversions.ToBoolean(this.OnlyTimerCall()))
        return;
      this.Buisy = true;
      this.Screeny.DoRefresh();
      this.PaintScreeny();
      this.Buisy = false;
    }

    pub object OnlyTimerCall() => (object) false;

     void Form1_MouseWheel(object sender, MouseEventArgs e)
    {
      if (this.StartupPhase < 2 || this.Buisy)
        return;
      if (e.Delta > 0)
      {
        if (this.Game.EditObj.MouseWheel < 0)
          this.Game.EditObj.MouseWheel = 0;
        this += 1.Game.EditObj.MouseWheel;
      }
      else
      {
        if (e.Delta >= 0)
          return;
        if (this.Game.EditObj.MouseWheel > 0)
          this.Game.EditObj.MouseWheel = 0;
        --this.Game.EditObj.MouseWheel;
      }
    }

     void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Interval = 50;
      this.debugPoint2 = 1;
      this.debugPoint3 = 1;
      if (!Information.IsNothing((object) this.Game) && !Information.IsNothing((object) this.Game.Data) && this.Game.Data.Turn > -1 && this.Game.Data.DontShowAIMove && this.Game.Data.RegimeCounter >= this.Game.Data.Turn && this.Game.Data.RegimeObj[this.Game.Data.Turn].AI)
        this.Timer1.Interval = 250;
      if (this.StartupPhase < 2)
      {
        if (this.FullScreen)
          this.WindowState = FormWindowState.Maximized;
        this.Bounds = Screen.PrimaryScreen.Bounds;
      }
      this.debugPoint2 = 2;
      this.debugPoint3 = 2;
      if (this.StartupPhase == 0)
      {
        this.StartupPhase = 1;
        this.Startup();
      }
      else
      {
        if (this.StartupPhase < 2)
          return;
        this += 1.CollectCount;
        --this.Game.EditObj.MouseWheelWait;
        if (0 > this.Game.EditObj.MouseWheelWait)
          this.Game.EditObj.MouseWheelWait = 0;
        this.debugPoint2 = 3;
        this.debugPoint3 = 3;
        if (this.Buisy)
          return;
        this.Buisy = true;
        this.lastTimerTime = DateAndTime.Now;
        this.debugPoint2 = 4;
        this.debugPoint3 = 4;
        SoundMod.dssTimer( this.Game.EditObj);
        if (!this.Game.EditObj.MouseOverVisible & this.Game.EditObj.ShowMouseOver)
        {
          this += 1.CheckMouseMove;
          if (this.CheckMouseMove > 6)
            this.Game.EditObj.MouseOverVisible = true;
        }
        this.debugPoint2 = 5;
        this.debugPoint3 = 5;
        tipText: String = this.Game.EditObj.TipText;
        this.Screeny.HandleTooltip(this.LastMouseX, this.LastMouseY);
        if (!Information.IsNothing((object) this.Game.EditObj.TipText) && Operators.CompareString(this.Game.EditObj.TipText, this.LastTipText, false) != 0)
        {
          this.LastTipText = this.Game.EditObj.TipText;
          this.LastTipTextX = this.LastMouseX;
          this.LastTipTextY = this.LastMouseY;
        }
        if (this.Game.EditObj.CounterAlpha2 < 1)
        {
          if (this.Game.EditObj.CounterAlpha < 128)
            this.Game.EditObj.CounterAlpha =  sbyte.MaxValue;
          this.Game.EditObj.CounterAlpha += 32;
          if (this.Game.EditObj.CounterAlpha >  byte.MaxValue)
          {
            this.Game.EditObj.CounterAlpha =  byte.MaxValue;
            this.Game.EditObj.CounterAlpha2 = 1;
          }
        }
        else
        {
          this.Game.EditObj.CounterAlpha -= 32;
          if (this.Game.EditObj.CounterAlpha < 128)
          {
            this.Game.EditObj.CounterAlpha =  sbyte.MaxValue;
            this.Game.EditObj.CounterAlpha2 = 0;
          }
        }
        int num1;
        int num2;
        if (this.FullScreen)
        {
          num1 = Cursor.Position.X - this.Bounds.X;
          num2 = Cursor.Position.Y - this.Bounds.Y;
        }
        else
        {
          num1 = Cursor.Position.X - this.Bounds.X;
          num2 = Cursor.Position.Y - this.Bounds.Y;
        }
        this.debugPoint2 = 6;
        this.debugPoint3 = 6;
        if (this.FullScreen & this.hasFocus)
        {
          int num3 = 1;
          if (this.doubleSize)
          {
            num1 =  Math.Round((double) ((float) num1 * this.doubleModX));
            num2 =  Math.Round((double) ((float) num2 * this.doubleModY));
            if ((double) this.doubleModX >= 2.0)
              num3 =  Math.Round((double) this.doubleModX);
          }
          if (this.FullScreen)
          {
            this.Game.EditObj.ScrollDir = 0;
            int num4 = 310;
            if (this.Game.EditObj.GuiDown)
              num4 = 90;
            if (num1 >= this.Game.ScreenWidth - num3 & num2 < this.Game.ScreenHeight - num4)
              this.Game.EditObj.ScrollDir = 2;
            if (num2 >= this.Game.ScreenHeight - num3)
              this.Game.EditObj.ScrollDir = 3;
            if (num2 <= 1)
              this.Game.EditObj.ScrollDir = 1;
            if (num1 <= 1 & num2 < this.Game.ScreenHeight - num4)
              this.Game.EditObj.ScrollDir = 4;
          }
          else
          {
            this.Game.EditObj.ScrollDir = 0;
            if (num1 >= this.Game.ScreenWidth - num3)
              this.Game.EditObj.ScrollDir = 2;
            if (num2 >= this.Game.ScreenHeight - num3)
              this.Game.EditObj.ScrollDir = 3;
            if (num2 <= 1)
              this.Game.EditObj.ScrollDir = 1;
            if (num1 <= 1)
              this.Game.EditObj.ScrollDir = 4;
          }
        }
        else
          this.Game.EditObj.ScrollDir = 0;
        ScreenReturnClass screenReturnClass = this.Screeny.HandleTimerWheel(this.LastMouseX, this.LastMouseY);
        this.debugPoint2 = 7;
        this.debugPoint3 = 7;
        if (!screenReturnClass.flag)
        {
          if (this.Game.EditObj.ScrollDir > 0)
          {
            this.Timer1.Interval = 1;
            if (this.Game.Data.Product >= 6)
              this.Timer1.Interval = 15;
          }
          this.lastTimerTime_DebugPoint1 = DateAndTime.Now;
          this.debugPoint2 = 8;
          this.debugPoint3 = 8;
          screenReturnClass = this.Screeny.HandleTimer();
          this.debugPoint2 = 9;
          this.debugPoint3 = 9;
        }
        if (screenReturnClass.NewScreen <= 0 & !screenReturnClass.ClosePopUp & Operators.CompareString(tipText, this.Game.EditObj.TipText, false) != 0)
        {
          this.LastTipX = this.LastMouseX;
          this.LastTipY = this.LastMouseY;
          if (this.Game.EmpireStyle)
          {
            this.tempOnlyToolTip = true;
            this.PaintScreeny();
            this.tempOnlyToolTip = false;
          }
          else
          {
            this.Screeny.FlagAll();
            screenReturnClass.flag = true;
          }
        }
        if (screenReturnClass.NewScreen > 0)
        {
          if (screenReturnClass.OpenPopUp)
          {
            this.StoredScreeny = this.Screeny;
          }
          else
          {
            this.Screeny.Dispose();
            this.Screeny = (ScreenClass) null;
          }
          if (screenReturnClass.NewScreen == 1 & DrawMod.TGame.ModIntroType != 0)
            screenReturnClass.NewScreen = 12;
          if (screenReturnClass.NewScreen == 24)
            this.Screeny = (ScreenClass) new ManagementScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 12)
            this.Screeny = (ScreenClass) new FirstScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 13)
            this.Screeny = (ScreenClass) new GameLoopScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 14)
            this.Screeny = (ScreenClass) new MessagePopUpScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 16)
            this.Screeny = (ScreenClass) new HistoryScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 15)
            this.Screeny = (ScreenClass) new SFScreenClass2( this.Game, this, true);
          if (screenReturnClass.NewScreen == 11)
            this.Screeny = (ScreenClass) new PlayScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 17)
            this.Screeny = (ScreenClass) new SimpleEditScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 25)
            this.Screeny = (ScreenClass) new SS_ScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 18)
            this.Screeny = (ScreenClass) new SimpleTroopTypeScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 19)
            this.Screeny = (ScreenClass) new SimpleHisScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 20)
            this.Screeny = (ScreenClass) new SimpleOfficerScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 21)
            this.Screeny = (ScreenClass) new SimpleMapScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 22)
            this.Screeny = (ScreenClass) new DynamicCinematicsScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 23)
            this.Screeny = (ScreenClass) new RandomScreenClass2( this.Game, this);
          if (screenReturnClass.NewScreen == 3)
            this.Screeny = (ScreenClass) new PlayScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 2)
            this.Screeny = (ScreenClass) new MainEditScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 1)
            this.Screeny = (ScreenClass) new FirstScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 4)
            this.Screeny = (ScreenClass) new GameLoopScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 5)
            this.Screeny = (ScreenClass) new CombatScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 6)
            this.Screeny = (ScreenClass) new HistoryScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 7)
            this.Screeny = (ScreenClass) new EventScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 8)
            this.Screeny = (ScreenClass) new SFScreenClass( this.Game, this);
          if (screenReturnClass.NewScreen == 9)
            this.Screeny = (ScreenClass) new StatsScreenClass( this.Game);
          if (screenReturnClass.NewScreen == 10)
            this.Screeny = (ScreenClass) new MessagePopUpScreenClass( this.Game, this);
          this.PaintScreeny();
          screenReturnClass.flag = false;
        }
        else if (screenReturnClass.ClosePopUp)
        {
          this.Screeny.Dispose();
          this.Screeny = (ScreenClass) null;
          this.Screeny = this.StoredScreeny;
          this.StoredScreeny = (ScreenClass) null;
          this.Game.EditObj.MapPopupMode = false;
          this.Game.EditObj.TempCoordList = CoordList::new();
          this.Game.EditObj.MyDelegate();
          this.Screeny.FlagAllIncludingRefresh();
          this.PaintScreeny();
          this.Buisy = false;
          this.Timer1_Tick(RuntimeHelpers.GetObjectValue(sender), e);
          return;
        }
        if (screenReturnClass.flag)
          this.PaintScreeny();
        this.Buisy = false;
      }
    }

    pub void PaintScreeny()
    {
      if (!this.hasFocus & this.Game.noDrawNoFocus)
        return;
      if (this.doubleSize)
        this.PaintScreeny(new Rectangle(0, 0,  Math.Round((double) ((float) this.Width * this.doubleModX)),  Math.Round((double) ((float) this.Height * this.doubleModY))));
      else
        this.PaintScreeny(new Rectangle(0, 0, this.Width, this.Height));
    }

     void Form1_GotFocus(object sender, EventArgs e)
    {
      this.hasFocus = true;
      if (this.StartupPhase < 2)
        return;
      if (SoundMod.NOSOUND && !Information.IsNothing((object) this.Game) && !Information.IsNothing((object) this.Game.EditObj) && !this.Game.EditObj.InEditor)
      {
        SoundMod.NOSOUND = false;
        SoundMod.RestartLastBackground( this.Game.EditObj);
      }
      if (this.Buisy)
        return;
      this.Buisy = true;
      this.PaintScreeny();
      this.Buisy = false;
    }

     void Form1_LostFocus(object sender, EventArgs e)
    {
      this.hasFocus = false;
      if (this.StartupPhase < 2 || this.Game.EditObj.systemPopup || SoundMod.NOSOUND)
        return;
      SoundMod.STopEventBackground();
      SoundMod.STopEventWave();
      SoundMod.NOSOUND = true;
    }

    pub void PaintScreeny(Rectangle rect)
    {
      if (!this.Screeny.HasOwnBitmap() || !this.hasFocus & this.Game.noDrawNoFocus)
        return;
      if (DrawMod.TGame.EditObj.highGfxSpeedOn)
      {
        if (this.doubleSize)
        {
          Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
          bool flag = false;
          if (Information.IsNothing((object) this.sbmp))
            flag = true;
          else if (!(this.sbmp.Width == this.Width & this.sbmp.Height == this.Height))
            flag = true;
          if (flag)
            this.sbmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
          if (DrawMod.TGame.EditObj.DoubleSizePercentage == 200 & bitmap.Width % 2 == 0 & bitmap.Height % 2 == 0)
          {
            DrawMod.CopyPerLine_DOUBLE( bitmap,  this.sbmp, 0, 0, bitmap.Width, bitmap.Height, 0, 0);
          }
          else
          {
            Graphics objGraphics = Graphics.FromImage((Image) this.sbmp);
            objGraphics.CompositingMode = CompositingMode.SourceCopy;
            objGraphics.CompositingQuality = CompositingQuality.HighSpeed;
            objGraphics.SmoothingMode = SmoothingMode.None;
            objGraphics.PixelOffsetMode = PixelOffsetMode.None;
            objGraphics.InterpolationMode = InterpolationMode.Bilinear;
            if (DrawMod.TGame.EditObj.DoubleSizePercentage == 75)
              objGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawMod.DrawSimplePart2( objGraphics,  bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height), new Rectangle(0, 0, this.Width, this.Height));
            objGraphics.Dispose();
          }
           Bitmap local1 =  this.sbmp;
          Form form =  this;
           Form local2 =  form;
          DrawMod.CopyToForm2( local1,  local2);
        }
        else if (!(rect.X == 0 & rect.Y == 0 & rect.Width == this.Width & rect.Height == this.Height))
        {
          Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
           Bitmap local3 =  bitmap;
          Form form =  this;
           Form local4 =  form;
          Rectangle rect1 = rect;
          DrawMod.CopyToForm2rect( local3,  local4, rect1);
        }
        else
        {
          Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
           Bitmap local5 =  bitmap;
          Form form =  this;
           Form local6 =  form;
          DrawMod.CopyToForm2( local5,  local6);
        }
      }
      else
      {
        Graphics graphics = Graphics.FromHwnd(this.Handle);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighSpeed;
        graphics.SmoothingMode = SmoothingMode.None;
        graphics.PixelOffsetMode = PixelOffsetMode.None;
        if (this.doubleSize)
        {
          graphics.InterpolationMode = InterpolationMode.Bilinear;
           Graphics local7 =  graphics;
          Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
           Bitmap local8 =  bitmap;
          Rectangle srcrect = rect;
          Rectangle destrect = new Rectangle( Math.Round((double) ((float) rect.X / this.doubleModX)),  Math.Round((double) ((float) rect.Y / this.doubleModY)),  Math.Round((double) ((float) rect.Width / this.doubleModX)),  Math.Round((double) ((float) rect.Height / this.doubleModY)));
          DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
        }
        else
        {
          graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
          if (!(rect.X == 0 & rect.Y == 0 & rect.Width == this.Width & rect.Height == this.Height))
          {
             Graphics local9 =  graphics;
            Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
             Bitmap local10 =  bitmap;
            Rectangle rect2 = rect;
            DrawMod.DrawSimplePart( local9,  local10, rect2);
          }
          else if (DrawMod.TGame.EditObj.highGfxSpeedOn)
          {
            Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
             Bitmap local11 =  bitmap;
            Form form =  this;
             Form local12 =  form;
            DrawMod.CopyToForm2( local11,  local12);
          }
          else
          {
             Graphics local13 =  graphics;
            Bitmap bitmap = this.Screeny.Paint(this.tempOnlyToolTip);
             Bitmap local14 =  bitmap;
            DrawMod.DrawSimple( local13,  local14, 0, 0);
          }
        }
        graphics.CompositingMode = CompositingMode.SourceOver;
        graphics.Dispose();
        graphics = (Graphics) null;
      }
    }

    ~Form1() => base.Finalize();

     void Form1_Paint(object sender, PaintEventArgs e)
    {
    }
  }
}
