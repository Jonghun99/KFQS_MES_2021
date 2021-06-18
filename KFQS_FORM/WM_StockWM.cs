#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : 
//   Form Name    : 제품 재고 관리 및 상차 등록
//   Name Space   : 
//   Created Date : 
//   Made By      : 
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region <USING AREA>
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DC00_assm;
using DC_POPUP;
using DC00_WinForm;

#endregion

namespace KFQS_Form
{
    public partial class WM_StockWM : DC00_WinForm.BaseMDIChildForm
    {
        #region <MEMBER AREA>

        DataTable table         = new DataTable();
        DataTable rtnDtTemp     = new DataTable();
        UltraGridUtil _GridUtil = new UltraGridUtil();
        #endregion

        #region < CONSTRUCTOR >

        public WM_StockWM()
        {
            InitializeComponent();
        }
        #endregion

        #region  WM_StockWM
        private void WM_StockWM_Load(object sender, EventArgs e)
        {
            //그리드 객체 생성
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1, true, true, false, "", false);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK", "확정", true, GridColDataType_emu.CheckBox, 100, 120, Infragistics.Win.HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPFLAG", "상차여부", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE", "품목", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "품목명", true, GridColDataType_emu.VarChar, 140, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO", "LOTNO", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE", "입고창고", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY", "재고수량", true, GridColDataType_emu.Double, 100, 120, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE", "단위", true, GridColDataType_emu.VarChar, 100, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE", "입고일자", true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE", "등록일시", true, GridColDataType_emu.DateTime24, 120, 120, Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER", "등록자", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARNO", "", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE", "", true, GridColDataType_emu.VarChar, 120, 120, Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region 콤보박스
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  
            Common.FillComboboxMaster(this.cboPlantCode_H, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("YESNO");  
            Common.FillComboboxMaster(this.cboYesNo, rtnDtTemp, rtnDtTemp.Columns["CODE_ID"].ColumnName, rtnDtTemp.Columns["CODE_NAME"].ColumnName, "ALL", "");
            UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp, "CODE_ID", "CODE_NAME");

            rtnDtTemp = _Common.Standard_CODE("WHCODE");  
            UltraGridUtil.SetComboUltraGrid(this.grid1, "WHCODE", rtnDtTemp, "CODE_ID", "CODE_NAME");

            string sPlantCode = Convert.ToString(this.cboPlantCode_H.Value);
            this.cboPlantCode_H.Value = "1000";
            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btManager = new BizTextBoxManager();
            btManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER", new object[] { "1000", "" });
            btManager.PopUpAdd(txtWorker_H, txtWorkerName_H, "WORKER_MASTER", new object[] { "", "", "", "", "" });
            btManager.PopUpAdd(txtCustCode_H, txtCustName_H, "CUST_MASTER", new object[] { cboPlantCode_H, "", "", "", "" });

            #endregion
        }
        #endregion  WM_StockWM_Load

        #region <TOOL BAR AREA >
        public override void DoInquire()
        {   
            if (!CheckData())
            {
                return;
            }
            
            this._GridUtil.Grid_Clear(grid1);

            DBHelper helper = new DBHelper(false);

            try
            {

                string sPlantCode = Convert.ToString(cboPlantCode_H.Value);
                string sItemCode = Convert.ToString(txtItemCode_H.Value);
                string sStart     = string.Format("{0:yyyy-MM-dd}", dtStart_H.Value);
                string sEnd       = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);
                string sLotNo     = this.txtLotNo.Text;
                string sYesNo     = this.cboYesNo.Value.ToString();

                rtnDtTemp = helper.FillTable("18WM_StockWM_S1", CommandType.StoredProcedure
                                              , helper.CreateParameter("PLANTCODE",  sPlantCode,      DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ITEMCODE",   sItemCode,      DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("STARTDATE",  sStart,          DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("ENDDATE",    sEnd,            DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("LOTNO",      sLotNo,          DbType.String, ParameterDirection.Input)
                                              , helper.CreateParameter("SHIPFLAG",   sYesNo,          DbType.String, ParameterDirection.Input)
                                              );
                grid1.DataSource = rtnDtTemp;
                grid1.DataBinds();
                this.ClosePrgForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void dtStart_H_TextChanged(object sender, EventArgs e)
        {
            CheckData();
        }
        private bool CheckData()
        {
            int sSrart = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtStart_H.Value));
            int sEnd   = Convert.ToInt32(string.Format("{0:yyyyMMdd}", dtEnd_H.Value));
            if (sSrart > sEnd)
            {
                this.ShowDialog("조회 시작일자가 종료일자보다 큽니다.", DialogForm.DialogType.OK);
                return false;
            }
            return true;
        }
        #region <METHOD AREA>
        #endregion


        //public override void DoSave()
        //{

        //    DataTable dt = new DataTable();

        //    dt = grid1.chkChange();
        //    if (dt == null)
        //        return;

        //    if (this.cboWhCode.Value.ToString() == "")
        //    {
        //        this.ShowDialog("창고를 선택하세요", DialogForm.DialogType.OK);
        //        return;
        //    }
        //    DBHelper helper = new DBHelper("", false);

        //    try
        //    {
        //        //base.DoSave();

        //        if (this.ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
        //        {
        //            CancelProcess = true;
        //            return;
        //        }

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (Convert.ToString(dt.Rows[i]["CHK"]) == "0") continue;

        //            helper.ExecuteNoneQuery("00MM_StockOut_M_I1"
        //                                    , CommandType.StoredProcedure
        //                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(dt.Rows[i]["PLANTCODE"]), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("LOTNO", Convert.ToString(dt.Rows[i]["MATLOTNO"]), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("ITEMCODE", Convert.ToString(dt.Rows[i]["ITEMCODE"]), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("QTY", Convert.ToString(dt.Rows[i]["STOCKQTY"]), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("UnitCode", Convert.ToString(dt.Rows[i]["UnitCode"]), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("WhCode", Convert.ToString(cboWhCode.Value), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("StorageLocCode", Convert.ToString(cboStoreageLocCode.Value), DbType.String, ParameterDirection.Input)
        //                                    , helper.CreateParameter("WORKERID", this.WorkerID, DbType.String, ParameterDirection.Input));

        //            if (helper.RSCODE == "E")
        //            {
        //                this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
        //                helper.Rollback();
        //                return;
        //            }
        //        }

        //        helper.Commit();
        //        this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);
        //        this.ClosePrgForm();
        //        DoInquire();
        //    }
        //    catch (Exception ex)
        //    {
        //        helper.Rollback();
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        helper.Close();
        //    }
        //}

    }

}


