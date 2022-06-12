// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.ScreenClass
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
  public class ScreenClass
  {
    protected WindowClass[] WindowList;
    protected int[] WindowX;
    protected int[] WindowY;
    protected int[] WindowW;
    protected int[] WindowH;
    protected bool[] WindowInputBlock;
    protected bool[] WindowFlag;
    protected int WindowCounter;
    protected int WindowIDCounter;
    protected int[] WindowID;
    protected Bitmap OwnBitmap;
    public Bitmap OwnBackground;
    public int LastOverlayWindow;
    public GameClass Game;
    protected Form1 FormRef;
    public bool doMinimize;
    public bool doQuit;
    public Rectangle LastToolTipRect;
    public bool AllowRightMouse;

    public void Dispose()
    {
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowList[index].Dispose();
        this.WindowList[index] = (WindowClass) null;
      }
      this.OwnBitmap.Dispose();
      this.OwnBitmap = (Bitmap) null;
      this.OwnBackground.Dispose();
      this.OwnBackground = (Bitmap) null;
      this.Game = (GameClass) null;
      this.FormRef = (Form1) null;
      GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
      Application.DoEvents();
    }

    public bool HasOwnBitmap() => !Information.IsNothing((object) this.OwnBitmap);

    public int GetMemorySize()
    {
      int memorySize = (int) Math.Round((double) (64 * this.OwnBitmap.Width * this.OwnBitmap.Height) / 8000.0);
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
        memorySize += this.WindowList[index].GetMemorySize();
      return memorySize;
    }

    public void RefreshOwnBackground(int backgroundsprite)
    {
      if (Information.IsNothing((object) this.OwnBackground))
      {
        this.OwnBackground = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
        this.OwnBackground.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      Graphics graphics = Graphics.FromImage((Image) this.OwnBackground);
      if (BitmapStore.GetWidth(backgroundsprite) <= 512)
      {
        int width = BitmapStore.GetWidth(backgroundsprite);
        int num1 = BitmapStore.Getheight(backgroundsprite);
        int num2 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenWidth / (double) width));
        for (int index1 = 0; index1 <= num2; ++index1)
        {
          int num3 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenHeight / (double) num1));
          for (int index2 = 0; index2 <= num3; ++index2)
          {
            ref Graphics local1 = ref graphics;
            Bitmap bitmap = BitmapStore.GetBitmap(backgroundsprite);
            ref Bitmap local2 = ref bitmap;
            int x = index1 * width;
            int y = index2 * num1;
            int w = width;
            int h = num1;
            DrawMod.DrawScaled(ref local1, ref local2, x, y, w, h);
          }
        }
      }
      else
      {
        int width = BitmapStore.GetWidth(backgroundsprite);
        int num4 = BitmapStore.Getheight(backgroundsprite);
        float num5 = (float) this.Game.ScreenWidth / (float) width;
        float num6 = (float) this.Game.ScreenHeight / (float) num4;
        if ((double) num5 != (double) num6)
        {
          if ((double) num5 > (double) num6)
            num6 = num5;
          else
            num5 = num6;
          int num7 = (int) Math.Round((double) ((float) width * num5));
          int num8 = (int) Math.Round((double) ((float) num4 * num6));
          int num9 = (int) Math.Round(0.0 + (double) (this.Game.ScreenWidth - num7) / 2.0);
          int num10 = (int) Math.Round(0.0 + (double) (this.Game.ScreenHeight - num8) / 2.0);
          if (num9 > 0)
          {
            num7 += num9;
            num10 -= num9;
            num8 += num9;
            num9 = 0;
          }
          if (num10 > 0)
          {
            num8 += num10;
            num7 += num10;
            num9 -= num10;
            num10 = 0;
          }
          ref Graphics local3 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(backgroundsprite);
          ref Bitmap local4 = ref bitmap;
          int x = num9;
          int y = num10;
          int w = num7;
          int h = num8;
          DrawMod.DrawScaled(ref local3, ref local4, x, y, w, h);
        }
        else
        {
          ref Graphics local5 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(backgroundsprite);
          ref Bitmap local6 = ref bitmap;
          int screenWidth = this.Game.ScreenWidth;
          int screenHeight = this.Game.ScreenHeight;
          DrawMod.DrawScaled(ref local5, ref local6, 0, 0, screenWidth, screenHeight);
        }
      }
      if (Information.IsNothing((object) this.OwnBitmap))
      {
        this.OwnBitmap = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
        this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objGraphics.CompositingMode = CompositingMode.SourceCopy;
      DrawMod.DrawSimple(ref objGraphics, ref this.OwnBackground, 0, 0);
      objGraphics.CompositingMode = CompositingMode.SourceOver;
      this.WindowCounter = -1;
      this.WindowIDCounter = 0;
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
    }

    public ScreenClass(ref GameClass tGame, int backgroundsprite = -1, Form1 tFormRef = null)
    {
      this.Game = tGame;
      this.FormRef = tFormRef;
      this.OwnBackground = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
      this.OwnBackground.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics Expression = Graphics.FromImage((Image) this.OwnBackground);
      switch (backgroundsprite)
      {
        case -4:
          if (Strings.Len(tGame.EditObj.CampaignRoomTitle) > 0 & (double) this.Game.Data.RuleVar[839] == 0.0)
          {
            DrawMod.DrawBlock(ref Expression, 0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight, 0, 0, 0, (int) byte.MaxValue);
            break;
          }
          DrawMod.DrawSimple(ref Expression, ref this.FormRef.StoredScreeny.OwnBitmap, 0, 0);
          DrawMod.DrawBlock(ref Expression, 0, 0, this.Game.ScreenWidth, this.Game.ScreenHeight, 0, 0, 0, 100);
          break;
        case -3:
          DrawMod.Clear(ref Expression, 0, 0, 150);
          break;
        case -2:
          DrawMod.Clear(ref Expression, 0, 0, 0);
          break;
        case -1:
          DrawMod.Clear(ref Expression, 0, 0, 0);
          break;
        default:
          if (BitmapStore.GetWidth(backgroundsprite) <= 512)
          {
            int width = BitmapStore.GetWidth(backgroundsprite);
            int num1 = BitmapStore.Getheight(backgroundsprite);
            int num2 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenWidth / (double) width));
            for (int index1 = 0; index1 <= num2; ++index1)
            {
              int num3 = (int) Math.Round(Conversion.Int((double) this.Game.ScreenHeight / (double) num1));
              for (int index2 = 0; index2 <= num3; ++index2)
              {
                ref Graphics local1 = ref Expression;
                Bitmap bitmap = BitmapStore.GetBitmap(backgroundsprite);
                ref Bitmap local2 = ref bitmap;
                int x = index1 * width;
                int y = index2 * num1;
                int w = width;
                int h = num1;
                DrawMod.DrawScaled(ref local1, ref local2, x, y, w, h);
              }
            }
            break;
          }
          int width1 = BitmapStore.GetWidth(backgroundsprite);
          int num4 = BitmapStore.Getheight(backgroundsprite);
          float num5 = (float) this.Game.ScreenWidth / (float) width1;
          float num6 = (float) this.Game.ScreenHeight / (float) num4;
          if ((double) num5 != (double) num6)
          {
            if ((double) num5 > (double) num6)
              num6 = num5;
            else
              num5 = num6;
            int num7 = (int) Math.Round((double) ((float) width1 * num5));
            int num8 = (int) Math.Round((double) ((float) num4 * num6));
            int num9 = (int) Math.Round(0.0 + (double) (this.Game.ScreenWidth - num7) / 2.0);
            int num10 = (int) Math.Round(0.0 + (double) (this.Game.ScreenHeight - num8) / 2.0);
            if (num9 > 0)
            {
              num7 += num9;
              num10 -= num9;
              num8 += num9;
              num9 = 0;
            }
            if (num10 > 0)
            {
              num8 += num10;
              num7 += num10;
              num9 -= num10;
              num10 = 0;
            }
            ref Graphics local3 = ref Expression;
            Bitmap bitmap = BitmapStore.GetBitmap(backgroundsprite);
            ref Bitmap local4 = ref bitmap;
            int x = num9;
            int y = num10;
            int w = num7;
            int h = num8;
            DrawMod.DrawScaled(ref local3, ref local4, x, y, w, h);
            break;
          }
          ref Graphics local5 = ref Expression;
          Bitmap bitmap1 = BitmapStore.GetBitmap(backgroundsprite);
          ref Bitmap local6 = ref bitmap1;
          int screenWidth = this.Game.ScreenWidth;
          int screenHeight = this.Game.ScreenHeight;
          DrawMod.DrawScaled(ref local5, ref local6, 0, 0, screenWidth, screenHeight);
          break;
      }
      this.OwnBitmap = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
      this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Expression = Graphics.FromImage((Image) this.OwnBitmap);
      Expression.CompositingMode = CompositingMode.SourceCopy;
      DrawMod.DrawSimpleFast(ref Expression, ref this.OwnBackground, ref this.OwnBitmap, 0, 0);
      Expression.CompositingMode = CompositingMode.SourceOver;
      this.WindowCounter = -1;
      this.WindowIDCounter = 0;
      if (Information.IsNothing((object) Expression))
        return;
      Expression.Dispose();
      Expression = (Graphics) null;
    }

    public int GetNr(int id)
    {
      if (this.WindowCounter <= -1)
        return -1;
      int windowCounter = this.WindowCounter;
      for (int nr = 0; nr <= windowCounter; ++nr)
      {
        if (this.WindowID[nr] == id)
          return nr;
      }
      int nr1;
      return nr1;
    }

    public int GetWindowHeight(int id)
    {
      if (this.WindowCounter <= -1)
        return -1;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        if (this.WindowID[index] == id)
          return this.WindowH[index];
      }
      int windowHeight;
      return windowHeight;
    }

    public int GetWindowWidth(int id)
    {
      if (this.WindowCounter <= -1)
        return -1;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        if (this.WindowID[index] == id)
          return this.WindowW[index];
      }
      int windowWidth;
      return windowWidth;
    }

    public void DoRefresh()
    {
      if (this.WindowCounter < 0)
        return;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowFlag[index] = true;
        this.WindowList[index].DoRefresh();
      }
    }

    public void FlagAll()
    {
      if (this.WindowCounter < 0)
        return;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowFlag[index] = true;
        this.WindowList[index].FlagAll();
      }
    }

    public void FlagAllIncludingRefresh()
    {
      if (this.WindowCounter < 0)
        return;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowList[index].Before_DoRefresh_Called_By_FlagAllIncludingRefresh();
        this.WindowList[index].DoRefresh();
        this.WindowFlag[index] = true;
        this.WindowList[index].FlagAll();
      }
    }

    public virtual Bitmap Paint(bool onlyToolTip = false)
    {
      bool flag1 = false;
      if (Information.IsNothing((object) this.OwnBitmap))
      {
        this.OwnBitmap = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
        this.OwnBitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      if (Information.IsNothing((object) this.OwnBackground))
      {
        this.OwnBackground = new Bitmap(this.Game.ScreenWidth, this.Game.ScreenHeight, PixelFormat.Format32bppPArgb);
        this.OwnBackground.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      }
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.LastToolTipRect.Width > 0)
      {
        DrawMod.DrawSimplePart(ref graphics, ref this.OwnBackground, this.LastToolTipRect);
        int num = 1;
        do
        {
          int windowCounter = this.WindowCounter;
          for (int index = 0; index <= windowCounter; ++index)
          {
            if (num == 2 & !(Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 | Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0) | num == 1 & (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 | Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0))
            {
              Rectangle rectangle = new Rectangle(this.WindowX[index], this.WindowY[index], this.WindowW[index], this.WindowH[index]);
              Rectangle destrect = Rectangle.Intersect(this.LastToolTipRect, rectangle);
              if (!destrect.IsEmpty)
              {
                rectangle = destrect;
                rectangle.X -= this.WindowX[index];
                rectangle.Y -= this.WindowY[index];
                rectangle.Width = Math.Min(rectangle.Width, this.WindowW[index]);
                rectangle.Height = Math.Min(rectangle.Height, this.WindowH[index]);
                if (num == 1)
                  DrawMod.DrawSimplePart2(ref graphics, ref this.WindowList[index].SubPartList[0].OwnBitmap, rectangle, destrect);
                else
                  DrawMod.DrawSimplePart2(ref graphics, ref this.WindowList[index].OwnBitmap, rectangle, destrect);
              }
            }
          }
          ++num;
        }
        while (num <= 2);
        this.LastToolTipRect.Width = 0;
      }
      if (!onlyToolTip)
      {
        int windowCounter1 = this.WindowCounter;
        int num;
        for (int index = 0; index <= windowCounter1; ++index)
        {
          if (!Information.IsNothing((object) this.WindowList[index]) && Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 | Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0 && this.WindowFlag[index])
          {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            if (this.WindowList[index].DoShowRect)
              DrawMod.DrawSimplePart2Fast(ref graphics, ref this.WindowList[index].SubPartList[0].OwnBitmap, ref this.OwnBitmap, this.WindowList[index].ShowRect, new Rectangle()
              {
                X = this.WindowX[index] + this.WindowList[index].ShowRect.X,
                Y = this.WindowY[index] + this.WindowList[index].ShowRect.Y,
                Width = this.WindowList[index].ShowRect.Width,
                Height = this.WindowList[index].ShowRect.Height
              });
            else
              DrawMod.DrawSimpleFast(ref graphics, ref this.WindowList[index].SubPartList[0].OwnBitmap, ref this.OwnBitmap, this.WindowX[index], this.WindowY[index]);
            graphics.CompositingMode = CompositingMode.SourceOver;
            ++num;
            this.WindowFlag[index] = false;
            if (flag1)
              DrawMod.DrawRectangle(ref graphics, this.WindowX[index], this.WindowY[index], this.WindowW[index], this.WindowH[index], (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
          }
        }
        int windowCounter2 = this.WindowCounter;
        for (int index1 = 0; index1 <= windowCounter2; ++index1)
        {
          if (!Information.IsNothing((object) this.WindowList[index1]))
          {
            if (!(Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) == 0 | Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.MapWindowClass", false) == 0) && this.WindowFlag[index1])
            {
              Rectangle rectangle1;
              if (!Information.IsNothing((object) this.WindowList[index1].LowerWindow) | this.WindowList[index1].BlockBlit)
              {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                ref Graphics local1 = ref graphics;
                Bitmap bitmap = this.WindowList[index1].Paint();
                ref Bitmap local2 = ref bitmap;
                ref Bitmap local3 = ref this.OwnBitmap;
                int x = this.WindowX[index1];
                int y = this.WindowY[index1];
                DrawMod.DrawSimpleFast(ref local1, ref local2, ref local3, x, y);
                graphics.CompositingMode = CompositingMode.SourceOver;
              }
              else
              {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                Rectangle rectangle2 = new Rectangle();
                if (this.WindowList[index1].QuickDrawMode)
                {
                  int quickRectCount = this.WindowList[index1].QuickRectCount;
                  for (int index2 = 0; index2 <= quickRectCount; ++index2)
                  {
                    rectangle2.X = this.WindowX[index1] + this.WindowList[index1].QuickRect[index2].X;
                    rectangle2.Y = this.WindowY[index1] + this.WindowList[index1].QuickRect[index2].Y;
                    rectangle2.Width = this.WindowList[index1].QuickRect[index2].Width;
                    rectangle2.Height = this.WindowList[index1].QuickRect[index2].Height;
                    DrawMod.DrawSimplePart2(ref graphics, ref this.OwnBackground, rectangle2, rectangle2);
                  }
                }
                else
                {
                  ref Graphics local4 = ref graphics;
                  ref Bitmap local5 = ref this.OwnBackground;
                  rectangle1 = new Rectangle(this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1]);
                  Rectangle rect = rectangle1;
                  DrawMod.DrawSimplePart(ref local4, ref local5, rect);
                }
                graphics.CompositingMode = CompositingMode.SourceOver;
                if (this.WindowList[index1].QuickDrawMode)
                {
                  int quickRectCount = this.WindowList[index1].QuickRectCount;
                  for (int index3 = 0; index3 <= quickRectCount; ++index3)
                  {
                    rectangle2.X = this.WindowX[index1] + this.WindowList[index1].QuickRect[index3].X;
                    rectangle2.Y = this.WindowY[index1] + this.WindowList[index1].QuickRect[index3].Y;
                    rectangle2.Width = this.WindowList[index1].QuickRect[index3].Width;
                    rectangle2.Height = this.WindowList[index1].QuickRect[index3].Height;
                    DrawMod.DrawSimplePart2(ref graphics, ref this.WindowList[index1].OwnBitmap, this.WindowList[index1].QuickRect[index3], rectangle2);
                  }
                  this.WindowList[index1].ResetQuickRect();
                }
                else
                {
                  ref Graphics local6 = ref graphics;
                  Bitmap bitmap = this.WindowList[index1].Paint();
                  ref Bitmap local7 = ref bitmap;
                  int x = this.WindowX[index1];
                  int y = this.WindowY[index1];
                  DrawMod.DrawSimple(ref local6, ref local7, x, y);
                }
              }
              if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.SpecialWindowClass7", false) == 0 && this.WindowCounter >= index1 + 1 && Operators.CompareString(this.WindowList[index1 + 1].GetType().FullName, "WindowsApplication1.ResourceWindowClass2", false) == 0)
                this.WindowFlag[index1 + 1] = true;
              if (this.WindowList[index1].fixshade)
              {
                ref Graphics local8 = ref graphics;
                ref Bitmap local9 = ref this.OwnBackground;
                rectangle1 = new Rectangle(0, this.OwnBitmap.Height - 210, this.OwnBitmap.Width, 10);
                Rectangle rect = rectangle1;
                DrawMod.DrawSimplePart(ref local8, ref local9, rect);
                DrawMod.DrawBlock(ref graphics, 0, this.OwnBitmap.Height - 210, this.OwnBitmap.Width, 10, (int) DrawMod.TGame.VicColor4.R, (int) DrawMod.TGame.VicColor4.G, (int) DrawMod.TGame.VicColor4.B, (int) DrawMod.TGame.VicColor4.A);
                DrawMod.drawLine(ref graphics, 0, this.OwnBitmap.Height - 200, this.OwnBitmap.Width, this.OwnBitmap.Height - 200, (int) DrawMod.TGame.VicColor6.R, (int) DrawMod.TGame.VicColor6.G, (int) DrawMod.TGame.VicColor6.B, (int) DrawMod.TGame.VicColor3.A);
              }
              ++num;
              this.WindowFlag[index1] = false;
              if (flag1)
              {
                int w = this.WindowW[index1] - 10;
                int h = this.WindowH[index1] - 10;
                DrawMod.DrawRectangle(ref graphics, this.WindowX[index1], this.WindowY[index1], w, h, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                DrawMod.drawLine(ref graphics, (int) Math.Round((double) this.WindowX[index1] + (double) w / 2.0), this.WindowY[index1], (int) Math.Round((double) this.WindowX[index1] + (double) w / 2.0), this.WindowY[index1] + h, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
                DrawMod.drawLine(ref graphics, this.WindowX[index1], (int) Math.Round((double) this.WindowY[index1] + (double) h / 2.0), this.WindowX[index1] + w, (int) Math.Round((double) this.WindowY[index1] + (double) h / 2.0), (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
              }
            }
            if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.UnitSelectWindowClass2", false) == 0)
            {
              graphics.CompositingMode = CompositingMode.SourceCopy;
              DrawMod.DrawSimple(ref graphics, ref this.WindowList[index1].SubPartList[0].OwnBitmap, this.WindowX[index1] + 5, this.WindowY[index1] + 60);
              graphics.CompositingMode = CompositingMode.SourceOver;
              if (flag1)
                DrawMod.DrawRectangle(ref graphics, this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1], (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            }
            if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.NonCardSelectWindowClass", false) == 0)
            {
              if (Operators.CompareString(this.WindowList[index1].SubPartList[0].GetType().FullName, "WindowsApplication1.MapPartClass", false) == 0)
              {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                DrawMod.DrawSimple(ref graphics, ref this.WindowList[index1].SubPartList[0].OwnBitmap, this.WindowX[index1] + 5, this.WindowY[index1] + 60);
                graphics.CompositingMode = CompositingMode.SourceOver;
              }
              if (flag1)
                DrawMod.DrawRectangle(ref graphics, this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1], (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            }
            if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.MapSelectWindowClass2", false) == 0)
            {
              graphics.CompositingMode = CompositingMode.SourceCopy;
              DrawMod.DrawSimple(ref graphics, ref this.WindowList[index1].SubPartList[0].OwnBitmap, this.WindowX[index1] + 5, this.WindowY[index1] + 60);
              graphics.CompositingMode = CompositingMode.SourceOver;
              if (flag1)
                DrawMod.DrawRectangle(ref graphics, this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1], (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            }
          }
        }
        if (num > 0 & this.Game.EditObj.TutMode)
          this.DoTutorial3(graphics);
        if (this.Game.Data.Product < 6)
        {
          if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.PlayScreenClass", false) == 0)
          {
            DrawMod.DrawBlock(ref graphics, this.Game.ScreenWidth - 52, 1, 25, 25, 0, 0, 0, (int) byte.MaxValue);
            DrawMod.DrawBlock(ref graphics, this.Game.ScreenWidth - 28, 1, 25, 25, 0, 0, 0, (int) byte.MaxValue);
          }
          Bitmap bitmap1;
          if (this.doMinimize)
          {
            ref Graphics local10 = ref graphics;
            Bitmap bitmap2 = BitmapStore.GetBitmap(this.Game.SYSTEM1B);
            ref Bitmap local11 = ref bitmap2;
            int x = this.Game.ScreenWidth - 52;
            DrawMod.DrawSimple(ref local10, ref local11, x, 1);
          }
          else
          {
            ref Graphics local12 = ref graphics;
            bitmap1 = BitmapStore.GetBitmap(this.Game.SYSTEM1);
            ref Bitmap local13 = ref bitmap1;
            int x = this.Game.ScreenWidth - 52;
            DrawMod.DrawSimple(ref local12, ref local13, x, 1);
          }
          if (this.doQuit)
          {
            ref Graphics local14 = ref graphics;
            bitmap1 = BitmapStore.GetBitmap(this.Game.SYSTEM2B);
            ref Bitmap local15 = ref bitmap1;
            int x = this.Game.ScreenWidth - 28;
            DrawMod.DrawSimple(ref local14, ref local15, x, 1);
          }
          else
          {
            ref Graphics local16 = ref graphics;
            bitmap1 = BitmapStore.GetBitmap(this.Game.SYSTEM2);
            ref Bitmap local17 = ref bitmap1;
            int x = this.Game.ScreenWidth - 28;
            DrawMod.DrawSimple(ref local16, ref local17, x, 1);
          }
        }
        else if (this.Game.Data.Product == 6)
        {
          if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.PlayScreenClass2", false) != 0 && Operators.CompareString(this.GetType().FullName, "WindowsApplication1.MessagePopUpScreenClass2", false) != 0)
          {
            Bitmap bitmap3;
            if (this.doMinimize)
            {
              ref Graphics local18 = ref graphics;
              Bitmap bitmap4 = BitmapStore.GetBitmap(this.Game.SYSTEM1B);
              ref Bitmap local19 = ref bitmap4;
              int x = this.Game.ScreenWidth - 52;
              DrawMod.DrawSimple(ref local18, ref local19, x, 1);
            }
            else
            {
              ref Graphics local20 = ref graphics;
              bitmap3 = BitmapStore.GetBitmap(this.Game.SYSTEM1);
              ref Bitmap local21 = ref bitmap3;
              int x = this.Game.ScreenWidth - 52;
              DrawMod.DrawSimple(ref local20, ref local21, x, 1);
            }
            if (this.doQuit)
            {
              ref Graphics local22 = ref graphics;
              bitmap3 = BitmapStore.GetBitmap(this.Game.SYSTEM2B);
              ref Bitmap local23 = ref bitmap3;
              int x = this.Game.ScreenWidth - 28;
              DrawMod.DrawSimple(ref local22, ref local23, x, 1);
            }
            else
            {
              ref Graphics local24 = ref graphics;
              bitmap3 = BitmapStore.GetBitmap(this.Game.SYSTEM2);
              ref Bitmap local25 = ref bitmap3;
              int x = this.Game.ScreenWidth - 28;
              DrawMod.DrawSimple(ref local24, ref local25, x, 1);
            }
          }
        }
        else if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.RandomScreenClass2", false) == 0 | Operators.CompareString(this.GetType().FullName, "WindowsApplication1.GameLoopScreenClass2", false) == 0)
        {
          DrawMod.DrawBlock(ref graphics, this.Game.ScreenWidth - 52, 1, 25, 25, 0, 0, 0, (int) byte.MaxValue);
          DrawMod.DrawBlock(ref graphics, this.Game.ScreenWidth - 28, 1, 25, 25, 0, 0, 0, (int) byte.MaxValue);
          Bitmap bitmap5;
          if (this.doMinimize)
          {
            ref Graphics local26 = ref graphics;
            Bitmap bitmap6 = BitmapStore.GetBitmap(this.Game.SYSTEM1B);
            ref Bitmap local27 = ref bitmap6;
            int x = this.Game.ScreenWidth - 52;
            DrawMod.DrawSimple(ref local26, ref local27, x, 1);
          }
          else
          {
            ref Graphics local28 = ref graphics;
            bitmap5 = BitmapStore.GetBitmap(this.Game.SYSTEM1);
            ref Bitmap local29 = ref bitmap5;
            int x = this.Game.ScreenWidth - 52;
            DrawMod.DrawSimple(ref local28, ref local29, x, 1);
          }
          if (this.doQuit)
          {
            ref Graphics local30 = ref graphics;
            bitmap5 = BitmapStore.GetBitmap(this.Game.SYSTEM2B);
            ref Bitmap local31 = ref bitmap5;
            int x = this.Game.ScreenWidth - 28;
            DrawMod.DrawSimple(ref local30, ref local31, x, 1);
          }
          else
          {
            ref Graphics local32 = ref graphics;
            bitmap5 = BitmapStore.GetBitmap(this.Game.SYSTEM2);
            ref Bitmap local33 = ref bitmap5;
            int x = this.Game.ScreenWidth - 28;
            DrawMod.DrawSimple(ref local32, ref local33, x, 1);
          }
        }
      }
      if (Information.IsNothing((object) this.Game.EditObj.TipText))
        this.Game.EditObj.TipText = "";
      if (this.Game.EditObj.TipText.Length > 0 & this.Game.ModIntroType >= 1)
      {
        SizeF sizeF1 = new SizeF();
        SizeF sizeF2 = new SizeF();
        string str1 = this.Game.EditObj.TipTitle;
        bool flag2;
        if (Strings.InStr(str1, "<FIXEDSYS>") > 0)
        {
          flag2 = true;
          str1 = str1.Replace("<FIXEDSYS>", "");
        }
        int num1 = 100;
        int num2 = 20;
        string str2 = this.Game.EditObj.TipText;
        string str3 = "";
        int num3 = 0;
        if (Information.IsNothing((object) str2))
          str2 = "";
        while (str2.Length > 0)
        {
          string Left = Strings.Mid(str2, 1, 1);
          if (Operators.CompareString(Left, "\r\n", false) == 0 | Operators.CompareString(Left, "\r", false) == 0 | Operators.CompareString(Left, "\n", false) == 0)
          {
            num3 = 0;
            str3 += Left;
            str2 = Strings.Mid(str2, 2);
          }
          else
          {
            ++num3;
            bool flag3 = false;
            if (Strings.InStr(str2, "\r\n") > 0 & Strings.InStr(str2, "\r\n") <= num2)
              flag3 = true;
            if (Strings.InStr(str2, "\n") > 0 & Strings.InStr(str2, "\n") <= num2)
              flag3 = true;
            if (!flag3 & num3 > num1 && Operators.CompareString(Left, " ", false) == 0)
            {
              Left = "\r\n";
              num3 = 0;
            }
            str3 += Left;
            str2 = Strings.Mid(str2, 2);
          }
        }
        SizeF sizeF3 = !flag2 ? graphics.MeasureString(str3, this.Game.MarcFont4) : graphics.MeasureString(str3, this.Game.MarcFont4b);
        int x1 = this.FormRef.LastTipX + 20;
        int num4 = this.FormRef.LastTipY + 20;
        int num5 = (int) Math.Round((double) (sizeF3.Width + 4f));
        int h = (int) Math.Round((double) (sizeF3.Height + 4f));
        if (str1.Length > 0)
        {
          sizeF2 = !flag2 ? graphics.MeasureString(str1, this.Game.MarcFont4) : graphics.MeasureString(str1, this.Game.MarcFont4b);
          h = (int) Math.Round((double) ((float) (h + 4) + sizeF2.Height));
        }
        float width = sizeF3.Width;
        if ((double) sizeF2.Width > (double) width)
          width = sizeF2.Width;
        int num6 = (int) Math.Round((double) (width + 4f));
        if (x1 + num6 > this.Game.ScreenWidth - 64)
          x1 -= x1 + num6 - (this.Game.ScreenWidth - 64);
        if (num4 + h > this.Game.ScreenHeight - 32)
          num4 -= num4 + h - (this.Game.ScreenHeight - 32);
        this.LastToolTipRect = str1.Length <= 0 ? new Rectangle(x1 - 16, num4, num6 + 1 + 32, h + 1) : new Rectangle(x1 - 16, num4, num6 + 1 + 32, h + 1 + 16);
        int r1 = 240;
        int g1 = 240;
        int b1 = 160;
        int num7 = 40;
        int num8 = 40;
        int num9 = 20;
        if (this.Game.EditObj.TipColor >= 1)
        {
          r1 = (int) byte.MaxValue;
          g1 = 180;
          b1 = 0;
          num7 = 40;
          num8 = 40;
          num9 = 20;
          this.Game.EditObj.TipColor = 0;
        }
        int r2 = num7;
        int g2 = num8;
        int b2 = num9;
        if (flag2)
        {
          r1 = 240;
          g1 = 240;
          b1 = 160;
          num7 = 0;
          num8 = 0;
          num9 = 0;
          r2 = 200;
          g2 = 200;
          b2 = 100;
        }
        if (str1.Length > 0)
        {
          DrawMod.DrawBlock(ref graphics, x1 - 16, num4, num6 + 32, (int) Math.Round((double) (sizeF2.Height + 4f)), r1, g1, b1, (int) byte.MaxValue);
          DrawMod.DrawBlock(ref graphics, x1 - 16, (int) Math.Round((double) num4 + (double) sizeF2.Height + 4.0), num6 + 32, (int) Math.Round((double) h - ((double) sizeF2.Height + 4.0) + 16.0), r2, g2, b2, (int) byte.MaxValue);
          if (flag2)
          {
            DrawMod.DrawTextColouredNicely(ref graphics, str1, this.Game.MarcFont16, x1 + 2, num4 + 2, Color.FromArgb((int) byte.MaxValue, num7, num8, num9));
            DrawMod.DrawTextColouredNicely(ref graphics, str3, this.Game.MarcFont4b, x1 + 3, (int) Math.Round((double) ((float) (num4 + 6 + 8) + sizeF2.Height)), Color.FromArgb(178, 0, 0, 0));
            DrawMod.DrawTextColouredNicely(ref graphics, str3, this.Game.MarcFont4b, x1 + 2, (int) Math.Round((double) ((float) (num4 + 6 + 8) + sizeF2.Height)), Color.Black);
          }
          else
          {
            DrawMod.DrawTextColouredNicely(ref graphics, str1, this.Game.MarcFont16, x1 + 2, num4 + 2, Color.FromArgb((int) byte.MaxValue, num7, num8, num9), 12);
            DrawMod.DrawTextColouredNicely(ref graphics, str3, this.Game.MarcFont4, x1 + 2, (int) Math.Round((double) ((float) (num4 + 8 + 6) + sizeF2.Height)), Color.White);
          }
          DrawMod.DrawRectangle(ref graphics, x1 - 16, num4, num6 + 32, h + 16, r1, g1, b1, (int) byte.MaxValue);
        }
        else if (Operators.CompareString(str3, ".", false) == 0)
        {
          DrawMod.DrawBlock(ref graphics, x1, num4, 8, 4, num7, num8, num9, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref graphics, x1 + 2, num4 + 2, 1, 1, r1, g1, b1, (int) byte.MaxValue);
          DrawMod.DrawRectangle(ref graphics, x1, num4, 8, 4, r1, g1, b1, (int) byte.MaxValue);
        }
        else
        {
          DrawMod.DrawBlock(ref graphics, x1 - 16, num4, num6 + 32, h, num7, num8, num9, (int) byte.MaxValue);
          if (flag2)
            DrawMod.DrawTextColouredNicely(ref graphics, str3, this.Game.MarcFont4b, x1 + 2, num4 + 2, Color.White);
          else
            DrawMod.DrawTextColouredNicely(ref graphics, str3, this.Game.MarcFont4, x1 + 2, num4 + 2, Color.White);
          DrawMod.DrawRectangle(ref graphics, x1 - 16, num4, num6 + 32, h, r1, g1, b1, (int) byte.MaxValue);
        }
      }
      if (!Information.IsNothing((object) graphics))
        graphics.Dispose();
      return this.OwnBitmap;
    }

    public void ClearOverlaySpecificWindow(int id)
    {
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        if (this.WindowID[index] == id)
        {
          this.WindowList[index].clearoverlay();
          this.WindowFlag[index] = true;
          this.LastOverlayWindow = 0;
        }
      }
    }

    public int AddWindow(WindowClass tmpWindow, int x, int y, int w, int h)
    {
      ++this.WindowCounter;
      ++this.WindowIDCounter;
      this.WindowList = (WindowClass[]) Utils.CopyArray((Array) this.WindowList, (Array) new WindowClass[this.WindowCounter + 1]);
      this.WindowFlag = (bool[]) Utils.CopyArray((Array) this.WindowFlag, (Array) new bool[this.WindowCounter + 1]);
      this.WindowX = (int[]) Utils.CopyArray((Array) this.WindowX, (Array) new int[this.WindowCounter + 1]);
      this.WindowInputBlock = (bool[]) Utils.CopyArray((Array) this.WindowInputBlock, (Array) new bool[this.WindowCounter + 1]);
      this.WindowY = (int[]) Utils.CopyArray((Array) this.WindowY, (Array) new int[this.WindowCounter + 1]);
      this.WindowW = (int[]) Utils.CopyArray((Array) this.WindowW, (Array) new int[this.WindowCounter + 1]);
      this.WindowH = (int[]) Utils.CopyArray((Array) this.WindowH, (Array) new int[this.WindowCounter + 1]);
      this.WindowID = (int[]) Utils.CopyArray((Array) this.WindowID, (Array) new int[this.WindowCounter + 1]);
      this.WindowList[this.WindowCounter] = tmpWindow;
      this.WindowList[this.WindowCounter].formref = this.FormRef;
      this.WindowFlag[this.WindowCounter] = true;
      this.WindowX[this.WindowCounter] = x;
      this.WindowY[this.WindowCounter] = y;
      this.WindowW[this.WindowCounter] = w;
      this.WindowH[this.WindowCounter] = h;
      this.WindowID[this.WindowCounter] = this.WindowIDCounter;
      this.WindowList[this.WindowCounter].screenbackref = this.OwnBackground;
      this.WindowList[this.WindowCounter].screenx = x;
      this.WindowList[this.WindowCounter].screeny = y;
      this.WindowList[this.WindowCounter].screenw = w;
      this.WindowList[this.WindowCounter].screenh = h;
      return this.WindowIDCounter;
    }

    public int AddWindow(
      WindowClass tmpWindow,
      int x,
      int y,
      int w,
      int h,
      Rectangle tShowRectangle)
    {
      ++this.WindowCounter;
      ++this.WindowIDCounter;
      this.WindowList = (WindowClass[]) Utils.CopyArray((Array) this.WindowList, (Array) new WindowClass[this.WindowCounter + 1]);
      this.WindowFlag = (bool[]) Utils.CopyArray((Array) this.WindowFlag, (Array) new bool[this.WindowCounter + 1]);
      this.WindowX = (int[]) Utils.CopyArray((Array) this.WindowX, (Array) new int[this.WindowCounter + 1]);
      this.WindowInputBlock = (bool[]) Utils.CopyArray((Array) this.WindowInputBlock, (Array) new bool[this.WindowCounter + 1]);
      this.WindowY = (int[]) Utils.CopyArray((Array) this.WindowY, (Array) new int[this.WindowCounter + 1]);
      this.WindowW = (int[]) Utils.CopyArray((Array) this.WindowW, (Array) new int[this.WindowCounter + 1]);
      this.WindowH = (int[]) Utils.CopyArray((Array) this.WindowH, (Array) new int[this.WindowCounter + 1]);
      this.WindowID = (int[]) Utils.CopyArray((Array) this.WindowID, (Array) new int[this.WindowCounter + 1]);
      this.WindowList[this.WindowCounter] = tmpWindow;
      this.WindowList[this.WindowCounter].formref = this.FormRef;
      this.WindowFlag[this.WindowCounter] = true;
      this.WindowX[this.WindowCounter] = x;
      this.WindowY[this.WindowCounter] = y;
      this.WindowW[this.WindowCounter] = w;
      this.WindowH[this.WindowCounter] = h;
      this.WindowID[this.WindowCounter] = this.WindowIDCounter;
      this.WindowList[this.WindowCounter].screenbackref = this.OwnBackground;
      this.WindowList[this.WindowCounter].screenx = x;
      this.WindowList[this.WindowCounter].screeny = y;
      this.WindowList[this.WindowCounter].screenw = w;
      this.WindowList[this.WindowCounter].screenh = h;
      this.WindowList[this.WindowCounter].ShowRect = tShowRectangle;
      this.WindowList[this.WindowCounter].DoShowRect = true;
      return this.WindowIDCounter;
    }

    public void RemoveWindow(int id)
    {
      int index1 = -1;
      int windowCounter = this.WindowCounter;
      for (int index2 = 0; index2 <= windowCounter; ++index2)
      {
        if (this.WindowID[index2] == id)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == -1 || Information.IsNothing((object) this.WindowList[index1]))
        return;
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (Operators.CompareString(this.WindowList[index1].GetType().FullName, "WindowsApplication1.UdsUnitOpsWindowClass", false) == 0)
      {
        System.Type WC = typeof (MapWindowClass2);
        WindowClass window = this.GetWindow(ref WC);
        Rectangle rect = new Rectangle(this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1]);
        DrawMod.DrawSimplePart(ref objGraphics, ref window.SubPartList[0].OwnBitmap, rect);
      }
      else
      {
        Rectangle rect = new Rectangle(this.WindowX[index1], this.WindowY[index1], this.WindowW[index1], this.WindowH[index1]);
        DrawMod.DrawSimplePart(ref objGraphics, ref this.OwnBackground, rect);
      }
      this.WindowList[index1].Dispose();
      this.WindowList[index1] = (WindowClass) null;
      if (index1 < this.WindowCounter)
      {
        int num1 = index1;
        int num2 = this.WindowCounter - 1;
        for (int index3 = num1; index3 <= num2; ++index3)
        {
          this.WindowList[index3] = this.WindowList[index3 + 1];
          this.WindowFlag[index3] = this.WindowFlag[index3 + 1];
          this.WindowX[index3] = this.WindowX[index3 + 1];
          this.WindowInputBlock[index3] = this.WindowInputBlock[index3 + 1];
          this.WindowY[index3] = this.WindowY[index3 + 1];
          this.WindowW[index3] = this.WindowW[index3 + 1];
          this.WindowH[index3] = this.WindowH[index3 + 1];
          this.WindowID[index3] = this.WindowID[index3 + 1];
        }
      }
      --this.WindowCounter;
      this.WindowList = (WindowClass[]) Utils.CopyArray((Array) this.WindowList, (Array) new WindowClass[this.WindowCounter + 1]);
      this.WindowFlag = (bool[]) Utils.CopyArray((Array) this.WindowFlag, (Array) new bool[this.WindowCounter + 1]);
      this.WindowX = (int[]) Utils.CopyArray((Array) this.WindowX, (Array) new int[this.WindowCounter + 1]);
      this.WindowInputBlock = (bool[]) Utils.CopyArray((Array) this.WindowInputBlock, (Array) new bool[this.WindowCounter + 1]);
      this.WindowY = (int[]) Utils.CopyArray((Array) this.WindowY, (Array) new int[this.WindowCounter + 1]);
      this.WindowW = (int[]) Utils.CopyArray((Array) this.WindowW, (Array) new int[this.WindowCounter + 1]);
      this.WindowH = (int[]) Utils.CopyArray((Array) this.WindowH, (Array) new int[this.WindowCounter + 1]);
      this.WindowID = (int[]) Utils.CopyArray((Array) this.WindowID, (Array) new int[this.WindowCounter + 1]);
      if (Information.IsNothing((object) objGraphics))
        return;
      objGraphics.Dispose();
    }

    public virtual ScreenReturnClass HandleMouseClick(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass;
      return screenReturnClass;
    }

    public virtual void HandleTooltip(int x, int y, bool skipReset = false)
    {
      int num1;
      int index1;
      if (!skipReset)
      {
        this.Game.EditObj.TipColor = 0;
        this.Game.EditObj.TipText = "";
        this.Game.EditObj.TipTitle = "";
        this.Game.EditObj.TipButton = false;
      }
      else
        index1 = num1;
      if (this.Game.ModIntroType == 0 || this.Game.EditObj.InEditor && !this.Game.Data.SimpleEditor)
        return;
      if (!skipReset && this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (index1 = 0; index1 <= windowCounter; ++index1)
        {
          if (x > this.WindowX[index1] & x < this.WindowX[index1] + this.WindowW[index1] && y > this.WindowY[index1] & y < this.WindowY[index1] + this.WindowH[index1])
            this.WindowList[index1].HandleToolTip(x - this.WindowX[index1], y - this.WindowY[index1]);
        }
      }
      if (Information.IsNothing((object) this.Game.EditObj.TipText))
        this.Game.EditObj.TipText = "";
      if (Strings.InStr(this.Game.EditObj.TipText, "<BR>") > 0)
        this.Game.EditObj.TipText = this.Game.EditObj.TipText.Replace("<BR>", "\r\n");
      if (Strings.InStr(this.Game.EditObj.TipText, "<br>") > 0)
        this.Game.EditObj.TipText = this.Game.EditObj.TipText.Replace("<br>", "\r\n");
      if (this.Game.EditObj.TipText.Length > 0)
      {
        int num2 = num2;
      }
      if (this.Game.EditObj.TipText.Length > 90)
      {
        int num3 = -1;
        int Start = 1;
        int num4 = 1;
        while ((num3 == -1 | num3 - Start > 90) & num4 == 1)
        {
          num3 = Strings.InStr(Start, this.Game.EditObj.TipText, "\r\n");
          num4 = 0;
          if (num3 == 0 | num3 - Start > 90 && this.Game.EditObj.TipText.Length - Start > 90)
          {
            int num5 = Start;
            int num6;
            while (num5 - Start < 90)
            {
              num6 = num5;
              num5 = Strings.InStr(num5 + 1, this.Game.EditObj.TipText, " ");
              if (num5 == 0)
                break;
            }
            int num7 = num6;
            if (num7 > 0 & num7 - Start < 90)
            {
              num4 = 1;
              this.Game.EditObj.TipText = Strings.Left(this.Game.EditObj.TipText, num7 - 1) + "\r\n" + Strings.Right(this.Game.EditObj.TipText, this.Game.EditObj.TipText.Length - num7);
              Start = num7 + 1;
            }
          }
        }
      }
      if (!Information.IsNothing((object) this.FormRef))
      {
        if (!(this.FormRef.RightMousePressed | this.Game.EditObj.MouseOverVisible) & this.Game.EditObj.TipText.Length > 0)
        {
          this.Game.EditObj.TipTitle = "";
          this.Game.EditObj.TipText = "";
          if (this.Game.EditObj.TipButton)
          {
            if (!(this.FormRef.Cursor == Cursors.WaitCursor))
              this.FormRef.Cursor = Cursors.Hand;
          }
          else if (!(this.FormRef.Cursor == Cursors.WaitCursor))
            this.FormRef.Cursor = Cursors.Help;
        }
        else if (!((this.FormRef.RightMousePressed | this.Game.EditObj.MouseOverVisible) & this.Game.EditObj.TipText.Length > 0) && !(this.FormRef.Cursor == Cursors.WaitCursor) & !(this.FormRef.Cursor == Cursors.Default))
          this.FormRef.Cursor = Cursors.Default;
      }
      num1 = Operators.CompareString(this.Game.EditObj.TipText, "", false) != 0 ? index1 : index1;
      if (((this.Game.Data.Product >= 7 ? 1 : 0) & 0) == 0 || this.Game.HelpCounter <= -1 || Strings.InStr(this.Game.EditObj.TipText, "@") <= 0)
        return;
      SimpleStringList simpleStringList = new SimpleStringList();
      int Start1 = Strings.InStr(this.Game.EditObj.TipText, "@");
      if (Start1 <= 0)
        return;
      int num8 = Strings.InStr(Start1 + 1, this.Game.EditObj.TipText, "@");
      if (num8 <= 0)
        return;
      string str = Strings.Mid(this.Game.EditObj.TipText, Start1, num8 - Start1 + 1);
      string oldValue = str;
      string[] strArray = str.Replace("@", "").Split(':');
      string newValue = "";
      if (strArray.Length >= 2)
      {
        int helpCounter = this.Game.HelpCounter;
        for (int index2 = 0; index2 <= helpCounter; ++index2)
        {
          if (Operators.CompareString(this.Game.HelpFile[index2], strArray[1], false) == 0 && Operators.CompareString(this.Game.HelpDir[index2], strArray[0], false) == 0)
          {
            newValue = this.Game.HelpText[index2];
            break;
          }
        }
      }
      else if (strArray.Length < 1)
        ;
      this.Game.EditObj.TipText = this.Game.EditObj.TipText.Replace(oldValue, newValue);
    }

    public virtual ScreenReturnClass HandleMouseUp(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      screenReturnClass.flag = false;
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        WindowReturnClass windowReturnClass = this.WindowList[index].HandleMouseUp(x - this.WindowX[index], y - this.WindowY[index], b);
        this.WindowFlag[index] = windowReturnClass.Flag;
        if (windowReturnClass.Flag)
          screenReturnClass.flag = windowReturnClass.Flag;
      }
      return screenReturnClass;
    }

    public virtual void HandleBLOCKEDMouseUp(int x, int y, int b)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      screenReturnClass.flag = false;
      if (this.WindowCounter <= -1)
        return;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        if (!Information.IsNothing((object) this.WindowList[index]))
        {
          WindowReturnClass windowReturnClass = this.WindowList[index].HandleBLOCKEDMouseUp(x - this.WindowX[index], y - this.WindowY[index], b);
          this.WindowFlag[index] = windowReturnClass.Flag;
          if (windowReturnClass.Flag)
            screenReturnClass.flag = windowReturnClass.Flag;
        }
      }
    }

    public virtual ScreenReturnClass HandleKeyPress(int nr)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[index].HandleKeyPress(nr);
        this.WindowFlag[index] = windowReturnClass2.Flag;
        if (windowReturnClass2.Flag)
          return screenReturnClass;
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }

    public virtual ScreenReturnClass HandleKeyup(int nr)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[index].HandleKeyup(nr);
        this.WindowFlag[index] = windowReturnClass2.Flag;
      }
      screenReturnClass.flag = true;
      return screenReturnClass;
    }

    public virtual ScreenReturnClass HandleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      bool flag = false;
      int windowCounter = this.WindowCounter;
      for (int index1 = 0; index1 <= windowCounter; ++index1)
      {
        WindowReturnClass windowReturnClass2 = this.WindowList[index1].handleTimer();
        this.WindowFlag[index1] = windowReturnClass2.Flag;
        if (this.WindowFlag[index1])
          flag = true;
        if (windowReturnClass2.Counter > -1)
        {
          int counter = windowReturnClass2.Counter;
          for (int index2 = 0; index2 <= counter; ++index2)
          {
            if (windowReturnClass2.CommandType[index2] == 3)
            {
              screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
              return screenReturnClass;
            }
          }
        }
      }
      screenReturnClass.flag = flag;
      return screenReturnClass;
    }

    public virtual ScreenReturnClass HandleTimerWheel(int x, int y)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (int index1 = 0; index1 <= windowCounter; ++index1)
        {
          if (x > this.WindowX[index1] & y > this.WindowY[index1] & x < this.WindowX[index1] + this.WindowW[index1] & y < this.WindowY[index1] + this.WindowH[index1])
          {
            WindowReturnClass windowReturnClass2 = this.WindowList[index1].handleTimerWheel(x - this.WindowX[index1], y - this.WindowY[index1]);
            if (windowReturnClass2.Flag)
            {
              screenReturnClass.flag = true;
              this.WindowFlag[index1] = true;
              if (windowReturnClass2.Counter > -1)
              {
                int counter = windowReturnClass2.Counter;
                for (int index2 = 0; index2 <= counter; ++index2)
                {
                  if (windowReturnClass2.CommandType[index2] == 3)
                  {
                    screenReturnClass.NewScreen = windowReturnClass2.CommandData[index2];
                    return screenReturnClass;
                  }
                }
              }
              return screenReturnClass;
            }
            screenReturnClass.flag = false;
            return screenReturnClass;
          }
        }
        this.Game.EditObj.MouseWheel = 0;
        screenReturnClass.flag = false;
        return screenReturnClass;
      }
      this.Game.EditObj.MouseWheel = 0;
      screenReturnClass.flag = false;
      return screenReturnClass;
    }

    public virtual ScreenReturnClass HandleMouseMove(int x, int y)
    {
      ScreenReturnClass screenReturnClass = new ScreenReturnClass();
      if (this.WindowCounter <= -1)
        return screenReturnClass;
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        this.WindowList[index].MouseInThisWindow = false;
        if (x >= this.WindowX[index] & x < this.WindowX[index] + this.WindowW[index] && y >= this.WindowY[index] & y < this.WindowY[index] + this.WindowH[index])
          this.WindowList[index].MouseInThisWindow = true;
        WindowReturnClass windowReturnClass = this.WindowList[index].HandleMouseMove(x - this.WindowX[index], y - this.WindowY[index]);
        this.WindowFlag[index] = windowReturnClass.Flag;
        if (windowReturnClass.Overlay | this.LastOverlayWindow > 0)
        {
          if (this.LastOverlayWindow > 0 & this.LastOverlayWindow != this.WindowID[index])
            this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
          if (this.LastOverlayWindow > 0 & !windowReturnClass.Overlay)
            this.LastOverlayWindow = 0;
          if (windowReturnClass.Overlay)
            this.LastOverlayWindow = this.WindowID[index];
          screenReturnClass.flag = true;
          return screenReturnClass;
        }
        if (windowReturnClass.Flag)
        {
          screenReturnClass.flag = windowReturnClass.Flag;
          return screenReturnClass;
        }
      }
      if (this.LastOverlayWindow > 0)
      {
        this.ClearOverlaySpecificWindow(this.LastOverlayWindow);
        screenReturnClass.flag = true;
      }
      else
        screenReturnClass.flag = false;
      if (this.Game.Data.Product < 7)
      {
        if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        {
          if (!this.doMinimize)
          {
            this.doMinimize = true;
            screenReturnClass.flag = true;
          }
        }
        else if (this.doMinimize)
        {
          this.doMinimize = false;
          screenReturnClass.flag = true;
        }
        if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25)
        {
          if (!this.doQuit)
          {
            this.doQuit = true;
            screenReturnClass.flag = true;
          }
        }
        else if (this.doQuit)
        {
          this.doQuit = false;
          screenReturnClass.flag = true;
        }
      }
      else if (Operators.CompareString(this.GetType().FullName, "WindowsApplication1.RandomScreenClass2", false) == 0 | Operators.CompareString(this.GetType().FullName, "WindowsApplication1.GameLoopMainWindowClass2", false) == 0)
      {
        if (x > this.Game.ScreenWidth - 52 & x < this.Game.ScreenWidth - 28 & y < 25)
        {
          if (!this.doMinimize)
          {
            this.doMinimize = true;
            screenReturnClass.flag = true;
          }
        }
        else if (this.doMinimize)
        {
          this.doMinimize = false;
          screenReturnClass.flag = true;
        }
        if (x > this.Game.ScreenWidth - 28 & x < this.Game.ScreenWidth - 4 & y < 25)
        {
          if (!this.doQuit)
          {
            this.doQuit = true;
            screenReturnClass.flag = true;
          }
        }
        else if (this.doQuit)
        {
          this.doQuit = false;
          screenReturnClass.flag = true;
        }
      }
      return screenReturnClass;
    }

    public void DoTutorial(Graphics g)
    {
      Color color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 28, 0);
      this.Game.EditObj.Zoom = 0;
      System.Type WC1 = typeof (IntroWindowClass2);
      if (this.WindowPresent(ref WC1))
      {
        this.Game.EditObj.TutStep = 0;
        DrawMod.DrawTutback(g, 5, 5, 960, 160, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        DrawMod.DrawTextColouredOutline(ref g, "Hi! Let me introduce myself. I am Vic, the designer of the game. Welcome to the tutorial. It will go over some ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "key concepts and orders. The tutorial is not exhaustive and it is advised that you read the manual too.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "One of the most important things for new players to know is that you can right click on everything where the mouse", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 70, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "shows a question mark or hand.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 95, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "Now please press 'start' to start the tutorial.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 135, Color.White);
        int num1 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
        int num2 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
        int num3 = num1 + 845;
        int num4 = num2 + 650;
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
        ref Bitmap local2 = ref bitmap;
        int x = num3;
        int y = num4;
        DrawMod.DrawSimple(ref local1, ref local2, x, y);
      }
      else
      {
        System.Type WC2 = typeof (CombatResultWindowClass2);
        int num5;
        if (this.WindowPresent(ref WC2))
        {
          int num6 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
          num5 = 0;
          if (this.Game.EditObj.TutStep == 13 | this.Game.EditObj.TutStep == 18)
          {
            this.Game.EditObj.TutStep = 18;
            this.Game.EditObj.TutX = (object) 12;
            this.Game.EditObj.TutY = (object) 7;
            this.Game.EditObj.TutOrder = 9999;
            DrawMod.DrawTutback(g, 5, 5, 800, 200, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "The battle is being fought combat round by combat round.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
            if ((uint) this.Game.TempCombat.BattleEnded > 0U)
            {
              DrawMod.DrawTextColouredOutline(ref g, "And once ended you can inspect the battle details or return back to the main screen. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Lets go back to main screen. Click OK.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Note: What your basically seeing in the battle screen is each side's participating units.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 100, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Each unit's troops are displayed. Troops in the middle columns are still participating ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 120, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "in combat. And troops in the side columns have been killed or have retreated from combat.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 140, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Battle ends when one of the sides has no troops participating anymore. In a nutshell ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 160, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "that is what happens. If you are not easily shaken then click on DETAILS to see whats really going on.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 180, Color.White);
            }
            int num7 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0);
            int num8 = (int) Math.Round((double) this.Game.ScreenHeight / 2.0);
            int x1_1 = num7 - 200;
            int y1 = num8 - 150;
            DrawMod.DrawBlock(ref g, x1_1, y1, 5, 300, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawBlock(ref g, x1_1 + 90, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "PARTICIPATING TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), x1_1 + 95, y1 + 20, Color.White);
            int num9 = x1_1 - 350;
            DrawMod.DrawBlock(ref g, num9 + 110, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "RETREATED TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), num9 + 120, y1 + 20, Color.White);
            int x1_2 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0) + 190;
            DrawMod.DrawBlock(ref g, x1_2, y1, 5, 300, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            int num10 = x1_2 - 80;
            DrawMod.DrawBlock(ref g, num10 + 110, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "RETREATED TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), num10 + 120, y1 + 20, Color.White);
            int num11 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0);
            int num12 = (int) Math.Round((double) this.Game.ScreenHeight / 2.0);
            num5 = 1;
          }
          if (!(this.Game.EditObj.TutStep == 27 | this.Game.EditObj.TutStep == 30))
            return;
          this.Game.EditObj.TutStep = 30;
          this.Game.EditObj.TutX = (object) -1;
          this.Game.EditObj.TutY = (object) -1;
          this.Game.Data.MapObj[0].HexObj[this.Game.EditObj.TargetX, this.Game.EditObj.TargetY].set_BattlePenalty(0, 12);
          DrawMod.DrawTutback(g, 5, 5, 900, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
          DrawMod.DrawTextColouredOutline(ref g, "And another battle commences.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
          if ((uint) this.Game.TempCombat.BattleEnded > 0U)
            DrawMod.DrawTextColouredOutline(ref g, "And of course won by your stronger forces. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
          num5 = 1;
        }
        else
        {
          System.Type WC3 = typeof (PlayExtraWindowClass2);
          int num13 = this.WindowPresent(ref WC3) ? 1 : 0;
          System.Type WC4 = typeof (StrategicWindowClass2);
          int num14 = this.WindowPresent(ref WC4) ? 1 : 0;
          if ((num13 | num14) != 0)
          {
            int num15 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
            num5 = 0;
            if (this.Game.EditObj.TutStep == 30)
            {
              DrawMod.DrawTutback(g, 5, 5, 850, 210, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see a black box with a number on the hex you just conquered. This is so called remaining 'battle AP penalty' ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "and it will cause a movement penalty on units that did not participate in the combat for taking the hex. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "(This rule makes it possible for the defender to delay the whole enemy army with one properly defended roadblock)", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "And that concludes this short tutorial. It handled some key concepts, but I advise you to read the manual now.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "In a normal game you would now press", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 105, Color.White);
              ref Graphics local3 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.MARCBACK4);
              ref Bitmap local4 = ref bitmap;
              DrawMod.DrawSimple(ref local3, ref local4, 95, 138);
              ref Graphics local5 = ref g;
              bitmap = BitmapStore.GetBitmap(this.Game.BUTTONNEXT);
              ref Bitmap local6 = ref bitmap;
              DrawMod.DrawSimple(ref local5, ref local6, 95, 138);
              DrawMod.DrawTextColouredOutline(ref g, "the next turn button, but the tutorial has no next turn. You have to use the 'quit' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 130, 155, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "It's in the top-right corner. I will be available on the forums for any questions. Thanks for your attention and happy gaming!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 180, Color.White);
              int num16 = this.Game.ScreenWidth - 20;
              int y1 = 35;
              DrawMod.drawLine(ref g, num16, y1, num16, y1 + 40, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              DrawMod.drawLine(ref g, num16, y1, num16 - 10, y1 + 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              DrawMod.drawLine(ref g, num16, y1, num16 + 10, y1 + 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              num5 = 1;
            }
            int num17 = 0;
            Bitmap bitmap1;
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.TempUnitList.counter > -1)
            {
              int num18 = num15 + 825;
              int num19 = this.Game.ScreenHeight - 360;
              ref Graphics local7 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local8 = ref bitmap1;
              int x = num18;
              int y = num19;
              DrawMod.DrawSimple(ref local7, ref local8, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Alright and now press attack!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.EditObj.OrderType == 2)
            {
              this.Game.EditObj.TutStep = 27;
              int num20 = num15 + 956;
              int num21 = this.Game.ScreenHeight - 360;
              ref Graphics local9 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local10 = ref bitmap1;
              int x = num20;
              int y = num21;
              DrawMod.DrawSimple(ref local9, ref local10, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "To select all available units to join in the attack press the 'ALL' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.SelectX == 15 & this.Game.SelectY == 4)
            {
              if (this.Game.EditObj.TutOrder != 2)
              {
                this.Game.EditObj.TutOrder = 2;
                Graphics g1 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local11 = ref WC4;
                this.PaintPresentWindow(g1, ref local11);
                Graphics g2 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local12 = ref WC4;
                this.PaintPresentWindow(g2, ref local12);
                Graphics g3 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local13 = ref WC4;
                this.PaintPresentWindow(g3, ref local13);
              }
              int num22 = num15 + 75;
              int num23 = this.Game.ScreenHeight - 360;
              ref Graphics local14 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local15 = ref bitmap1;
              int x = num22;
              int y = num23;
              DrawMod.DrawSimple(ref local14, ref local15, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Alright. Now click the attack button so you can start to select the participants in the attack on this hex.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if ((this.Game.EditObj.TutStep == 24 | this.Game.EditObj.TutStep == 27) & num17 == 0 && Operators.CompareString(this.Game.Data.UnitObj[this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(281)].HQ].Name, "OKH", false) == 0)
            {
              this.Game.EditObj.TutStep = 27;
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                this.Game.EditObj.TutX = (object) 15;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g4 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local16 = ref WC4;
                this.PaintPresentWindow(g4, ref local16);
                Graphics g5 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local17 = ref WC4;
                this.PaintPresentWindow(g5, ref local17);
                Graphics g6 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local18 = ref WC4;
                this.PaintPresentWindow(g6, ref local18);
              }
              DrawMod.DrawTutback(g, 5, 5, 960, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Very well. You can see the HQ change reflected in the colored bar of the unit. It's now brown just as the OKH. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now I will show the concept of battle AP penalties. For this you have to start a battle first. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on the selected enemy unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 24 & num17 == 0 && this.Game.EditObj.OrderType == 3)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g7 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local19 = ref WC4;
                this.PaintPresentWindow(g7, ref local19);
                Graphics g8 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local20 = ref WC4;
                this.PaintPresentWindow(g8, ref local20);
                Graphics g9 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local21 = ref WC4;
                this.PaintPresentWindow(g9, ref local21);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "The game wants to know what unit should be the new HQ for the motorized regiment.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on the OKH and then on the confirm button to make that the HQ.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.SelectX == 8 & this.Game.SelectY == 7)
              {
                int num24 = num15 + 723;
                int num25 = this.Game.ScreenHeight - 360;
                ref Graphics local22 = ref g;
                bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
                ref Bitmap local23 = ref bitmap1;
                int x = num24;
                int y = num25;
                DrawMod.DrawSimple(ref local22, ref local23, x, y);
              }
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 24 & num17 == 0 && this.Game.SelectX == 10 & this.Game.SelectY == 4 && !this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 24;
              if (this.Game.EditObj.TutOrder != 3)
              {
                this.Game.EditObj.TutOrder = 3;
                Graphics g10 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local24 = ref WC4;
                this.PaintPresentWindow(g10, ref local24);
                Graphics g11 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local25 = ref WC4;
                this.PaintPresentWindow(g11, ref local25);
                Graphics g12 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local26 = ref WC4;
                this.PaintPresentWindow(g12, ref local26);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have now selected the Motorized Unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Click the highlighted 'HQ' order.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              int num26 = num15 + 143;
              int num27 = this.Game.ScreenHeight - 360;
              ref Graphics local27 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local28 = ref bitmap1;
              int x = num26;
              int y = num27;
              DrawMod.DrawSimple(ref local27, ref local28, x, y);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 24 & num17 == 0 && !(this.Game.SelectX == 10 & this.Game.SelectY == 4) && !this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 24;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutY, (object) 4, false))))
              {
                this.Game.EditObj.TutX = (object) 10;
                this.Game.EditObj.TutY = (object) 4;
                this.Game.SelectX = 8;
                this.Game.SelectY = 6;
                Graphics g13 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local29 = ref WC4;
                this.PaintPresentWindow(g13, ref local29);
                Graphics g14 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local30 = ref WC4;
                this.PaintPresentWindow(g14, ref local30);
                Graphics g15 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local31 = ref WC4;
                this.PaintPresentWindow(g15, ref local31);
                Graphics g16 = g;
                WC4 = typeof (PlayExtraWindowClass2);
                ref System.Type local32 = ref WC4;
                this.PaintPresentWindow(g16, ref local32);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Now I'll show how to change a units HQ. Please now select the Motorized Regiment.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              int num28 = num15 + 143;
              int num29 = this.Game.ScreenHeight - 360;
              ref Graphics local33 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local34 = ref bitmap1;
              int x = num28;
              int y = num29;
              DrawMod.DrawSimple(ref local33, ref local34, x, y);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 21 | this.Game.EditObj.TutStep == 24 && this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 24;
              DrawMod.DrawTutback(g, 5, 5, 870, 80, (int) color.R, (int) color.G, (int) color.B, (int) color.A, true);
              DrawMod.DrawTextColouredOutline(ref g, "You see that the supply flowing through I Corps is strained. This is because the supply from I Corps source, the OKH,", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "has to cross the rivers with blown bridges to get to I Corps. This already costs 148 AP.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Supply being issued from I Corps thus starts with a huge penalty already. De-activate supply layer now please.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              int num30 = num15 + 38;
              int num31 = this.Game.ScreenHeight - 360;
              ref Graphics local35 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local36 = ref bitmap1;
              int x = num30;
              int y = num31;
              DrawMod.DrawSimple(ref local35, ref local36, x, y);
              num5 = 1;
              num17 = 1;
            }
            if ((this.Game.EditObj.TutStep == 20 | this.Game.EditObj.TutStep == 21) & num17 == 0 && !this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 21;
              this.Game.EditObj.TutOrder = 51;
              int num32 = num15 + 770;
              int num33 = this.Game.ScreenHeight - 360;
              ref Graphics local37 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local38 = ref bitmap1;
              int x = num32;
              int y = num33;
              DrawMod.DrawSimple(ref local37, ref local38, x, y);
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 10, false))))
              {
                this.Game.EditObj.TutX = (object) 10;
                this.Game.EditObj.TutY = (object) 0;
                Graphics g17 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local39 = ref WC4;
                this.PaintPresentWindow(g17, ref local39);
                Graphics g18 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local40 = ref WC4;
                this.PaintPresentWindow(g18, ref local40);
                Graphics g19 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local41 = ref WC4;
                this.PaintPresentWindow(g19, ref local41);
                Graphics g20 = g;
                WC4 = typeof (PlayExtraWindowClass2);
                ref System.Type local42 = ref WC4;
                this.PaintPresentWindow(g20, ref local42);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 55, (int) color.R, (int) color.G, (int) color.B, (int) color.A, true);
              DrawMod.DrawTextColouredOutline(ref g, "I was saying the Motorized Regiment has the I Corps as its HQ.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select the I Corps and press the supply layer button again.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
            }
            int num34 = 0;
            if (this.Game.EditObj.TutStep == 19 | this.Game.EditObj.TutStep == 20 && this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 20;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 10, false))))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 0;
                Graphics g21 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local43 = ref WC4;
                this.PaintPresentWindow(g21, ref local43);
                Graphics g22 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local44 = ref WC4;
                this.PaintPresentWindow(g22, ref local44);
                Graphics g23 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local45 = ref WC4;
                this.PaintPresentWindow(g23, ref local45);
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 175, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "That's it. You now see how supply flows from your HQ to your units. Click on a hex of choice to see exact path.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Click on back button to hide the supply layer again.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "There is something important here you have to understand. It may seem to you that the", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Motorized Regiment is in green supply zone. However the red supply sign on its counter is a tell-tale", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "it is not getting enough supply. Why? That is because supply comes from I Corps and not from the OKH.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 105, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "If you would have selected I Corps as HQ and then activated supply layer you would have seen a different picture.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 130, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "You will check how the situation looks from I Corps after you have closed the supply layer again.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 155, Color.White);
              int num35 = num15 + 38;
              int num36 = this.Game.ScreenHeight - 360;
              ref Graphics local46 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local47 = ref bitmap1;
              int x = num35;
              int y = num36;
              DrawMod.DrawSimple(ref local46, ref local47, x, y);
              num5 = 1;
              num34 = 1;
            }
            if ((this.Game.EditObj.TutStep == 18 | this.Game.EditObj.TutStep == 19) & num34 == 0 && this.Game.Data.MapObj[0].HexObj[6, 8].UnitCounter > -1)
            {
              this.Game.EditObj.TutStep = 19;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 8, false))))
              {
                this.Game.EditObj.TutX = (object) 8;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g24 = g;
                WC4 = typeof (StrategicWindowClass2);
                ref System.Type local48 = ref WC4;
                this.PaintPresentWindow(g24, ref local48);
                Graphics g25 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local49 = ref WC4;
                this.PaintPresentWindow(g25, ref local49);
                Graphics g26 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local50 = ref WC4;
                this.PaintPresentWindow(g26, ref local50);
                Graphics g27 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local51 = ref WC4;
                this.PaintPresentWindow(g27, ref local51);
              }
              DrawMod.DrawTutback(g, 5, 5, 960, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "That's how you strategically transfer units. Now I will show how the supply layer can be activated.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "For this you need to select a HQ and then press the supply layer button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select the OKH unit and activate the supply layer!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              this.Game.EditObj.TutOrder = 51;
              int num37 = num15 + 770;
              int num38 = this.Game.ScreenHeight - 360;
              ref Graphics local52 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local53 = ref bitmap1;
              int x = num37;
              int y = num38;
              DrawMod.DrawSimple(ref local52, ref local53, x, y);
              num34 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 && this.Game.EditObj.OrderType == 18)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 6, false))))
              {
                this.Game.EditObj.TutX = (object) 6;
                this.Game.EditObj.TutY = (object) 8;
                Graphics g28 = g;
                WC4 = typeof (StrategicWindowClass2);
                ref System.Type local54 = ref WC4;
                this.PaintPresentWindow(g28, ref local54);
                Graphics g29 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local55 = ref WC4;
                this.PaintPresentWindow(g29, ref local55);
                Graphics g30 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local56 = ref WC4;
                this.PaintPresentWindow(g30, ref local56);
                Graphics g31 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local57 = ref WC4;
                this.PaintPresentWindow(g31, ref local57);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "The hexes you can strategically transfer the unit to are highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select the highlighted hex and press the big 'transfer' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) this.Game.SelectX, false), Operators.CompareObjectEqual(this.Game.EditObj.TutY, (object) this.Game.SelectY, false))))
              {
                int num39 = num15 + 735;
                int num40 = this.Game.ScreenHeight - 200;
                ref Graphics local58 = ref g;
                bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
                ref Bitmap local59 = ref bitmap1;
                int x = num39;
                int y = num40;
                DrawMod.DrawSimple(ref local58, ref local59, x, y);
              }
              num34 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num34 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 283)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g32 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local60 = ref WC4;
                this.PaintPresentWindow(g32, ref local60);
                Graphics g33 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local61 = ref WC4;
                this.PaintPresentWindow(g33, ref local61);
                Graphics g34 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local62 = ref WC4;
                this.PaintPresentWindow(g34, ref local62);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Yes thats the engineer unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now to strategically transfer this unit you press the strategic transfer button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 18)
              {
                this.Game.EditObj.TutOrder = 18;
                Graphics g35 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g35, ref local);
              }
              int num41 = num15 + 165;
              int num42 = this.Game.ScreenHeight - 360;
              ref Graphics local63 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local64 = ref bitmap1;
              int x = num41;
              int y = num42;
              DrawMod.DrawSimple(ref local63, ref local64, x, y);
              num34 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 & num34 == 0)
            {
              this.Game.EditObj.TutOrder = 9999;
              DrawMod.DrawTutback(g, 5, 5, 720, 155, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how attacks work. Artillery and Air attack work more or less the same.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "You now see a black oval shape with a number on top of the hex you just attacked.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "This is remembered 'battle stack points' and they will be added to the 'stack' total of your next attack.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "(basically this rule will make it impossible to keep attacking a specific hex over and over)", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now lets see how to do a strategic transfer.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 105, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select your highlighted Engineer Unit!.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 130, Color.White);
              int unitCounter = this.Game.Data.UnitCounter;
              for (int index1 = 0; index1 <= unitCounter; ++index1)
              {
                if (Operators.CompareString(this.Game.Data.UnitObj[index1].Name, "Assault Brigade", false) == 0)
                {
                  int sfCount = this.Game.Data.UnitObj[index1].SFCount;
                  for (int index2 = 0; index2 <= sfCount; ++index2)
                    this.Game.Data.SFObj[this.Game.Data.UnitObj[index1].SFList[index2]].Ap = 100;
                }
              }
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 12, false))))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g36 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local65 = ref WC4;
                this.PaintPresentWindow(g36, ref local65);
                Graphics g37 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local66 = ref WC4;
                this.PaintPresentWindow(g37, ref local66);
                Graphics g38 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local67 = ref WC4;
                this.PaintPresentWindow(g38, ref local67);
              }
              num34 = 1;
            }
            if (this.Game.EditObj.TutStep == 13 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.TempUnitList.counter > -1)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "After you have selected one or more units to join the attack you can actually begin the attack. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Lets do so. Press the attack button! ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num34 = 1;
              int num43 = num15 + 842;
              int num44 = this.Game.ScreenHeight - 360;
              ref Graphics local68 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local69 = ref bitmap1;
              int x = num43;
              int y = num44;
              DrawMod.DrawSimple(ref local68, ref local69, x, y);
            }
            if (this.Game.EditObj.TutStep == 13 & num34 == 0 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.UnitSelected > -1 && this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 277)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "To let the Grenzschutz unit participate in the attack we", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "click the indicated button. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num34 = 1;
              int num45 = num15 + 722;
              int num46 = this.Game.ScreenHeight - 360;
              ref Graphics local70 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local71 = ref bitmap1;
              int x = num45;
              int y = num46;
              DrawMod.DrawSimple(ref local70, ref local71, x, y);
            }
            if (this.Game.EditObj.TutStep == 13 & num34 == 0 && this.Game.EditObj.OrderType == 2)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g39 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local72 = ref WC4;
                this.PaintPresentWindow(g39, ref local72);
                Graphics g40 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local73 = ref WC4;
                this.PaintPresentWindow(g40, ref local73);
                Graphics g41 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local74 = ref WC4;
                this.PaintPresentWindow(g41, ref local74);
              }
              this.Game.EditObj.TutOrder = -1;
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Attack planning has started. You now have to select friendly and adjacent units to participate in the attack.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on our Grenzschutz unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num34 = 1;
            }
            if (this.Game.EditObj.TutStep == 13 & this.Game.SelectX == 15 & this.Game.SelectY == 4 & num34 == 0)
            {
              if (this.Game.EditObj.TutOrder != 2)
              {
                this.Game.EditObj.TutOrder = 2;
                Graphics g42 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local75 = ref WC4;
                this.PaintPresentWindow(g42, ref local75);
                Graphics g43 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local76 = ref WC4;
                this.PaintPresentWindow(g43, ref local76);
                Graphics g44 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local77 = ref WC4;
                this.PaintPresentWindow(g44, ref local77);
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have selected the enemy hex/unit. You always need to do this before you can order an attack on it.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please now click on the attack button to start planning an attack on the hex. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              int num47 = num15 + 70;
              int num48 = this.Game.ScreenHeight - 375;
              ref Graphics local78 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local79 = ref bitmap1;
              int x = num47;
              int y = num48;
              DrawMod.DrawSimple(ref local78, ref local79, x, y);
              num34 = 1;
            }
            if ((this.Game.EditObj.TutStep == 11 | this.Game.EditObj.TutStep == 13) & num34 == 0 && this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(178)].DidMove)
            {
              this.Game.EditObj.TutStep = 13;
              if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 12, false), Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) 15;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g45 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local80 = ref WC4;
                this.PaintPresentWindow(g45, ref local80);
                Graphics g46 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local81 = ref WC4;
                this.PaintPresentWindow(g46, ref local81);
              }
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                Graphics g47 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g47, ref local);
              }
              DrawMod.DrawTutback(g, 5, 5, 900, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how you group move a unit. It definitely has its uses in scenarios with a high unit count! ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now I will show how to attack the enemy. Please select the highlighted enemy Engineer unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
            }
            int num49 = 0;
            if (this.Game.EditObj.TutStep == 11 & this.Game.EditObj.UnitSelected > -1 && this.Game.EditObj.OrderType == 48 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 178)
            {
              DrawMod.DrawTutback(g, 5, 5, 900, 100, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see all the hexes highlighted where the units can move to. Only the hexes where all 73rd division", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "units can move too are highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Units from different hexes will thus move over different paths to the same target hex.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now please move the selected units (of 73rd div) to the selected target hex!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              this.Game.EditObj.TutOrder = -1;
              if (Operators.ConditionalCompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 6;
                Graphics g48 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local82 = ref WC4;
                this.PaintPresentWindow(g48, ref local82);
                Graphics g49 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local83 = ref WC4;
                this.PaintPresentWindow(g49, ref local83);
              }
              num49 = 1;
            }
            if (this.Game.EditObj.TutStep == 11 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num49 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 178)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g50 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local84 = ref WC4;
                this.PaintPresentWindow(g50, ref local84);
                Graphics g51 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local85 = ref WC4;
                this.PaintPresentWindow(g51, ref local85);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Now click the highlighted Group Move button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 48)
              {
                this.Game.EditObj.TutOrder = 48;
                Graphics g52 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g52, ref local);
              }
              int num50 = num15 + 106;
              int num51 = this.Game.ScreenHeight - 360;
              ref Graphics local86 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local87 = ref bitmap1;
              int x = num50;
              int y = num51;
              DrawMod.DrawSimple(ref local86, ref local87, x, y);
              num49 = 1;
            }
            if ((this.Game.EditObj.TutStep == 10 | this.Game.EditObj.TutStep == 11) & num49 == 0 && this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(277)].DidMove)
            {
              this.Game.EditObj.TutStep = 11;
              if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 14, false), Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) 13;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g53 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local88 = ref WC4;
                this.PaintPresentWindow(g53, ref local88);
                Graphics g54 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local89 = ref WC4;
                this.PaintPresentWindow(g54, ref local89);
              }
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                Graphics g55 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g55, ref local);
              }
              DrawMod.DrawTutback(g, 5, 5, 900, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how you move a unit! Its very simple. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "However you can also move a whole division (4 units) with one order. Select one of the units of the 73th div now.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
            }
            int num52 = 0;
            if (this.Game.EditObj.TutStep == 10 & this.Game.EditObj.UnitSelected > -1 && this.Game.EditObj.OrderType == 1 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 277)
            {
              DrawMod.DrawTutback(g, 5, 5, 850, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see all the hexes highlighted where the unit", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "can move too. Click on the highlighted hex to move the unit there.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              this.Game.EditObj.TutOrder = -1;
              if (Operators.ConditionalCompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))
              {
                this.Game.EditObj.TutX = (object) 14;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g56 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local90 = ref WC4;
                this.PaintPresentWindow(g56, ref local90);
                Graphics g57 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local91 = ref WC4;
                this.PaintPresentWindow(g57, ref local91);
                Graphics g58 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local92 = ref WC4;
                this.PaintPresentWindow(g58, ref local92);
              }
              num52 = 1;
            }
            if (this.Game.EditObj.TutStep == 10 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num52 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 277)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g59 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local93 = ref WC4;
                this.PaintPresentWindow(g59, ref local93);
                Graphics g60 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local94 = ref WC4;
                this.PaintPresentWindow(g60, ref local94);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Well done. You can now inspect the unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "To move it you have to click the highlighted 'move unit' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 1)
              {
                this.Game.EditObj.TutOrder = 1;
                Graphics g61 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g61, ref local);
              }
              int num53 = num15 + 70;
              int num54 = this.Game.ScreenHeight - 360;
              ref Graphics local95 = ref g;
              bitmap1 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local96 = ref bitmap1;
              int x = num53;
              int y = num54;
              DrawMod.DrawSimple(ref local95, ref local96, x, y);
              num52 = 1;
            }
            if (!(this.Game.EditObj.TutStep > 1 & this.Game.EditObj.TutStep <= 10 & num52 == 0))
              return;
            this.Game.EditObj.TutStep = 10;
            if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 13, false))))
            {
              this.Game.EditObj.TutX = (object) 13;
              this.Game.EditObj.TutY = (object) 4;
              Graphics g62 = g;
              WC4 = typeof (MapWindowClass2);
              ref System.Type local97 = ref WC4;
              this.PaintPresentWindow(g62, ref local97);
              Graphics g63 = g;
              WC4 = typeof (ResourceWindowClass2);
              ref System.Type local98 = ref WC4;
              this.PaintPresentWindow(g63, ref local98);
            }
            if (this.Game.EditObj.TutOrder != 9999)
            {
              this.Game.EditObj.TutOrder = 9999;
              Graphics g64 = g;
              WC4 = typeof (OrderWindowClass2);
              ref System.Type local = ref WC4;
              this.PaintPresentWindow(g64, ref local);
            }
            DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "This is the mainscreen. I'll start with showing how to move a unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
            DrawMod.DrawTextColouredOutline(ref g, "Please select the 'Grenzschutze Regiment'. Its highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
          }
          else
          {
            WC4 = typeof (GameLoopMainWindowClass);
            if (!this.WindowPresent(ref WC4))
              return;
            if (this.Game.EditObj.TutStep <= 1)
            {
              int unitCounter = this.Game.Data.UnitCounter;
              for (int index3 = 0; index3 <= unitCounter; ++index3)
              {
                if (Operators.CompareString(this.Game.Data.UnitObj[index3].Name, "Assault Brigade", false) == 0)
                {
                  int sfCount = this.Game.Data.UnitObj[index3].SFCount;
                  for (int index4 = 0; index4 <= sfCount; ++index4)
                    this.Game.Data.SFObj[this.Game.Data.UnitObj[index3].SFList[index4]].Ap = 0;
                }
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "As first round starts some calculations are done...", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 10, Color.White);
              if (this.Game.EditObj.TutStep != 1)
                return;
              DrawMod.DrawTextColouredOutline(ref g, "Once the calculations have completed, you can begin playing.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 35, Color.White);
              int num55 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
              int num56 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
              int num57 = num55 + 485;
              int num58 = num56 + 630;
              ref Graphics local99 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local100 = ref bitmap;
              int x = num57;
              int y = num58;
              DrawMod.DrawSimple(ref local99, ref local100, x, y);
            }
            else if (this.Game.EditObj.TutStep == 2)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have now started your turn. You get synopsis of what", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "happened in the turns of your opponent and any other news.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              int num59 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
              int num60 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
              int num61 = num59 + 485;
              int num62 = num60 + 630;
              ref Graphics local101 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local102 = ref bitmap;
              int x = num61;
              int y = num62;
              DrawMod.DrawSimple(ref local101, ref local102, x, y);
            }
            else
            {
              if (this.Game.EditObj.TutStep != 3)
                return;
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "When news or messages popup you can just press a key.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "to continue or click the button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              this.Game.EditObj.TutOrder = 9999;
            }
          }
        }
      }
    }

    public void DoTutorial3(Graphics g)
    {
      Color color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 28, 0);
      this.Game.EditObj.Zoom = 0;
      this.Game.EditObj.HideDetail = false;
      this.Game.EditObj.HideAS = false;
      System.Type WC1 = typeof (IntroWindowClass2);
      if (this.WindowPresent(ref WC1))
      {
        this.Game.EditObj.TutStep = 0;
        DrawMod.DrawTutback(g, 5, 5, 960, 160, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        DrawMod.DrawTextColouredOutline(ref g, "Hi! Let me introduce myself. I am Vic, the designer of the game. Welcome to the tutorial. It will go over some ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "key concepts and orders. The tutorial is not exhaustive and it is advised that you read the manual too.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "One of the most important things for new players to know is that you can right click on everything where the mouse", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 70, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "shows a question mark or hand.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 95, Color.White);
        DrawMod.DrawTextColouredOutline(ref g, "Now please press 'start' to start the tutorial.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 135, Color.White);
        int num1 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
        int num2 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
        int num3 = num1 + 845;
        int num4 = num2 + 650;
        ref Graphics local1 = ref g;
        Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
        ref Bitmap local2 = ref bitmap;
        int x = num3;
        int y = num4;
        DrawMod.DrawSimple(ref local1, ref local2, x, y);
      }
      else
      {
        System.Type WC2 = typeof (CombatResultWindowClass2);
        int num5;
        if (this.WindowPresent(ref WC2))
        {
          int num6 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
          num5 = 0;
          if (this.Game.EditObj.TutStep == 13 | this.Game.EditObj.TutStep == 18)
          {
            this.Game.EditObj.TutStep = 18;
            this.Game.EditObj.TutX = (object) 12;
            this.Game.EditObj.TutY = (object) 7;
            this.Game.EditObj.TutOrder = 9999;
            DrawMod.DrawTutback(g, 5, 5, 800, 200, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "The battle is being fought combat round by combat round.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
            if ((uint) this.Game.TempCombat.BattleEnded > 0U)
            {
              DrawMod.DrawTextColouredOutline(ref g, "And once ended you can inspect the battle details or return back to the main screen. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Lets go back to main screen. Click OK.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Note: What your basically seeing in the battle screen is each side's participating units.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 100, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Each unit's troops are displayed. Troops in the middle columns are still participating ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 120, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "in combat. And troops in the side columns have been killed or have retreated from combat.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 140, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Battle ends when one of the sides has no troops participating anymore. In a nutshell ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 160, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "that is what happens. If you are not easily shaken then click on DETAILS to see whats really going on.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 180, Color.White);
            }
            int num7 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0);
            int num8 = (int) Math.Round((double) this.Game.ScreenHeight / 2.0);
            int x1_1 = num7 - 200;
            int y1 = num8 - 150;
            DrawMod.DrawBlock(ref g, x1_1, y1, 5, 300, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawBlock(ref g, x1_1 + 90, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "PARTICIPATING TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), x1_1 + 95, y1 + 20, Color.White);
            int num9 = x1_1 - 350;
            DrawMod.DrawBlock(ref g, num9 + 110, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "RETREATED TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), num9 + 120, y1 + 20, Color.White);
            int x1_2 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0) + 190;
            DrawMod.DrawBlock(ref g, x1_2, y1, 5, 300, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            int num10 = x1_2 - 80;
            DrawMod.DrawBlock(ref g, num10 + 110, y1 + 20, 220, 25, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "RETREATED TROOPS", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), num10 + 120, y1 + 20, Color.White);
            int num11 = (int) Math.Round((double) this.Game.ScreenWidth / 2.0);
            int num12 = (int) Math.Round((double) this.Game.ScreenHeight / 2.0);
            num5 = 1;
          }
          if (!(this.Game.EditObj.TutStep == 27 | this.Game.EditObj.TutStep == 30))
            return;
          this.Game.EditObj.TutStep = 30;
          this.Game.EditObj.TutX = (object) -1;
          this.Game.EditObj.TutY = (object) -1;
          this.Game.Data.MapObj[0].HexObj[this.Game.EditObj.TargetX, this.Game.EditObj.TargetY].set_BattlePenalty(0, 12);
          DrawMod.DrawTutback(g, 5, 5, 900, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
          DrawMod.DrawTextColouredOutline(ref g, "And another battle commences.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
          if ((uint) this.Game.TempCombat.BattleEnded > 0U)
            DrawMod.DrawTextColouredOutline(ref g, "And of course won by your stronger forces. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
          num5 = 1;
        }
        else
        {
          System.Type WC3 = typeof (PlayExtraWindowClass2);
          int num13 = this.WindowPresent(ref WC3) ? 1 : 0;
          System.Type WC4 = typeof (StrategicWindowClass2);
          int num14 = this.WindowPresent(ref WC4) ? 1 : 0;
          if ((num13 | num14) != 0)
          {
            int num15 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
            num5 = 0;
            if (this.Game.EditObj.TutStep == 30)
            {
              DrawMod.DrawTutback(g, 5, 5, 850, 210, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see a black box with a number on the hex you just conquered. This is so called remaining 'battle AP penalty' ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "and it will cause a movement penalty on units that did not participate in the combat for taking the hex. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "(This rule makes it possible for the defender to delay the whole enemy army with one properly defended roadblock)", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "And that concludes this short tutorial. It handled some key concepts, but I advise you to read the manual now.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "In a normal game you would now press", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 105, Color.White);
              ref Graphics local3 = ref g;
              Bitmap bitmap1 = BitmapStore.GetBitmap(this.Game.MARCBACK4);
              ref Bitmap local4 = ref bitmap1;
              DrawMod.DrawSimple(ref local3, ref local4, 95, 138);
              ref Graphics local5 = ref g;
              Bitmap bitmap2 = BitmapStore.GetBitmap(this.Game.BUTTONNEXT);
              ref Bitmap local6 = ref bitmap2;
              DrawMod.DrawSimple(ref local5, ref local6, 95, 138);
              DrawMod.DrawTextColouredOutline(ref g, "the next turn button, but the tutorial has no next turn. You have to use the 'quit' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 130, 155, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "It's in the top-right corner. I will be available on the forums for any questions. Thanks for your attention and happy gaming!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 180, Color.White);
              int num16 = this.Game.ScreenWidth - 20;
              int y1 = 35;
              DrawMod.drawLine(ref g, num16, y1, num16, y1 + 40, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              DrawMod.drawLine(ref g, num16, y1, num16 - 10, y1 + 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              DrawMod.drawLine(ref g, num16, y1, num16 + 10, y1 + 10, (int) color.R, (int) color.G, (int) color.B, (int) color.A, 4);
              num5 = 1;
            }
            int num17 = 0;
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.TempUnitList.counter > -1)
            {
              int num18 = num15 + 825;
              int num19 = this.Game.ScreenHeight - 360;
              ref Graphics local7 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local8 = ref bitmap;
              int x = num18;
              int y = num19;
              DrawMod.DrawSimple(ref local7, ref local8, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Alright and now press attack!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.EditObj.OrderType == 2)
            {
              this.Game.EditObj.TutStep = 27;
              int num20 = num15 + 956;
              int num21 = this.Game.ScreenHeight - 360;
              ref Graphics local9 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local10 = ref bitmap;
              int x = num20;
              int y = num21;
              DrawMod.DrawSimple(ref local9, ref local10, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "To select all available units to join in the attack press the 'ALL' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 27 & num17 == 0 && this.Game.SelectX == 15 & this.Game.SelectY == 4)
            {
              if (this.Game.EditObj.TutOrder != 2)
              {
                this.Game.EditObj.TutOrder = 2;
                Graphics g1 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local11 = ref WC4;
                this.PaintPresentWindow(g1, ref local11);
                Graphics g2 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local12 = ref WC4;
                this.PaintPresentWindow(g2, ref local12);
                Graphics g3 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local13 = ref WC4;
                this.PaintPresentWindow(g3, ref local13);
              }
              int num22 = num15 + 75;
              int num23 = this.Game.ScreenHeight - 360;
              ref Graphics local14 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local15 = ref bitmap;
              int x = num22;
              int y = num23;
              DrawMod.DrawSimple(ref local14, ref local15, x, y);
              num5 = 1;
              DrawMod.DrawTutback(g, 5, 5, 960, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Alright. Now click the attack button so you can start to select the participants in the attack on this hex.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num17 = 1;
            }
            if ((this.Game.EditObj.TutStep == 24 | this.Game.EditObj.TutStep == 27) & num17 == 0 && Operators.CompareString(this.Game.Data.UnitObj[this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(540)].HQ].Name, "OKH", false) == 0)
            {
              this.Game.EditObj.TutStep = 27;
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                this.Game.EditObj.TutX = (object) 15;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g4 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local16 = ref WC4;
                this.PaintPresentWindow(g4, ref local16);
                Graphics g5 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local17 = ref WC4;
                this.PaintPresentWindow(g5, ref local17);
                Graphics g6 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local18 = ref WC4;
                this.PaintPresentWindow(g6, ref local18);
              }
              if (this.Game.Data.MapObj[0].HexObj[15, 4].get_BattlePenalty(0) < 1)
                this.Game.Data.MapObj[0].HexObj[12, 1].set_BattlePenalty(0, 7);
              DrawMod.DrawTutback(g, 5, 5, 960, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Very well. You can see the HQ change reflected in the colored bar of the unit. It's now brown just as the OKH. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now I will show the concept of battle AP penalties. For this you have to start a battle first. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on the selected enemy unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num17 = 1;
            }
            if (this.Game.EditObj.TutStep == 24 & num17 == 0 && this.Game.EditObj.OrderType == 3)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                int unitCounter = this.Game.Data.UnitCounter;
                for (int index1 = 0; index1 <= unitCounter; ++index1)
                {
                  if (Operators.CompareString(this.Game.Data.UnitObj[index1].Name, "1st SS Brigade", false) == 0)
                  {
                    int sfCount = this.Game.Data.UnitObj[index1].SFCount;
                    for (int index2 = 0; index2 <= sfCount; ++index2)
                      this.Game.Data.SFObj[this.Game.Data.UnitObj[index1].SFList[index2]].Ap = 100;
                  }
                  if (Strings.InStr(this.Game.Data.UnitObj[index1].Name, "59th Panzer") > 0)
                  {
                    int sfCount = this.Game.Data.UnitObj[index1].SFCount;
                    for (int index3 = 0; index3 <= sfCount; ++index3)
                      this.Game.Data.SFObj[this.Game.Data.UnitObj[index1].SFList[index3]].Ap = 100;
                  }
                }
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g7 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local19 = ref WC4;
                this.PaintPresentWindow(g7, ref local19);
                Graphics g8 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local20 = ref WC4;
                this.PaintPresentWindow(g8, ref local20);
                Graphics g9 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local21 = ref WC4;
                this.PaintPresentWindow(g9, ref local21);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "The game wants to know what unit should be the new HQ for the motorized regiment.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on the OKH and then on the confirm button to make that the HQ.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.SelectX == 8 & this.Game.SelectY == 7)
              {
                int num24 = num15 + 723;
                int num25 = this.Game.ScreenHeight - 360;
                ref Graphics local22 = ref g;
                Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
                ref Bitmap local23 = ref bitmap;
                int x = num24;
                int y = num25;
                DrawMod.DrawSimple(ref local22, ref local23, x, y);
              }
              num17 = 1;
            }
            Bitmap bitmap3;
            if (this.Game.EditObj.TutStep == 24 & num17 == 0 && this.Game.SelectX == 10 & this.Game.SelectY == 4 && !this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 24;
              if (this.Game.EditObj.TutOrder != 3)
              {
                this.Game.EditObj.TutOrder = 3;
                Graphics g10 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local24 = ref WC4;
                this.PaintPresentWindow(g10, ref local24);
                Graphics g11 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local25 = ref WC4;
                this.PaintPresentWindow(g11, ref local25);
                Graphics g12 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local26 = ref WC4;
                this.PaintPresentWindow(g12, ref local26);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have now selected the Motorized Unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Click the highlighted 'HQ' order.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              int num26 = num15 + 143;
              int num27 = this.Game.ScreenHeight - 360;
              ref Graphics local27 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local28 = ref bitmap3;
              int x = num26;
              int y = num27;
              DrawMod.DrawSimple(ref local27, ref local28, x, y);
              num17 = 1;
            }
            if ((this.Game.EditObj.TutStep == 20 | this.Game.EditObj.TutStep == 24) & num17 == 0 && !(this.Game.SelectX == 10 & this.Game.SelectY == 4) && !this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 24;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutY, (object) 4, false))))
              {
                this.Game.EditObj.TutX = (object) 10;
                this.Game.EditObj.TutY = (object) 4;
                this.Game.SelectX = 8;
                this.Game.SelectY = 6;
                Graphics g13 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local29 = ref WC4;
                this.PaintPresentWindow(g13, ref local29);
                Graphics g14 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local30 = ref WC4;
                this.PaintPresentWindow(g14, ref local30);
                Graphics g15 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local31 = ref WC4;
                this.PaintPresentWindow(g15, ref local31);
                Graphics g16 = g;
                WC4 = typeof (PlayExtraWindowClass2);
                ref System.Type local32 = ref WC4;
                this.PaintPresentWindow(g16, ref local32);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Now I'll show how to change a units HQ. Please now select the Motorized Regiment.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              num5 = 1;
            }
            int num28 = 0;
            if ((this.Game.EditObj.TutStep == 19 | this.Game.EditObj.TutStep == 20) & num28 == 0 && this.Game.EditObj.LayerSupplyOn)
            {
              this.Game.EditObj.TutStep = 20;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 10, false))))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 0;
                Graphics g17 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local33 = ref WC4;
                this.PaintPresentWindow(g17, ref local33);
                Graphics g18 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local34 = ref WC4;
                this.PaintPresentWindow(g18, ref local34);
                Graphics g19 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local35 = ref WC4;
                this.PaintPresentWindow(g19, ref local35);
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 150, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "That's it. You now see how supply flows from your HQ to your units. Click on a hex of choice to see exact path.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Click on back button to hide the supply layer again.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "The colors indicate if an area is in good supply. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 75, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Note that our Flak unit is in bad supply due to the river and broken bridges.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 100, Color.White);
              int num29 = num15 + 38;
              int num30 = this.Game.ScreenHeight - 360;
              ref Graphics local36 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local37 = ref bitmap3;
              int x = num29;
              int y = num30;
              DrawMod.DrawSimple(ref local36, ref local37, x, y);
              num5 = 1;
              num28 = 1;
            }
            if ((this.Game.EditObj.TutStep == 18 | this.Game.EditObj.TutStep == 19) & num28 == 0 && this.Game.Data.MapObj[0].HexObj[6, 8].UnitCounter > -1)
            {
              this.Game.EditObj.TutStep = 19;
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 8, false))))
              {
                this.Game.EditObj.TutX = (object) 8;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g20 = g;
                WC4 = typeof (StrategicWindowClass2);
                ref System.Type local38 = ref WC4;
                this.PaintPresentWindow(g20, ref local38);
                Graphics g21 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local39 = ref WC4;
                this.PaintPresentWindow(g21, ref local39);
                Graphics g22 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local40 = ref WC4;
                this.PaintPresentWindow(g22, ref local40);
                Graphics g23 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local41 = ref WC4;
                this.PaintPresentWindow(g23, ref local41);
              }
              DrawMod.DrawTutback(g, 5, 5, 960, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "That's how you strategically transfer units. Now I will show how the supply layer can be activated.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "For this you need to select a HQ and then press the supply layer button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select the OKH unit and activate the supply layer!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              if (this.Game.SelectX == 8 & this.Game.SelectY == 7)
              {
                this.Game.EditObj.TutOrder = 51;
                int num31 = num15 + 770;
                int num32 = this.Game.ScreenHeight - 360;
                ref Graphics local42 = ref g;
                bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
                ref Bitmap local43 = ref bitmap3;
                int x = num31;
                int y = num32;
                DrawMod.DrawSimple(ref local42, ref local43, x, y);
              }
              else
                this.Game.EditObj.TutOrder = 9999;
              num28 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 && this.Game.EditObj.OrderType == 18)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 6, false))))
              {
                this.Game.EditObj.TutX = (object) 6;
                this.Game.EditObj.TutY = (object) 8;
                Graphics g24 = g;
                WC4 = typeof (StrategicWindowClass2);
                ref System.Type local44 = ref WC4;
                this.PaintPresentWindow(g24, ref local44);
                Graphics g25 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local45 = ref WC4;
                this.PaintPresentWindow(g25, ref local45);
                Graphics g26 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local46 = ref WC4;
                this.PaintPresentWindow(g26, ref local46);
                Graphics g27 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local47 = ref WC4;
                this.PaintPresentWindow(g27, ref local47);
              }
              DrawMod.DrawTutback(g, 5, 5, 860, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "The hexes you can strategically transfer the unit to are highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select the highlighted hex and press the big 'transfer' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) this.Game.SelectX, false), Operators.CompareObjectEqual(this.Game.EditObj.TutY, (object) this.Game.SelectY, false))))
              {
                int num33 = num15 + 735;
                int num34 = this.Game.ScreenHeight - 200;
                ref Graphics local48 = ref g;
                bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
                ref Bitmap local49 = ref bitmap3;
                int x = num33;
                int y = num34;
                DrawMod.DrawSimple(ref local48, ref local49, x, y);
              }
              num28 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num28 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 581)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g28 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local50 = ref WC4;
                this.PaintPresentWindow(g28, ref local50);
                Graphics g29 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local51 = ref WC4;
                this.PaintPresentWindow(g29, ref local51);
                Graphics g30 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local52 = ref WC4;
                this.PaintPresentWindow(g30, ref local52);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Yes thats the engineer unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now to strategically transfer this unit you press the strategic transfer button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 18)
              {
                this.Game.EditObj.TutOrder = 18;
                Graphics g31 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g31, ref local);
              }
              int num35 = num15 + 165;
              int num36 = this.Game.ScreenHeight - 360;
              ref Graphics local53 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local54 = ref bitmap3;
              int x = num35;
              int y = num36;
              DrawMod.DrawSimple(ref local53, ref local54, x, y);
              num28 = 1;
            }
            if (this.Game.EditObj.TutStep == 18 & num28 == 0)
            {
              this.Game.EditObj.TutOrder = 9999;
              DrawMod.DrawTutback(g, 5, 5, 720, 155, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how attacks work. Artillery and Air attack work more or less the same.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "You now see a black oval shape with a number on top of the hex you just attacked.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "This is remembered 'battle stack points' and they will be added to the 'stack' total of your next attack.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "(basically this rule will make it impossible to keep attacking a specific hex over and over)", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now lets see how to do a strategic transfer.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 105, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please select your highlighted Engineer Unit!.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 130, Color.White);
              int unitCounter = this.Game.Data.UnitCounter;
              for (int index4 = 0; index4 <= unitCounter; ++index4)
              {
                if (Operators.CompareString(this.Game.Data.UnitObj[index4].Name, "1st SS Brigade", false) == 0)
                {
                  int sfCount = this.Game.Data.UnitObj[index4].SFCount;
                  for (int index5 = 0; index5 <= sfCount; ++index5)
                    this.Game.Data.SFObj[this.Game.Data.UnitObj[index4].SFList[index5]].Ap = 100;
                }
              }
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 12, false))))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g32 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local55 = ref WC4;
                this.PaintPresentWindow(g32, ref local55);
                Graphics g33 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local56 = ref WC4;
                this.PaintPresentWindow(g33, ref local56);
                Graphics g34 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local57 = ref WC4;
                this.PaintPresentWindow(g34, ref local57);
              }
              num28 = 1;
            }
            if (this.Game.EditObj.TutStep == 13 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.TempUnitList.counter > -1)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "After you have selected one or more units to join the attack you can actually begin the attack. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Lets do so. Press the attack button! ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num28 = 1;
              int num37 = num15 + 842;
              int num38 = this.Game.ScreenHeight - 360;
              ref Graphics local58 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local59 = ref bitmap3;
              int x = num37;
              int y = num38;
              DrawMod.DrawSimple(ref local58, ref local59, x, y);
            }
            if (this.Game.EditObj.TutStep == 13 & num28 == 0 && this.Game.EditObj.OrderType == 2 & this.Game.EditObj.UnitSelected > -1 && this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 1258)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "To let the Cossack unit participate in the attack we", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "click the indicated button. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              num28 = 1;
              int num39 = num15 + 722;
              int num40 = this.Game.ScreenHeight - 360;
              ref Graphics local60 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local61 = ref bitmap3;
              int x = num39;
              int y = num40;
              DrawMod.DrawSimple(ref local60, ref local61, x, y);
            }
            if (this.Game.EditObj.TutStep == 13 & num28 == 0 && this.Game.EditObj.OrderType == 2)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g35 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local62 = ref WC4;
                this.PaintPresentWindow(g35, ref local62);
                Graphics g36 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local63 = ref WC4;
                this.PaintPresentWindow(g36, ref local63);
                Graphics g37 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local64 = ref WC4;
                this.PaintPresentWindow(g37, ref local64);
              }
              this.Game.EditObj.TutOrder = -1;
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Attack planning has started. You now have to select friendly and adjacent units to participate in the attack.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please click on our Cossack unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              num28 = 1;
            }
            if (this.Game.EditObj.TutStep == 13 & this.Game.SelectX == 15 & this.Game.SelectY == 4 & num28 == 0)
            {
              if (this.Game.EditObj.TutOrder != 2)
              {
                this.Game.EditObj.TutOrder = 2;
                Graphics g38 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local65 = ref WC4;
                this.PaintPresentWindow(g38, ref local65);
                Graphics g39 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local66 = ref WC4;
                this.PaintPresentWindow(g39, ref local66);
                Graphics g40 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local67 = ref WC4;
                this.PaintPresentWindow(g40, ref local67);
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 90, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have selected the enemy hex/unit. You always need to do this before you can order an attack on it.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Please now click on the attack button to start planning an attack on the hex. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, " ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              int num41 = num15 + 70;
              int num42 = this.Game.ScreenHeight - 375;
              ref Graphics local68 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local69 = ref bitmap3;
              int x = num41;
              int y = num42;
              DrawMod.DrawSimple(ref local68, ref local69, x, y);
              num28 = 1;
            }
            if ((this.Game.EditObj.TutStep == 11 | this.Game.EditObj.TutStep == 13) & num28 == 0 && this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(531)].DidMove)
            {
              this.Game.EditObj.TutStep = 13;
              if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 12, false), Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) 15;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g41 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local70 = ref WC4;
                this.PaintPresentWindow(g41, ref local70);
                Graphics g42 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local71 = ref WC4;
                this.PaintPresentWindow(g42, ref local71);
              }
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                Graphics g43 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g43, ref local);
              }
              DrawMod.DrawTutback(g, 5, 5, 900, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how you group move a unit. It definitely has its uses in scenarios with a high unit count! ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now I will show how to attack the enemy. Please select the highlighted enemy Engineer unit.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
            }
            int num43 = 0;
            if (this.Game.EditObj.TutStep == 11 & this.Game.EditObj.UnitSelected > -1 && this.Game.EditObj.OrderType == 48 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 531)
            {
              DrawMod.DrawTutback(g, 5, 5, 900, 100, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see all the hexes highlighted where the units can move to. Only the hexes where all 73rd division", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "units can move too are highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Units from different hexes will thus move over different paths to the same target hex.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 55, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "Now please move the selected units (of 73rd div) to the selected target hex!", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 80, Color.White);
              this.Game.EditObj.TutOrder = -1;
              if (Operators.ConditionalCompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))
              {
                this.Game.EditObj.TutX = (object) 12;
                this.Game.EditObj.TutY = (object) 6;
                Graphics g44 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local72 = ref WC4;
                this.PaintPresentWindow(g44, ref local72);
                Graphics g45 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local73 = ref WC4;
                this.PaintPresentWindow(g45, ref local73);
              }
              num43 = 1;
            }
            if (this.Game.EditObj.TutStep == 11 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num43 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 531)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g46 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local74 = ref WC4;
                this.PaintPresentWindow(g46, ref local74);
                Graphics g47 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local75 = ref WC4;
                this.PaintPresentWindow(g47, ref local75);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Now click the highlighted Group Move button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 48)
              {
                this.Game.EditObj.TutOrder = 48;
                Graphics g48 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g48, ref local);
              }
              int num44 = num15 + 106;
              int num45 = this.Game.ScreenHeight - 360;
              ref Graphics local76 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local77 = ref bitmap3;
              int x = num44;
              int y = num45;
              DrawMod.DrawSimple(ref local76, ref local77, x, y);
              num43 = 1;
            }
            if ((this.Game.EditObj.TutStep == 10 | this.Game.EditObj.TutStep == 11) & num43 == 0 && this.Game.Data.UnitObj[this.Game.HandyFunctionsObj.GetUnitByHistorical(1258)].DidMove)
            {
              this.Game.EditObj.TutStep = 11;
              if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 14, false), Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) 13;
                this.Game.EditObj.TutY = (object) 7;
                Graphics g49 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local78 = ref WC4;
                this.PaintPresentWindow(g49, ref local78);
                Graphics g50 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local79 = ref WC4;
                this.PaintPresentWindow(g50, ref local79);
              }
              if (this.Game.EditObj.TutOrder != 9999)
              {
                this.Game.EditObj.TutOrder = 9999;
                Graphics g51 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g51, ref local);
              }
              DrawMod.DrawTutback(g, 5, 5, 900, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "So thats how you move a unit! Its very simple. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "However you can also move a whole division (4 units) with one order. Select one of the units of the 73th div now.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
            }
            int num46 = 0;
            if (this.Game.EditObj.TutStep == 10 & this.Game.EditObj.UnitSelected > -1 && this.Game.EditObj.OrderType == 1 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 1258)
            {
              DrawMod.DrawTutback(g, 5, 5, 850, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You now see all the hexes highlighted where the unit", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "can move too. Click on the highlighted hex to move the unit there.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              this.Game.EditObj.TutOrder = -1;
              if (Operators.ConditionalCompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))
              {
                this.Game.EditObj.TutX = (object) 14;
                this.Game.EditObj.TutY = (object) 4;
                Graphics g52 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local80 = ref WC4;
                this.PaintPresentWindow(g52, ref local80);
                Graphics g53 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local81 = ref WC4;
                this.PaintPresentWindow(g53, ref local81);
                Graphics g54 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local82 = ref WC4;
                this.PaintPresentWindow(g54, ref local82);
              }
              num46 = 1;
            }
            if (this.Game.EditObj.TutStep == 10 & this.Game.EditObj.UnitSelected > -1 & this.Game.EditObj.OrderType == 0 && num46 == 0 & this.Game.Data.UnitObj[this.Game.EditObj.UnitSelected].Historical == 1258)
            {
              if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) -1, false))))
              {
                this.Game.EditObj.TutX = (object) -1;
                this.Game.EditObj.TutY = (object) -1;
                Graphics g55 = g;
                WC4 = typeof (MapWindowClass2);
                ref System.Type local83 = ref WC4;
                this.PaintPresentWindow(g55, ref local83);
                Graphics g56 = g;
                WC4 = typeof (ResourceWindowClass2);
                ref System.Type local84 = ref WC4;
                this.PaintPresentWindow(g56, ref local84);
              }
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "Well done. You can now inspect the unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "To move it you have to click the highlighted 'move unit' button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              if (this.Game.EditObj.TutOrder != 1)
              {
                this.Game.EditObj.TutOrder = 1;
                Graphics g57 = g;
                WC4 = typeof (OrderWindowClass2);
                ref System.Type local = ref WC4;
                this.PaintPresentWindow(g57, ref local);
              }
              int num47 = num15 + 70;
              int num48 = this.Game.ScreenHeight - 360;
              ref Graphics local85 = ref g;
              bitmap3 = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local86 = ref bitmap3;
              int x = num47;
              int y = num48;
              DrawMod.DrawSimple(ref local85, ref local86, x, y);
              num46 = 1;
            }
            if (!(this.Game.EditObj.TutStep > 1 & this.Game.EditObj.TutStep <= 10 & num46 == 0))
              return;
            this.Game.EditObj.TutStep = 10;
            if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(this.Game.EditObj.TutX, (object) 13, false))))
            {
              this.Game.EditObj.TutX = (object) 13;
              this.Game.EditObj.TutY = (object) 4;
              Graphics g58 = g;
              WC4 = typeof (MapWindowClass2);
              ref System.Type local87 = ref WC4;
              this.PaintPresentWindow(g58, ref local87);
              Graphics g59 = g;
              WC4 = typeof (ResourceWindowClass2);
              ref System.Type local88 = ref WC4;
              this.PaintPresentWindow(g59, ref local88);
            }
            if (this.Game.EditObj.TutOrder != 9999)
            {
              this.Game.EditObj.TutOrder = 9999;
              Graphics g60 = g;
              WC4 = typeof (OrderWindowClass2);
              ref System.Type local = ref WC4;
              this.PaintPresentWindow(g60, ref local);
            }
            DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
            DrawMod.DrawTextColouredOutline(ref g, "This is the mainscreen. I'll start with showing how to move a unit. ", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
            DrawMod.DrawTextColouredOutline(ref g, "Please select the 'Cossacks'. Its highlighted.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
          }
          else
          {
            WC4 = typeof (GameLoopMainWindowClass2);
            if (!this.WindowPresent(ref WC4))
              return;
            if (this.Game.EditObj.TutStep <= 1)
            {
              int unitCounter = this.Game.Data.UnitCounter;
              for (int index6 = 0; index6 <= unitCounter; ++index6)
              {
                if (Operators.CompareString(this.Game.Data.UnitObj[index6].Name, "1st SS Brigade", false) == 0)
                {
                  int sfCount = this.Game.Data.UnitObj[index6].SFCount;
                  for (int index7 = 0; index7 <= sfCount; ++index7)
                    this.Game.Data.SFObj[this.Game.Data.UnitObj[index6].SFList[index7]].Ap = 0;
                }
                if (Strings.InStr(this.Game.Data.UnitObj[index6].Name, "59th Panzer") > 0)
                {
                  int sfCount = this.Game.Data.UnitObj[index6].SFCount;
                  for (int index8 = 0; index8 <= sfCount; ++index8)
                    this.Game.Data.SFObj[this.Game.Data.UnitObj[index6].SFList[index8]].Ap = 0;
                }
              }
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "As first round starts some calculations are done...", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 10, Color.White);
              if (this.Game.EditObj.TutStep != 1)
                return;
              DrawMod.DrawTextColouredOutline(ref g, "Once the calculations have completed, you can begin playing.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 35, Color.White);
              int num49 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
              int num50 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
              int num51 = num49 + 485;
              int num52 = num50 + 630;
              ref Graphics local89 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local90 = ref bitmap;
              int x = num51;
              int y = num52;
              DrawMod.DrawSimple(ref local89, ref local90, x, y);
            }
            else if (this.Game.EditObj.TutStep == 2)
            {
              DrawMod.DrawTutback(g, 5, 5, 800, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "You have now started your turn. You get synopsis of what", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "happened in the turns of your opponent and any other news.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              int num53 = (int) Math.Round((double) (this.Game.ScreenWidth - 1024) / 2.0);
              int num54 = (int) Math.Round((double) (this.Game.ScreenHeight - 768) / 2.0);
              int num55 = num53 + 485;
              int num56 = num54 + 630;
              ref Graphics local91 = ref g;
              Bitmap bitmap = BitmapStore.GetBitmap(this.Game.TUTARROW);
              ref Bitmap local92 = ref bitmap;
              int x = num55;
              int y = num56;
              DrawMod.DrawSimple(ref local91, ref local92, x, y);
            }
            else
            {
              if (this.Game.EditObj.TutStep != 3)
                return;
              DrawMod.DrawTutback(g, 5, 5, 700, 60, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
              DrawMod.DrawTextColouredOutline(ref g, "When news or messages popup you can just press a key.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 5, Color.White);
              DrawMod.DrawTextColouredOutline(ref g, "to continue or click the button.", new Font(this.Game.FontCol.Families[1], 16f, FontStyle.Regular, GraphicsUnit.Pixel), 10, 30, Color.White);
              this.Game.EditObj.TutOrder = 9999;
            }
          }
        }
      }
    }

    public bool WindowPresent(ref System.Type WC)
    {
      if (this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (int index = 0; index <= windowCounter; ++index)
        {
          if (this.WindowList[index].GetType().Equals(WC))
            return true;
        }
      }
      return false;
    }

    public WindowClass GetWindow(ref System.Type WC)
    {
      if (this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (int index = 0; index <= windowCounter; ++index)
        {
          if (this.WindowList[index].GetType().Equals(WC))
            return this.WindowList[index];
        }
      }
      return (WindowClass) null;
    }

    public int GetWindowID(ref System.Type WC)
    {
      if (this.WindowCounter > -1)
      {
        int windowCounter = this.WindowCounter;
        for (int index = 0; index <= windowCounter; ++index)
        {
          if (this.WindowList[index].GetType().Equals(WC))
            return this.WindowID[index];
        }
      }
      return 0;
    }

    public void PaintPresentWindow(Graphics g, ref System.Type WC)
    {
      int windowCounter = this.WindowCounter;
      for (int index = 0; index <= windowCounter; ++index)
      {
        if (this.WindowList[index].GetType().Equals(WC))
        {
          this.WindowList[index].DoRefresh();
          if (Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass", false) != 0 & Operators.CompareString(this.WindowList[index].GetType().FullName, "WindowsApplication1.MapWindowClass2", false) != 0)
          {
            g.CompositingMode = CompositingMode.SourceCopy;
            DrawMod.DrawSimplePart(ref g, ref this.OwnBackground, new Rectangle(this.WindowX[index], this.WindowY[index], this.WindowW[index], this.WindowH[index]));
            g.CompositingMode = CompositingMode.SourceOver;
            ref Graphics local1 = ref g;
            Bitmap bitmap = this.WindowList[index].Paint();
            ref Bitmap local2 = ref bitmap;
            int x = this.WindowX[index];
            int y = this.WindowY[index];
            DrawMod.DrawSimple(ref local1, ref local2, x, y);
          }
          else
          {
            g.CompositingMode = CompositingMode.SourceCopy;
            DrawMod.DrawSimple(ref g, ref this.WindowList[index].SubPartList[0].OwnBitmap, this.WindowX[index], this.WindowY[index]);
            g.CompositingMode = CompositingMode.SourceOver;
          }
        }
      }
    }
  }
}
