// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.BigListSubPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsApplication1
{
  public class BigListSubPartClass : SubPartClass
  {
    private int ListSize;
    private int ListSelect;
    public int TopItem;
    private ListClass ListObj;
    private Font OwnFont;
    private Font ownfont2;
    private const int ItemSize = 32;
    private int ItemFontOffset;
    private int LeftTextOffset;
    private int Width;
    private int Height;
    private GameClass game;
    private string Header;
    private bool HeaderCenter;
    private bool Highlight;
    private bool ShowPair;
    private int ValueWidth;
    private bool DoTopAndBottom;
    private Bitmap backbitmap;
    private int clickscroll;
    private bool MarcStyle;

    public override void Refresh(ListClass tListObj, int tlistselect, string theader = "")
    {
      this.ListObj = tListObj;
      this.ListSelect = tlistselect;
      if (Strings.Len(theader) > 0)
        this.Header = theader;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      this.Clear();
    }

    public override void SubDispose()
    {
      if (Information.IsNothing((object) this.backbitmap))
        return;
      this.backbitmap.Dispose();
      this.backbitmap = (Bitmap) null;
    }

    public BigListSubPartClass(
      ListClass tListobj,
      int tlistsize,
      int twidth,
      int tlistselect,
      GameClass tgame,
      bool systemfont = false,
      string tHeader = "",
      bool tHeaderCenter = true,
      bool tHighlight = true,
      int tTop = 0,
      bool tShowPair = false,
      int tValueWidth = 50,
      bool tdotopandbottom = true,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool tMarcStyle = false)
      : base(twidth, (tlistsize + 3) * 32)
    {
      this.ItemFontOffset = 3;
      this.LeftTextOffset = 5;
      if (!tdotopandbottom)
        this.Resize(twidth, (tlistsize + 1) * 32);
      this.MarcStyle = tMarcStyle;
      if (this.MarcStyle)
      {
        this.ItemFontOffset = 3;
        this.LeftTextOffset = 10;
      }
      this.ShowPair = tShowPair;
      this.ValueWidth = tValueWidth;
      this.DoTopAndBottom = tdotopandbottom;
      if (!Information.IsNothing((object) tbackbitmap))
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
        graphics.Dispose();
      }
      this.Width = twidth;
      this.Height = (tlistsize + 3) * 32;
      if (!this.DoTopAndBottom)
        this.Height = (tlistsize + 1) * 32;
      this.ListSize = tlistsize;
      this.ListSelect = tlistselect;
      this.ListObj = tListobj;
      this.MouseOver = true;
      this.clickscroll = 0;
      this.Highlight = tHighlight;
      this.TopItem = tTop;
      this.HeaderCenter = tHeaderCenter;
      this.game = tgame;
      if (Strings.Len(tHeader) > 0)
        this.Header = tHeader;
      if (tTop == 0)
      {
        this.TopItem = (int) Math.Round((double) this.ListSelect - Conversion.Int((double) this.ListSize / 2.0));
        if (this.TopItem < 0)
          this.TopItem = 0;
      }
      if (this.MarcStyle)
        this.OwnFont = this.game.MarcFont5;
      else if (!systemfont)
      {
        this.OwnFont = new Font(this.game.FontCol.Families[1], 12f, FontStyle.Regular, GraphicsUnit.Pixel);
        this.ownfont2 = new Font(this.game.FontCol.Families[1], 11f, FontStyle.Regular, GraphicsUnit.Pixel);
      }
      else
      {
        this.OwnFont = new Font("Courier New", 12f, FontStyle.Regular, GraphicsUnit.Pixel);
        this.ownfont2 = new Font("Courier New", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
      }
    }

    public override Bitmap Paint()
    {
      SizeF sizeF = new SizeF();
      Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.ListSize >= this.ListObj.ListCount)
        this.TopItem = 0;
      if (Information.IsNothing((object) this.backbitmap))
      {
        graphics.Clear(Color.Transparent);
      }
      else
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref graphics, ref this.backbitmap, 0, 0);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      if (!this.DoTopAndBottom)
        DrawMod.DrawBlockGradient2(ref graphics, 0, 0, this.Width, this.Height, this.game.MarcCol1, this.game.MarcCol2);
      int num1 = 20;
      if (this.ListSize >= this.ListObj.ListCount)
        num1 = 0;
      int num2 = 2;
      int num3 = 1;
      if (!this.DoTopAndBottom)
      {
        num2 = 0;
        num3 = 0;
      }
      int num4 = -1;
      int topItem = this.TopItem;
      int num5 = this.TopItem + this.ListSize + num2;
      for (int index = topItem; index <= num5; ++index)
      {
        ++num4;
        if (!(num4 == this.ListSize + 2 & this.DoTopAndBottom) && this.ListSelect == index - num3 & this.ListSelect > -1 & this.Highlight)
        {
          if (this.MarcStyle)
            DrawMod.DrawBlockGradient2(ref graphics, 0, 32 * num4, this.Width - num1, 32, Color.FromArgb(175, (int) byte.MaxValue, 200, (int) byte.MaxValue), Color.FromArgb(50, (int) byte.MaxValue, 200, (int) byte.MaxValue));
          else
            DrawMod.DrawBlockGradient2(ref graphics, 0, 32 * num4, this.Width - num1, 32, Color.FromArgb(175, 0, (int) byte.MaxValue, 0), Color.FromArgb(50, 0, (int) byte.MaxValue, 0));
        }
        if (index - num3 <= this.ListObj.ListCount & index - num3 >= 0)
        {
          string[] strArray = this.ListObj.ListName[index - num3].Split('#');
          DrawMod.DrawTextColouredMarc(ref graphics, strArray[0], this.game.MarcFont7, this.LeftTextOffset, 32 * num4 + this.ItemFontOffset, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, strArray[1], this.game.MarcFont13, this.LeftTextOffset, 32 * num4 + this.ItemFontOffset + 16, Color.White);
          DrawMod.DrawTextColouredMarc(ref graphics, strArray[2], this.game.MarcFont8, this.Width - 50, 32 * num4 + this.ItemFontOffset + 8, Color.White);
          if (index - num3 <= this.ListObj.ListCount & index > this.TopItem)
            DrawMod.drawLine(ref graphics, 0, 32 * num4, this.Width, 32 * num4, (int) this.game.MarcCol2.R, (int) this.game.MarcCol2.G, (int) this.game.MarcCol2.B, (int) this.game.MarcCol2.A);
          else
            index = index;
        }
      }
      int num6 = (this.ListSize + 1) * 32;
      float num7 = this.ListObj.ListCount <= 0 ? 1f : (float) this.ListSize / (float) this.ListObj.ListCount;
      if ((double) num7 > 1.0)
        num7 = 1f;
      int num8 = (int) Math.Round((double) Conversion.Int((float) num6 * num7));
      float num9 = this.ListObj.ListCount <= 0 ? 0.0f : (float) this.TopItem / (float) this.ListObj.ListCount;
      if ((double) num9 > 1.0)
        num9 = 1f;
      int num10 = (int) Math.Round((double) Conversion.Int((float) num6 * num9));
      if (this.DoTopAndBottom)
        num10 += 32;
      if (num6 < 5)
        num6 = 5;
      if (num10 + num8 > num6 + 32)
        num8 = num6 + 32 - num10;
      if (this.ListSize < this.ListObj.ListCount)
      {
        int x = this.Width - 18;
        int y = num10 + 3;
        int width = 16;
        int num11 = num8 - 2;
        if (!this.MarcStyle)
        {
          ref Graphics local1 = ref graphics;
          Bitmap bitmap1 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local2 = ref bitmap1;
          Rectangle rectangle1 = new Rectangle(0, 8, 28, 12);
          Rectangle srcrect1 = rectangle1;
          Rectangle rectangle2 = new Rectangle(x, y + 8, width, num11 - 16);
          Rectangle destrect1 = rectangle2;
          DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
          ref Graphics local3 = ref graphics;
          Bitmap bitmap2 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local4 = ref bitmap2;
          rectangle2 = new Rectangle(0, 0, 28, 8);
          Rectangle srcrect2 = rectangle2;
          rectangle1 = new Rectangle(x, y, width, 8);
          Rectangle destrect2 = rectangle1;
          DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
          ref Graphics local5 = ref graphics;
          Bitmap bitmap3 = BitmapStore.GetBitmap(DrawMod.TGame.SLIDER1);
          ref Bitmap local6 = ref bitmap3;
          rectangle2 = new Rectangle(0, 28, 28, 8);
          Rectangle srcrect3 = rectangle2;
          rectangle1 = new Rectangle(x, y + num11 - 8, 28, 8);
          Rectangle destrect3 = rectangle1;
          DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        }
        else
        {
          ref Graphics local7 = ref graphics;
          Bitmap bitmap4 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local8 = ref bitmap4;
          Rectangle rectangle3 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect4 = rectangle3;
          Rectangle rectangle4 = new Rectangle(x, 2, 20, this.Height - 4);
          Rectangle destrect4 = rectangle4;
          DrawMod.DrawSimplePart2(ref local7, ref local8, srcrect4, destrect4);
          ref Graphics local9 = ref graphics;
          Bitmap bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local10 = ref bitmap5;
          rectangle3 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect5 = rectangle3;
          rectangle4 = new Rectangle(x, 0, 20, 2);
          Rectangle destrect5 = rectangle4;
          DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect5, destrect5);
          ref Graphics local11 = ref graphics;
          bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
          ref Bitmap local12 = ref bitmap5;
          rectangle3 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect6 = rectangle3;
          rectangle4 = new Rectangle(x, this.Height - 2, 20, 2);
          Rectangle destrect6 = rectangle4;
          DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect6, destrect6);
          ref Graphics local13 = ref graphics;
          bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local14 = ref bitmap5;
          rectangle3 = new Rectangle(0, 2, 20, 6);
          Rectangle srcrect7 = rectangle3;
          rectangle4 = new Rectangle(x, y + 2, width, num11 - 2);
          Rectangle destrect7 = rectangle4;
          DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect7, destrect7);
          ref Graphics local15 = ref graphics;
          bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local16 = ref bitmap5;
          rectangle3 = new Rectangle(0, 0, 20, 2);
          Rectangle srcrect8 = rectangle3;
          rectangle4 = new Rectangle(x, y, width, 2);
          Rectangle destrect8 = rectangle4;
          DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect8, destrect8);
          ref Graphics local17 = ref graphics;
          bitmap5 = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
          ref Bitmap local18 = ref bitmap5;
          rectangle3 = new Rectangle(0, 8, 20, 2);
          Rectangle srcrect9 = rectangle3;
          rectangle4 = new Rectangle(x, y + num11 - 2, 10, 2);
          Rectangle destrect9 = rectangle4;
          DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect9, destrect9);
        }
      }
      if (!this.MarcStyle)
      {
        if (this.DoTopAndBottom)
        {
          if (this.ListSize < this.ListObj.ListCount)
            DrawMod.DrawRectangle(ref graphics, 0, 32, this.Width - 21, this.Height - 64, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          else
            DrawMod.DrawRectangle(ref graphics, 0, 32, this.Width - 1, this.Height - 64, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
        else if (this.ListSize < this.ListObj.ListCount)
          DrawMod.DrawRectangle(ref graphics, 0, 0, this.Width - 21, this.Height - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        else
          DrawMod.DrawRectangle(ref graphics, 0, 0, this.Width - 1, this.Height - 1, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      }
      if (this.MarcStyle)
        DrawMod.DrawFrame(ref this.OwnBitmap, ref this.backbitmap, ref graphics, 0, 0, this.Width, this.Height, -1, -1);
      return this.OwnBitmap;
    }

    public override void ShiftDown()
    {
      ++this.TopItem;
      ++this.ListSelect;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (this.ListSelect > this.ListObj.ListCount)
        this.ListSelect = this.ListObj.ListCount;
      if (0 > this.TopItem)
        this.TopItem = 0;
      if (0 <= this.ListSelect)
        return;
      this.ListSelect = 0;
    }

    public override void ShiftUp()
    {
      --this.TopItem;
      --this.ListSelect;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (this.ListSelect > this.ListObj.ListCount)
        this.ListSelect = this.ListObj.ListCount;
      if (0 > this.TopItem)
        this.TopItem = 0;
      if (0 <= this.ListSelect)
        return;
      this.ListSelect = 0;
    }

    public override int GetSelect() => this.ListObj.ListData[this.ListSelect];

    public override int Click(int x, int y, int b = 1)
    {
      int num1 = y;
      y = (int) Math.Round(Conversion.Int((double) y / 32.0));
      this.Scroller = true;
      int num2 = 0;
      int num3 = 2;
      int num4 = 1;
      if (!this.DoTopAndBottom)
      {
        num3 = 1;
        num2 = -1;
        num4 = 0;
      }
      int num5 = 20;
      if (this.ListSize >= this.ListObj.ListCount)
        num5 = 0;
      if (y > num2 & y < this.ListSize + num3)
      {
        if (x <= this.Width - num5)
        {
          y -= num4;
          y += this.TopItem;
          this.clickscroll = 0;
          if (y > this.ListObj.ListCount)
            return -1;
          this.ListSelect = y;
          return this.ListObj.ListData[this.ListSelect];
        }
        this.clickscroll = 1;
        int num6 = (this.ListSize + 1) * 32;
        if (this.DoTopAndBottom)
          num1 -= 32;
        if (num1 < 1)
          num1 = 1;
        int num7 = (int) Math.Round((double) (int) Math.Round((double) ((float) num1 / (float) num6 * (float) this.ListObj.ListCount)) - (double) this.ListSize / 2.0);
        if (0 > num7)
          num7 = 0;
        this.TopItem = num7;
        if (this.TopItem > this.ListObj.ListCount - this.ListSize)
          this.TopItem = this.ListObj.ListCount - this.ListSize;
        if (0 > this.TopItem)
          this.TopItem = 0;
        return -1;
      }
      if (y == 0 & this.DoTopAndBottom)
      {
        --this.TopItem;
        this.clickscroll = 0;
        if (0 > this.TopItem)
          this.TopItem = 0;
        return -1;
      }
      if (!(y == this.ListSize + 2 & this.DoTopAndBottom))
        return -1;
      ++this.TopItem;
      this.clickscroll = 0;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return -1;
    }

    public override int HandleMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    public override bool MouseMove(int x, int y)
    {
      int num1 = y;
      y = (int) Math.Round(Conversion.Int((double) y / 32.0));
      int num2 = 0;
      int num3 = 2;
      int num4 = 1;
      if (!this.DoTopAndBottom)
      {
        num3 = 1;
        num2 = -1;
        num4 = 0;
      }
      int num5 = 20;
      if (this.ListSize >= this.ListObj.ListCount)
        num5 = 0;
      if (!(y > num2 & y < this.ListSize + num3 & this.clickscroll == 1))
        return false;
      int num6 = (this.ListSize + 1) * 32;
      if (this.DoTopAndBottom)
        num1 -= 32;
      if (num1 < 1)
        num1 = 1;
      int num7 = (int) Math.Round((double) (int) Math.Round((double) ((float) num1 / (float) num6 * (float) this.ListObj.ListCount)) - (double) this.ListSize / 2.0);
      if (0 > num7)
        num7 = 0;
      this.TopItem = num7;
      if (this.TopItem > this.ListObj.ListCount - this.ListSize)
        this.TopItem = this.ListObj.ListCount - this.ListSize;
      if (0 > this.TopItem)
        this.TopItem = 0;
      return true;
    }
  }
}
