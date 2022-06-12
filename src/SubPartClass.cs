// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class SubPartClass
  {
    public Bitmap OwnBitmap;
    public string Descript;
    public bool MouseOver;
    public bool Scroller;
    public Rectangle[] MouseRect;
    public int MouseCounter;
    public string[] MouseText;
    public string[] MouseTitle;
    public int[] MouseData;
    public int[] MouseType;
    public bool oldStyle;

    public virtual bool UseSourceCopyForPaintSpecific() => false;

    public void ClearMouse() => this.MouseCounter = -1;

    public void AddMouse(ref Rectangle trect, string ttitle, string ttext, int tdata = -1, int ttype = 0)
    {
      ++this.MouseCounter;
      this.MouseRect = (Rectangle[]) Utils.CopyArray((Array) this.MouseRect, (Array) new Rectangle[this.MouseCounter + 1]);
      this.MouseText = (string[]) Utils.CopyArray((Array) this.MouseText, (Array) new string[this.MouseCounter + 1]);
      this.MouseTitle = (string[]) Utils.CopyArray((Array) this.MouseTitle, (Array) new string[this.MouseCounter + 1]);
      this.MouseData = (int[]) Utils.CopyArray((Array) this.MouseData, (Array) new int[this.MouseCounter + 1]);
      this.MouseType = (int[]) Utils.CopyArray((Array) this.MouseType, (Array) new int[this.MouseCounter + 1]);
      this.MouseRect[this.MouseCounter] = trect;
      this.MouseText[this.MouseCounter] = ttext;
      this.MouseTitle[this.MouseCounter] = ttitle;
      this.MouseData[this.MouseCounter] = tdata;
      this.MouseType[this.MouseCounter] = ttype;
    }

    public void Dispose()
    {
      if (!Information.IsNothing((object) this.OwnBitmap))
        this.OwnBitmap.Dispose();
      this.OwnBitmap = (Bitmap) null;
      this.SubDispose();
    }

    public virtual void SubDispose()
    {
    }

    public int GetMemorySize() => (int) Math.Round((double) (64 * this.OwnBitmap.Width * this.OwnBitmap.Height) / 8000.0);

    public virtual int GetSelect() => -1;

    public virtual int GetTopItem() => -1;

    public SubPartClass(int w, int h)
    {
      this.oldStyle = false;
      this.MouseCounter = -1;
      if (w > 0 & h > 0)
      {
        this.OwnBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
        this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
        DrawMod.ClearTransparent(ref objgraphics);
        if (!Information.IsNothing((object) objgraphics))
          objgraphics.Dispose();
      }
      this.MouseOver = false;
    }

    public void Resize(int w, int h)
    {
      if (!Information.IsNothing((object) this.OwnBitmap))
        this.OwnBitmap.Dispose();
      this.OwnBitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
      this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.ClearTransparent(ref objgraphics);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    public virtual void Refresh(ListClass tListObj, int tlistselect, string theader = "")
    {
    }

    public virtual void Refresh(ATListClass tListObj, int tlistselect, string theader = "")
    {
    }

    public virtual void Refresh(StringListClass tListObj, int trow, int tcol)
    {
    }

    public virtual void Refresh(string s)
    {
    }

    public virtual int HeightUsed() => this.OwnBitmap.Height;

    public virtual string GetText() => "";

    public void Clear()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.ClearTransparent(ref objgraphics);
      if (Information.IsNothing((object) objgraphics))
        return;
      objgraphics.Dispose();
    }

    public virtual Bitmap Paint()
    {
      Bitmap bitmap;
      return bitmap;
    }

    public virtual int HandleMouseUp(int x, int y) => -1;

    public virtual int HandleBLOCKEDMouseUp(int x, int y) => -1;

    public virtual void HandleToolTip(int x, int y)
    {
    }

    public virtual bool HandleMouseMove(int x, int y)
    {
      bool flag;
      return flag;
    }

    public virtual bool HandleTimerWheel(int x, int y, ref WindowClass tWindow) => false;

    public virtual Bitmap PaintOverlay() => this.Paint();

    public virtual bool MouseMove(int x, int y) => false;

    public virtual int Click(int x, int y, int b = 1)
    {
      int num;
      return num;
    }

    public virtual Coordinate Click2(int x, int y, int b = 1)
    {
      Coordinate coordinate;
      return coordinate;
    }

    public virtual Coordinate ClickMap(int x, int y)
    {
      Coordinate coordinate;
      return coordinate;
    }

    public virtual void PaintCoordinate(
      Graphics g,
      int x,
      int y,
      int map,
      int counteralpha = 255,
      ref Bitmap gBitmap = null)
    {
    }

    public virtual void DescriptInfo(int x, int y)
    {
    }

    public virtual void ShiftLeft()
    {
    }

    public virtual void ShiftRight()
    {
    }

    public virtual void ShiftUp()
    {
    }

    public virtual void ShiftDown()
    {
    }
  }
}
