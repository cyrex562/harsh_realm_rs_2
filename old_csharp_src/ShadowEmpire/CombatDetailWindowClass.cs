// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatDetailWindowClass
// Assembly: WindowsApplication1, Version=1.0.8020.28903, Culture=neutral, PublicKeyToken=null
// MVID: F52869E5-0850-48AD-BBBE-68E7A4900AFE
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Shadow Empire\ShadowEmpire.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace WindowsApplication1
{
  public class CombatDetailWindowClass : WindowClass
  {
    private int okid;
    private int tbacknr;
    private int oktextid;
    private int noteid;
    private int note2id;
    private int cloudid;
    private int Pic1Id;
    private int TAid;
    private int Ta2Id;
    private DateTime lasttime;
    private int FromMessage;
    private bool ForwardKey;
    private bool LastDrawAfterEnd;
    private int useWidth;
    private int useHeight;
    private int OptionsListId;
    private ListClass OptionsListObj;
    private int OptionsList1Id;
    private ListClass OptionsList1Obj;
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
    private int detailnr4;
    private int detailnr1;

    public CombatDetailWindowClass(ref GameClass tGame, int thn)
      : base(ref tGame, 1024, 768, 8)
    {
      this.FromMessage = tGame.EditObj.FromMessage;
      this.lasttime = DateAndTime.Now;
      this.dostuff();
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr1 = -1;
    }

    public CombatDetailWindowClass(ref GameClass tGame, int thn, bool OldGui)
      : base(ref tGame, 1024, 768, BackSprite: tGame.BACKGROUND3MARC)
    {
      this.FromMessage = tGame.EditObj.FromMessage;
      this.lasttime = DateAndTime.Now;
      this.dostuff();
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr1 = -1;
    }

    public CombatDetailWindowClass(ref GameClass tGame, int thn, int tWidth, int tHeight)
      : base(ref tGame, tWidth, tHeight, BackSprite: tGame.BACKGROUND3MARC)
    {
      this.FromMessage = tGame.EditObj.FromMessage;
      this.lasttime = DateAndTime.Now;
      this.useWidth = tWidth;
      this.useHeight = tHeight;
      this.dostuff();
      this.detailnr = -1;
      this.detailnr2 = -1;
      this.detailnr3 = -1;
      this.detailnr4 = -1;
      this.detailnr1 = -1;
    }

    public override void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            this.SubPartList[index].DescriptInfo(x - this.SubPartX[index], y - this.SubPartY[index]);
            if (Operators.CompareString(this.SubPartList[index].Descript, "", false) > 0)
            {
              this.game.EditObj.TipButton = true;
              this.game.EditObj.TipTitle = "";
              this.game.EditObj.TipText = this.SubPartList[index].Descript;
              return;
            }
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

    public void dostuff()
    {
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.TAid > 0)
      {
        this.RemoveSubPart(this.TAid);
        this.TAid = 0;
      }
      if (this.noteid > 0)
      {
        this.RemoveSubPart(this.noteid);
        this.noteid = 0;
      }
      SizeF sizeF = new SizeF();
      bool flag1;
      if ((double) this.game.Data.RuleVar[839] >= 1.0)
      {
        flag1 = true;
        this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      }
      else
      {
        flag1 = false;
        this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, this.game.BACKGROUND3MARC);
      }
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      if (flag1)
        DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 0, 0, this.useWidth, this.useHeight);
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      DrawMod.DrawTextColouredMarc(ref graphics, "COMBAT ROUNDS", this.game.MarcFont4, 10, 8, Color.White);
      this.OptionsListObj = new ListClass();
      if (this.detailnr > this.game.TempCombat.CombatRound)
        this.detailnr = -1;
      int tlistselect1 = -1;
      int num1 = -1;
      if (this.game.TempCombat.CombatRound > -1)
      {
        int combatRound = this.game.TempCombat.CombatRound;
        for (int index = 1; index <= combatRound; ++index)
        {
          ++num1;
          if (this.detailnr <= 0)
            this.detailnr = index;
          if (this.detailnr == index)
            tlistselect1 = num1;
          this.OptionsListObj.add("Round " + Strings.Trim(Conversion.Str((object) index)), index);
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
          ref Bitmap local1 = ref this.OwnBitmap;
          int num2 = flag1 ? 1 : 0;
          Font font = (Font) null;
          ref Font local2 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsListObj, 13, 280, tlistselect2, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local1), bbx: 10, bby: 25, tMarcStyle: (num2 != 0), overruleFont: (ref local2));
          this.OptionsListId = this.AddSubPart(ref tsubpart, 10, 25, 280, 224, 0);
        }
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "UNITS", this.game.MarcFont4, 10, 252, Color.White);
      this.OptionsList1Obj = new ListClass();
      if (this.detailnr1 > this.game.TempCombat.UCounter)
        this.detailnr1 = -1;
      int tlistselect3 = -1;
      int num3 = -1;
      if (this.game.TempCombat.UCounter > -1)
      {
        int ucounter = this.game.TempCombat.UCounter;
        for (int tdata = 0; tdata <= ucounter; ++tdata)
        {
          bool flag2 = true;
          bool flag3 = true;
          if ((double) this.game.Data.RuleVar[431] > 0.0)
          {
            flag2 = false;
            int icounter = this.game.TempCombat.ICounter;
            for (int index = 0; index <= icounter; ++index)
            {
              if (this.game.TempCombat.IList[index].IUlistNr == tdata)
              {
                if (this.game.TempCombat.IList[index].IvisibleFromRound < this.game.TempCombat.CombatRound | this.game.Data.UnitObj[this.game.TempCombat.IList[index].IUnr].Regime == this.game.Data.Turn)
                {
                  flag2 = true;
                  flag3 = false;
                }
                else if (!this.game.Data.FOWOn)
                  flag2 = true;
              }
            }
          }
          if (flag2)
          {
            ++num3;
            if (this.detailnr1 == -1)
              this.detailnr1 = tdata;
            if (this.detailnr1 == tdata)
              tlistselect3 = num3;
            string str = this.game.Data.UnitObj[this.game.TempCombat.UList[tdata].UNr].Name;
            if ((double) this.game.Data.RuleVar[431] > 0.0 & this.game.Data.FOWOn && (double) this.game.HandyFunctionsObj.CanWeSeeUnit(this.game.TempCombat.UList[tdata].UNr, this.game.Data.Turn) < (double) this.game.Data.RuleVar[55])
              str = "Unknown Unit";
            if (flag3)
              str += " [Hidden]";
            this.OptionsList1Obj.add(Strings.Left(str, 30), tdata, Strings.Left(this.game.Data.RegimeObj[this.game.Data.UnitObj[this.game.TempCombat.UList[tdata].UNr].Regime].Name, 20));
          }
        }
        if (this.OptionsList1Id > 0)
        {
          this.SubPartList[this.SubpartNr(this.OptionsList1Id)].Refresh(this.OptionsList1Obj, tlistselect3);
          this.SubPartFlag[this.SubpartNr(this.OptionsList1Id)] = true;
        }
        else
        {
          ListClass optionsList1Obj = this.OptionsList1Obj;
          int tlistselect4 = tlistselect3;
          GameClass game = this.game;
          ref Bitmap local3 = ref this.OwnBitmap;
          int num4 = flag1 ? 1 : 0;
          Font font = (Font) null;
          ref Font local4 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList1Obj, 14, 280, tlistselect4, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 120, tdotopandbottom: false, tbackbitmap: (ref local3), bbx: 10, bby: 270, tMarcStyle: (num4 != 0), overruleFont: (ref local4));
          this.OptionsList1Id = this.AddSubPart(ref tsubpart, 10, 270, 280, 240, 0);
        }
      }
      bool flag4 = true;
      if ((double) this.game.Data.RuleVar[431] > 0.0)
      {
        flag4 = false;
        int icounter = this.game.TempCombat.ICounter;
        for (int index = 0; index <= icounter; ++index)
        {
          if (this.game.TempCombat.IList[index].IUlistNr == this.detailnr1 && this.game.TempCombat.IList[index].IvisibleFromRound < this.detailnr | this.game.Data.UnitObj[this.game.TempCombat.IList[index].IUnr].Regime == this.game.Data.Turn)
            flag4 = true;
        }
      }
      if (flag4)
      {
        DrawMod.DrawTextColouredMarc(ref graphics, "UNIT REPORTS", this.game.MarcFont4, 10, 517, Color.White);
        this.OptionsList2Obj = new ListClass();
        int tlistselect5 = -1;
        if (this.detailnr1 > -1)
        {
          int num5 = -1;
          int repCounter = this.game.TempCombat.RepCounter;
          int num6;
          for (int tdata = 0; tdata <= repCounter; ++tdata)
          {
            if (this.game.TempCombat.RepFrom[tdata] == this.detailnr1 & this.game.TempCombat.RepRound[tdata] == this.detailnr)
            {
              ++num5;
              if (num5 == 0)
                num6 = tdata;
              if (this.detailnr2 == tdata)
                tlistselect5 = num5;
              this.OptionsList2Obj.add(Strings.Left(this.game.TempCombat.RepTitle[tdata], 55), tdata);
            }
          }
          if (tlistselect5 == -1)
            this.detailnr2 = -1;
          if (tlistselect5 == -1)
            this.detailnr2 = -1;
          if (num5 > -1 & this.detailnr4 == -1 & tlistselect5 == -1)
          {
            tlistselect5 = 0;
            this.detailnr2 = num6;
          }
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
          ref Bitmap local5 = ref this.OwnBitmap;
          int num7 = flag1 ? 1 : 0;
          Font font = (Font) null;
          ref Font local6 = ref font;
          SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList2Obj, 11, 280, tlistselect6, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local5), bbx: 10, bby: 535, tMarcStyle: (num7 != 0), overruleFont: (ref local6));
          this.OptionsList2Id = this.AddSubPart(ref tsubpart, 10, 535, 280, 192, 0);
        }
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "INDIVIDUAL LIST", this.game.MarcFont4, 310, 8, Color.White);
      this.OptionsList3Obj = new ListClass();
      int tlistselect7 = -1;
      if (this.detailnr1 > -1)
      {
        int num8 = -1;
        int icounter = this.game.TempCombat.ICounter;
        for (int tdata = 0; tdata <= icounter; ++tdata)
        {
          if (this.game.TempCombat.IList[tdata].IUnr == this.game.TempCombat.UList[this.detailnr1].UNr)
          {
            bool flag5 = true;
            bool flag6 = false;
            if ((double) this.game.Data.RuleVar[431] > 0.0)
            {
              flag5 = false;
              if (this.game.TempCombat.IList[tdata].IvisibleFromRound < this.detailnr | this.game.Data.UnitObj[this.game.TempCombat.IList[tdata].IUnr].Regime == this.game.Data.Turn)
                flag5 = true;
              else if (!this.game.Data.FOWOn)
              {
                flag5 = true;
                flag6 = true;
              }
            }
            if (flag5)
            {
              ++num8;
              if (this.detailnr3 == -1)
                this.detailnr3 = tdata;
              if (this.detailnr3 == tdata)
                tlistselect7 = num8;
              string tvalue;
              string tvalue2;
              if (!Information.IsNothing((object) this.game.TempCombat.IList[tdata].IHistoricState))
              {
                tvalue = this.game.TempCombat.IList[tdata].IHistoricState[this.detailnr];
                tvalue2 = this.game.TempCombat.IList[tdata].IHistoricState2[this.detailnr];
              }
              else
              {
                tvalue = "";
                tvalue2 = "";
              }
              string str1 = this.game.Data.SFTypeObj[this.game.TempCombat.IList[tdata].ISFType].Name;
              string Left = "";
              if (flag6)
                str1 += " [Hidden]";
              if (!Information.IsNothing((object) this.game.TempCombat.IList[tdata].IunitFeat) && this.game.TempCombat.IList[tdata].IunitFeat.Counter > -1)
              {
                if (this.game.TempCombat.IList[tdata].IunitFeatStart > 0 & !Information.IsNothing((object) this.game.TempCombat.customCombatObj) & this.game.TempCombat.IList[tdata].IunitFeat.Data1[0] == this.game.TempCombat.IList[tdata].IID && this.game.TempCombat.IList[tdata].IunitFeatDeadRound >= this.detailnr | this.game.TempCombat.IList[tdata].IunitFeatDeadRound < 1)
                  Left = " + " + this.game.TempCombat.customCombatObj.GetUnitFeatName(this.game, this.game.TempCombat.IList[tdata].IunitFeatStart) + "*";
                string str2 = "";
                if (!Information.IsNothing((object) this.game.TempCombat.customCombatObj))
                {
                  int num9 = 0;
                  int counter = this.game.TempCombat.IList[tdata].IunitFeat.Counter;
                  for (int index = 0; index <= counter; ++index)
                  {
                    if (this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IunitFeatDeadRound >= this.detailnr | this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IunitFeatDeadRound < 1 && this.game.TempCombat.IList[tdata].IunitFeat.Data1[index] != this.game.TempCombat.IList[tdata].IID && this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IKilled >= this.detailnr | this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IKilled < 1 && this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IRetreated >= this.detailnr | this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.game.TempCombat.IList[tdata].IunitFeat.Data1[index])].IRetreated < 1)
                    {
                      ++num9;
                      if (num9 == 1)
                        str2 = this.game.TempCombat.customCombatObj.GetUnitFeatName(this.game, this.game.TempCombat.IList[tdata].IunitFeat.Id[index]);
                    }
                  }
                  if (num9 > 1 & Operators.CompareString(Left, "", false) != 0)
                    str1 = str1 + Left + " + " + num9.ToString() + " others";
                  else if (num9 > 0 & Operators.CompareString(Left, "", false) == 0)
                  {
                    str1 = str1 + " + " + str2;
                    int num10 = num9 - 1;
                    if (num10 >= 1)
                      str1 = str1 + " + " + num10.ToString() + " others";
                  }
                  else
                    str1 += Left;
                }
              }
              this.OptionsList3Obj.add(Strings.Left(Strings.Trim(Conversion.Str((object) this.game.TempCombat.IList[tdata].IID)) + ") " + str1, 30), tdata, tvalue, tvalue2);
            }
          }
        }
        if (tlistselect7 == -1)
          this.detailnr3 = -1;
      }
      if (this.OptionsList3Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList3Id)].Refresh(this.OptionsList3Obj, tlistselect7);
        this.SubPartFlag[this.SubpartNr(this.OptionsList3Id)] = true;
      }
      else
      {
        int num11 = (int) Math.Round((double) (this.useHeight - 768) / 16.0);
        ListClass optionsList3Obj = this.OptionsList3Obj;
        int tlistsize = 36 + num11;
        int tlistselect8 = tlistselect7;
        GameClass game = this.game;
        ref Bitmap local7 = ref this.OwnBitmap;
        int num12 = flag1 ? 1 : 0;
        Font font = (Font) null;
        ref Font local8 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList3Obj, tlistsize, 280, tlistselect8, game, tHeaderCenter: false, tShowPair: true, tValueWidth: 140, tdotopandbottom: false, tbackbitmap: (ref local7), bbx: 310, bby: 25, tMarcStyle: (num12 != 0), overruleFont: (ref local8));
        this.OptionsList3Id = this.AddSubPart(ref tsubpart, 310, 25, 280, (37 + num11) * 16, 0);
      }
      DrawMod.DrawTextColouredMarc(ref graphics, "INDIVIDUAL REPORTS", this.game.MarcFont4, 610, 8, Color.White);
      this.OptionsList4Obj = new ListClass();
      int tlistselect9 = -1;
      if (this.detailnr3 > -1)
      {
        int num13 = -1;
        int repCounter = this.game.TempCombat.RepCounter;
        int num14;
        for (int tdata = 0; tdata <= repCounter; ++tdata)
        {
          if (this.game.TempCombat.RepFrom[tdata] == this.detailnr3 + 10000 & this.game.TempCombat.RepRound[tdata] == this.detailnr)
          {
            ++num13;
            if (num13 == 0)
              num14 = tdata;
            if (this.detailnr4 == tdata)
              tlistselect9 = num13;
            this.OptionsList4Obj.add(Strings.Left(this.game.TempCombat.RepTitle[tdata], 85), tdata);
          }
        }
        if (tlistselect9 == -1)
          this.detailnr4 = -1;
        if (this.detailnr2 == -1 & num13 > -1 & tlistselect9 == -1)
        {
          tlistselect9 = 0;
          this.detailnr4 = num14;
        }
      }
      int num15 = Math.Min(300, this.useWidth - 1024);
      int num16 = (int) Math.Round((double) num15 / 2.0);
      if (this.OptionsList4Id > 0)
      {
        this.SubPartList[this.SubpartNr(this.OptionsList4Id)].Refresh(this.OptionsList4Obj, tlistselect9);
        this.SubPartFlag[this.SubpartNr(this.OptionsList4Id)] = true;
      }
      else
      {
        ListClass optionsList4Obj = this.OptionsList4Obj;
        int twidth = 380 + num15;
        int tlistselect10 = tlistselect9;
        GameClass game = this.game;
        ref Bitmap local9 = ref this.OwnBitmap;
        int num17 = flag1 ? 1 : 0;
        Font font = (Font) null;
        ref Font local10 = ref font;
        SubPartClass tsubpart = (SubPartClass) new ListSubPartClass(optionsList4Obj, 15, twidth, tlistselect10, game, tHeaderCenter: false, tdotopandbottom: false, tbackbitmap: (ref local9), bbx: 610, bby: 25, tMarcStyle: (num17 != 0), overruleFont: (ref local10));
        this.OptionsList4Id = this.AddSubPart(ref tsubpart, 610, 25, 380 + num15, 256, 0);
      }
      this.RemoveSubPart(this.TAid);
      this.RemoveSubPart(this.OptionsList5Id);
      this.OptionsList5Id = 0;
      this.RemoveSubPart(this.OptionsList6Id);
      this.OptionsList6Id = 0;
      int index1;
      if (this.detailnr2 > -1)
        index1 = this.detailnr2;
      if (this.detailnr4 > -1)
        index1 = this.detailnr4;
      SubPartClass tsubpart1;
      if (index1 > -1)
      {
        string str = Strings.UCase(this.game.TempCombat.RepTitle[index1]) + "\r\n" + "\r\n" + this.game.TempCombat.RepText[index1];
        if (Strings.InStr(str, "[tab]") == 0 & this.detailnr2 == index1)
          str = "[tab]Unit Report," + str + "[/tab]";
        if (Strings.InStr(str, "[tab]") == 0 & this.detailnr4 == index1)
          str = "[tab]Individual Report," + str + "[/tab]";
        if (this.game.TempCombat.RepType[index1] == 1)
        {
          if (flag1)
          {
            tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 380 + num15, 6, this.game.MarcFont5, str, 15, ref this.OwnBitmap, 610, 300);
            this.TAid = this.AddSubPart(ref tsubpart1, 610, 300, 380 + num15, 105, 0);
          }
          else
          {
            SubPartClass tsubpart2 = (SubPartClass) new TextAreaClass(this.game, 380 + num15, 6, this.game.gamefont1b, "", false, str, Color.White, tItemSize: 15, tbackbitmap: (ref this.OwnBitmap), bbx: 610, bby: 300);
            this.TAid = this.AddSubPart(ref tsubpart2, 610, 300, 380 + num15, 105, 0);
          }
          DrawMod.DrawTextColouredMarc(ref graphics, "ATTACK SCORE MODS", this.game.MarcFont4, 610, 447, Color.White);
          this.OptionsList5Obj = new ListClass();
          int index2 = 1;
          do
          {
            if (!Information.IsNothing((object) this.game.TempCombat.RepCom[index2, 0, index1]) && this.game.TempCombat.RepCom[index2, 0, index1].Length > 0 & (index2 == 1 | Operators.CompareString(this.game.TempCombat.RepCom[index2 - 1, 2, index1], this.game.TempCombat.RepCom[index2, 2, index1], false) != 0 | Operators.CompareString(this.game.TempCombat.RepCom[index2, 0, index1], "After mods", false) == 0) && Operators.CompareString(this.game.TempCombat.RepCom[index2, 2, index1], "?", false) != 0)
              this.OptionsList5Obj.add(this.game.TempCombat.RepCom[index2, 0, index1], -1, this.game.TempCombat.RepCom[index2, 1, index1], Conversions.ToString(Math.Round((double) Conversions.ToSingle(this.game.TempCombat.RepCom[index2, 2, index1]), 1)));
            ++index2;
          }
          while (index2 <= 60);
          int num18 = (int) Math.Round((double) (this.useWidth - 1024) / 5.0);
          ListClass optionsList5Obj = this.OptionsList5Obj;
          int twidth1 = 170 + num16;
          int tlistselect11 = tlistselect9;
          GameClass game1 = this.game;
          int tValueWidth1 = 80 + num18;
          ref Bitmap local11 = ref this.OwnBitmap;
          int num19 = flag1 ? 1 : 0;
          Font font1 = (Font) null;
          ref Font local12 = ref font1;
          tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList5Obj, 15, twidth1, tlistselect11, game1, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: tValueWidth1, tdotopandbottom: false, tbackbitmap: (ref local11), bbx: 610, bby: 465, tMarcStyle: (num19 != 0), overruleFont: (ref local12));
          this.OptionsList5Id = this.AddSubPart(ref tsubpart1, 610, 465, 170 + num16, 256, 0);
          DrawMod.DrawTextColouredMarc(ref graphics, "DEFENDER SCORE MODS", this.game.MarcFont4, 810 + num16, 447, Color.White);
          this.OptionsList6Obj = new ListClass();
          int index3 = 1;
          do
          {
            if (!Information.IsNothing((object) this.game.TempCombat.RepCom[index3, 3, index1]) & !Information.IsNothing((object) this.game.TempCombat.RepCom[index3, 5, index1]) && Operators.CompareString(this.game.TempCombat.RepCom[index3, 5, index1], "?", false) != 0 & this.game.TempCombat.RepCom[index3, 3, index1].Length > 0 & (index3 == 1 | Operators.CompareString(this.game.TempCombat.RepCom[index3 - 1, 5, index1], this.game.TempCombat.RepCom[index3, 5, index1], false) != 0 | Operators.CompareString(this.game.TempCombat.RepCom[index3, 3, index1], "After mods", false) == 0) && Operators.CompareString(this.game.TempCombat.RepCom[index3, 5, index1], "?", false) != 0)
              this.OptionsList6Obj.add(this.game.TempCombat.RepCom[index3, 3, index1], -1, this.game.TempCombat.RepCom[index3, 4, index1], Conversions.ToString(Math.Round((double) Conversions.ToSingle(this.game.TempCombat.RepCom[index3, 5, index1]), 1)));
            ++index3;
          }
          while (index3 <= 60);
          int num20 = (int) Math.Round((double) (this.useWidth - 1024) / 5.0);
          ListClass optionsList6Obj = this.OptionsList6Obj;
          int twidth2 = 170 + num16;
          int tlistselect12 = tlistselect9;
          GameClass game2 = this.game;
          int tValueWidth2 = 80 + num20;
          ref Bitmap local13 = ref this.OwnBitmap;
          int bbx = 810 + num16;
          int num21 = flag1 ? 1 : 0;
          Font font2 = (Font) null;
          ref Font local14 = ref font2;
          tsubpart1 = (SubPartClass) new ListSubPartClass(optionsList6Obj, 15, twidth2, tlistselect12, game2, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: tValueWidth2, tdotopandbottom: false, tbackbitmap: (ref local13), bbx: bbx, bby: 465, tMarcStyle: (num21 != 0), overruleFont: (ref local14));
          this.OptionsList6Id = this.AddSubPart(ref tsubpart1, 810 + num16, 465, 170 + num16, 256, 0);
        }
        else if (this.game.TempCombat.RepType[index1] == 2)
        {
          int num22 = Math.Min(300, this.useHeight - 768);
          DrawMod.DrawTextColouredMarc(ref graphics, "STATUS", this.game.MarcFont4, 610, 300, Color.White);
          this.OptionsList5Obj = new ListClass();
          int index4 = 1;
          do
          {
            if (!Information.IsNothing((object) this.game.TempCombat.RepCom[index4, 0, index1]) && this.game.TempCombat.RepCom[index4, 0, index1].Length > 0)
              this.OptionsList5Obj.add(this.game.TempCombat.RepCom[index4, 0, index1], -1, this.game.TempCombat.RepCom[index4, 1, index1]);
            ++index4;
          }
          while (index4 <= 60);
          int num23 = (int) Math.Round((double) num22 / 16.0);
          ListClass optionsList5Obj = this.OptionsList5Obj;
          int tlistsize = 19 + num23;
          int tlistselect13 = tlistselect9;
          GameClass game = this.game;
          ref Bitmap local15 = ref this.OwnBitmap;
          int num24 = flag1 ? 1 : 0;
          Font font = (Font) null;
          ref Font local16 = ref font;
          SubPartClass tsubpart3 = (SubPartClass) new ListSubPartClass(optionsList5Obj, tlistsize, 380, tlistselect13, game, tHeaderCenter: false, tHighlight: false, tShowPair: true, tValueWidth: 200, tdotopandbottom: false, tbackbitmap: (ref local15), bbx: 610, bby: 317, tMarcStyle: (num24 != 0), overruleFont: (ref local16));
          this.OptionsList5Id = this.AddSubPart(ref tsubpart3, 610, 317, 380, (20 + num23) * 16, 0);
        }
        else if (flag1)
        {
          SubPartClass tsubpart4 = (SubPartClass) new TextAreaClass2(this.game, 380, 26, this.game.MarcFont5, str, 15, ref this.OwnBitmap, 610, 300);
          this.TAid = this.AddSubPart(ref tsubpart4, 610, 300, 380, 405, 0);
        }
        else
        {
          tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 380, 26, this.game.gamefont1b, "", false, str, Color.White, tItemSize: 15, tbackbitmap: (ref this.OwnBitmap), bbx: 610, bby: 300);
          this.TAid = this.AddSubPart(ref tsubpart1, 610, 300, 380, 405, 0);
        }
      }
      string combatOneSentence = this.game.EditObj.CombatOneSentence;
      string tText = this.game.EditObj.CombatOneSentenceCustom.Length <= 0 ? this.game.EditObj.CombatOneSentenceCustom : combatOneSentence + " " + this.game.EditObj.CombatOneSentenceCustom;
      if (tText.Length > 1)
      {
        if (flag1)
        {
          tsubpart1 = (SubPartClass) new TextAreaClass2(this.game, 290, 3, this.game.MarcFont5, tText, 15, ref this.OwnBitmap, 310, 620);
          this.Ta2Id = this.AddSubPart(ref tsubpart1, 310, 620, 290, 60, 0);
        }
        else
        {
          tsubpart1 = (SubPartClass) new TextAreaClass(this.game, 290, 3, this.game.gamefont1b, "", false, tText, Color.White, tItemSize: 15, tbackbitmap: (ref this.OwnBitmap), bbx: 310, bby: 620);
          this.Ta2Id = this.AddSubPart(ref tsubpart1, 310, 620, 290, 60, 0);
        }
      }
      int num25 = (int) Math.Round((double) this.useWidth / 2.0 - 50.0);
      if (flag1)
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("BACK", 100, "Click to return to regular combat screen\r\nOr press any key instead.", ref this.OwnBitmap, num25, this.useHeight - 40, theight: 20, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.okid = this.AddSubPart(ref tsubpart1, num25, this.useHeight - 40, 100, 20, 1);
      }
      else
      {
        tsubpart1 = (SubPartClass) new TextButtonPartClass("Back", 100, tBackbitmap: (ref this.OwnBitmap), bbx: 460, bby: (this.useHeight - 70));
        this.okid = this.AddSubPart(ref tsubpart1, 460, this.useHeight - 70, 100, 35, 1);
      }
    }

    public int GetSfNrBitmap(int sfnr, int att)
    {
      int type = this.game.Data.SFObj[sfnr].Type;
      int symbolSpriteId = this.game.Data.SFTypeObj[type].SymbolSpriteID;
      int index1 = -1;
      if (att == 0)
        index1 = this.game.TempCombat.DefenderRegime;
      if (att == 1)
        index1 = this.game.TempCombat.AttackerRegime;
      if (index1 > -1)
      {
        if (this.game.Data.RegimeObj[index1].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (int index2 = 0; index2 <= extraCounter; ++index2)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index2] == this.game.Data.RegimeObj[index1].ExtraGraphicUse)
              symbolSpriteId = this.game.Data.SFTypeObj[type].ExtraSymbolSpriteID[index2];
          }
        }
        else
        {
          int index3;
          if (this.game.Data.PeopleObj[this.game.Data.SFObj[this.game.TempCombat.IList[index3].ISFNr].People].ExtraGraphicUse > -1)
          {
            int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
            for (int index4 = 0; index4 <= extraCounter; ++index4)
            {
              if (this.game.Data.SFTypeObj[type].ExtraCode[index4] == this.game.Data.PeopleObj[this.game.Data.SFObj[this.game.TempCombat.IList[index3].ISFNr].People].ExtraGraphicUse)
                symbolSpriteId = this.game.Data.SFTypeObj[type].ExtraSymbolSpriteID[index4];
            }
          }
        }
      }
      return symbolSpriteId;
    }

    public override WindowReturnClass HandleMouseClick(int x, int y, int b)
    {
      WindowReturnClass windowReturnClass = new WindowReturnClass();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; ++index)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num1 = this.SubPartID[index];
            if (num1 == this.TAid)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsListId)
            {
              int num2 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num2 > -1)
              {
                this.detailnr = num2;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList1Id)
            {
              int num3 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num3 > -1)
              {
                this.detailnr1 = num3;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList2Id)
            {
              int num4 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num4 > -1)
              {
                this.detailnr2 = num4;
                this.detailnr4 = -1;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList3Id)
            {
              int num5 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num5 > -1)
              {
                this.detailnr3 = num5;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.OptionsList4Id)
            {
              int num6 = this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              if (num6 > -1)
              {
                this.detailnr4 = num6;
                this.detailnr2 = -1;
                this.dostuff();
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (num1 == this.okid)
            {
              if ((double) this.game.Data.RuleVar[839] == 1.0)
              {
                this.game.EditObj.PopupValue = 7;
                windowReturnClass.AddCommand(5, 14);
              }
              else
              {
                windowReturnClass.AddCommand(1, 84);
                windowReturnClass.AddCommand(2, 84);
              }
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
        windowReturnClass.SetFlag(false);
        return windowReturnClass;
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }
  }
}
