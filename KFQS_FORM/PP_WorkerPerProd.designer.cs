﻿namespace KFQS_Form
{
    partial class PP_WorkerPerProd
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.cboPlantCode_H = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.dtpEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.dtpStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.txtWorkerName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtWorkerId = new DC00_Component.SBtnTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.dtpEnd);
            this.gbxHeader.Controls.Add(this.dtpStart);
            this.gbxHeader.Controls.Add(this.ultraLabel3);
            this.gbxHeader.Controls.Add(this.ultraLabel1);
            this.gbxHeader.Controls.Add(this.cboPlantCode_H);
            this.gbxHeader.Controls.Add(this.txtWorkerId);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.ultraLabel5);
            this.gbxHeader.Location = new System.Drawing.Point(3, 3);
            this.gbxHeader.Size = new System.Drawing.Size(1292, 142);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(3, 145);
            this.gbxBody.Size = new System.Drawing.Size(1292, 630);
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance29;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance57;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance58.BackColor = System.Drawing.SystemColors.Control;
            appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance58;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1280, 618);
            this.grid1.TabIndex = 6;
            this.grid1.TabStop = false;
            this.grid1.Text = "LOT 투입";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(37, 51);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(50, 23);
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Text = "공장";
            // 
            // cboPlantCode_H
            // 
            this.cboPlantCode_H.Location = new System.Drawing.Point(93, 47);
            this.cboPlantCode_H.Name = "cboPlantCode_H";
            this.cboPlantCode_H.Size = new System.Drawing.Size(144, 35);
            this.cboPlantCode_H.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.DateButtons.Add(dateButton1);
            this.dtpEnd.Location = new System.Drawing.Point(1062, 49);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.NonAutoSizeHeight = 32;
            this.dtpEnd.Size = new System.Drawing.Size(142, 32);
            this.dtpEnd.TabIndex = 15;
            // 
            // dtpStart
            // 
            this.dtpStart.DateButtons.Add(dateButton2);
            this.dtpStart.Location = new System.Drawing.Point(908, 49);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.NonAutoSizeHeight = 32;
            this.dtpStart.Size = new System.Drawing.Size(140, 32);
            this.dtpStart.TabIndex = 14;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Location = new System.Drawing.Point(812, 52);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(98, 23);
            this.ultraLabel3.TabIndex = 13;
            this.ultraLabel3.Text = "지시일자";
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Location = new System.Drawing.Point(307, 51);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(67, 23);
            this.ultraLabel5.TabIndex = 18;
            this.ultraLabel5.Text = "작업자";
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.Location = new System.Drawing.Point(583, 47);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(195, 35);
            this.txtWorkerName.TabIndex = 17;
            // 
            // txtWorkerId
            // 
            appearance4.FontData.BoldAsString = "False";
            appearance4.FontData.UnderlineAsString = "False";
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerId.Appearance = appearance4;
            this.txtWorkerId.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtWorkerId.btnWidth = 26;
            this.txtWorkerId.Location = new System.Drawing.Point(380, 47);
            this.txtWorkerId.Name = "txtWorkerId";
            this.txtWorkerId.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.Size = new System.Drawing.Size(188, 35);
            this.txtWorkerId.TabIndex = 7;
            // 
            // PP_WorkerPerProd
            // 
            this.ClientSize = new System.Drawing.Size(1298, 778);
            this.Name = "PP_WorkerPerProd";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "생산 실적 등록";
            this.Load += new System.EventHandler(this.PP_WorkerPerProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DC00_Component.Grid grid1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode_H;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpEnd;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpStart;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtWorkerName;
        private DC00_Component.SBtnTextEditor txtWorkerId;
    }
}
