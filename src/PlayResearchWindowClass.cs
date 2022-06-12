// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.PlayResearchWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
  public class PlayResearchWindowClass : WindowClass
  {
    private int LocNr;
    private int BNameId;
    private int BNameTextId;
    private int B1Id;
    private int B1TextId;
    private int B2Id;
    private int B2TextId;
    private int B3Id;
    private int B3TextId;
    private int BAllyId;
    private int Text1Id;
    private int Text2Id;
    private int Text3Id;
    private int Text4id;
    private int Text5id;
    private int text6id;
    private int text7id;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList2Id;
    private ListClass OptionsList2Obj;
    private int OptionsList3Id;
    private ListClass OptionsList3Obj;
    private int OptionsList4Id;
    private ListClass OptionsList4Obj;
    private int OptionsList5Id;
    private ListClass OptionsList5Obj;
    private int OptionsList6Id;
    private ListClass OptionsList6Obj;
    private int detailnr;
    private int detailnr2;
    private int detailnr3;
    private int peoplenr;
    private int but1id;
    private int but1textid;
    private int regnr;
    private int pplnr;
    private int pregnr;
    private SimpleList SL;
    private int[] minicard;
    private Bitmap[] tempbmp;
    private int main1;
    private int main2;
    private int main3;
    private int main4;
    private int main5;
    private int mainnr;
    private int mainx;
    private int dodetailnr;
    private DateTime lasttime;

    public PlayResearchWindowClass(ref GameClass tGame, int tempInt)
      : base(ref tGame, 1024, 768, 7)
    {
      this.minicard = new int[65];
      this.tempbmp = new Bitmap[65];
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      this.remainderofnew();
    }

    public PlayResearchWindowClass(ref GameClass tGame)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND3MARC)
    {
      this.minicard = new int[65];
      this.tempbmp = new Bitmap[65];
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      this.remainderofnew();
    }

    public PlayResearchWindowClass(ref GameClass tGame, bool Marc)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND1MARC)
    {
      this.minicard = new int[65];
      this.tempbmp = new Bitmap[65];
      this.game.EditObj.DoCardSlot = -1;
      this.game.EditObj.HandCard = -1;
      this.remainderofnew();
    }

    public void remainderofnew()
    {
      this.SL = new SimpleList();
      this.regnr = this.game.Data.Turn;
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.peoplenr = -1;
      this.dodetailnr = -1;
      this.mainnr = 2;
      this.mainnr = (double) this.game.Data.RuleVar[501] >= 1.0 ? ((double) this.game.Data.RuleVar[502] >= 1.0 ? 4 : ((double) this.game.Data.RuleVar[510] >= 1.0 ? 2 : 2)) : 5;
      if (this.game.Data.CampaignRoom > -1)
      {
        this.mainnr = 2;
        this.game.EditObj.DoCardSlot = this.game.Data.CampaignRoom;
      }
      this.regnr = this.game.Data.Turn;
      this.pplnr = this.game.Data.RegimeObj[this.regnr].People;
      this.pregnr = this.game.Data.Turn;
      this.game.EditObj.AreaSlot = -1;
      this.game.EditObj.AreaValue = -1;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.game.EditObj.AreaMap = -1;
      this.domain();
    }

    public override WindowReturnClass handleTimer()
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      TimeSpan timeSpan = DateAndTime.Now.Subtract(this.lasttime);
      if (timeSpan.Milliseconds + timeSpan.Seconds * 1000 > 100 | this.game.EditObj.DoCardSlot > -1)
      {
        this.lasttime = DateAndTime.Now;
        if (this.game.EditObj.DoCardSlot > -1)
        {
          if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot > -1)
          {
            this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
            this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot;
            this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaValue;
            this.game.EditObj.PopupValue = 1;
            windowReturnClass1.AddCommand(5, 10);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].UnitSelect)
          {
            this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
            this.game.EditObj.PopupValue = 3;
            windowReturnClass1.AddCommand(5, 10);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
          int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
          this.game.ProcessingObj.PlayCard(this.game.EditObj.DoCardSlot);
          if (Strings.Len(this.game.Data.LoadGame) > 0)
          {
            this.game.FormRef.Cursor = Cursors.WaitCursor;
            Form formRef = (Form) this.game.FormRef;
            this.game.HandyFunctionsObj.LoadGameNow();
            this.game.FormRef = (Form1) formRef;
            this.game.FormRef.Cursor = Cursors.Default;
            windowReturnClass1.AddCommand(3, 4);
            return windowReturnClass1;
          }
          int Number = 0;
          int locCounter = this.game.Data.LocCounter;
          for (int locnr = 0; locnr <= locCounter; ++locnr)
          {
            if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
            {
              int index = 0;
              do
              {
                if (this.game.Data.LocObj[locnr].Production[index] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index]).result)
                {
                  ++Number;
                  this.game.Data.LocObj[locnr].Production[index] = -1;
                  this.game.Data.LocObj[locnr].ProdPointRemainder[index] = 0;
                  this.game.Data.LocObj[locnr].ProdPercent[index] = 0;
                }
                ++index;
              }
              while (index <= 3);
            }
          }
          if (Number > 0)
          {
            int num = (int) Interaction.MsgBox((object) (Conversion.Str((object) Number) + " production lines have been cancelled due to this action card being played."), Title: ((object) "Shadow Empire : Planetary Conquest"));
          }
          if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
          {
            this.game.EditObj.PopupValue = 0;
            this.game.EditObj.FromMessage = messCounter + 1;
            windowReturnClass1.AddCommand(5, 10);
            this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
        else if (Strings.Len(this.game.Data.LoadGame) > 0)
        {
          this.game.FormRef.Cursor = Cursors.WaitCursor;
          Form1 formRef = this.game.FormRef;
          this.game.HandyFunctionsObj.LoadGameNow();
          this.game.FormRef = formRef;
          this.game.FormRef.Cursor = Cursors.Default;
          this.game.FormRef.StoredScreeny = (ScreenClass) null;
          WindowReturnClass windowReturnClass2 = new WindowReturnClass();
          windowReturnClass2.AddCommand(3, 4);
          windowReturnClass2.SetFlag(true);
          return windowReturnClass2;
        }
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    private void domain()
    {
      if (this.main1 > 0)
        this.RemoveSubPart(this.main1);
      if (this.main2 > 0)
        this.RemoveSubPart(this.main2);
      if (this.main3 > 0)
        this.RemoveSubPart(this.main3);
      if (this.main4 > 0)
        this.RemoveSubPart(this.main4);
      if (this.main5 > 0)
        this.RemoveSubPart(this.main5);
      if (this.mainx > 0)
        this.RemoveSubPart(this.mainx);
      if (this.but1id > 0)
        this.RemoveSubPart(this.but1id);
      if (this.but1textid > 0)
        this.RemoveSubPart(this.but1textid);
      if (this.game.EditObj.DoCardSlot > -1)
        return;
      if (this.game.Data.CampaignRoom > -1)
      {
        if ((double) this.game.Data.RuleVar[839] == 0.0)
        {
          if (this.game.EditObj.CampaignRoomBitmap > -1)
            this.NewBackGroundAndClearAll(1024, 768, this.game.Data.EventPicNr[this.game.EditObj.CampaignRoomBitmap]);
          else
            this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND3MARC);
        }
        else
          this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND1MARC);
      }
      else
        this.NewBackGroundAndClearAll(1024, 768, this.game.BACKGROUND3MARC);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      if (this.game.Data.CampaignRoom > -1 & Strings.Len(this.game.EditObj.CampaignRoomTitle) > 0)
      {
        if ((double) this.game.Data.RuleVar[839] == 1.0)
        {
          DrawMod.DrawTextColouredMarc(ref graphics, Strings.UCase(this.game.EditObj.CampaignRoomTitle), this.game.MarcFont2, 20, 15, Color.White);
          DrawMod.DrawBlock(ref graphics, 20, 45, 500, 3, (int) this.game.MarcCol4.R, (int) this.game.MarcCol4.G, (int) this.game.MarcCol4.B, (int) this.game.MarcCol4.A);
        }
        else
        {
          DrawMod.DrawSteveBlock(ref graphics, 200, 15, 700, 27);
          DrawMod.DrawBlock(ref graphics, 20, 15, 900, 27, 0, 0, 0, (int) byte.MaxValue);
          DrawMod.DrawSteveBlock(ref graphics, 20, 15, 900, 27);
          DrawMod.DrawTextColoured(ref graphics, this.game.EditObj.CampaignRoomTitle, new Font("Arial Black", 17f, FontStyle.Regular, GraphicsUnit.Pixel), 20, 15, Color.White);
        }
      }
      else
      {
        DrawMod.DrawSteveBlock(ref graphics, 200, 15, 700, 27);
        DrawMod.DrawTextColoured(ref graphics, "Decision Room", new Font("Arial Black", 19f, FontStyle.Regular, GraphicsUnit.Pixel), 200, 15, Color.White);
      }
      if (this.game.Data.CampaignRoom == -1)
      {
        SubPartClass tsubpart = (SubPartClass) new SteveButtonPartClass(this.game.BACKBUTTON, tBackbitmap: (ref this.OwnBitmap), bbx: 25, bby: 700);
        this.but1id = this.AddSubPart(ref tsubpart, 25, 700, 35, 35, 1);
      }
      int num1 = 200;
      if (Strings.Len(this.game.EditObj.CampaignRoomTitle) > 0)
        num1 = 25;
      Font usefont;
      bool flag;
      if ((double) this.game.Data.RuleVar[839] == 1.0)
      {
        usefont = this.game.MarcFont4;
        flag = true;
      }
      else
      {
        usefont = (Font) null;
        flag = false;
      }
      if (!(this.game.Data.CampaignRoom > -1 & (double) this.game.Data.RuleVar[839] == 1.0))
      {
        SubPartClass tsubpart1;
        if ((double) this.game.Data.RuleVar[502] == 0.0)
        {
          string buttontext = "Cards";
          if ((double) this.game.Data.RuleVar[839] == 1.0)
            buttontext = Strings.UCase(buttontext);
          if (this.mainnr != 2)
          {
            SubPartClass tsubpart2 = (SubPartClass) new TextButtonPartClass(buttontext, 150, "Click to see your cards", ref this.OwnBitmap, num1, 60, usefont: usefont, useshadow: flag, tMarcStyle: flag);
            this.main2 = this.AddSubPart(ref tsubpart2, num1, 60, 150, 35, 1);
          }
          else
          {
            tsubpart1 = (SubPartClass) new TextButtonPartClass(buttontext, 150, "Your viewing your cards already.", ref this.OwnBitmap, num1, 60, tred: (!flag), usefont: usefont, useshadow: flag, tMarcStyle: flag);
            this.mainx = this.AddSubPart(ref tsubpart1, num1, 60, 150, 35, 1);
          }
          num1 += 160;
          if ((double) this.game.Data.RuleVar[510] == 0.0)
          {
            if (this.mainnr != 3)
            {
              tsubpart1 = (SubPartClass) new TextButtonPartClass("Active Cards", 150, tBackbitmap: (ref this.OwnBitmap), bbx: num1, bby: 60, usefont: usefont, useshadow: flag, tMarcStyle: flag);
              this.main3 = this.AddSubPart(ref tsubpart1, num1, 60, 150, 35, 1);
            }
            else
            {
              tsubpart1 = (SubPartClass) new TextButtonPartClass("Active Cards", 150, tBackbitmap: (ref this.OwnBitmap), bbx: num1, bby: 60, tred: (!flag), usefont: usefont, useshadow: flag, tMarcStyle: flag);
              this.mainx = this.AddSubPart(ref tsubpart1, num1, 60, 150, 35, 1);
            }
            num1 += 160;
          }
        }
        string buttontext1 = "Reports";
        if ((double) this.game.Data.RuleVar[839] == 1.0)
          buttontext1 = Strings.UCase(buttontext1);
        if (this.mainnr != 4)
        {
          tsubpart1 = (SubPartClass) new TextButtonPartClass(buttontext1, 150, "Click to view your reports.", ref this.OwnBitmap, num1, 60, usefont: usefont, useshadow: flag, tMarcStyle: flag);
          this.main4 = this.AddSubPart(ref tsubpart1, num1, 60, 150, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new TextButtonPartClass(buttontext1, 150, "Your currently viewing your reports already.", ref this.OwnBitmap, num1, 60, tred: (!flag), usefont: usefont, useshadow: flag, tMarcStyle: flag);
          this.mainx = this.AddSubPart(ref tsubpart1, num1, 60, 150, 35, 1);
        }
        int num2 = num1 + 160;
        if ((double) this.game.Data.RuleVar[501] < 1.0)
        {
          if (this.mainnr != 5)
          {
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Research", 150, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 60, usefont: usefont, useshadow: flag, tMarcStyle: flag);
            this.main5 = this.AddSubPart(ref tsubpart1, num2, 60, 150, 35, 1);
          }
          else
          {
            tsubpart1 = (SubPartClass) new TextButtonPartClass("Research", 150, tBackbitmap: (ref this.OwnBitmap), bbx: num2, bby: 60, tred: (!flag), usefont: usefont, useshadow: flag, tMarcStyle: flag);
            this.mainx = this.AddSubPart(ref tsubpart1, num2, 60, 150, 35, 1);
          }
          int num3 = num2 + 160;
        }
      }
      string str1 = "Game Round is " + Strings.Trim(Conversion.Str((object) this.game.Data.Round));
      if (this.game.Data.AlternateRound > -1)
      {
        string str2 = "The date is ";
        DateTime dateTime = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
        if (this.game.Data.AlternateRound == 31)
        {
          dateTime = dateTime.AddMonths((this.game.Data.Round - 1) * 1);
        }
        else
        {
          TimeSpan timeSpan = new TimeSpan((this.game.Data.Round - 1) * this.game.Data.AlternateRound, 0, 0, 0);
          dateTime = dateTime.Add(timeSpan);
        }
        str1 = str2 + this.game.HandyFunctionsObj.GetMonth(dateTime.Month) + " " + Strings.Trim(Conversion.Str((object) dateTime.Day)) + " " + Strings.Trim(Conversion.Str((object) dateTime.Year));
      }
      SizeF sizeF1 = new SizeF();
      if ((double) this.game.Data.RuleVar[839] == 1.0)
      {
        if (this.game.Data.Turn > -1)
        {
          int num4 = 940;
          int num5 = 16;
          ref Graphics local1 = ref graphics;
          Bitmap bitmap = BitmapStore.GetBitmap(this.game.MARCOPTSLOTS);
          ref Bitmap local2 = ref bitmap;
          int x = num4;
          int y = num5;
          DrawMod.DrawSimple(ref local1, ref local2, x, y);
          DrawMod.DrawTextColouredMarc(ref graphics, "PP", this.game.MarcFont8, num4 + 7, num5 + 4, Color.White);
          string str3 = this.game.Data.RegimeObj[this.game.Data.Turn].ResPts.ToString();
          SizeF sizeF2 = graphics.MeasureString(str3, this.game.MarcFont6);
          DrawMod.DrawTextColouredMarc(ref graphics, str3, this.game.MarcFont8, (int) Math.Round((double) ((float) (num4 + 57) - sizeF2.Width)), num5 + 2, Color.White);
          Rectangle trect = new Rectangle((int) Math.Round((double) ((float) (num4 + 57) - sizeF2.Width)), num5 + 2, 75, 20);
          this.AddMouse(ref trect, "Political Points", "You need PP to play regime action cards");
        }
      }
      else
      {
        Font font = new Font(this.game.FontCol.Families[1], 13f, FontStyle.Regular, GraphicsUnit.Pixel);
        string str4 = "You have " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ResPts)) + " pp. " + str1;
        SizeF sizeF3 = graphics.MeasureString(str4, font);
        DrawMod.DrawText(ref graphics, str4, font, (int) Math.Round((double) (870f - sizeF3.Width)), 20);
      }
      if (this.mainnr == 2)
        this.docardshand();
      if (this.mainnr == 3)
        this.docardsplayed();
      if (this.mainnr == 4)
        this.doreport();
      if (this.mainnr != 5)
        return;
      this.dostuff();
    }

    private void clearsubstuff()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
      {
        this.RemoveSubPart(this.Text2Id);
        this.Text2Id = 0;
      }
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Text4id > 0)
        this.RemoveSubPart(this.Text4id);
      if (this.Text5id > 0)
        this.RemoveSubPart(this.Text5id);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      if (this.BAllyId > 0)
        this.RemoveSubPart(this.BAllyId);
      if (this.OptionsListId > 0)
      {
        this.RemoveSubPart(this.OptionsListId);
        this.OptionsListId = 0;
      }
      if (this.OptionsList2Id > 0)
      {
        this.RemoveSubPart(this.OptionsList2Id);
        this.OptionsList2Id = 0;
      }
      if (this.OptionsList3Id > 0)
      {
        this.RemoveSubPart(this.OptionsList3Id);
        this.OptionsList3Id = 0;
      }
      if (this.OptionsList4Id > 0)
      {
        this.RemoveSubPart(this.OptionsList4Id);
        this.OptionsList4Id = 0;
      }
      if (this.OptionsList5Id > 0)
      {
        this.RemoveSubPart(this.OptionsList5Id);
        this.OptionsList5Id = 0;
      }
      if (this.OptionsList6Id > 0)
      {
        this.RemoveSubPart(this.OptionsList6Id);
        this.OptionsList6Id = 0;
      }
      int index = 0;
      do
      {
        if (this.minicard[index] > 0)
          this.RemoveSubPart(this.minicard[index]);
        this.tempbmp[index] = (Bitmap) null;
        ++index;
      }
      while (index <= 64);
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.game.EditObj.AreaSlot = -1;
      this.game.EditObj.AreaValue = -1;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.game.EditObj.AreaMap = -1;
    }

    private void docardsplayed()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.BAllyId > 0)
        this.RemoveSubPart(this.BAllyId);
      if (this.Text4id > 0)
        this.RemoveSubPart(this.Text4id);
      if (this.Text5id > 0)
        this.RemoveSubPart(this.Text5id);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      int index1 = 0;
      do
      {
        if (this.minicard[index1] > 0)
          this.RemoveSubPart(this.minicard[index1]);
        ++index1;
      }
      while (index1 <= 64);
      Graphics graphics1 = Graphics.FromImage((Image) this.OwnBitmap);
      graphics1.SmoothingMode = SmoothingMode.AntiAlias;
      graphics1.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics1.TextContrast = 1;
      ref Graphics local1 = ref graphics1;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.RESEARCHOVERPRINT);
      ref Bitmap local2 = ref bitmap1;
      DrawMod.DrawSimple(ref local1, ref local2, 610, 120);
      if (this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryCounter > 64)
      {
        this.OptionsList4Obj = new ListClass();
        int tlistselect1 = -1;
        int num = -1;
        int cardHistoryCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryCounter;
        for (int tdata = 0; tdata <= cardHistoryCounter; ++tdata)
        {
          ++num;
          if (this.detailnr == tdata)
            tlistselect1 = num;
          this.OptionsList4Obj.add(this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistory[tdata]].Title, tdata, Conversions.ToString(this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistory[tdata]].PPCost));
        }
        if (this.OptionsList4Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
        }
        else
        {
          ListClass optionsList4Obj = this.OptionsList4Obj;
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList4Obj, 16, 550, tlistselect2, game, tHeader: "Action Cards", tShowPair: true, tValueWidth: 150, tbackbitmap: (ref local3), bbx: 10, bby: 150, overruleFont: (ref local4));
          this.OptionsList4Id = this.AddSubPart(ref tsubpart, 10, 160, 550, 304, 0);
        }
      }
      else
      {
        int cardHistoryCounter = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryCounter;
        int num1 = (int) Math.Round(Conversion.Int((double) (int) Math.Round(Conversion.Int(Math.Sqrt((double) (cardHistoryCounter + 1))) + 1.0) * 1.5));
        int num2 = (int) Math.Round(Conversion.Int(520.0 / (double) num1));
        int num3 = (int) Math.Round(Conversion.Int((double) num2 * 1.5));
        int num4 = -1;
        int num5 = 0;
        int num6 = cardHistoryCounter;
        for (int index2 = 0; index2 <= num6; ++index2)
        {
          ++num4;
          if (num4 >= num1)
          {
            num4 = 0;
            ++num5;
          }
          int x = (int) Math.Round(13.0 + (double) num4 * ((double) num2 * 1.1));
          int y = (int) Math.Round(156.0 + (double) num5 * ((double) num3 * 1.1));
          if (Information.IsNothing((object) this.tempbmp[index2]))
          {
            this.tempbmp[index2] = new Bitmap(num2, num3);
            this.tempbmp[index2].SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
            Graphics graphics2 = Graphics.FromImage((Image) this.tempbmp[index2]);
            ref Graphics local5 = ref graphics2;
            Bitmap bitmap2 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistory[index2], this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryRound[index2]);
            ref Bitmap local6 = ref bitmap2;
            int w = num2;
            int h = num3;
            DrawMod.DrawScaled(ref local5, ref local6, 0, 0, w, h);
          }
          int[] minicard = this.minicard;
          int index3 = index2;
          SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(this.tempbmp[index2]);
          int num7 = this.AddSubPart(ref tsubpart, x, y, num2, num3, 1);
          minicard[index3] = num7;
          if (this.detailnr == index2)
          {
            DrawMod.DrawRectangle(ref graphics1, x - 1, y - 1, num2 + 1, num3 + 1, 0, 0, (int) byte.MaxValue, 185);
            DrawMod.DrawRectangle(ref graphics1, x - 2, y - 2, num2 + 3, num3 + 3, 0, 0, (int) byte.MaxValue, 125);
            DrawMod.DrawRectangle(ref graphics1, x - 3, y - 3, num2 + 5, num3 + 5, 0, 0, (int) byte.MaxValue, 65);
          }
        }
      }
      if (this.detailnr <= -1)
        return;
      ref Graphics local7 = ref graphics1;
      Bitmap bitmap3 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistory[this.detailnr]);
      ref Bitmap local8 = ref bitmap3;
      DrawMod.DrawSimple(ref local7, ref local8, 660, 160);
      if (this.game.Data.AlternateRound > -1)
      {
        DateTime dateTime1 = new DateTime().AddYears(this.game.Data.StartData.Year - 1).AddMonths(this.game.Data.StartData.Month - 1).AddDays((double) (this.game.Data.StartData.Day - 1));
        DateTime dateTime2;
        if (this.game.Data.AlternateRound == 31)
        {
          dateTime2 = dateTime1.AddMonths((this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryRound[this.detailnr] - 1) * 1);
        }
        else
        {
          TimeSpan timeSpan = new TimeSpan((this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryRound[this.detailnr] - 1) * this.game.Data.AlternateRound, 0, 0, 0);
          dateTime2 = dateTime1.Add(timeSpan);
        }
        string str1;
        string str2 = str1 + this.game.HandyFunctionsObj.GetMonth(dateTime2.Month) + " " + Strings.Trim(Conversion.Str((object) dateTime2.Day)) + " " + Strings.Trim(Conversion.Str((object) dateTime2.Year));
        DrawMod.DrawTextColoured(ref graphics1, "Played " + str2, new Font("Times New Roman", 19f, FontStyle.Bold, GraphicsUnit.Pixel), 715, 625, Color.White);
      }
      else
        DrawMod.DrawTextColoured(ref graphics1, "Played in round " + Strings.Trim(Conversion.Str((object) this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardHistoryRound[this.detailnr])), new Font("Times New Roman", 19f, FontStyle.Bold, GraphicsUnit.Pixel), 715, 625, Color.White);
    }

    private void docardshand()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Text4id > 0)
        this.RemoveSubPart(this.Text4id);
      if (this.Text5id > 0)
        this.RemoveSubPart(this.Text5id);
      if (this.BAllyId > 0)
        this.RemoveSubPart(this.BAllyId);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      if (this.B3Id > 0)
        this.RemoveSubPart(this.B3Id);
      if (this.B3TextId > 0)
        this.RemoveSubPart(this.B3TextId);
      int index1 = 0;
      do
      {
        if (this.minicard[index1] > 0)
          this.RemoveSubPart(this.minicard[index1]);
        ++index1;
      }
      while (index1 <= 64);
      Graphics objGraphics = Graphics.FromImage((Image) this.OwnBitmap);
      objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
      objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      objGraphics.TextContrast = 1;
      ref Graphics local1 = ref objGraphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.RESEARCHOVERPRINT);
      ref Bitmap local2 = ref bitmap1;
      DrawMod.DrawSimple(ref local1, ref local2, 610, 120);
      this.ClearMouse();
      SimpleList simpleList = new SimpleList();
      int actionCardCounter1;
      if (this.game.Data.Turn > -1)
      {
        actionCardCounter1 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
        int num = actionCardCounter1;
        for (index1 = 0; index1 <= num; ++index1)
        {
          int tweight = this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].ColorScheme * 1000 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1];
          simpleList.Add(index1, tweight);
        }
      }
      simpleList.Sort();
      SubPartClass tsubpart1;
      Bitmap bitmap2;
      Rectangle trect1;
      if ((double) this.game.Data.RuleVar[839] == 0.0)
      {
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter > 64)
        {
          this.OptionsList4Obj = new ListClass();
          int tlistselect1 = -1;
          int num = -1;
          int actionCardCounter2 = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter;
          for (index1 = 0; index1 <= actionCardCounter2; ++index1)
          {
            ++num;
            if (this.detailnr == index1)
              tlistselect1 = num;
            this.OptionsList4Obj.add(this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].Title, index1, Conversions.ToString(this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]].PPCost));
          }
          if (this.OptionsList4Id > 0)
          {
            this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, tlistselect1);
            this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
          }
          else
          {
            ListClass optionsList4Obj = this.OptionsList4Obj;
            int tlistselect2 = tlistselect1;
            GameClass game = this.game;
            ref Bitmap local3 = ref this.OwnBitmap;
            Font font = (Font) null;
            ref Font local4 = ref font;
            SubPartClass tsubpart2 = (SubPartClass) new ListSubPartClass(optionsList4Obj, 16, 550, tlistselect2, game, tHeader: "Action Cards", tShowPair: true, tValueWidth: 150, tbackbitmap: (ref local3), bbx: 10, bby: 150, overruleFont: (ref local4));
            this.OptionsList4Id = this.AddSubPart(ref tsubpart2, 10, 160, 550, 304, 0);
          }
        }
        else
        {
          int num1 = (int) Math.Round(Conversion.Int((double) (int) Math.Round(Conversion.Int(Math.Sqrt((double) (actionCardCounter1 + 1))) + 1.0) * 1.5));
          int num2 = (int) Math.Round(Conversion.Int(520.0 / (double) num1));
          int num3 = (int) Math.Round(Conversion.Int((double) num2 * 1.5));
          int num4 = -1;
          int num5 = 0;
          int counter = simpleList.Counter;
          for (int index2 = 0; index2 <= counter; ++index2)
          {
            index1 = simpleList.Id[index2];
            ++num4;
            if (num4 >= num1)
            {
              num4 = 0;
              ++num5;
            }
            int x = (int) Math.Round(13.0 + (double) num4 * ((double) num2 * 1.1));
            int y = (int) Math.Round(156.0 + (double) num5 * ((double) num3 * 1.1));
            if (Information.IsNothing((object) this.tempbmp[index1]))
            {
              this.tempbmp[index1] = new Bitmap(num2, num3);
              this.tempbmp[index1].SetResolution((float) DrawMod.DPIx, (float) DrawMod.DPIy);
              Graphics graphics = Graphics.FromImage((Image) this.tempbmp[index1]);
              ref Graphics local5 = ref graphics;
              Bitmap bitmap3 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[index1]);
              ref Bitmap local6 = ref bitmap3;
              int w = num2;
              int h = num3;
              DrawMod.DrawScaled(ref local5, ref local6, 0, 0, w, h);
            }
            int[] minicard = this.minicard;
            int index3 = index1;
            tsubpart1 = (SubPartClass) new ButtonPartClass(this.tempbmp[index1]);
            int num6 = this.AddSubPart(ref tsubpart1, x, y, num2, num3, 1);
            minicard[index3] = num6;
            if (this.detailnr == index1)
            {
              DrawMod.DrawRectangle(ref objGraphics, x - 1, y - 1, num2 + 1, num3 + 1, 0, 0, (int) byte.MaxValue, 185);
              DrawMod.DrawRectangle(ref objGraphics, x - 2, y - 2, num2 + 3, num3 + 3, 0, 0, (int) byte.MaxValue, 125);
              DrawMod.DrawRectangle(ref objGraphics, x - 3, y - 3, num2 + 5, num3 + 5, 0, 0, (int) byte.MaxValue, 65);
            }
          }
        }
      }
      else
      {
        int num = (int) Math.Round(Conversion.Int(1650.0 / (double) (simpleList.Counter + 1)));
        if (num > 110)
          num = 110;
        int x1 = 25 - num;
        int y1 = 140;
        int counter = simpleList.Counter;
        for (index1 = 0; index1 <= counter; ++index1)
        {
          if (this.detailnr == -1)
            this.detailnr = simpleList.Id[index1];
          x1 += num;
          if (x1 > 550 & y1 > 200)
          {
            x1 = 25;
            y1 = 454;
          }
          else if (x1 > 550)
          {
            x1 = 25;
            y1 = 297;
          }
          int nr = this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[simpleList.Id[index1]];
          ref Graphics local7 = ref objGraphics;
          bitmap2 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, nr, size: 2);
          ref Bitmap local8 = ref bitmap2;
          int x2 = x1;
          int y2 = y1;
          DrawMod.DrawSimple(ref local7, ref local8, x2, y2);
          Rectangle trect2;
          if (this.game.Data.ActionCardObj[nr].MouseOver.Length > 0)
          {
            trect2 = new Rectangle(x1, y1, 110, 147);
            trect1 = trect2;
            this.AddMouse(ref trect1, "REGIME CARD", this.game.Data.ActionCardObj[nr].MouseOver + "\r\nClick for close up and play option", simpleList.Id[index1] + 100);
          }
          else
          {
            trect1 = new Rectangle(x1, y1, 110, 147);
            trect2 = trect1;
            this.AddMouse(ref trect2, "REGIME CARD", "Click for close up and play option", simpleList.Id[index1] + 100);
          }
        }
      }
      if (this.detailnr <= -1)
        return;
      Font usefont;
      bool flag;
      if ((double) this.game.Data.RuleVar[839] == 0.0)
      {
        usefont = (Font) null;
        flag = false;
      }
      else
      {
        usefont = this.game.MarcFont2;
        flag = true;
      }
      if ((double) this.game.Data.RuleVar[839] == 0.0)
      {
        ref Graphics local9 = ref objGraphics;
        bitmap2 = this.game.CustomBitmapObj.DrawActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]);
        ref Bitmap local10 = ref bitmap2;
        DrawMod.DrawSimple(ref local9, ref local10, 660, 160);
      }
      else
      {
        ref Graphics local11 = ref objGraphics;
        bitmap2 = this.game.CustomBitmapObj.DrawActionCardMarc2(this.game.Data.Turn, this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]);
        ref Bitmap local12 = ref bitmap2;
        DrawMod.DrawSimple(ref local11, ref local12, 710, 260);
        if (this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].MouseOver.Length > 0)
        {
          trect1 = new Rectangle(710, 260, 190, 266);
          Rectangle trect3 = trect1;
          this.AddMouse(ref trect3, "SELECTED REGIME CARD", this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].MouseOver + "\r\nClick on the 'play card' button to play this card.", simpleList.Id[index1] + 100);
        }
        else
        {
          trect1 = new Rectangle(710, 260, 190, 266);
          Rectangle trect4 = trect1;
          this.AddMouse(ref trect4, "SELECTED REGIME CARD", "Click on the 'play card' button to play this card.", simpleList.Id[index1] + 100);
        }
      }
      if (this.game.Data.RegimeObj[this.game.Data.Turn].ResPts >= this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].PPCost | this.game.Data.ActionCardObj[this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]].PPCost == 0)
      {
        if ((double) this.game.Data.RuleVar[839] == 0.0)
        {
          tsubpart1 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 715, bby: 625, usefont: usefont, useshadow: flag, tMarcStyle: flag);
          this.B3Id = this.AddSubPart(ref tsubpart1, 715, 625, 200, 35, 1);
        }
        else
        {
          tsubpart1 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 200, "Click to play this card.", ref this.OwnBitmap, 700, 560, usefont: usefont, useshadow: flag, tMarcStyle: flag);
          this.B3Id = this.AddSubPart(ref tsubpart1, 700, 560, 200, 35, 1);
        }
      }
      else if ((double) this.game.Data.RuleVar[839] == 0.0)
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 200, tBackbitmap: (ref this.OwnBitmap), bbx: 715, bby: 625, tinactive: true, usefont: usefont, useshadow: flag, tMarcStyle: flag);
        this.B3TextId = this.AddSubPart(ref tsubpart1, 715, 625, 200, 35, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("PLAY CARD", 200, "You do not have the PP to play this card.", ref this.OwnBitmap, 700, 560, true, usefont: usefont, useshadow: flag, tMarcStyle: flag);
        this.B3TextId = this.AddSubPart(ref tsubpart1, 700, 560, 200, 35, 1);
      }
    }

    private void doreport()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
      {
        this.RemoveSubPart(this.Text2Id);
        this.Text2Id = 0;
      }
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Text4id > 0)
        this.RemoveSubPart(this.Text4id);
      if (this.Text5id > 0)
        this.RemoveSubPart(this.Text5id);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.BAllyId > 0)
        this.RemoveSubPart(this.BAllyId);
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      this.OptionsList5Obj = new ListClass();
      int tlistselect1 = -1;
      int num1 = -1;
      int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
      for (int tdata = 0; tdata <= messCounter; ++tdata)
      {
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessBackPic[tdata] == -2)
        {
          ++num1;
          if (this.detailnr == tdata)
            tlistselect1 = num1;
          int num2 = Strings.InStr(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], "\r\n");
          string str;
          if (Information.IsNothing((object) num2) | num2 <= 0)
          {
            str = Strings.Left(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], 50) + "...";
          }
          else
          {
            str = Strings.Left(this.game.Data.RegimeObj[this.game.Data.Turn].MessString[tdata], num2);
            if (Strings.Len(str) > 50)
              str = Strings.Left(str, 50) + "...";
          }
          this.OptionsList5Obj.add(str, tdata);
        }
      }
      if (this.OptionsList5Obj.ListCount > -1)
      {
        if (this.OptionsList5Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList5Id)].Refresh(this.OptionsList5Obj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsList5Id)] = true;
        }
        else
        {
          ListClass optionsList5Obj = this.OptionsList5Obj;
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local1 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList5Obj, 16, 550, tlistselect2, game, tHeader: "This rounds reports", tbackbitmap: (ref local1), bbx: 30, bby: 160, overruleFont: (ref local2));
          this.OptionsList5Id = this.AddSubPart(ref tsubpart, 30, 160, 550, 304, 0);
        }
        if (this.detailnr <= -1)
          return;
        int num3;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr] > -1)
        {
          int index = this.game.Data.RegimeObj[this.game.Data.Turn].MessFrontPic[this.detailnr];
          int num4 = index < 10000 ? this.game.Data.EventPicNr[index] : this.game.Data.HistoricalUnitObj[index - 10000].CommanderSpriteID;
          if (num4 > -1)
          {
            int num5 = BitmapStore.GetWidth(num4);
            int num6 = BitmapStore.Getheight(num4);
            if (num5 > 320)
            {
              num6 = (int) Math.Round((double) num6 * (320.0 / (double) num5));
              num5 = (int) Math.Round((double) num5 * (320.0 / (double) num5));
            }
            SubPartClass tsubpart = (SubPartClass) new ButtonPartClass(num4, tResizeX: num5, tresizeY: num6);
            this.Text1Id = this.AddSubPart(ref tsubpart, (int) Math.Round(790.0 - (double) num5 / 2.0), 140, num5, num6, 0);
            DrawMod.DrawRectangle(ref graphics, (int) Math.Round(789.0 - (double) num5 / 2.0), 139, num5 + 2, num6 + 2, 0, 0, 0, (int) byte.MaxValue);
            DrawMod.DrawRectangle(ref graphics, (int) Math.Round(788.0 - (double) num5 / 2.0), 138, num5 + 4, num6 + 4, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
            num3 = 20 + num6 + 25;
          }
        }
        int trows = (int) Math.Round(35.0 - (double) num3 / 16.0);
        if (this.Text2Id != 0)
          return;
        SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 360, trows, new Font("Times New Roman", 16f, FontStyle.Regular, GraphicsUnit.Pixel), "", false, this.game.Data.RegimeObj[this.game.Data.Turn].MessString[this.detailnr], Color.White, tbackbitmap: (ref this.OwnBitmap), bbx: 630, bby: (120 + num3));
        this.Text2Id = this.AddSubPart(ref tsubpart1, 630, 120 + num3, 360, 16 * (trows + 3), 0);
      }
      else
        DrawMod.DrawText(ref graphics, "No reports available.", this.game.GameFont1, 10, 150);
    }

    private void dostuff()
    {
      if (this.Text1Id > 0)
        this.RemoveSubPart(this.Text1Id);
      if (this.Text2Id > 0)
        this.RemoveSubPart(this.Text2Id);
      if (this.Text3Id > 0)
        this.RemoveSubPart(this.Text3Id);
      if (this.Text4id > 0)
        this.RemoveSubPart(this.Text4id);
      if (this.Text5id > 0)
        this.RemoveSubPart(this.Text5id);
      if (this.text6id > 0)
        this.RemoveSubPart(this.text6id);
      if (this.BAllyId > 0)
        this.RemoveSubPart(this.BAllyId);
      if (this.text7id > 0)
        this.RemoveSubPart(this.text7id);
      if (this.B1Id > 0)
        this.RemoveSubPart(this.B1Id);
      if (this.B1TextId > 0)
        this.RemoveSubPart(this.B1TextId);
      if (this.B2Id > 0)
        this.RemoveSubPart(this.B2Id);
      if (this.B2TextId > 0)
        this.RemoveSubPart(this.B2TextId);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
      graphics.TextContrast = 1;
      ref Graphics local1 = ref graphics;
      Bitmap bitmap1 = BitmapStore.GetBitmap(this.game.RESEARCHOVERPRINT);
      ref Bitmap local2 = ref bitmap1;
      DrawMod.DrawSimple(ref local1, ref local2, 610, 120);
      this.OptionsListObj = new ListClass();
      if (this.detailnr > this.game.Data.ResearchCounter)
        this.detailnr = -1;
      int num1 = -1;
      int num2 = -1;
      if (this.game.Data.ResearchCounter > -1)
      {
        int researchCounter = this.game.Data.ResearchCounter;
        for (int tdata = 0; tdata <= researchCounter; ++tdata)
        {
          if (!this.game.Data.RegimeObj[this.pregnr].ResField[tdata])
          {
            int num3 = 1;
            if (this.game.Data.ResearchObj[tdata].PreReq > -1 && !this.game.Data.RegimeObj[this.pregnr].ResField[this.game.Data.ResearchObj[tdata].PreReq])
              num3 = 0;
            if (this.game.Data.ResearchObj[tdata].PreReq2 > -1 && !this.game.Data.RegimeObj[this.pregnr].ResField[this.game.Data.ResearchObj[tdata].PreReq2])
              num3 = 0;
            if (this.game.Data.ResearchObj[tdata].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] < 0 | this.game.Data.ResearchObj[tdata].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] > 9998)
              num3 = 0;
            if (num3 == 1)
            {
              ++num2;
              if (this.detailnr == tdata)
                num1 = num2;
              string tname = this.game.Data.ResearchObj[tdata].Name;
              int Number = 0;
              if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true) & (double) this.game.Data.RuleVar[530] == 1.0)
              {
                int regimeCounter = this.game.Data.RegimeCounter;
                for (int reg2 = 0; reg2 <= regimeCounter; ++reg2)
                {
                  if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) & this.game.Data.Turn != reg2 && this.game.Data.RegimeObj[reg2].ResField[tdata])
                    ++Number;
                }
              }
              if (Number > 0)
                tname = tname + " (" + Strings.Trim(Conversion.Str((object) Number)) + ")";
              this.OptionsListObj.add(tname, tdata);
            }
          }
        }
        this.OptionsListObj.Sort();
        int tlistselect1 = -1;
        int listCount = this.OptionsListObj.ListCount;
        for (int index = 0; index <= listCount; ++index)
        {
          if (this.detailnr == this.OptionsListObj.ListData[index])
            tlistselect1 = index;
        }
        if (this.OptionsListId > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsListId)].Refresh(this.OptionsListObj, tlistselect1);
          this.SubPartFlag[this.SubpartNr(this.OptionsListId)] = true;
        }
        else
        {
          ListClass optionsListObj = this.OptionsListObj;
          int tlistselect2 = tlistselect1;
          GameClass game = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 30, 150, tlistselect2, game, tHeader: "Available Research", tbackbitmap: (ref local3), bbx: 400, bby: 160, overruleFont: (ref local4));
          this.OptionsListId = this.AddSubPart(ref tsubpart, 400, 160, 150, 528, 0);
        }
      }
      this.OptionsList3Obj = new ListClass();
      if (this.detailnr3 > this.game.Data.ResearchCounter)
        this.detailnr3 = -1;
      num1 = -1;
      int num4 = -1;
      if (this.game.Data.ResearchCounter > -1)
      {
        int researchCounter = this.game.Data.ResearchCounter;
        for (int tdata = 0; tdata <= researchCounter; ++tdata)
        {
          if (!this.game.Data.RegimeObj[this.pregnr].ResField[tdata])
          {
            int num5 = 1;
            if (this.game.Data.ResearchObj[tdata].PreReq > -1 && !this.game.Data.RegimeObj[this.pregnr].ResField[this.game.Data.ResearchObj[tdata].PreReq])
              num5 = 0;
            if (this.game.Data.ResearchObj[tdata].PreReq2 > -1 && !this.game.Data.RegimeObj[this.pregnr].ResField[this.game.Data.ResearchObj[tdata].PreReq2])
              num5 = 0;
            if (this.game.Data.ResearchObj[tdata].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] < 0 | this.game.Data.ResearchObj[tdata].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] > 9998)
              num5 = 1;
            if (num5 == 0)
            {
              ++num4;
              if (this.detailnr3 == tdata)
                num1 = num4;
              string tname = this.game.Data.ResearchObj[tdata].Name;
              int Number = 0;
              if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true) & (double) this.game.Data.RuleVar[530] == 1.0)
              {
                int regimeCounter = this.game.Data.RegimeCounter;
                for (int reg2 = 0; reg2 <= regimeCounter; ++reg2)
                {
                  if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) & this.game.Data.Turn != reg2 && this.game.Data.RegimeObj[reg2].ResField[tdata])
                    ++Number;
                }
              }
              if (Number > 0)
                tname = tname + " (" + Strings.Trim(Conversion.Str((object) Number)) + ")";
              this.OptionsList3Obj.add(tname, tdata);
            }
          }
        }
        this.OptionsList3Obj.Sort();
        int tlistselect3 = -1;
        int listCount = this.OptionsList3Obj.ListCount;
        for (int index = 0; index <= listCount; ++index)
        {
          if (this.detailnr3 == this.OptionsList3Obj.ListData[index])
            tlistselect3 = index;
        }
        if (this.OptionsList3Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, tlistselect3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
        }
        else
        {
          ListClass optionsList3Obj = this.OptionsList3Obj;
          int tlistselect4 = tlistselect3;
          GameClass game = this.game;
          ref Bitmap local5 = ref this.OwnBitmap;
          Font font = (Font) null;
          ref Font local6 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList3Obj, 30, 150, tlistselect4, game, tHeader: "Not yet available", tbackbitmap: (ref local5), bbx: 220, bby: 160, overruleFont: (ref local6));
          this.OptionsList3Id = this.AddSubPart(ref tsubpart, 220, 160, 150, 528, 0);
        }
      }
      num1 = -1;
      int num6 = -1;
      if (this.detailnr2 > this.game.Data.ResearchCounter)
        this.detailnr2 = -1;
      this.OptionsList2Obj = new ListClass();
      if (this.game.Data.ResearchCounter > -1)
      {
        int researchCounter1 = this.game.Data.ResearchCounter;
        for (int tdata = 0; tdata <= researchCounter1; ++tdata)
        {
          if (this.game.Data.RegimeObj[this.pregnr].ResField[tdata])
          {
            int num7 = 1;
            int researchCounter2 = this.game.Data.ResearchCounter;
            for (int index = 0; index <= researchCounter2; ++index)
            {
              if (this.game.Data.RegimeObj[this.pregnr].ResField[index] && this.game.Data.ResearchObj[index].Blocks == tdata)
              {
                num7 = 0;
                if (this.game.HandyFunctionsObj.HasAllies(this.pregnr, true) & (double) this.game.Data.RuleVar[530] == 1.0)
                  num7 = 1;
              }
            }
            if (num7 == 1)
            {
              ++num6;
              if (this.detailnr2 == tdata)
                num1 = num6;
              string tname = this.game.Data.ResearchObj[tdata].Name;
              int Number = 0;
              if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true) & (double) this.game.Data.RuleVar[530] == 1.0)
              {
                int regimeCounter = this.game.Data.RegimeCounter;
                for (int reg2 = 0; reg2 <= regimeCounter; ++reg2)
                {
                  if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) & this.game.Data.Turn != reg2 && this.game.Data.RegimeObj[reg2].ResField[tdata])
                    ++Number;
                }
              }
              if (Number > 0)
                tname = tname + " (" + Strings.Trim(Conversion.Str((object) Number)) + ")";
              this.OptionsList2Obj.add(tname, tdata);
            }
          }
        }
      }
      this.OptionsList2Obj.Sort();
      int tlistselect5 = -1;
      int listCount1 = this.OptionsList2Obj.ListCount;
      for (int index = 0; index <= listCount1; ++index)
      {
        if (this.detailnr2 == this.OptionsList2Obj.ListData[index])
          tlistselect5 = index;
      }
      if (this.OptionsList2Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList2Id)].Refresh(this.OptionsList2Obj, tlistselect5);
        this.SubPartFlag[this.SubpartNr(this.OptionsList2Id)] = true;
      }
      else
      {
        ListClass optionsList2Obj = this.OptionsList2Obj;
        int tlistselect6 = tlistselect5;
        GameClass game = this.game;
        ref Bitmap local7 = ref this.OwnBitmap;
        Font font = (Font) null;
        ref Font local8 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList2Obj, 30, 150, tlistselect6, game, tHeader: "Known Research", tHeaderCenter: false, tbackbitmap: (ref local7), bbx: 40, bby: 160, overruleFont: (ref local8));
        this.OptionsList2Id = this.AddSubPart(ref tsubpart, 40, 160, 150, 528, 0);
      }
      int index1 = this.detailnr;
      if (index1 == -1)
        index1 = this.detailnr2;
      if (index1 == -1)
        index1 = this.detailnr3;
      if (index1 <= -1)
        return;
      int x1 = 650;
      int num8 = 0;
      if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true))
      {
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int reg2 = 0; reg2 <= regimeCounter; ++reg2)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) & this.game.Data.Turn != reg2 & (double) this.game.Data.RuleVar[530] == 1.0 && this.game.Data.RegimeObj[reg2].ResField[index1])
          {
            if (num8 == 0)
              DrawMod.DrawText(ref graphics, "Allies:", this.game.GameFont1, x1, 145);
            num8 = 1;
            x1 += 37;
            ref Graphics local9 = ref graphics;
            Bitmap bitmap2 = BitmapStore.GetBitmap(this.game.Data.RegimeObj[reg2].HQSpriteNr);
            ref Bitmap local10 = ref bitmap2;
            int x2 = x1;
            DrawMod.DrawSimple(ref local9, ref local10, x2, 143);
          }
        }
      }
      if (index1 == this.detailnr)
        DrawMod.DrawSimple(ref graphics, ref this.game.CARD3B, 648, 173);
      else if (index1 == this.detailnr2)
        DrawMod.DrawSimple(ref graphics, ref this.game.CARD2B, 648, 173);
      else if (index1 == this.detailnr3)
        DrawMod.DrawSimple(ref graphics, ref this.game.CARD1B, 648, 173);
      DrawMod.DrawTextColoured(ref graphics, this.game.Data.ResearchObj[index1].Name, new Font("Arial Black", 19f, FontStyle.Regular, GraphicsUnit.Pixel), 675, 201, Color.White);
      if (this.game.Data.ResearchObj[index1].SFTypePic > -1)
      {
        int picSpriteId = this.game.Data.SFTypeObj[this.game.Data.ResearchObj[index1].SFTypePic].PicSpriteID;
        if (this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[this.game.Data.ResearchObj[index1].SFTypePic].ExtraCounter;
          for (int index2 = 0; index2 <= extraCounter; ++index2)
          {
            if (this.game.Data.SFTypeObj[this.game.Data.ResearchObj[index1].SFTypePic].ExtraCode[index2] == this.game.Data.RegimeObj[this.game.Data.Turn].ExtraGraphicUse)
              picSpriteId = this.game.Data.SFTypeObj[this.game.Data.ResearchObj[index1].SFTypePic].ExtraPicSpriteID[index2];
          }
        }
        ref Graphics local11 = ref graphics;
        Bitmap bitmap3 = BitmapStore.GetBitmap(picSpriteId);
        ref Bitmap local12 = ref bitmap3;
        DrawMod.DrawScaled(ref local11, ref local12, 665, 240, 260, 194);
        ref Graphics local13 = ref graphics;
        Bitmap bitmap4 = BitmapStore.GetBitmap(this.game.ACTIONFRAME);
        ref Bitmap local14 = ref bitmap4;
        DrawMod.DrawSimple(ref local13, ref local14, 665, 240);
      }
      if (this.game.Data.ResearchObj[index1].PreReq > -1)
      {
        string tstring = "PreReq: " + this.game.Data.ResearchObj[this.game.Data.ResearchObj[index1].PreReq].Name;
        DrawMod.DrawTextColoured(ref graphics, tstring, new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 675, 450, Color.Black);
      }
      if (this.game.Data.ResearchObj[index1].PreReq2 > -1)
      {
        string tstring = "PreReq: " + this.game.Data.ResearchObj[this.game.Data.ResearchObj[index1].PreReq2].Name;
        DrawMod.DrawTextColoured(ref graphics, tstring, new Font("Times New Roman", 13f, FontStyle.Regular, GraphicsUnit.Pixel), 675, 465, Color.Black);
      }
      string tstring1 = this.game.Data.ResearchObj[index1].CostType <= -1 ? Conversion.Str((object) Conversion.Int((float) this.game.Data.ResearchObj[index1].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] * this.game.Data.ResCostMod)) + "pp" : Conversion.Str((object) Conversion.Int((float) this.game.Data.ResearchObj[index1].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] * this.game.Data.ResCostMod)) + " " + this.game.Data.RegimeSlotName[this.game.Data.ResearchObj[index1].CostType];
      DrawMod.DrawTextColoured(ref graphics, tstring1, new Font("Times New Roman", 25f, FontStyle.Regular, GraphicsUnit.Pixel), 670, 480, Color.Black);
      if (this.game.Data.ResearchObj[index1].CostType == -1)
      {
        if (this.detailnr2 == -1 & this.detailnr3 == -1 & (double) Conversion.Int(this.game.Data.ResCostMod * (float) this.game.Data.ResearchObj[index1].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup]) <= (double) this.game.Data.RegimeObj[this.regnr].ResPts)
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Buy", 100, "Buy selected researchfield", ref this.OwnBitmap, 750, 635);
          this.B2Id = this.AddSubPart(ref tsubpart, 750, 635, 100, 35, 1);
        }
      }
      else if (this.detailnr2 == -1 & this.detailnr3 == -1 & (double) Conversion.Int(this.game.Data.ResCostMod * (float) this.game.Data.ResearchObj[index1].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup]) <= (double) this.game.Data.RegimeObj[this.regnr].RegimeSlot[this.game.Data.ResearchObj[index1].CostType])
      {
        SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Buy", 100, "Buy selected researchfield", ref this.OwnBitmap, 750, 635);
        this.B2Id = this.AddSubPart(ref tsubpart, 750, 635, 100, 35, 1);
      }
      int num9 = 0;
      if (this.game.HandyFunctionsObj.HasAllies(this.game.Data.Turn, true) & this.game.Data.RegimeObj[this.game.Data.Turn].ResField[index1] & (double) this.game.Data.RuleVar[530] == 1.0 && this.game.Data.ResearchObj[index1].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] > -1)
      {
        int regimeCounter = this.game.Data.RegimeCounter;
        for (int reg2 = 0; reg2 <= regimeCounter; ++reg2)
        {
          if (this.game.HandyFunctionsObj.IsAlliedOrSelf(this.game.Data.Turn, reg2) & this.game.Data.Turn != reg2 && !this.game.Data.RegimeObj[reg2].ResField[index1])
            ++num9;
        }
        int preReq = this.game.Data.ResearchObj[index1].PreReq;
        if (preReq > -1 && this.game.Data.ResearchObj[preReq].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] == -1)
          num9 = 0;
        int preReq2 = this.game.Data.ResearchObj[index1].PreReq2;
        if (preReq2 > -1 && this.game.Data.ResearchObj[preReq2].PointCost[this.game.Data.PeopleObj[this.pplnr].PeopleGroup] == -1)
          num9 = 0;
        if (num9 > 0)
        {
          SubPartClass tsubpart = (SubPartClass) new TextButtonPartClass("Give to Ally", 200, "Give selected researchfield", ref this.OwnBitmap, 700, 635);
          this.BAllyId = this.AddSubPart(ref tsubpart, 700, 635, 200, 35, 1);
        }
      }
      SubPartClass tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 280, 4, new Font(this.game.FontCol.Families[1], 13f, FontStyle.Regular, GraphicsUnit.Pixel), "", false, this.game.Data.ResearchObj[index1].Text, Color.Black, tbackbitmap: (ref this.OwnBitmap), bbx: 665, bby: 510, tHideShade: true, tBlockScroller: true);
      this.Text4id = this.AddSubPart(ref tsubpart1, 665, 510, 280, 80, 0);
    }

    public override WindowReturnClass HandleKeyPress(int nr, bool fromTimer = false)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      try
      {
        if ((nr == 27 | nr == 32) & this.game.Data.CampaignRoom == -1)
        {
          this.game.EditObj.TempCoordList = new CoordList();
          this.game.EditObj.OrderType = 0;
          windowReturnClass.AddCommand(3, 3);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    public WindowReturnClass HandleActionCard(int t2)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.game.Data.ActionCardObj[t2].AreaSlot > -1)
      {
        if (this.game.EditObj.AreaX == -1)
        {
          this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, this.detailnr);
          this.game.EditObj.DoCardSlot = this.detailnr;
          this.game.EditObj.HandCard = -1;
          this.clearsubstuff();
          this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[t2].AreaSlot;
          this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[t2].AreaValue;
          this.game.EditObj.PopupValue = 1;
          windowReturnClass.AddCommand(5, 10);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        int num = (int) Interaction.MsgBox((object) "Error. Cant have selected an Area X,Y already.");
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (this.game.Data.ActionCardObj[t2].UnitSelect)
      {
        this.game.ProcessingObj.PlayCardPreEvent(this.game.Data.Turn, this.detailnr);
        this.game.EditObj.DoCardSlot = this.detailnr;
        this.game.EditObj.HandCard = -1;
        this.clearsubstuff();
        this.game.EditObj.PopupValue = 3;
        windowReturnClass.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
      this.game.ProcessingObj.PlayCard(this.game.Data.Turn, this.detailnr);
      if (this.game.EditObj.DoQuit)
      {
        this.game.Data = new DataClass();
        this.game.EditObj.DoQuit = false;
        this.game.EditObj = new EditClass(this.game.AppPath + "editobj.txt");
        if (this.game.Data.UseAI == 1)
          this.game.NewAIObj.LastRegime = -1;
        this.game.EditObj.ShowInitialMenu = true;
        windowReturnClass.AddCommand(3, 1);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      if (Strings.Len(this.game.Data.LoadGame) > 0 & this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter <= messCounter)
      {
        this.game.FormRef.Cursor = Cursors.WaitCursor;
        Form formRef = (Form) this.game.FormRef;
        this.game.HandyFunctionsObj.LoadGameNow();
        this.game.FormRef = (Form1) formRef;
        this.game.FormRef.Cursor = Cursors.Default;
        windowReturnClass.AddCommand(3, 4);
        return windowReturnClass;
      }
      t2 = 0;
      int locCounter = this.game.Data.LocCounter;
      for (int locnr = 0; locnr <= locCounter; ++locnr)
      {
        if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
        {
          int index = 0;
          do
          {
            if (this.game.Data.LocObj[locnr].Production[index] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index]).result)
            {
              ++t2;
              this.game.Data.LocObj[locnr].Production[index] = -1;
              this.game.Data.LocObj[locnr].ProdPointRemainder[index] = 0;
              this.game.Data.LocObj[locnr].ProdPercent[index] = 0;
            }
            ++index;
          }
          while (index <= 3);
        }
      }
      if (t2 > 0)
      {
        int num1 = (int) Interaction.MsgBox((object) (Conversion.Str((object) t2) + " production lines have been cancelled due to this action card being played."), Title: ((object) "Shadow Empire : Planetary Conquest"));
      }
      if (this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter > messCounter)
      {
        this.clearsubstuff();
        this.game.EditObj.PopupValue = 0;
        this.game.EditObj.FromMessage = messCounter + 1;
        windowReturnClass.AddCommand(5, 10);
        this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
        windowReturnClass.SetFlag(true);
        return windowReturnClass;
      }
      this.detailnr = -1;
      this.domain();
      windowReturnClass.SetFlag(true);
      return windowReturnClass;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass1 = new WindowReturnClass();
      for (int mouseCounter = this.MouseCounter; mouseCounter >= 0; mouseCounter += -1)
      {
        if (this.MouseData[mouseCounter] > 0 && x > this.MouseRect[mouseCounter].X & x < this.MouseRect[mouseCounter].X + this.MouseRect[mouseCounter].Width && y > this.MouseRect[mouseCounter].Y & y < this.MouseRect[mouseCounter].Y + this.MouseRect[mouseCounter].Height && this.MouseData[mouseCounter] >= 100 & this.MouseData[mouseCounter] <= 100 + this.game.Data.RegimeObj[this.game.Data.Turn].ActionCardCounter + 100)
        {
          this.detailnr = this.MouseData[mouseCounter] - 100;
          this.detailnr2 = -1;
          this.detailnr3 = -1;
          this.domain();
          windowReturnClass1.SetFlag(true);
          return windowReturnClass1;
        }
      }
      if (this.SubPartCounter > -1)
      {
        if (this.dodetailnr > -1)
        {
          WindowReturnClass windowReturnClass2;
          return windowReturnClass2;
        }
        int subPartCounter = this.SubPartCounter;
label_71:
        for (int index1 = 0; index1 <= subPartCounter; ++index1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int num1 = this.SubPartID[index1];
            if (num1 == this.main2)
            {
              this.mainnr = 2;
              this.clearsubstuff();
              this.domain();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.main3)
            {
              this.mainnr = 3;
              this.clearsubstuff();
              this.domain();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.main4)
            {
              this.mainnr = 4;
              this.clearsubstuff();
              this.domain();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.main5)
            {
              this.mainnr = 5;
              this.clearsubstuff();
              this.domain();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.OptionsList4Id)
            {
              int num2 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.detailnr2 = -1;
                this.detailnr3 = -1;
                if (this.mainnr == 2)
                  this.docardshand();
                if (this.mainnr == 3)
                  this.docardsplayed();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.B3Id)
              return this.HandleActionCard(this.game.Data.RegimeObj[this.game.Data.Turn].ActionCard[this.detailnr]);
            if (num1 == this.Text2Id)
            {
              this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.OptionsList5Id)
            {
              int num3 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num3 > -1)
              {
                this.detailnr = num3;
                this.detailnr2 = -1;
                this.detailnr3 = -1;
                if (this.Text2Id > 0)
                {
                  this.RemoveSubPart(this.Text2Id);
                  this.Text2Id = 0;
                }
                this.domain();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.but1id)
            {
              this.game.EditObj.TempCoordList = new CoordList();
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.AreaX = -1;
              this.game.EditObj.AreaY = -1;
              this.game.EditObj.AreaSlot = -1;
              this.game.EditObj.AreaValue = -1;
              windowReturnClass1.AddCommand(3, 11);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.B2Id)
            {
              this.game.ProcessingObj.BuyResearch(this.pplnr, this.regnr, this.detailnr);
              SimpleList simpleList = new SimpleList();
              int itemTypeCounter = this.game.Data.ItemTypeCounter;
              int Number;
              for (int itemtypenr = 0; itemtypenr <= itemTypeCounter; ++itemtypenr)
              {
                if (this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[0] == this.detailnr | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[1] == this.detailnr | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[2] == this.detailnr | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[3] == this.detailnr | this.game.Data.ItemTypeObj[itemtypenr].ResFieldNeeded[4] == this.detailnr && this.game.Data.ItemTypeObj[itemtypenr].Blocks > -1)
                {
                  int blocks = this.game.Data.ItemTypeObj[itemtypenr].Blocks;
                  int locCounter = this.game.Data.LocCounter;
                  for (int locnr = 0; locnr <= locCounter; ++locnr)
                  {
                    if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
                    {
                      int index2 = 0;
                      do
                      {
                        if (this.game.Data.LocObj[locnr].Production[index2] == this.game.Data.ItemTypeObj[itemtypenr].Blocks && this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, itemtypenr).result)
                        {
                          this.game.Data.LocObj[locnr].Production[index2] = itemtypenr;
                          ++Number;
                        }
                        ++index2;
                      }
                      while (index2 <= 3);
                    }
                  }
                }
              }
              if (Number > 0)
              {
                int num4 = (int) Interaction.MsgBox((object) ("Automatically switched " + Conversion.Str((object) Number) + " production line(s)."), Title: ((object) "Shadow Empire : Planetary Conquest"));
              }
              this.detailnr = -1;
              this.detailnr2 = -1;
              this.detailnr3 = -1;
              this.domain();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.OptionsListId)
            {
              int num5 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num5 > -1)
              {
                this.detailnr = num5;
                this.detailnr2 = -1;
                this.detailnr3 = -1;
                this.domain();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.BAllyId)
            {
              new Form3((Form) this.formref).Initialize(this.game.Data, 54, this.detailnr2);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.OptionsList2Id)
            {
              int num6 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num6 > -1)
              {
                this.detailnr2 = num6;
                this.detailnr = -1;
                this.detailnr3 = -1;
                this.domain();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num1 == this.OptionsList3Id)
            {
              int num7 = this.SubPartList[index1].Click(x - this.SubPartX[index1], y - this.SubPartY[index1]);
              this.SubPartFlag[index1] = true;
              if (num7 > -1)
              {
                this.detailnr3 = num7;
                this.detailnr = -1;
                this.detailnr2 = -1;
                this.domain();
              }
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            int index3 = 0;
            while (this.SubPartID[index1] != this.minicard[index3])
            {
              ++index3;
              if (index3 > 64)
                goto label_71;
            }
            this.detailnr = index3;
            this.domain();
            windowReturnClass1.SetFlag(true);
            return windowReturnClass1;
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    public override void DoRefresh() => this.domain();

    public void PopUpRefresh()
    {
      this.game.EditObj.AreaSlot = -1;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.game.EditObj.AreaValue = -1;
      this.game.EditObj.DoCardSlot = -1;
      this.mainnr = 2;
      this.domain();
    }
  }
}
