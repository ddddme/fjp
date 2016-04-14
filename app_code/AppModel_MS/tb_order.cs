using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using yangNetCl;
using _D = yangNetCl.Cl_DataMag;
namespace d_fjp
{   
	/// <summary>
	 	///订单
	/// </summary>
	public class tb_order
	{
      	private int _tb_order_id;
		private string _tb_order_transid="";
		private string _tb_order_wxbs="";
		private string _tb_order_batchid="";
		private string _tb_order_wechattransid="";
		private decimal? _tb_order_amount=0;
		private DateTime? _tb_order_createdate=DateTime.Now;
		private DateTime? _tb_order_paydate=DateTime.Now;
		private string _tb_order_status="业务创建";
		private string _tb_order_refundid="";
		private DateTime? _tb_order_refundtime=DateTime.Now;
		private string _tb_order_refundstatus="";
		private string _tb_order_tcjg="";
		private string _tb_order_pborderid="";
		private string _tb_order_prepayid="";
		private string _tb_order_cc="";
		private DateTime? _tb_order_fcsj=DateTime.Now;
		private string _tb_order_ddz="";
		private string _tb_order_cx="";
		private int _tb_order_lc=0;
		private decimal? _tb_order_pj=0;
		private decimal? _tb_order_fjf=0;
		private string _tb_order_jpk="";
		private string _tb_order_zwh="";
		      	/// <summary>
		/// 主键
        /// </summary>		
        public int tb_order_ID
        {
            get{ return _tb_order_id; }
            set{ _tb_order_id = value; }
        }        
		/// <summary>
		/// 微信订单号
        /// </summary>		
        public string tb_order_TransID
        {
            get{ return _tb_order_transid; }
            set{ _tb_order_transid = value; }
        }        
		/// <summary>
		/// 微信标识
        /// </summary>		
        public string tb_order_wxbs
        {
            get{ return _tb_order_wxbs; }
            set{ _tb_order_wxbs = value; }
        }        
		/// <summary>
		/// 商户订单号
        /// </summary>		
        public string tb_order_BatchID
        {
            get{ return _tb_order_batchid; }
            set{ _tb_order_batchid = value; }
        }        
		/// <summary>
		/// 微信支付流水号
        /// </summary>		
        public string tb_order_WechatTransID
        {
            get{ return _tb_order_wechattransid; }
            set{ _tb_order_wechattransid = value; }
        }        
		/// <summary>
		/// 订单金额
        /// </summary>		
        public decimal? tb_order_Amount
        {
            get{ return _tb_order_amount; }
            set{ _tb_order_amount = value; }
        }        
		/// <summary>
		/// 提交时间
        /// </summary>		
        public DateTime? tb_order_CreateDate
        {
            get{ return _tb_order_createdate; }
            set{ _tb_order_createdate = value; }
        }        
		/// <summary>
		/// 支付结果时间
        /// </summary>		
        public DateTime? tb_order_PayDate
        {
            get{ return _tb_order_paydate; }
            set{ _tb_order_paydate = value; }
        }        
		/// <summary>
		/// 订单状态
        /// </summary>		
        public string tb_order_Status
        {
            get{ return _tb_order_status; }
            set{ _tb_order_status = value; }
        }        
		/// <summary>
		/// 退款单号
        /// </summary>		
        public string tb_order_refundid
        {
            get{ return _tb_order_refundid; }
            set{ _tb_order_refundid = value; }
        }        
		/// <summary>
		/// 退款申请时间
        /// </summary>		
        public DateTime? tb_order_refundTime
        {
            get{ return _tb_order_refundtime; }
            set{ _tb_order_refundtime = value; }
        }        
		/// <summary>
		/// 退款申请状态
        /// </summary>		
        public string tb_order_refundstatus
        {
            get{ return _tb_order_refundstatus; }
            set{ _tb_order_refundstatus = value; }
        }        
		/// <summary>
		/// 退款结果
        /// </summary>		
        public string tb_order_tcjg
        {
            get{ return _tb_order_tcjg; }
            set{ _tb_order_tcjg = value; }
        }        
		/// <summary>
		/// 预支付订单号
        /// </summary>		
        public string tb_order_pbOrderID
        {
            get{ return _tb_order_pborderid; }
            set{ _tb_order_pborderid = value; }
        }        
		/// <summary>
		/// 预支付交易会话标识
        /// </summary>		
        public string tb_order_prepayID
        {
            get{ return _tb_order_prepayid; }
            set{ _tb_order_prepayid = value; }
        }        
		/// <summary>
		/// 车次
        /// </summary>		
        public string tb_order_cc
        {
            get{ return _tb_order_cc; }
            set{ _tb_order_cc = value; }
        }        
		/// <summary>
		/// 发车时间
        /// </summary>		
        public DateTime? tb_order_fcsj
        {
            get{ return _tb_order_fcsj; }
            set{ _tb_order_fcsj = value; }
        }        
		/// <summary>
		/// 到达站
        /// </summary>		
        public string tb_order_ddz
        {
            get{ return _tb_order_ddz; }
            set{ _tb_order_ddz = value; }
        }        
		/// <summary>
		/// 车型
        /// </summary>		
        public string tb_order_cx
        {
            get{ return _tb_order_cx; }
            set{ _tb_order_cx = value; }
        }        
		/// <summary>
		/// 里程
        /// </summary>		
        public int tb_order_lc
        {
            get{ return _tb_order_lc; }
            set{ _tb_order_lc = value; }
        }        
		/// <summary>
		/// 票价
        /// </summary>		
        public decimal? tb_order_pj
        {
            get{ return _tb_order_pj; }
            set{ _tb_order_pj = value; }
        }        
		/// <summary>
		/// 附加费
        /// </summary>		
        public decimal? tb_order_fjf
        {
            get{ return _tb_order_fjf; }
            set{ _tb_order_fjf = value; }
        }        
		/// <summary>
		/// 检票口
        /// </summary>		
        public string tb_order_jpk
        {
            get{ return _tb_order_jpk; }
            set{ _tb_order_jpk = value; }
        }        
		/// <summary>
		/// 座位号
        /// </summary>		
        public string tb_order_zwh
        {
            get{ return _tb_order_zwh; }
            set{ _tb_order_zwh = value; }
        }        
		        /// <summary>
        /// 通过GID返回实体对象
        /// </summary>
        public static tb_order getNewModel(int pId, _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.Append("select tb_order_ID, tb_order_TransID, tb_order_wxbs, tb_order_BatchID, tb_order_WechatTransID, tb_order_Amount, tb_order_CreateDate, tb_order_PayDate, tb_order_Status, tb_order_refundid, tb_order_refundTime, tb_order_refundstatus, tb_order_tcjg, tb_order_pbOrderID, tb_order_prepayID, tb_order_cc, tb_order_fcsj, tb_order_ddz, tb_order_cx, tb_order_lc, tb_order_pj, tb_order_fjf, tb_order_jpk, tb_order_zwh  ");			
			strSql.Append("  from tb_order ");
            strSql.Append(" where tb_order_ID='"+pId+"'");

            DataTable dt = _D.getDb(strSql.ToString(),pMt:mt);
            if (dt.Rows.Count> 0)
            {
                tb_order model = new tb_order();
		      	if(dt.Rows[0]["tb_order_ID"] != null&&dt.Rows[0]["tb_order_ID"].ToString()!="")model.tb_order_ID=Convert.ToInt32(dt.Rows[0]["tb_order_ID"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_TransID"] != null&&dt.Rows[0]["tb_order_TransID"].ToString()!="")model.tb_order_TransID=dt.Rows[0]["tb_order_TransID"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_wxbs"] != null&&dt.Rows[0]["tb_order_wxbs"].ToString()!="")model.tb_order_wxbs=dt.Rows[0]["tb_order_wxbs"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_BatchID"] != null&&dt.Rows[0]["tb_order_BatchID"].ToString()!="")model.tb_order_BatchID=dt.Rows[0]["tb_order_BatchID"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_WechatTransID"] != null&&dt.Rows[0]["tb_order_WechatTransID"].ToString()!="")model.tb_order_WechatTransID=dt.Rows[0]["tb_order_WechatTransID"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_Amount"] != null&&dt.Rows[0]["tb_order_Amount"].ToString()!="")model.tb_order_Amount=Convert.ToDecimal(dt.Rows[0]["tb_order_Amount"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_CreateDate"] != null&&dt.Rows[0]["tb_order_CreateDate"].ToString()!="")model.tb_order_CreateDate=Convert.ToDateTime(dt.Rows[0]["tb_order_CreateDate"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_PayDate"] != null&&dt.Rows[0]["tb_order_PayDate"].ToString()!="")model.tb_order_PayDate=Convert.ToDateTime(dt.Rows[0]["tb_order_PayDate"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_Status"] != null&&dt.Rows[0]["tb_order_Status"].ToString()!="")model.tb_order_Status=dt.Rows[0]["tb_order_Status"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_refundid"] != null&&dt.Rows[0]["tb_order_refundid"].ToString()!="")model.tb_order_refundid=dt.Rows[0]["tb_order_refundid"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_refundTime"] != null&&dt.Rows[0]["tb_order_refundTime"].ToString()!="")model.tb_order_refundTime=Convert.ToDateTime(dt.Rows[0]["tb_order_refundTime"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_refundstatus"] != null&&dt.Rows[0]["tb_order_refundstatus"].ToString()!="")model.tb_order_refundstatus=dt.Rows[0]["tb_order_refundstatus"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_tcjg"] != null&&dt.Rows[0]["tb_order_tcjg"].ToString()!="")model.tb_order_tcjg=dt.Rows[0]["tb_order_tcjg"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_pbOrderID"] != null&&dt.Rows[0]["tb_order_pbOrderID"].ToString()!="")model.tb_order_pbOrderID=dt.Rows[0]["tb_order_pbOrderID"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_prepayID"] != null&&dt.Rows[0]["tb_order_prepayID"].ToString()!="")model.tb_order_prepayID=dt.Rows[0]["tb_order_prepayID"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_cc"] != null&&dt.Rows[0]["tb_order_cc"].ToString()!="")model.tb_order_cc=dt.Rows[0]["tb_order_cc"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_fcsj"] != null&&dt.Rows[0]["tb_order_fcsj"].ToString()!="")model.tb_order_fcsj=Convert.ToDateTime(dt.Rows[0]["tb_order_fcsj"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_ddz"] != null&&dt.Rows[0]["tb_order_ddz"].ToString()!="")model.tb_order_ddz=dt.Rows[0]["tb_order_ddz"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_cx"] != null&&dt.Rows[0]["tb_order_cx"].ToString()!="")model.tb_order_cx=dt.Rows[0]["tb_order_cx"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_lc"] != null&&dt.Rows[0]["tb_order_lc"].ToString()!="")model.tb_order_lc=Convert.ToInt32(dt.Rows[0]["tb_order_lc"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_pj"] != null&&dt.Rows[0]["tb_order_pj"].ToString()!="")model.tb_order_pj=Convert.ToDecimal(dt.Rows[0]["tb_order_pj"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_fjf"] != null&&dt.Rows[0]["tb_order_fjf"].ToString()!="")model.tb_order_fjf=Convert.ToDecimal(dt.Rows[0]["tb_order_fjf"].ToString());		      	
		      	if(dt.Rows[0]["tb_order_jpk"] != null&&dt.Rows[0]["tb_order_jpk"].ToString()!="")model.tb_order_jpk=dt.Rows[0]["tb_order_jpk"].ToString();		      	
		      	if(dt.Rows[0]["tb_order_zwh"] != null&&dt.Rows[0]["tb_order_zwh"].ToString()!="")model.tb_order_zwh=dt.Rows[0]["tb_order_zwh"].ToString();		      	
		      	return model;                
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        public void add(_D.myTransaction mt = null){
            StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tb_order(");			
            strSql.Append("tb_order_TransID,tb_order_wxbs,tb_order_BatchID,tb_order_WechatTransID,tb_order_Amount,tb_order_CreateDate,tb_order_PayDate,tb_order_Status,tb_order_refundid,tb_order_refundTime,tb_order_refundstatus,tb_order_tcjg,tb_order_pbOrderID,tb_order_prepayID,tb_order_cc,tb_order_fcsj,tb_order_ddz,tb_order_cx,tb_order_lc,tb_order_pj,tb_order_fjf,tb_order_jpk,tb_order_zwh");
			strSql.Append(") values (");
            strSql.Append("@tb_order_TransID,@tb_order_wxbs,@tb_order_BatchID,@tb_order_WechatTransID,@tb_order_Amount,@tb_order_CreateDate,@tb_order_PayDate,@tb_order_Status,@tb_order_refundid,@tb_order_refundTime,@tb_order_refundstatus,@tb_order_tcjg,@tb_order_pbOrderID,@tb_order_prepayID,@tb_order_cc,@tb_order_fcsj,@tb_order_ddz,@tb_order_cx,@tb_order_lc,@tb_order_pj,@tb_order_fjf,@tb_order_jpk,@tb_order_zwh");            
            strSql.Append(") ");       
			SqlParameter[] parameters = {
			            new SqlParameter("@tb_order_TransID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_wxbs", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_BatchID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_WechatTransID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_Amount", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_CreateDate", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_PayDate", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_Status", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_refundid", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_refundTime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_refundstatus", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_tcjg", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_pbOrderID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_prepayID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_cc", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_fcsj", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_ddz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_cx", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_lc", SqlDbType.SmallInt) ,            
                        new SqlParameter("@tb_order_pj", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_fjf", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_jpk", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_zwh", SqlDbType.VarChar,8000)             
              
            };
                        
            parameters[0].Value =this.tb_order_TransID;                        
            parameters[1].Value =this.tb_order_wxbs;                        
            parameters[2].Value =this.tb_order_BatchID;                        
            parameters[3].Value =this.tb_order_WechatTransID;                        
            parameters[4].Value =this.tb_order_Amount;                        
            parameters[5].Value =this.tb_order_CreateDate;                        
            parameters[6].Value =this.tb_order_PayDate;                        
            parameters[7].Value =this.tb_order_Status;                        
            parameters[8].Value =this.tb_order_refundid;                        
            parameters[9].Value =this.tb_order_refundTime;                        
            parameters[10].Value =this.tb_order_refundstatus;                        
            parameters[11].Value =this.tb_order_tcjg;                        
            parameters[12].Value =this.tb_order_pbOrderID;                        
            parameters[13].Value =this.tb_order_prepayID;                        
            parameters[14].Value =this.tb_order_cc;                        
            parameters[15].Value =this.tb_order_fcsj;                        
            parameters[16].Value =this.tb_order_ddz;                        
            parameters[17].Value =this.tb_order_cx;                        
            parameters[18].Value =this.tb_order_lc;                        
            parameters[19].Value =this.tb_order_pj;                        
            parameters[20].Value =this.tb_order_fjf;                        
            parameters[21].Value =this.tb_order_jpk;                        
            parameters[22].Value =this.tb_order_zwh;            

            tb_order_ID=_D.dbExe(strSql.ToString(), parameters,pMt:mt);
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(string strWhere="", _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
			strSql.Append("update tb_order set ");         
            strSql.Append(" tb_order_TransID = @tb_order_TransID , ");         
            strSql.Append(" tb_order_wxbs = @tb_order_wxbs , ");         
            strSql.Append(" tb_order_BatchID = @tb_order_BatchID , ");         
            strSql.Append(" tb_order_WechatTransID = @tb_order_WechatTransID , ");         
            strSql.Append(" tb_order_Amount = @tb_order_Amount , ");         
            strSql.Append(" tb_order_CreateDate = @tb_order_CreateDate , ");         
            strSql.Append(" tb_order_PayDate = @tb_order_PayDate , ");         
            strSql.Append(" tb_order_Status = @tb_order_Status , ");         
            strSql.Append(" tb_order_refundid = @tb_order_refundid , ");         
            strSql.Append(" tb_order_refundTime = @tb_order_refundTime , ");         
            strSql.Append(" tb_order_refundstatus = @tb_order_refundstatus , ");         
            strSql.Append(" tb_order_tcjg = @tb_order_tcjg , ");         
            strSql.Append(" tb_order_pbOrderID = @tb_order_pbOrderID , ");         
            strSql.Append(" tb_order_prepayID = @tb_order_prepayID , ");         
            strSql.Append(" tb_order_cc = @tb_order_cc , ");         
            strSql.Append(" tb_order_fcsj = @tb_order_fcsj , ");         
            strSql.Append(" tb_order_ddz = @tb_order_ddz , ");         
            strSql.Append(" tb_order_cx = @tb_order_cx , ");         
            strSql.Append(" tb_order_lc = @tb_order_lc , ");         
            strSql.Append(" tb_order_pj = @tb_order_pj , ");         
            strSql.Append(" tb_order_fjf = @tb_order_fjf , ");         
            strSql.Append(" tb_order_jpk = @tb_order_jpk , ");         
            strSql.Append(" tb_order_zwh = @tb_order_zwh  ");            	
            if (strWhere.Trim() == "")
                strWhere = "where tb_order_ID='" + this.tb_order_ID + "'";
            else
            {
                if (strWhere.Trim().Substring(0, 5).ToLower() != "where")
                {
                    if (strWhere.Trim().Substring(0, 3).ToLower() != "and")
                        strWhere = " where " + strWhere;
                    else
                        strWhere = " where 1=1 " + strWhere;
                }
            }
            strSql.Append(strWhere);
			SqlParameter[] parameters = {
			            new SqlParameter("@tb_order_TransID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_wxbs", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_BatchID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_WechatTransID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_Amount", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_CreateDate", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_PayDate", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_Status", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_refundid", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_refundTime", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_refundstatus", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_tcjg", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_pbOrderID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_prepayID", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_cc", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_fcsj", SqlDbType.SmallDateTime) ,            
                        new SqlParameter("@tb_order_ddz", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_cx", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_lc", SqlDbType.SmallInt) ,            
                        new SqlParameter("@tb_order_pj", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_fjf", SqlDbType.Money) ,            
                        new SqlParameter("@tb_order_jpk", SqlDbType.VarChar,8000) ,            
                        new SqlParameter("@tb_order_zwh", SqlDbType.VarChar,8000)             
              
            };
                        
            parameters[0].Value =this.tb_order_ID;                        
            parameters[1].Value =this.tb_order_TransID;                        
            parameters[2].Value =this.tb_order_wxbs;                        
            parameters[3].Value =this.tb_order_BatchID;                        
            parameters[4].Value =this.tb_order_WechatTransID;                        
            parameters[5].Value =this.tb_order_Amount;                        
            parameters[6].Value =this.tb_order_CreateDate;                        
            parameters[7].Value =this.tb_order_PayDate;                        
            parameters[8].Value =this.tb_order_Status;                        
            parameters[9].Value =this.tb_order_refundid;                        
            parameters[10].Value =this.tb_order_refundTime;                        
            parameters[11].Value =this.tb_order_refundstatus;                        
            parameters[12].Value =this.tb_order_tcjg;                        
            parameters[13].Value =this.tb_order_pbOrderID;                        
            parameters[14].Value =this.tb_order_prepayID;                        
            parameters[15].Value =this.tb_order_cc;                        
            parameters[16].Value =this.tb_order_fcsj;                        
            parameters[17].Value =this.tb_order_ddz;                        
            parameters[18].Value =this.tb_order_cx;                        
            parameters[19].Value =this.tb_order_lc;                        
            parameters[20].Value =this.tb_order_pj;                        
            parameters[21].Value =this.tb_order_fjf;                        
            parameters[22].Value =this.tb_order_jpk;                        
            parameters[23].Value =this.tb_order_zwh;            

            int rows = _D.dbExe(strSql.ToString(), parameters,pMt:mt);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        public bool Delete(_D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_order ");
            strSql.Append("where tb_order_ID='" + this.tb_order_ID + "'");

            int rows = _D.dbExe(strSql.ToString(),pMt:mt);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetList(string strWhere = "",string pColumns="",string pOrder="", _D.myTransaction mt = null)
        {
            StringBuilder strSql = new StringBuilder();
            if(string.IsNullOrEmpty(pColumns))
				strSql.Append("select  tb_order_ID, tb_order_TransID, tb_order_wxbs, tb_order_BatchID, tb_order_WechatTransID, tb_order_Amount, tb_order_CreateDate, tb_order_PayDate, tb_order_Status, tb_order_refundid, tb_order_refundTime, tb_order_refundstatus, tb_order_tcjg, tb_order_pbOrderID, tb_order_prepayID, tb_order_cc, tb_order_fcsj, tb_order_ddz, tb_order_cx, tb_order_lc, tb_order_pj, tb_order_fjf, tb_order_jpk, tb_order_zwh ");			
			else
				strSql.Append("select " + pColumns);
			strSql.Append("  from tb_order ");
            if (strWhere.Trim() != "")
            {
                if (strWhere.Trim().Substring(0, 5).ToLower() != "where")
                {
                    if (strWhere.Trim().Substring(0, 3).ToLower() != "and")
                        strWhere = " where " + strWhere;
                    else
                        strWhere = " where 1=1 " + strWhere;
                }
                strSql.Append(strWhere);
            }
            if (!string.IsNullOrEmpty(pOrder))
                strSql.Append(" order by " + pOrder);
            return _D.getDb(strSql.ToString(),pMt:mt);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<tb_order> GetModelList(string strWhere="",string pColumns="",string pOrder="",_D.myTransaction mt = null)
		{
			DataTable dt =GetList(strWhere,pColumns,pOrder,mt);
			return DataTableToList(dt);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<tb_order> DataTableToList(DataTable dt)
		{
			List<tb_order> modelList = new List<tb_order>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				tb_order model;
				for (int n = 0; n < rowsCount; n++)
				{
				    model = new tb_order();
				    if(dt.Columns.Contains("tb_order_ID")){if(dt.Rows[n]["tb_order_ID"] != null&&dt.Rows[n]["tb_order_ID"].ToString()!="")model.tb_order_ID=Convert.ToInt32(dt.Rows[n]["tb_order_ID"].ToString());};
					if(dt.Columns.Contains("tb_order_TransID")){if(dt.Rows[n]["tb_order_TransID"] != null&&dt.Rows[n]["tb_order_TransID"].ToString()!="")model.tb_order_TransID=dt.Rows[n]["tb_order_TransID"].ToString();};
					if(dt.Columns.Contains("tb_order_wxbs")){if(dt.Rows[n]["tb_order_wxbs"] != null&&dt.Rows[n]["tb_order_wxbs"].ToString()!="")model.tb_order_wxbs=dt.Rows[n]["tb_order_wxbs"].ToString();};
					if(dt.Columns.Contains("tb_order_BatchID")){if(dt.Rows[n]["tb_order_BatchID"] != null&&dt.Rows[n]["tb_order_BatchID"].ToString()!="")model.tb_order_BatchID=dt.Rows[n]["tb_order_BatchID"].ToString();};
					if(dt.Columns.Contains("tb_order_WechatTransID")){if(dt.Rows[n]["tb_order_WechatTransID"] != null&&dt.Rows[n]["tb_order_WechatTransID"].ToString()!="")model.tb_order_WechatTransID=dt.Rows[n]["tb_order_WechatTransID"].ToString();};
					if(dt.Columns.Contains("tb_order_Amount")){if(dt.Rows[n]["tb_order_Amount"] != null&&dt.Rows[n]["tb_order_Amount"].ToString()!="")model.tb_order_Amount=Convert.ToDecimal(dt.Rows[n]["tb_order_Amount"].ToString());};
					if(dt.Columns.Contains("tb_order_CreateDate")){if(dt.Rows[n]["tb_order_CreateDate"] != null&&dt.Rows[n]["tb_order_CreateDate"].ToString()!="")model.tb_order_CreateDate=Convert.ToDateTime(dt.Rows[n]["tb_order_CreateDate"].ToString());};
					if(dt.Columns.Contains("tb_order_PayDate")){if(dt.Rows[n]["tb_order_PayDate"] != null&&dt.Rows[n]["tb_order_PayDate"].ToString()!="")model.tb_order_PayDate=Convert.ToDateTime(dt.Rows[n]["tb_order_PayDate"].ToString());};
					if(dt.Columns.Contains("tb_order_Status")){if(dt.Rows[n]["tb_order_Status"] != null&&dt.Rows[n]["tb_order_Status"].ToString()!="")model.tb_order_Status=dt.Rows[n]["tb_order_Status"].ToString();};
					if(dt.Columns.Contains("tb_order_refundid")){if(dt.Rows[n]["tb_order_refundid"] != null&&dt.Rows[n]["tb_order_refundid"].ToString()!="")model.tb_order_refundid=dt.Rows[n]["tb_order_refundid"].ToString();};
					if(dt.Columns.Contains("tb_order_refundTime")){if(dt.Rows[n]["tb_order_refundTime"] != null&&dt.Rows[n]["tb_order_refundTime"].ToString()!="")model.tb_order_refundTime=Convert.ToDateTime(dt.Rows[n]["tb_order_refundTime"].ToString());};
					if(dt.Columns.Contains("tb_order_refundstatus")){if(dt.Rows[n]["tb_order_refundstatus"] != null&&dt.Rows[n]["tb_order_refundstatus"].ToString()!="")model.tb_order_refundstatus=dt.Rows[n]["tb_order_refundstatus"].ToString();};
					if(dt.Columns.Contains("tb_order_tcjg")){if(dt.Rows[n]["tb_order_tcjg"] != null&&dt.Rows[n]["tb_order_tcjg"].ToString()!="")model.tb_order_tcjg=dt.Rows[n]["tb_order_tcjg"].ToString();};
					if(dt.Columns.Contains("tb_order_pbOrderID")){if(dt.Rows[n]["tb_order_pbOrderID"] != null&&dt.Rows[n]["tb_order_pbOrderID"].ToString()!="")model.tb_order_pbOrderID=dt.Rows[n]["tb_order_pbOrderID"].ToString();};
					if(dt.Columns.Contains("tb_order_prepayID")){if(dt.Rows[n]["tb_order_prepayID"] != null&&dt.Rows[n]["tb_order_prepayID"].ToString()!="")model.tb_order_prepayID=dt.Rows[n]["tb_order_prepayID"].ToString();};
					if(dt.Columns.Contains("tb_order_cc")){if(dt.Rows[n]["tb_order_cc"] != null&&dt.Rows[n]["tb_order_cc"].ToString()!="")model.tb_order_cc=dt.Rows[n]["tb_order_cc"].ToString();};
					if(dt.Columns.Contains("tb_order_fcsj")){if(dt.Rows[n]["tb_order_fcsj"] != null&&dt.Rows[n]["tb_order_fcsj"].ToString()!="")model.tb_order_fcsj=Convert.ToDateTime(dt.Rows[n]["tb_order_fcsj"].ToString());};
					if(dt.Columns.Contains("tb_order_ddz")){if(dt.Rows[n]["tb_order_ddz"] != null&&dt.Rows[n]["tb_order_ddz"].ToString()!="")model.tb_order_ddz=dt.Rows[n]["tb_order_ddz"].ToString();};
					if(dt.Columns.Contains("tb_order_cx")){if(dt.Rows[n]["tb_order_cx"] != null&&dt.Rows[n]["tb_order_cx"].ToString()!="")model.tb_order_cx=dt.Rows[n]["tb_order_cx"].ToString();};
					if(dt.Columns.Contains("tb_order_lc")){if(dt.Rows[n]["tb_order_lc"] != null&&dt.Rows[n]["tb_order_lc"].ToString()!="")model.tb_order_lc=Convert.ToInt32(dt.Rows[n]["tb_order_lc"].ToString());};
					if(dt.Columns.Contains("tb_order_pj")){if(dt.Rows[n]["tb_order_pj"] != null&&dt.Rows[n]["tb_order_pj"].ToString()!="")model.tb_order_pj=Convert.ToDecimal(dt.Rows[n]["tb_order_pj"].ToString());};
					if(dt.Columns.Contains("tb_order_fjf")){if(dt.Rows[n]["tb_order_fjf"] != null&&dt.Rows[n]["tb_order_fjf"].ToString()!="")model.tb_order_fjf=Convert.ToDecimal(dt.Rows[n]["tb_order_fjf"].ToString());};
					if(dt.Columns.Contains("tb_order_jpk")){if(dt.Rows[n]["tb_order_jpk"] != null&&dt.Rows[n]["tb_order_jpk"].ToString()!="")model.tb_order_jpk=dt.Rows[n]["tb_order_jpk"].ToString();};
					if(dt.Columns.Contains("tb_order_zwh")){if(dt.Rows[n]["tb_order_zwh"] != null&&dt.Rows[n]["tb_order_zwh"].ToString()!="")model.tb_order_zwh=dt.Rows[n]["tb_order_zwh"].ToString();};
										
				modelList.Add(model);
				}
			}
			return modelList;
		}
	}
}