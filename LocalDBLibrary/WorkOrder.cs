using LiteDB;
using MaximoServiceLibrary.model;

namespace LocalDBLibrary
{
    public class WorkOrder
    {
        
        // todo : move app config
        private static string dbString = "lite.db";
        
        public static void Insert(MaximoWorkOrder workOrder)
        {
            using (var db = new LiteDatabase(@dbString))
            {
                var workorders = db.GetCollection<MaximoWorkOrder>("workorders");
                workorders.Insert(workOrder);
            }
        }

        public static MaximoWorkOrder FindByWoNum(string num)
        {
            using (var db = new LiteDatabase(@dbString))
            {
                var workorders = db.GetCollection<MaximoWorkOrder>("workorders");
                return workorders.FindOne(x => x.wonum.Contains(num));
            }
        }
        
        public static MaximoWorkOrder FindByAssetAssetNum(string num)
        {
            using (var db = new LiteDatabase(@dbString))
            {
                var workorders = db.GetCollection<MaximoWorkOrder>("workorders");
                return workorders.FindOne(x => x.asset.assetnum.Contains(num));
            }
        }
    }
}