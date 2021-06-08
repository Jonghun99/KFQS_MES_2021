using DC00_assm;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KFQS_Form
{
    public partial class MM_StockMM : DC00_WinForm.BaseMDIChildForm
    {
        // 그리드를 셋팅 할 수 있도록 도와주는 함수 클래스
        UltraGridUtil _GridUtil = new UltraGridUtil();
        //공장 변수 입력
        //private sPlantCode = LoginInfo.
        public MM_StockMM()
        {
            InitializeComponent();
        }

        private void MM_StockMM_Load(object sender, EventArgs e)
        {
            // 그리드를 셋팅한다.
            try
            {
                _GridUtil.InitializeGrid(this.grid1, false, true, false, "", false);
                _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",      true, GridColDataType_emu.VarChar, 130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",   "작업자ID",  true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME", "작업자 명", true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",    "작업반",    true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",      "그룹",      true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",   "부서",      true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",    "연락처",    true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, true);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "등록일시",  true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, false);
                _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "등록자",    true, GridColDataType_emu.VarChar,130, 130, Infragistics.Win.HAlign.Left, true, false);

                //셋팅 내역 그리드와 바인딩
                _GridUtil.SetInitUltraGridBind(grid1); //셋팅 내역 그리드와 바인딩

                Common _Common = new Common();
                DataTable dtTemp = new DataTable();
                // PLANTCODE 기준정보 가져와서 데이터 테이블에 추가.
                dtTemp = _Common.Standard_CODE("PLANTCODE"); 
                // 데이터 테이블에 있는 데이터를 해당 콤보박스에 추가.
                Common.FillComboboxMaster(this.cboPlantCode_H, dtTemp, 
                                          dtTemp.Columns["CODE_ID"].ColumnName, 
                                          dtTemp.Columns["CODE_NAME"].ColumnName, 
                                          "ALL","");
                UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", dtTemp, "CODE_ID", "CODE_NAME");

                dtTemp = _Common.Standard_CODE("ITEMCODE");
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
        }
        public override void DoInquire()
        {
            base.DoInquire();
            DBHelper helper = new DBHelper(false);
            try
            {
                string sPlantcode  = cboPlantCode_H.Value.ToString();
                string sItemCode   = txtItemCode.Text.ToString();
                string sItemName   = txtItemName.Text.ToString();

                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("18MM_StockMM_S1", CommandType.StoredProcedure
                                          , helper.CreateParameter("PLANTCODE",    sPlantcode,  DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ITEMCODE",     sItemCode,   DbType.String, ParameterDirection.Input)
                                          , helper.CreateParameter("ITEMNAME",     sItemName, DbType.String, ParameterDirection.Input));
                this.ClosePrgForm();
                if (dtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = dtTemp;
                    grid1.DataBinds(dtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    ShowDialog("조회할 데이터가 없습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                }
            }
            catch(Exception ex)
            {
                ShowDialog(ex.Message, DC00_WinForm.DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoNew()
        {
            base.DoNew();
            this.grid1.InsertRow();

            this.grid1.ActiveRow.Cells["PLANTCODE"].Value = "1000";
            this.grid1.ActiveRow.Cells["GRPID"].Value     = "SW";
            this.grid1.ActiveRow.Cells["USEFLAG"].Value   = "Y";
            this.grid1.ActiveRow.Cells["INDATE"].Value    = DateTime.Now.ToString("yyyy-MM-dd");

            grid1.ActiveRow.Cells["MAKER"].Activation    = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation   = Activation.NoEdit;
        }

        public override void DoDelete()
        {
            base.DoDelete();
            this.grid1.DeleteRow();
        }

        public override void DoSave()
        {
            base.DoSave();
            DataTable dtTemp = new DataTable();
            dtTemp = grid1.chkChange();
            if (dtTemp.Rows.Count == 0) return;

            DBHelper helper = new DBHelper("", true);
            try
            {
                // 해당내역을 저장 하시겠습니까? 
                if (ShowDialog("해당 사항을 저장 하시겠습니까?",DC00_WinForm.DialogForm.DialogType.YESNO)
                    == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                foreach (DataRow drrow in dtTemp.Rows)
                {
                    switch (drrow.RowState)
                    {
                        case DataRowState.Deleted:
                            drrow.RejectChanges();
                            helper.ExecuteNoneQuery("18MM_StockMM_D1", CommandType.StoredProcedure,
                                                helper.CreateParameter("PLANTCODE", Convert.ToString(drrow["PLANTCODE"]),  DbType.String, ParameterDirection.Input),
                                                helper.CreateParameter("WORKERID",  Convert.ToString(drrow["WORKERID"]),   DbType.String, ParameterDirection.Input));
                            break;
                        case DataRowState.Added:
                            if (Convert.ToString(drrow["WORKERID"]) == string.Empty)
                            {
                                this.ClosePrgForm();
                                this.ShowDialog("작업자 ID 를 입력하세요.", DC00_WinForm.DialogForm.DialogType.OK);
                                return;
                            }
                            helper.ExecuteNoneQuery("18MM_StockMM_I1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE",  Convert.ToString(drrow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID",   Convert.ToString(drrow["WORKERID"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drrow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID",      Convert.ToString(drrow["GRPID"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE",   Convert.ToString(drrow["DEPTCODE"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE",    Convert.ToString(drrow["BANCODE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG",    Convert.ToString(drrow["USEFLAG"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO",    Convert.ToString(drrow["PHONENO"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE",     Convert.ToString(drrow["INDATE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE",    Convert.ToString(drrow["OUTDATE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("MAKER",      LoginInfo.UserID,                      DbType.String, ParameterDirection.Input)
                                                    );
                            break;
                        case DataRowState.Modified:
                             helper.ExecuteNoneQuery("18MM_StockMM_U1"
                                                    , CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE",  Convert.ToString(drrow["PLANTCODE"]),  DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERID",   Convert.ToString(drrow["WORKERID"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("WORKERNAME", Convert.ToString(drrow["WORKERNAME"]), DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("GRPID",      Convert.ToString(drrow["GRPID"]),      DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("DEPTCODE",   Convert.ToString(drrow["DEPTCODE"]),   DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("BANCODE",    Convert.ToString(drrow["BANCODE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("USEFLAG",    Convert.ToString(drrow["USEFLAG"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("PHONENO",    Convert.ToString(drrow["PHONENO"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("INDATE",     Convert.ToString(drrow["INDATE"]),     DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("OUTDATE",    Convert.ToString(drrow["OUTDATE"]),    DbType.String, ParameterDirection.Input)
                                                    , helper.CreateParameter("EDITOR",      LoginInfo.UserID,                      DbType.String, ParameterDirection.Input)
                                                    );
                            break;
                    }
                }
                if (helper.RSCODE == "S")
                {
                    string s = helper.RSMSG;
                    helper.Commit();
                    this.ShowDialog("정상적으로 등록 되었습니다.", DC00_WinForm.DialogForm.DialogType.OK);
                    DoInquire();
                }
            }
            catch (Exception ex)
            {
                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }
        }

    }
}
