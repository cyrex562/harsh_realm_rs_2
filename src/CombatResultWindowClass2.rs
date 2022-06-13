// Decompiled with JetBrains decompiler
// Type: WindowsApplication1.CombatResultWindowClass2
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
  pub class CombatResultWindowClass2 : WindowClass
  {
     int okid;
     int tbacknr;
     int typeid;
     int oktextid;
     int detailid;
     int noteid;
     int note2id;
     int cloudid;
     int Pic1Id;
     int TAid;
     int showdetail;
     DateTime lasttime;
     DateTime lastAnimTime;
     int FromMessage;
     bool ForwardKey;
     bool LastDrawAfterEnd;
     int Hn;
     int resolveId;
     int[] StartRdn;
     int[] StartEntr;
     int[] StartMor;
     int[] StartXp;
     int useWidth;
     int useHeight;
     int useZoom;
     int[,,,] crm;
     bool crmSet;
     int attPage;
     int maxAttPage;
     int defPage;
     int maxDefPage;
     int slotCulture;
     int slotChar;
     int slotCharSkill;
     int slotSkillType;
     int slotUnitFeats;
     int[,] tabid;
     int[] tabup;
     int[] tabdown;
     int zoom1id;
     int zoom0id;
     bool playBattle;
     int mesId;
     int roundId;
     int playId;
     int crmSetOnRound;
     SimpleList animList;
     Bitmap bufferBitmap;

    pub CombatResultWindowClass2(ref GameClass tGame, int thn)
      : base(ref tGame, 1, 1, 8)
    {
      this.StartRdn = new int[2];
      this.StartEntr = new int[2];
      this.StartMor = new int[2];
      this.StartXp = new int[2];
      this.crm = new int[2, 2, 2, 2];
      this.tabid = new int[2, 1000];
      this.tabup = new int[2];
      this.tabdown = new int[2];
    }

    pub CombatResultWindowClass2(ref GameClass tGame, int tUseWidth, int tUseHeight)
      : base(ref tGame, tUseWidth, tUseHeight, 8)
    {
      this.StartRdn = new int[2];
      this.StartEntr = new int[2];
      this.StartMor = new int[2];
      this.StartXp = new int[2];
      this.crm = new int[2, 2, 2, 2];
      this.tabid = new int[2, 1000];
      this.tabup = new int[2];
      this.tabdown = new int[2];
      this.slotCulture = tGame.HandyFunctionsObj.GetStringListByID(tGame.EventRelatedObj.CheckStringlistID("SE_Data", 306, 0, 0));
      this.slotUnitFeats = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 402, 0, 0));
      this.slotChar = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 196, 0, 0));
      this.slotCharSkill = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 199, 0, 0));
      this.slotSkillType = this.game.HandyFunctionsObj.GetStringListByID(this.game.EventRelatedObj.CheckStringlistID("SE_Data", 203, 0, 0));
      this.FromMessage = tGame.EditObj.FromMessage;
      this.lasttime = DateAndTime.Now;
      this.lastAnimTime = DateAndTime.Now;
      this.useWidth = tUseWidth;
      this.useHeight = tUseHeight;
      this.game.EditObj.DoCardSlot = -1;
      this.showdetail = !this.game.EditObj.CombatTextual ? 0 : 1;
      this.animList = SimpleList::new();
      this.attPage = 0;
      this.maxAttPage = 0;
      this.defPage = 0;
      this.maxDefPage = 0;
      this.crmSet = false;
      this.useZoom = 1;
      this.dostuff();
    }

    pub void HandleToolTip(int x, int y)
    {
      base.HandleToolTip(x, y);
      if (this.SubPartCounter > -1)
      {
        int subPartCounter = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter; index += 1)
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
      for (int index = 0; index <= mouseCounter; index += 1)
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

    pub string GetUnitDescription(int unr)
    {
      int uslot = this.game.TempCombat.FindUSlot(unr);
      string unitDescription;
      if (this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode == 1 & this.game.TempCombat.UList[uslot].URetreated < 1)
        unitDescription = !(this.game.TempCombat.BattleEnded > 0 & this.game.HandyFunctionsObj.GetPowerPtsAbsolute(unr) < 1) ? "RETREATING" : "OVERRUN";
      else if (this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode == 1)
        unitDescription = "RETREATED";
      else if (this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode >= 2 & this.game.TempCombat.UList[uslot].URetreatMode < 5)
        unitDescription = "OUT OF AP";
      else if (!this.game.TempCombat.UList[uslot].UBreaks & this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode == 5)
        unitDescription = "PANICKED";
      else if (this.game.TempCombat.UList[uslot].UBreaks)
        unitDescription = "BROKEN";
      else if (this.game.TempCombat.UList[uslot].UBreaks & this.game.TempCombat.UList[uslot].URetreatMode == 5)
        unitDescription = "BROKEN";
      else if (this.game.TempCombat.UList[uslot].URetreatMode == 0 & this.game.TempCombat.BattleEnded > 0 & this.game.TempCombat.UList[uslot].URetreated > 0 & this.game.TempCombat.CombatType == 3 & this.game.TempCombat.UList[uslot].Uattacker == 1)
        unitDescription = "OUT OF AP";
      else if (this.game.TempCombat.UList[uslot].URetreatMode == 0 & this.game.TempCombat.BattleEnded > 0 & this.game.TempCombat.UList[uslot].URetreated > 0)
        unitDescription = !(this.game.TempCombat.CombatType == 5 | this.game.TempCombat.CombatType == 13) ? "SURRENDERED" : "HOLDING";
      else if (this.game.TempCombat.BattleEnded > 0)
      {
        unitDescription = this.game.TempCombat.BattleEnded <= 0 ? Strings.Trim(Conversion.Str((object) (this.game.HandyFunctionsObj.GetLowestAp(this.game.TempCombat.UList[uslot].UNr) - this.game.TempCombat.UList[uslot].UApSpend))) + "AP" : Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(this.game.TempCombat.UList[uslot].UNr))) + "AP";
        if (this.game.TempCombat.UList[uslot].Uattacker < 1)
          unitDescription = "HOLDING";
      }
      else
      {
        unitDescription = this.game.TempCombat.BattleEnded <= 0 ? Strings.Trim(Conversion.Str((object) (this.game.HandyFunctionsObj.GetLowestAp(this.game.TempCombat.UList[uslot].UNr) - this.game.TempCombat.UList[uslot].UApSpend))) + "AP" : Strings.Trim(Conversion.Str((object) this.game.HandyFunctionsObj.GetLowestAp(this.game.TempCombat.UList[uslot].UNr))) + "AP";
        if (this.game.TempCombat.UList[uslot].Uattacker < 1)
          unitDescription = "HOLDING";
      }
      return unitDescription;
    }

    pub Color GetUnitColor(int unr)
    {
      int uslot = this.game.TempCombat.FindUSlot(unr);
      Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      return !this.game.TempCombat.UList[uslot].UBreaks ? (!(this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode == 1) ? (!(this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode <= 2) ? (!(this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode > 2 & this.game.TempCombat.UList[uslot].URetreatMode < 5) ? (!(!this.game.TempCombat.UList[uslot].UBreaks & this.game.TempCombat.UList[uslot].URetreat > 0 & this.game.TempCombat.UList[uslot].URetreatMode == 5) ? (this.game.TempCombat.BattleEnded <= 0 ? Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue) : (this.game.TempCombat.UList[uslot].Uattacker >= 1 ? Color.FromArgb((int) byte.MaxValue, 100, 100, 100) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue))) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 215, 215)) : Color.FromArgb((int) byte.MaxValue, 215, 215, 215)) : Color.FromArgb((int) byte.MaxValue, 215, 215, 215)) : Color.FromArgb((int) byte.MaxValue, 215, 215, 215)) : Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 215, 215);
    }

    pub string GetCombatDescription()
    {
      int num = 0;
      int ucounter = this.game.TempCombat.UCounter;
      for (int index = 0; index <= ucounter; index += 1)
      {
        if (this.game.TempCombat.UList[index].Uattacker == 1)
        {
          if (num == 0)
            num = 1;
          if (this.game.TempCombat.UList[index].URetreat == 0 & this.game.TempCombat.UList[index].UDead == 0)
            num = 2;
        }
      }
      string combatDescription;
      if (this.game.TempCombat.CombatType == 11)
      {
        if (this.game.TempCombat.BattleEnded == 0)
          combatDescription = "AMBUSH ONGOING\r\nROUND " + this.game.TempCombat.CombatRound.ToString();
        else if (this.game.TempCombat.BattleEnded == 1)
          combatDescription = "AMBUSH ENDED";
        else if (this.game.TempCombat.BattleEnded == 2)
          combatDescription = "AMBUSH ENDED";
        else if (this.game.TempCombat.BattleEnded == 3)
          combatDescription = "AMBUSH ENDED";
      }
      else if (this.game.TempCombat.CombatType == 1 | this.game.TempCombat.CombatType == 2 | this.game.TempCombat.CombatType == 10 | this.game.TempCombat.CombatType == 9)
      {
        if (this.game.TempCombat.BattleEnded == 0)
          combatDescription = "BATTLE ONGOING\r\nROUND " + this.game.TempCombat.CombatRound.ToString();
        else if (this.game.TempCombat.BattleEnded == 1)
          combatDescription = "ATTACKER WON";
        else if (this.game.TempCombat.BattleEnded == 2)
          combatDescription = "DEFENDER HELD";
        else if (this.game.TempCombat.BattleEnded == 3)
          combatDescription = "STANDOFF";
      }
      else if (this.game.TempCombat.CombatType == 3 | this.game.TempCombat.CombatType == 4)
      {
        if (this.game.TempCombat.BattleEnded == 0)
          combatDescription = "ARTILLERY BOMBARDMENT\r\nROUND " + this.game.TempCombat.CombatRound.ToString();
        else if (this.game.TempCombat.BattleEnded == 1)
          combatDescription = "END OF BOMBARDMENT";
        else if (this.game.TempCombat.BattleEnded == 2)
          combatDescription = "END OF BOMBARDMENT";
        else if (this.game.TempCombat.BattleEnded == 3)
          combatDescription = "END OF BOMBARDMENT";
      }
      else if (this.game.TempCombat.CombatType == 5 | this.game.TempCombat.CombatType == 6)
      {
        if (this.game.TempCombat.BattleEnded == 0)
          combatDescription = "AIRSTRIKE\r\nROUND " + this.game.TempCombat.CombatRound.ToString();
        else if (this.game.TempCombat.BattleEnded == 1)
          combatDescription = "END OF AIRSTRIKE";
        else if (this.game.TempCombat.BattleEnded == 2)
          combatDescription = "END OF AIRSTRIKE";
        else if (this.game.TempCombat.BattleEnded == 3)
          combatDescription = "END OF AIRSTRIKE";
      }
      else if (this.game.TempCombat.CombatType == 13)
      {
        if (this.game.TempCombat.BattleEnded == 0)
          combatDescription = "AIRRECON\r\nROUND " + this.game.TempCombat.CombatRound.ToString();
        else if (this.game.TempCombat.BattleEnded == 1)
          combatDescription = "END OF AIRRECON";
        else if (this.game.TempCombat.BattleEnded == 2)
          combatDescription = "END OF AIRRECON";
        else if (this.game.TempCombat.BattleEnded == 3)
          combatDescription = "END OF AIRRECON";
      }
      return combatDescription;
    }

    pub void DrawIndividual(
      Graphics g,
      int tx,
      int ty,
      int iid,
      int tw,
      int th,
      bool useColMod,
      Color colMod,
      bool mirror)
    {
      int regimeNr = -1;
      int islot = this.game.TempCombat.FindISlot(iid);
      if (islot < 0)
        return;
      int isfNr = this.game.TempCombat.IList[islot].ISFNr;
      int tv0 = this.game.Data.PeopleObj[this.game.Data.SFObj[isfNr].People].tv0;
      int type = this.game.Data.SFObj[isfNr].Type;
      int iunr = this.game.TempCombat.IList[islot].IUnr;
      if (this.game.TempCombat.IList[islot].IAttacker == 1)
        regimeNr = this.game.TempCombat.AttackerRegime;
      if (this.game.TempCombat.IList[islot].IAttacker < 1)
        regimeNr = this.game.TempCombat.DefenderRegime;
      Bitmap objBitmap;
      if (this.game.Data.SFTypeObj[type].SFTypeVar[89] < 1)
      {
        if (this.game.Data.SFTypeObj[type].SFTypeVar[82] > 0)
        {
          int y1 = -4;
          objBitmap = new Bitmap(76, 76, PixelFormat.Format32bppPArgb);
          Graphics graphics = Graphics.FromImage((Image) objBitmap);
          graphics.Clear(Color.Transparent);
          Bitmap bitmap;
          Rectangle rectangle1;
          Rectangle rectangle2;
          if (this.game.Data.SFTypeObj[type].artCode[0] == 1)
          {
            ref Graphics local1 = ref graphics;
            bitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[type].SidewaysSpriteID);
            ref Bitmap local2 = ref bitmap;
            rectangle1 = new Rectangle(0, 0, 76, 76);
            Rectangle srcrect = rectangle1;
            rectangle2 = new Rectangle(0, y1, 76, 76);
            Rectangle destrect = rectangle2;
            double r = (double) ((float) this.game.Data.SFTypeObj[type].artCode[1] / (float) byte.MaxValue);
            double g1 = (double) ((float) this.game.Data.SFTypeObj[type].artCode[2] / (float) byte.MaxValue);
            double b = (double) ((float) this.game.Data.SFTypeObj[type].artCode[3] / (float) byte.MaxValue);
            DrawMod.DrawSimplePart2ColouredNew(ref local1, ref local2, srcrect, destrect, (float) r, (float) g1, (float) b, 1f);
          }
          else
          {
            ref Graphics local3 = ref graphics;
            bitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[type].SidewaysSpriteID);
            ref Bitmap local4 = ref bitmap;
            int y2 = y1;
            DrawMod.DrawSimple(ref local3, ref local4, 0, y2);
          }
          if (this.game.Data.SFTypeObj[type].artCode[5] == 1)
          {
            ref Graphics local5 = ref graphics;
            bitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[type].SymbolColBigSprite2ID);
            ref Bitmap local6 = ref bitmap;
            rectangle2 = new Rectangle(0, 0, 76, 76);
            Rectangle srcrect = rectangle2;
            rectangle1 = new Rectangle(0, y1, 76, 76);
            Rectangle destrect = rectangle1;
            double r = (double) ((float) this.game.Data.SFTypeObj[type].artCode[6] / (float) byte.MaxValue);
            double g2 = (double) ((float) this.game.Data.SFTypeObj[type].artCode[7] / (float) byte.MaxValue);
            double b = (double) ((float) this.game.Data.SFTypeObj[type].artCode[8] / (float) byte.MaxValue);
            double a = (double) ((float) this.game.Data.SFTypeObj[type].artCode[9] / (float) byte.MaxValue);
            DrawMod.DrawSimplePart2ColouredNew(ref local5, ref local6, srcrect, destrect, (float) r, (float) g2, (float) b, (float) a);
          }
          graphics.Dispose();
        }
        else
          objBitmap = BitmapStore.GetBitmap(this.game.Data.SFTypeObj[type].SymbolSpriteID, this.useZoom);
      }
      else
      {
        bool isMilitia = this.game.Data.HistoricalUnitObj[this.game.Data.UnitObj[iunr].Historical].GiveHisVarValue(11) > 0;
        int integer = Conversions.ToInteger(this.game.Data.StringListObj[this.slotCulture].GetData(0, tv0, 1));
        objBitmap = this.game.CustomBitmapObj.DrawSFTypeGraphic(type, isMilitia, integer, regimeNr, this.game.TempCombat.IList[islot].IUnr);
      }
      if (Information.IsNothing((object) objBitmap))
        return;
      int num1 = 0;
      int num2 = 0;
      int w = tw;
      int h = th;
      int width = objBitmap.Width;
      int height = objBitmap.Height;
      if (width > w | height > h)
      {
        if ((double) width / (double) w > (double) height / (double) h)
        {
          float num3 = (float) w / (float) width;
          int num4 = (int) Math.Round((double) ((float) h - (float) height * num3));
          num2 += (int) Math.Round((double) num4 / 2.0);
          h -= num4;
        }
        else
        {
          float num5 = (float) h / (float) height;
          int num6 = (int) Math.Round((double) ((float) w - (float) width * num5));
          num1 += (int) Math.Round((double) num6 / 2.0);
          w -= num6;
        }
        if (mirror)
        {
          Matrix matrix = Matrix::new();
          matrix.Scale(-1f, 1f);
          matrix.Translate((float) -(2 * (tx + num1) + w), 0.0f);
          g.Transform = matrix;
        }
        if (useColMod)
          DrawMod.DrawScaledColorized2(ref g, ref objBitmap, tx + num1, ty + num2, w, h, objBitmap.Width, objBitmap.Height, (float) colMod.R / (float) byte.MaxValue, (float) colMod.G / (float) byte.MaxValue, (float) colMod.B / (float) byte.MaxValue, (float) colMod.A / (float) byte.MaxValue);
        else
          DrawMod.DrawScaled(ref g, ref objBitmap, tx + num1, ty + num2, w, h, true);
        if (!mirror)
          return;
        g.ResetTransform();
      }
      else
      {
        if (this.game.Data.SFTypeObj[type].SFTypeVar[89] < 1)
        {
          if (this.useZoom == 1)
          {
            tx += 4;
            ty += 4;
          }
          else
          {
            tx += 2;
            ty += 2;
          }
        }
        if (mirror)
        {
          Matrix matrix = Matrix::new();
          matrix.Scale(-1f, 1f);
          matrix.Translate((float) -(2 * tx + objBitmap.Width + (w - width)), 0.0f);
          g.Transform = matrix;
        }
        if (useColMod)
          DrawMod.Draw(ref g, ref objBitmap, tx + num1 + (int) Math.Round((double) (w - width) / 2.0), ty + num2 + (int) Math.Round((double) (h - height) / 2.0), (float) colMod.R / (float) byte.MaxValue - 1f, (float) colMod.G / (float) byte.MaxValue - 1f, (float) colMod.B / (float) byte.MaxValue - 1f, (float) colMod.A / (float) byte.MaxValue);
        else
          DrawMod.DrawSimple(ref g, ref objBitmap, tx + num1 + (int) Math.Round((double) (w - width) / 2.0), ty + num2 + (int) Math.Round((double) (h - height) / 2.0));
        if (!mirror)
          return;
        g.ResetTransform();
      }
    }

    pub void dostuff(bool crmAlreadySet = false)
    {
      if (this.okid > 0)
      {
        this.RemoveSubPart(this.okid);
        this.okid = 0;
      }
      if (this.playId > 0)
      {
        this.RemoveSubPart(this.playId);
        this.playId = 0;
      }
      if (this.roundId > 0)
      {
        this.RemoveSubPart(this.roundId);
        this.roundId = 0;
      }
      if (this.zoom1id > 0)
      {
        this.RemoveSubPart(this.zoom1id);
        this.zoom1id = 0;
      }
      if (this.zoom0id > 0)
      {
        this.RemoveSubPart(this.zoom0id);
        this.zoom0id = 0;
      }
      if (this.mesId > 0)
      {
        this.RemoveSubPart(this.mesId);
        this.mesId = 0;
      }
      if (this.typeid > 0)
      {
        this.RemoveSubPart(this.typeid);
        this.typeid = 0;
      }
      if (this.TAid > 0)
      {
        this.RemoveSubPart(this.TAid);
        this.TAid = 0;
      }
      if (this.detailid > 0)
      {
        this.RemoveSubPart(this.detailid);
        this.detailid = 0;
      }
      if (this.resolveId > 0)
      {
        this.RemoveSubPart(this.resolveId);
        this.resolveId = 0;
      }
      int index1 = 0;
      do
      {
        if (this.tabid[0, index1] > 0)
        {
          this.RemoveSubPart(this.tabid[0, index1]);
          this.tabid[0, index1] = 0;
        }
        if (this.tabid[1, index1] > 0)
        {
          this.RemoveSubPart(this.tabid[1, index1]);
          this.tabid[1, index1] = 0;
        }
        index1 += 1;
      }
      while (index1 <= 999);
      if (this.tabup[0] > 0)
      {
        this.RemoveSubPart(this.tabup[0]);
        this.tabup[0] = 0;
      }
      if (this.tabdown[0] > 0)
      {
        this.RemoveSubPart(this.tabdown[0]);
        this.tabdown[0] = 0;
      }
      if (this.tabup[1] > 0)
      {
        this.RemoveSubPart(this.tabup[1]);
        this.tabup[1] = 0;
      }
      if (this.tabdown[1] > 0)
      {
        this.RemoveSubPart(this.tabdown[1]);
        this.tabdown[1] = 0;
      }
      SizeF sizeF1 = SizeF::new();
      Color.FromArgb(160, 230, 210, 190);
      this.ClearMouse();
      this.NewBackGroundAndClearAll(this.useWidth, this.useHeight, -1);
      Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
      DrawMod.DrawMessFrame(ref this.OwnBitmap, ref graphics, 25, 40, this.useWidth - 50, this.useHeight - 40);
      if (!Information.IsNothing((object) this.BackBitmap))
      {
        this.BackBitmap.Dispose();
        this.BackBitmap = (Bitmap) null;
      }
      this.BackBitmap = (Bitmap) this.OwnBitmap.Clone();
      int num1 = (int) Math.Round(Math.Floor((double) (this.useWidth - 1280) / 2.0));
      int int32 = Convert.ToInt32(Math.Floor(new Decimal(this.useHeight - 768)));
      Rectangle rectangle1 = new Rectangle(35, 160, 595 + num1, 555 + int32);
      Rectangle rectangle2 = new Rectangle(this.useWidth - (638 + num1), 160, 595 + num1, 555 + int32);
      Rectangle rectangle3 = new Rectangle(35, 12, 370, 140);
      Rectangle rectangle4 = new Rectangle(this.useWidth - 413, 12, 370, 140);
      Rectangle rectangle5 = new Rectangle((int) Math.Round((double) this.useWidth / 2.0) - 185, 0, 371, 90);
      int num2;
      int num3;
      int num4;
      int num5;
      int num6;
      int num7;
      int num8;
      int num9;
      int num10;
      if (this.useZoom == 1)
      {
        num2 = 85;
        num3 = (int) Math.Round(Math.Floor((double) (555 + int32) / (double) num2));
        num4 = (int) Math.Round(Math.Floor((double) (595 + num1) / (double) num2));
        num5 = (int) Math.Round((double) (rectangle1.Width - num4 * num2) / 2.0);
        num6 = (int) Math.Round((double) (rectangle1.Height - num3 * num2) / 2.0);
        num7 = 4;
        num8 = 4;
        num9 = 76;
        num10 = 76;
      }
      else if (this.useZoom == 0)
      {
        num2 = 43;
        num3 = (int) Math.Round(Math.Floor((double) (555 + int32) / (double) num2));
        num4 = (int) Math.Round(Math.Floor((double) (595 + num1) / (double) num2));
        num5 = (int) Math.Round((double) (rectangle1.Width - num4 * num2) / 2.0);
        num6 = (int) Math.Round((double) (rectangle1.Height - num3 * num2) / 2.0);
        num7 = 2;
        num8 = 2;
        num9 = 38;
        num10 = 38;
      }
      if (!this.crmSet | this.crmSetOnRound < this.game.TempCombat.CombatRound)
      {
        int num11 = 0;
        int num12 = 0;
        int val2 = 0;
        int val1 = 0;
        this.crmSet = true;
        this.crmSetOnRound = this.game.TempCombat.CombatRound;
        bool[] flagArray = new bool[this.game.TempCombat.UCounter + 1];
        int ucounter1 = this.game.TempCombat.UCounter;
        for (int index2 = 0; index2 <= ucounter1; index2 += 1)
        {
          int num13 = 3;
          flagArray[index2] = (double) this.game.Data.RuleVar[431] <= 0.0;
          if (this.game.Data.MapObj[0].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].MaxRecon >= 0)
            flagArray[index2] = true;
          int icounter = this.game.TempCombat.ICounter;
          int num14;
          for (int index3 = 0; index3 <= icounter; index3 += 1)
          {
            if (this.game.TempCombat.IList[index3].IUnr == this.game.TempCombat.UList[index2].UNr)
            {
              bool flag = true;
              if ((double) this.game.Data.RuleVar[431] > 0.0)
              {
                flag = false;
                if (this.game.TempCombat.IList[index3].IvisibleFromRound <= this.game.TempCombat.CombatRound | this.game.Data.UnitObj[this.game.TempCombat.IList[index3].IUnr].Regime == this.game.Data.Turn)
                {
                  flag = true;
                  flagArray[index2] = true;
                }
              }
              if (!flagArray[index2])
                flag = false;
              if (flag)
              {
                num13 += 1;
                if (this.game.TempCombat.IList[index3].IunitFeatStart > 0)
                  num13 += 1;
              }
              else
              {
                num14 += 1;
                if (this.game.TempCombat.IList[index3].IunitFeatStart > 0)
                  num14 += 1;
              }
            }
          }
          if (flagArray[index2])
          {
            int num15 = (int) Math.Round(Math.Ceiling((double) num13 / (double) num4));
            if (this.game.TempCombat.UList[index2].Uattacker == 1)
              num11 += num15;
            else
              num12 += num15;
          }
          int num16 = (int) Math.Round(Math.Ceiling((double) (num14 + num13) / (double) num4));
          if (this.game.TempCombat.UList[index2].Uattacker == 1)
            val1 += num16;
          else
            val2 += num16;
        }
        int num17 = Math.Max(val1, val2) + (this.game.TempCombat.UCounter + 1);
        int num18 = num4 + 1;
        this.crm = new int[2, num18 + 1, num17 + (num3 + 2) + 1, 5];
        num4 = num18 - 1;
        int index4 = 0;
        int index5 = 0;
        int index6 = -1;
        int index7 = -1;
        int ucounter2 = this.game.TempCombat.UCounter;
        for (int index8 = 0; index8 <= ucounter2; index8 += 1)
        {
          int index9 = 0;
          if (this.game.TempCombat.UList[index8].Uattacker == 1)
            index9 = 1;
          if (flagArray[index8])
          {
            if (index9 == 1)
            {
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 1;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 1;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 2;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 2;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 5;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 5;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
            }
            else
            {
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 5;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 5;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 2;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 2;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 1)
                index6 += 1;
              else
                index7 += 1;
              if (index6 >= num4)
              {
                index4 += 1;
                index6 = 0;
              }
              if (index7 >= num4)
              {
                index5 += 1;
                index7 = 0;
              }
              if (index9 == 1)
                this.crm[index9, index6, index4, 0] = 1;
              if (index9 == 1)
                this.crm[index9, index6, index4, 1] = this.game.TempCombat.UList[index8].UNr;
              if (index9 == 0)
                this.crm[index9, index7, index5, 0] = 1;
              if (index9 == 0)
                this.crm[index9, index7, index5, 1] = this.game.TempCombat.UList[index8].UNr;
            }
            int icounter1 = this.game.TempCombat.ICounter;
            for (int index10 = 0; index10 <= icounter1; index10 += 1)
            {
              if (this.game.TempCombat.IList[index10].IUnr == this.game.TempCombat.UList[index8].UNr && this.game.TempCombat.IList[index10].IunitFeatStart > 0)
              {
                bool flag = true;
                if ((double) this.game.Data.RuleVar[431] > 0.0)
                {
                  flag = false;
                  if (this.game.TempCombat.IList[index10].IvisibleFromRound <= this.game.TempCombat.CombatRound | this.game.Data.UnitObj[this.game.TempCombat.IList[index10].IUnr].Regime == this.game.Data.Turn)
                    flag = true;
                }
                if (flag)
                {
                  if (index9 == 1)
                    index6 += 1;
                  else
                    index7 += 1;
                  if (index6 >= num4)
                  {
                    index4 += 1;
                    index6 = 0;
                  }
                  if (index7 >= num4)
                  {
                    index5 += 1;
                    index7 = 0;
                  }
                  if (index9 == 1)
                    this.crm[index9, index6, index4, 0] = 4;
                  if (index9 == 1)
                    this.crm[index9, index6, index4, 1] = this.game.TempCombat.IList[index10].IID;
                  if (index9 == 0)
                    this.crm[index9, index7, index5, 0] = 4;
                  if (index9 == 0)
                    this.crm[index9, index7, index5, 1] = this.game.TempCombat.IList[index10].IID;
                }
              }
            }
            int icounter2 = this.game.TempCombat.ICounter;
            for (int index11 = 0; index11 <= icounter2; index11 += 1)
            {
              if (this.game.TempCombat.IList[index11].IUnr == this.game.TempCombat.UList[index8].UNr)
              {
                bool flag = true;
                if ((double) this.game.Data.RuleVar[431] > 0.0)
                {
                  flag = false;
                  if (this.game.TempCombat.IList[index11].IvisibleFromRound <= this.game.TempCombat.CombatRound | this.game.Data.UnitObj[this.game.TempCombat.IList[index11].IUnr].Regime == this.game.Data.Turn)
                    flag = true;
                }
                if (flag)
                {
                  if (index9 == 1)
                    index6 += 1;
                  else
                    index7 += 1;
                  if (index6 >= num4)
                  {
                    index4 += 1;
                    index6 = 0;
                  }
                  if (index7 >= num4)
                  {
                    index5 += 1;
                    index7 = 0;
                  }
                  if (index9 == 1)
                    this.crm[index9, index6, index4, 0] = 3;
                  if (index9 == 1)
                    this.crm[index9, index6, index4, 1] = this.game.TempCombat.IList[index11].IID;
                  if (index9 == 0)
                    this.crm[index9, index7, index5, 0] = 3;
                  if (index9 == 0)
                    this.crm[index9, index7, index5, 1] = this.game.TempCombat.IList[index11].IID;
                }
              }
            }
            if (index9 == 1)
              index4 += 1;
            else
              index5 += 1;
            if (index9 == 1)
              index6 = -1;
            else
              index7 = -1;
          }
        }
        int num19 = (int) Math.Round(Math.Ceiling((double) (index4 + 1) / (double) num3) - 1.0);
        if (num19 < 0)
          num19 = 0;
        this.attPage = 0;
        this.maxAttPage = num19;
        int num20 = (int) Math.Round(Math.Ceiling((double) index5 / (double) num3) - 1.0);
        if (num20 < 0)
          num20 = 0;
        this.defPage = 0;
        this.maxDefPage = num20;
        int num21 = index5;
        for (int index12 = 0; index12 <= num21; index12 += 1)
        {
          int[,] numArray = new int[num4 + 1, 5];
          int num22 = num4 - 1;
          for (int index13 = 0; index13 <= num22; index13 += 1)
          {
            int index14 = 0;
            do
            {
              numArray[index13, index14] = this.crm[0, index13, index12, index14];
              index14 += 1;
            }
            while (index14 <= 4);
          }
          int num23 = num4 - 1;
          for (int index15 = 0; index15 <= num23; index15 += 1)
          {
            int index16 = 0;
            do
            {
              this.crm[0, index15, index12, index16] = numArray[num4 - 1 - index15, index16];
              index16 += 1;
            }
            while (index16 <= 4);
          }
        }
      }
      int[] numArray1 = new int[2];
      int[] numArray2 = new int[2];
      int[] numArray3 = new int[2];
      int[] numArray4 = new int[2];
      int[] numArray5 = new int[2];
      int[] numArray6 = new int[2];
      int num24 = 0;
      do
      {
        int icounter = this.game.TempCombat.ICounter;
        for (int index17 = 0; index17 <= icounter; index17 += 1)
        {
          if (this.game.TempCombat.IList[index17].IAttacker == num24)
          {
            bool flag = true;
            if ((double) this.game.Data.RuleVar[431] > 0.0)
            {
              flag = false;
              if (this.game.TempCombat.IList[index17].IvisibleFromRound <= this.game.TempCombat.CombatRound | this.game.Data.UnitObj[this.game.TempCombat.IList[index17].IUnr].Regime == this.game.Data.Turn)
                flag = true;
            }
            if (flag)
            {
              int[] numArray7 = numArray1;
              int[] numArray8 = numArray7;
              int index18 = num24;
              int index19 = index18;
              int num25 = numArray7[index18] + 1;
              numArray8[index19] = num25;
              if (this.game.TempCombat.IList[index17].IKilled > 0)
              {
                int[] numArray9 = numArray4;
                int[] numArray10 = numArray9;
                int index20 = num24;
                int index21 = index20;
                int num26 = numArray9[index20] + 1;
                numArray10[index21] = num26;
              }
              else if (this.game.TempCombat.IList[index17].IRetreat > 0 | this.game.TempCombat.IList[index17].IRetreated > 0)
              {
                int[] numArray11 = numArray2;
                int[] numArray12 = numArray11;
                int index22 = num24;
                int index23 = index22;
                int num27 = numArray11[index22] + 1;
                numArray12[index23] = num27;
              }
              else if (this.game.TempCombat.IList[index17].IKilled < 1 & this.game.TempCombat.IList[index17].IRetreat < 1)
              {
                int[] numArray13 = numArray3;
                int[] numArray14 = numArray13;
                int index24 = num24;
                int index25 = index24;
                int num28 = numArray13[index24] + 1;
                numArray14[index25] = num28;
              }
              else
              {
                int[] numArray15 = numArray5;
                int[] numArray16 = numArray15;
                int index26 = num24;
                int index27 = index26;
                int num29 = numArray15[index26] + 1;
                numArray16[index27] = num29;
              }
            }
            else
            {
              int[] numArray17 = numArray6;
              int[] numArray18 = numArray17;
              int index28 = num24;
              int index29 = index28;
              int num30 = numArray17[index28] + 1;
              numArray18[index29] = num30;
            }
          }
        }
        num24 += 1;
      }
      while (num24 <= 1);
      SimpleList simpleList1 = SimpleList::new();
      SimpleList simpleList2 = SimpleList::new();
      int counter1 = this.game.TempCombat.customCombatObj.logLeaderBonus.Counter;
      int num31;
      for (int index30 = 0; index30 <= counter1; index30 += 1)
      {
        int tid = this.game.TempCombat.customCombatObj.logLeaderBonus.Id[index30];
        int tdata3 = this.game.TempCombat.customCombatObj.logLeaderBonus.Data2[index30];
        if (simpleList2.FindNr(tid, tdata3: tdata3) == -1 & tdata3 >= 1)
        {
          int num32 = 0;
          int val2 = 0;
          int counter2 = this.game.TempCombat.customCombatObj.logLeaderBonus.Counter;
          for (int index31 = 0; index31 <= counter2; index31 += 1)
          {
            if (this.game.TempCombat.customCombatObj.logLeaderBonus.Id[index31] == tid & this.game.TempCombat.customCombatObj.logLeaderBonus.Data2[index31] == this.game.TempCombat.customCombatObj.logLeaderBonus.Data2[index30])
            {
              num32 += this.game.TempCombat.customCombatObj.logLeaderBonus.Weight[index31];
              val2 += this.game.TempCombat.customCombatObj.logLeaderBonus.Data1[index31];
            }
          }
          int tdata1 = (int) Math.Round((double) num32 / (double) Math.Max(1, val2));
          int num33 = 0;
          num31 = 0;
          int counter3 = this.game.TempCombat.customCombatObj.logLeaderBonusDef.Counter;
          for (int index32 = 0; index32 <= counter3; index32 += 1)
          {
            if (this.game.TempCombat.customCombatObj.logLeaderBonusDef.Id[index32] == tid & this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data2[index32] == this.game.TempCombat.customCombatObj.logLeaderBonus.Data2[index30])
            {
              num33 += this.game.TempCombat.customCombatObj.logLeaderBonusDef.Weight[index32];
              num31 += this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data1[index32];
            }
          }
          int tdata2 = (int) Math.Round((double) num33 / (double) Math.Max(1, num31));
          if (tdata1 >= 0 | tdata2 >= 0)
            simpleList2.Add(tid, (int) Math.Round((double) (tdata1 + tdata2) / 2.0), tdata1, tdata2, tdata3, CheckExistence: false);
        }
      }
      int counter4 = this.game.TempCombat.customCombatObj.logLeaderBonusDef.Counter;
      for (int index33 = 0; index33 <= counter4; index33 += 1)
      {
        int tid = this.game.TempCombat.customCombatObj.logLeaderBonusDef.Id[index33];
        int tdata3 = this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data2[index33];
        if (simpleList2.FindNr(tid, tdata3: tdata3) == -1 & tdata3 > 0)
        {
          int num34 = 0;
          int val2 = 0;
          int counter5 = this.game.TempCombat.customCombatObj.logLeaderBonus.Counter;
          for (int index34 = 0; index34 <= counter5; index34 += 1)
          {
            if (this.game.TempCombat.customCombatObj.logLeaderBonus.Id[index34] == tid & this.game.TempCombat.customCombatObj.logLeaderBonus.Data2[index34] == this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data2[index33])
            {
              num34 += this.game.TempCombat.customCombatObj.logLeaderBonus.Weight[index34];
              val2 += this.game.TempCombat.customCombatObj.logLeaderBonus.Data1[index34];
            }
          }
          int tdata1 = (int) Math.Round((double) num34 / (double) Math.Max(1, val2));
          int num35 = 0;
          num31 = 0;
          int counter6 = this.game.TempCombat.customCombatObj.logLeaderBonusDef.Counter;
          for (int index35 = 0; index35 <= counter6; index35 += 1)
          {
            if (this.game.TempCombat.customCombatObj.logLeaderBonusDef.Id[index35] == tid & this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data2[index35] == this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data2[index33])
            {
              num35 += this.game.TempCombat.customCombatObj.logLeaderBonusDef.Weight[index35];
              num31 += this.game.TempCombat.customCombatObj.logLeaderBonusDef.Data1[index35];
            }
          }
          int tdata2 = (int) Math.Round((double) num35 / (double) Math.Max(1, num31));
          if (tdata1 > 0 | tdata2 > 0)
            simpleList2.Add(tid, (int) Math.Round((double) (tdata1 + tdata2) / 2.0), tdata1, tdata2, tdata3, CheckExistence: false);
        }
      }
      int counter7 = simpleList2.Counter;
      for (int index36 = 0; index36 <= counter7; index36 += 1)
      {
        int tid = simpleList2.Id[index36];
        if (simpleList1.FindNr(tid) == -1)
        {
          int tdata1 = 0;
          int tdata2 = 0;
          int counter8 = simpleList2.Counter;
          for (int index37 = 0; index37 <= counter8; index37 += 1)
          {
            if (simpleList2.Id[index36] == simpleList2.Id[index37])
            {
              if (simpleList2.Data1[index37] > 0)
              {
                int num36 = (int) Math.Round((double) (tdata1 * simpleList2.Data1[index37]) / 100.0);
                tdata1 += simpleList2.Data1[index37] + num36;
              }
              if (simpleList2.Data2[index37] > 0)
              {
                int num37 = (int) Math.Round((double) (tdata2 * simpleList2.Data2[index37]) / 100.0);
                tdata2 += simpleList2.Data2[index37] + num37;
              }
            }
          }
          int num38 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList2.Id[index36], 6)));
          int tweight = 5;
          if (num38 == 4)
            tweight = 10;
          simpleList1.Add(tid, tweight, tdata1, tdata2, CheckExistence: false);
        }
      }
      simpleList2.ReverseSort();
      simpleList1.ReverseSort();
      bool flag1 = false;
      int counter9 = simpleList1.Counter;
      for (int index38 = 0; index38 <= counter9; index38 += 1)
      {
        int num39 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index38], 6)));
        int num40 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index38], 25)));
        int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index38], 5)));
        if (id < 1 & num40 > 0)
          id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index38], 26)));
        if (this.game.HandyFunctionsObj.GetRegimeByID(id) == this.game.TempCombat.AttackerRegime && num40 > 0)
          flag1 = true;
      }
      if (flag1)
        DrawMod.DrawBlockGradient2(ref graphics, 38, 46, this.useWidth - 82, this.useHeight - 64, Color.FromArgb(125, (int) byte.MaxValue, 0, 0), Color.FromArgb(0, (int) byte.MaxValue, 0, 0));
      ref Graphics local1 = ref graphics;
      Bitmap bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBAR1);
      ref Bitmap local2 = ref bitmap;
      int x1 = rectangle3.X;
      int y1 = rectangle3.Y;
      DrawMod.DrawSimple(ref local1, ref local2, x1, y1);
      Matrix matrix1 = Matrix::new();
      matrix1.Scale(-1f, 1f);
      matrix1.Translate(0.0f, 0.0f);
      graphics.Transform = matrix1;
      ref Graphics local3 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBAR1);
      ref Bitmap local4 = ref bitmap;
      int x2 = -(rectangle4.X + BitmapStore.GetWidth(this.game.SE1_COMBATBAR1));
      int y2 = rectangle3.Y;
      DrawMod.DrawSimple(ref local3, ref local4, x2, y2);
      graphics.ResetTransform();
      int num41 = 0;
      int num42 = 0;
      int num43 = 62;
      int w1 = (int) Math.Round((double) (100 * num43) / 140.0);
      int x3 = rectangle3.X;
      int num44 = rectangle3.Y + 87;
      int num45 = x3 + 100;
      int num46 = num41 + 100;
      int num47 = rectangle4.X + rectangle4.Width - (90 + w1 + 50);
      if (this.game.ScreenWidth < 1660)
      {
        num45 -= 90;
        num47 += 90;
      }
      int num48 = 0;
      int num49 = 0;
      int counter10 = simpleList1.Counter;
      Rectangle trect1;
      Rectangle trect2;
      for (int index39 = 0; index39 <= counter10; index39 += 1)
      {
        int num50 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index39], 6)));
        int num51 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index39], 25)));
        int id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index39], 5)));
        if (id < 1 & num51 > 0)
          id = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index39], 26)));
        int regimeById = this.game.HandyFunctionsObj.GetRegimeByID(id);
        bool flag2 = false;
        if (regimeById == this.game.TempCombat.AttackerRegime)
        {
          if (num49 <= 2)
          {
            ref Graphics local5 = ref graphics;
            bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(simpleList1.Id[index39], w1, num43);
            ref Bitmap local6 = ref bitmap;
            int x4 = num45;
            int y3 = num44;
            DrawMod.DrawSimple(ref local5, ref local6, x4, y3);
            DrawMod.DrawBlock(ref graphics, num45 + w1, num44, 45, num43, 0, 0, 0, 128);
            DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, num45 - 6, num44, w1 + 51, num43, 10, 10, 10);
            str: String = ((int) Math.Round((double) simpleList1.Data1[index39] + (double) simpleList1.Data2[index39] / 2.0)).ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if ((int) Math.Round((double) simpleList1.Data1[index39] + (double) simpleList1.Data2[index39] / 2.0) > 0)
              str = "+" + str;
            tstring1: String = "HQ";
            if (num51 < 1)
            {
              if (num50 == 3)
                tstring1 = "OHQ";
              if (num50 == 4)
                tstring1 = "SHQ";
              DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring1, this.game.MarcFont4, num45 + w1 + 21, num44 + (int) Math.Round((double) num43 * 0.35) - 10, Color.LightGray);
            }
            else
            {
              tstring2: String = "KIA";
              DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring2, this.game.MarcFont4, num45 + w1 + 21, num44 + (int) Math.Round((double) num43 * 0.35) - 10, Color.Red);
            }
            DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + w1 + 21, num44 + (int) Math.Round((double) num43 * 0.35) + 10, Color.White);
            num31 = w1 + 55;
            num49 += 1;
          }
          else
            flag2 = true;
        }
        else if ((double) this.game.Data.MapObj[0].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].MaxRecon < (double) this.game.Data.RuleVar[55])
          flag2 = true;
        else if (num48 <= 2)
        {
          ref Graphics local7 = ref graphics;
          bitmap = this.game.CustomBitmapObj.DrawLeaderPortrait(simpleList1.Id[index39], w1, num43);
          ref Bitmap local8 = ref bitmap;
          int x5 = num47;
          int y4 = num44;
          DrawMod.DrawSimple(ref local7, ref local8, x5, y4);
          DrawMod.DrawBlock(ref graphics, num47 + w1, num44, 45, num43, 0, 0, 0, 128);
          DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, num47 - 6, num44, w1 + 51, num43, 10, 10, 10);
          str: String = ((int) Math.Round((double) simpleList1.Data1[index39] + (double) simpleList1.Data2[index39] / 2.0)).ToString() + "%";
          if (Operators.CompareString(str, "0%", false) == 0)
            str = "-";
          else if ((int) Math.Round((double) simpleList1.Data1[index39] + (double) simpleList1.Data2[index39] / 2.0) > 0)
            str = "+" + str;
          tstring: String = "HQ";
          if (num50 == 3)
            tstring = "OHQ";
          if (num50 == 4)
            tstring = "SHQ";
          DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num47 + w1 + 21, num44 + (int) Math.Round((double) num43 * 0.35) + 10, Color.White);
          DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring, this.game.MarcFont4, num47 + w1 + 21, num44 + (int) Math.Round((double) num43 * 0.35) - 10, Color.White);
          num31 = w1 + 55;
          num48 += 1;
        }
        else
          flag2 = true;
        int num52 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotChar].GetData(0, simpleList1.Id[index39], 6)));
        leaderName: String = this.game.EventRelatedObj.GetLeaderName(simpleList1.Id[index39], true);
        ttext: String = (num51 <= 0 ? this.game.EventRelatedObj.Helper_GetCharacterJobTitle(simpleList1.Id[index39]) + "\r\n" : "Leader was killed in combat.\r\n") + "-----------------\r\n" + "Skill rolls added on average " + simpleList1.Data1[index39].ToString() + "% to attack power of subordinate troops.\r\n" + "Skill rolls added on average " + simpleList1.Data2[index39].ToString() + "% to hitpoints of subordinate troops.\r\n";
        str1: String = "";
        int counter11 = simpleList2.Counter;
        for (int index40 = 0; index40 <= counter11; index40 += 1)
        {
          if (simpleList2.Id[index40] == simpleList1.Id[index39] && simpleList2.Data1[index40] > 0 | simpleList2.Data2[index40] > 0)
          {
            int idValue = simpleList2.Data3[index40];
            str1 = str1 + this.game.Data.StringListObj[this.slotSkillType].GetData(0, idValue, 1) + " skill rolls gave " + simpleList2.Data1[index40].ToString() + "% attack power bonus and " + simpleList2.Data2[index40].ToString() + "% hitpoints bonus." + "\r\n";
          }
        }
        if (str1.Length > 1)
          ttext = ttext + "-----------------\r\n" + str1;
        if (!flag2)
        {
          if (regimeById == this.game.TempCombat.AttackerRegime)
          {
            trect1 = new Rectangle(num45, num44, num31, num43);
            trect2 = trect1;
            this.AddMouse(ref trect2, leaderName, ttext);
            num45 += num31;
            num46 += num31;
          }
          else
          {
            trect2 = new Rectangle(num47, num44, num31, num43);
            trect1 = trect2;
            this.AddMouse(ref trect1, leaderName, ttext);
            num47 -= num31;
            num42 += num31;
          }
        }
      }
      for (int index41 = num48; index41 <= 2; index41 += 1)
      {
        DrawMod.DrawBlock(ref graphics, num47, num44, 45 + w1, num43, 0, 0, 0, 128);
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, num47 - 6, num44, w1 + 51, num43, 10, 10, 10);
        int num53 = w1 + 55;
        num47 -= num53;
        num42 += num53;
      }
      for (int index42 = num49; index42 <= 2; index42 += 1)
      {
        DrawMod.DrawBlock(ref graphics, num45, num44, 45 + w1, num43, 0, 0, 0, 128);
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, num45 - 6, num44, w1 + 51, num43, 10, 10, 10);
        int num54 = w1 + 55;
        num45 += num54;
        num46 += num54;
      }
      if (num42 > 0)
        num42 += 50 + w1;
      if (num42 > num46)
        num46 = num42;
      if (num46 > num42)
        ;
      int x6 = num47 + 40;
      int num55 = 1;
      int index43;
      int num56;
      int index44;
      int index45;
      do
      {
        DrawMod.DrawBlock(ref graphics, num45, num44, 45, 62, 0, 0, 0, 128);
        int tid = 0;
        do
        {
          int num57 = 0;
          int num58 = 0;
          index43 = 0;
          int num59 = 0;
          int num60 = 0;
          int num61 = 0;
          int num62 = 0;
          int num63 = 0;
          int num64 = 0;
          num56 = 0;
          int num65 = 0;
          int num66 = 0;
          if (num55 == 1)
          {
            int nr1 = this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 1);
            if (nr1 > -1)
            {
              num58 = this.game.TempCombat.customCombatObj.otherBonus.Weight[nr1];
              num57 = this.game.TempCombat.customCombatObj.otherBonus.Data1[nr1];
            }
            int nr2 = this.game.TempCombat.customCombatObj.otherBonusDef.FindNr(tid, tdata2: 1);
            if (nr2 > -1)
            {
              num63 = this.game.TempCombat.customCombatObj.otherBonusDef.Weight[nr2];
              num62 = this.game.TempCombat.customCombatObj.otherBonusDef.Data1[nr2];
            }
            int nr3 = this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 2);
            if (nr3 > -1)
            {
              num59 = this.game.TempCombat.customCombatObj.otherBonus.Weight[nr3];
              index43 = this.game.TempCombat.customCombatObj.otherBonus.Data1[nr3];
            }
            int nr4 = this.game.TempCombat.customCombatObj.otherBonusDef.FindNr(tid, tdata2: 2);
            if (nr4 > -1)
            {
              num56 = this.game.TempCombat.customCombatObj.otherBonusDef.Weight[nr4];
              num64 = this.game.TempCombat.customCombatObj.otherBonusDef.Data1[nr4];
            }
          }
          if (num55 == 2)
          {
            int nr5 = this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 4);
            if (nr5 > -1)
            {
              num58 = this.game.TempCombat.customCombatObj.otherBonus.Weight[nr5];
              num57 = this.game.TempCombat.customCombatObj.otherBonus.Data1[nr5];
            }
            int nr6 = this.game.TempCombat.customCombatObj.otherBonusDef.FindNr(tid, tdata2: 4);
            if (nr6 > -1)
            {
              num63 = this.game.TempCombat.customCombatObj.otherBonusDef.Weight[nr6];
              num62 = this.game.TempCombat.customCombatObj.otherBonusDef.Data1[nr6];
            }
            int nr7 = this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 5);
            if (nr7 > -1)
            {
              num59 = this.game.TempCombat.customCombatObj.otherBonus.Weight[nr7];
              index43 = this.game.TempCombat.customCombatObj.otherBonus.Data1[nr7];
            }
            int nr8 = this.game.TempCombat.customCombatObj.otherBonusDef.FindNr(tid, tdata2: 5);
            if (nr8 > -1)
            {
              num56 = this.game.TempCombat.customCombatObj.otherBonusDef.Weight[nr8];
              num64 = this.game.TempCombat.customCombatObj.otherBonusDef.Data1[nr8];
            }
          }
          if (num55 >= 3)
          {
            int repCounter = this.game.TempCombat.RepCounter;
            for (int index46 = 0; index46 <= repCounter; index46 += 1)
            {
              int num67 = this.game.TempCombat.RepFrom[index46];
              if (num67 >= 10000 & this.game.TempCombat.RepType[index46] == 1 && this.game.TempCombat.IList[num67 - 10000].IAttacker == tid)
              {
                if (Strings.InStr(this.game.TempCombat.RepTitle[index46], "=>") > 0)
                {
                  int index47 = 0;
                  do
                  {
                    switch (num55)
                    {
                      case 3:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Landscape", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          num57 += 1;
                          num58 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Concentric", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          index43 += 1;
                          num59 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Entrenchment", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          num60 += 1;
                          num61 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                          break;
                        }
                        break;
                      case 4:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Readiness", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          num57 += 1;
                          num58 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Experience", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          index43 += 1;
                          num59 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                          break;
                        }
                        break;
                      case 5:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Supply", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          num57 += 1;
                          num58 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Ammunition Mod", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          index43 += 1;
                          num59 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index47, 0, index46], "Fuel Mod", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index47, 1, index46], "?", false) != 0)
                        {
                          num60 += 1;
                          num61 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index47, 1, index46]));
                          break;
                        }
                        break;
                    }
                    index47 += 1;
                  }
                  while (index47 <= 60);
                }
                if (Strings.InStr(this.game.TempCombat.RepTitle[index46], "<=") > 0)
                {
                  int index48 = 0;
                  do
                  {
                    switch (num55)
                    {
                      case 3:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Landscape", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num62 += 1;
                          num63 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Concentric", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num64 += 1;
                          num56 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Entrenchment", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num65 += 1;
                          num66 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                          break;
                        }
                        break;
                      case 4:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Readiness", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num62 += 1;
                          num63 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Experience", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num64 += 1;
                          num56 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                          break;
                        }
                        break;
                      case 5:
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Supply", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num57 += 1;
                          num58 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Ammunition Mod", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          index43 += 1;
                          num59 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                        }
                        if (Operators.CompareString(this.game.TempCombat.RepCom[index48, 3, index46], "Fuel Mod", false) == 0 & Operators.CompareString(this.game.TempCombat.RepCom[index48, 4, index46], "?", false) != 0)
                        {
                          num60 += 1;
                          num61 += (int) Math.Round(Conversion.Val(this.game.TempCombat.RepCom[index48, 4, index46]));
                          break;
                        }
                        break;
                    }
                    index48 += 1;
                  }
                  while (index48 <= 60);
                }
              }
            }
          }
          index44 = num57 <= 0 ? 0 : (int) Math.Round((double) num58 / (double) num57);
          int num68 = index43 <= 0 ? 0 : (int) Math.Round((double) num59 / (double) index43);
          int num69 = num60 <= 0 ? 0 : (int) Math.Round((double) num61 / (double) num60);
          int num70 = num62 <= 0 ? 0 : (int) Math.Round((double) num63 / (double) num62);
          num56 = num64 <= 0 ? 0 : (int) Math.Round((double) num56 / (double) num64);
          num66 = num65 <= 0 ? 0 : (int) Math.Round((double) num66 / (double) num65);
          if (num55 == 1)
          {
            int num71 = 4;
            index45 = (int) Math.Round((double) (100 + index44) * ((double) (100 + num68) / 100.0) * ((double) (num70 + 100) / 100.0) * ((double) (num56 + 100) / 100.0)) - 100;
            str: String = index45.ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if (Operators.CompareString(Strings.Left(str, 1), "-", false) != 0 & Strings.Len(str) > 1)
              str = "+" + str;
            if (num57 == 0 & index43 == 0 & num62 == 0 & num64 == 0 & tid == 0)
              str = "?";
            ttext: String = "Posture Bonus to Attack Values : " + index44.ToString() + "%\r\n" + "Posture Bonus of Hitpoints : " + num70.ToString() + "%\r\n" + "Profile Bonus to Attack Values : " + num68.ToString() + "%\r\n";
            if (tid == 1)
            {
              ref Graphics local9 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local10 = ref bitmap;
              trect2 = new Rectangle(num71 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(num45 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local9, ref local10, srcrect, destrect);
            }
            if (tid == 1)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", "No bonus or penalty.");
            }
            if (tid == 0)
            {
              ref Graphics local11 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local12 = ref bitmap;
              trect2 = new Rectangle(num71 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(x6 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local11, ref local12, srcrect, destrect);
            }
            if (tid == 0)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, x6 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPORT MODIFIERS", "No bonus or penalty.");
            }
          }
          if (num55 == 2)
          {
            int num72 = 30;
            index45 = (int) Math.Round((double) (100 + index44) * ((double) (100 + num68) / 100.0) * ((double) (num70 + 100) / 100.0) * ((double) (num56 + 100) / 100.0)) - 100;
            str: String = index45.ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if (Operators.CompareString(Strings.Left(str, 1), "-", false) != 0 & Strings.Len(str) > 1)
              str = "+" + str;
            if (this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 4) > -1 | this.game.TempCombat.customCombatObj.otherBonus.FindNr(tid, tdata2: 5) > -1 && num57 == 0 & index43 == 0 & num62 == 0 & num64 == 0 & tid == 0)
              str = "?";
            ttext: String = "Weapon Matrix Modifier for Attack Values : " + index44.ToString() + "%\r\n" + "Callibre Modifier to Attack Values : " + num68.ToString() + "%\r\n";
            if (tid == 1)
            {
              ref Graphics local13 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local14 = ref bitmap;
              trect2 = new Rectangle(num72 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(num45 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local13, ref local14, srcrect, destrect);
            }
            if (tid == 1)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", "No bonus or penalty.");
            }
            if (tid == 0)
            {
              ref Graphics local15 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local16 = ref bitmap;
              trect2 = new Rectangle(num72 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(x6 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local15, ref local16, srcrect, destrect);
            }
            if (tid == 0)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, x6 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "WEAPON MODIFIERS", "No bonus or penalty.");
            }
          }
          if (num55 == 3)
          {
            int num73 = 38;
            index45 = (int) Math.Round((double) (100 + index44) * ((double) (100 + num68) / 100.0) * ((double) (num70 + 100) / 100.0) * ((double) (num56 + 100) / 100.0) * ((double) (num66 + 100) / 100.0) * ((double) (num69 + 100) / 100.0)) - 100;
            str: String = index45.ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if (Operators.CompareString(Strings.Left(str, 1), "-", false) != 0 & Strings.Len(str) > 1)
              str = "+" + str;
            if (num57 == 0 & index43 == 0 & num62 == 0 & num64 == 0 & tid == 0)
              str = "?";
            ttext: String = "Landscape Modifier of Attack Values : " + index44.ToString() + "%\r\n" + "Concentric Attack Modifier of Attack Values : " + num68.ToString() + "%\r\n" + "Landscape Modifier of Hitpoints : " + num70.ToString() + "%\r\n" + "Concentric Attack Modifier of Hitpoints : " + num56.ToString() + "%\r\n" + "Entrenchment Modifier of Hitpoints: " + num66.ToString() + "%\r\n";
            if (tid == 1)
            {
              ref Graphics local17 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local18 = ref bitmap;
              trect2 = new Rectangle(num73 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(num45 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local17, ref local18, srcrect, destrect);
            }
            if (tid == 1)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", "No bonus or penalty.");
            }
            if (tid == 0)
            {
              ref Graphics local19 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local20 = ref bitmap;
              trect2 = new Rectangle(num73 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(x6 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local19, ref local20, srcrect, destrect);
            }
            if (tid == 0)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, x6 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TERRAIN MODIFIERS", "No bonus or penalty.");
            }
          }
          if (num55 == 4)
          {
            int num74 = 33;
            index45 = (int) Math.Round((double) (100 + index44) * ((double) (100 + num68) / 100.0) * ((double) (num70 + 100) / 100.0) * ((double) (num56 + 100) / 100.0)) - 100;
            str: String = index45.ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if (Operators.CompareString(Strings.Left(str, 1), "-", false) != 0 & Strings.Len(str) > 1)
              str = "+" + str;
            if (num57 == 0 & index43 == 0 & num62 == 0 & num64 == 0 & tid == 0)
              str = "?";
            ttext: String = "Readiness Modifier of Attack Values: " + index44.ToString() + "%\r\n" + "Experience Modifier of Attack Values : " + num68.ToString() + "%\r\n" + "Readiness Modifier of Hitpoints: " + num70.ToString() + "%\r\n" + "Experience Modifier of Hitpoints : " + num56.ToString() + "%\r\n";
            if (tid == 1)
            {
              ref Graphics local21 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local22 = ref bitmap;
              trect2 = new Rectangle(num74 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(num45 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local21, ref local22, srcrect, destrect);
            }
            if (tid == 1)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", "No bonus or penalty.");
            }
            if (tid == 0)
            {
              ref Graphics local23 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local24 = ref bitmap;
              trect2 = new Rectangle(num74 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(x6 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local23, ref local24, srcrect, destrect);
            }
            if (tid == 0)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, x6 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "TROOP MODIFIERS", "No bonus or penalty.");
            }
          }
          if (num55 == 5)
          {
            int num75 = 37;
            index45 = (int) Math.Round((double) (100 + index44) * ((double) (100 + num68) / 100.0) * ((double) (num70 + 100) / 100.0) * ((double) (num56 + 100) / 100.0) * ((double) (num66 + 100) / 100.0) * ((double) (num69 + 100) / 100.0)) - 100;
            str: String = index45.ToString() + "%";
            if (Operators.CompareString(str, "0%", false) == 0)
              str = "-";
            else if (Operators.CompareString(Strings.Left(str, 1), "-", false) != 0 & Strings.Len(str) > 1)
              str = "+" + str;
            if (num57 == 0 & index43 == 0 & num62 == 0 & num64 == 0 & num60 == 0 & num65 == 0 & tid == 0)
              str = "?";
            ttext: String = "Supply Modifier of Attack Values: " + index44.ToString() + "%\r\n" + "Ammo Modifier of Attack Values : " + num68.ToString() + "%\r\n" + "Fuel Modifier of Attack Values : " + num69.ToString() + "%\r\n" + "Supply Modifier of Hitpoints: " + num70.ToString() + "%\r\n" + "Ammo Modifier of Hitpoints : " + num56.ToString() + "%\r\n" + "Fuel Modifier  of Hitpoints : " + num66.ToString() + "%\r\n";
            if (tid == 1)
            {
              ref Graphics local25 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local26 = ref bitmap;
              trect2 = new Rectangle(num75 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(num45 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local25, ref local26, srcrect, destrect);
            }
            if (tid == 1)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, num45 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 1)
            {
              trect2 = new Rectangle(num45, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", "No bonus or penalty.");
            }
            if (tid == 0)
            {
              ref Graphics local27 = ref graphics;
              bitmap = BitmapStore.GetBitmap(DrawMod.TGame.SE1_ICONS);
              ref Bitmap local28 = ref bitmap;
              trect2 = new Rectangle(num75 * 42, 0, 42, 32);
              Rectangle srcrect = trect2;
              trect1 = new Rectangle(x6 + 2, num44 + 3, 42, 32);
              Rectangle destrect = trect1;
              DrawMod.DrawSimplePart2(ref local27, ref local28, srcrect, destrect);
            }
            if (tid == 0)
              DrawMod.DrawTextColouredMarcCenter(ref graphics, str, this.game.MarcFont16, x6 + 22, num44 + 34, Color.White);
            if (Operators.CompareString(str, "?", false) != 0 & Operators.CompareString(str, "-", false) != 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", ttext);
            }
            if (Operators.CompareString(str, "?", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", "No details available.");
            }
            if (Operators.CompareString(str, "-", false) == 0 & tid == 0)
            {
              trect2 = new Rectangle(x6, num44, 45, 60);
              trect1 = trect2;
              this.AddMouse(ref trect1, "SUPPLY MODIFIERS", "No bonus or penalty.");
            }
          }
          tid += 1;
        }
        while (tid <= 1);
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, num45, num44, 45, 62, 10, 10, 10);
        DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, x6, num44, 45, 62, 10, 10, 10);
        num45 += 46;
        x6 -= 46;
        num55 += 1;
      }
      while (num55 <= 5);
      int index49 = 0;
      do
      {
        if (index49 == 0)
          index44 = this.game.TempCombat.DefenderRegime;
        if (index49 == 1)
          index44 = this.game.TempCombat.AttackerRegime;
        if (index44 == -1)
          index44 = 1;
        int red = this.game.Data.RegimeObj[index44].Red;
        int green = this.game.Data.RegimeObj[index44].Green;
        int blue = this.game.Data.RegimeObj[index44].Blue;
        int red2 = this.game.Data.RegimeObj[index44].Red2;
        int green2 = this.game.Data.RegimeObj[index44].Green2;
        int blue2 = this.game.Data.RegimeObj[index44].Blue2;
        if (((this.game.TempCombat.BattleEnded <= 0 ? 1 : 0) | 1) != 0)
        {
          Rectangle rectangle6;
          if (index49 == 1)
            rectangle6 = new Rectangle(rectangle3.X + 100, rectangle3.Y + 44, 240, 30);
          if (index49 == 0)
            rectangle6 = new Rectangle(rectangle4.X + rectangle4.Width - 340, rectangle4.Y + 44, 240, 30);
          Color color1 = Color.FromArgb((int) byte.MaxValue, 55, 155, 55);
          Color color2 = Color.FromArgb((int) byte.MaxValue, 55, 105, 155);
          Color color3 = Color.FromArgb((int) byte.MaxValue, 105, 105, 105);
          Color color4 = Color.FromArgb((int) byte.MaxValue, 155, 55, 55);
          int num76 = rectangle6.Width - 8;
          if (numArray1[index49] > 0)
          {
            if (index49 == 1)
            {
              int num77 = 4;
              int num78 = (int) Math.Round((double) (num76 * numArray3[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num77, rectangle6.Y + 4, num78, rectangle6.Height - 8, (int) color1.R, (int) color1.G, (int) color1.B, (int) color1.A);
              trect2 = new Rectangle(rectangle6.X + num77, rectangle6.Y + 4, num78, rectangle6.Height - 8);
              Rectangle trect3 = trect2;
              this.AddMouse(ref trect3, "", "Attacker still has " + numArray3[index49].ToString() + " sub units fighting.");
              int num79 = num77 + num78;
              int num80 = (int) Math.Round((double) (num76 * numArray2[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num79, rectangle6.Y + 4, num80, rectangle6.Height - 8, (int) color2.R, (int) color2.G, (int) color2.B, (int) color2.A);
              trect2 = new Rectangle(rectangle6.X + num79, rectangle6.Y + 4, num80, rectangle6.Height - 8);
              Rectangle trect4 = trect2;
              this.AddMouse(ref trect4, "", "Attacker has " + numArray2[index49].ToString() + " sub units that are retreating, or have retreated.");
              int num81 = num79 + num80;
              int num82 = (int) Math.Round((double) (num76 * numArray5[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num81, rectangle6.Y + 4, num82, rectangle6.Height - 8, (int) color3.R, (int) color3.G, (int) color3.B, (int) color3.A);
              trect2 = new Rectangle(rectangle6.X + num81, rectangle6.Y + 4, num82, rectangle6.Height - 8);
              Rectangle trect5 = trect2;
              this.AddMouse(ref trect5, "", "Attacker has " + numArray5[index49].ToString() + " sub units that are neither fighting, nor retreating, nor killed.");
              int num83 = num81 + num82;
              index44 = (int) Math.Round((double) (num76 * numArray4[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num83, rectangle6.Y + 4, index44, rectangle6.Height - 8, (int) color4.R, (int) color4.G, (int) color4.B, (int) color4.A);
              trect2 = new Rectangle(rectangle6.X + num83, rectangle6.Y + 4, index44, rectangle6.Height - 8);
              Rectangle trect6 = trect2;
              this.AddMouse(ref trect6, "", "Attacker has lost " + numArray4[index49].ToString() + " sub units.");
            }
            else
            {
              int num84 = 4;
              int num85 = (int) Math.Round((double) (num76 * numArray4[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num84, rectangle6.Y + 4, num85, rectangle6.Height - 8, (int) color4.R, (int) color4.G, (int) color4.B, (int) color4.A);
              trect2 = new Rectangle(rectangle6.X + num84, rectangle6.Y + 4, num85, rectangle6.Height - 8);
              Rectangle trect7 = trect2;
              this.AddMouse(ref trect7, "", "Defender has lost " + numArray4[index49].ToString() + " sub units.");
              int num86 = num84 + num85;
              int num87 = (int) Math.Round((double) (num76 * numArray5[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num86, rectangle6.Y + 4, num87, rectangle6.Height - 8, (int) color3.R, (int) color3.G, (int) color3.B, (int) color3.A);
              trect2 = new Rectangle(rectangle6.X + num86, rectangle6.Y + 4, num87, rectangle6.Height - 8);
              Rectangle trect8 = trect2;
              this.AddMouse(ref trect8, "", "Defender has " + numArray5[index49].ToString() + " sub units that are neither fighting, nor retreating, nor killed.");
              int num88 = num86 + num87;
              int num89 = (int) Math.Round((double) (num76 * numArray2[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num88, rectangle6.Y + 4, num89, rectangle6.Height - 8, (int) color2.R, (int) color2.G, (int) color2.B, (int) color2.A);
              trect2 = new Rectangle(rectangle6.X + num88, rectangle6.Y + 4, num89, rectangle6.Height - 8);
              Rectangle trect9 = trect2;
              this.AddMouse(ref trect9, "", "Defender has " + numArray2[index49].ToString() + " sub units that are retreating, or have retreated.");
              int num90 = num88 + num89;
              index44 = (int) Math.Round((double) (num76 * numArray3[index49]) / (double) numArray1[index49]);
              DrawMod.DrawBlock(ref graphics, rectangle6.X + num90, rectangle6.Y + 4, index44, rectangle6.Height - 8, (int) color1.R, (int) color1.G, (int) color1.B, (int) color1.A);
              trect2 = new Rectangle(rectangle6.X + num90, rectangle6.Y + 4, index44, rectangle6.Height - 8);
              Rectangle trect10 = trect2;
              this.AddMouse(ref trect10, "", "Defender still has " + numArray3[index49].ToString() + " sub units fighting.");
            }
            DrawMod.DrawSimpleFrame(ref this.game.LINESFRAME, ref graphics, rectangle6.X, rectangle6.Y, rectangle6.Width, rectangle6.Height, 10, 10, 10);
            index45 = (int) Math.Round((double) (100 * numArray3[index49]) / (double) numArray1[index49]);
            str: String = index45.ToString() + "%";
            if (numArray6[index49] > 0)
              str += " ?";
            tstring: String = str + " Troops Operational";
            DrawMod.DrawTextColouredMarcCenter(ref graphics, tstring, this.game.MarcFont16, rectangle6.X + (int) Math.Round((double) rectangle6.Width / 2.0), rectangle6.Y + Math.Max(rectangle6.Height - 50, 0) + 6, Color.White);
          }
        }
        int num91 = rectangle4.Y + 15;
        if (index49 == 0)
        {
          index44 = this.game.TempCombat.DefenderRegime;
          num45 = rectangle4.X + rectangle4.Width - 100;
        }
        if (index49 == 1)
        {
          index44 = this.game.TempCombat.AttackerRegime;
          num45 = rectangle3.X + 13;
        }
        if (index44 == -1)
          index44 = 1;
        if (this.game.ScreenWidth < 1660)
        {
          int bannerSpriteNr = this.game.Data.RegimeObj[index44].BannerSpriteNr;
          ref Graphics local29 = ref graphics;
          bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
          ref Bitmap local30 = ref bitmap;
          int x7 = num45;
          int y5 = num91;
          double r1 = (double) ((float) red / (float) byte.MaxValue) - 1.0;
          double g1 = (double) ((float) green / (float) byte.MaxValue) - 1.0;
          double b1 = (double) ((float) blue / (float) byte.MaxValue) - 1.0;
          DrawMod.DrawScaledColorized(ref local29, ref local30, x7, y5, 80, 75, 124, 210, (float) r1, (float) g1, (float) b1, 1f);
          int bannerSpriteNr2 = this.game.Data.RegimeObj[index44].BannerSpriteNr2;
          if (bannerSpriteNr2 > 0)
          {
            ref Graphics local31 = ref graphics;
            bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
            ref Bitmap local32 = ref bitmap;
            int x8 = num45;
            int y6 = num91;
            double r2 = (double) ((float) red2 / (float) byte.MaxValue) - 1.0;
            double g2 = (double) ((float) green2 / (float) byte.MaxValue) - 1.0;
            double b2 = (double) ((float) blue2 / (float) byte.MaxValue) - 1.0;
            DrawMod.DrawScaledColorized(ref local31, ref local32, x8, y6, 80, 75, 124, 210, (float) r2, (float) g2, (float) b2, 1f);
          }
          int hqSpriteNr2 = this.game.Data.RegimeObj[index44].HQSpriteNr2;
          if (hqSpriteNr2 > 0)
          {
            ref Graphics local33 = ref graphics;
            bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
            ref Bitmap local34 = ref bitmap;
            int x9 = num45 + 20;
            int y7 = num91 + 20;
            double r3 = (double) ((float) this.game.Data.RegimeObj[index44].Red3 / (float) byte.MaxValue) - 1.0;
            double g3 = (double) ((float) this.game.Data.RegimeObj[index44].Green3 / (float) byte.MaxValue) - 1.0;
            double b3 = (double) ((float) this.game.Data.RegimeObj[index44].Blue3 / (float) byte.MaxValue) - 1.0;
            DrawMod.Draw(ref local33, ref local34, x9, y7, (float) r3, (float) g3, (float) b3, 0.95f);
          }
        }
        else
        {
          int bannerSpriteNr = this.game.Data.RegimeObj[index44].BannerSpriteNr;
          ref Graphics local35 = ref graphics;
          bitmap = BitmapStore.GetBitmap(bannerSpriteNr);
          ref Bitmap local36 = ref bitmap;
          int x10 = num45;
          int y8 = num91;
          double r4 = (double) ((float) red / (float) byte.MaxValue) - 1.0;
          double g4 = (double) ((float) green / (float) byte.MaxValue) - 1.0;
          double b4 = (double) ((float) blue / (float) byte.MaxValue) - 1.0;
          DrawMod.DrawScaledColorized(ref local35, ref local36, x10, y8, 80, 135, 124, 210, (float) r4, (float) g4, (float) b4, 1f);
          int bannerSpriteNr2 = this.game.Data.RegimeObj[index44].BannerSpriteNr2;
          if (bannerSpriteNr2 > 0)
          {
            ref Graphics local37 = ref graphics;
            bitmap = BitmapStore.GetBitmap(bannerSpriteNr2);
            ref Bitmap local38 = ref bitmap;
            int x11 = num45;
            int y9 = num91;
            double r5 = (double) ((float) red2 / (float) byte.MaxValue) - 1.0;
            double g5 = (double) ((float) green2 / (float) byte.MaxValue) - 1.0;
            double b5 = (double) ((float) blue2 / (float) byte.MaxValue) - 1.0;
            DrawMod.DrawScaledColorized(ref local37, ref local38, x11, y9, 80, 135, 124, 210, (float) r5, (float) g5, (float) b5, 1f);
          }
          int hqSpriteNr2 = this.game.Data.RegimeObj[index44].HQSpriteNr2;
          if (hqSpriteNr2 > 0)
          {
            ref Graphics local39 = ref graphics;
            bitmap = BitmapStore.GetBitmap(hqSpriteNr2);
            ref Bitmap local40 = ref bitmap;
            int x12 = num45 + 20;
            int y10 = num91 + 44;
            double r6 = (double) ((float) this.game.Data.RegimeObj[index44].Red3 / (float) byte.MaxValue) - 1.0;
            double g6 = (double) ((float) this.game.Data.RegimeObj[index44].Green3 / (float) byte.MaxValue) - 1.0;
            double b6 = (double) ((float) this.game.Data.RegimeObj[index44].Blue3 / (float) byte.MaxValue) - 1.0;
            DrawMod.Draw(ref local39, ref local40, x12, y10, (float) r6, (float) g6, (float) b6, 0.95f);
          }
        }
        if (index49 == 0)
          DrawMod.DrawTextColouredConsoleCenter(ref graphics, this.game.Data.RegimeObj[index44].Name, this.game.MarcFont16, num45 - 117, num91 + 5, this.game.seColWhite);
        if (index49 == 1)
          DrawMod.DrawTextColouredConsoleCenter(ref graphics, this.game.Data.RegimeObj[index44].Name, this.game.MarcFont16, num45 + 217, num91 + 5, this.game.seColWhite);
        index49 += 1;
      }
      while (index49 <= 1);
      Rectangle trect11;
      if (this.showdetail <= 0)
      {
        int num92 = 0;
        do
        {
          int num93 = num3 - 1;
          for (int index50 = 0; index50 <= num93; index50 += 1)
          {
            int num94 = num4 - 1;
            for (int index51 = 0; index51 <= num94; index51 += 1)
            {
              int num95;
              int index52;
              if (num92 == 1)
              {
                num95 = this.crm[1, index51, index50 + this.attPage * num3, 0];
                index52 = this.crm[1, index51, index50 + this.attPage * num3, 1];
              }
              else
              {
                num95 = this.crm[0, index51, index50 + this.defPage * num3, 0];
                index52 = this.crm[0, index51, index50 + this.defPage * num3, 1];
              }
              Color color = Color.White;
              Color colMod = Color.White;
              str2: String = "";
              int nr9 = -1;
              switch (num95)
              {
                case 1:
                  color = this.GetUnitColor(index52);
                  color = Color.FromArgb((int) byte.MaxValue, 100, 100, 100);
                  break;
                case 2:
                  color = this.GetUnitColor(index52);
                  color = Color.FromArgb((int) byte.MaxValue, 100, 100, 100);
                  break;
                default:
                  if (num95 == 3 | num95 == 4)
                  {
                    index43 = this.game.TempCombat.FindISlot(index52);
                    colMod = Color.White;
                    if (this.game.TempCombat.IList[index43].ICapitulate)
                    {
                      color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 200, 200);
                      colMod = Color.White;
                      str2 = "capitulated";
                      nr9 = this.game.SE1_COMBAT_SURRENDER;
                    }
                    else if (this.game.TempCombat.IList[index43].IKilled > 0)
                    {
                      color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 200, 200);
                      colMod = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
                      str2 = "dead";
                      nr9 = this.game.SE1_COMBAT_DEAD;
                    }
                    else if (this.game.TempCombat.IList[index43].IRetreated == 0 & this.game.TempCombat.IList[index43].IRetreat > 0 & this.game.TempCombat.IList[index43].IRetreatMode == 1)
                    {
                      str2 = "forced retreat + in process of retreating";
                      nr9 = this.game.SE1_COMBAT_RETREATING;
                    }
                    else if (this.game.TempCombat.IList[index43].IRetreated == 0 & this.game.TempCombat.IList[index43].IRetreat > 0 & this.game.TempCombat.IList[index43].IRetreatMode == 3)
                    {
                      str2 = "panicked + in process of retreating";
                      nr9 = this.game.SE1_COMBAT_RETREATING;
                    }
                    else if (this.game.TempCombat.IList[index43].IRetreated == 0 & this.game.TempCombat.IList[index43].IRetreat > 0)
                    {
                      str2 = "orderly retreat - in process of retreating";
                      nr9 = this.game.SE1_COMBAT_RETREATING;
                    }
                    else if (this.game.TempCombat.IList[index43].IRetreated == 0 & this.game.TempCombat.IList[index43].IKilled == 0)
                      str2 = this.game.TempCombat.IList[index43].IBreakTrough <= 0 ? "fighting" : "fighting + broken through";
                    else if (this.game.TempCombat.IList[index43].IRetreated > 0)
                    {
                      if (this.game.TempCombat.IList[index43].IRetreatMode == 1 || this.game.TempCombat.IList[index43].IRetreatMode == 3)
                        ;
                      str2 = "safely retreated";
                      nr9 = this.game.SE1_COMBAT_RETREATED;
                    }
                    else
                    {
                      color = Color.White;
                      str2 = "fighting";
                    }
                    if (num95 == 4 && this.game.TempCombat.IList[index43].IunitFeatStart > 0 && this.game.TempCombat.IList[index43].IunitFeatDeadRound > 0)
                    {
                      color = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 200, 200);
                      colMod = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 0, 0);
                      str2 = "dead";
                      nr9 = this.game.SE1_COMBAT_DEAD;
                      break;
                    }
                    break;
                  }
                  if (num95 != 5)
                    break;
                  break;
              }
              int x13;
              int y11;
              if (num92 == 1)
              {
                x13 = rectangle1.X + num2 * index51 + num5;
                y11 = rectangle1.Y + num2 * index50 + num6;
              }
              else
              {
                x13 = rectangle2.X + num2 * index51 + num5;
                y11 = rectangle2.Y + num2 * index50 + num6;
              }
              switch (num95)
              {
                case 0:
                  ref Graphics local41 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK3, this.useZoom);
                  ref Bitmap local42 = ref bitmap;
                  int x14 = x13;
                  int y12 = y11;
                  DrawMod.DrawSimple(ref local41, ref local42, x14, y12);
                  break;
                case 1:
                  ref Graphics local43 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK1B, this.useZoom);
                  ref Bitmap local44 = ref bitmap;
                  int x15 = x13;
                  int y13 = y11;
                  double r7 = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
                  double g7 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
                  double b7 = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
                  double a1 = (double) ((float) color.A / (float) byte.MaxValue);
                  DrawMod.Draw(ref local43, ref local44, x15, y13, (float) r7, (float) g7, (float) b7, (float) a1);
                  ref Graphics local45 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK2B, this.useZoom);
                  ref Bitmap local46 = ref bitmap;
                  int x16 = x13;
                  int y14 = y11;
                  DrawMod.DrawSimple(ref local45, ref local46, x16, y14);
                  break;
                default:
                  if (num95 != 2 & num95 != 5)
                  {
                    color = Color.FromArgb((int) byte.MaxValue, (int) color.R + (int) Math.Round((double) ((int) byte.MaxValue - (int) color.R) * 0.66), (int) color.G + (int) Math.Round((double) ((int) byte.MaxValue - (int) color.G) * 0.66), (int) color.B + (int) Math.Round((double) ((int) byte.MaxValue - (int) color.B) * 0.66));
                    if (color.R == byte.MaxValue & color.G == byte.MaxValue & color.B == byte.MaxValue)
                    {
                      ref Graphics local47 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK1, this.useZoom);
                      ref Bitmap local48 = ref bitmap;
                      int x17 = x13;
                      int y15 = y11;
                      DrawMod.DrawSimple(ref local47, ref local48, x17, y15);
                    }
                    else
                    {
                      ref Graphics local49 = ref graphics;
                      bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK1, this.useZoom);
                      ref Bitmap local50 = ref bitmap;
                      int x18 = x13;
                      int y16 = y11;
                      double r8 = (double) ((float) color.R / (float) byte.MaxValue) - 1.0;
                      double g8 = (double) ((float) color.G / (float) byte.MaxValue) - 1.0;
                      double b8 = (double) ((float) color.B / (float) byte.MaxValue) - 1.0;
                      double a2 = (double) ((float) color.A / (float) byte.MaxValue);
                      DrawMod.Draw(ref local49, ref local50, x18, y16, (float) r8, (float) g8, (float) b8, (float) a2);
                    }
                    ref Graphics local51 = ref graphics;
                    bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBLOCK2, this.useZoom);
                    ref Bitmap local52 = ref bitmap;
                    int x19 = x13;
                    int y17 = y11;
                    DrawMod.DrawSimple(ref local51, ref local52, x19, y17);
                    break;
                  }
                  break;
              }
              if (num95 == 1)
              {
                bool mirror = this.game.Data.RegimeObj[this.game.Data.UnitObj[index52].Regime].Mirror;
                if (this.game.TempCombat.AttackerRegime == this.game.Data.UnitObj[index52].Regime)
                {
                  if (mirror)
                    this.game.Data.RegimeObj[this.game.Data.UnitObj[index52].Regime].Mirror = false;
                }
                else if (!mirror)
                  this.game.Data.RegimeObj[this.game.Data.UnitObj[index52].Regime].Mirror = true;
                if (this.useZoom == 1)
                  this.game.CustomBitmapObj.DrawUnitBig(index52, toG: graphics, tx: (x13 + num7), ty: (y11 + num8), FullRecon: true);
                if (this.useZoom == 0)
                  this.game.CustomBitmapObj.DrawUnit(index52, toG: graphics, tx: (x13 + num7), ty: (y11 + num8), FullRecon: true, ForceHideUnitMode: 0);
                this.game.Data.RegimeObj[this.game.Data.UnitObj[index52].Regime].Mirror = mirror;
                name: String = this.game.Data.UnitObj[index52].Name;
                ttext: String = "[ " + this.GetUnitDescription(index52) + " ]";
                trect2 = new Rectangle(x13, y11, num2 * 3, num2);
                trect11 = trect2;
                this.AddMouse(ref trect11, name, ttext);
              }
              SizeF sizeF2;
              if (num95 == 2)
              {
                if (this.useZoom == 1)
                {
                  str3: String = this.game.Data.UnitObj[index52].Name;
                  if (this.game.Data.UnitObj[index52].Regime != this.game.Data.Turn && (double) this.game.Data.MapObj[0].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].MaxRecon < (double) this.game.Data.RuleVar[55])
                    str3 = "Unknown Unit";
                  sizeF2 = graphics.MeasureString(str3, this.game.MarcFont4, num2 * 2 - num7);
                  index43 = (int) Math.Round(((double) (int) Math.Round((double) num2 * 0.2) + (double) sizeF2.Height) / 2.0);
                  unitDescription: String = this.GetUnitDescription(index52);
                  if (unitDescription.Length < 2)
                    index43 = (int) Math.Round((double) (sizeF2.Height / 2f));
                  DrawMod.DrawTextColouredConsoleMultiline(ref graphics, str3, this.game.MarcFont4, x13 + num7, y11 - index43 + (int) Math.Round((double) num2 * 0.5), Color.LightGray, num2 * 2 - num7, num2);
                  DrawMod.DrawTextColouredMarc(ref graphics, unitDescription, this.game.MarcFont16, x13 + num7, (int) Math.Round((double) ((float) (y11 - index43 + (int) Math.Round((double) num2 * 0.5)) + sizeF2.Height)), Color.White);
                }
                if (this.useZoom == 0)
                {
                  lower: String = this.GetUnitDescription(index52).ToLower();
                  DrawMod.DrawTextColouredMarc(ref graphics, lower, this.game.MarcFont16, x13 + num7, y11 + (int) Math.Round((double) num2 * 0.5) - 9, Color.LightGray);
                }
              }
              if (num95 == 3)
              {
                str4: String = "";
                index43 = this.game.TempCombat.FindISlot(index52);
                if (!Information.IsNothing((object) this.game.TempCombat.IList[index43].IunitFeat))
                {
                  int counter12 = this.game.TempCombat.IList[index43].IunitFeat.Counter;
                  for (int index53 = 0; index53 <= counter12; index53 += 1)
                  {
                    if (index53 <= 1)
                    {
                      int idValue = this.game.TempCombat.IList[index43].IunitFeat.Id[index53];
                      if (idValue > 0)
                      {
                        int islot = this.game.TempCombat.FindISlot(this.game.TempCombat.IList[index43].IunitFeat.Data1[index53]);
                        if (this.game.TempCombat.IList[islot].IunitFeatDeadRound < 1 & (this.game.TempCombat.IList[islot].IKilled < 1 | islot == index43))
                        {
                          int index54 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 10)));
                          str5: String = this.game.Data.StringListObj[this.slotUnitFeats].GetData(0, idValue, 2);
                          if (str4.Length > 0 & index53 < this.game.TempCombat.IList[index43].IunitFeat.Counter)
                            str5 = ", " + str5;
                          if (str4.Length > 0 & index53 == this.game.TempCombat.IList[index43].IunitFeat.Counter)
                            str5 = " and " + str5;
                          str4 += str5;
                          int nr10 = this.game.Data.EventPicNr[index54];
                          int num96;
                          int num97;
                          int num98;
                          int num99;
                          if (this.useZoom == 1 & index53 == 0)
                          {
                            num96 = 2;
                            num97 = 2;
                            num98 = 40;
                            num99 = 40;
                          }
                          if (this.useZoom == 1 & index53 == 1)
                          {
                            num96 = 44;
                            num97 = 2;
                            num98 = 40;
                            num99 = 40;
                          }
                          if (this.useZoom == 0 & index53 == 0)
                          {
                            num96 = 0;
                            num97 = 0;
                            num98 = 20;
                            num99 = 20;
                          }
                          if (this.useZoom == 0 & index53 == 1)
                          {
                            num96 = 20;
                            num97 = 0;
                            num98 = 20;
                            num99 = 20;
                          }
                          BitmapStore.GetWidth(nr10);
                          BitmapStore.Getheight(nr10);
                          ref Graphics local53 = ref graphics;
                          bitmap = BitmapStore.GetBitmap(nr10);
                          ref Bitmap local54 = ref bitmap;
                          int x20 = x13 + num96;
                          int y18 = y11 + num97;
                          int w2 = num98;
                          int h = num99;
                          int width = BitmapStore.GetWidth(nr10);
                          int origh = BitmapStore.Getheight(nr10);
                          double r9 = (double) ((float) colMod.R / (float) byte.MaxValue);
                          double g9 = (double) ((float) colMod.G / (float) byte.MaxValue);
                          double b9 = (double) ((float) colMod.B / (float) byte.MaxValue);
                          double a3 = (double) ((float) colMod.A / (float) byte.MaxValue);
                          DrawMod.DrawScaledColorized2(ref local53, ref local54, x20, y18, w2, h, width, origh, (float) r9, (float) g9, (float) b9, (float) a3);
                        }
                      }
                    }
                  }
                }
                this.DrawIndividual(graphics, x13 + num7, y11 + num8, index52, num9, num10, true, colMod, num92 == 0);
                if (nr9 > -1)
                {
                  bool flag3 = num92 == 1;
                  int num100;
                  if (this.useZoom == 1)
                    num100 = 76;
                  if (this.useZoom == 0)
                    num100 = 38;
                  if (flag3)
                  {
                    Matrix matrix2 = Matrix::new();
                    matrix2.Scale(-1f, 1f);
                    matrix2.Translate((float) -(2 * (x13 + num7) + num100), 0.0f);
                    graphics.Transform = matrix2;
                  }
                  ref Graphics local55 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr9, this.useZoom);
                  ref Bitmap local56 = ref bitmap;
                  int x21 = x13 + num7;
                  int y19 = y11 + num8;
                  DrawMod.DrawSimple(ref local55, ref local56, x21, y19);
                  if (flag3)
                    graphics.ResetTransform();
                }
                int num101;
                if (this.useZoom == 1)
                {
                  if (this.game.TempCombat.IList[index43].ItotalKills > 0 & this.game.TempCombat.IList[index43].ItotalHits > 0)
                  {
                    str6: String = this.game.TempCombat.IList[index43].ItotalKills.ToString();
                    str7: String = "/";
                    str8: String = this.game.TempCombat.IList[index43].ItotalHits.ToString();
                    sizeF2 = graphics.MeasureString(str6, this.game.MarcFont4, 76);
                    int num102 = (int) Math.Round((double) (sizeF2.Width - 2f));
                    sizeF2 = graphics.MeasureString(str7, this.game.MarcFont4, 76);
                    int num103 = (int) Math.Round((double) (sizeF2.Width - 2f));
                    sizeF2 = graphics.MeasureString(str8, this.game.MarcFont4, 76);
                    int num104 = (int) Math.Round((double) (sizeF2.Width - 2f));
                    if (num92 == 0)
                      num101 = 72 - (num102 + num103 + num104);
                    if (num92 == 1)
                      num101 = 8;
                    DrawMod.DrawTextColouredMarc(ref graphics, str6, this.game.MarcFont4, x13 + num7 + num101, y11 + 6, Color.Red);
                    DrawMod.DrawTextColouredMarc(ref graphics, str7, this.game.MarcFont4, x13 + num7 + num101 + num102, y11 + 6, Color.LightGray);
                    DrawMod.DrawTextColouredMarc(ref graphics, str8, this.game.MarcFont4, x13 + num7 + num101 + num102 + num103, y11 + 6, Color.White);
                  }
                  else if (this.game.TempCombat.IList[index43].ItotalKills > 0)
                  {
                    str9: String = this.game.TempCombat.IList[index43].ItotalKills.ToString();
                    sizeF2 = graphics.MeasureString(str9, this.game.MarcFont4, 76);
                    int num105 = (int) Math.Round((double) (sizeF2.Width - 2f));
                    if (num92 == 0)
                      num101 = 72 - num105;
                    if (num92 == 1)
                      num101 = 8;
                    DrawMod.DrawTextColouredMarc(ref graphics, str9, this.game.MarcFont4, x13 + num7 + num101, y11 + 6, Color.Red);
                  }
                  else if (this.game.TempCombat.IList[index43].ItotalHits > 0)
                  {
                    str10: String = this.game.TempCombat.IList[index43].ItotalHits.ToString();
                    sizeF2 = graphics.MeasureString(str10, this.game.MarcFont4, 76);
                    int num106 = (int) Math.Round((double) (sizeF2.Width - 2f));
                    if (num92 == 0)
                      num101 = 72 - num106;
                    if (num92 == 1)
                      num101 = 8;
                    DrawMod.DrawTextColouredMarc(ref graphics, str10, this.game.MarcFont4, x13 + num7 + num101, y11 + 6, Color.White);
                  }
                }
                if (this.useZoom == 1 && this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].DepletingHitpointRule > 0)
                {
                  int w3 = (int) Math.Round((double) ((float) (this.game.TempCombat.IList[index43].IHp * 56) / (float) this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].HitPoints[0]));
                  DrawMod.DrawBlock(ref graphics, x13 + num7 + 7, y11 + 8, 58, 6, 0, 100, 100, 155);
                  DrawMod.DrawBlock(ref graphics, x13 + 1 + num7 + 7, y11 + 9, w3, 4, 0, (int) byte.MaxValue, (int) byte.MaxValue, 155);
                }
                if (!(this.game.TempCombat.IList[index43].IKilled > 0 & this.game.TempCombat.IList[index43].IKilled < this.game.TempCombat.CombatRound) & this.game.TempCombat.CombatRound > 0)
                {
                  if (this.animList.FindNr(this.game.TempCombat.IList[index43].IID) == -1 & this.game.TempCombat.IList[index43].IKilled == this.game.TempCombat.CombatRound & !this.game.TempCombat.IList[index43].ICapitulate)
                    this.animList.Add(this.game.TempCombat.IList[index43].IID, 0, x13 + num7, y11 + num8, num9, num10, 1);
                  else if (this.animList.FindNr(this.game.TempCombat.IList[index43].IID) == -1 & this.game.TempCombat.IList[index43].ILastHit == this.game.TempCombat.CombatRound & this.game.TempCombat.IList[index43].IKilled < 1)
                    this.animList.Add(this.game.TempCombat.IList[index43].IID, 15, x13 + num7, y11 + num8, num9, num10, 2);
                }
                ttitle: String = this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].Ratio.ToString() + "x " + this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].Name;
                str11: String = "";
                if (str2.Length > 0)
                  str11 = str11 + " [ " + str2.ToUpper() + " ]\r\n---------------\r\n";
                string ttext;
                if (this.game.TempCombat.IList[index43].IAttacker == 1)
                {
                  if (str4.Length > 0)
                    str11 = str11 + "Has embedded with them: " + str4 + ".\r\n" + "---------------" + "\r\n";
                  str12: String = str11;
                  index45 = (int) Math.Round((double) (this.game.TempCombat.IList[index43].ILisAmmoMod * 100f));
                  str13: String = index45.ToString();
                  str14: String = str12 + "Ammo modifier: \t" + str13 + "%\r\n";
                  index45 = (int) Math.Round((double) (this.game.TempCombat.IList[index43].ILisFuelMod * 100f));
                  str15: String = index45.ToString();
                  str16: String = str14 + "Fuel modifier: \t" + str15 + "%\r\n" + "---------------" + "\r\n" + "Readiness: \t" + this.game.TempCombat.IList[index43].IRdn.ToString() + " / " + this.game.TempCombat.IList[index43].IRdnInitial.ToString() + "\r\n" + "Morale: \t\t" + this.game.TempCombat.IList[index43].IMor.ToString() + " / " + this.game.TempCombat.IList[index43].IMorInitial.ToString() + "\r\n" + "Experience: \t" + this.game.TempCombat.IList[index43].IXp.ToString() + " / " + this.game.TempCombat.IList[index43].IXpInitial.ToString() + "\r\n" + "Entrenchment: \t" + this.game.TempCombat.IList[index43].IEntrench.ToString() + " / " + this.game.TempCombat.IList[index43].IEntrenchInitial.ToString() + "\r\n" + "Upkeep: \t\t" + this.game.Data.UnitObj[this.game.TempCombat.IList[index43].IUnr].SupplyConsume.ToString() + "\r\n" + "---------------\r\n";
                  if (this.game.TempCombat.IList[index43].IHp > 0)
                    str16 = str16 + "Shielding: \t" + this.game.TempCombat.IList[index43].IHp.ToString() + " / " + this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].HitPoints[0].ToString() + "\r\n" + "---------------\r\n";
                  str17: String = str16 + "Total Kills Scored: \t" + this.game.TempCombat.IList[index43].ItotalKills.ToString() + "\r\n" + "Total Hits Scored: \t" + this.game.TempCombat.IList[index43].ItotalHits.ToString() + "\r\n" + "---------------\r\n" + "Attacks done this Round: \t" + this.game.TempCombat.IList[index43].AttackCount.ToString() + "\r\n";
                  ttext = (this.game.TempCombat.IList[index43].ISuccesfullAttack != this.game.TempCombat.CombatRound ? str17 + "Hit placed this Round: \tNo\r\n" : str17 + "Hit placed this Round: \tYes\r\n") + "Been attacked this Round: \t" + this.game.TempCombat.IList[index43].AttackedCount.ToString() + "\r\n";
                  if (this.game.TempCombat.IList[index43].IRetreat > 0 & this.game.TempCombat.IList[index43].IKilled < 1)
                  {
                    str18: String = ttext + "---------------\r\n" + "Retreat started in Round: \t" + this.game.TempCombat.IList[index43].IRetreat.ToString() + "\r\n";
                    ttext = this.game.TempCombat.IList[index43].IRetreated <= 0 ? str18 + "Finished retreat: \t\tNot yet \r\n" : str18 + "Finished retreat: \t\tSafely retreated\r\n";
                  }
                }
                else
                {
                  if (str4.Length > 0)
                    str11 = str11 + "Has embedded with them: " + str4 + ".\r\n" + "---------------" + "\r\n";
                  str19: String = str11;
                  index45 = (int) Math.Round((double) (this.game.TempCombat.IList[index43].ILisAmmoMod * 100f));
                  str20: String = index45.ToString();
                  str21: String = str19 + "Ammo modifier: \t" + str20 + "%\r\n";
                  index45 = (int) Math.Round((double) (this.game.TempCombat.IList[index43].ILisFuelMod * 100f));
                  str22: String = index45.ToString();
                  str23: String = str21 + "Fuel modifier: \t" + str22 + "%\r\n" + "---------------" + "\r\n" + "Readiness: \t" + this.game.TempCombat.IList[index43].IRdn.ToString() + "\r\n" + "Morale: \t\t" + this.game.TempCombat.IList[index43].IMor.ToString() + "\r\n" + "Experience: \t" + this.game.TempCombat.IList[index43].IXp.ToString() + "\r\n" + "Entrenchment: \t" + this.game.TempCombat.IList[index43].IEntrench.ToString() + "\r\n" + "Upkeep: \t\t" + this.game.Data.UnitObj[this.game.TempCombat.IList[index43].IUnr].SupplyConsume.ToString() + "\r\n";
                  if (this.game.TempCombat.IList[index43].IHp > 0)
                    str23 = str23 + "Shielding: \t" + this.game.TempCombat.IList[index43].IHp.ToString() + " / " + this.game.Data.SFTypeObj[this.game.TempCombat.IList[index43].ISFType].HitPoints[0].ToString() + "\r\n" + "---------------\r\n";
                  str24: String = str23 + "---------------\r\n" + "Total Kills Scored: \t" + this.game.TempCombat.IList[index43].ItotalKills.ToString() + "\r\n" + "Total Hits Scored: \t" + this.game.TempCombat.IList[index43].ItotalHits.ToString() + "\r\n" + "---------------\r\n" + "Attacks done this Round: \t" + this.game.TempCombat.IList[index43].AttackCount.ToString() + "\r\n";
                  ttext = (this.game.TempCombat.IList[index43].ISuccesfullAttack != this.game.TempCombat.CombatRound ? str24 + "Hit placed this Round: \tNo\r\n" : str24 + "Hit placed this Round: \tYes\r\n") + "Been attacked this Round: \t" + this.game.TempCombat.IList[index43].AttackedCount.ToString() + "\r\n";
                  if (this.game.TempCombat.IList[index43].IRetreat > 0 & this.game.TempCombat.IList[index43].IKilled < 1)
                  {
                    str25: String = ttext + "---------------\r\n" + "Retreat started in Round: \t" + this.game.TempCombat.IList[index43].IRetreat.ToString() + "\r\n";
                    ttext = this.game.TempCombat.IList[index43].IRetreated <= 0 ? str25 + "Finished retreat: \t\tNot yet \r\n" : str25 + "Finished retreat: \t\tYes in Round " + this.game.TempCombat.IList[index43].IRetreated.ToString() + "\r\n";
                  }
                }
                trect2 = new Rectangle(x13, y11, num2, num2);
                trect11 = trect2;
                this.AddMouse(ref trect11, ttitle, ttext);
              }
              if (num95 == 4)
              {
                index43 = this.game.TempCombat.FindISlot(index52);
                int iunitFeatStart = this.game.TempCombat.IList[index43].IunitFeatStart;
                int index55 = (int) Math.Round(Conversion.Val(this.game.Data.StringListObj[this.slotUnitFeats].GetData(0, iunitFeatStart, 10)));
                data: String = this.game.Data.StringListObj[this.slotUnitFeats].GetData(0, iunitFeatStart, 2);
                ttext: String = this.game.Data.StringListObj[this.slotUnitFeats].GetData(0, iunitFeatStart, 12);
                int nr11 = this.game.Data.EventPicNr[index55];
                int num107;
                int num108;
                int num109;
                int num110;
                if (this.useZoom == 1)
                {
                  num107 = 0;
                  num108 = 0;
                  num109 = 80;
                  num110 = 80;
                }
                if (this.useZoom == 0)
                {
                  num107 = 0;
                  num108 = 0;
                  num109 = 40;
                  num110 = 40;
                }
                int num111 = BitmapStore.GetWidth(nr11);
                int num112 = BitmapStore.Getheight(nr11);
                if (this.useZoom == 0)
                {
                  num111 = (int) Math.Round((double) num111 / 2.0);
                  num112 = (int) Math.Round((double) num112 / 2.0);
                }
                if (this.useZoom == 1)
                {
                  ref Graphics local57 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr11);
                  ref Bitmap local58 = ref bitmap;
                  int x22 = x13 + num107 + (int) Math.Round((double) (num109 - num111) / 2.0);
                  int y20 = y11 + num108 + (int) Math.Round((double) (num110 - num112) * 0.0) - 12;
                  double r10 = (double) ((float) colMod.R / (float) byte.MaxValue) - 1.0;
                  double g10 = (double) ((float) colMod.G / (float) byte.MaxValue) - 1.0;
                  double b10 = (double) ((float) colMod.B / (float) byte.MaxValue) - 1.0;
                  double a4 = (double) ((float) colMod.A / (float) byte.MaxValue);
                  DrawMod.Draw(ref local57, ref local58, x22, y20, (float) r10, (float) g10, (float) b10, (float) a4);
                }
                else if (this.useZoom == 0)
                {
                  ref Graphics local59 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr11);
                  ref Bitmap local60 = ref bitmap;
                  int x23 = x13 + num107 + (int) Math.Round((double) (num109 - num111) / 2.0);
                  int y21 = y11 + num108 + (int) Math.Round((double) (num110 - num112) * 0.0) - 4;
                  int w4 = num109;
                  int h = num110;
                  double r11 = (double) ((float) colMod.R / (float) byte.MaxValue);
                  double g11 = (double) ((float) colMod.G / (float) byte.MaxValue);
                  double b11 = (double) ((float) colMod.B / (float) byte.MaxValue);
                  double a5 = (double) ((float) colMod.A / (float) byte.MaxValue);
                  DrawMod.DrawScaledColorized2(ref local59, ref local60, x23, y21, w4, h, 80, 80, (float) r11, (float) g11, (float) b11, (float) a5);
                }
                if (nr9 > -1)
                {
                  bool flag4 = num92 == 1;
                  if (this.useZoom == 1)
                    num109 = 76;
                  if (this.useZoom == 0)
                    num109 = 38;
                  if (flag4)
                  {
                    Matrix matrix3 = Matrix::new();
                    matrix3.Scale(-1f, 1f);
                    matrix3.Translate((float) -(2 * x13 + num109), 0.0f);
                    graphics.Transform = matrix3;
                  }
                  ref Graphics local61 = ref graphics;
                  bitmap = BitmapStore.GetBitmap(nr9, this.useZoom);
                  ref Bitmap local62 = ref bitmap;
                  int x24 = x13 + num7;
                  int y22 = y11 + num8;
                  DrawMod.DrawSimple(ref local61, ref local62, x24, y22);
                  if (flag4)
                    graphics.ResetTransform();
                }
                if (str2.Length > 0)
                  ttext = " [ " + str2.ToUpper() + " ]\r\n---------------\r\n" + ttext;
                trect2 = new Rectangle(x13, y11, num2, num2);
                trect11 = trect2;
                this.AddMouse(ref trect11, data, ttext);
              }
            }
          }
          num92 += 1;
        }
        while (num92 <= 1);
      }
      ref Graphics local63 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_COMBATBAR2);
      ref Bitmap local64 = ref bitmap;
      int x25 = rectangle5.X;
      int y23 = rectangle5.Y;
      DrawMod.DrawSimple(ref local63, ref local64, x25, y23);
      combatDescription: String = this.GetCombatDescription();
      if (Strings.InStr(combatDescription, "\r\n") > 0)
        DrawMod.DrawTextColouredConsoleMultiline(ref graphics, combatDescription, this.game.MarcFont2, rectangle5.X, rectangle5.Y + 13, Color.White, rectangle5.Width, rectangle5.Height, true);
      else
        DrawMod.DrawTextColouredConsoleMultiline(ref graphics, combatDescription, this.game.MarcFont2, rectangle5.X, rectangle5.Y + 30, Color.White, rectangle5.Width, rectangle5.Height, true);
      int x26 = rectangle5.X + rectangle5.Width + 13;
      int y24 = rectangle5.Y + 50;
      bool flag5 = false;
      if (x26 + BitmapStore.GetWidth(this.game.SE1_SIDEBARHEADER) > rectangle4.X)
      {
        x26 = rectangle4.X - BitmapStore.GetWidth(this.game.SE1_SIDEBARHEADER);
        y24 += 10;
        flag5 = true;
      }
      ref Graphics local65 = ref graphics;
      bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
      ref Bitmap local66 = ref bitmap;
      int x27 = x26;
      int y25 = y24;
      DrawMod.DrawSimple(ref local65, ref local66, x27, y25);
      int num113 = this.game.Data.MapObj[0].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].MaxRecon;
      if (num113 > (int) Math.Round((double) this.game.Data.RuleVar[56]))
        num113 = (int) Math.Round((double) this.game.Data.RuleVar[56]);
      str26: String = "Rec: " + num113.ToString();
      index45 = (int) Math.Round((double) this.game.Data.RuleVar[56]);
      str27: String = index45.ToString();
      tstring3: String = str26 + " / " + str27;
      DrawMod.DrawTextColouredConsoleCenter(ref graphics, tstring3, this.game.MarcFont4, x26 + 70, y24 + 11, Color.LightGray);
      ttitle1: String = "Recon on target Hex";
      index45 = (int) Math.Round((double) this.game.Data.RuleVar[56]);
      ttext1: String = "As long as you have less than " + index45.ToString() + " Recon Points on the Hex you are attacking you'll not be sure to spot all enemy sub formations.";
      trect2 = new Rectangle(x26, y24, 137, 39);
      trect11 = trect2;
      this.AddMouse(ref trect11, ttitle1, ttext1);
      if (this.showdetail < 1)
      {
        str28: String = "";
        if (this.game.TempCombat.BattleEnded > 0)
        {
          str29: String = this.game.EditObj.CombatOneSentence;
          if (this.game.EditObj.CombatOneSentenceCustom.Length > 0 & str29.Length > 0)
            str29 = str29 + "\r\n•" + this.game.EditObj.CombatOneSentenceCustom;
          else if (this.game.EditObj.CombatOneSentenceCustom.Length > 0)
            str29 = "• " + this.game.EditObj.CombatOneSentenceCustom;
          if (str29.Length > 1)
          {
            str30: String = str29.Replace(".", ".\r\n•");
            if (Operators.CompareString(Strings.Right(str30, 1), "•", false) == 0)
              str30 = Strings.Left(str30, Strings.Len(str30) - 2);
            if (Operators.CompareString(Strings.Right(str30, 2), "• ", false) == 0)
              str30 = Strings.Left(str30, Strings.Len(str30) - 3);
            str28 = str28 + str30 + "\r\n";
          }
          if (str28.Length > 1)
          {
            int num114 = 0;
            int length = str28.Length;
            for (int Start = 1; Start <= length; Start += 1)
            {
              if (Operators.CompareString(Strings.Mid(str28, Start, 1), ".", false) == 0)
                num114 += 1;
            }
            if (num114 < 1)
              num114 = 1;
            int x28 = rectangle5.X - 155;
            int y26 = 49;
            if (flag5)
            {
              x28 = rectangle3.X + rectangle3.Width - 6;
              y26 += 10;
            }
            ref Graphics local67 = ref graphics;
            bitmap = BitmapStore.GetBitmap(this.game.SE1_SIDEBARHEADER);
            ref Bitmap local68 = ref bitmap;
            int x29 = x28;
            int y27 = y26;
            DrawMod.DrawSimple(ref local67, ref local68, x29, y27);
            tstring4: String = num114.ToString() + " Message(s)";
            DrawMod.DrawTextColouredConsoleCenter(ref graphics, tstring4, this.game.MarcFont4, x28 + 70, y26 + 12, Color.White);
            ttitle2: String = "MESSAGES";
            trect2 = new Rectangle(x28, y26, 137, 39);
            trect11 = trect2;
            this.AddMouse(ref trect11, ttitle2, str28);
          }
        }
      }
      this.Hn = this.useHeight;
      if (this.useZoom == 1)
      {
        let mut tsubpart1: SubPartClass =  new TextButtonPartClass("ZOOM IN", 90, "Click to use big icons.", ref this.OwnBitmap, 50, this.Hn - 51, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.zoom1id = this.AddSubPart(ref tsubpart1, 50, this.Hn - 51, 90, 36, 0);
        let mut tsubpart2: SubPartClass =  new TextButtonPartClass("ZOOM OUT", 90, "Click to use small icons.", ref this.OwnBitmap, 150, this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.zoom0id = this.AddSubPart(ref tsubpart2, 150, this.Hn - 51, 90, 36, 1);
      }
      else
      {
        let mut tsubpart3: SubPartClass =  new TextButtonPartClass("ZOOM IN", 90, "Click to use big icons.", ref this.OwnBitmap, 50, this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.zoom1id = this.AddSubPart(ref tsubpart3, 50, this.Hn - 51, 90, 36, 1);
        let mut tsubpart4: SubPartClass =  new TextButtonPartClass("ZOOM OUT", 90, "Click to use small icons.", ref this.OwnBitmap, 150, this.Hn - 51, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.zoom0id = this.AddSubPart(ref tsubpart4, 150, this.Hn - 51, 90, 36, 0);
      }
      int num115 = 250;
      int num116;
      SubPartClass tsubpart5;
      if (this.game.TempCombat.BattleEnded > 0)
      {
        let mut tsubpart6: SubPartClass =  new TextButtonPartClass("OK", 200, "Click to return to main screen.\r\nOr press any key instead.", ref this.OwnBitmap, (int) Math.Round((double) this.useWidth / 2.0 - 104.0), this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.okid = this.AddSubPart(ref tsubpart6, (int) Math.Round((double) this.useWidth / 2.0 - 104.0), this.Hn - 51, 200, 36, 1);
        num116 = (int) Math.Round((double) this.useWidth / 2.0 - 104.0 + 200.0 + 10.0);
      }
      else
      {
        if (!this.playBattle & !this.game.EditObj.AutoCombat)
        {
          let mut tsubpart7: SubPartClass =  new TextButtonPartClass("NEXT ROUND", 150, "Click to initiate next Combat Round.\r\nOr press any key instead.", ref this.OwnBitmap, (int) Math.Round((double) this.useWidth / 2.0 - 154.0), this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.roundId = this.AddSubPart(ref tsubpart7, (int) Math.Round((double) this.useWidth / 2.0 - 154.0), this.Hn - 51, 150, 36, 1);
          tsubpart5 =  new TextButtonPartClass("AUTOPLAY", 150, "Click to initiate next Combat Round.\r\nOr press any key instead.", ref this.OwnBitmap, (int) Math.Round((double) this.useWidth / 2.0 - 4.0), this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          this.playId = this.AddSubPart(ref tsubpart5, (int) Math.Round((double) this.useWidth / 2.0 - 4.0), this.Hn - 51, 150, 36, 1);
        }
        num116 = (int) Math.Round((double) this.useWidth / 2.0 - 154.0 + 300.0 + 10.0);
      }
      tsubpart5 =  new TextButtonPartClass("DETAIL", 90, "Click to get deepest detail level.\r\nOr press any key instead.", ref this.OwnBitmap, this.useWidth - 146, this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
      this.detailid = this.AddSubPart(ref tsubpart5, this.useWidth - 146, this.Hn - 51, 90, 36, 1);
      if (this.showdetail <= 0)
      {
        tsubpart5 =  new TextButtonPartClass("TEXTUAL", 90, "Click to switch to a numerical combat overview.", ref this.OwnBitmap, this.useWidth - 256, this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.typeid = this.AddSubPart(ref tsubpart5, this.useWidth - 256, this.Hn - 51, 90, 36, 1);
      }
      else
      {
        tsubpart5 =  new TextButtonPartClass("GRAPHIC", 90, "Click to switch to a graphical combat overview.", ref this.OwnBitmap, this.useWidth - 256, this.Hn - 51, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
        this.typeid = this.AddSubPart(ref tsubpart5, this.useWidth - 256, this.Hn - 51, 90, 36, 1);
      }
      int index56;
      if (this.maxAttPage > 3)
      {
        int num117 = num115 + 30;
        int num118 = this.Hn - 51;
        if (this.attPage > 0)
        {
          int[] tabdown = this.tabdown;
          tsubpart5 =  new TextButtonPartClass("< ", 50, "Click to go back a page.", ref this.OwnBitmap, num117, num118, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num119 = this.AddSubPart(ref tsubpart5, num117, num118, 50, 36, 1);
          tabdown[1] = num119;
        }
        else
        {
          int[] tabdown = this.tabdown;
          tsubpart5 =  new TextButtonPartClass("< ", 50, "You are at the first page.", ref this.OwnBitmap, num117, num118, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num120 = this.AddSubPart(ref tsubpart5, num117, num118, 50, 36, 0);
          tabdown[1] = num120;
        }
        int num121 = num117 + 50;
        index56 = this.attPage + 1;
        str31: String = index56.ToString();
        index45 = this.maxAttPage + 1;
        str32: String = index45.ToString();
        tstring5: String = "Page " + str31 + " of " + str32;
        DrawMod.DrawTextColouredConsoleCenter(ref graphics, tstring5, this.game.MarcFont4, num121 + 75, num118 + 7, Color.LightGray);
        int num122 = num121 + 150;
        if (this.attPage < this.maxAttPage)
        {
          int[] tabup = this.tabup;
          tsubpart5 =  new TextButtonPartClass("> ", 50, "Click to go forward a page.", ref this.OwnBitmap, num122, num118, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num123 = this.AddSubPart(ref tsubpart5, num122, num118, 50, 36, 1);
          tabup[1] = num123;
        }
        else
        {
          int[] tabup = this.tabup;
          tsubpart5 =  new TextButtonPartClass("> ", 50, "You are at the last page.", ref this.OwnBitmap, num122, num118, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num124 = this.AddSubPart(ref tsubpart5, num122, num118, 50, 36, 0);
          tabup[1] = num124;
        }
      }
      else if (this.maxAttPage > 0)
      {
        int num125 = num115;
        int num126 = this.Hn - 51;
        int maxAttPage = this.maxAttPage;
        for (int index57 = 0; index57 <= maxAttPage; index57 += 1)
        {
          if (index57 < 9)
          {
            if (index57 != this.attPage)
            {
              int[,] tabid = this.tabid;
              int index58 = index57;
              index56 = index57 + 1;
              tsubpart5 =  new TextButtonPartClass("Pg " + index56.ToString(), 50, "Click to see this page.", ref this.OwnBitmap, num125, num126, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num127 = this.AddSubPart(ref tsubpart5, num125, num126, 50, 36, 1);
              tabid[1, index58] = num127;
            }
            else
            {
              int[,] tabid = this.tabid;
              int index59 = index57;
              index56 = index57 + 1;
              tsubpart5 =  new TextButtonPartClass("Pg " + index56.ToString(), 50, "This page is currently selected.", ref this.OwnBitmap, num125, num126, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num128 = this.AddSubPart(ref tsubpart5, num125, num126, 50, 36, 0);
              tabid[1, index59] = num128;
            }
            num125 += 50;
          }
        }
      }
      if (this.maxDefPage > 3)
      {
        int num129 = num116 + 30;
        int num130 = this.Hn - 51;
        if (this.defPage > 0)
        {
          int[] tabdown = this.tabdown;
          tsubpart5 =  new TextButtonPartClass("< ", 50, "Click to go back a page.", ref this.OwnBitmap, num129, num130, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num131 = this.AddSubPart(ref tsubpart5, num129, num130, 50, 36, 1);
          tabdown[0] = num131;
        }
        else
        {
          int[] tabdown = this.tabdown;
          tsubpart5 =  new TextButtonPartClass("< ", 50, "You are at the first page.", ref this.OwnBitmap, num129, num130, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num132 = this.AddSubPart(ref tsubpart5, num129, num130, 50, 36, 0);
          tabdown[0] = num132;
        }
        int num133 = num129 + 50;
        index45 = this.defPage + 1;
        str33: String = index45.ToString();
        index56 = this.maxDefPage + 1;
        str34: String = index56.ToString();
        tstring6: String = "Page " + str33 + " of " + str34;
        DrawMod.DrawTextColouredConsoleCenter(ref graphics, tstring6, this.game.MarcFont4, num133 + 75, num130 + 7, Color.LightGray);
        int num134 = num133 + 150;
        if (this.defPage < this.maxDefPage)
        {
          int[] tabup = this.tabup;
          tsubpart5 =  new TextButtonPartClass("> ", 50, "Click to go forward a page.", ref this.OwnBitmap, num134, num130, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num135 = this.AddSubPart(ref tsubpart5, num134, num130, 50, 36, 1);
          tabup[0] = num135;
        }
        else
        {
          int[] tabup = this.tabup;
          tsubpart5 =  new TextButtonPartClass("> ", 50, "You are at the last page.", ref this.OwnBitmap, num134, num130, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
          int num136 = this.AddSubPart(ref tsubpart5, num134, num130, 50, 36, 0);
          tabup[0] = num136;
        }
      }
      else if (this.maxDefPage > 0)
      {
        int num137 = num116;
        int num138 = this.Hn - 51;
        int maxDefPage = this.maxDefPage;
        for (int index60 = 0; index60 <= maxDefPage; index60 += 1)
        {
          if (index60 < 9)
          {
            if (index60 != this.defPage)
            {
              int[,] tabid = this.tabid;
              int index61 = index60;
              index56 = index60 + 1;
              tsubpart5 =  new TextButtonPartClass("Pg " + index56.ToString(), 50, "Click to see this page.", ref this.OwnBitmap, num137, num138, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num139 = this.AddSubPart(ref tsubpart5, num137, num138, 50, 36, 1);
              tabid[0, index61] = num139;
            }
            else
            {
              int[,] tabid = this.tabid;
              int index62 = index60;
              index56 = index60 + 1;
              tsubpart5 =  new TextButtonPartClass("Pg " + index56.ToString(), 50, "This page is currently selected.", ref this.OwnBitmap, num137, num138, true, theight: 36, usefont: this.game.MarcFont4, useshadow: true, tMarcStyle: true);
              int num140 = this.AddSubPart(ref tsubpart5, num137, num138, 50, 36, 0);
              tabid[0, index62] = num140;
            }
            num137 += 50;
          }
        }
      }
      object[,] objArray1 = new object[2, 100];
      object[,] objArray2 = new object[2, 100];
      int[,,] numArray19 = new int[2, 100, 9];
      object[,,,] objArray3 = new object[2, 100, 9, 3];
      int index63 = -1;
      int index64 = -1;
      int ucounter = this.game.TempCombat.UCounter;
      for (int index65 = 0; index65 <= ucounter; index65 += 1)
      {
        if (this.game.TempCombat.UList[index65].Uattacker == 1)
        {
          index63 += 1;
          objArray1[1, index63] = (object) this.game.TempCombat.UList[index65].UNr;
          objArray2[1, index63] = (object) index65;
          int unr = this.game.TempCombat.UList[index65].UNr;
          int index66 = 0;
          do
          {
            numArray19[1, index63, index66] = -1;
            index66 += 1;
          }
          while (index66 <= 7);
          int num141 = Math.Min(7, this.game.Data.UnitObj[unr].SFCount);
          for (int index67 = 0; index67 <= num141; index67 += 1)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[index67];
            numArray19[1, index63, index67] = sf;
          }
        }
        else
        {
          index64 += 1;
          objArray1[0, index64] = (object) this.game.TempCombat.UList[index65].UNr;
          objArray2[0, index64] = (object) index65;
          int unr = this.game.TempCombat.UList[index65].UNr;
          int index68 = 0;
          do
          {
            numArray19[0, index64, index68] = -1;
            index68 += 1;
          }
          while (index68 <= 7);
          int num142 = Math.Min(7, this.game.Data.UnitObj[unr].SFCount);
          for (int index69 = 0; index69 <= num142; index69 += 1)
          {
            int sf = this.game.Data.UnitObj[unr].SFList[index69];
            numArray19[0, index64, index69] = sf;
          }
        }
      }
      int icounter3 = this.game.TempCombat.ICounter;
      for (int index70 = 0; index70 <= icounter3; index70 += 1)
      {
        int num143 = !this.game.TempCombat.IList[index70].ICapitulate ? (!(this.game.TempCombat.IList[index70].IRetreated == 0 & this.game.TempCombat.IList[index70].IKilled == 0) ? (!((this.game.TempCombat.IList[index70].IRetreated > 0 | this.game.TempCombat.IList[index70].IRetreat > 0 & this.game.TempCombat.IList[index70].IRetreatMode != 2) & this.game.TempCombat.IList[index70].IKilled == 0) ? (this.game.TempCombat.IList[index70].IKilled <= 0 ? 1 : 2) : 1) : 0) : 2;
        int iattacker = this.game.TempCombat.IList[index70].IAttacker;
        if (iattacker == 0)
          index43 = index64;
        if (iattacker == 1)
          index43 = index63;
        int num144 = index43;
        for (int index71 = 0; index71 <= num144; index71 += 1)
        {
          if (Operators.ConditionalCompareObjectEqual(objArray1[iattacker, index71], (object) this.game.TempCombat.IList[index70].IUnr, false))
          {
            int index72 = 0;
            do
            {
              if (numArray19[iattacker, index71, index72] == this.game.TempCombat.IList[index70].ISFNr)
              {
                object[,,,] objArray4 = objArray3;
                object[,,,] objArray5 = objArray4;
                index56 = iattacker;
                int index73 = index56;
                index45 = index71;
                int index74 = index45;
                int index75 = index72;
                int index76 = index75;
                int index77 = num143;
                int index78 = index77;
                object obj = Operators.AddObject(objArray4[index56, index45, index75, index77], (object) 1);
                objArray5[index73, index74, index76, index78] = obj;
              }
              index72 += 1;
            }
            while (index72 <= 7);
          }
        }
      }
      int[,] numArray20 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[,] numArray21 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[,] numArray22 = new int[this.game.Data.SFTypeCounter + 1, 2];
      int[] numArray23 = new int[2];
      int[] numArray24 = new int[2];
      int[] numArray25 = new int[2];
      int[] numArray26 = new int[2];
      int[] numArray27 = new int[2];
      int[] numArray28 = new int[2];
      int[] numArray29 = new int[2];
      int[] numArray30 = new int[2];
      int[] numArray31 = new int[2];
      int num145 = 0;
      int num146 = 0;
      numArray23[0] = 0;
      numArray23[1] = 0;
      numArray24[0] = 0;
      numArray24[1] = 0;
      numArray25[0] = 0;
      numArray25[1] = 0;
      numArray26[0] = 0;
      numArray26[1] = 0;
      numArray27[0] = 0;
      numArray27[1] = 0;
      numArray28[0] = 0;
      numArray28[1] = 0;
      numArray29[0] = 0;
      numArray29[1] = 0;
      numArray30[0] = 0;
      numArray30[1] = 0;
      numArray30[0] = 0;
      this.StartRdn[0] = 0;
      this.StartXp[0] = 0;
      this.StartMor[0] = 0;
      this.StartEntr[0] = 0;
      numArray30[1] = 0;
      this.StartRdn[1] = 0;
      this.StartXp[1] = 0;
      this.StartMor[1] = 0;
      this.StartEntr[1] = 0;
      int num147 = 0;
      num56 = 0;
      int icounter4 = this.game.TempCombat.ICounter;
      for (int index79 = 0; index79 <= icounter4; index79 += 1)
      {
        int iattacker = this.game.TempCombat.IList[index79].IAttacker;
        int isfType = this.game.TempCombat.IList[index79].ISFType;
        int isfNr = this.game.TempCombat.IList[index79].ISFNr;
        bool flag6 = false;
        if ((double) this.game.Data.MapObj[0].HexObj[this.game.TempCombat.TargetX, this.game.TempCombat.TargetY].MaxRecon >= (double) this.game.TempCombat.IList[index79].IcoverPoints)
          flag6 = true;
        if (!this.game.Data.FOWOn)
          flag6 = true;
        if (iattacker == 1)
          flag6 = true;
        if (flag6)
        {
          int[] numArray32 = numArray31;
          int[] numArray33 = numArray32;
          int index80 = iattacker;
          int index81 = index80;
          int num148 = numArray32[index80] + 1;
          numArray33[index81] = num148;
          int[] numArray34 = numArray30;
          int[] numArray35 = numArray34;
          int index82 = iattacker;
          int index83 = index82;
          int num149 = numArray34[index82] + this.game.Data.SFTypeObj[isfType].PowerPts;
          numArray35[index83] = num149;
          int[] startRdn = this.StartRdn;
          int[] numArray36 = startRdn;
          int index84 = iattacker;
          int index85 = index84;
          int num150 = startRdn[index84] + this.game.Data.SFObj[isfNr].Rdn;
          numArray36[index85] = num150;
          int[] startXp = this.StartXp;
          int[] numArray37 = startXp;
          int index86 = iattacker;
          int index87 = index86;
          int num151 = startXp[index86] + this.game.Data.SFObj[isfNr].Xp;
          numArray37[index87] = num151;
          int[] startMor = this.StartMor;
          int[] numArray38 = startMor;
          int index88 = iattacker;
          int index89 = index88;
          int num152 = startMor[index88] + this.game.Data.SFObj[isfNr].Mor;
          numArray38[index89] = num152;
          int[] startEntr = this.StartEntr;
          int[] numArray39 = startEntr;
          int index90 = iattacker;
          int index91 = index90;
          int num153 = startEntr[index90] + this.game.Data.SFObj[isfNr].CurrentEntrench;
          numArray39[index91] = num153;
          if (iattacker == 1)
            num147 += 1;
          else
            num56 += 1;
          if (this.game.TempCombat.IList[index79].IKilled > 0)
          {
            int[,] numArray40 = numArray20;
            int[,] numArray41 = numArray40;
            int index92 = isfType;
            int index93 = index92;
            int index94 = iattacker;
            int index95 = index94;
            int num154 = numArray40[index92, index94] + 1;
            numArray41[index93, index95] = num154;
            int[] numArray42 = numArray27;
            int[] numArray43 = numArray42;
            int index96 = iattacker;
            int index97 = index96;
            int num155 = numArray42[index96] + this.game.Data.SFTypeObj[isfType].PowerPts;
            numArray43[index97] = num155;
          }
          else if (this.game.TempCombat.IList[index79].IRetreat > 0)
          {
            int[,] numArray44 = numArray21;
            int[,] numArray45 = numArray44;
            int index98 = isfType;
            int index99 = index98;
            int index100 = iattacker;
            int index101 = index100;
            int num156 = numArray44[index98, index100] + 1;
            numArray45[index99, index101] = num156;
            int[] numArray46 = numArray28;
            int[] numArray47 = numArray46;
            int index102 = iattacker;
            int index103 = index102;
            int num157 = numArray46[index102] + this.game.Data.SFTypeObj[isfType].PowerPts;
            numArray47[index103] = num157;
          }
          else
          {
            int[,] numArray48 = numArray22;
            int[,] numArray49 = numArray48;
            int index104 = isfType;
            int index105 = index104;
            int index106 = iattacker;
            int index107 = index106;
            int num158 = numArray48[index104, index106] + 1;
            numArray49[index105, index107] = num158;
            int[] numArray50 = numArray29;
            int[] numArray51 = numArray50;
            int index108 = iattacker;
            int index109 = index108;
            int num159 = numArray50[index108] + this.game.Data.SFTypeObj[isfType].PowerPts;
            numArray51[index109] = num159;
          }
          if (this.game.TempCombat.IList[index79].IKilled <= 0)
          {
            if (iattacker == 1)
              num145 += 1;
            else
              num146 += 1;
            int[] numArray52 = numArray23;
            int[] numArray53 = numArray52;
            int index110 = iattacker;
            int index111 = index110;
            int num160 = numArray52[index110] + this.game.TempCombat.IList[index79].IRdn;
            numArray53[index111] = num160;
            int[] numArray54 = numArray24;
            int[] numArray55 = numArray54;
            int index112 = iattacker;
            int index113 = index112;
            int num161 = numArray54[index112] + this.game.TempCombat.IList[index79].IXp;
            numArray55[index113] = num161;
            int[] numArray56 = numArray25;
            int[] numArray57 = numArray56;
            int index114 = iattacker;
            int index115 = index114;
            int num162 = numArray56[index114] + this.game.TempCombat.IList[index79].IMor;
            numArray57[index115] = num162;
            int[] numArray58 = numArray26;
            int[] numArray59 = numArray58;
            int index116 = iattacker;
            int index117 = index116;
            int num163 = numArray58[index116] + this.game.TempCombat.IList[index79].IEntrench;
            numArray59[index117] = num163;
          }
        }
      }
      if (num145 < 1)
        num145 = 1;
      if (num146 < 1)
        num146 = 1;
      if (this.game.TempCombat.CombatRound == 0)
      {
        if (num56 > 0)
        {
          this.StartRdn[0] = (int) Math.Round(Conversion.Int((double) this.StartRdn[0] / (double) num56));
          this.StartXp[0] = (int) Math.Round(Conversion.Int((double) this.StartXp[0] / (double) num56));
          this.StartMor[0] = (int) Math.Round(Conversion.Int((double) this.StartMor[0] / (double) num56));
          this.StartEntr[0] = (int) Math.Round(Conversion.Int((double) this.StartEntr[0] / (double) num56));
        }
        else
        {
          this.StartRdn[0] = -1;
          this.StartXp[0] = -1;
          this.StartMor[0] = -1;
          this.StartEntr[0] = -1;
        }
        this.StartRdn[1] = (int) Math.Round(Conversion.Int((double) this.StartRdn[1] / (double) num147));
        this.StartXp[1] = (int) Math.Round(Conversion.Int((double) this.StartXp[1] / (double) num147));
        this.StartMor[1] = (int) Math.Round(Conversion.Int((double) this.StartMor[1] / (double) num147));
        this.StartEntr[1] = (int) Math.Round(Conversion.Int((double) this.StartEntr[1] / (double) num147));
        int index118 = 0;
        do
        {
          this.game.EditObj.StartRdn[index118] = this.StartRdn[index118];
          this.game.EditObj.StartXp[index118] = this.StartXp[index118];
          this.game.EditObj.StartMor[index118] = this.StartMor[index118];
          this.game.EditObj.StartEntr[index118] = this.StartEntr[index118];
          index118 += 1;
        }
        while (index118 <= 1);
      }
      if (num146 > 0)
      {
        numArray23[0] = (int) Math.Round(Conversion.Int((double) numArray23[0] / (double) num146));
        numArray24[0] = (int) Math.Round(Conversion.Int((double) numArray24[0] / (double) num146));
        numArray25[0] = (int) Math.Round(Conversion.Int((double) numArray25[0] / (double) num146));
        numArray26[0] = (int) Math.Round(Conversion.Int((double) numArray26[0] / (double) num146));
      }
      else
      {
        numArray23[0] = -1;
        numArray24[0] = -1;
        numArray25[0] = -1;
        numArray26[0] = -1;
      }
      numArray23[1] = (int) Math.Round(Conversion.Int((double) numArray23[1] / (double) num145));
      numArray24[1] = (int) Math.Round(Conversion.Int((double) numArray24[1] / (double) num145));
      numArray25[1] = (int) Math.Round(Conversion.Int((double) numArray25[1] / (double) num145));
      numArray26[1] = (int) Math.Round(Conversion.Int((double) numArray26[1] / (double) num145));
      int index119 = 0;
      do
      {
        this.StartRdn[index119] = this.game.EditObj.StartRdn[index119];
        this.StartXp[index119] = this.game.EditObj.StartXp[index119];
        this.StartMor[index119] = this.game.EditObj.StartMor[index119];
        this.StartEntr[index119] = this.game.EditObj.StartEntr[index119];
        index119 += 1;
      }
      while (index119 <= 1);
      if (this.showdetail == 1)
      {
        str35: String = "ATTACKER TOTALS\r\n";
        Expression1: String = "SUBFORMATIONTYPE";
        int Number1 = 35 - Strings.Len(Expression1);
        if (0 > Number1)
          Number1 = 0;
        str36: String = str35 + Expression1 + Strings.Space(Number1);
        Expression2: String = "INITIAL";
        int Number2 = 10 - Strings.Len(Expression2);
        if (0 > Number2)
          Number2 = 0;
        str37: String = str36 + Expression2 + Strings.Space(Number2);
        Expression3: String = "@FRONT";
        int Number3 = 9 - Strings.Len(Expression3);
        if (0 > Number3)
          Number3 = 0;
        str38: String = str37 + Expression3 + Strings.Space(Number3);
        Expression4: String = "DEAD";
        int Number4 = 7 - Strings.Len(Expression4);
        if (0 > Number4)
          Number4 = 0;
        str39: String = str38 + Expression4 + Strings.Space(Number4);
        Expression5: String = "RETREAT";
        int Number5 = 9 - Strings.Len(Expression5);
        if (0 > Number5)
          Number5 = 0;
        str40: String = str39 + Expression5 + Strings.Space(Number5);
        Expression6: String = "ALIVE";
        int Number6 = 6 - Strings.Len(Expression6);
        if (0 > Number6)
          Number6 = 0;
        str41: String = str40 + Expression6 + Strings.Space(Number6) + "\r\n";
        int sfTypeCounter1 = this.game.Data.SFTypeCounter;
        for (int index120 = 0; index120 <= sfTypeCounter1; index120 += 1)
        {
          int num164 = 1;
          if (this.game.Data.SFTypeObj[index120].Ratio > 0)
            num164 = this.game.Data.SFTypeObj[index120].Ratio;
          if (numArray22[index120, 1] > 0 | numArray20[index120, 1] > 0 | numArray21[index120, 1] > 0)
          {
            Expression7: String = this.game.Data.SFTypeObj[index120].Name;
            if (Strings.Len(Expression7) > 29)
              Expression7 = Strings.Left(str41, 29);
            int Number7 = 35 - Strings.Len(Expression7);
            if (0 > Number7)
              Number7 = 0;
            str42: String = str41 + Expression7 + Strings.Space(Number7);
            Expression8: String = Strings.Trim(Conversion.Str((object) (num164 * (numArray22[index120, 1] + numArray20[index120, 1] + numArray21[index120, 1]))));
            int Number8 = 10 - Strings.Len(Expression8);
            if (0 > Number8)
              Number8 = 0;
            str43: String = str42 + Expression8 + Strings.Space(Number8);
            Expression9: String = Strings.Trim(Conversion.Str((object) (num164 * numArray22[index120, 1])));
            int Number9 = 9 - Strings.Len(Expression9);
            if (0 > Number9)
              Number9 = 0;
            str44: String = str43 + Expression9 + Strings.Space(Number9);
            Expression10: String = Strings.Trim(Conversion.Str((object) (num164 * numArray20[index120, 1])));
            int Number10 = 7 - Strings.Len(Expression10);
            if (0 > Number10)
              Number10 = 0;
            str45: String = str44 + Expression10 + Strings.Space(Number10);
            Expression11: String = Strings.Trim(Conversion.Str((object) (num164 * numArray21[index120, 1])));
            int Number11 = 9 - Strings.Len(Expression11);
            if (0 > Number11)
              Number11 = 0;
            str46: String = str45 + Expression11 + Strings.Space(Number11);
            Expression12: String = Strings.Trim(Conversion.Str((object) (num164 * (numArray21[index120, 1] + numArray22[index120, 1]))));
            int Number12 = 6 - Strings.Len(Expression12);
            if (0 > Number12)
              Number12 = 0;
            str41 = str46 + Expression12 + Strings.Space(Number12) + "\r\n";
          }
        }
        if (numArray31[0] > 0)
        {
          str47: String = str41 + "\r\n" + "DEFENDERS TOTALS\r\n";
          Expression13: String = "SUBFORMATIONTYPE";
          int Number13 = 35 - Strings.Len(Expression13);
          if (0 > Number13)
            Number13 = 0;
          str48: String = str47 + Expression13 + Strings.Space(Number13);
          Expression14: String = "INITIAL";
          int Number14 = 10 - Strings.Len(Expression14);
          if (0 > Number14)
            Number14 = 0;
          str49: String = str48 + Expression14 + Strings.Space(Number14);
          Expression15: String = "@FRONT";
          int Number15 = 9 - Strings.Len(Expression15);
          if (0 > Number15)
            Number15 = 0;
          str50: String = str49 + Expression15 + Strings.Space(Number15);
          Expression16: String = "DEAD";
          int Number16 = 7 - Strings.Len(Expression16);
          if (0 > Number16)
            Number16 = 0;
          str51: String = str50 + Expression16 + Strings.Space(Number16);
          Expression17: String = "RETREAT";
          int Number17 = 9 - Strings.Len(Expression17);
          if (0 > Number17)
            Number17 = 0;
          str52: String = str51 + Expression17 + Strings.Space(Number17);
          Expression18: String = "ALIVE";
          int Number18 = 6 - Strings.Len(Expression18);
          if (0 > Number18)
            Number18 = 0;
          str41 = str52 + Expression18 + Strings.Space(Number18) + "\r\n";
        }
        int sfTypeCounter2 = this.game.Data.SFTypeCounter;
        for (int index121 = 0; index121 <= sfTypeCounter2; index121 += 1)
        {
          int num165 = 1;
          if (this.game.Data.SFTypeObj[index121].Ratio > 0)
            num165 = this.game.Data.SFTypeObj[index121].Ratio;
          if (numArray22[index121, 0] > 0 | numArray20[index121, 0] > 0 | numArray21[index121, 0] > 0)
          {
            Expression19: String = this.game.Data.SFTypeObj[index121].Name;
            if (Strings.Len(Expression19) > 29)
              Expression19 = Strings.Left(str41, 29);
            int Number19 = 35 - Strings.Len(Expression19);
            if (0 > Number19)
              Number19 = 0;
            str53: String = str41 + Expression19 + Strings.Space(Number19);
            Expression20: String = Strings.Trim(Conversion.Str((object) (num165 * (numArray22[index121, 0] + numArray20[index121, 0] + numArray21[index121, 0]))));
            int Number20 = 10 - Strings.Len(Expression20);
            if (0 > Number20)
              Number20 = 0;
            str54: String = str53 + Expression20 + Strings.Space(Number20);
            Expression21: String = Strings.Trim(Conversion.Str((object) (num165 * numArray22[index121, 0])));
            int Number21 = 9 - Strings.Len(Expression21);
            if (0 > Number21)
              Number21 = 0;
            str55: String = str54 + Expression21 + Strings.Space(Number21);
            Expression22: String = Strings.Trim(Conversion.Str((object) (num165 * numArray20[index121, 0])));
            int Number22 = 7 - Strings.Len(Expression22);
            if (0 > Number22)
              Number22 = 0;
            str56: String = str55 + Expression22 + Strings.Space(Number22);
            Expression23: String = Strings.Trim(Conversion.Str((object) (num165 * numArray21[index121, 0])));
            int Number23 = 9 - Strings.Len(Expression23);
            if (0 > Number23)
              Number23 = 0;
            str57: String = str56 + Expression23 + Strings.Space(Number23);
            Expression24: String = Strings.Trim(Conversion.Str((object) (num165 * (numArray21[index121, 0] + numArray22[index121, 0]))));
            int Number24 = 6 - Strings.Len(Expression24);
            if (0 > Number24)
              Number24 = 0;
            str41 = str57 + Expression24 + Strings.Space(Number24) + "\r\n";
          }
        }
        str58: String = str41 + "\r\n";
        Expression25: String = "ATTACKER";
        int Number25 = 10 - Strings.Len(Expression25);
        if (0 > Number25)
          Number25 = 0;
        str59: String = str58 + Strings.Space(20) + Expression25 + Strings.Space(Number25);
        Expression26: String = "DEFENDER";
        int num166 = 10 - Strings.Len(Expression26);
        if (0 > num166)
          num166 = 0;
        str60: String = str59 + Strings.Space(20) + Expression26 + Strings.Space(num166 + 50) + "\r\n";
        Expression27: String = "STAT";
        int Number26 = 20 - Strings.Len(Expression27);
        if (0 > Number26)
          Number26 = 0;
        str61: String = str60 + Expression27 + Strings.Space(Number26);
        Expression28: String = "INITIAL";
        int Number27 = 10 - Strings.Len(Expression28);
        if (0 > Number27)
          Number27 = 0;
        str62: String = str61 + Expression28 + Strings.Space(Number27);
        Expression29: String = "CURRENT";
        int Number28 = 20 - Strings.Len(Expression29);
        if (0 > Number28)
          Number28 = 0;
        str63: String = str62 + Expression29 + Strings.Space(Number28);
        Expression30: String = "INITIAL";
        int Number29 = 10 - Strings.Len(Expression30);
        if (0 > Number29)
          Number29 = 0;
        str64: String = str63 + Expression30 + Strings.Space(Number29);
        Expression31: String = "CURRENT";
        int Number30 = 10 - Strings.Len(Expression31);
        if (0 > Number30)
          Number30 = 0;
        str65: String = str64 + Expression31 + Strings.Space(Number30) + "\r\n";
        Expression32: String = "Readiness";
        if (Strings.Len(Expression32) > 29)
          Expression32 = Strings.Left(str65, 29);
        int Number31 = 20 - Strings.Len(Expression32);
        if (0 > Number31)
          Number31 = 0;
        str66: String = str65 + Expression32 + Strings.Space(Number31);
        Expression33: String = Strings.Trim(Conversion.Str((object) this.StartRdn[1]));
        int Number32 = 10 - Strings.Len(Expression33);
        if (0 > Number32)
          Number32 = 0;
        str67: String = str66 + Expression33 + Strings.Space(Number32);
        Expression34: String = Strings.Trim(Conversion.Str((object) numArray23[1]));
        int Number33 = 20 - Strings.Len(Expression34);
        if (0 > Number33)
          Number33 = 0;
        str68: String = str67 + Expression34 + Strings.Space(Number33);
        str69: String = Strings.Trim(Conversion.Str((object) this.StartRdn[0]));
        if (numArray31[0] < 1)
          str69 = "?";
        if (Operators.CompareString(str69, "-1", false) == 0)
          str69 = "?";
        int Number34 = 10 - Strings.Len(str69);
        if (0 > Number34)
          Number34 = 0;
        str70: String = str68 + str69 + Strings.Space(Number34);
        str71: String = Strings.Trim(Conversion.Str((object) numArray23[0]));
        if (numArray31[0] < 1)
          str71 = "?";
        if (Operators.CompareString(str71, "-1", false) == 0)
          str71 = "?";
        int Number35 = 10 - Strings.Len(str71);
        if (0 > Number35)
          Number35 = 0;
        str72: String = str70 + str71 + Strings.Space(Number35) + "\r\n";
        Expression35: String = "Experience";
        if (Strings.Len(Expression35) > 29)
          Expression35 = Strings.Left(str72, 29);
        int Number36 = 20 - Strings.Len(Expression35);
        if (0 > Number36)
          Number36 = 0;
        str73: String = str72 + Expression35 + Strings.Space(Number36);
        Expression36: String = Strings.Trim(Conversion.Str((object) this.StartXp[1]));
        int Number37 = 10 - Strings.Len(Expression36);
        if (0 > Number37)
          Number37 = 0;
        str74: String = str73 + Expression36 + Strings.Space(Number37);
        Expression37: String = Strings.Trim(Conversion.Str((object) numArray24[1]));
        int Number38 = 20 - Strings.Len(Expression37);
        if (0 > Number38)
          Number38 = 0;
        str75: String = str74 + Expression37 + Strings.Space(Number38);
        str76: String = Strings.Trim(Conversion.Str((object) this.StartXp[0]));
        if (numArray31[0] < 1)
          str76 = "?";
        if (Operators.CompareString(str76, "-1", false) == 0)
          str76 = "?";
        int Number39 = 10 - Strings.Len(str76);
        if (0 > Number39)
          Number39 = 0;
        str77: String = str75 + str76 + Strings.Space(Number39);
        str78: String = Strings.Trim(Conversion.Str((object) numArray24[0]));
        if (numArray31[0] < 1)
          str78 = "?";
        if (Operators.CompareString(str78, "-1", false) == 0)
          str78 = "?";
        int Number40 = 10 - Strings.Len(str78);
        if (0 > Number40)
          Number40 = 0;
        str79: String = str77 + str78 + Strings.Space(Number40) + "\r\n";
        Expression38: String = "Morale";
        if (Strings.Len(Expression38) > 29)
          Expression38 = Strings.Left(str79, 29);
        int Number41 = 20 - Strings.Len(Expression38);
        if (0 > Number41)
          Number41 = 0;
        str80: String = str79 + Expression38 + Strings.Space(Number41);
        Expression39: String = Strings.Trim(Conversion.Str((object) this.StartMor[1]));
        int Number42 = 10 - Strings.Len(Expression39);
        if (0 > Number42)
          Number42 = 0;
        str81: String = str80 + Expression39 + Strings.Space(Number42);
        Expression40: String = Strings.Trim(Conversion.Str((object) numArray25[1]));
        int Number43 = 20 - Strings.Len(Expression40);
        if (0 > Number43)
          Number43 = 0;
        str82: String = str81 + Expression40 + Strings.Space(Number43);
        str83: String = Strings.Trim(Conversion.Str((object) this.StartMor[0]));
        if (numArray31[0] < 1)
          str83 = "?";
        if (Operators.CompareString(str83, "-1", false) == 0)
          str83 = "?";
        int Number44 = 10 - Strings.Len(str83);
        if (0 > Number44)
          Number44 = 0;
        str84: String = str82 + str83 + Strings.Space(Number44);
        str85: String = Strings.Trim(Conversion.Str((object) numArray25[0]));
        if (numArray31[0] < 1)
          str85 = "?";
        if (Operators.CompareString(str85, "-1", false) == 0)
          str85 = "?";
        int Number45 = 10 - Strings.Len(str85);
        if (0 > Number45)
          Number45 = 0;
        str86: String = str84 + str85 + Strings.Space(Number45) + "\r\n";
        Expression41: String = "Entrenchment";
        if (Strings.Len(Expression41) > 29)
          Expression41 = Strings.Left(str86, 29);
        int Number46 = 20 - Strings.Len(Expression41);
        if (0 > Number46)
          Number46 = 0;
        str87: String = str86 + Expression41 + Strings.Space(Number46);
        Expression42: String = Strings.Trim(Conversion.Str((object) this.StartEntr[1]));
        int Number47 = 10 - Strings.Len(Expression42);
        if (0 > Number47)
          Number47 = 0;
        str88: String = str87 + Expression42 + Strings.Space(Number47);
        Expression43: String = Strings.Trim(Conversion.Str((object) numArray26[1]));
        int Number48 = 20 - Strings.Len(Expression43);
        if (0 > Number48)
          Number48 = 0;
        str89: String = str88 + Expression43 + Strings.Space(Number48);
        str90: String = Strings.Trim(Conversion.Str((object) this.StartEntr[0]));
        if (numArray31[0] < 1)
          str90 = "?";
        if (Operators.CompareString(str90, "-1", false) == 0)
          str90 = "?";
        int Number49 = 10 - Strings.Len(str90);
        if (0 > Number49)
          Number49 = 0;
        str91: String = str89 + str90 + Strings.Space(Number49);
        str92: String = Strings.Trim(Conversion.Str((object) numArray26[0]));
        if (numArray31[0] < 1)
          str92 = "?";
        if (Operators.CompareString(str92, "-1", false) == 0)
          str92 = "?";
        int Number50 = 10 - Strings.Len(str92);
        if (0 > Number50)
          Number50 = 0;
        str93: String = str91 + str92 + Strings.Space(Number50) + "\r\n" + "\r\n";
        if (this.game.TempCombat.BattleEnded > 0)
        {
          str94: String = this.game.EditObj.CombatOneSentence;
          if (this.game.EditObj.CombatOneSentenceCustom.Length > 0 & str94.Length > 0)
            str94 = str94 + "\r\n•" + this.game.EditObj.CombatOneSentenceCustom;
          else if (this.game.EditObj.CombatOneSentenceCustom.Length > 0)
            str94 = "•" + this.game.EditObj.CombatOneSentenceCustom;
          if (str94.Length > 1)
          {
            str95: String = str94.Replace(".", ".\r\n•");
            if (Operators.CompareString(Strings.Right(str95, 1), "•", false) == 0)
              str95 = Strings.Left(str95, Strings.Len(str95) - 2);
            str93 = str93 + str95 + "\r\n";
          }
        }
        int num167 = 18;
        int num168 = rectangle1.X + num167;
        int num169 = rectangle1.Y + 12 + num167;
        int num170 = rectangle2.X - rectangle1.X + rectangle2.Width - num167 * 2 + 16;
        int num171 = rectangle1.Height - num167 * 2 - 10;
        string tTexty;
        if (this.game.ScreenHeight <= 900)
          tTexty = "[element][type]text[/type][pos]50,50," + (num170 - 100).ToString() + "," + (num171 - 50).ToString() + ",1[/pos][fontname]LMmonoCaps-Regular.ttf[/fontname][fontsize]16[/fontsize][fontstyle]0[/fontstyle][lineheight]18[/lineheight][text]" + str93 + "[/text][color]0,0,0,255][/color][/element]";
        else
          tTexty = "[element][type]text[/type][pos]50,50," + (num170 - 100).ToString() + "," + (num171 - 50).ToString() + ",1[/pos][fontname]LMmonoCaps-Regular.ttf[/fontname][fontsize]20[/fontsize][fontstyle]0[/fontstyle][lineheight]26[/lineheight][text]" + str93 + "[/text][color]0,0,0,255][/color][/element]";
        tsubpart5 =  new UDSPartClass(this.game, num170, num171, tTexty, ref this.OwnBitmap, num168, num169, tAllGray: true);
        this.resolveId = this.AddSubPart(ref tsubpart5, num168, num169, num170, num171, 1);
      }
      graphics.Dispose();
      graphics = (Graphics) null;
      if (!Information.IsNothing((object) this.bufferBitmap))
      {
        this.bufferBitmap.Dispose();
        this.bufferBitmap = (Bitmap) null;
      }
      this.bufferBitmap = (Bitmap) this.OwnBitmap.Clone();
    }

    pub void DrawBlockies(
      int qty1,
      int qty2,
      Color col1,
      Color col2,
      Graphics g,
      int x,
      int y)
    {
      if (this.game.EditObj.CombatNumbers)
      {
        SizeF sizeF1 = SizeF::new();
        int num1 = 0;
        int num2;
        if (qty1 > 0)
        {
          text: String = Strings.Trim(Conversion.Str((object) qty1));
          SizeF sizeF2 = g.MeasureString(text, this.game.MarcFont11);
          int num3;
          num2 = (int) Math.Round((double) ((float) num3 + sizeF2.Width));
        }
        if (qty2 > 0)
        {
          text: String = Strings.Trim(Conversion.Str((object) qty2));
          SizeF sizeF3 = g.MeasureString(text, this.game.MarcFont11);
          num2 = (int) Math.Round((double) ((float) num2 + sizeF3.Width));
        }
        int num4;
        if (num2 < 20)
          num4 = (int) Math.Round((double) (20 - num2) / 2.0);
        x += num4;
        SizeF sizeF4;
        if (qty1 > 0)
        {
          str: String = Strings.Trim(Conversion.Str((object) qty1));
          sizeF4 = g.MeasureString(str, this.game.MarcFont11);
          DrawMod.DrawTextColouredMarc(ref g, str, this.game.MarcFont11b, x - 1, y - 1, col1);
          DrawMod.DrawRectangle(ref g, x - 1, y - 1, (int) Math.Round((double) (sizeF4.Width + 1f)), (int) Math.Round((double) (sizeF4.Height + 0.0f)), (int) col1.R, (int) col1.G, (int) col1.B, (int) col1.A);
          num1 = (int) Math.Round((double) ((float) num1 + (2f + sizeF4.Width)));
        }
        if (qty2 <= 0)
          return;
        str1: String = Strings.Trim(Conversion.Str((object) qty2));
        sizeF4 = g.MeasureString(str1, this.game.MarcFont11);
        DrawMod.DrawTextColouredMarc(ref g, str1, this.game.MarcFont11b, x + num1 - 1, y - 1, col2);
        DrawMod.DrawRectangle(ref g, x + num1 - 1, y - 1, (int) Math.Round((double) (sizeF4.Width + 1f)), (int) Math.Round((double) (sizeF4.Height + 0.0f)), (int) col2.R, (int) col2.G, (int) col2.B, (int) col2.A);
      }
      else
      {
        int[] numArray1 = new int[100];
        int[] numArray2 = new int[100];
        int index1 = -1;
        if (qty1 >= 100)
          qty1 = 100;
        if (qty2 >= 100)
          qty2 = 100;
        while (qty1 > 0 | qty2 > 0)
        {
          if (qty1 >= 50)
          {
            index1 += 1;
            numArray1[index1] = 50;
            numArray2[index1] = 1;
            qty1 -= 50;
          }
          else if (qty2 >= 50)
          {
            index1 += 1;
            numArray1[index1] = 10;
            numArray2[index1] = 2;
            qty2 -= 10;
          }
          else if (qty1 >= 10)
          {
            index1 += 1;
            numArray1[index1] = 10;
            numArray2[index1] = 1;
            qty1 -= 10;
          }
          else if (qty2 >= 10)
          {
            index1 += 1;
            numArray1[index1] = 10;
            numArray2[index1] = 2;
            qty2 -= 10;
          }
          else if (qty1 >= 5 & qty2 >= 5)
          {
            index1 += 1;
            numArray1[index1] = 10;
            numArray2[index1] = 3;
            qty1 -= 5;
            qty2 -= 5;
          }
          else if (qty1 >= 1)
          {
            index1 += 1;
            numArray1[index1] = 1;
            numArray2[index1] = 1;
            --qty1;
          }
          else if (qty2 >= 1)
          {
            index1 += 1;
            numArray1[index1] = 1;
            numArray2[index1] = 2;
            --qty2;
          }
        }
        int num5 = 0;
        int num6 = 0;
        int num7 = 0;
        int num8 = -1;
        int num9 = 0;
        int num10 = 0;
        do
        {
          int num11 = index1;
          for (int index2 = 0; index2 <= num11; index2 += 1)
          {
            if (numArray1[index2] == 50 & num10 == 0 | numArray1[index2] == 10 & num10 == 1 | numArray1[index2] == 1 & num10 == 2)
            {
              if (numArray1[index2] == 50)
              {
                if (numArray2[index2] == 1)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 5, 4, (int) col1.R, (int) col1.G, (int) col1.B, (int) col1.A);
                if (numArray2[index2] == 2)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 5, 4, (int) col2.R, (int) col2.G, (int) col2.B, (int) col2.A);
                num5 += 6;
                num7 = num6 + 5;
              }
              if (numArray1[index2] == 10)
              {
                if (numArray2[index2] == 1)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 2, 4, (int) col1.R, (int) col1.G, (int) col1.B, (int) col1.A);
                if (numArray2[index2] == 2)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 2, 4, (int) col2.R, (int) col2.G, (int) col2.B, (int) col2.A);
                if (numArray2[index2] == 3)
                {
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 1, 4, (int) col1.R, (int) col1.G, (int) col1.B, (int) col1.A);
                  DrawMod.DrawBlock(ref g, x + num5 + 1, y + num6, 1, 4, (int) col2.R, (int) col2.G, (int) col2.B, (int) col2.A);
                }
                num5 += 3;
                num7 = num6 + 5;
              }
              if (numArray1[index2] == 1)
              {
                if (num6 == 0 & num9 == 0 & num5 > 0)
                {
                  num6 = num7;
                  num5 = 0;
                }
                num9 += 1;
                if (numArray2[index2] == 1)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 2, 2, (int) col1.R, (int) col1.G, (int) col1.B, (int) col1.A);
                if (numArray2[index2] == 2)
                  DrawMod.DrawBlock(ref g, x + num5, y + num6, 2, 2, (int) col2.R, (int) col2.G, (int) col2.B, (int) col2.A);
                if (num8 == -1)
                  num8 = num5;
                num5 += 3;
                num7 = num6 + 3;
              }
              if (num5 > 15)
              {
                num5 = 0;
                num6 = num7;
                if (num8 != -1)
                  num5 = num8;
              }
            }
          }
          num10 += 1;
        }
        while (num10 <= 2);
      }
    }

    pub int GetSfNrBitmap(int sfnr, int att)
    {
      int type = this.game.Data.SFObj[sfnr].Type;
      int symbolSprite2Id = this.game.Data.SFTypeObj[type].SymbolSprite2ID;
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
          for (int index2 = 0; index2 <= extraCounter; index2 += 1)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index2] == this.game.Data.RegimeObj[index1].ExtraGraphicUse)
              symbolSprite2Id = this.game.Data.SFTypeObj[type].ExtraSymbolSprite2ID[index2];
          }
        }
        else if (this.game.Data.PeopleObj[this.game.Data.SFObj[sfnr].People].ExtraGraphicUse > -1)
        {
          int extraCounter = this.game.Data.SFTypeObj[type].ExtraCounter;
          for (int index3 = 0; index3 <= extraCounter; index3 += 1)
          {
            if (this.game.Data.SFTypeObj[type].ExtraCode[index3] == this.game.Data.PeopleObj[this.game.Data.SFObj[sfnr].People].ExtraGraphicUse)
              symbolSprite2Id = this.game.Data.SFTypeObj[type].ExtraSymbolSprite2ID[index3];
          }
        }
      }
      return symbolSprite2Id;
    }

    pub HandleKeyup: WindowReturnClass(int nr)
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      try
      {
        if (nr == 27 | nr == 32)
        {
          if (nr > 0 & this.okid > 0)
          {
            this.ForwardKey = false;
            windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.okid)] + 1, this.SubPartY[this.SubpartNr(this.okid)] + 1, 1);
            windowReturnClass.SetFlag(true);
          }
          if (this.game.TempCombat.BattleEnded > 0)
          {
            if (!this.ForwardKey)
            {
              this.game.EditObj.TempCoordList.DeActivate();
              this.game.EditObj.CombatOneSentence = "";
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.TargetX = -1;
              this.game.EditObj.TargetY = -1;
              this.game.EditObj.OrderBombMode = 0;
              windowReturnClass.AddCommand(3, 11);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
          else
          {
            if (nr == 32 & this.roundId > 0)
            {
              this.ForwardKey = false;
              windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.roundId)] + 1, this.SubPartY[this.SubpartNr(this.roundId)] + 1, 1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
            if (nr == 27 & this.playId > 0)
            {
              this.ForwardKey = false;
              windowReturnClass = this.HandleMouseClick(this.SubPartX[this.SubpartNr(this.playId)] + 1, this.SubPartY[this.SubpartNr(this.playId)] + 1, 1);
              windowReturnClass.SetFlag(true);
              return windowReturnClass;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      return windowReturnClass;
    }

    pub HandleMouseClick: WindowReturnClass(int x, int y, int b)
    {
      windowReturnClass1: WindowReturnClass = WindowReturnClass::new();
      windowReturnClass2: WindowReturnClass = WindowReturnClass::new();
      if (this.SubPartCounter > -1)
      {
        int subPartCounter1 = this.SubPartCounter;
        for (int index1 = 0; index1 <= subPartCounter1; index1 += 1)
        {
          if (x > this.SubPartX[index1] & x < this.SubPartX[index1] + this.SubPartW[index1] && y > this.SubPartY[index1] & y < this.SubPartY[index1] + this.SubPartH[index1])
          {
            int maxAttPage = this.maxAttPage;
            for (int index2 = 0; index2 <= maxAttPage; index2 += 1)
            {
              if (this.tabid[1, index2] == this.SubPartID[index1])
              {
                this.attPage = index2;
                this.SubPartFlag[index1] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            int maxDefPage = this.maxDefPage;
            for (int index3 = 0; index3 <= maxDefPage; index3 += 1)
            {
              if (this.tabid[0, index3] == this.SubPartID[index1])
              {
                this.defPage = index3;
                this.SubPartFlag[index1] = true;
                this.dostuff();
                windowReturnClass1.SetFlag(true);
                return windowReturnClass1;
              }
            }
            if (this.SubPartID[index1] == this.tabup[0] & this.defPage < this.maxDefPage)
            {
              this += 1.defPage;
              this.SubPartFlag[index1] = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.SubPartID[index1] == this.tabup[1] & this.attPage < this.maxAttPage)
            {
              this += 1.attPage;
              this.SubPartFlag[index1] = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.SubPartID[index1] == this.tabdown[0] & this.defPage > 0)
            {
              --this.defPage;
              this.SubPartFlag[index1] = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (this.SubPartID[index1] == this.tabdown[1] & this.attPage > 0)
            {
              --this.attPage;
              this.SubPartFlag[index1] = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
        }
        int subPartCounter2 = this.SubPartCounter;
        for (int index = 0; index <= subPartCounter2; index += 1)
        {
          if (x > this.SubPartX[index] & x < this.SubPartX[index] + this.SubPartW[index] && y > this.SubPartY[index] & y < this.SubPartY[index] + this.SubPartH[index])
          {
            int num = this.SubPartID[index];
            if (num == this.typeid)
            {
              if (this.showdetail <= 0)
              {
                this.showdetail = 1;
                this.game.EditObj.CombatTextual = true;
              }
              else
              {
                this.showdetail = 0;
                this.game.EditObj.CombatTextual = false;
              }
              this.game.EditObj.PopupValue = 7;
              this.animList = SimpleList::new();
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.detailid)
            {
              this.game.EditObj.PopupValue = 8;
              this.bufferBitmap.Dispose();
              this.bufferBitmap = (Bitmap) null;
              windowReturnClass1.AddCommand(5, 14);
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.playId)
            {
              this.playBattle = true;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.roundId)
            {
              this.game.TempCombat.DoRound();
              this.dostuff();
              this.lasttime = DateAndTime.Now;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.zoom0id)
            {
              this.useZoom = 0;
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              this.crmSet = false;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.zoom1id)
            {
              this.useZoom = 1;
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              this.crmSet = false;
              this.dostuff();
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.resolveId)
            {
              this.SubPartList[index].Click(x - this.SubPartX[index], y - this.SubPartY[index]);
              this.SubPartFlag[index] = true;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
            if (num == this.okid)
            {
              Expression: WindowReturnClass = this.EndTheBattle();
              this.game.EditObj.TempCoordList.DeActivate();
              this.game.EditObj.CombatOneSentence = "";
              this.game.EditObj.OrderType = 0;
              this.game.EditObj.TargetX = -1;
              this.game.EditObj.TargetY = -1;
              SoundMod.STopEventWave();
              this.bufferBitmap.Dispose();
              this.bufferBitmap = (Bitmap) null;
              windowReturnClass1.AddCommand(6, 0);
              if (!Information.IsNothing((object) Expression))
                windowReturnClass1 = Expression;
              this.game.EditObj.se1_SelectAssetButton = -1;
              windowReturnClass1.SetFlag(true);
              return windowReturnClass1;
            }
          }
        }
        windowReturnClass1.SetFlag(false);
        return windowReturnClass1;
      }
      windowReturnClass1.SetFlag(false);
      return windowReturnClass1;
    }

    pub EndTheBattle: WindowReturnClass()
    {
      this.game.TempCombat.EndBattle();
      if (this.game.EditObj.DoCardSlot > -1)
      {
        windowReturnClass: WindowReturnClass;
        if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot > -1)
        {
          this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
          this.game.EditObj.AreaSlot = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaSlot;
          this.game.EditObj.AreaValue = this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].AreaValue;
          this.game.EditObj.PopupValue = 1;
          this.bufferBitmap.Dispose();
          this.bufferBitmap = (Bitmap) null;
          windowReturnClass.AddCommand(5, 10);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        if (this.game.Data.ActionCardObj[this.game.EditObj.DoCardSlot].UnitSelect)
        {
          this.game.ProcessingObj.PlayCardPreEvent(this.game.EditObj.DoCardSlot);
          this.game.EditObj.PopupValue = 3;
          this.bufferBitmap.Dispose();
          this.bufferBitmap = (Bitmap) null;
          windowReturnClass.AddCommand(5, 10);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
        int messCounter = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
        this.game.ProcessingObj.PlayCard(this.game.EditObj.DoCardSlot);
        if (Strings.Len(this.game.Data.LoadGame) > 0)
        {
          this.game.FormRef.Cursor = Cursors.WaitCursor;
          Form formRef =  this.game.FormRef;
          this.game.HandyFunctionsObj.LoadGameNow();
          this.game.FormRef = (Form1) formRef;
          this.game.FormRef.Cursor = Cursors.Default;
          this.bufferBitmap.Dispose();
          this.bufferBitmap = (Bitmap) null;
          windowReturnClass.AddCommand(3, 4);
          return windowReturnClass;
        }
        int Number = 0;
        int locCounter = this.game.Data.LocCounter;
        for (int locnr = 0; locnr <= locCounter; locnr += 1)
        {
          if (this.game.Data.MapObj[this.game.EditObj.MapSelected].HexObj[this.game.Data.LocObj[locnr].X, this.game.Data.LocObj[locnr].Y].Regime == this.game.Data.Turn)
          {
            int index = 0;
            do
            {
              if (this.game.Data.LocObj[locnr].Production[index] > -1 && !this.game.HandyFunctionsObj.CanProduceItem(locnr, this.game.Data.Turn, this.game.Data.LocObj[locnr].Production[index]).result)
              {
                Number += 1;
                this.game.Data.LocObj[locnr].Production[index] = -1;
                this.game.Data.LocObj[locnr].ProdPointRemainder[index] = 0;
                this.game.Data.LocObj[locnr].ProdPercent[index] = 0;
              }
              index += 1;
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
          this.bufferBitmap.Dispose();
          this.bufferBitmap = (Bitmap) null;
          this.game.EditObj.FromMessage = this.game.Data.RegimeObj[this.game.Data.Turn].MessCounter;
          windowReturnClass.AddCommand(5, 10);
          this.game.EditObj.MyDelegate = new EditClass.AfterPopUpRefresh(this.PopUpRefresh);
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      windowReturnClass1: WindowReturnClass;
      return windowReturnClass1;
    }

    pub handleTimer: WindowReturnClass()
    {
      windowReturnClass: WindowReturnClass = WindowReturnClass::new();
      if (!this.game.EditObj.CombatSim)
      {
        if (this.game.TempCombat.BattleEnded == 0 & (this.game.EditObj.AutoCombat | this.playBattle))
        {
          TimeSpan timeSpan = DateAndTime.Now.Subtract(this.lasttime);
          if (timeSpan.Milliseconds + timeSpan.Seconds * 1000 > 1000 | this.game.TempCombat.CombatRound == 0)
          {
            this.game.TempCombat.DoRound();
            this.animList = SimpleList::new();
            this.dostuff();
            this.lasttime = DateAndTime.Now;
            windowReturnClass.SetFlag(true);
            if (this.game.TempCombat.BattleEnded <= 0)
              ;
            return windowReturnClass;
          }
        }
        TimeSpan timeSpan1 = DateAndTime.Now.Subtract(this.lastAnimTime);
        if (timeSpan1.Milliseconds + timeSpan1.Seconds * 1000 > 100 & this.animList.Counter > -1)
        {
          for (int counter = this.animList.Counter; counter >= 0; counter += -1)
          {
            if (this.animList.Weight[counter] != -1)
            {
              if (this.animList.Weight[counter] <= 31)
              {
                if (this.animList.Data5[counter] == 1)
                {
                  int[] weight = this.animList.Weight;
                  int[] numArray = weight;
                  int index1 = counter;
                  int index2 = index1;
                  int num = weight[index1] + 4;
                  numArray[index2] = num;
                }
                else
                {
                  int[] weight = this.animList.Weight;
                  int[] numArray = weight;
                  int index3 = counter;
                  int index4 = index3;
                  int num = weight[index3] + 3;
                  numArray[index4] = num;
                }
              }
              else if (this.animList.Weight[counter] >= 32)
              {
                if (this.game.TempCombat.IList[this.game.TempCombat.FindISlot(this.animList.Id[counter])].IKilled == this.game.TempCombat.CombatRound)
                  this.animList.Weight[counter] = -1;
                else
                  this.animList.Remove(counter);
              }
            }
          }
          if (this.animList.Counter > -1 & !Information.IsNothing((object) this.bufferBitmap))
          {
            Graphics graphics = Graphics.FromImage((Image) this.OwnBitmap);
            ref Graphics local1 = ref graphics;
            ref Bitmap local2 = ref this.bufferBitmap;
            ref Bitmap local3 = ref this.OwnBitmap;
            Rectangle rectangle1 = new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - 55);
            Rectangle srcrect1 = rectangle1;
            Rectangle rectangle2 = new Rectangle(0, 0, this.OwnBitmap.Width, this.OwnBitmap.Height - 55);
            Rectangle destrect1 = rectangle2;
            DrawMod.DrawSimplePart2Fast(ref local1, ref local2, ref local3, srcrect1, destrect1);
            for (int counter = this.animList.Counter; counter >= 0; counter += -1)
            {
              int num1 = this.animList.Weight[counter];
              if (num1 > 0)
              {
                if (this.animList.Data5[counter] == 1)
                {
                  ref Graphics local4 = ref graphics;
                  Bitmap bitmap = BitmapStore.GetBitmap(this.game.EXPLOSION, 1);
                  ref Bitmap local5 = ref bitmap;
                  rectangle2 = new Rectangle(128 * (num1 - 1), 0, 128, 96);
                  Rectangle srcrect2 = rectangle2;
                  rectangle1 = new Rectangle(this.animList.Data1[counter] - (int) Math.Round((double) this.animList.Data3[counter] * 0.5), this.animList.Data2[counter] - (int) Math.Round((double) this.animList.Data4[counter] * 0.5), this.animList.Data3[counter] * 2, this.animList.Data4[counter] * 2);
                  Rectangle destrect2 = rectangle1;
                  DrawMod.DrawSimplePart2(ref local4, ref local5, srcrect2, destrect2);
                }
                else
                {
                  float num2 = 1f;
                  if (num1 < 23)
                    num2 = 1f - Math.Min(1f, (float) (23 - num1) / 6f);
                  ref Graphics local6 = ref graphics;
                  Bitmap bitmap = BitmapStore.GetBitmap(this.game.EXPLOSION, 1);
                  ref Bitmap local7 = ref bitmap;
                  rectangle2 = new Rectangle(128 * (num1 - 1), 0, 128, 96);
                  Rectangle srcrect3 = rectangle2;
                  rectangle1 = new Rectangle(this.animList.Data1[counter] - (int) Math.Round((double) this.animList.Data3[counter] * 0.5), this.animList.Data2[counter] - (int) Math.Round((double) this.animList.Data4[counter] * 0.5), this.animList.Data3[counter] * 2, this.animList.Data4[counter] * 2);
                  Rectangle destrect3 = rectangle1;
                  double a = (double) num2;
                  DrawMod.DrawSimplePart2ColouredNew(ref local6, ref local7, srcrect3, destrect3, 1f, 1f, 1f, (float) a);
                }
              }
            }
            graphics.Dispose();
          }
          this.lastAnimTime = DateAndTime.Now;
          windowReturnClass.SetFlag(true);
          return windowReturnClass;
        }
      }
      windowReturnClass.SetFlag(false);
      return windowReturnClass;
    }

    pub void PopUpRefresh()
    {
      this.game.EditObj.AreaSlot = -1;
      this.game.EditObj.AreaX = -1;
      this.game.EditObj.AreaY = -1;
      this.game.EditObj.AreaMap = -1;
      this.game.EditObj.AreaValue = -1;
      this.dostuff();
    }
  }
}
