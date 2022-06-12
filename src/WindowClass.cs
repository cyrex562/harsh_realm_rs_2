// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.WindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class WindowClass
  {
    public SubPartClass[] SubPartList;
    protected int SubPartCounter;
    protected int SubPartIDCounter;
    protected int[] SubPartX;
    protected int[] SubPartY;
    protected int[] SubPartW;
    protected int[] SubPartH;
    protected int[] SubPartID;
    protected int[] SubPartOverlay;
    protected bool[] SubPartFlag;
    public Bitmap OwnBitmap;
    public Bitmap BackBitmap;
    public string HeaderString;
    public Color BackColor;
    public Color BackColor2;
    private bool NoPartDraw;
    private bool DoGradient;
    private int DoBorders;
    private int LastOverlaySubPart;
    public GameClass game;
    protected bool mapframe;
    protected bool downframe;
    protected bool mainframe;
    protected bool extrabackground;
    public Form1 formref;
    public bool fixshade;
    public bool shade;
    public Bitmap screenbackref;
    public int screenx;
    public int screeny;
    public int screenw;
    public int screenh;
    public bool useparentscreenbitmap;
    public bool backspritescaled;
    public bool transbacksprite;
    public WindowClass LowerWindow;
    public Rectangle LowerRect;
    public Rectangle ShowRect;
    public bool DoShowRect;
    public Rectangle[] MouseRect;
    public int MouseCounter;
    public string[] MouseText;
    public string[] MouseTitle;
    public int[] MouseData;
    public int[] MouseData2;
    public bool BlockBlit;
    public bool MouseInThisWindow;
    public bool NewGfx;
    public Rectangle[] QuickRect;
    public bool QuickDrawMode;
    public int QuickRectCount;
    public int QuickRectMax;
    public OrderResult form3_orderResult;
    public bool form3_returnInstruction;
    public int form3_data1;
    public int form3_data2;

    public void ClearMouse() => this.MouseCounter = -1;

    public void AddQuickRect(Rectangle trect)
    {
      if (this.QuickRectCount >= this.QuickRectMax)
      {
        this.QuickDrawMode = false;
      }
      else
      {
        ++this.QuickRectCount;
        this.QuickRect[this.QuickRectCount] = trect;
        this.QuickDrawMode = true;
      }
    }

    public void ResetQuickRect()
    {
      this.QuickDrawMode = false;
      this.QuickRectCount = -1;
    }

    public void AddMouse(ref Rectangle trect, string ttitle, string ttext, int tdata = -1, int tdata2 = -1)
    {
      ++this.MouseCounter;
      this.MouseRect = (Rectangle[]) Utils.CopyArray((Array) this.MouseRect, (Array) new Rectangle[this.MouseCounter + 1]);
      this.MouseText = (string[]) Utils.CopyArray((Array) this.MouseText, (Array) new string[this.MouseCounter + 1]);
      this.MouseTitle = (string[]) Utils.CopyArray((Array) this.MouseTitle, (Array) new string[this.MouseCounter + 1]);
      this.MouseData = (int[]) Utils.CopyArray((Array) this.MouseData, (Array) new int[this.MouseCounter + 1]);
      this.MouseData2 = (int[]) Utils.CopyArray((Array) this.MouseData2, (Array) new int[this.MouseCounter + 1]);
      this.MouseRect[this.MouseCounter] = trect;
      this.MouseText[this.MouseCounter] = ttext;
      this.MouseTitle[this.MouseCounter] = ttitle;
      this.MouseData[this.MouseCounter] = tdata;
      this.MouseData2[this.MouseCounter] = tdata2;
    }

    public int GetMemorySize()
    {
      int memorySize = (int) Math.Round((double) (64 * this.OwnBitmap.Width * this.OwnBitmap.Height) / 8000.0);
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
        memorySize += this.SubPartList[index].GetMemorySize();
      return memorySize;
    }

    public int SubpartNr(int id)
    {
      if (this.SubPartCounter <= -1)
        return -1;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (this.SubPartID[index] == id)
          return index;
      }
      return -1;
    }

    public virtual void Dispose()
    {
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        this.SubPartList[index].Dispose();
        this.SubPartList[index] = (SubPartClass) null;
      }
      this.OwnBitmap.Dispose();
      this.OwnBitmap = (Bitmap) null;
      this.BackBitmap.Dispose();
      this.BackBitmap = (Bitmap) null;
      this.screenbackref = (Bitmap) null;
      this.game = (GameClass) null;
      this.LowerWindow = (WindowClass) null;
      GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
      Application.DoEvents();
    }

    public WindowClass(
      ref GameClass tGame,
      int w,
      int h,
      int backcolornr = -1,
      int BackSprite = -1,
      bool tBackSpriteScaled = false,
      int tDoBorders = 0,
      bool tDoGradient = true,
      string tHeaderString = "",
      bool tShade = true,
      Bitmap screenbitmap = null,
      int sx = -1,
      int sy = -1,
      bool tTransBacksprite = false)
    {
      this.QuickRect = new Rectangle[20];
      this.QuickDrawMode = false;
      this.QuickRectCount = -1;
      this.QuickRectMax = 19;
      this.MouseCounter = -1;
      this.QuickRectCount = -1;
      this.game = tGame;
      this.DoBorders = tDoBorders;
      this.DoGradient = tDoGradient;
      this.HeaderString = tHeaderString;
      this.transbacksprite = tTransBacksprite;
      this.backspritescaled = tBackSpriteScaled;
      this.screenbackref = screenbitmap;
      this.screenx = sx;
      this.screeny = sy;
      this.screenw = w;
      this.screenh = h;
      this.shade = tShade;
      if (backcolornr == 0)
      {
        this.BackColor = Color.FromArgb(14, 70, 140, (int) byte.MaxValue);
        this.BackColor2 = Color.FromArgb(14, 70, 140, (int) byte.MaxValue);
      }
      if (backcolornr == 1)
      {
        this.BackColor = Color.FromArgb(100, 150, 50, (int) byte.MaxValue);
        this.BackColor2 = Color.FromArgb(14, 70, 140, (int) byte.MaxValue);
      }
      if (backcolornr == 5 | backcolornr == -1)
      {
        this.BackColor = Color.FromArgb((int) byte.MaxValue, 10, 10, 10);
        this.BackColor2 = Color.FromArgb((int) byte.MaxValue, 40, 40, 70);
      }
      if (backcolornr == 6)
      {
        this.BackColor = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
        this.BackColor2 = Color.FromArgb(14, 70, 140, (int) byte.MaxValue);
      }
      if (backcolornr == 7)
      {
        this.BackColor = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
        this.BackColor2 = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
      }
      if (backcolornr == 8)
      {
        this.BackColor = Color.FromArgb(0, 0, 0, 0);
        this.BackColor2 = Color.FromArgb(0, 0, 0, 0);
      }
      if (this.game.Data.Product == 6)
      {
        if (backcolornr == 9)
        {
          this.BackColor = Color.FromArgb((int) byte.MaxValue, 60, 120, 60);
          this.BackColor2 = Color.FromArgb((int) byte.MaxValue, 120, 180, 120);
        }
      }
      else if (backcolornr == 9)
      {
        this.BackColor = Color.FromArgb((int) byte.MaxValue, 40, 80, 120);
        this.BackColor2 = Color.FromArgb((int) byte.MaxValue, 100, 140, 180);
      }
      this.BackBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
      this.BackBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) this.BackBitmap);
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (BackSprite == -1 | this.transbacksprite)
      {
        if (backcolornr == 99 & !Information.IsNothing((object) this.screenbackref))
        {
          ref Graphics local1 = ref graphics;
          ref Bitmap local2 = ref this.screenbackref;
          rectangle1 = new Rectangle(this.screenx, this.screeny, this.screenw, this.screenh);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 0, this.screenw, this.screenh);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
          this.useparentscreenbitmap = true;
        }
        else if (!this.DoGradient)
          DrawMod.DrawClear(graphics, ref this.BackBitmap, Color.FromArgb((int) this.BackColor.A, (int) this.BackColor.R, (int) this.BackColor.G, (int) this.BackColor.B));
        else
          DrawMod.DrawBlockGradient3(ref graphics, 0, 0, this.screenw, this.screenh, this.BackColor, this.BackColor2);
        if (Strings.Len(this.HeaderString) > 0)
        {
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          DrawMod.DrawBlock(ref graphics, 2, 2, w - 4, 38, 0, 0, 0, 128);
          SizeF sizeF = graphics.MeasureString(this.HeaderString, this.game.MarcFont1);
          DrawMod.DrawTextColouredMarc(ref graphics, this.HeaderString, this.game.MarcFont1, (int) Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0), (int) Math.Round(22.0 - (double) sizeF.Height / 2.0), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
        if (this.DoBorders > 0)
          DrawMod.DrawRectangle(ref graphics, 0, 0, w - 1, h - 1, 0, 0, 0, (int) byte.MaxValue);
      }
      if (BackSprite > -1)
      {
        if (!this.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceCopy;
        if (!this.backspritescaled)
        {
          if (BitmapStore.GetWidth(BackSprite) > w)
          {
            ref Graphics local3 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
            ref Bitmap local4 = ref bitmap;
            rectangle2 = new Rectangle((int) Math.Round((double) BitmapStore.GetWidth(BackSprite) / 2.0 - (double) w / 2.0), 0, w, h);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect, destrect);
          }
          else
          {
            ref Graphics local5 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
            ref Bitmap local6 = ref bitmap;
            DrawMod.DrawSimple(ref local5, ref local6, 0, 0);
          }
        }
        else
        {
          ref Graphics local7 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
          ref Bitmap local8 = ref bitmap;
          int w1 = w;
          int h1 = h;
          DrawMod.DrawScaled(ref local7, ref local8, 0, 0, w1, h1);
        }
        if (!this.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.OwnBitmap = (Bitmap) this.BackBitmap.Clone();
      this.SubPartCounter = -1;
      this.SubPartIDCounter = 0;
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
    }

    public void FlagAll()
    {
      if (this.SubPartCounter < 0)
        return;
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
        this.SubPartFlag[index] = true;
    }

    public Bitmap Paint()
    {
      if (Information.IsNothing((object) this.OwnBitmap))
      {
        if (Information.IsNothing((object) this.BackBitmap))
        {
          this.OwnBitmap = new Bitmap(this.screenw, this.screenh, PixelFormat.Format32bppPArgb);
          this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          Graphics.FromImage((Image) this.OwnBitmap).Clear(Color.Pink);
        }
        else
          this.OwnBitmap = (Bitmap) this.BackBitmap.Clone();
      }
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      int subPartCounter = this.SubPartCounter;
      Bitmap bitmap;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if ((!Information.IsNothing((object) this.LowerWindow) | this.BlockBlit) & !this.SubPartList[index].oldStyle)
        {
          if (this.SubPartFlag[index])
          {
            if (this.LastOverlaySubPart == this.SubPartID[index])
            {
              ref Graphics local1 = ref objGraphics;
              bitmap = this.SubPartList[index].PaintOverlay();
              ref Bitmap local2 = ref bitmap;
              ref Bitmap local3 = ref this.OwnBitmap;
              int x = this.SubPartX[index];
              int y = this.SubPartY[index];
              DrawMod.DrawSimpleFast(ref local1, ref local2, ref local3, x, y);
            }
            else
            {
              ref Graphics local4 = ref objGraphics;
              bitmap = this.SubPartList[index].Paint();
              ref Bitmap local5 = ref bitmap;
              ref Bitmap local6 = ref this.OwnBitmap;
              int x = this.SubPartX[index];
              int y = this.SubPartY[index];
              DrawMod.DrawSimpleFast(ref local4, ref local5, ref local6, x, y);
            }
            this.SubPartFlag[index] = false;
          }
        }
        else if (this.SubPartFlag[index])
        {
          if (this.LastOverlaySubPart == this.SubPartID[index])
          {
            ref Graphics local7 = ref objGraphics;
            bitmap = this.SubPartList[index].PaintOverlay();
            ref Bitmap local8 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local7, ref local8, x, y);
          }
          else
          {
            ref Graphics local9 = ref objGraphics;
            bitmap = this.SubPartList[index].Paint();
            ref Bitmap local10 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local9, ref local10, x, y);
          }
          this.SubPartFlag[index] = false;
        }
      }
      if (this.mapframe)
        DrawMod.DrawRectangle(ref objGraphics, 0, 0, this.OwnBitmap.Width - 1, this.OwnBitmap.Height - 1, 0, 0, 0, (int) byte.MaxValue);
      if (!Information.IsNothing((object) objGraphics))
        objGraphics.Dispose();
      return this.OwnBitmap;
    }

    public void PaintSpecific(int id)
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (id == this.SubPartID[index])
        {
          if (this.SubPartList[index].UseSourceCopyForPaintSpecific())
          {
            Expression.CompositingMode = CompositingMode.SourceCopy;
            ref Graphics local1 = ref Expression;
            Bitmap bitmap = this.SubPartList[index].Paint();
            ref Bitmap local2 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local1, ref local2, x, y);
            Expression.CompositingMode = CompositingMode.SourceOver;
          }
          else
          {
            ref Graphics local3 = ref Expression;
            Bitmap bitmap = this.SubPartList[index].Paint();
            ref Bitmap local4 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local3, ref local4, x, y);
          }
          this.AddQuickRect(new Rectangle(this.SubPartX[index], this.SubPartY[index], this.SubPartW[index], this.SubPartH[index]));
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public virtual void Before_DoRefresh_Called_By_FlagAllIncludingRefresh()
    {
    }

    public virtual void DoRefresh()
    {
    }

    public void PaintCurrentBitmap(int id)
    {
      Graphics Expression = Graphics.FromImage((Image) this.OwnBitmap);
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (id == this.SubPartID[index])
        {
          if (this.SubPartW[index] == this.OwnBitmap.Width & this.SubPartH[index] == this.OwnBitmap.Height & this.GetType().Equals(typeof (MapWindowClass)))
          {
            this.OwnBitmap.Dispose();
            this.OwnBitmap = (Bitmap) this.SubPartList[index].OwnBitmap.Clone();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Application.DoEvents();
          }
          else
          {
            ref Graphics local1 = ref Expression;
            Bitmap bitmap = this.SubPartList[index].Paint();
            ref Bitmap local2 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local1, ref local2, x, y);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    public void PaintCurrentBitmapScaled(int id)
    {
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (id == this.SubPartID[index])
          DrawMod.DrawScaled(ref objGraphics, ref this.SubPartList[index].OwnBitmap, this.SubPartX[index], this.SubPartY[index], this.SubPartW[index], this.SubPartH[index]);
      }
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
    }

    public Bitmap PaintSpecificOverlay(int id)
    {
      int subPartCounter = this.SubPartCounter;
      Graphics Expression;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (id == this.SubPartID[index])
        {
          Expression = Graphics.FromImage((Image) this.OwnBitmap);
          ref Graphics local1 = ref Expression;
          Bitmap bitmap = this.SubPartList[index].PaintOverlay();
          ref Bitmap local2 = ref bitmap;
          int x = this.SubPartX[index];
          int y = this.SubPartY[index];
          DrawMod.DrawSimple(ref local1, ref local2, x, y);
          this.AddQuickRect(new Rectangle(this.SubPartX[index], this.SubPartY[index], this.SubPartW[index], this.SubPartH[index]));
        }
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return this.OwnBitmap;
    }

    public bool MouseOverSpecific(int id)
    {
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (id == this.SubPartID[index] && (this.SubPartList[index].MouseOver | this.SubPartList[index].Scroller) & DrawMod.MouseClicked)
        {
          Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
          if (this.formref.doubleSize)
          {
            if (this.SubPartList[index].MouseMove((int) Math.Round((double) ((float) Cursor.Position.X * this.formref.doubleModX - (float) (this.SubPartX[index] + this.screenx))), (int) Math.Round((double) ((float) Cursor.Position.Y * this.formref.doubleModY - (float) (this.SubPartY[index] + this.screeny)))))
            {
              ref Graphics local1 = ref graphics;
              Bitmap bitmap = this.SubPartList[index].Paint();
              ref Bitmap local2 = ref bitmap;
              int x = this.SubPartX[index];
              int y = this.SubPartY[index];
              DrawMod.DrawSimple(ref local1, ref local2, x, y);
              return true;
            }
          }
          else if (this.SubPartList[index].MouseMove(Cursor.Position.X - (this.SubPartX[index] + this.screenx), Cursor.Position.Y - (this.SubPartY[index] + this.screeny)))
          {
            ref Graphics local3 = ref graphics;
            Bitmap bitmap = this.SubPartList[index].Paint();
            ref Bitmap local4 = ref bitmap;
            int x = this.SubPartX[index];
            int y = this.SubPartY[index];
            DrawMod.DrawSimple(ref local3, ref local4, x, y);
            return true;
          }
          return false;
        }
      }
      return false;
    }

    public int AddSubPart(ref SubPartClass tsubpart, int x, int y, int w, int h, int overlay)
    {
      ++this.SubPartCounter;
      ++this.SubPartIDCounter;
      this.SubPartList = (SubPartClass[]) Utils.CopyArray((Array) this.SubPartList, (Array) new SubPartClass[this.SubPartCounter + 1]);
      this.SubPartFlag = (bool[]) Utils.CopyArray((Array) this.SubPartFlag, (Array) new bool[this.SubPartCounter + 1]);
      this.SubPartX = (int[]) Utils.CopyArray((Array) this.SubPartX, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartY = (int[]) Utils.CopyArray((Array) this.SubPartY, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartW = (int[]) Utils.CopyArray((Array) this.SubPartW, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartH = (int[]) Utils.CopyArray((Array) this.SubPartH, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartID = (int[]) Utils.CopyArray((Array) this.SubPartID, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartOverlay = (int[]) Utils.CopyArray((Array) this.SubPartOverlay, (Array) new int[this.SubPartCounter + 1]);
      this.SubPartList[this.SubPartCounter] = tsubpart;
      this.SubPartFlag[this.SubPartCounter] = true;
      this.SubPartX[this.SubPartCounter] = x;
      this.SubPartY[this.SubPartCounter] = y;
      this.SubPartW[this.SubPartCounter] = w;
      this.SubPartH[this.SubPartCounter] = h;
      this.SubPartOverlay[this.SubPartCounter] = overlay;
      this.SubPartID[this.SubPartCounter] = this.SubPartIDCounter;
      return this.SubPartIDCounter;
    }

    public void NewBackGroundAndClearAll(int w, int h, int backsprite)
    {
      if (Information.IsNothing((object) this.BackBitmap))
      {
        this.BackBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
        this.BackBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      Graphics graphics = Graphics.FromImage((Image) this.BackBitmap);
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (backsprite == -1 | this.transbacksprite)
      {
        if (this.useparentscreenbitmap)
        {
          ref Graphics local1 = ref graphics;
          ref Bitmap local2 = ref this.screenbackref;
          rectangle1 = new Rectangle(this.screenx, this.screeny, this.screenw, this.screenh);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 0, this.screenw, this.screenh);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect, destrect);
        }
        else if (!Information.IsNothing((object) this.LowerWindow))
        {
          if (!Information.IsNothing((object) this.LowerWindow.SubPartList))
          {
            if (this.LowerWindow.GetType().Equals(typeof (MapWindowClass)) | this.LowerWindow.GetType().Equals(typeof (MapWindowClass2)))
            {
              ref Graphics local3 = ref graphics;
              ref Bitmap local4 = ref this.LowerWindow.SubPartList[0].OwnBitmap;
              Rectangle lowerRect = this.LowerRect;
              rectangle2 = new Rectangle(0, 0, w, h);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2(ref local3, ref local4, lowerRect, destrect);
            }
            else
            {
              ref Graphics local5 = ref graphics;
              ref Bitmap local6 = ref this.LowerWindow.OwnBitmap;
              Rectangle lowerRect = this.LowerRect;
              rectangle2 = new Rectangle(0, 0, w, h);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2(ref local5, ref local6, lowerRect, destrect);
            }
          }
          else if (!Information.IsNothing((object) this.LowerWindow))
          {
            ref Graphics local7 = ref graphics;
            ref Bitmap local8 = ref this.LowerWindow.OwnBitmap;
            Rectangle lowerRect = this.LowerRect;
            rectangle2 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2(ref local7, ref local8, lowerRect, destrect);
          }
        }
        else if (!this.DoGradient)
          DrawMod.DrawClear(graphics, ref this.BackBitmap, Color.FromArgb((int) this.BackColor.A, (int) this.BackColor.R, (int) this.BackColor.G, (int) this.BackColor.B));
        else
          DrawMod.DrawBlockGradient3(ref graphics, 0, 0, this.screenw, this.screenh, this.BackColor, this.BackColor2);
        if (Strings.Len(this.HeaderString) > 0)
        {
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          DrawMod.DrawBlock(ref graphics, 2, 2, w - 4, 38, 0, 0, 0, 128);
          SizeF sizeF = graphics.MeasureString(this.HeaderString, this.game.MarcFont1);
          DrawMod.DrawTextColouredMarc(ref graphics, this.HeaderString, this.game.MarcFont1, (int) Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0), (int) Math.Round(22.0 - (double) sizeF.Height / 2.0), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue));
        }
        if (this.DoBorders > 0)
          DrawMod.DrawRectangle(ref graphics, 0, 0, w - 1, h - 1, 0, 0, 0, (int) byte.MaxValue);
      }
      if (backsprite > -1)
      {
        if (!this.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceCopy;
        if (!this.backspritescaled)
        {
          if (BitmapStore.GetWidth(backsprite) > w)
          {
            ref Graphics local9 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
            ref Bitmap local10 = ref bitmap;
            rectangle2 = new Rectangle((int) Math.Round((double) BitmapStore.GetWidth(backsprite) / 2.0 - (double) w / 2.0), 0, w, h);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
          }
          else if (BitmapStore.GetWidth(backsprite) < w)
          {
            ref Graphics local11 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
            ref Bitmap local12 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(backsprite), BitmapStore.Getheight(backsprite));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
          }
          else
          {
            ref Graphics local13 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
            ref Bitmap local14 = ref bitmap;
            DrawMod.DrawSimple(ref local13, ref local14, 0, 0);
          }
        }
        else
        {
          ref Graphics local15 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
          ref Bitmap local16 = ref bitmap;
          int w1 = w;
          int h1 = h;
          DrawMod.DrawScaled(ref local15, ref local16, 0, 0, w1, h1);
        }
        if (!this.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (!Information.IsNothing((object) this.OwnBitmap))
      {
        if (!Information.IsNothing((object) graphics))
        {
          graphics.Dispose();
          graphics = (Graphics) null;
        }
        graphics = Graphics.FromImage((Image) this.OwnBitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) this.BackBitmap, 0, 0);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    public void RemoveSubPart(int id)
    {
      if (this.SubPartCounter <= -1)
        return;
      int subPartCounter1 = this.SubPartCounter;
      for (int index1 = 0; index1 <= subPartCounter1; ++index1)
      {
        if (this.SubPartID[index1] == id)
        {
          if (!Information.IsNothing((object) this.OwnBitmap))
          {
            Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
            Rectangle rect = new Rectangle(this.SubPartX[index1], this.SubPartY[index1], this.SubPartW[index1], this.SubPartH[index1]);
            DrawMod.DrawSimplePart(ref objGraphics, ref this.BackBitmap, rect);
          }
          if (this.LastOverlaySubPart == id)
            this.LastOverlaySubPart = 0;
          this.SubPartList[index1].Dispose();
          this.SubPartList[index1] = (SubPartClass) null;
          if (index1 != this.SubPartCounter)
          {
            int num = index1 + 1;
            int subPartCounter2 = this.SubPartCounter;
            for (int index2 = num; index2 <= subPartCounter2; ++index2)
            {
              this.SubPartList[index2 - 1] = this.SubPartList[index2];
              this.SubPartFlag[index2 - 1] = this.SubPartFlag[index2];
              this.SubPartX[index2 - 1] = this.SubPartX[index2];
              this.SubPartY[index2 - 1] = this.SubPartY[index2];
              this.SubPartW[index2 - 1] = this.SubPartW[index2];
              this.SubPartOverlay[index2 - 1] = this.SubPartOverlay[index2];
              this.SubPartH[index2 - 1] = this.SubPartH[index2];
              this.SubPartID[index2 - 1] = this.SubPartID[index2];
            }
          }
          --this.SubPartCounter;
          this.SubPartList = (SubPartClass[]) Utils.CopyArray((Array) this.SubPartList, (Array) new SubPartClass[this.SubPartCounter + 1]);
          this.SubPartFlag = (bool[]) Utils.CopyArray((Array) this.SubPartFlag, (Array) new bool[this.SubPartCounter + 1]);
          this.SubPartX = (int[]) Utils.CopyArray((Array) this.SubPartX, (Array) new int[this.SubPartCounter + 1]);
          this.SubPartOverlay = (int[]) Utils.CopyArray((Array) this.SubPartOverlay, (Array) new int[this.SubPartCounter + 1]);
          this.SubPartY = (int[]) Utils.CopyArray((Array) this.SubPartY, (Array) new int[this.SubPartCounter + 1]);
          this.SubPartW = (int[]) Utils.CopyArray((Array) this.SubPartW, (Array) new int[this.SubPartCounter + 1]);
          this.SubPartH = (int[]) Utils.CopyArray((Array) this.SubPartH, (Array) new int[this.SubPartCounter + 1]);
          this.SubPartID = (int[]) Utils.CopyArray((Array) this.SubPartID, (Array) new int[this.SubPartCounter + 1]);
          break;
        }
      }
    }

    public virtual WindowReturnClass HandleMouseClick(int x, int y, int b) => new WindowReturnClass();

    public virtual WindowReturnClass HandleMouseClickOutsideWindow(
      int x,
      int y,
      int b)
    {
      return new WindowReturnClass();
    }

    public virtual WindowReturnClass HandleMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (this.SubPartList[index].HandleMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]) > -1)
          {
            windowReturnClass.SetFlag(true);
            this.SubPartFlag[index] = true;
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public virtual WindowReturnClass HandleBLOCKEDMouseUp(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (!Information.IsNothing((object) this.SubPartList[index]))
            this.SubPartList[index].HandleBLOCKEDMouseUp(x - this.SubPartX[index], y - this.SubPartY[index]);
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public virtual object allowClickOutsideWindow() => (object) false;

    public virtual void clearoverlay()
    {
      if (this.LastOverlaySubPart > 0)
        this.PaintSpecific(this.LastOverlaySubPart);
      this.LastOverlaySubPart = 0;
    }

    public virtual WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false) => new WindowReturnClass()
    {
      Flag = false
    };

    public virtual WindowReturnClass HandleKeyup(int nr) => new WindowReturnClass()
    {
      Flag = false
    };

    public virtual WindowReturnClass handleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      windowReturnClass.Flag = false;
      if (this.SubPartCounter > -1)
      {
        for (int subPartCounter = this.SubPartCounter; subPartCounter >= 0; subPartCounter += -1)
        {
          if (x > this.SubPartX[subPartCounter] & y > this.SubPartY[subPartCounter] & x < this.SubPartX[subPartCounter] + this.SubPartW[subPartCounter] & y < this.SubPartY[subPartCounter] + this.SubPartH[subPartCounter])
          {
            SubPartClass subPart = this.SubPartList[subPartCounter];
            int x1 = x - this.SubPartX[subPartCounter];
            int y1 = y - this.SubPartY[subPartCounter];
            WindowClass windowClass = this;
            ref WindowClass local = ref windowClass;
            if (subPart.HandleTimerWheel(x1, y1, ref local))
            {
              windowReturnClass.SetFlag(true);
              this.SubPartFlag[subPartCounter] = true;
              return windowReturnClass;
            }
          }
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    public virtual WindowReturnClass handleTimer() => new WindowReturnClass()
    {
      Flag = false
    };

    public virtual void HandleToolTip(int x, int y)
    {
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
          {
            this.game.EditObj.TipButton = true;
            this.game.EditObj.TipTitle = "";
            this.game.EditObj.TipText = this.SubPartList[index].Descript;
            return;
          }
        }
      }
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          if (this.MouseData[index] > 0)
            this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          break;
        }
      }
    }

    public virtual string WindowDescription(int x, int y) => "";

    public virtual WindowReturnClass HandleMouseMove(int x, int y)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        bool flag;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] & y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] | this.SubPartList[index].Scroller)
          {
            if (this.SubPartList[index].HandleMouseMove(x - this.SubPartX[index], y - this.SubPartY[index]))
            {
              this.PaintSpecific(this.SubPartID[index]);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if ((double) this.game.Data.RuleVar[839] == 0.0 & !this.NewGfx | this.game.Data.Round == 0)
            {
              this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
              windowReturnClass.SetFlag(false);
              if (Operators.CompareString(this.SubPartList[index].Descript, this.game.EditObj.CurrentDescript, false) == 0)
              {
                flag = true;
              }
              else
              {
                this.game.EditObj.CurrentDescript = this.SubPartList[index].Descript;
                flag = true;
                windowReturnClass.AddCommand(4, 29);
                windowReturnClass.SetFlag(true);
              }
            }
            if (this.SubPartOverlay[index] > 0)
            {
              if (this.LastOverlaySubPart == this.SubPartID[index])
              {
                windowReturnClass.SetOverlay(true);
                return windowReturnClass;
              }
              if (this.LastOverlaySubPart > 0)
                this.PaintSpecific(this.LastOverlaySubPart);
              this.PaintSpecificOverlay(this.SubPartID[index]);
              if (this.game.EmpireStyle)
                SoundMod.PlayAWave(this.game.AppPath + "sound/interface/mouseover.wav", ref this.game.EditObj);
              this.LastOverlaySubPart = this.SubPartID[index];
              windowReturnClass.SetFlag(true);
              windowReturnClass.SetOverlay(true);
              return windowReturnClass;
            }
            if (this.MouseOverSpecific(this.SubPartID[index]))
            {
              windowReturnClass.SetFlag(true);
              windowReturnClass.SetOverlay(true);
              return windowReturnClass;
            }
          }
        }
        if ((double) this.game.Data.RuleVar[839] == 0.0 & !this.NewGfx)
        {
          if (!flag)
          {
            string Left = this.WindowDescription(x, y);
            if (Operators.CompareString(Left, "", false) != 0)
            {
              this.game.EditObj.CurrentDescript = Left;
              flag = true;
              windowReturnClass.AddCommand(4, 29);
              windowReturnClass.SetFlag(true);
            }
          }
          if (!flag && Operators.CompareString("", this.game.EditObj.CurrentDescript, false) != 0)
          {
            this.game.EditObj.CurrentDescript = "";
            windowReturnClass.AddCommand(4, 29);
            windowReturnClass.SetFlag(true);
          }
        }
        if (this.LastOverlaySubPart > 0)
        {
          this.PaintSpecific(this.LastOverlaySubPart);
          this.LastOverlaySubPart = 0;
          windowReturnClass.SetFlag(true);
        }
        windowReturnClass.SetOverlay(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      windowReturnClass.SetOverlay(false);
      return windowReturnClass;
    }
  }
}
