// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.DynamicArea
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
  pub class DynamicArea : SubPartClass
  {
     Font OwnFont;
     int Width;
     int Height;
     GameClass game;
     Bitmap backbitmap;
     int bx;
     int by;
     int clickscroll;
    pub texty: String;
     int curY;
     int maxY;
     int lastY;
     Bitmap paper;
     bool alwaysBlockScrollBar;
     bool useActualWidth;

    pub void SubDispose()
    {
      if (!Information.IsNothing((object) this.backbitmap))
      {
        this.backbitmap.Dispose();
        this.backbitmap = (Bitmap) null;
      }
      if (Information.IsNothing((object) this.paper))
        return;
      this.paper.Dispose();
      this.paper = (Bitmap) null;
    }

    pub bool HandleTimerWheel(int x, int y, ref WindowClass tWindow)
    {
      if (this.game.EditObj.MouseWheel > 0)
      {
        int mouseWheel = this.game.EditObj.MouseWheel;
        for (int index = 1; index <= mouseWheel; index += 1)
          this.ShiftUp();
        this.game.EditObj.MouseWheel = 0;
        this.game.EditObj.MouseWheelWait = 4;
        return true;
      }
      if (this.game.EditObj.MouseWheel >= 0)
        return false;
      int mouseWheel1 = this.game.EditObj.MouseWheel;
      for (int index = -1; index >= mouseWheel1; index += -1)
        this.ShiftDown();
      this.game.EditObj.MouseWheel = 0;
      this.game.EditObj.MouseWheelWait = 4;
      return true;
    }

    pub DynamicArea(
      GameClass tgame,
      int twidth,
      int theight,
      string tTexty,
      ref Bitmap tbackbitmap = null,
      int bbx = -1,
      int bby = -1,
      bool talwaysBlockScrollBar = false,
      bool tJustCheckHeight = false,
      bool tUseActualWidth = false)
      : base(twidth, theight)
    {
      this.Width = twidth;
      this.Height = theight;
      this.game = tgame;
      this.texty = tTexty;
      this.useActualWidth = tUseActualWidth;
      this.alwaysBlockScrollBar = talwaysBlockScrollBar;
      if (!Information.IsNothing((object) tbackbitmap) & !tJustCheckHeight)
      {
        this.backbitmap = new Bitmap(this.OwnBitmap.Width, this.OwnBitmap.Height, PixelFormat.Format32bppPArgb);
        this.backbitmap.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
        Graphics graphics = Graphics.FromImage((Image) this.backbitmap);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.DrawImage((Image) tbackbitmap, new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height), new Rectangle(bbx, bby, this.OwnBitmap.Width, this.OwnBitmap.Height), GraphicsUnit.Pixel);
        graphics.CompositingMode = CompositingMode.SourceOver;
      }
      this.bx = bbx;
      this.by = bby;
      this.MouseOver = true;
      if (tJustCheckHeight)
        return;
      this.MakeBitmap();
    }

    pub int HeightUsed() => this.maxY;

    pub void HandleToolTip(int x, int y)
    {
      this.game.EditObj.TipColor = 0;
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; index += 1)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          this.game.EditObj.TipColor = this.MouseData[index];
          if (this.game.EditObj.TipText.Length != 0)
            break;
          this.game.EditObj.TipText = "...................";
          break;
        }
      }
    }

    pub int DoJustCheckHeight()
    {
      DynamicData dynamicData = new DynamicData(this.texty);
      int num1 = 0;
      int elementCounter = dynamicData.elementCounter;
      for (int index1 = 0; index1 <= elementCounter; index1 += 1)
      {
        Bitmap bitmap;
        if (dynamicData.element[index1].type == DynamicType.TextField)
        {
          if (Strings.InStr(dynamicData.element[index1].fontName, "courier") > 0)
          {
            let mut game: GameClass = this.game;
            int w = dynamicData.element[index1].w;
            int trows =  Math.Round((double) dynamicData.element[index1].h / (double) dynamicData.element[index1].lineHeight);
            Font marcFont4b = this.game.MarcFont4b;
            texty: String = dynamicData.element[index1].texty;
            int lineHeight = dynamicData.element[index1].lineHeight;
            bitmap = (Bitmap) null;
            ref Bitmap local = ref bitmap;
            int r =  dynamicData.element[index1].color.R;
            int g =  dynamicData.element[index1].color.G;
            int b =  dynamicData.element[index1].color.B;
            int a =  dynamicData.element[index1].color.A;
            int num2 = new TextAreaClass2(game, w, trows, marcFont4b, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseEncy: true).HeightUsed() + 24;
            if (num2 > num1)
              num1 = num2;
          }
          else
          {
            int index2 = this.game.AddDynFont(dynamicData.element[index1].fontName, dynamicData.element[index1].fontSize, dynamicData.element[index1].fontStyle);
            if (index2 > -1)
            {
              let mut game: GameClass = this.game;
              int w = dynamicData.element[index1].w;
              int trows =  Math.Round((double) dynamicData.element[index1].h / (double) dynamicData.element[index1].lineHeight);
              Font tfont = this.game.DynFont[index2];
              texty: String = dynamicData.element[index1].texty;
              int lineHeight = dynamicData.element[index1].lineHeight;
              bitmap = (Bitmap) null;
              ref Bitmap local = ref bitmap;
              int r =  dynamicData.element[index1].color.R;
              int g =  dynamicData.element[index1].color.G;
              int b =  dynamicData.element[index1].color.B;
              int a =  dynamicData.element[index1].color.A;
              int num3 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseEncy: true).HeightUsed() + 24;
              if (num3 > num1)
                num1 = num3;
            }
          }
        }
        if (dynamicData.element[index1].type == DynamicType.PictureField && dynamicData.element[index1].eventPicture > -1)
        {
          int num4 = BitmapStore.Getheight(this.game.Data.EventPicNr[dynamicData.element[index1].eventPicture]);
          if (num4 > num1)
            num1 = num4;
        }
      }
      return num1;
    }

    pub void MakeBitmap()
    {
      this.ClearMouse();
      DynamicData dynamicData = new DynamicData(this.texty);
      Graphics.FromImage((Image) this.OwnBitmap);
      int num1 = 0;
      int elementCounter1 = dynamicData.elementCounter;
      for (int index1 = 0; index1 <= elementCounter1; index1 += 1)
      {
        if (dynamicData.element[index1].type == DynamicType.TextField)
        {
          int index2 = this.game.AddDynFont(dynamicData.element[index1].fontName, dynamicData.element[index1].fontSize, dynamicData.element[index1].fontStyle);
          if (Strings.InStr(dynamicData.element[index1].fontName, "courier") > 0)
          {
            let mut game: GameClass = this.game;
            int w = dynamicData.element[index1].w;
            int trows =  Math.Round((double) dynamicData.element[index1].h / (double) dynamicData.element[index1].lineHeight);
            Font marcFont4 = this.game.MarcFont4;
            texty: String = dynamicData.element[index1].texty;
            int lineHeight = dynamicData.element[index1].lineHeight;
            Bitmap bitmap = (Bitmap) null;
            ref Bitmap local = ref bitmap;
            int r =  dynamicData.element[index1].color.R;
            int g =  dynamicData.element[index1].color.G;
            int b =  dynamicData.element[index1].color.B;
            int a =  dynamicData.element[index1].color.A;
            TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w, trows, marcFont4, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseEncy: true);
            int num2 = textAreaClass2.HeightUsed() + dynamicData.element[index1].y;
            if (num2 > num1)
              num1 = num2 + dynamicData.element[index1].lineHeight * 1 + 48;
            dynamicData.element[index1].h = textAreaClass2.HeightUsed() + dynamicData.element[index1].lineHeight * 1 + 48;
          }
          else if (index2 > -1)
          {
            TextAreaClass2 textAreaClass2;
            if (!dynamicData.element[index1].center)
            {
              let mut game: GameClass = this.game;
              int w = dynamicData.element[index1].w;
              int trows =  Math.Round((double) dynamicData.element[index1].h / (double) dynamicData.element[index1].lineHeight);
              Font tfont = this.game.DynFont[index2];
              texty: String = dynamicData.element[index1].texty;
              int lineHeight = dynamicData.element[index1].lineHeight;
              Bitmap bitmap = (Bitmap) null;
              ref Bitmap local = ref bitmap;
              int r =  dynamicData.element[index1].color.R;
              int g =  dynamicData.element[index1].color.G;
              int b =  dynamicData.element[index1].color.B;
              int a =  dynamicData.element[index1].color.A;
              textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseEncy: true);
            }
            else
            {
              let mut game: GameClass = this.game;
              int w = dynamicData.element[index1].w;
              int trows =  Math.Round((double) dynamicData.element[index1].h / (double) dynamicData.element[index1].lineHeight);
              Font tfont = this.game.DynFont[index2];
              texty: String = dynamicData.element[index1].texty;
              int lineHeight = dynamicData.element[index1].lineHeight;
              Bitmap bitmap = (Bitmap) null;
              ref Bitmap local = ref bitmap;
              int r =  dynamicData.element[index1].color.R;
              int g =  dynamicData.element[index1].color.G;
              int b =  dynamicData.element[index1].color.B;
              int a =  dynamicData.element[index1].color.A;
              textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, tcenterit: true, colr: r, colg: g, colb: b, cola: a, tshadow: false, tUseEncy: true);
            }
            int num3 = textAreaClass2.HeightUsed() + dynamicData.element[index1].y;
            if (num3 > num1)
              num1 = num3 + dynamicData.element[index1].lineHeight * 1 + 48;
            dynamicData.element[index1].h = textAreaClass2.HeightUsed() + dynamicData.element[index1].lineHeight * 1 + 48;
          }
        }
        else if (dynamicData.element[index1].type == DynamicType.PictureField && dynamicData.element[index1].y + dynamicData.element[index1].h > num1)
          num1 = dynamicData.element[index1].y + dynamicData.element[index1].h + 48;
      }
      if (this.maxY < this.Height)
        this.maxY = this.Height;
      this.maxY = this.Height;
      this.maxY -= this.maxY % 100;
      if (this.maxY < 100)
        this.maxY = 100;
      int elementCounter2 = dynamicData.elementCounter;
      for (int index = 0; index <= elementCounter2; index += 1)
      {
        if (dynamicData.element[index].y + dynamicData.element[index].h > this.maxY)
          this.maxY = dynamicData.element[index].y + dynamicData.element[index].h;
      }
      this.curY = 0;
      this.paper = this.alwaysBlockScrollBar ? new Bitmap(this.Width, this.maxY, PixelFormat.Format32bppPArgb) : (!this.useActualWidth ? new Bitmap(540, this.maxY, PixelFormat.Format32bppPArgb) : (this.alwaysBlockScrollBar ? new Bitmap(this.Width, this.maxY, PixelFormat.Format32bppPArgb) : new Bitmap(this.Width - 30, this.maxY, PixelFormat.Format32bppPArgb)));
      this.paper.SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
      Graphics g1 = Graphics.FromImage((Image) this.paper);
      if (!this.alwaysBlockScrollBar)
      {
        if (this.useActualWidth)
        {
          int width = this.Width;
          if (!this.alwaysBlockScrollBar)
            width -= 30;
          g1.CompositingMode = CompositingMode.SourceCopy;
          g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK1), 0, 0, width, 100);
          for (int y = 100; y < this.maxY - 100; y += 100)
            g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK2), 0, y, width, 100);
          g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK3), 0, this.maxY - 100, width, 100);
          g1.CompositingMode = CompositingMode.SourceOver;
        }
        else
        {
          g1.CompositingMode = CompositingMode.SourceCopy;
          g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK1), 0, 0);
          for (int y = 100; y < this.maxY - 100; y += 100)
            g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK2), 0, y);
          g1.DrawImage((Image) BitmapStore.GetBitmap(this.game.PAPERBACK3), 0, this.maxY - 100);
          g1.CompositingMode = CompositingMode.SourceOver;
        }
      }
      int elementCounter3 = dynamicData.elementCounter;
      for (int index3 = 0; index3 <= elementCounter3; index3 += 1)
      {
        if (dynamicData.element[index3].type == DynamicType.TextField)
        {
          int index4 = this.game.AddDynFont(dynamicData.element[index3].fontName, dynamicData.element[index3].fontSize, dynamicData.element[index3].fontStyle);
          Rectangle trect1;
          Rectangle trect2;
          if (Strings.InStr(dynamicData.element[index3].fontName, "courier") > 0)
          {
            let mut game: GameClass = this.game;
            int w = dynamicData.element[index3].w;
            int trows =  Math.Round((double) dynamicData.element[index3].h / (double) dynamicData.element[index3].lineHeight);
            Font marcFont4b = this.game.MarcFont4b;
            texty: String = dynamicData.element[index3].texty;
            int lineHeight = dynamicData.element[index3].lineHeight;
            Bitmap bitmap = (Bitmap) null;
            ref Bitmap local = ref bitmap;
            int r =  dynamicData.element[index3].color.R;
            int g2 =  dynamicData.element[index3].color.G;
            int b =  dynamicData.element[index3].color.B;
            int a =  dynamicData.element[index3].color.A;
            TextAreaClass2 textAreaClass2 = new TextAreaClass2(game, w, trows, marcFont4b, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g2, colb: b, cola: a, tshadow: false, tUseEncy: true);
            textAreaClass2.Paint();
            int mouseCounter = textAreaClass2.MouseCounter;
            for (int index5 = 0; index5 <= mouseCounter; index5 += 1)
            {
              trect1 = new Rectangle(textAreaClass2.MouseRect[index5].X + dynamicData.element[index3].x, textAreaClass2.MouseRect[index5].Y + dynamicData.element[index3].y, textAreaClass2.MouseRect[index5].Width, textAreaClass2.MouseRect[index5].Height);
              trect2 = trect1;
              this.AddMouse(ref trect2, textAreaClass2.MouseTitle[index5], textAreaClass2.MouseText[index5], textAreaClass2.MouseData[index5]);
            }
            g1.DrawImage((Image) textAreaClass2.OwnBitmap, dynamicData.element[index3].x, dynamicData.element[index3].y);
          }
          else if (index4 > -1)
          {
            TextAreaClass2 textAreaClass2;
            if (!dynamicData.element[index3].center)
            {
              let mut game: GameClass = this.game;
              int w = dynamicData.element[index3].w;
              int trows =  Math.Round((double) dynamicData.element[index3].h / (double) dynamicData.element[index3].lineHeight);
              Font tfont = this.game.DynFont[index4];
              texty: String = dynamicData.element[index3].texty;
              int lineHeight = dynamicData.element[index3].lineHeight;
              Bitmap bitmap = (Bitmap) null;
              ref Bitmap local = ref bitmap;
              int r =  dynamicData.element[index3].color.R;
              int g3 =  dynamicData.element[index3].color.G;
              int b =  dynamicData.element[index3].color.B;
              int a =  dynamicData.element[index3].color.A;
              textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, colr: r, colg: g3, colb: b, cola: a, tshadow: false, tUseEncy: true);
            }
            else
            {
              let mut game: GameClass = this.game;
              int w = dynamicData.element[index3].w;
              int trows =  Math.Round((double) dynamicData.element[index3].h / (double) dynamicData.element[index3].lineHeight);
              Font tfont = this.game.DynFont[index4];
              texty: String = dynamicData.element[index3].texty;
              int lineHeight = dynamicData.element[index3].lineHeight;
              Bitmap bitmap = (Bitmap) null;
              ref Bitmap local = ref bitmap;
              int r =  dynamicData.element[index3].color.R;
              int g4 =  dynamicData.element[index3].color.G;
              int b =  dynamicData.element[index3].color.B;
              int a =  dynamicData.element[index3].color.A;
              textAreaClass2 = new TextAreaClass2(game, w, trows, tfont, texty, lineHeight, ref local, tWithoutScrollbars: true, tWithoutFrame: true, tcenterit: true, colr: r, colg: g4, colb: b, cola: a, tshadow: false, tUseEncy: true);
            }
            textAreaClass2.Paint();
            int mouseCounter = textAreaClass2.MouseCounter;
            for (int index6 = 0; index6 <= mouseCounter; index6 += 1)
            {
              trect2 = new Rectangle(textAreaClass2.MouseRect[index6].X + dynamicData.element[index3].x, textAreaClass2.MouseRect[index6].Y + dynamicData.element[index3].y, textAreaClass2.MouseRect[index6].Width, textAreaClass2.MouseRect[index6].Height);
              trect1 = trect2;
              this.AddMouse(ref trect1, textAreaClass2.MouseTitle[index6], textAreaClass2.MouseText[index6], textAreaClass2.MouseData[index6]);
            }
            g1.DrawImage((Image) textAreaClass2.OwnBitmap, dynamicData.element[index3].x, dynamicData.element[index3].y);
          }
        }
        if (dynamicData.element[index3].type == DynamicType.PictureField)
        {
          if (dynamicData.element[index3].historicalUnitPortrait > 0)
          {
            int historicalUnitById = this.game.HandyFunctionsObj.GetHistoricalUnitByID(dynamicData.element[index3].historicalUnitPortrait);
            if (historicalUnitById > -1)
            {
              if (dynamicData.element[index3].w > 0)
                DrawMod.DrawOfficer(g1, historicalUnitById, dynamicData.element[index3].x, dynamicData.element[index3].y, dynamicData.element[index3].w, dynamicData.element[index3].h);
              else
                DrawMod.DrawOfficer(g1, historicalUnitById, dynamicData.element[index3].x, dynamicData.element[index3].y, 95, 105);
            }
          }
          else if (dynamicData.element[index3].w > 0)
          {
            ref Graphics local1 = ref g1;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[dynamicData.element[index3].eventPicture]);
            ref Bitmap local2 = ref bitmap;
            int x = dynamicData.element[index3].x;
            int y = dynamicData.element[index3].y;
            int w = dynamicData.element[index3].w;
            int h = dynamicData.element[index3].h;
            int width = BitmapStore.GetBitmap(this.game.Data.EventPicNr[dynamicData.element[index3].eventPicture]).Width;
            int height = BitmapStore.GetBitmap(this.game.Data.EventPicNr[dynamicData.element[index3].eventPicture]).Height;
            double r = (double) ((float) dynamicData.element[index3].color.R / (float) byte.MaxValue);
            double g5 = (double) ((float) dynamicData.element[index3].color.G / (float) byte.MaxValue);
            double b = (double) ((float) dynamicData.element[index3].color.B / (float) byte.MaxValue);
            double a = (double) ((float) dynamicData.element[index3].color.A / (float) byte.MaxValue);
            DrawMod.DrawScaledColorized(ref local1, ref local2, x, y, w, h, width, height, (float) r, (float) g5, (float) b, (float) a);
          }
          else if (dynamicData.element[index3].color.R == byte.MaxValue & dynamicData.element[index3].color.G == byte.MaxValue & dynamicData.element[index3].color.B == byte.MaxValue & dynamicData.element[index3].color.A == byte.MaxValue)
          {
            ref Graphics local3 = ref g1;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[dynamicData.element[index3].eventPicture]);
            ref Bitmap local4 = ref bitmap;
            int x = dynamicData.element[index3].x;
            int y = dynamicData.element[index3].y;
            DrawMod.DrawSimple(ref local3, ref local4, x, y);
          }
          else
          {
            ref Graphics local5 = ref g1;
            Bitmap bitmap = BitmapStore.GetBitmap(this.game.Data.EventPicNr[dynamicData.element[index3].eventPicture]);
            ref Bitmap local6 = ref bitmap;
            int x = dynamicData.element[index3].x;
            int y = dynamicData.element[index3].y;
            double r = (double) ((float) dynamicData.element[index3].color.R / (float) byte.MaxValue);
            double g6 = (double) ((float) dynamicData.element[index3].color.G / (float) byte.MaxValue);
            double b = (double) ((float) dynamicData.element[index3].color.B / (float) byte.MaxValue);
            double a = (double) ((float) dynamicData.element[index3].color.A / (float) byte.MaxValue);
            DrawMod.Draw(ref local5, ref local6, x, y, (float) r, (float) g6, (float) b, (float) a);
          }
        }
      }
      g1.Dispose();
    }

    pub Bitmap Paint()
    {
      SizeF sizeF = SizeF::new();
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (this.lastY != this.curY)
      {
        int num = this.lastY - this.curY;
        int mouseCounter = this.MouseCounter;
        for (int index1 = 0; index1 <= mouseCounter; index1 += 1)
        {
          Rectangle[] mouseRect = this.MouseRect;
          Rectangle[] rectangleArray = mouseRect;
          int index2 = index1;
          int index3 = index2;
          rectangleArray[index3].Y = mouseRect[index2].Y + num;
        }
        this.lastY = this.curY;
      }
      if (!Information.IsNothing((object) this.backbitmap))
      {
        objGraphics.CompositingMode = CompositingMode.SourceCopy;
        DrawMod.DrawSimple(ref objGraphics, ref this.backbitmap, 0, 0);
        objGraphics.CompositingMode = CompositingMode.SourceOver;
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.alwaysBlockScrollBar)
      {
        if (this.useActualWidth)
        {
          if (!this.alwaysBlockScrollBar)
          {
            Graphics graphics = objGraphics;
            Bitmap paper = this.paper;
            rectangle1 = new Rectangle(0, 0, this.Width - 30, this.Height);
            Rectangle destRect = rectangle1;
            rectangle2 = new Rectangle(0, this.curY, this.Width - 30, this.Height);
            Rectangle srcRect = rectangle2;
            graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
          }
          else
          {
            Graphics graphics = objGraphics;
            Bitmap paper = this.paper;
            rectangle2 = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle destRect = rectangle2;
            rectangle1 = new Rectangle(0, this.curY, this.Width, this.Height);
            Rectangle srcRect = rectangle1;
            graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
          }
        }
        else
        {
          Graphics graphics = objGraphics;
          Bitmap paper = this.paper;
          rectangle2 = new Rectangle(0, 0, 540, this.Height);
          Rectangle destRect = rectangle2;
          rectangle1 = new Rectangle(0, this.curY, 540, this.Height);
          Rectangle srcRect = rectangle1;
          graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
        }
      }
      else
      {
        Graphics graphics = objGraphics;
        Bitmap paper = this.paper;
        rectangle2 = new Rectangle(0, 0, this.Width, this.Height);
        Rectangle destRect = rectangle2;
        rectangle1 = new Rectangle(0, this.curY, this.Width, this.Height);
        Rectangle srcRect = rectangle1;
        graphics.DrawImage((Image) paper, destRect, srcRect, GraphicsUnit.Pixel);
      }
      if (!this.alwaysBlockScrollBar && this.maxY > this.Height)
      {
        int x1 = this.Width - 20;
        int num =  Math.Round((double) (this.Height - 16) * ((double) this.curY / (double) (this.maxY - this.Height)) + 8.0);
        if (num > this.Height - 16)
          num = this.Height - 16;
        ref Graphics local1 = ref objGraphics;
        Bitmap bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local2 = ref bitmap;
        rectangle2 = new Rectangle(0, 3, 20, 4);
        Rectangle srcrect1 = rectangle2;
        rectangle1 = new Rectangle(x1, 3, 20, this.Height);
        Rectangle destrect1 = rectangle1;
        DrawMod.DrawSimplePart2(ref local1, ref local2, srcrect1, destrect1);
        ref Graphics local3 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local4 = ref bitmap;
        rectangle2 = new Rectangle(0, 0, 20, 3);
        Rectangle srcrect2 = rectangle2;
        rectangle1 = new Rectangle(x1, 0, 20, 3);
        Rectangle destrect2 = rectangle1;
        DrawMod.DrawSimplePart2(ref local3, ref local4, srcrect2, destrect2);
        ref Graphics local5 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBACK);
        ref Bitmap local6 = ref bitmap;
        rectangle2 = new Rectangle(0, 7, 20, 3);
        Rectangle srcrect3 = rectangle2;
        rectangle1 = new Rectangle(x1, this.Height - 8, 20, 3);
        Rectangle destrect3 = rectangle1;
        DrawMod.DrawSimplePart2(ref local5, ref local6, srcrect3, destrect3);
        ref Graphics local7 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTUP);
        ref Bitmap local8 = ref bitmap;
        int x2 = x1;
        DrawMod.DrawSimple(ref local7, ref local8, x2, 0);
        ref Graphics local9 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTDOWN);
        ref Bitmap local10 = ref bitmap;
        int x3 = x1;
        int y1 = this.Height - 8;
        DrawMod.DrawSimple(ref local9, ref local10, x3, y1);
        ref Graphics local11 = ref objGraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.LISTBLOCK);
        ref Bitmap local12 = ref bitmap;
        int x4 = x1;
        int y2 = num;
        DrawMod.DrawSimple(ref local11, ref local12, x4, y2);
      }
      return this.OwnBitmap;
    }

    pub void ShiftDown()
    {
      if (this.maxY <= this.Height)
        return;
      this.curY += 20;
      if (this.curY <= this.maxY - this.Height)
        return;
      this.curY = this.maxY - this.Height;
    }

    pub void ShiftUp()
    {
      if (this.maxY <= this.Height)
        return;
      this.curY -= 20;
      if (0 <= this.curY)
        return;
      this.curY = 0;
    }

    pub int HandleMouseUp(int x, int y)
    {
      if (!(this.clickscroll == 1 | this.Scroller))
        return -1;
      this.clickscroll = 0;
      this.Scroller = false;
      return 1;
    }

    pub int Click(int x, int y, int b = 1)
    {
      if (this.alwaysBlockScrollBar || this.maxY <= this.Height || x <= this.Width - 20)
      {
        int num;
        return num;
      }
      if (y >= 0 & y <= 8)
      {
        this.curY -= 20;
        this.clickscroll = 0;
        if (0 > this.curY)
          this.curY = 0;
        return -1;
      }
      if (y > this.Height - 8)
      {
        this.curY += 20;
        this.clickscroll = 0;
        if (this.curY > this.maxY - this.Height)
          this.curY = this.maxY - this.Height;
        return -1;
      }
      this.clickscroll = 1;
      this.Scroller = true;
      this.curY =  Math.Round((double) (this.maxY - this.Height) * ((double) (y - 8) / (double) (this.Height - 16)));
      if (0 > this.curY)
        this.curY = 0;
      if (this.curY > this.maxY - this.Height)
        this.curY = this.maxY - this.Height;
      return -1;
    }

    pub bool MouseMove(int x, int y)
    {
      if (this.alwaysBlockScrollBar || this.clickscroll != 1)
        return false;
      this.clickscroll = 1;
      this.Scroller = true;
      this.clickscroll = 1;
      this.Scroller = true;
      this.curY =  Math.Round((double) (this.maxY - this.Height) * ((double) (y - 8) / (double) (this.Height - 16)));
      if (0 > this.curY)
        this.curY = 0;
      if (this.curY > this.maxY - this.Height)
        this.curY = this.maxY - this.Height;
      return true;
    }
  }
}
