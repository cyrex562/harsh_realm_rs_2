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
  pub class WindowClass
  {
    pub SubPartClass[] SubPartList;
    protected int SubPartCounter;
    protected int SubPartIDCounter;
    protected int[] SubPartX;
    protected int[] SubPartY;
    protected int[] SubPartW;
    protected int[] SubPartH;
    protected int[] SubPartID;
    protected int[] SubPartOverlay;
    protected bool[] SubPartFlag;
    pub Bitmap OwnBitmap;
    pub Bitmap BackBitmap;
    pub HeaderString: String;
    pub Color BackColor;
    pub Color BackColor2;
     bool NoPartDraw;
     bool DoGradient;
     int DoBorders;
     int LastOverlaySubPart;
    pub GameClass game;
    protected bool mapframe;
    protected bool downframe;
    protected bool mainframe;
    protected bool extrabackground;
    pub Form1 formref;
    pub fixshade: bool;
    pub shade: bool;
    pub Bitmap screenbackref;
    pub screenx: i32;
    pub screeny: i32;
    pub screenw: i32;
    pub screenh: i32;
    pub useparentscreenbitmap: bool;
    pub backspritescaled: bool;
    pub transbacksprite: bool;
    pub WindowClass LowerWindow;
    pub Rectangle LowerRect;
    pub Rectangle ShowRect;
    pub DoShowRect: bool;
    pub Rectangle[] MouseRect;
    pub MouseCounter: i32;
    pub string[] MouseText;
    pub string[] MouseTitle;
    pub int[] MouseData;
    pub int[] MouseData2;
    pub BlockBlit: bool;
    pub MouseInThisWindow: bool;
    pub NewGfx: bool;
    pub Rectangle[] QuickRect;
    pub QuickDrawMode: bool;
    pub QuickRectCount: i32;
    pub QuickRectMax: i32;
    pub OrderResult form3_orderResult;
    pub form3_returnInstruction: bool;
    pub form3_data1: i32;
    pub form3_data2: i32;

    pub void ClearMouse() => self.MouseCounter = -1;

    pub void AddQuickRect(Rectangle trect)
    {
      if (self.QuickRectCount >= self.QuickRectMax)
      {
        self.QuickDrawMode = false;
      }
      else
      {
        self += 1.QuickRectCount;
        self.QuickRect[self.QuickRectCount] = trect;
        self.QuickDrawMode = true;
      }
    }

    pub void ResetQuickRect()
    {
      self.QuickDrawMode = false;
      self.QuickRectCount = -1;
    }

    pub void AddMouse( Rectangle trect, string ttitle, string ttext, let mut tdata: i32 = -1, let mut tdata2: i32 = -1)
    {
      self += 1.MouseCounter;
      self.MouseRect = (Rectangle[]) Utils.CopyArray((Array) self.MouseRect, (Array) new Rectangle[self.MouseCounter + 1]);
      self.MouseText = (string[]) Utils.CopyArray((Array) self.MouseText, (Array) new string[self.MouseCounter + 1]);
      self.MouseTitle = (string[]) Utils.CopyArray((Array) self.MouseTitle, (Array) new string[self.MouseCounter + 1]);
      self.MouseData = (int[]) Utils.CopyArray((Array) self.MouseData, (Array) new int[self.MouseCounter + 1]);
      self.MouseData2 = (int[]) Utils.CopyArray((Array) self.MouseData2, (Array) new int[self.MouseCounter + 1]);
      self.MouseRect[self.MouseCounter] = trect;
      self.MouseText[self.MouseCounter] = ttext;
      self.MouseTitle[self.MouseCounter] = ttitle;
      self.MouseData[self.MouseCounter] = tdata;
      self.MouseData2[self.MouseCounter] = tdata2;
    }

    pub int GetMemorySize()
    {
      let mut memorySize: i32 =  Math.Round((double) (64 * self.OwnBitmap.Width * self.OwnBitmap.Height) / 8000.0);
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        memorySize += self.SubPartList[index].GetMemorySize();
      return memorySize;
    }

    pub int SubpartNr(int id)
    {
      if (self.SubPartCounter <= -1)
        return -1;
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (self.SubPartID[index] == id)
          return index;
      }
      return -1;
    }

    pub virtual void Dispose()
    {
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        self.SubPartList[index].Dispose();
        self.SubPartList[index] =  null;
      }
      self.OwnBitmap.Dispose();
      self.OwnBitmap = (Bitmap) null;
      self.BackBitmap.Dispose();
      self.BackBitmap = (Bitmap) null;
      self.screenbackref = (Bitmap) null;
      self.game = (GameClass) null;
      self.LowerWindow = (WindowClass) null;
      GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
      Application.DoEvents();
    }

    pub WindowClass(
       GameClass tGame,
      int w,
      int h,
      let mut backcolornr: i32 = -1,
      let mut BackSprite: i32 = -1,
      bool tBackSpriteScaled = false,
      let mut tDoBorders: i32 = 0,
      bool tDoGradient = true,
      tHeaderString: String = "",
      bool tShade = true,
      Bitmap screenbitmap = null,
      let mut sx: i32 = -1,
      let mut sy: i32 = -1,
      bool tTransBacksprite = false)
    {
      self.QuickRect = new Rectangle[20];
      self.QuickDrawMode = false;
      self.QuickRectCount = -1;
      self.QuickRectMax = 19;
      self.MouseCounter = -1;
      self.QuickRectCount = -1;
      self.game = tGame;
      self.DoBorders = tDoBorders;
      self.DoGradient = tDoGradient;
      self.HeaderString = tHeaderString;
      self.transbacksprite = tTransBacksprite;
      self.backspritescaled = tBackSpriteScaled;
      self.screenbackref = screenbitmap;
      self.screenx = sx;
      self.screeny = sy;
      self.screenw = w;
      self.screenh = h;
      self.shade = tShade;
      if (backcolornr == 0)
      {
        self.BackColor = Color.FromArgb(14, 70, 140,  byte.MaxValue);
        self.BackColor2 = Color.FromArgb(14, 70, 140,  byte.MaxValue);
      }
      if (backcolornr == 1)
      {
        self.BackColor = Color.FromArgb(100, 150, 50,  byte.MaxValue);
        self.BackColor2 = Color.FromArgb(14, 70, 140,  byte.MaxValue);
      }
      if (backcolornr == 5 | backcolornr == -1)
      {
        self.BackColor = Color.FromArgb( byte.MaxValue, 10, 10, 10);
        self.BackColor2 = Color.FromArgb( byte.MaxValue, 40, 40, 70);
      }
      if (backcolornr == 6)
      {
        self.BackColor = Color.FromArgb( byte.MaxValue, 0, 0, 0);
        self.BackColor2 = Color.FromArgb(14, 70, 140,  byte.MaxValue);
      }
      if (backcolornr == 7)
      {
        self.BackColor = Color.FromArgb( byte.MaxValue, 0, 0, 0);
        self.BackColor2 = Color.FromArgb( byte.MaxValue, 0, 0, 0);
      }
      if (backcolornr == 8)
      {
        self.BackColor = Color.FromArgb(0, 0, 0, 0);
        self.BackColor2 = Color.FromArgb(0, 0, 0, 0);
      }
      if (self.game.Data.Product == 6)
      {
        if (backcolornr == 9)
        {
          self.BackColor = Color.FromArgb( byte.MaxValue, 60, 120, 60);
          self.BackColor2 = Color.FromArgb( byte.MaxValue, 120, 180, 120);
        }
      }
      else if (backcolornr == 9)
      {
        self.BackColor = Color.FromArgb( byte.MaxValue, 40, 80, 120);
        self.BackColor2 = Color.FromArgb( byte.MaxValue, 100, 140, 180);
      }
      self.BackBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
      self.BackBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics graphics = Graphics.FromImage((Image) self.BackBitmap);
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (BackSprite == -1 | self.transbacksprite)
      {
        if (backcolornr == 99 & !Information.IsNothing((object) self.screenbackref))
        {
           Graphics local1 =  graphics;
           Bitmap local2 =  self.screenbackref;
          rectangle1 = new Rectangle(self.screenx, self.screeny, self.screenw, self.screenh);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 0, self.screenw, self.screenh);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
          self.useparentscreenbitmap = true;
        }
        else if (!self.DoGradient)
          DrawMod.DrawClear(graphics,  self.BackBitmap, Color.FromArgb( self.BackColor.A,  self.BackColor.R,  self.BackColor.G,  self.BackColor.B));
        else
          DrawMod.DrawBlockGradient3( graphics, 0, 0, self.screenw, self.screenh, self.BackColor, self.BackColor2);
        if (Strings.Len(self.HeaderString) > 0)
        {
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          DrawMod.DrawBlock( graphics, 2, 2, w - 4, 38, 0, 0, 0, 128);
          SizeF sizeF = graphics.MeasureString(self.HeaderString, self.game.MarcFont1);
          DrawMod.DrawTextColouredMarc( graphics, self.HeaderString, self.game.MarcFont1,  Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0),  Math.Round(22.0 - (double) sizeF.Height / 2.0), Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
        }
        if (self.DoBorders > 0)
          DrawMod.DrawRectangle( graphics, 0, 0, w - 1, h - 1, 0, 0, 0,  byte.MaxValue);
      }
      if (BackSprite > -1)
      {
        if (!self.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceCopy;
        if (!self.backspritescaled)
        {
          if (BitmapStore.GetWidth(BackSprite) > w)
          {
             Graphics local3 =  graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
             Bitmap local4 =  bitmap;
            rectangle2 = new Rectangle( Math.Round((double) BitmapStore.GetWidth(BackSprite) / 2.0 - (double) w / 2.0), 0, w, h);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local3,  local4, srcrect, destrect);
          }
          else
          {
             Graphics local5 =  graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
             Bitmap local6 =  bitmap;
            DrawMod.DrawSimple( local5,  local6, 0, 0);
          }
        }
        else
        {
           Graphics local7 =  graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(BackSprite);
           Bitmap local8 =  bitmap;
          let mut w1: i32 = w;
          let mut h1: i32 = h;
          DrawMod.DrawScaled( local7,  local8, 0, 0, w1, h1);
        }
        if (!self.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceOver;
      }
      self.OwnBitmap = (Bitmap) self.BackBitmap.Clone();
      self.SubPartCounter = -1;
      self.SubPartIDCounter = 0;
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
    }

    pub void FlagAll()
    {
      if (self.SubPartCounter < 0)
        return;
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        self.SubPartFlag[index] = true;
    }

    pub Bitmap Paint()
    {
      if (Information.IsNothing((object) self.OwnBitmap))
      {
        if (Information.IsNothing((object) self.BackBitmap))
        {
          self.OwnBitmap = new Bitmap(self.screenw, self.screenh, PixelFormat.Format32bppPArgb);
          self.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
          Graphics.FromImage((Image) self.OwnBitmap).Clear(Color.Pink);
        }
        else
          self.OwnBitmap = (Bitmap) self.BackBitmap.Clone();
      }
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      let mut subPartCounter: i32 = self.SubPartCounter;
      Bitmap bitmap;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if ((!Information.IsNothing((object) self.LowerWindow) | self.BlockBlit) & !self.SubPartList[index].oldStyle)
        {
          if (self.SubPartFlag[index])
          {
            if (self.LastOverlaySubPart == self.SubPartID[index])
            {
               Graphics local1 =  objGraphics;
              bitmap = self.SubPartList[index].PaintOverlay();
               Bitmap local2 =  bitmap;
               Bitmap local3 =  self.OwnBitmap;
              let mut x: i32 = self.SubPartX[index];
              let mut y: i32 = self.SubPartY[index];
              DrawMod.DrawSimpleFast( local1,  local2,  local3, x, y);
            }
            else
            {
               Graphics local4 =  objGraphics;
              bitmap = self.SubPartList[index].Paint();
               Bitmap local5 =  bitmap;
               Bitmap local6 =  self.OwnBitmap;
              let mut x: i32 = self.SubPartX[index];
              let mut y: i32 = self.SubPartY[index];
              DrawMod.DrawSimpleFast( local4,  local5,  local6, x, y);
            }
            self.SubPartFlag[index] = false;
          }
        }
        else if (self.SubPartFlag[index])
        {
          if (self.LastOverlaySubPart == self.SubPartID[index])
          {
             Graphics local7 =  objGraphics;
            bitmap = self.SubPartList[index].PaintOverlay();
             Bitmap local8 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local7,  local8, x, y);
          }
          else
          {
             Graphics local9 =  objGraphics;
            bitmap = self.SubPartList[index].Paint();
             Bitmap local10 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local9,  local10, x, y);
          }
          self.SubPartFlag[index] = false;
        }
      }
      if (self.mapframe)
        DrawMod.DrawRectangle( objGraphics, 0, 0, self.OwnBitmap.Width - 1, self.OwnBitmap.Height - 1, 0, 0, 0,  byte.MaxValue);
      if (!Information.IsNothing((object) objGraphics))
        objGraphics.Dispose();
      return self.OwnBitmap;
    }

    pub void PaintSpecific(int id)
    {
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (id == self.SubPartID[index])
        {
          if (self.SubPartList[index].UseSourceCopyForPaintSpecific())
          {
            Expression.CompositingMode = CompositingMode.SourceCopy;
             Graphics local1 =  Expression;
            Bitmap bitmap = self.SubPartList[index].Paint();
             Bitmap local2 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local1,  local2, x, y);
            Expression.CompositingMode = CompositingMode.SourceOver;
          }
          else
          {
             Graphics local3 =  Expression;
            Bitmap bitmap = self.SubPartList[index].Paint();
             Bitmap local4 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local3,  local4, x, y);
          }
          self.AddQuickRect(new Rectangle(self.SubPartX[index], self.SubPartY[index], self.SubPartW[index], self.SubPartH[index]));
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    pub virtual void Before_DoRefresh_Called_By_FlagAllIncludingRefresh()
    {
    }

    pub virtual void DoRefresh()
    {
    }

    pub void PaintCurrentBitmap(int id)
    {
      Graphics Expression = Graphics.FromImage((Image) self.OwnBitmap);
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (id == self.SubPartID[index])
        {
          if (self.SubPartW[index] == self.OwnBitmap.Width & self.SubPartH[index] == self.OwnBitmap.Height & self.GetType().Equals(typeof (MapWindowClass)))
          {
            self.OwnBitmap.Dispose();
            self.OwnBitmap = (Bitmap) self.SubPartList[index].OwnBitmap.Clone();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Application.DoEvents();
          }
          else
          {
             Graphics local1 =  Expression;
            Bitmap bitmap = self.SubPartList[index].Paint();
             Bitmap local2 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local1,  local2, x, y);
          }
        }
      }
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
    }

    pub void PaintCurrentBitmapScaled(int id)
    {
      Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (id == self.SubPartID[index])
          DrawMod.DrawScaled( objGraphics,  self.SubPartList[index].OwnBitmap, self.SubPartX[index], self.SubPartY[index], self.SubPartW[index], self.SubPartH[index]);
      }
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
    }

    pub Bitmap PaintSpecificOverlay(int id)
    {
      let mut subPartCounter: i32 = self.SubPartCounter;
      Graphics Expression;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (id == self.SubPartID[index])
        {
          Expression = Graphics.FromImage((Image) self.OwnBitmap);
           Graphics local1 =  Expression;
          Bitmap bitmap = self.SubPartList[index].PaintOverlay();
           Bitmap local2 =  bitmap;
          let mut x: i32 = self.SubPartX[index];
          let mut y: i32 = self.SubPartY[index];
          DrawMod.DrawSimple( local1,  local2, x, y);
          self.AddQuickRect(new Rectangle(self.SubPartX[index], self.SubPartY[index], self.SubPartW[index], self.SubPartH[index]));
        }
      }
      if (!Information.IsNothing((object) Expression))
      {
        Expression.Dispose();
        Expression = (Graphics) null;
      }
      return self.OwnBitmap;
    }

    pub MouseOverSpecific: bool(int id)
    {
      let mut subPartCounter: i32 = self.SubPartCounter;
      for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
      {
        if (id == self.SubPartID[index] && (self.SubPartList[index].MouseOver | self.SubPartList[index].Scroller) & DrawMod.MouseClicked)
        {
          Graphics graphics = Graphics.FromImage((Image) self.OwnBitmap);
          if (self.formref.doubleSize)
          {
            if (self.SubPartList[index].MouseMove( Math.Round((double) ((float) Cursor.Position.X * self.formref.doubleModX - (float) (self.SubPartX[index] + self.screenx))),  Math.Round((double) ((float) Cursor.Position.Y * self.formref.doubleModY - (float) (self.SubPartY[index] + self.screeny)))))
            {
               Graphics local1 =  graphics;
              Bitmap bitmap = self.SubPartList[index].Paint();
               Bitmap local2 =  bitmap;
              let mut x: i32 = self.SubPartX[index];
              let mut y: i32 = self.SubPartY[index];
              DrawMod.DrawSimple( local1,  local2, x, y);
              return true;
            }
          }
          else if (self.SubPartList[index].MouseMove(Cursor.Position.X - (self.SubPartX[index] + self.screenx), Cursor.Position.Y - (self.SubPartY[index] + self.screeny)))
          {
             Graphics local3 =  graphics;
            Bitmap bitmap = self.SubPartList[index].Paint();
             Bitmap local4 =  bitmap;
            let mut x: i32 = self.SubPartX[index];
            let mut y: i32 = self.SubPartY[index];
            DrawMod.DrawSimple( local3,  local4, x, y);
            return true;
          }
          return false;
        }
      }
      return false;
    }

    pub int AddSubPart( SubPartClass tsubpart, int x, int y, int w, int h, int overlay)
    {
      self += 1.SubPartCounter;
      self += 1.SubPartIDCounter;
      self.SubPartList = (SubPartClass[]) Utils.CopyArray((Array) self.SubPartList, (Array) new SubPartClass[self.SubPartCounter + 1]);
      self.SubPartFlag = (bool[]) Utils.CopyArray((Array) self.SubPartFlag, (Array) new bool[self.SubPartCounter + 1]);
      self.SubPartX = (int[]) Utils.CopyArray((Array) self.SubPartX, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartY = (int[]) Utils.CopyArray((Array) self.SubPartY, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartW = (int[]) Utils.CopyArray((Array) self.SubPartW, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartH = (int[]) Utils.CopyArray((Array) self.SubPartH, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartID = (int[]) Utils.CopyArray((Array) self.SubPartID, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartOverlay = (int[]) Utils.CopyArray((Array) self.SubPartOverlay, (Array) new int[self.SubPartCounter + 1]);
      self.SubPartList[self.SubPartCounter] = tsubpart;
      self.SubPartFlag[self.SubPartCounter] = true;
      self.SubPartX[self.SubPartCounter] = x;
      self.SubPartY[self.SubPartCounter] = y;
      self.SubPartW[self.SubPartCounter] = w;
      self.SubPartH[self.SubPartCounter] = h;
      self.SubPartOverlay[self.SubPartCounter] = overlay;
      self.SubPartID[self.SubPartCounter] = self.SubPartIDCounter;
      return self.SubPartIDCounter;
    }

    pub void NewBackGroundAndClearAll(int w, int h, int backsprite)
    {
      if (Information.IsNothing((object) self.BackBitmap))
      {
        self.BackBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
        self.BackBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      Graphics graphics = Graphics.FromImage((Image) self.BackBitmap);
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (backsprite == -1 | self.transbacksprite)
      {
        if (self.useparentscreenbitmap)
        {
           Graphics local1 =  graphics;
           Bitmap local2 =  self.screenbackref;
          rectangle1 = new Rectangle(self.screenx, self.screeny, self.screenw, self.screenh);
          Rectangle srcrect = rectangle1;
          rectangle2 = new Rectangle(0, 0, self.screenw, self.screenh);
          Rectangle destrect = rectangle2;
          DrawMod.DrawSimplePart2( local1,  local2, srcrect, destrect);
        }
        else if (!Information.IsNothing((object) self.LowerWindow))
        {
          if (!Information.IsNothing((object) self.LowerWindow.SubPartList))
          {
            if (self.LowerWindow.GetType().Equals(typeof (MapWindowClass)) | self.LowerWindow.GetType().Equals(typeof (MapWindowClass2)))
            {
               Graphics local3 =  graphics;
               Bitmap local4 =  self.LowerWindow.SubPartList[0].OwnBitmap;
              Rectangle lowerRect = self.LowerRect;
              rectangle2 = new Rectangle(0, 0, w, h);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2( local3,  local4, lowerRect, destrect);
            }
            else
            {
               Graphics local5 =  graphics;
               Bitmap local6 =  self.LowerWindow.OwnBitmap;
              Rectangle lowerRect = self.LowerRect;
              rectangle2 = new Rectangle(0, 0, w, h);
              Rectangle destrect = rectangle2;
              DrawMod.DrawSimplePart2( local5,  local6, lowerRect, destrect);
            }
          }
          else if (!Information.IsNothing((object) self.LowerWindow))
          {
             Graphics local7 =  graphics;
             Bitmap local8 =  self.LowerWindow.OwnBitmap;
            Rectangle lowerRect = self.LowerRect;
            rectangle2 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle2;
            DrawMod.DrawSimplePart2( local7,  local8, lowerRect, destrect);
          }
        }
        else if (!self.DoGradient)
          DrawMod.DrawClear(graphics,  self.BackBitmap, Color.FromArgb( self.BackColor.A,  self.BackColor.R,  self.BackColor.G,  self.BackColor.B));
        else
          DrawMod.DrawBlockGradient3( graphics, 0, 0, self.screenw, self.screenh, self.BackColor, self.BackColor2);
        if (Strings.Len(self.HeaderString) > 0)
        {
          graphics.SmoothingMode = SmoothingMode.AntiAlias;
          DrawMod.DrawBlock( graphics, 2, 2, w - 4, 38, 0, 0, 0, 128);
          SizeF sizeF = graphics.MeasureString(self.HeaderString, self.game.MarcFont1);
          DrawMod.DrawTextColouredMarc( graphics, self.HeaderString, self.game.MarcFont1,  Math.Round((double) w / 2.0 - (double) sizeF.Width / 2.0),  Math.Round(22.0 - (double) sizeF.Height / 2.0), Color.FromArgb( byte.MaxValue,  byte.MaxValue,  byte.MaxValue,  byte.MaxValue));
        }
        if (self.DoBorders > 0)
          DrawMod.DrawRectangle( graphics, 0, 0, w - 1, h - 1, 0, 0, 0,  byte.MaxValue);
      }
      if (backsprite > -1)
      {
        if (!self.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceCopy;
        if (!self.backspritescaled)
        {
          if (BitmapStore.GetWidth(backsprite) > w)
          {
             Graphics local9 =  graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
             Bitmap local10 =  bitmap;
            rectangle2 = new Rectangle( Math.Round((double) BitmapStore.GetWidth(backsprite) / 2.0 - (double) w / 2.0), 0, w, h);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
          }
          else if (BitmapStore.GetWidth(backsprite) < w)
          {
             Graphics local11 =  graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
             Bitmap local12 =  bitmap;
            rectangle2 = new Rectangle(0, 0, BitmapStore.GetWidth(backsprite), BitmapStore.Getheight(backsprite));
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, 0, w, h);
            Rectangle destrect = rectangle1;
            DrawMod.DrawSimplePart2( local11,  local12, srcrect, destrect);
          }
          else
          {
             Graphics local13 =  graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
             Bitmap local14 =  bitmap;
            DrawMod.DrawSimple( local13,  local14, 0, 0);
          }
        }
        else
        {
           Graphics local15 =  graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(backsprite);
           Bitmap local16 =  bitmap;
          let mut w1: i32 = w;
          let mut h1: i32 = h;
          DrawMod.DrawScaled( local15,  local16, 0, 0, w1, h1);
        }
        if (!self.transbacksprite)
          graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (!Information.IsNothing((object) self.OwnBitmap))
      {
        if (!Information.IsNothing((object) graphics))
        {
          graphics.Dispose();
          graphics = (Graphics) null;
        }
        graphics = Graphics.FromImage((Image) self.OwnBitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) self.BackBitmap, 0, 0);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (Information.IsNothing((object) graphics))
        return;
      graphics.Dispose();
      graphics = (Graphics) null;
    }

    pub void RemoveSubPart(int id)
    {
      if (self.SubPartCounter <= -1)
        return;
      let mut subPartCounter1: i32 = self.SubPartCounter;
      for (let mut index1: i32 = 0; index1 <= subPartCounter1; index1 += 1)
      {
        if (self.SubPartID[index1] == id)
        {
          if (!Information.IsNothing((object) self.OwnBitmap))
          {
            Graphics objGraphics = Graphics.FromImage((Image) self.OwnBitmap);
            Rectangle rect = new Rectangle(self.SubPartX[index1], self.SubPartY[index1], self.SubPartW[index1], self.SubPartH[index1]);
            DrawMod.DrawSimplePart( objGraphics,  self.BackBitmap, rect);
          }
          if (self.LastOverlaySubPart == id)
            self.LastOverlaySubPart = 0;
          self.SubPartList[index1].Dispose();
          self.SubPartList[index1] =  null;
          if (index1 != self.SubPartCounter)
          {
            let mut num: i32 = index1 + 1;
            let mut subPartCounter2: i32 = self.SubPartCounter;
            for (let mut index2: i32 = num; index2 <= subPartCounter2; index2 += 1)
            {
              self.SubPartList[index2 - 1] = self.SubPartList[index2];
              self.SubPartFlag[index2 - 1] = self.SubPartFlag[index2];
              self.SubPartX[index2 - 1] = self.SubPartX[index2];
              self.SubPartY[index2 - 1] = self.SubPartY[index2];
              self.SubPartW[index2 - 1] = self.SubPartW[index2];
              self.SubPartOverlay[index2 - 1] = self.SubPartOverlay[index2];
              self.SubPartH[index2 - 1] = self.SubPartH[index2];
              self.SubPartID[index2 - 1] = self.SubPartID[index2];
            }
          }
          --self.SubPartCounter;
          self.SubPartList = (SubPartClass[]) Utils.CopyArray((Array) self.SubPartList, (Array) new SubPartClass[self.SubPartCounter + 1]);
          self.SubPartFlag = (bool[]) Utils.CopyArray((Array) self.SubPartFlag, (Array) new bool[self.SubPartCounter + 1]);
          self.SubPartX = (int[]) Utils.CopyArray((Array) self.SubPartX, (Array) new int[self.SubPartCounter + 1]);
          self.SubPartOverlay = (int[]) Utils.CopyArray((Array) self.SubPartOverlay, (Array) new int[self.SubPartCounter + 1]);
          self.SubPartY = (int[]) Utils.CopyArray((Array) self.SubPartY, (Array) new int[self.SubPartCounter + 1]);
          self.SubPartW = (int[]) Utils.CopyArray((Array) self.SubPartW, (Array) new int[self.SubPartCounter + 1]);
          self.SubPartH = (int[]) Utils.CopyArray((Array) self.SubPartH, (Array) new int[self.SubPartCounter + 1]);
          self.SubPartID = (int[]) Utils.CopyArray((Array) self.SubPartID, (Array) new int[self.SubPartCounter + 1]);
          break;
        }
      }
    }

    pub virtual HandleMouseClick: WindowReturnClass(int x, int y, int b) => WindowReturnClass::new();

    pub virtual HandleMouseClickOutsideWindow: WindowReturnClass(
      int x,
      int y,
      int b)
    {
      return WindowReturnClass::new();
    }

    pub virtual HandleMouseUp: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (self.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = self.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (self.SubPartList[index].HandleMouseUp(x - self.SubPartX[index], y - self.SubPartY[index]) > -1)
          {
            windowReturnClass.SetFlag(true);
            self.SubPartFlag[index] = true;
            return windowReturnClass;
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub virtual HandleBLOCKEDMouseUp: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (self.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = self.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (!Information.IsNothing((object) self.SubPartList[index]))
            self.SubPartList[index].HandleBLOCKEDMouseUp(x - self.SubPartX[index], y - self.SubPartY[index]);
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub virtual object allowClickOutsideWindow() => (object) false;

    pub virtual void clearoverlay()
    {
      if (self.LastOverlaySubPart > 0)
        self.PaintSpecific(self.LastOverlaySubPart);
      self.LastOverlaySubPart = 0;
    }

    pub virtual HandleKeyPress: WindowReturnClass(int nr, bool fromTimer = false) => WindowReturnClass::new()
    {
      Flag = false
    };

    pub virtual HandleKeyup: WindowReturnClass(int nr) => WindowReturnClass::new()
    {
      Flag = false
    };

    pub virtual handleTimerWheel: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      windowReturnClass.Flag = false;
      if (self.SubPartCounter > -1)
      {
        for (let mut subPartCounter: i32 = self.SubPartCounter; subPartCounter >= 0; subPartCounter += -1)
        {
          if (x > self.SubPartX[subPartCounter] & y > self.SubPartY[subPartCounter] & x < self.SubPartX[subPartCounter] + self.SubPartW[subPartCounter] & y < self.SubPartY[subPartCounter] + self.SubPartH[subPartCounter])
          {
            let mut subPart: SubPartClass = self.SubPartList[subPartCounter];
            let mut x1: i32 = x - self.SubPartX[subPartCounter];
            let mut y1: i32 = y - self.SubPartY[subPartCounter];
            WindowClass windowClass = this;
             WindowClass local =  windowClass;
            if (subPart.HandleTimerWheel(x1, y1,  local))
            {
              windowReturnClass.SetFlag(true);
              self.SubPartFlag[subPartCounter] = true;
              return windowReturnClass;
            }
          }
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub virtual handleTimer: WindowReturnClass() => WindowReturnClass::new()
    {
      Flag = false
    };

    pub virtual void HandleToolTip(int x, int y)
    {
      if (self.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = self.SubPartCounter;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > self.SubPartX[index] & x < self.SubPartX[index] + self.SubPartW[index] && y > self.SubPartY[index] & y < self.SubPartY[index] + self.SubPartH[index] && Operators.CompareString(self.SubPartList[index].Descript, "", false) > 0)
          {
            self.game.EditObj.TipButton = true;
            self.game.EditObj.TipTitle = "";
            self.game.EditObj.TipText = self.SubPartList[index].Descript;
            return;
          }
        }
      }
      let mut mouseCounter: i32 = self.MouseCounter;
      for (let mut index: i32 = 0; index <= mouseCounter; index += 1)
      {
        if (x > self.MouseRect[index].X & x < self.MouseRect[index].X + self.MouseRect[index].Width && y > self.MouseRect[index].Y & y < self.MouseRect[index].Y + self.MouseRect[index].Height)
        {
          if (self.MouseData[index] > 0)
            self.game.EditObj.TipButton = true;
          self.game.EditObj.TipTitle = self.MouseTitle[index];
          self.game.EditObj.TipText = self.MouseText[index];
          break;
        }
      }
    }

    pub virtual string WindowDescription(int x, int y) => "";

    pub virtual HandleMouseMove: WindowReturnClass(int x, int y)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (self.SubPartCounter > -1)
      {
        let mut subPartCounter: i32 = self.SubPartCounter;
        bool flag;
        for (let mut index: i32 = 0; index <= subPartCounter; index += 1)
        {
          if (x > self.SubPartX[index] & x < self.SubPartX[index] + self.SubPartW[index] & y > self.SubPartY[index] & y < self.SubPartY[index] + self.SubPartH[index] | self.SubPartList[index].Scroller)
          {
            if (self.SubPartList[index].HandleMouseMove(x - self.SubPartX[index], y - self.SubPartY[index]))
            {
              self.PaintSpecific(self.SubPartID[index]);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if ((double) self.game.Data.RuleVar[839] == 0.0 & !self.NewGfx | self.game.Data.Round == 0)
            {
              self.SubPartList[index].DescriptInfo(x - self.SubPartX[index], y - self.SubPartY[index]);
              windowReturnClass.SetFlag(false);
              if (Operators.CompareString(self.SubPartList[index].Descript, self.game.EditObj.CurrentDescript, false) == 0)
              {
                flag = true;
              }
              else
              {
                self.game.EditObj.CurrentDescript = self.SubPartList[index].Descript;
                flag = true;
                windowReturnClass.AddCommand(4, 29);
                windowReturnClass.SetFlag(true);
              }
            }
            if (self.SubPartOverlay[index] > 0)
            {
              if (self.LastOverlaySubPart == self.SubPartID[index])
              {
                windowReturnClass.SetOverlay(true);
                return windowReturnClass;
              }
              if (self.LastOverlaySubPart > 0)
                self.PaintSpecific(self.LastOverlaySubPart);
              self.PaintSpecificOverlay(self.SubPartID[index]);
              if (self.game.EmpireStyle)
                SoundMod.PlayAWave(self.game.AppPath + "sound/interface/mouseover.wav",  self.game.EditObj);
              self.LastOverlaySubPart = self.SubPartID[index];
              windowReturnClass.SetFlag(true);
              windowReturnClass.SetOverlay(true);
              return windowReturnClass;
            }
            if (self.MouseOverSpecific(self.SubPartID[index]))
            {
              windowReturnClass.SetFlag(true);
              windowReturnClass.SetOverlay(true);
              return windowReturnClass;
            }
          }
        }
        if ((double) self.game.Data.RuleVar[839] == 0.0 & !self.NewGfx)
        {
          if (!flag)
          {
            Left: String = self.WindowDescription(x, y);
            if (Operators.CompareString(Left, "", false) != 0)
            {
              self.game.EditObj.CurrentDescript = Left;
              flag = true;
              windowReturnClass.AddCommand(4, 29);
              windowReturnClass.SetFlag(true);
            }
          }
          if (!flag && Operators.CompareString("", self.game.EditObj.CurrentDescript, false) != 0)
          {
            self.game.EditObj.CurrentDescript = "";
            windowReturnClass.AddCommand(4, 29);
            windowReturnClass.SetFlag(true);
          }
        }
        if (self.LastOverlaySubPart > 0)
        {
          self.PaintSpecific(self.LastOverlaySubPart);
          self.LastOverlaySubPart = 0;
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
