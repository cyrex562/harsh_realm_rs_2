// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingMicrosoft.VisualBasic.CompilerServices;
// usingSystem;
// usingSystem.Drawing;
// usingSystem.Drawing.Imaging;

namespace WindowsApplication1
{
  pub class SubPartClass
  {
    pub Bitmap OwnBitmap;
    pub Descript: String;
    pub MouseOver: bool;
    pub Scroller: bool;
    pub Rectangle[] MouseRect;
    pub MouseCounter: i32;
    pub string[] MouseText;
    pub string[] MouseTitle;
    pub MouseData: Vec<i32>;
    pub MouseType: Vec<i32>;
    pub oldStyle: bool;

    pub virtual bool UseSourceCopyForPaintSpecific() => false;

    pub void ClearMouse() => self.MouseCounter = -1;

    pub void AddMouse( Rectangle trect, string ttitle, string ttext, let mut tdata: i32 = -1, let mut ttype: i32 = 0)
    {
      self += 1.MouseCounter;
      self.MouseRect = (Rectangle[]) Utils.CopyArray((Array) self.MouseRect, (Array) Rectangle::new[self.MouseCounter + 1]);
      self.MouseText = (string[]) Utils.CopyArray((Array) self.MouseText, (Array) new string[self.MouseCounter + 1]);
      self.MouseTitle = (string[]) Utils.CopyArray((Array) self.MouseTitle, (Array) new string[self.MouseCounter + 1]);
      self.MouseData = (int[]) Utils.CopyArray((Array) self.MouseData, (Array) new int[self.MouseCounter + 1]);
      self.MouseType = (int[]) Utils.CopyArray((Array) self.MouseType, (Array) new int[self.MouseCounter + 1]);
      self.MouseRect[self.MouseCounter] = trect;
      self.MouseText[self.MouseCounter] = ttext;
      self.MouseTitle[self.MouseCounter] = ttitle;
      self.MouseData[self.MouseCounter] = tdata;
      self.MouseType[self.MouseCounter] = ttype;
    }

    pub void Dispose()
    {
      if (!Information.IsNothing( self.OwnBitmap))
        self.OwnBitmap.Dispose();
      self.OwnBitmap = (Bitmap) null;
      self.SubDispose();
    }

    pub virtual void SubDispose()
    {
    }

    pub int GetMemorySize() =>  Math.Round( (64 * self.OwnBitmap.Width * self.OwnBitmap.Height) / 8000.0);

    pub virtual int GetSelect() => -1;

    pub virtual int GetTopItem() => -1;

    pub SubPartClass(int w, int h)
    {
      self.oldStyle = false;
      self.MouseCounter = -1;
      if (w > 0 & h > 0)
      {
        self.OwnBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
        self.OwnBitmap.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
        Graphics objgraphics = Graphics.FromImage((Image) self.OwnBitmap);
        DrawMod.ClearTransparent( objgraphics);
        if (!Information.IsNothing( objgraphics))
          objgraphics.Dispose();
      }
      self.MouseOver = false;
    }

    pub void Resize(int w, int h)
    {
      if (!Information.IsNothing( self.OwnBitmap))
        self.OwnBitmap.Dispose();
      self.OwnBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
      self.OwnBitmap.SetResolution( DrawMod.DPIx,  DrawMod.DPIy);
      Graphics objgraphics = Graphics.FromImage((Image) self.OwnBitmap);
      DrawMod.ClearTransparent( objgraphics);
      if (Information.IsNothing( objgraphics))
        return;
      objgraphics.Dispose();
    }

    pub virtual void Refresh(ListClass tListObj, int tlistselect, theader: String = "")
    {
    }

    pub virtual void Refresh(ATListClass tListObj, int tlistselect, theader: String = "")
    {
    }

    pub virtual void Refresh(StringListClass tListObj, int trow, int tcol)
    {
    }

    pub virtual void Refresh(string s)
    {
    }

    pub virtual int HeightUsed() => self.OwnBitmap.Height;

    pub virtual string GetText() => "";

    pub void Clear()
    {
      Graphics objgraphics = Graphics.FromImage((Image) self.OwnBitmap);
      DrawMod.ClearTransparent( objgraphics);
      if (Information.IsNothing( objgraphics))
        return;
      objgraphics.Dispose();
    }

    pub virtual Bitmap Paint()
    {
      Bitmap bitmap;
      return bitmap;
    }

    pub virtual int HandleMouseUp(int x, int y) => -1;

    pub virtual int HandleBLOCKEDMouseUp(int x, int y) => -1;

    pub virtual void HandleToolTip(int x, int y)
    {
    }

    pub virtual bool HandleMouseMove(int x, int y)
    {
      bool flag;
      return flag;
    }

    pub virtual bool HandleTimerWheel(int x, int y,  WindowClass tWindow) => false;

    pub virtual Bitmap PaintOverlay() => self.Paint();

    pub virtual bool MouseMove(int x, int y) => false;

    pub virtual int Click(int x, int y, let mut b: i32 = 1)
    {
      int num;
      return num;
    }

    pub virtual Coordinate Click2(int x, int y, let mut b: i32 = 1)
    {
      Coordinate coordinate;
      return coordinate;
    }

    pub virtual Coordinate ClickMap(int x, int y)
    {
      Coordinate coordinate;
      return coordinate;
    }

    pub virtual void PaintCoordinate(
      Graphics g,
      int x,
      int y,
      int map,
      let mut counteralpha: i32 = 255,
       Bitmap gBitmap = null)
    {
    }

    pub virtual void DescriptInfo(int x, int y)
    {
    }

    pub virtual void ShiftLeft()
    {
    }

    pub virtual void ShiftRight()
    {
    }

    pub virtual void ShiftUp()
    {
    }

    pub virtual void ShiftDown()
    {
    }
  }
}
