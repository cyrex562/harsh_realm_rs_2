// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.TabMiniMapWindowClass2
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class TabMiniMapWindowClass2 : WindowClass
  {
    private int Info1Id;
    private int info2id;
    private string ShowString;
    private DateTime ShowTime;
    private int w;
    private int h;
    private int CurrentView;

    public TabMiniMapWindowClass2(
      ref GameClass tGame,
      ref WindowClass tLowerWindow,
      ref Rectangle tLowerRect,
      Rectangle trect)
      : base(ref tGame, trect.Width, trect.Height, 8)
    {
      this.w = trect.Width;
      this.h = trect.Height;
      this.LowerWindow = tLowerWindow;
      this.LowerRect = tLowerRect;
      this.dostuff();
    }

    public override void DoRefresh() => this.dostuff();

    public void dostuff()
    {
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.w, this.h, -1);
      Rectangle trect = DrawMod.DrawBackTab(Graphics.FromImage((Image) this.OwnBitmap), this.w, this.h, "MINI", 7);
      this.AddMouse(ref trect, "CLOSE TAB", "Click here to close this tab. [ESC/F8]", 999);
      bool tpaintview;
      if (this.game.EditObj.Zoom == 0)
      {
        if ((double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 52.0 + (double) this.game.ScreenHeight / 48.0)
          tpaintview = true;
      }
      else if (this.game.EditObj.Zoom == -1)
      {
        if ((double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 27.0 + (double) this.game.ScreenHeight / 24.0)
          tpaintview = true;
      }
      else if (this.game.EditObj.Zoom == 1 && (double) (this.game.Data.MapObj[0].MapHeight + this.game.Data.MapObj[0].MapWidth) > (double) this.game.ScreenWidth / 104.0 + (double) this.game.ScreenHeight / 96.0)
        tpaintview = true;
      if (this.Info1Id == 0)
      {
        int widthForMiniMap = DrawMod.GetWidthForMiniMap();
        SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tpaintview, widthForMiniMap, 200);
        this.Info1Id = this.AddSubPart(ref tsubpart, 16, 0, widthForMiniMap, 200, 0);
      }
      else
      {
        if (this.game.EditObj.Zoom != ((MiniMapPartClass) this.SubPartList[this.SubpartNr(this.Info1Id)]).tZoomLevel)
        {
          this.RemoveSubPart(this.Info1Id);
          int widthForMiniMap = DrawMod.GetWidthForMiniMap();
          SubPartClass tsubpart = (SubPartClass) new MiniMapPartClass(DrawMod.TGame, tpaintview, widthForMiniMap, 200);
          this.Info1Id = this.AddSubPart(ref tsubpart, 16, 0, widthForMiniMap, 200, 0);
        }
        this.SubPartFlag[this.SubpartNr(this.Info1Id)] = true;
      }
    }

    public override void HandleToolTip(int x, int y)
    {
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height)
        {
          this.game.EditObj.TipButton = true;
          this.game.EditObj.TipTitle = this.MouseTitle[index];
          this.game.EditObj.TipText = this.MouseText[index];
          return;
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (!(x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index]) || !(y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index]) || this.SubPartID[index] != this.Info1Id)
          ;
      }
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      int mouseCounter = this.MouseCounter;
      for (int index = 0; index <= mouseCounter; ++index)
      {
        if (this.MouseData[index] > 0 && x > this.MouseRect[index].X & x < this.MouseRect[index].X + this.MouseRect[index].Width && y > this.MouseRect[index].Y & y < this.MouseRect[index].Y + this.MouseRect[index].Height && this.MouseData[index] == 999)
        {
          this.game.EditObj.SetViewMode2 = 0;
          windowReturnClass.AddCommand(1, 9);
          windowReturnClass.AddCommand(7, 12);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      int subPartCounter = this.SubPartCounter;
      for (int index = 0; index <= subPartCounter; ++index)
      {
        if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index] && this.SubPartID[index] == this.Info1Id)
        {
          this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
          windowReturnClass.AddCommand(4, 12);
          windowReturnClass.AddCommand(4, 68);
          windowReturnClass.AddCommand(4, 67);
          windowReturnClass.AddCommand(4, 9);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      if (x > 8 & x < this.w - 8 && y < this.h - 24)
        windowReturnClass.NoMouseClickBelow = true;
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
