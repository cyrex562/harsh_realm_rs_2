// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.SEZoneButtonPartClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

// usingMicrosoft.VisualBasic;
// usingSystem;
// usingSystem.Drawing;

namespace WindowsApplication1
{
  pub class SEZoneButtonPartClass : SubPartClass
  {
     int iconSlotNr;
     string dataString;
     string description;
     bool active;
     int delta;
     bool showDelta;
     int eventpicslotPos;
     int eventpicslotNeg;
     int eventpicslotZero;

    pub void SubDispose()
    {
    }

    pub SEZoneButtonPartClass(
      int tIconSlotNr,
      string tDataString,
      string tDescript,
      bool tactive,
      bool tshowDelta = false,
      let mut tdelta: i32 = 0)
      : base(220, 40)
    {
      this.iconSlotNr = tIconSlotNr;
      this.Descript = tDescript;
      this.dataString = tDataString;
      this.active = tactive;
      this.showDelta = tshowDelta;
      this.delta = tdelta;
      this.eventpicslotPos = DrawMod.TGame.Data.FindEventPic("", 8, "SE_Present");
      this.eventpicslotNeg = DrawMod.TGame.Data.FindEventPic("", 9, "SE_Present");
      this.eventpicslotZero = DrawMod.TGame.Data.FindEventPic("", 11, "SE_Present");
    }

    pub Bitmap Paint()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTON);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
      }
      if (this.active)
      {
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local3,  local4, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         let mut local6: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(this.iconSlotNr * 42, 0, 42, 32);
        let mut srcrect: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(0, 3, 48, 32);
        let mut destrect: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2( local5,  local6, srcrect, destrect);
      }
      if (this.active)
      {
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         let mut local8: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(this.iconSlotNr * 42, 32, 42, 32);
        let mut srcrect: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 3, 48, 32);
        let mut destrect: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (this.showDelta)
      {
        bool flag = false;
        SizeF sizeF = SizeF::new();
        let mut num1: i32 = this.delta;
        if (num1 < 0)
        {
          num1 = Math.Abs(num1);
          flag = true;
        }
        str: String = num1.ToString();
        let mut num2: i32 =  Math.Round(210.0 - ( objgraphics.MeasureString(str, DrawMod.TGame.MarcFont16).Width + 4.0 + 16.0));
        let mut index: i32 = this.eventpicslotZero;
        if (flag)
          index = this.eventpicslotNeg;
        else if (this.delta > 0)
          index = this.eventpicslotPos;
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index]);
         let mut local10: &Bitmap = &bitmap;
        let mut x1: i32 = num2;
        DrawMod.DrawSimple( local9,  local10, x1, 13);
        let mut x2: i32 = num2 + 15;
        DrawMod.DrawTextColouredConsole( objgraphics, str, DrawMod.TGame.MarcFont16, x2, 11, DrawMod.TGame.seColGray);
      }
      if (!Information.IsNothing( objgraphics))
        objgraphics.Dispose();
      return this.OwnBitmap;
    }

    pub Bitmap PaintOverlay()
    {
      Graphics objgraphics = Graphics.FromImage((Image) this.OwnBitmap);
      Bitmap bitmap;
      if (!this.active)
      {
         let mut local1: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTON);
         let mut local2: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local1,  local2, 0, 0);
         let mut local3: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
         let mut local4: &Bitmap = &bitmap;
        DrawMod.Draw( local3,  local4, 0, 0, 0.0f, 0.0f, 0.0f, 0.2f);
      }
      if (this.active)
      {
         let mut local5: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ZONEBUTTONHIGH);
         let mut local6: &Bitmap = &bitmap;
        DrawMod.DrawSimple( local5,  local6, 0, 0);
      }
      Rectangle rectangle1;
      Rectangle rectangle2;
      if (!this.active)
      {
         let mut local7: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         let mut local8: &Bitmap = &bitmap;
        rectangle1 = Rectangle::new(this.iconSlotNr * 42, 0, 42, 32);
        let mut srcrect: &Rectangle = &rectangle1
        rectangle2 = Rectangle::new(0, 3, 48, 32);
        let mut destrect: &Rectangle = &rectangle2
        DrawMod.DrawSimplePart2( local7,  local8, srcrect, destrect);
      }
      if (this.active)
      {
         let mut local9: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
         let mut local10: &Bitmap = &bitmap;
        rectangle2 = Rectangle::new(this.iconSlotNr * 42, 32, 42, 32);
        let mut srcrect: &Rectangle = &rectangle2
        rectangle1 = Rectangle::new(0, 3, 48, 32);
        let mut destrect: &Rectangle = &rectangle1
        DrawMod.DrawSimplePart2( local9,  local10, srcrect, destrect);
      }
      if (!this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColGray);
      if (this.active)
        DrawMod.DrawTextColouredConsole( objgraphics, this.dataString, DrawMod.TGame.MarcFont16, 51, 11, DrawMod.TGame.seColWhite);
      if (this.showDelta)
      {
        bool flag = false;
        SizeF sizeF = SizeF::new();
        let mut num1: i32 = this.delta;
        if (num1 < 0)
        {
          num1 = Math.Abs(num1);
          flag = true;
        }
        str: String = num1.ToString();
        let mut num2: i32 =  Math.Round(210.0 - ( objgraphics.MeasureString(str, DrawMod.TGame.MarcFont16).Width + 4.0 + 16.0));
        let mut index: i32 = this.eventpicslotZero;
        if (flag)
          index = this.eventpicslotNeg;
        else if (this.delta > 0)
          index = this.eventpicslotPos;
         let mut local11: &Graphics = &objgraphics;
        bitmap = BitmapStore.GetBitmap(DrawMod.TGame.Data.EventPicNr[index]);
         let mut local12: &Bitmap = &bitmap;
        let mut x1: i32 = num2;
        DrawMod.DrawSimple( local11,  local12, x1, 13);
        let mut x2: i32 = num2 + 15;
        DrawMod.DrawTextColouredConsole( objgraphics, str, DrawMod.TGame.MarcFont16, x2, 11, DrawMod.TGame.seColGray);
      }
      if (!Information.IsNothing( objgraphics))
      {
        objgraphics.Dispose();
        objgraphics = (Graphics) null;
      }
      return this.OwnBitmap;
    }
  }
}
